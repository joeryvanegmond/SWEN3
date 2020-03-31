using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public enum SwitchState
    {
        ToBelow = '╗', FromBelow = '╔', ToAbove = '╝', FromAbove = '╚'
    }

    public class SwitchRail : Rail
    {
        private Spot CurrentState { get; set; }
        public SwitchState CurrentSwitchState { get; set; }

        public SwitchRail() 
        {
            CurrentState = this.Next;
        }

        override public string VehicleName
        {
            get
            {
                string ret = Char.ToString(Convert.ToChar(CurrentSwitchState));
                if (Vehicle != null)
                {
                    ret = Vehicle.Name;
                }
                return ret;
            }
        }

        public override void PutVehicleOnRail(Vehicle vehicle)
        {
            if (Vehicle == null)
            {
                Vehicle = vehicle;
            }
        }

        public override void RemoveVehicleFromRail(Vehicle vehicle)
        {
            if (Vehicle == vehicle)
            {
                Vehicle = null;
            }
            else
            {
                return;
            }
        }

        public void DoSwitchThing() 
        {
            if (NotUsedPrevious != null)
            {
                var tempSpot = Previous;
                Previous = NotUsedPrevious;
                NotUsedPrevious = tempSpot;

                if (CurrentSwitchState == SwitchState.FromBelow)
                {
                    CurrentSwitchState = SwitchState.FromAbove;
                }
                else
                {
                    CurrentSwitchState = SwitchState.FromBelow;
                }
            }

            if (NotUsedNext != null)
            {
                var tempSpot = Next;
                Next = NotUsedNext;
                NotUsedNext = tempSpot;

                if (CurrentSwitchState == SwitchState.ToBelow)
                {
                    CurrentSwitchState = SwitchState.ToAbove;
                }
                else
                {
                    CurrentSwitchState = SwitchState.ToBelow;
                }
            }
        }
    }
}