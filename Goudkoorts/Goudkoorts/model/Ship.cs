using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Ship : Vehicle
    {
       

        public Ship(Spot firstSpot) 
        {
            Cargo = 0;
            CurrentSpot = firstSpot;
            Name = Cargo.ToString();
            IsAtDestination = false;
        }

        public override void Move(Spot spot)
        {
            Spot oldSpot = CurrentSpot;

            if (spot == null) { oldSpot.RemoveVehicleFromRail(this); return; }

            oldSpot.RemoveVehicleFromRail(this);
            CurrentSpot = spot;
            spot.PutVehicleOnRail(this);
        }
    }
}