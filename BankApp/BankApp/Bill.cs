using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Bill
    {   public int _id { get; set;}
        public int _amount {get; set;}
        public string _accountNumber { get; set; }
        public int _kidNr { get; set; }
        public DateTime _payDate { get; set; }

        public Bill(int id,int billAmount, string billNum, DateTime timeToPay)
        {
            _id = id;
            _amount = billAmount;
            _accountNumber = billNum;
            _payDate = timeToPay;
        }

        public int GetAmount()
        {
            return _amount;
        }
    }


}
