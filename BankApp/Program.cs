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
            while (true)
            {
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.Create an account");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Print all accounts");
                Console.WriteLine("5.Print all transactions");
                Console.Write("Please choose one opition from above:");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting");
                        return;
                    case "1":
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.Write("Account Name: ");
                        var accountName = Console.ReadLine();
                        var typeOfAccounts = Enum.GetNames(typeof(TypeOfAccount));
                        for (var i = 0; i < typeOfAccounts.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{typeOfAccounts[i]}");
                        }
                        Console.Write("Account Type: ");
                        var accountType = Convert.ToInt32(Console.ReadLine());
                        var account = Bank.CreateAccount(emailAddress, accountName, (TypeOfAccount)(accountType - 1)); /*(TypeOfAccount)(accountType-1) - converting Enum types*/
                        Console.WriteLine($"AN: {account.AccountNumber}, Account Name: {account.AccountName} Balance: {account.Balance}, Type: {account.AccountType}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        var an = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit:");
                        var amt = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(an, amt);
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        var acn = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw:");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(acn, amount);
                        Console.WriteLine("You successfully withdraw: "+ amount + " dollars");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        acn = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactions(acn);
                        foreach (var tran in transactions) {
                            Console.WriteLine($"Tranaction ID: { tran.TransactionId}, Type of transaction {tran.TypeOfTransaction}, Transaction Amount: {tran.TransactionAmount}, Transaction Date: {tran.TransactionDate}, Description: {tran.Description}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var email = Console.ReadLine();
            var accounts = Bank.GetAllAccounts(email);
            Console.WriteLine($"Accounts:");
            foreach (var acnt in accounts)
            {
                Console.WriteLine($"AN: {acnt.AccountNumber}, Account Name: {acnt.AccountName} Balance: {acnt.Balance}, Type: {acnt.AccountType}");
            }
        }
    }
}
