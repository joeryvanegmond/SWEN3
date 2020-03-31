using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace view
{
    public class InputView
    {
        public void checkInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    // return Y - 1?
                    break;

                case ConsoleKey.LeftArrow:
                    // return return X - 1?
                    break;

                case ConsoleKey.RightArrow:
                    // return X + 1?
                    break;

                case ConsoleKey.DownArrow:
                    // return Y + 1?
                    break;

                default:
                    Console.WriteLine("Maak gebruik van de pijltjes toetsen.");
                    break;
            }
        }
    }
}
