using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Rail : Spot
    {

        public Rail()
        { 
            Name = "═";
            AnkerIsOut = false;
            VehicleCrash = false;
        }

        override public string VehicleName
        {
            get
            {
                string ret = Name;
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
            else
            {
                VehicleCrash = true;
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
    }
}