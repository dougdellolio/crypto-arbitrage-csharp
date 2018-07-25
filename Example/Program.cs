using System;
using System.Threading.Tasks;
using CryptoArbitrageSharp;
using CryptoArbitrageSharp.Calculator;
using CryptoArbitrageSharp.Exchanges;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var client = new ArbitrageClient(new ArbitrageCalculator());
            var task = Task.Run(() => client.Get(CurrencyPair.LtcBtc));
            task.Wait();

            Console.WriteLine($"Lowest bid on {task.Result.bestBid.Exchange} @ {task.Result.bestBid.BestBid}");
            Console.WriteLine($"Highest ask on {task.Result.bestAsk.Exchange} @ {task.Result.bestAsk.BestAsk}");
            Console.ReadKey();
        }
    }
}
