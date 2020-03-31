using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class OutputView
    {
        
        private int _x = 12;
        private int _y = 9;
        private Spot[,] field;


        private Warehouse warehouse;
        public OutputView(Warehouse warehouse)
        {
            this.warehouse = warehouse;
            field = warehouse.Field;
        }


        public void PrintGame() 
        {
            PrintSea();
            UpdateWareHouse();
        }

        private void UpdateWareHouse()
        {
            int y = 0;
            for (y = 0; y < _y; y++)
            {
                for (int x = 0; x < _x; x++)
                {
                    if (field[x, y] != null)
                    {
                        Console.Write(field[x, y].VehicleName);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void ShowStats(int score, int time)
        {
            Console.WriteLine("┌─────────────┐   ");
            Console.WriteLine("| Goudkoorts  |   ");
            Console.WriteLine("└─────────────┘   ");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("   Score: {0}                                                Tijd: {1}   ", score, (int)(time * 0.001));
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
        }

        public void ShowControls() 
        {
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine(" Druk op:      Q | W | E ");
            Console.WriteLine("                 A | S ");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("> Bestuur de spoorwissels");
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Goudkoorts!                               |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("| betekenis van de symbolen     |   doel van het spel  |");
            Console.WriteLine("|                               |                      |");
            Console.WriteLine("| spatie   : outerspace         |   Scoor zoveel       |");
            Console.WriteLine("|      =   : rails              |   mogelijk punten    |");
            Console.WriteLine("| ╚ ╔ ╝ ╗  : schakelaars        |   door caretjes      |");
            Console.WriteLine("|      @   : cart               |   naar de kader te   |");
            Console.WriteLine("|      K   : de kader           |   leiden.            |");
            Console.WriteLine("|  A B C   : de loodsen         |                      |");
            Console.WriteLine("|      0   : schip              |                      |");
            Console.WriteLine("└──────────────────────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("  > Druk op enter om te beginnen.                     ");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
        }

        public void ShowBusy()
        {
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("                        Spel wordt bijgewerkt..                     ");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
        }

        public void ShowGameOver()
        {
            Console.WriteLine(">                   Helaas je hebt het spel verloren!                   <");
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PrintSea()
        {
            Spot temp = warehouse.First;

            for (int i = 0; i < 13; i++)
            {
                Console.Write(temp.VehicleName);
                temp = temp.Next;
            }
            Console.WriteLine();
        }
    }
}