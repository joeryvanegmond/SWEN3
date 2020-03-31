using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Cart : Vehicle
    {

        public Cart(Spot firstSpot) 
        {
            CurrentSpot = firstSpot;
            Name = "@";
        }

        public override void Move(Spot spot)
        {
            Spot oldSpot = CurrentSpot;

            if (spot == null) 
            { 
                oldSpot.RemoveVehicleFromRail(this); 
                return; 
            }

            if (CurrentSpot == spot.NotUsedPrevious) 
            { 
                return; 
            }

            oldSpot.RemoveVehicleFromRail(this);
            CurrentSpot = spot;
            spot.PutVehicleOnRail(this);
        }

       
    }
}