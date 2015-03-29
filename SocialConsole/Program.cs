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
                Console.Write("> ");
                var input = Console.ReadLine();

                var response = MessageHandler.Process(input);

                foreach (var item in response)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
