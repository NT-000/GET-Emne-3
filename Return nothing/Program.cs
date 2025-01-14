using System.Security.Cryptography.X509Certificates;

namespace Return_nothing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            printMsg();
        }

        public static void printMsg()
        {
            Console.WriteLine("Denne metoden returnerer ingenting");
        }
    }
}
