using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int loops = 100000;
            //Initializing the array
            int size = 10000;
            double[] dArray = new double[size];
            for (int i = 0; i < size; i++)
            {
                dArray[i] = i + 0.5;
            }

            //Cloning through the IClonable interface
            Stopwatch sw = new Stopwatch();
            var cM = new CloneManual();
            cM.DoubleArray = dArray;
            var rM = new ReferenceClass();
            rM.Name = "Manual reference";
            rM.version = 1;
            cM.Reference = rM;
            CloneManual cMClone = null;
            sw.Start();
            for (int i = 0; i < loops; i++)
            {
                cMClone = cM.ManualClone();
            }
            sw.Stop();
            Console.WriteLine("Clone manually done.");
            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine("Reference equals: " + Object.ReferenceEquals(cM.Reference, cMClone.Reference));
            Console.WriteLine();

            //Cloning with serialization
            sw = new Stopwatch();
            var cS = new CloneSerialize();
            cS.DoubleArray = dArray;
            var rS = new ReferenceClass();
            rS.Name = "Serialize reference";
            rS.version = 1;
            cS.Reference = rS;
            CloneSerialize cSClone = null;
            sw.Start();
            for (int i = 0; i < loops; i++)
            {
                cSClone = cS.SerializeClone();
            }
            sw.Stop();
            Console.WriteLine("Clone with serializable done.");
            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine("Reference equals: " + Object.ReferenceEquals(cS.Reference, cSClone.Reference));
            Console.WriteLine();

            //Cloning with interface
            sw = new Stopwatch();
            var cI = new CloneInterface();
            cI.DoubleArray = dArray;
            var rI = new ReferenceClass();
            rI.Name = "Interface reference";
            rI.version = 1;
            cI.Reference = rI;
            CloneInterface cIClone = null;
            sw.Start();
            for (int i = 0; i < loops; i++)
            {
                cIClone = (CloneInterface)cI.Clone();
            }
            sw.Stop();
            Console.WriteLine("Clone with interface done.");
            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine("Reference equals: " + Object.ReferenceEquals(cI.Reference, cIClone.Reference));
            Console.ReadKey();
        }
    }
}
