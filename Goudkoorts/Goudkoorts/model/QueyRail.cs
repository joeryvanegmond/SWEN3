using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class QueyRail : Rail
    {

        public QueyRail()  
        {
            Name = "K";
        }

        public override void PutVehicleOnRail(Vehicle vehicle)
        {
            base.PutVehicleOnRail(vehicle);

            if (LoadingDock.Vehicle != null)
            {
                LoadingDock.Vehicle.Cargo = Int32.Parse(LoadingDock.Vehicle.Name) + 1;
                LoadingDock.Vehicle.Name = LoadingDock.Vehicle.Cargo.ToString();
            }

        }
    }
}