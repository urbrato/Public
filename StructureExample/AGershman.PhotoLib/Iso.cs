using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    public struct Iso
    {
        /// <summary>
        /// Constant for undefined value.
        /// </summary>
        public static Iso Empty = new Iso(0, string.Empty);

        /// <summary>
        /// ISO
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Name of the aperture value in the camera proprietary API.
        /// </summary>
        public string Name { get; }

        public Iso(int iso, string name)
        {
            Value = iso;
            Name = name;
        }

        public Iso(int iso) : this(iso, iso.ToString()) { }

        public Iso(string name) : this(0, name) { }

        public override bool Equals(object obj)
        {
            if (obj is Iso v)
            {
                return v.Value == Value && v.Name == Name;
            }
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

        public static bool operator ==(Iso iso1, Iso iso2)
        {
            return iso1.Equals(iso2);
        }

        public static bool operator !=(Iso iso1, Iso iso2)
        {
            return !iso1.Equals(iso2);
        }
    }
}
