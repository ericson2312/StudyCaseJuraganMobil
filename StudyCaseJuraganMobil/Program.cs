using StudyCaseJuraganMobil.OOP;
using StudyCaseJuraganMobil.OOP.Structure;
using System;
using System.Diagnostics;

namespace StudyCaseJuraganMobil 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory _iVehicle = new VehicleFactory();

            var suvHolder1 = new VehicleStruct
            {
                NoPolice = "D 1001 UM",
                VehicleType = VehicleType.SUV,
                TransactionDate = new DateOnly(2023, 1, 10),
                DriverFee = 150_000,
                Rent = 500_000
            };
            var suvHolder2 = new VehicleStruct
            {
                NoPolice = "D 1002 UM",
                VehicleType = VehicleType.SUV,
                TransactionDate = new DateOnly(2023, 1, 10),
                DriverFee = 150_000,
                Rent = 650_000
            };
            var taxiHolder1 = new VehicleRecord
            {
                NoPolice = "D 11 UK",
                VehicleType = VehicleType.TAXI,
                TransactionDate = new DateOnly(2023, 1, 12),
                Order = 45,
                OrderPerKm = 4_500
            };


            var suv1 = _iVehicle.CreateSUV(suvHolder1);
            var suv2 = _iVehicle.CreateSUV(suvHolder2);
            var taxi1 = _iVehicle.CreateTaxi(taxiHolder1);

            List<VehicleBase> list = new List<VehicleBase>();
            list.Add(suv1);
            list.Add(suv2);
            list.Add(taxi1);

            _iVehicle.DisplayVehicle(list);

            var total = _iVehicle.GetTotalVehicle(list, VehicleType.SUV);

            var minTotalIncome = list.Min(x => x.Total);
            var maxTotalIncome = list.Max(x => x.Total);
            Console.WriteLine($"Total Vehicle : {total}");
            Console.WriteLine($"Min Total Income : {minTotalIncome}, Max Total Income : {maxTotalIncome}");

            var query = list.Where(x => x.Total > minTotalIncome && x.Total < maxTotalIncome).Select(vh =>
                new
                {
                    NoPolisi = vh.NoPolice,
                    TahunBeli = vh.Year,
                    TotalIncome = vh.Total
                }
            );

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            /*
            List<Vehicle> listVehicle = new List<Vehicle>();
            listVehicle.Add(new SUV("D 1001 UM", 2010, 350_000_000, 3_500_000, 4, new DateOnly(2023, 1, 10), 500_000, 150_000));
            listVehicle.Add(new SUV("D 1002 UM", 2010, 350_000_000, 3_500_000, 4, new DateOnly(2023, 1, 10), 500_000, 150_000));
            listVehicle.Add(new SUV("D 1003 UM", 2015, 350_000_000, 3_500_000, 5, new DateOnly(2023, 1, 12), 500_000, 150_000));
            listVehicle.Add(new SUV("D 1004 UM", 2015, 350_000_000, 3_500_000, 5, new DateOnly(2023, 1, 13), 500_000, 150_000));
            listVehicle.Add(new Taxi("D 11 UK", 2002, 175_000_000, 1_750_000, 4, new DateOnly(2023, 1, 12), 45, 4_500));
            listVehicle.Add(new Taxi("D 12 UK", 2015, 225_000_000, 2_250_000, 4, new DateOnly(2023, 1, 13), 75, 4_500));
            listVehicle.Add(new Taxi("D 13 UK", 2020, 275_000_000, 2_750_000, 4, new DateOnly(2023, 1, 13), 90, 4_500));
            listVehicle.Add(new PrivateJet("ID8089", 2015, 150_000_000_000, 1_500_000_000, 12, new DateOnly(2023, 1, 23), 35_000_000, 15_000_000));
            listVehicle.Add(new PrivateJet("ID8099", 2018, 175_000_000_000, 1_750_000_000, 15, new DateOnly(2023, 1, 25), 55_000_000, 25_000_000));
            
            SUV suv = new SUV();
            Taxi taxi = new Taxi();
            PrivateJet privateJet = new PrivateJet();
            Console.WriteLine($"GetTotalVehicle() : {suv.GetTotalVehicle(listVehicle)}");
            Console.WriteLine($"GetTotalVehicle(SUV) : {suv.GetTotalVehicle(listVehicle, "SUV")}");
            Console.WriteLine($"GetTotalIncomeVehicle(SUV) : {suv.GetTotalIncomeVehicle(listVehicle, "SUV")}");
            Console.WriteLine($"GetTotalIncomeVehicle(Taxi) : {taxi.GetTotalIncomeVehicle(listVehicle, "Taxi")}");
            Console.WriteLine($"GetTotalIncomeVehicle(PrivateJet) : {privateJet.GetTotalIncomeVehicle(listVehicle, "PrivateJet")}");
            Console.WriteLine($"GetTotalIncomeVehicle() : {suv.GetTotalIncomeVehicle(listVehicle)}");
            
        }

        abstract class Vehicle
        {
            public abstract String NoPolice { get; set;}
            public abstract int Year { get; set; }
            public abstract double Price { get; set; }
            public abstract int Tax { get; set; }
            public abstract int Seat { get; set; }
            public abstract DateOnly TransactionDate { get; set; }
            public abstract int Total { get; set; }
            public abstract int Rent { get; set; }
        }
        
        class SUV : Vehicle, ISummary
        {
            private String noPolice;
            private int year;
            private double price;
            private int tax;
            private int seat;
            private DateOnly transactionDate;
            private int total;
            private int rent;
            private int driver;

            public SUV()
            {
            }

            public SUV(String noPolice, int year, double price, int tax, int seat, DateOnly transactionDate, int rent, int driver)
            {
                this.noPolice = noPolice;
                this.year = year;
                this.price = price;
                this.tax = tax;
                this.seat = seat;
                this.transactionDate = transactionDate;
                this.rent = rent;
                this.driver = driver;
                this.total = rent + driver;
            }

            public override String NoPolice { get => noPolice; set => noPolice = value; }
            public override int Year { get => year; set => year = value; }
            public override double Price { get => price; set => price = value; }
            public override int Tax { get => tax; set => tax = value; }
            public override int Seat { get => seat; set => seat = value; }
            public override DateOnly TransactionDate { get => transactionDate; set => transactionDate = value; }
            public override int Total { get => total; set => total = total + rent + driver; }
            public int Rent { get => rent; set => rent = value; }
            public int Driver { get => driver; set => driver = value; }

      

            public int GetTotalIncomeVehicle(List<Vehicle> listVehicle, string vehicleType)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    if (item.GetType().Name == vehicleType)
                    {
                        total += item.Total;
                    }
                }
                return total;
            }

            public int GetTotalIncomeVehicle(List<Vehicle> listVehicle)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    total += item.Total;
                }
                return total;
            }

            public int GetTotalVehicle(List<Vehicle> listVehicle)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    total++;
                }
                return total;
            }

            public int GetTotalVehicle(List<Vehicle> listVehicle, string vehicleType)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    if (item.GetType().Name == vehicleType)
                    {
                        total++;
                    }
                }
                return total;
            }

            public override string? ToString()
            {
                return $"NoPolice/NoRegister : {NoPolice}, Year : {Year}, Price : {Price}, Tax(InYear) : {Tax}, Seat : {Seat}, TransactionDate : {TransactionDate}, " +
                    $"Rent : {Rent}, Driver : {Driver}, Total : {Total}";
            }

        }
        class Taxi : Vehicle, ISummary
        {
            private String noPolice;
            private int year;
            private double price;
            private int tax;
            private int seat;
            private DateOnly transactionDate;
            private int total;
            private int order;
            private int orderPerKm;

            public Taxi()
            {
            }

            public Taxi(String noPolice, int year, double price, int tax, int seat, DateOnly transactionDate, int order, int orderPerKm)
            {
                this.noPolice = noPolice;
                this.year = year;
                this.price = price;
                this.tax = tax;
                this.seat = seat;
                this.transactionDate = transactionDate;
                this.Order = order;
                this.OrderPerKm = orderPerKm;
                this.total = order * orderPerKm;
            }

            public override String NoPolice { get => noPolice; set => noPolice = value; }
            public override int Year { get => year; set => year = value; }
            public override double Price { get => price; set => price = value; }
            public override int Tax { get => tax; set => tax = value; }
            public override int Seat { get => seat; set => seat = value; }
            public override DateOnly TransactionDate { get => transactionDate; set => transactionDate = value; }
            public override int Total { get => total; set => total = Order * OrderPerKm; }
            public int Order { get => order; set => order = value; }
            public int OrderPerKm { get => orderPerKm; set => orderPerKm = value; }
            public override string? ToString()
            {
                return $"NoPolice/NoRegister : {NoPolice}, Year : {Year}, Price : {Price}, Tax(InYear) : {Tax}, Seat : {Seat}, TransactionDate : {TransactionDate}, " +
                    $"Order : {Order}, OrderPerKm : {OrderPerKm}, Total : {Total}";
            }
            public int GetTotalIncomeVehicle(List<Vehicle> listVehicle, string vehicleType)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    if (item.GetType().Name == vehicleType)
                    {
                        total += item.Total;
                    }
                }
                return total;
            }

            public int GetTotalIncomeVehicle(List<Vehicle> listVehicle)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    total += item.Total;
                }
                return total;
            }

            public int GetTotalVehicle(List<Vehicle> listVehicle)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    total++;
                }
                return total;
            }

            public int GetTotalVehicle(List<Vehicle> listVehicle, string vehicleType)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    if (item.GetType().Name == vehicleType)
                    {
                        total++;
                    }
                }
                return total;
            }
        }
        class PrivateJet : Vehicle, ISummary
        {
            private String noPolice;
            private int year;
            private double price;
            private int tax;
            private int seat;
            private DateOnly transactionDate;
            private int total;
            private int rent;
            private int driver;

            public PrivateJet()
            {
            }

            public PrivateJet(String noPolice, int year, double price, int tax, int seat, DateOnly transactionDate, int rent, int driver)
            {
                this.noPolice = noPolice;
                this.year = year;
                this.price = price;
                this.tax = tax;
                this.seat = seat;
                this.transactionDate = transactionDate;
                this.Rent = rent;
                this.Driver = driver;
                this.total = rent + driver;
            }

            public override String NoPolice { get => noPolice; set => noPolice = value; }
            public override int Year { get => year; set => year = value; }
            public override double Price { get => price; set => price = value; }
            public override int Tax { get => tax; set => tax = value; }
            public override int Seat { get => seat; set => seat = value; }
            public override DateOnly TransactionDate { get => transactionDate; set => transactionDate = value; }
            public override int Total { get => total; set => total = Rent + Driver; }
            public int Rent { get => rent; set => rent = value; }
            public int Driver { get => driver; set => driver = value; }
            public override string? ToString()
            {
                return $"NoPolice/NoRegister : {NoPolice}, Year : {Year}, Price : {Price}, Tax(InYear) : {Tax}, Seat : {Seat}, TransactionDate : {TransactionDate}, " +
                    $"Rent : {Rent}, Driver : {Driver}, Total : {Total}";
            }
            public int GetTotalIncomeVehicle(List<Vehicle> listVehicle, string vehicleType)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    if (item.GetType().Name == vehicleType)
                    {
                        total += item.Total;
                    }
                }
                return total;
            }

            public int GetTotalIncomeVehicle(List<Vehicle> listVehicle)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    total += item.Total;
                }
                return total;
            }

            public int GetTotalVehicle(List<Vehicle> listVehicle)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    total++;
                }
                return total;
            }

            public int GetTotalVehicle(List<Vehicle> listVehicle, string vehicleType)
            {
                var total = 0;
                foreach (var item in listVehicle)
                {
                    if (item.GetType().Name == vehicleType)
                    {
                        total++;
                    }
                }
                return total;
            }
        }

        interface ISummary
        {
            int GetTotalVehicle(List<Vehicle> listVehicle);
            int GetTotalVehicle(List<Vehicle> listVehicle, string vehicleType);
            int GetTotalIncomeVehicle(List<Vehicle> listVehicle);
            int GetTotalIncomeVehicle(List<Vehicle> listVehicle, string vehicleType);
        }
        */
        }
    }
}   