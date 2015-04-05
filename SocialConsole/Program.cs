namespace SocialConsole
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var consoleHandler = new ConsoleHandler();
            consoleHandler.Handle();

            return 0;
        }
    }
}