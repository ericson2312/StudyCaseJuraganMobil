using StudyCaseJuraganMobil.OOP.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP
{
    internal class VehicleFactory : IVehicleFactory
    {
        public SUV CreateSUV(VehicleStruct vehicleStruct)
        {
            return new SUV(vehicleStruct.NoPolice, vehicleStruct.VehicleType, vehicleStruct.TransactionDate, vehicleStruct.Rent, vehicleStruct.DriverFee, vehicleStruct.Total);
        }

        public Taxi CreateTaxi(VehicleRecord vehicleRecord)
        {
            return new Taxi(vehicleRecord.NoPolice, vehicleRecord.VehicleType, vehicleRecord.TransactionDate, vehicleRecord.Order, vehicleRecord.OrderPerKm);
        }

        public void DisplayVehicle<T>(List<T> vehicles)
        {
            foreach (var item in vehicles)
            {
                Console.WriteLine(item);
            }
        }

        public int GetTotalVehicle<T>(List<T> vehicles)
        {
            return vehicles.Count;
        }

        public int GetTotalVehicle<T>(List<T> vehicles, VehicleType vehicleType)
        {
            int total = 0;
            switch (vehicleType)
            {
                case VehicleType.ALL:
                    total = vehicles.Count;
                    break;
                case VehicleType.SUV:
                    total = vehicles.OfType<VehicleBase>().Where(x => x.VehicleType == VehicleType.SUV).Count();
                    break;
                case VehicleType.TAXI:
                    total = vehicles.OfType<VehicleBase>().Where(x => x.VehicleType == VehicleType.TAXI).Count();
                    break;
                case VehicleType.JET:
                    total = vehicles.OfType<VehicleBase>().Where(x => x.VehicleType == VehicleType.JET).Count();
                    break;
                default:
                    break;
            }
            return total;
        }
    }
}
