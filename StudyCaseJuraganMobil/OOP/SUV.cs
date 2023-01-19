using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP
{
    internal class SUV : VehicleBase
    {

        public SUV(string? noPolice, VehicleType? vehicleType, DateOnly transactionDate, double rent, double driverFee, double total = 0) : base(noPolice, vehicleType, transactionDate, rent)
        {
            DriverFee = driverFee;
            Total = rent + driverFee;

        }

        public double DriverFee { get; set; }

        public override string? ToString()
        {
            return $"{base.ToString()}, Rent : {Rent}, Driver Fee : {DriverFee}, Total Income = {Total}";
        }
    }
}
