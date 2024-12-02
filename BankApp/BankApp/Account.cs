using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Account
    {
        private int _balance { get; set; }
        private string _accountName { get; set; }
        bool _savingsAccount { get; set; }
        private string _accountNumber { get; set; }
        private List<Account> _accountTransactions = new List<Account>();

        public Account(bool isSavingsAccount, string accountName)
        {
            _savingsAccount = isSavingsAccount;
            _accountName = accountName;
            _balance = 0;
            _accountTransactions = new List<Account>();
            _accountNumber = new Guid().ToString();
        }
        public void DepositMoney(int amountToDeposit)
        {
            _balance += amountToDeposit;
        }

       public void Withdraw(int sum)
        {
            if (_balance >= sum)
            {
                _balance -= sum;
                
            }
            else
            {
                Console.WriteLine("You don't have to enough money");
            }
            Console.WriteLine($"New Balance: {_balance}");
        }
        public int GetBalance()
        {
            return _balance;
        }
    }
}
