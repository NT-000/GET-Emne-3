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
        private string Password { get; set; }

        List<Bill> _bills;//

        public Customer(string customerName)
        {
            _customerName = customerName;
            _customerId = counter++;
            _bills = new List<Bill>();
        }
   

        public Customer(string customerName, string password)
        {
            _customerName = customerName;
            Password = password;
            _customerId = counter++;
            _bills = new List<Bill>();
        }

        public Customer(string customerName, bool hasBills)
        {
            _customerName = customerName;
            _customerId = counter++;
            _savingsAccount = new Account(true, "savings");
            _currentAccount = new Account(false, "common");
            _bills = new List<Bill>()
            {
                new Bill(1,5239, "757574", new DateTime(2025, 2, 3)),
                new Bill(2,5239, "752574", new DateTime(2025, 2, 3)),
                new Bill(3,35239, "657574", new DateTime(2025,05,04))
            };
        }
   

        public void ShowBills()
        {
            foreach (Bill bill in _bills)
            {
                Console.WriteLine($"{bill._accountNumber} Amount: {bill._amount} Due date: {bill._payDate}");
            }
        }

        public Bill GetBill(int billId)
        {
            Bill foundBill = _bills.First(bill => bill._id == billId);
            return foundBill;
        }

        public void PayBill(int billId)
        {
            var bill = GetBill(billId);
            _currentAccount.Withdraw(bill._amount);
            _bills.Remove(bill);
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

