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

            var allSuppliersMethod = suppliers.Select(supplier => supplier.Name);

            allSuppliersMethod.ToList().ForEach(supplier => Console.WriteLine(supplier));


            Console.WriteLine("\nAll fruit suppliers (query):");

            var allSuppliersQuery = from supplier in suppliers select supplier.Name;

            allSuppliersQuery.ToList().ForEach(supplier => Console.WriteLine(supplier));



            // all fruit supplier names with shipping costs > 0  (method + query)
            Console.WriteLine("\nAll supplier names with shipping costs > 0 (method):");

            var suppliersWithShippingCostsMethod = suppliers.Where(supplier => supplier.ShippingCosts > 0).Select(supplier => supplier.Name);

            suppliersWithShippingCostsMethod.ToList().ForEach(supplier => Console.WriteLine(supplier));


            Console.WriteLine("\nAll supplier names with shipping costs > 0 (query):");

            var suppliersWithShippingCostsQuery =
                from supplier in suppliers
                where supplier.ShippingCosts > 0
                select supplier.Name;

            suppliersWithShippingCostsQuery.ToList().ForEach(supplier => Console.WriteLine(supplier));



            // all offers with supplier name, fruit name and price (method + query)
            Console.WriteLine("\nAll offers with supplier name, fruit name and price (method):");

            var allOffersMethod = suppliers.SelectMany(supplier => supplier.Offers.Select(offer => new { Supplier = supplier.Name, Fruit = offer.Name, offer.PricePerKG }));

            allOffersMethod.ToList().ForEach(offer => Console.WriteLine("Supplier: " + offer.Supplier + ", Fruit: " + offer.Fruit + ", Price: " + offer.PricePerKG));


            Console.WriteLine("\nAll offers with supplier name, fruit name and price (query):");

            var allOffersQuery =
                from supplier in suppliers
                from offer in supplier.Offers
                select new { Supplier = supplier.Name, Fruit = offer.Name, offer.PricePerKG };

            allOffersQuery.ToList().ForEach(offer => Console.WriteLine("Supplier: " + offer.Supplier + ", Fruit: " + offer.Fruit + ", Price: " + offer.PricePerKG));



            // total stock quantity of bananas from all suppliers (method)
            Console.WriteLine("\nTotal stock of bananas (method):");

            int bananaStock = suppliers.SelectMany(supplier => supplier.Offers.Where(offer => offer.Name == "Banana").Select(offer => offer.StockQuantity)).Sum();

            Console.WriteLine(bananaStock);



            // supplier name with total cost of 10 kg bananas including shipping (method + query)
            Console.WriteLine("\nCost for 10 kg bananas incuding shipping (method):");

            var bananasMethod = suppliers.SelectMany(supplier => supplier.Offers.Where(offer => offer.Name == "Banana").Select(offer => new
            {
                Supplier = supplier.Name,
                TotalPrice = supplier.ShippingCosts + (10 * offer.PricePerKG)
            }));

            bananasMethod.ToList().ForEach(bananaOffer => Console.WriteLine("Supplier: " + bananaOffer.Supplier + ", Price: " + bananaOffer.TotalPrice));


            Console.WriteLine("\nCost for 10 kg bananas incuding shipping (query):");

            var bananasQuery =
                from supplier in suppliers
                from offer in supplier.Offers
                where offer.Name == "Banana"
                select new
                {
                    Supplier = supplier.Name,
                    TotalPrice = supplier.ShippingCosts + (10 * offer.PricePerKG)
                };

            bananasQuery.ToList().ForEach(bananaOffer => Console.WriteLine("Supplier: " + bananaOffer.Supplier + ", Price: " + bananaOffer.TotalPrice));



            // supplier with the most expensive bananas (method)
            Console.WriteLine("\nSupplier with the most expensive bananas (method):");

            string supplierWithMostExpensiveBananas = suppliers
                .SelectMany(supplier => supplier.Offers.Where(offer => offer.Name == "Banana").Select(offer => new { Supplier = supplier.Name, offer.PricePerKG }))
                .OrderByDescending(bananaOffer => bananaOffer.PricePerKG)
                .Select(bananaOffer => bananaOffer.Supplier).FirstOrDefault();
                     
            Console.WriteLine(supplierWithMostExpensiveBananas);



            // supplier with the  cheapest bananas (query)
            Console.WriteLine("\nSupplier with the cheapest bananas (query):");

            string supplierWitCheapestBananas =
                (
                from supplier in suppliers
                from offer in supplier.Offers where offer.Name == "Banana"
                orderby offer.PricePerKG
                select supplier.Name
                ).FirstOrDefault();

            Console.WriteLine(supplierWitCheapestBananas);



            /// fruit supplier ratings
            List<FruitSupplierRating> ratings = new List<FruitSupplierRating>()
            {
                new FruitSupplierRating() { Name = "Früchteparadies", Description = "*****"},
                new FruitSupplierRating() { Name = "Bauer Hans", Description = "****"},
                new FruitSupplierRating() { Name = "Fruits Unlimited", Description = "**"}
            };



            // suppliers with their rating (method + query)
            Console.WriteLine("\nSupplier with their rating (method):");

            var suppliersWithRatingsMethod =
                suppliers.Join(ratings, supplier => supplier.Name, rating => rating.Name, (supplier, rating) => new { supplier.Name, Rating = rating.Description });

            suppliersWithRatingsMethod.ToList().ForEach(supplierWithRating => Console.WriteLine(supplierWithRating.Name + " " + supplierWithRating.Rating));


            Console.WriteLine("\nSupplier with their rating (query):");

            var suppliersWithRatingsQuery =
                from supplier in suppliers
                join rating in ratings
                on supplier.Name equals rating.Name
                select new { supplier.Name, Rating = rating.Description };

            suppliersWithRatingsQuery.ToList().ForEach(supplierWithRating => Console.WriteLine(supplierWithRating.Name + " " + supplierWithRating.Rating));
        }
    }
}
