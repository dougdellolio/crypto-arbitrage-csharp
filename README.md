# Crypto Arbitrage

Detects arbitrage opportunities across cryptocurrency exchanges

Supported Exchanges:

- Binance
- Bitfinex
- Bitstamp
- Bittrex
- CoinExchange
- GDAX
- Kraken
- Poloniex

Supported Currency Pairs:

- LTC/BTC

###### Example: ######

````
var client = new ArbitrageClient(new ArbitrageCalculator());
var task = Task.Run(() => client.Get(CurrencyPair.LtcBtc));
task.Wait();

Console.WriteLine($"Lowest bid on {task.Result.bestBid.Exchange} @ {task.Result.bestBid.BestBid}");
Console.WriteLine($"Highest ask on {task.Result.bestAsk.Exchange} @ {task.Result.bestAsk.BestAsk}");
Console.ReadKey();
````