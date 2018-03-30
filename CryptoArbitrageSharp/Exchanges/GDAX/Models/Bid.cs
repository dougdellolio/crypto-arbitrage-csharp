namespace CryptoArbitrageSharp.Exchanges.GDAX.Models
{
    public class Bid : Quote
    {
        public Bid(
            decimal price,
            decimal size)
                : base(price, size)
        {
        }
    }
}
