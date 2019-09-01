using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel.Design;

namespace AGershman.PhotoLib.WinForms.Controls
{
    public partial class LiveViewBox: UserControl
    {
        ICameraWithLiveView camera;
        Size szPrev;

        bool showGrid = false;
        Color gridColor = Color.Gray;
        DashStyle gridDashStyle = DashStyle.Dot;

        [Browsable(false)]
        public ICameraWithLiveView Camera
        {
            get
            {
                return camera;
            }

            set
            {
                if (camera != value)
                {
                    if (camera != null)
                    {
                        if (camera.LiveViewOn)
                            throw new InvalidOperationException();
                        camera.LiveViewFetched -= new EventHandler<LiveViewEventArgs>(camera_LiveViewFetched);
                    }

                    camera = value;
                    if (camera != null)
                        camera.LiveViewFetched += new EventHandler<LiveViewEventArgs>(camera_LiveViewFetched);
                }
            }
        }

        public bool ShowGrid
        {
            get
            {
                return showGrid;
            }

            set
            {
                showGrid = value;
                Refresh();
            }
        }

        public Color GridColor
        {
            get
            {
                return gridColor;
            }

            set
            {
                gridColor = value;
                Refresh();
            }
        }

        public DashStyle GridDashStyle
        {
            get
            {
                return gridDashStyle;
            }

            set
            {
                gridDashStyle = value;
                Refresh();
            }
        }

        public LiveViewBox()
        {
            InitializeComponent();
        }

        private bool getDesignMode()
        {
            try
            {
                IDesignerHost host;
                if (Site != null)
                {
                    host = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (host != null)
                    {
                        return host.RootComponent.Site.DesignMode;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        private void DrawGrid(Graphics g, int w, int h)
        {
            using (Pen pen = new Pen(gridColor))
            {
                int step = w / 3;
                g.DrawLine(pen, step, 0, step, h);

                step = 2 * w / 3;
                g.DrawLine(pen, step, 0, step, h);

                step = h / 3;
                g.DrawLine(pen, 0, step, w, step);

                step = 2 * h / 3;
                g.DrawLine(pen, 0, step, w, step);
            }
        }

        void camera_LiveViewFetched(object sender, LiveViewEventArgs e)
        {
            if (!pbView.IsDisposed)
            {
                using (Graphics g = pbView.CreateGraphics())
                {
                    try
                    {
                        Image img = (Image)e.Frame.Clone();

                        if (img.Size != szPrev)
                        {
                            using (Brush br = new SolidBrush(BackColor))
                                g.FillRectangle(br, pbView.ClientRectangle);
                            szPrev = img.Size;
                        }

                        if (showGrid)
                        {
                            using (Graphics gImg = Graphics.FromImage(img))
                            {
                                DrawGrid(gImg, img.Width, img.Height);
                            }
                        }

                        float by = Math.Min(Convert.ToSingle(pbView.Width) / img.Width, Convert.ToSingle(pbView.Height) / img.Height);
                        int offsX = (pbView.Width - Convert.ToInt32(img.Width * by)) / 2;
                        int offsY = (pbView.Height - Convert.ToInt32(img.Height * by)) / 2;

                        g.DrawImage(img,
                            new Rectangle(offsX, offsY, pbView.Width - 2 * offsX, pbView.Height - 2 * offsY),
                            new Rectangle(0, 0, img.Width, img.Height),
                            GraphicsUnit.Pixel);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void pbView_Paint(object sender, PaintEventArgs e)
        {
            if (getDesignMode() && BorderStyle == BorderStyle.None)
            {
                using (Pen pen = new Pen(Color.Black))
                {
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen,
                        e.ClipRectangle.Left, e.ClipRectangle.Top,
                        e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);

                    if (showGrid)
                        DrawGrid(e.Graphics, e.ClipRectangle.Width, e.ClipRectangle.Height);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (!getDesignMode())
            {
                pbView.Invalidate();
            }
        }
    }
}
