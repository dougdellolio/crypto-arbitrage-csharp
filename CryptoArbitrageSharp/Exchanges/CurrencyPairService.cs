using System;
using System.Collections.Generic;
using System.Linq;
using CryptoArbitrageSharp.Exchanges.Binance;

namespace CryptoArbitrageSharp.Exchanges
{
    public class CurrencyPairService : ICurrencyPairService
    {
        private readonly Dictionary<Exchange, (CurrencyPair currencyPair, string currencyPairString)[]> currencyPairs;

        public CurrencyPairService()
        {
            currencyPairs = new Dictionary<Exchange, (CurrencyPair currencyPair, string currencyPairString)[]>
            {
                { Exchange.Binance, new []
                    {
                        (CurrencyPair.LtcBtc, "LTCBTC")
                    }
                },
                { Exchange.Bitfinex, new []
                    {
                        (CurrencyPair.LtcBtc, "ltcbtc")
                    }
                },
                { Exchange.Bitstamp, new []
                    {
                        (CurrencyPair.LtcBtc, "ltcbtc")
                    }
                },
                { Exchange.Bittrex, new []
                    {
                        (CurrencyPair.LtcBtc, "BTC-LTC")
                    }
                },
                { Exchange.CoinExchange, new []
                    {
                        (CurrencyPair.LtcBtc, "18")
                    }
                },
                { Exchange.Gdax, new []
                    {
                        (CurrencyPair.LtcBtc, "LTC-BTC")
                    }
                },
                { Exchange.Kraken, new []
                    {
                        (CurrencyPair.LtcBtc, "XLTCXXBT")
                    }
                },
                { Exchange.Poloniex, new []
                    {
                        (CurrencyPair.LtcBtc, "BTC_LTC")
                    }
                }
            };
        }

        public string GetCurrencyPair(Exchange exchange, CurrencyPair currencyPair)
        {
            if (!currencyPairs.TryGetValue(exchange, out var value))
            {
                throw new ArgumentException($"No currency pair mapping exists for {currencyPair} on {nameof(BinanceExchange)}");
            }

            return value.Single(p => p.currencyPair == currencyPair).currencyPairString;
        }
    }
}
