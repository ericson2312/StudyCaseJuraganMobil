using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP
{
    internal abstract class VehicleBase
    {
        private double rent;

        protected VehicleBase(string? noPolice, VehicleType? vehicleType, DateOnly transactionDate, double rent = 0)
        {
            NoPolice = noPolice;
            VehicleType = vehicleType;
            TransactionDate = transactionDate;
            Rent = rent;
        }

        public string? NoPolice { get; set; }
        public VehicleType? VehicleType { get; set; }
        public int? Year { get; set; }
        public double? Price { get; set; }
        public int? Tax { get; set; }
        public int? Seat { get; set; }
        public DateOnly? TransactionDate { get; set; }
        public double? Total { get; set; }
        public double? Rent { get; set; }

        public override string? ToString()
        {
            return $"NoPolice/NoRegister : {NoPolice}, Vehicle Type : {VehicleType}, TransactionDate : {TransactionDate}";
        }
    }
}
