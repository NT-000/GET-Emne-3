using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloads
{
    public class Message
    {
        public string defCompliment;
        public string defText;
        public void PrintWelcomeMessage()
        {
            defText = "du er snill";
            Console.WriteLine($"\nHei og velkommen, {defText}\n");

        }

        public void PrintWelcomeMessage(string compliment)
        {
            defCompliment = compliment;
            Console.WriteLine($"Hei og velkommen, {compliment}\n");
        }
    }
}
