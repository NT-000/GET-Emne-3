using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Customer
    {
        private static int counter = 0;
        private string _customerName { get; set; }
        int _customerId { get; set; }
        Account _savingsAccount { get; set; }
        Account _currentAccount { get; set; }

        private string Password {get; set;}

        public Customer(string customerName)
        {
           _customerName = customerName;
           _customerId = counter++;
           _savingsAccount = new Account(true, "savings");
           _currentAccount = new Account(false, "common");

        }

        public Customer(string customerName, string password)
        {
            _customerName = customerName;
            Password = password;
            _customerId = counter++;
        }
        public string GetCustomerName()
        {
            return _customerName;
        }

        public bool PasswordMatches(string password)
        {
            return Password == password;
        }

        public int GetCustomerId()
        {
            return _customerId;
        }
        public void WithdrawMoney(int sum, bool fromSavingsAccount)
        {
            if (fromSavingsAccount)
            {
                _savingsAccount.Withdraw(sum);
            }
            else
            {
                _currentAccount.Withdraw(sum);
            }
        }

        public void DepositToCurrentAccount(int amount)
        {
            _savingsAccount.DepositMoney(amount);
        }
        //public int ReturnAccount(int amount)
        //{
        //    _savingsAccount.DepositMoney(amount);
        //}
    }
}
