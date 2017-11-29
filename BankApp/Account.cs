using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    //Own data type, choice list
    enum TypeOfAccount
    {
        Checking,
        Savings,
        CD,
        Loan
    }

    /// <summary>
    /// This is about a bank account  
    /// </summary>
    class Account
    {
        #region static
        private static int lastAccountNumber = 0;
        #endregion
        #region Constructor
        public Account()
        {
            AccountNumber = ++lastAccountNumber;
        }
        #endregion
        #region Properties
        public int AccountNumber { get; private set; }
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        public TypeOfAccount AccountType { get; set; } 
        public decimal Balance { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        public void Deposit (decimal amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Withdraw money from your account
        /// </summary>
        /// <param name="amount">Amount to be withdrawed</param>
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion
    }
}
