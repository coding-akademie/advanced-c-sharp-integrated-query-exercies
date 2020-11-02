using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitSupply
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FruitSupplier> suppliers = new List<FruitSupplier>()
            {
                new FruitSupplier()
                {
                    Name = "Frucht Krause",
                    Offers = new List<Fruit>()
                    {
                        new Fruit(){ Name = "Apple", PricePerKG = 1.50m, StockQuantity = 220},
                        new Fruit(){ Name = "Banana", PricePerKG = 2.00m, StockQuantity = 200},
                        new Fruit(){ Name = "Pear", PricePerKG = 2.00m, StockQuantity = 100}
                    },
                    ShippingCosts = 5.0m
                },
                new FruitSupplier()
                {
                    Name = "Früchteparadies",
                    Offers = new List<Fruit>()
                    {
                        new Fruit(){ Name = "Apple", PricePerKG = 1.90m, StockQuantity = 50},
                        new Fruit(){ Name = "Banana", PricePerKG = 2.50m, StockQuantity = 100},
                        new Fruit(){ Name = "Pear", PricePerKG = 2.20m, StockQuantity = 150},
                        new Fruit(){ Name = "Pineapple", PricePerKG = 4.50m, StockQuantity = 50}
                    },
                    ShippingCosts = 0.0m
                },
                new FruitSupplier()
                {
                    Name = "Fruits Unlimited",
                    Offers = new List<Fruit>()
                    {
                        new Fruit(){ Name = "Apple", PricePerKG = 1.20m, StockQuantity = 350},
                        new Fruit(){ Name = "Banana", PricePerKG = 1.80m, StockQuantity = 30},
                        new Fruit(){ Name = "Pineapple", PricePerKG = 4.20m, StockQuantity = 50}
                    },
                    ShippingCosts = 2.0m
                },
                new FruitSupplier()
                {
                    Name = "Bauer Hans",
                    Offers = new List<Fruit>()
                    {
                        new Fruit(){ Name = "Apple", PricePerKG = 1.70m, StockQuantity = 350},
                        new Fruit(){ Name = "Pear", PricePerKG = 2.00m, StockQuantity = 30},
                        new Fruit(){ Name = "Cherry", PricePerKG = 3.50m, StockQuantity = 50}
                    },
                    ShippingCosts = 5.0m
                }
            };


            // all fruit supplier names (method + query)
            Console.WriteLine("All fruit suppliers (method):");


            Console.WriteLine("\nAll fruit suppliers (query):");



            // all fruit supplier names with shipping costs > 0  (method + query)
            Console.WriteLine("\nAll supplier names with shipping costs > 0 (method):");


            Console.WriteLine("\nAll supplier names with shipping costs > 0 (query):");



            // all offers with supplier name, fruit name and price (method + query)
            Console.WriteLine("\nAll offers with supplier name, fruit name and price (method):");


            Console.WriteLine("\nAll offers with supplier name, fruit name and price (query):");



            // total stock quantity of bananas from all suppliers (method)
            Console.WriteLine("\nTotal stock of bananas (method):");



            // supplier name with total cost of 10 kg bananas including shipping (method + query)
            Console.WriteLine("\nCost for 10 kg bananas incuding shipping (method):");


            Console.WriteLine("\nCost for 10 kg bananas incuding shipping (query):");



            // supplier with the most expensive bananas (method)
            Console.WriteLine("\nSupplier with the most expensive bananas (method):");



            // supplier with the  cheapest bananas (query)
            Console.WriteLine("\nSupplier with the cheapest bananas (query):");



            /// fruit supplier ratings
            List<FruitSupplierRating> ratings = new List<FruitSupplierRating>()
            {
                new FruitSupplierRating() { Name = "Früchteparadies", Description = "*****"},
                new FruitSupplierRating() { Name = "Bauer Hans", Description = "****"},
                new FruitSupplierRating() { Name = "Fruits Unlimited", Description = "**"}
            };



            // suppliers with their rating (method + query)
            Console.WriteLine("\nSupplier with their rating (method):");


            Console.WriteLine("\nSupplier with their rating (query):");

        }
    }
}
