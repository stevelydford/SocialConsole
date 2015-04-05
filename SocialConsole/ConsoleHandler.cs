using System;

namespace SocialConsole
{
    public class ConsoleHandler
    {
        private static readonly MessageHandler MessageHandler = new MessageHandler(new UserRepository());

        public int Handle()
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            while (input != "exit")
            {
                var response = MessageHandler.Process(input);

                foreach (var item in response)
                {
                    Console.WriteLine(item);
                }

                Console.Write("> ");
                input = Console.ReadLine();
            }

            return 0;
        }
    }
}