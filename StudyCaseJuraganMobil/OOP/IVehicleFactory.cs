using StudyCaseJuraganMobil.OOP.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCaseJuraganMobil.OOP
{
    internal interface IVehicleFactory
    {
        public SUV CreateSUV(VehicleStruct vehicleStruct);
        public Taxi CreateTaxi(VehicleRecord vehicleRecord);

        //T digunakan untuk membuat tipe Generic
        //artinya bisa menampung list dari VehicleBase, SUV, Taxi, dan PrivateJet
        public void DisplayVehicle<T>(List<T> vehicles);

        public int GetTotalVehicle<T>(List<T> vehicles);
        public int GetTotalVehicle<T>(List<T> vehicles, VehicleType vehicleType);
    }
}
