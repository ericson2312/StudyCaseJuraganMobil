using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP
{
    internal class Jet : VehicleBase
    {
        public Jet(string noPolice, VehicleType vehicleType, DateOnly transactionDate, double rent, double orderPerHours = 0) : base(noPolice, vehicleType, transactionDate, rent)
        {
            orderPerHours = OrderPerHours;
        }
        public double OrderPerHours { get; set; }
    }
}
