using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    public struct Av
    {
        /// <summary>
        /// Constant for undefined value.
        /// </summary>
        public static Av Empty = new Av(0, string.Empty);

        /// <summary>
        /// Aperture value, mm
        /// </summary>
        public float Value { get; }

        /// <summary>
        /// Name of the aperture value in the camera proprietary API.
        /// </summary>
        public string Name { get; }

        public Av(float av, string name)
        {
            Value = av;
            Name = name;
        }

        public Av(float av) : this(av, av.ToString(CultureInfo.InvariantCulture)) { }

        public Av(string name) : this(0, name) { }

        public override bool Equals(object obj)
        {
            if (obj is Av v)
                return v.Value == Value && v.Name == Name;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(Av av1, Av av2)
        {
            return av1.Equals(av2);
        }

        public static bool operator !=(Av av1, Av av2)
        {
            return !av1.Equals(av2);
        }
    }
}
