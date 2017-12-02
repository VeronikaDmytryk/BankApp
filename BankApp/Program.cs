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
            Console.WriteLine("************************");
            Console.WriteLine("Welcome to my Bank");
            Console.WriteLine("************************");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Create an account");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("4.Print all accounts");

            Console.Write("Please choose one opition fromm above:");
            var choice = Console.ReadLine();

            switch (choice) {
                case "0":
                    Console.WriteLine("Thank you for visiting");
                    return;
                case "1":
                    Console.Write("Email Address: ");
                    var emailAddress = Console.ReadLine();
                    Console.Write("Account Type: ");
                    var accountName = Console.ReadLine();
                    var typeOfAccounts = Enum.GetNames(typeof(TypeOfAccount));
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    break;
            }
        }
    }
}
