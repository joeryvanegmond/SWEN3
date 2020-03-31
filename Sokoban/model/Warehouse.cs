using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace model
{
    class Warehouse
    {
        private controller.Parser parser;
        private String[] lines;
        private List<Spot> spots;
        public Warehouse()
        {
            parser = new controller.Parser();
            spots = new List<Spot>();
            lines = parser.readTxtFile();
            createSpots();
            //printField();
        }

        private void createSpots()
        {
            for (int y = 0; y < lines.Length; y++)
            {
                String temp = lines[y];
                int x = 0;

                foreach (char oneChar in temp.ToCharArray())
                {
                    switch (oneChar)
                    {

                        case '#':
                            spots.Add(new Wall(x, y, oneChar));
                            break;

                        case '.':
                            spots.Add(new Floor(x, y, oneChar));
                            break;

                        case 'o':
                            spots.Add(new Chest(x, y, oneChar));
                            break;

                        case 'x':
                            spots.Add(new Destination(x, y, oneChar));
                            break;

                        case '@':
                            spots.Add(new Truck(x, y, oneChar));
                            break;

                        default:
                            break;
                    }
                    x++;
                }
            }
        }

        public void printField()
        {
            //Console.WriteLine("AFTER PARSER");
            Console.Write("\t" + spots[0].getSym());
            for (int i = 1; i < spots.Count; i++)
            {
                int temp = spots[i - 1].getY();

                if (spots[i].getY() > temp)
                {
                    Console.Write("\n \t"); 
                }

                Console.Write(spots[i].getSym());
            }
            Console.WriteLine();
            Console.ReadKey();
        }

       
    }
}
