using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Bank
    {
        private Customers _currentCustomer;

        public Bank()
        {
            _currentCustomer = new Customers("Kåre Andersen");
            BankMenu();
        }

        void BankMenu()
        {
            Console.WriteLine($"Welcome to the bank, {_currentCustomer.ReturnCustomer()}");
            Console.WriteLine("1.Deposit money");
            Console.WriteLine("2.Withdraw money");
            Console.WriteLine("3.Pay bill");
            Console.WriteLine("4.Transfer money to savings");
            Console.WriteLine("5.Check account balance");

            var userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("Deposit money");
                    var amountToDeposit = int.Parse(Console.ReadLine());
                    _currentCustomer.DepositToCurrentAccount(amountToDeposit);
                    break;
                case "2":
                    Console.WriteLine($"how Much money do you want to withdraw?");
                    var withdrawMoney = int.Parse(Console.ReadLine());
                    _currentCustomer.WithdrawMoney(withdrawMoney, true);
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }
        }
    }
}
