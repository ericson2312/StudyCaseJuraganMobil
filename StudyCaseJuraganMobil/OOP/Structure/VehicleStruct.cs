using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP.Structure
{
    internal struct VehicleStruct
    {
        public string? NoPolice { get; set; }
        public VehicleType? VehicleType { get; set; }
        public DateOnly TransactionDate { get; set; }
        public double Rent { get; set; }
        public double DriverFee { get; set; }
        public double Total { get; set; }
    }
}
