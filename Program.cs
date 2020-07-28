using System;
using System.Collections.Generic;
using Lab_5._3_Used_Car_Lot;

namespace Lab_5._3_Used_Car_Lot
{
    class Car
    {
        //public static List<Car> Cars = new List<Car>();
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Decimal Price { get; set; }

        public Car()
        {

        }
        public Car(string aMake, string aModel, int aYear, Decimal aPrice)
        {
            Make = aMake;
            Model = aModel;
            Year = aYear;
            Price = aPrice;

        }

        
        public override string ToString()
        {
            return $"{Make}, {Model}, {Year}, {Price}.";
        }

    }
    
    class UsedCar : Car
    {
        public double Mileage;

        public UsedCar(string aMake, string aModel, int aYear, Decimal aPrice, double aMileage) : base(aMake, aModel, aYear, aPrice)
        {
            Mileage = aMileage;
        }
        public override string ToString()
        {
            return $"{Make}, {Model}, {Year}, {Price}, {Mileage}.";
        }
    }
    class CarLot
    {

        public static List<Car> Inventory = new List<Car>();
       

        public static void AddCar(Car aCar) // Takes an input from the Car Class and calls it aCar
        {
            Inventory.Add(aCar);
        }

        public static void RemoveCar(Car aCar)
        {
            Inventory.Remove(aCar);
        }
        public static void PrintCar()
        {
            Console.WriteLine($"There are {Inventory.Count} cars in the lot.");
            foreach(var cars in Inventory)
            {
                Console.WriteLine(cars);
            }
        }

    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Grant Chirpus' Used Car Emporium!");
        Console.WriteLine();
        
        Car car1 = new Car("Nikolai", "Model S", 2017, 54999.90M);
        Car car2 = new Car("Fourd", "Escapade", 2017, 31999.90M);
        Car car3 = new Car("Chewie", "Vette", 2017, 44989.95M);
        Car car4 = new UsedCar("Hyonda", "Prior", 2015, 14785.50M, 35987.6);
        Car car5 = new UsedCar("GC", "Chirpus", 2013, 8500.00M, 12345.0);
        Car car6 = new UsedCar("GC", "Witherell", 2016, 14450.00M, 3500.3);
        

        
        
        /*CarLot.AddCar(car1);
        CarLot.AddCar(car2);
        CarLot.PrintCar();
        CarLot.RemoveCar(car1);
        CarLot.PrintCar();
        */
    }
}


