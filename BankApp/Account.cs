using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    //Own data type, choice list
    public enum TypeOfAccount
    {
        Checking,
        Savings,
        CD,
        Loan
    }

    /// <summary>
    /// This is about a bank account  
    /// </summary>
    public class Account
    {
        #region Constructor
        public Account(){}
        #endregion

        #region Properties
        [Key]
        public int AccountNumber { get; set; }
        [StringLength(100, ErrorMessage ="Email address should be of 50 characters in length")]
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        public TypeOfAccount AccountType { get; set; } 
        public decimal Balance { get; set; }
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
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("amount", "Amount cannot exceed the balance!");
            }
            Balance -= amount;
        }
        #endregion
    }
}
