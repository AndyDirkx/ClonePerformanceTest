using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CloneTest
{
    [Serializable]
    public class CloneSerialize
    {
        public double[] DoubleArray { get; set; }

        public ReferenceClass Reference { get; set; }

        public CloneSerialize SerializeClone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (CloneSerialize)formatter.Deserialize(ms);
            }
        }
    }
}
