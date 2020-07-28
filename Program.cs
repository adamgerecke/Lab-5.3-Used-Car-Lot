using System;
using System.Collections.Generic;
using Lab_5._3_Used_Car_Lot;

namespace Lab_5._3_Used_Car_Lot
{
    class Car
    {
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
            //Console.WriteLine($"There are {Inventory.Count} cars in the lot.");

            for (int i = 0; i < CarLot.Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {CarLot.Inventory[i]}");
            }
            Console.WriteLine($"{CarLot.Inventory.Count + 1}. Add a car");
            Console.WriteLine($"{CarLot.Inventory.Count + 2}. Quit");
        }

    }
    
}

class Program
{
    static void Main(string[] args)
    {
        bool keepBuying = true;
        
        Console.WriteLine("Welcome to the Grant Chirpus' Used Car Emporium!");
        Console.WriteLine();

        while (keepBuying)
        {
            CarLot.AddCar(new Car("Nikolai", "Model S", 2017, 54999.90M));
            CarLot.AddCar(new Car("Fourd", "Escapade", 2017, 31999.90M));
            CarLot.AddCar(new Car("Chewie", "Vette", 2017, 44989.95M));
            CarLot.AddCar(new UsedCar("Hyonda", "Prior", 2015, 14785.50M, 35987.6));
            CarLot.AddCar(new UsedCar("GC", "Chirpus", 2013, 8500.00M, 12345.0));
            CarLot.AddCar(new UsedCar("GC", "Witherell", 2016, 14450.00M, 3500.3));

            CarLot.PrintCar();

            Console.Write("Which car would you like?");
            int input = int.Parse(Console.ReadLine());

            if (input == CarLot.Inventory.Capacity) //option 7
            {
                Console.WriteLine("Good Bye!");
                break;
            }
            else if (input == CarLot.Inventory.Capacity - 1) //option 7
            { 

                    Console.WriteLine("Good Bye ADD A CAR!");
                    break;
            }
            else if (input <=CarLot.Inventory.Capacity - 1) //This checks for inventory size -1
            {
                //Console.WriteLine(CarLot.Inventory[input - 1]);
                Console.Write("Would you like to buy this car? (y/n):");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    CarLot.RemoveCar(CarLot.Inventory[input - 1]);
                    Console.WriteLine("Excellent! Our finance department will be in touch shortly.!");
                    Console.WriteLine();
                    CarLot.PrintCar();
                }
                else if (choice != "N")
                {
                    Console.WriteLine("That is not a Valid Choice.");
                    continue;
                }
                else if(choice == "N")
                {
                    Console.WriteLine("Have a Great Day! Think about buying another car in the futrue.");
                    keepBuying = false;
                }

 
                /*else if () //option 8
                {

                }*/
            }
        }
       
    }
}


