using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller
{
    class Controller
    {
        private model.Warehouse wareHouse;
        private view.OutputView outputView;
        private view.InputView inputView;
        private Boolean waitForWin = true;

        public Controller() {
            wareHouse = new model.Warehouse();
            outputView = new view.OutputView();
            inputView = new view.InputView();

            StartGame();
        }

        private void StartGame()
        {
            outputView.StartMessage();
            

            while (waitForWin)
            {
                wareHouse.printField();
                checkInput();
            }
        }

        private void checkInput() {
            var input = Console.ReadKey();
            inputView.checkInput(input);
        }
        

    }
}
