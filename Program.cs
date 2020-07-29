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
            return $"{Make}\t{Model,-13}{Year,5}\t{Price,-15}";
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
            return $"{Make}\t{Model,-13}{Year,6}\t{Price,-10} (Used) {Mileage,-5}";
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






        CarLot.AddCar(new Car("Nikolai", "Model S", 2017, 54999.90M));
        CarLot.AddCar(new Car("Fourd", "Escapade", 2017, 31999.90M));
        CarLot.AddCar(new Car("Chewie", "Vette", 2017, 44989.95M));
        CarLot.AddCar(new UsedCar("Hyonda", "Prior", 2015, 14785.50M, 35987.6));
        CarLot.AddCar(new UsedCar("GC", "\tChirpus", 2013, 8500.00M, 12345.0));
        CarLot.AddCar(new UsedCar("GC", "\tWitherell", 2016, 14450.00M, 3500.3));

        CarLot.PrintCar();
        while (keepBuying)
        {
            Console.Write("Which car would you like?");
            int input = int.Parse(Console.ReadLine());



            if (input == CarLot.Inventory.Count + 2) //quit
            {
                Console.WriteLine("Good Bye!");
                break;
            }
            else if (input > CarLot.Inventory.Count - 1) //add a car
            {
                Console.Write("Is the car new or used? (u/n):");
                string userNew = Console.ReadLine().ToUpper();



                if (userNew == "U")
                {
                    Console.Write("Enter the Make:");
                    string Umake = Console.ReadLine();
                    Console.Write("Enter the Model:");
                    string Umodel = Console.ReadLine();
                    Console.Write("Enter the Year:");
                    int Uyear = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Price:");
                    Decimal Uprice = Decimal.Parse(Console.ReadLine());
                    Console.Write("Enter the Mileage:");
                    int Umileage = int.Parse(Console.ReadLine());



                    CarLot.AddCar(new UsedCar(Umake, Umodel, Uyear, Uprice, Umileage));
                    CarLot.PrintCar();
                }
                else if (userNew == "N")
                {
                    Console.Write("Enter the Make:");
                    string make = Console.ReadLine();
                    Console.Write("Enter the Model:");
                    string model = Console.ReadLine();
                    Console.Write("Enter the Year:");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Price:");
                    Decimal price = Decimal.Parse(Console.ReadLine());




                    CarLot.AddCar(new Car(make, model, year, price));
                    CarLot.PrintCar();
                }
                else if (userNew != "U" || userNew != "N")
                {
                    Console.WriteLine("Not a valid Choice");
                    continue;
                }



            }
            else if (input <= CarLot.Inventory.Capacity - 1) //This checks for inventory size -1
            {
                Console.WriteLine(CarLot.Inventory[input - 1]);
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
                else if (choice == "N")
                {
                    Console.WriteLine("Have a Great Day! Think about buying another car in the futrue.");
                    keepBuying = false;
                }



            }
        }



    }
}