using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMining.ScientificComputationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Math.NET library ----------------------------------------------------");
                //MathNET.MathNET_Main.run(args);  // not yet implemented.

                Console.WriteLine("\nILNumerics library --------------------------------------------------");
                //ILNumerics.ILNumerics_Main.run(args);  // not yet implemented.

                Console.WriteLine("\nAForge.NET library --------------------------------------------------");
                //AForgeNET.AForgeNET_Main.run(args);  // not yet implemented.

                Console.WriteLine("\nAccord.NET library --------------------------------------------------");
                //AccordNET.AccordNET_Main.run(args);  // not yet implemented.
            }
            catch (Exception e)
            {
                Console.WriteLine("System.Exception occurred: {0}", e);
            }

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }
    }
}
