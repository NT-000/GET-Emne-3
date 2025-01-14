using System.Security.Cryptography.X509Certificates;

namespace Return_nothing
{
    internal class Program
    {
        public static string Text = "Denne stringen returnerer ingenting...";
        static void Main(string[] args)
        {
            printMsg();
        }

        public static string printMsg()
        {
            return Text;
        }
    }
}