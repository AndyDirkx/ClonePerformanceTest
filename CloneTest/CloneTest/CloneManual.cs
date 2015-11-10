using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneTest
{
    public class CloneManual
    {
        public double[] DoubleArray { get; set; }

        public ReferenceClass Reference { get; set; }

        public CloneManual ManualClone()
        {
            CloneManual cM = new CloneManual();
            double[] clone = new double[DoubleArray.Length];
            int i = 0;
            foreach(double d in DoubleArray)
            {
                clone[i] = d;
                i++;
            }
            cM.DoubleArray = clone;

            var rM = new ReferenceClass();
            rM.Name = Reference.Name;
            rM.version = Reference.version;
            cM.Reference = rM;

            return cM;
        }
    }
}
