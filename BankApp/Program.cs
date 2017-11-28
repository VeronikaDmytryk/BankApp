using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // reference, object, instance of a class, Object inizialization
            var account = new Account
            {
                AccountName = "My checking",
                EmailAddress = "test@test.com",
                AccountType = TypeOfAccount.Checking,
            };
            account.Deposit(100.10M);
            Console.WriteLine($"Account Number: {account.AccountNumber}, Account Type: {account.AccountType}, Email Address: {account.EmailAddress}, Account Balance: {account.Balance}");


            var account2 = new Account {
                AccountName = "My savings",
                EmailAddress = "test@test.com",
                AccountType = TypeOfAccount.Savings,
            };
            account2.Deposit(200.10M);
            Console.WriteLine($"Account Number: {account2.AccountNumber}, Account Type: {account2.AccountType}, Email Address: {account2.EmailAddress}, Account Balance: {account2.Balance}");
         }
    }
}
