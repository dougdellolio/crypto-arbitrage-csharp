using System.Threading.Tasks;
using CryptoArbitrageSharp;
using CryptoArbitrageSharp.Calculator;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var client = new ArbitrageClient(new ArbitrageCalculator());
            var task = Task.Run(() => client.Get());
            task.Wait();

            var result = task;
        }
    }
}
