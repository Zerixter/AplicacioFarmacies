using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacioFarmacies.Models
{

    class Test
    {
        public static void Cargar()
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:/Users/victo/Downloads/farmacies.csv"))
                {
                    string currentLine;
                    // currentLine will be null when the StreamReader reaches the end of file
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        // Search, case insensitive, if the currentLine contains the searched keyword
                        if (currentLine.IndexOf("I/RPTGEN", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            Console.WriteLine(currentLine);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);

                Console.ReadLine();
            }
        }
    }
}

