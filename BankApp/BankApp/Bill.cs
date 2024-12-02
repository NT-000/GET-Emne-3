using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Bill
    {
        private int _amount {get; set;}
        private string _accountNumber { get; set; }
        private int _kidNr { get; set; }
        private DateTime _payDate { get; set; }
    }
}
