using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount_OOP.Models
{
    public enum AccountType {Current, Saving }
    public class BankAccount
    {
        // static data member
        static int NumberOfAccounts;

        // Data Members
        public int AccountID { get; private set; }
        public string  CustomerName { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; private set; }

        // Methods
        public BankAccount(decimal balanceAmount)
        {
            NumberOfAccounts += 1;
            AccountID = NumberOfAccounts;
        }


        public void Deposit(decimal amount)
        {
             
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {

            Balance -= amount;
        }

    }
}
