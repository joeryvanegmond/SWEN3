using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Goudkoorts
{
    public class InputView
    {
        private Controller _controller;
        private Thread _thread;
        private bool running = true;

        public InputView(Controller controller)
        {
            this._controller = controller;
        }

        public void PressAnyKey() 
        {
            Console.ReadKey();
        }

        public char ChooseSwitch(Char key) 
        {
            switch (key)
            {
                case 'q':
                case 'w':
                case 'e':
                case 'a':
                case 's':
                    return key;

                default:
                    break;
            }
            return ' ';
        }

        public void StartKeyboardListener()
        {
            _thread = new Thread(() => {
                while (true)
                {
                    ConsoleKeyInfo key = System.Console.ReadKey(true);
                    if (running)
                    {
                        _controller.warehouse.ControlSwitch(ChooseSwitch(key.KeyChar));
                    }
                }
            });

            _thread.IsBackground = true;
            _thread.Start();
        }

        public void Start() 
        {
            running = true;
        }

        public void Stop()
        {
            running = false;
        }

    }
}