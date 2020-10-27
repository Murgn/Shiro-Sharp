using System;

namespace Shiro_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();

            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
