using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Bank
    {
        private List<Customer> customers = new List<Customer>();

        private int _loggedInCustomer;
        private Customer _currentCustomer = new Customer("Kåre", true);

        public Bank()
        {  BankMenu();
           var user1 = new Customer("Jan", "hei");
           var user2 = new Customer("Arne", "kul");
           var user3 = new Customer("Kjell", "123");
           var user4 = new Customer("Anna", "123");


            customers.Add(user1);
            customers.Add(user2);
            customers.Add(user3);
            customers.Add(user4);

        }

        private bool _isMenu = true;
        void BankMenu()
        {

            LoginScreen();

            Console.WriteLine("1.Deposit money");
            Console.WriteLine("2.Withdraw money");
            Console.WriteLine("3.Pay bill");
            Console.WriteLine("4.Transfer money to savings");
            Console.WriteLine("5.Check account balance");
            var userinput = Console.ReadLine();
            while (_isMenu)
            {
                switch (userinput)
                {
                    case "1":
                        Console.WriteLine("Deposit money");
                        var amountToDeposit = int.Parse(Console.ReadLine());
                        var loggedInCustomer2 = customers.Find(c => c.GetCustomerId() == _loggedInCustomer);
                        loggedInCustomer2.DepositToCurrentAccount(amountToDeposit);
                        break;
                    case "2":
                        Console.WriteLine($"how Much money do you want to withdraw?");
                        var withdrawMoney = int.Parse(Console.ReadLine());
                        var loggedInCustomer = customers.Find(c => c.GetCustomerId() == _loggedInCustomer);
                            loggedInCustomer.WithdrawMoney(withdrawMoney, true);

                        break;
                    case "3":
                        _currentCustomer.ShowBills();
                        var billId = int.Parse(Console.ReadLine());
                        _currentCustomer.PayBill(billId);

                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                }
            }
        }

        void LoginScreen()
        {
            Console.WriteLine("Welcome to BankScam, already a customer or do you want to register?");
            Console.WriteLine("1.Log In");
            Console.WriteLine("1.Register New Account");
            var inputChoice = int.Parse(Console.ReadLine());


            if (inputChoice == 1)
            {
                Console.WriteLine("Enter Name and Password");
                var inputName = Console.ReadLine();
                var inputPassword = Console.ReadLine();
                LoginUser(inputName,inputPassword, customers);
            }
            else if (inputChoice == 2)
            {
                Console.WriteLine("Register a new account today");
                RegisterUser();
            }

        }

        public void LoginUser(string userName, string password, List<Customer> customers)
        {
           var userFound = customers.Find(user => user.GetCustomerName() == userName && user.PasswordMatches(password));
           if (userFound != null)
           {
               Console.WriteLine($"Velkommen {userFound.GetCustomerName()}!");
               _loggedInCustomer = userFound.GetCustomerId();
               BankMenu();
           }
           else
           {
               return;
           }

        }
        void RegisterUser()
        {
            Console.WriteLine("Enter Name");
            string inputName = Console.ReadLine();
            string inputPassword = Console.ReadLine();
        }
        
    }
}
