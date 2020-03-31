using Goudkoorts.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Goudkoorts
{
    public class Controller
    {

        public const int Easy = 2;
        public const int Medium = 5;
        public const int Hard = 7;


        public Warehouse warehouse;
        public InputView inputView;
        public OutputView outputView;
        public TimeCounter TimeCounter;

        public Controller() 
        {
            warehouse = new Warehouse(this);
            outputView = new OutputView(warehouse);
            inputView = new InputView(this);
            TimeCounter = new TimeCounter(5000, 1000, this);
        }

        public void Go() 
        {
            outputView.ShowMenu();
            inputView.PressAnyKey();
            TimeCounter.Start();
            inputView.StartKeyboardListener();
        }

        public void Update()
        {
            warehouse.SetAndMoveVehicle(Medium);
        }

        public void BlockInput() 
        {
            inputView.Stop();
        }

        public void EnableInput() 
        {
            inputView.Start();
        }

        public void PrintGame(int score, int time)
        {
            Console.Clear();
            outputView.ShowStats(score, time);
            outputView.PrintGame();
            outputView.ShowControls();
        }
    }
}