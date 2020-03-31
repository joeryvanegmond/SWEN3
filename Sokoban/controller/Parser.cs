using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller
{
    class Parser
    {
        public String[] readTxtFile()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("//Mac/Home/Documents/Avans/leerjaar 2/BLOK 5/MODL3/Sokoban/Sokoban/file/doolhof1.txt");
               
                //[TEST PRINT]
                //Console.WriteLine("BEFORE PARSER");
                //foreach (string line in lines)
                //{
                //    // Use a tab to indent each line of the file.
                //    Console.WriteLine("\t" + line);
                //}
                //Console.ReadLine();

                return lines;
            }
            catch (Exception)
            {

                throw;
            }
        }





    }

}
