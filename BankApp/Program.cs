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
            // reference, object, instance of a class
            var account = new Account();
            account.EmailAddress = "test@test.com";
            account.AccountType = "Checking";
            account.Deposit(100.10M);
            Console.WriteLine($"{account.Balance}");
        }
    }
}
