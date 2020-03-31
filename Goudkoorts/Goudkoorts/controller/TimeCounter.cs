using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts.controller
{
    public class TimeCounter
    {
        private Thread _timer;
        public int Interval { get; set; }
        private int _sleeptime;
        public int Time { get; private set; }
        private Controller _controller;

        public TimeCounter(int interval, int sleeptime, Controller controller)
        {
            Interval = interval;
            _sleeptime = sleeptime;
            _timer = new Thread(UpdateClock);
            _controller = controller;
        }

        public void Start()
        {
            _timer = new Thread(UpdateClock);
            Time = Interval;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Abort();
        }

        private void UpdateClock() 
        {
            for (; Time >= 0; Time -= _sleeptime)
            {
                Thread.Sleep(_sleeptime);
                Console.Clear();
                _controller.PrintGame(_controller.warehouse.Score, Time);

                if (Time == 0)
                {
                    _controller.BlockInput();
                    _controller.outputView.ShowBusy();
                    Thread.Sleep(_sleeptime);
                    _controller.Update();
                    Time = Interval + _sleeptime;
                    if (_controller.warehouse.IsGameOver)
                    {
                        _controller.outputView.ShowGameOver();
                        _controller.BlockInput();
                    }
                }
                _controller.EnableInput();
            }
            
        }
    }
}
