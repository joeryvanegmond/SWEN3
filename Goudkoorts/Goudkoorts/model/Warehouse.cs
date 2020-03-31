using Goudkoorts.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Warehouse
    {
        private Spot A = new Rail();
        private Spot B = new Rail();
        private Spot C = new Rail();
        private Dictionary<char, SwitchRail> selectedSwitch;
        private SwitchRail s1 = new SwitchRail();
        private SwitchRail s2 = new SwitchRail();
        private SwitchRail s3 = new SwitchRail();
        private SwitchRail s4 = new SwitchRail();
        private SwitchRail s5 = new SwitchRail();
        private Spot _previousrail;
        private Spot _rail;
        public Spot Last { get; set; }
        public Spot First { get; set; }
        private int _x = 12;
        private int _y = 9;
        private Spot[,] _field;
        List<Spot> spots;
        private Ship ship;
        private Controller _controller;
        private bool loadingShip;
        public bool IsGameOver { get; set; }
        private Spot MooringPlace;
        public int Score { get; private set; }

        public Warehouse(Controller controller) 
        {
            this._controller = controller;
            A.Name = "A";
            B.Name = "B";
            C.Name = "C";
            _field = new Spot[_x, _y];
            spots = new List<Spot>();
            selectedSwitch = new Dictionary<char, SwitchRail>();
            selectedSwitch.Add('q', s1);
            selectedSwitch.Add('w', s2);
            selectedSwitch.Add('e', s5);
            selectedSwitch.Add('a', s3);
            selectedSwitch.Add('s', s4);
            createWarehouse();
        }

        public Spot[,] Field { get { return _field; } }

        private void createWarehouse()
        {
            Sea();
            PathFromAToS1();
            PathFromBToS1();
            PathFromS1ToS2();
            PathFromS2ToS3();
            PathFromS2TOS5();
            PathFromCTOS3();
            PathFromS3ToS4();
            PathFromS4ToS5();
            PathFromS4ToStorage();
            RailFromS5ToQuay();
            CreateListOfAllSpots();
        }

       

        private void StraightRailSetter(int size) 
        {
            int index = 8;
            for (int i = 0; i < size; i++)
            {
                _rail = new Rail();
                _previousrail.Next = _rail;
                _previousrail = _rail;
                _field[index, 0] = _rail;
                index--;
            }
        }

        public void SetAndMoveVehicle(int difficulty) 
        {
            MoveVehicles();
            Random ran = new Random();
            int dif = ran.Next(0, 10);

            if (!loadingShip)
            {
                if (dif < 3)
                {
                    First.PutVehicleOnRail(ship = new Ship(First));
                    loadingShip = true;
                }
            }

            if (dif <= difficulty)
            {
                int num = ran.Next(0, 3);

                switch (num)
                {
                    case 0:
                        if (A.Next.Vehicle == null && A.Next.Next.Vehicle == null) 
                        { 
                            A.Next.PutVehicleOnRail(new Cart(A.Next)); 
                        }
                        return;

                    case 1:
                        if (B.Next.Vehicle == null && B.Next.Next.Vehicle == null)
                        {
                            B.Next.PutVehicleOnRail(new Cart(B.Next));
                        }
                        return;

                    case 2:
                        if (C.Next.Vehicle == null && C.Next.Next.Vehicle == null)
                        {
                            C.Next.PutVehicleOnRail(new Cart(C.Next));
                        }
                        return;

                    default:
                        break;
                }
            }
        }

        public void MoveVehicles() 
        {
            List<Vehicle> carts = new List<Vehicle>();
            for (int i = 0; i < spots.Count; i++)
            {
                if (spots[i].Vehicle != null)
                {
                    carts.Add(spots[i].Vehicle);
                }
            }

            if (carts.Count != 0)
            {
                for (int i = 0; i < carts.Count; i++)
                {
                    if (carts[i].CurrentSpot.VehicleCrash)
                    {
                        IsGameOver = true;
                    }
                    carts[i].Move(carts[i].CurrentSpot.Next);
                }
            }

            if (loadingShip)
            {
                if (ship.CurrentSpot.AnkerIsOut == false || ship.Cargo == 8)
                {
                    if (ship.CurrentSpot == Last)
                    {
                        ship.Move(ship.CurrentSpot.Next);
                        ship.IsAtDestination = false;
                        Score += 18;
                        ship = null;
                        loadingShip = false;
                    }
                    else
                    {
                        ship.Move(ship.CurrentSpot.Next);
                        ship.IsAtDestination = false;
                    }
                }
                else
                {
                    ship.IsAtDestination = true;
                }
            }
        }

        public void ControlSwitch(char key) 
        {
            if (selectedSwitch.ContainsKey(key))
            {
                selectedSwitch[key].DoSwitchThing();
            }
        }


        private void Sea()
        {
            _previousrail = null;

            for (int i = 0; i < 13; i++)
            {
                if (i == 9)
                {
                    _rail = new MooringRail();
                    _rail.Name = "~";
                    _rail.AnkerIsOut = true;
                    MooringPlace = _rail;
                }
                else
                {
                    _rail = new Rail();
                    _rail.Name = "~";
                    if (i == 12)
                    {
                        Last = _rail;
                    }
                }

                if (_previousrail != null)
                {
                    _previousrail.Next = _rail;
                }
                else
                {
                    First = _rail;
                }
                _previousrail = _rail;
            }

            _previousrail = null;
        }

        private void PathFromAToS1()
        {
            _field[0, 2] = A;
            A.Next = new Rail();
            _previousrail = A.Next;
            _field[1, 2] = _previousrail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[2, 2] = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[3, 2] = _rail;
            _rail.Name = "╗";
            _rail.Next = s1;
            _field[3, 3] = s1;
            s1.NotUsedPrevious = _rail;
            s1.CurrentSwitchState = SwitchState.FromBelow;
        }

        private void PathFromBToS1()
        {
            _field[0, 4] = B;
            B.Next = new Rail();
            _previousrail = B.Next;
            _field[1, 4] = _previousrail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _field[2, 4] = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _rail.Name = "╝";
            _field[3, 4] = _rail;
            _rail.Next = s1;
            _field[3, 3] = s1;
            _previousrail = s1;
            s1.Previous = _rail;
        }

        private void PathFromS1ToS2()
        {
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[4, 3] = _rail;
            _rail.Next = s2;
            _field[5, 3] = s2;
            s2.CurrentSwitchState = SwitchState.ToAbove;
        }

        private void PathFromS2ToS3()
        {
            s2.NotUsedNext = new Rail();
            _previousrail = s2.NotUsedNext;
            _previousrail.Name = "╚";
            _field[5, 4] = _previousrail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[6, 4] = _rail;
            _rail.Name = "╗";
            _previousrail = _rail;
            _rail.Next = s3;
            _field[6, 5] = _rail;
            s3.NotUsedPrevious = _rail;
            s3.CurrentSwitchState = SwitchState.FromBelow;
        }

        private void PathFromS2TOS5()
        {
            s2.Next = new Rail();
            _previousrail = s2.Next;
            _field[5, 2] = _previousrail;
            _previousrail.Name = "╔";
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[6, 2] = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[7, 2] = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[8, 2] = _rail;
            _previousrail = _rail;

            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[9, 2] = _rail;
            _rail.Name = "╗";
            _previousrail = _rail;
            _rail.Next = s5;
            _field[9, 3] = s5;
            s5.CurrentSwitchState = SwitchState.FromAbove;
            s5.Previous = _rail;
        }

        private void PathFromCTOS3()
        {
            _field[0, 6] = C;
            C.Next = new Rail();
            _previousrail = C.Next;
            _field[1, 6] = _previousrail;

            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[2, 6] = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[3, 6] = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[4, 6] = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _field[5, 6] = _rail;
            _previousrail = _rail;

            _rail = new Rail();
            _previousrail.Next = _rail;
            _rail.Name = "╝";
            _field[6, 6] = _rail;
            _previousrail = _rail;
            _rail.Next = s3;
            _field[6, 5] = s3;
            s3.Previous = _rail;
        }

        private void PathFromS3ToS4()
        {
            s3.Next = new Rail();
            _rail = s3.Next;
            _field[7, 5] = _rail;
            _rail.Next = s4;
            _field[8, 5] = s4;
            s4.CurrentSwitchState = SwitchState.ToBelow;
        }

        private void PathFromS4ToS5()
        {
            s4.NotUsedNext = new Rail();
            _previousrail = s4.NotUsedNext;
            _field[8, 4] = _previousrail;
            _previousrail.Name = "╔";

            _rail = new Rail();
            _previousrail.Next = _rail;
            _rail.Name = "╝";
            _field[9, 4] = _rail;
            _rail.Next = s5;
            s5.NotUsedPrevious = _rail;
        }

        private void PathFromS4ToStorage()
        {
            s4.Next = new Rail();
            _previousrail = s4.Next;
            _field[8, 6] = _previousrail;
            _previousrail.Name = "╚";

            _rail = new Rail();
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _field[9, 6] = _rail;
            _rail = new Rail();
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _field[10, 6] = _rail;

            _rail = new Rail();
            _field[11, 6] = _rail;
            _rail.Name = "╗";
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _rail.Name = "╝";
            _field[11, 7] = _rail;
            _previousrail.Next = _rail;
            _previousrail = _rail;

            _rail = new Rail();
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _field[10, 7] = _rail;

            _rail = new Rail();
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _field[9, 7] = _rail;

            int index = 8;
            for (int i = 0; i < 8; i++)
            {
                _rail = new StorageRail();
                _previousrail.Next = _rail;
                _field[index, 7] = _rail;
                _previousrail = _rail;
                index--;
            }
        }

        private void RailFromS5ToQuay()
        {
            s5.Next = new Rail();
            _previousrail = s5.Next;
            _field[10, 3] = _previousrail;
            _rail = new Rail();
            _rail.Name = "╝";
            _field[11, 3] = _rail;
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _field[11, 2] = _rail;
            _previousrail.Next = _rail;
            _rail.Name = "║";
            _previousrail = _rail;
            _rail = new Rail();
            _field[11, 1] = _rail;
            _previousrail.Next = _rail;
            _rail.Name = "║";
            _previousrail = _rail;
            _rail = new Rail();
            _field[11, 0] = _rail;
            _rail.Name = "╗";
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _rail = new Rail();
            _field[10, 0] = _rail;
            _previousrail.Next = _rail;
            _previousrail = _rail;
            _rail = new QueyRail();
            _rail.LoadingDock = MooringPlace;
            _field[9, 0] = _rail;
            _previousrail.Next = _rail;
            _previousrail = _rail;
            StraightRailSetter(9);
        }

        private void CreateListOfAllSpots()
        {
            for (int y = 0; y < _y; y++)
            {
                for (int x = 0; x < _x; x++)
                {
                    if (Field[x, y] != null)
                    {
                        spots.Add(Field[x, y]);
                    }
                }
            }
        }
    }
}  
       