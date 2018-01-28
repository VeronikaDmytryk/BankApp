using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class Bank
    {
        private static BankModel db = new BankModel();

        public static Account CreateAccount(string emailAddress,
                                            string accountName = "Default Account",
                                            TypeOfAccount accountType = TypeOfAccount.Checking)
        {

            Account account = new Account
            {
                EmailAddress = emailAddress,
                AccountName = accountName,
                AccountType = accountType,
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static List<Account> GetAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(a=>a.EmailAddress == emailAddress).ToList();
        }

        public static Account EditAccount(Account account)
        {
            if (account == null) {
                throw new ArgumentNullException("account", "Invalid Account");
            }
            var oldAccount = db.Accounts.Find(account.AccountNumber);
            if (oldAccount == null) {
                throw new ArgumentOutOfRangeException("account", "Invalid account number!");
            }

            db.Entry(oldAccount).CurrentValues.SetValues(account);
            db.SaveChanges();

            return account;
        }

        public static List<Transaction> GetAllTransactions(int acountNumber) {
            return db.Transactions.Where(t => t.AccountNumber == acountNumber).OrderByDescending(t=>t.TransactionDate).ToList();
        }

        public static void Deposit(int accountNumber, decimal amount) {
            
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null) {
                account.Deposit(amount);
                var transaction = new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TypeOfTransaction = TransactionType.Credit,
                    TransactionAmount = amount,
                    Description = "Deposit in a branch",
                    AccountNumber = account.AccountNumber
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Withdraw(amount);
                var transaction = new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TypeOfTransaction = TransactionType.Debit,
                    TransactionAmount = amount,
                    Description = "Withdrawal in a branch",
                    AccountNumber = account.AccountNumber
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }
    }
}
