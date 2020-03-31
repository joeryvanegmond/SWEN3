using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class StorageRail : Rail
    {

        public StorageRail() 
        {
            Name = "+";
        }

        public override void PutVehicleOnRail(Vehicle vehicle)
        {
            if (Vehicle == null)
            {
                Vehicle = vehicle;
            }
            return;
        }

        public override void RemoveVehicleFromRail(Vehicle vehicle)
        {
            if (Next != null)
            {
                if (Next.Vehicle == null)
                {
                    base.RemoveVehicleFromRail(vehicle);
                    return;
                }
            }


        }
    }
}