using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class Vehicle
    {

        public string Name { get; set; }
        
        public Spot CurrentSpot { get; set; }
        public bool IsAtDestination { get; set; }
        public int Cargo { get; set; }
        public abstract void Move(Spot spot);
    }
}