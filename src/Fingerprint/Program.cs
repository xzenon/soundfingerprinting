using System;
using System.Threading.Tasks;

namespace Fingerprint
{
    class Program
    {

        static async Task Main(string[] args)
        {
            FingerprintTasks tasks = new FingerprintTasks();
            await tasks.StoreForLaterRetrieval(args[0]);

            Console.WriteLine("File: " + args[0]);
        }
    }
}