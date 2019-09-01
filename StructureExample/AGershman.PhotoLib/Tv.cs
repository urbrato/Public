using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Shutter speed description
    /// </summary>
    public struct Tv
    {
        /// <summary>
        /// Constant for undefined value.
        /// </summary>
        public static Tv Empty = new Tv(0, 1, string.Empty);

        /// <summary>
        /// Numerator of the shutter speed fraction in sec.
        /// </summary>
        public int Numerator { get; }

        /// <summary>
        /// Denominator of the shutter speed fraction in sec.
        /// </summary>
        public int Denominator { get; }

        /// <summary>
        /// Name of the shutter speed value in the camera proprietary API.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value of the shutter speed in sec.
        /// </summary>
        public float Value
        {
            get { return Convert.ToSingle(Numerator) / Convert.ToSingle(Denominator); }
        }

        public Tv(int numerator, int denominator, string name)
        {
            Numerator = numerator;
            Denominator = denominator;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Tv tv)
            {
                return tv.Numerator == Numerator && tv.Denominator == Denominator && tv.Name == Name;
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

        public static bool operator ==(Tv tv1, Tv tv2)
        {
            return tv1.Equals(tv2);
        }

        public static bool operator !=(Tv tv1, Tv tv2)
        {
            return !tv1.Equals(tv2);
        }
    }
}
