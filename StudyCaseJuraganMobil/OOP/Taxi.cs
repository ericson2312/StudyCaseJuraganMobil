using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP
{//sealed mencegah inheritance
    internal sealed class Taxi : VehicleBase
    {
        public Taxi(string noPolice, VehicleType? vehicleType, DateOnly transactionDate, double order, double orderPerKm) : base(noPolice, vehicleType, transactionDate)
        {
            Order = order;
            OrderPerKm = orderPerKm;
            Total = order * orderPerKm;
        }
        public double Order { get; set; }
        public double OrderPerKm { get; set; }
        public override string? ToString()
        {
            return $"{base.ToString()}, Order : {Order}, Order Per Km : {OrderPerKm}, Total Income : {Total}";
        }
    }
}
