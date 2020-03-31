using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class Spot
    {
        public string Name { get; set; }
        public Spot Next { get; set; }
        public Spot NotUsedNext { get; set; }
        public Spot Previous { get; set; }
        public Spot NotUsedPrevious { get; set; }
        public abstract string VehicleName { get; }
        public Vehicle Vehicle { get; set; }
        public bool AnkerIsOut { get; set; }
        public Spot LoadingDock { get; set; }
        public bool VehicleCrash { get; set; }

        public abstract void PutVehicleOnRail(Vehicle vehicle);
        public abstract void RemoveVehicleFromRail(Vehicle vehicle);
    }
}

