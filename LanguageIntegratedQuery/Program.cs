using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LanguageIntegratedQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            // banks & accounts
            List<Bank> banks = new List<Bank>()
            {
                new Bank()
                {
                    Name = "Deutsches Bankhaus",
                    Accounts = new List<BankAccount>()
                    {
                        new BankAccount() { ID = 0, Name = "Max Mustermann", Balance = 24429.29m},
                        new BankAccount() { ID = 1, Name = "Petra Müller", Balance = -9429.90m},
                        new BankAccount() { ID = 2, Name = "Franz Zeiler", Balance = 9294429.60m}
                    }
                },
                new Bank()
                {
                    Name = "Schatzkasse",
                    Accounts = new List<BankAccount>()
                    {
                        new BankAccount() { ID = 3, Name = "Manfred Müller", Balance = 1429.29m},
                        new BankAccount() { ID = 4, Name = "Bernd Käser", Balance = -429.90m},
                        new BankAccount() { ID = 5, Name = "Angela Weikel", Balance = 4429.60m}
                    }
                },
                new Bank()
                {
                    Name = "Schleifeisen Bank",
                    Accounts = new List<BankAccount>()
                    {
                        new BankAccount() { ID = 6, Name = "Anton Schulz", Balance = 2429.42m},
                        new BankAccount() { ID = 7, Name = "Tom Weber", Balance = 44429.02m},
                        new BankAccount() { ID = 8, Name = "Bernhard Kaiser", Balance = -1429.32m}
                    }
                }
            };



            // all bank names
            Console.WriteLine("Banks (method):");

            var bankNamesMethod = banks.Select(b => b.Name);

            bankNamesMethod.ToList().ForEach(n => Console.WriteLine(n));


            Console.WriteLine("\nBanks (query):");

            var bankNamesQuery = from b in banks select b.Name;

            bankNamesQuery.ToList().ForEach(n => Console.WriteLine(n));



            // all account holder names with their bank's name and balance
            Console.WriteLine("\nAccount holders with bank name and balance (method):");

            var accountHoldersMethod = banks.SelectMany(bank => bank.Accounts.Select(account => new { Name = account.Name, BankName = bank.Name, account.Balance }));

            accountHoldersMethod.ToList().ForEach(a => Console.WriteLine("Name: " + a.Name + ", BankName: " + a.BankName + ", Balance: " + a.Balance));


            Console.WriteLine("\nAccount holders with bank name and balance (query):");

            var accountHoldersQuery =
                from bank in banks
                from account in bank.Accounts
                select new { Name = account.Name, BankName = bank.Name, account.Balance };

            accountHoldersQuery.ToList().ForEach(a => Console.WriteLine("Name: " + a.Name + ", BankName: " + a.BankName + ", Balance: " + a.Balance));



            // account holders with a positive balance (method)
            Console.WriteLine("\nAccount holders with a positive balance (method):");

            var accountHolderPlus = accountHoldersMethod.Where(account => account.Balance > 0).Select(account => new { account.Name, account.Balance });

            accountHolderPlus.ToList().ForEach(account => Console.WriteLine("Name: " + account.Name + ", Balance: " + account.Balance));



            // account holders with a positive balance (method)
            Console.WriteLine("\nAccount holders with a negative balance (query):");

            var accountHolderMinus =
                from account in accountHoldersQuery
                where account.Balance < 0
                select new { account.Name, account.Balance };

            accountHolderMinus.ToList().ForEach(account => Console.WriteLine("Name: " + account.Name + ", Balance: " + account.Balance));



            // all banks with their total balance
            Console.WriteLine("\nAll banks with total balance:");

            var banksWithTotalBalance = banks.Select(bank => new { bank.Name, TotalBalance = bank.Accounts.Sum(account => account.Balance) });

            banksWithTotalBalance.ToList().ForEach(bank => Console.WriteLine(bank.Name + " " + bank.TotalBalance));



            // total balance of all banks
            Console.WriteLine("\nTotal balance of all banks:");

            decimal totalBalanceOfAllBanks = banks.Sum(bank => bank.Accounts.Sum(account => account.Balance));

            Console.WriteLine(totalBalanceOfAllBanks);



            // richest account holder
            Console.WriteLine("\nRichest account holder:");

            string richestHolder = banks.SelectMany(bank => bank.Accounts).OrderByDescending(account => account.Balance).Select(account => account.Name).FirstOrDefault();

            Console.WriteLine(richestHolder);



            // poorest account holder
            Console.WriteLine("\nPoorest account holder:");

            string poorestHolder =
                (
                    from bank in banks
                    from account in bank.Accounts
                    orderby account.Balance
                    select account.Name
                ).FirstOrDefault();

            Console.WriteLine(poorestHolder);



            // credit ratings
            List<CreditRating> creditRatings = new List<CreditRating>()
            {
                new CreditRating() { Name = "Tom Weber", RatingDescription = "Very Good"},
                new CreditRating() { Name = "Manfred Müller", RatingDescription = "OK"},
                new CreditRating() { Name = "Anton Schulz", RatingDescription = "Good"},
                new CreditRating() { Name = "Bernhard Kaiser", RatingDescription = "Poor"}
            };


            // all account holders that have a credit rating
            Console.WriteLine("\nAccount holders which have a credit rating (method):");

            var accountHoldersWithCreditRatingMethod =
                accountHoldersMethod.Join( // outer table
                    creditRatings, // inner table
                    accountHolder => accountHolder.Name, // outer key
                    creditRating => creditRating.Name, // inner key
                    (accountHolder, creditRating) => new { accountHolder.Name, accountHolder.Balance, creditRating.RatingDescription } ); // result selector

            accountHoldersWithCreditRatingMethod.ToList().ForEach(a => Console.WriteLine("Name: " + a.Name + ", Balance: " + a.Balance + ", Credit Rating: " + a.RatingDescription));


            Console.WriteLine("\nAccount holders which have a credit rating (query):");

            var accountHoldersWithCreditRatingQuery =
                from accountHolder in accountHoldersQuery // outer table
                join creditRating in creditRatings // inner table
                on accountHolder.Name equals creditRating.Name // keys
                select new { accountHolder.Name, accountHolder.Balance, creditRating.RatingDescription }; // result selector

            accountHoldersWithCreditRatingQuery.ToList().ForEach(a => Console.WriteLine("Name: " + a.Name + ", Balance: " + a.Balance + ", Credit Rating: " + a.RatingDescription));


        }
    }
}
