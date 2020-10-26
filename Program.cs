using System;

namespace Shiro_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Bot();

            client.RunAsync().GetAwaiter().GetResult();
        }
    }
}
