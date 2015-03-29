using System;
using System.Data.Odbc;

namespace SocialConsole
{
    public class Program
    {
        private static readonly MessageHandler MessageHandler = new MessageHandler();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("> ");
                var input = Console.ReadLine();

                MessageHandler.Process(input);
            }
        }
    }
}
