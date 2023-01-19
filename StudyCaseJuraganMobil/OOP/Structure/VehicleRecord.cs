using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP.Structure
{
//record dan struct immutable, sedangkan class mutable
//artinya value di class bisa di update, sedangkan record dan struct tidak bisa diubah, tetapi akan menciptakan value baru
    internal record VehicleRecord
    {
        public string? NoPolice { get; set; }
        public VehicleType? VehicleType { get; set; }
        public DateOnly TransactionDate { get; set; }
        public double Order { get; set; }
        public double OrderPerKm { get; set; }
        public double Total { get; set; }
    }
}
