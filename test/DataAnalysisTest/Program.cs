using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.DataAnalysisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nWeka ----------------------------------------------------------------");
                Weka.Weka_Main.run(args);

                Console.WriteLine("\nRapidMiner ----------------------------------------------------------");
                //RapidMiner.RapidMiner_Main.run(args);  // not yet implemented.
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
