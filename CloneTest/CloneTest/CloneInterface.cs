using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneTest
{
    public class CloneInterface : ICloneable
    {
        public double[] DoubleArray { get; set; }

        public ReferenceClass Reference { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        Object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
