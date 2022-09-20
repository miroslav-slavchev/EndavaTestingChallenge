namespace EndavaTestingChallenge.Library.SwagLabs.InventoryPage
{
    public class InventoryPrice
    {

        public InventoryPrice(string text)
        {
            PriceFulltext = text;
            CurrencySymbol = text[0].ToString();
            PriceFulltext = text[1..];
        }

        public string CurrencySymbol { get; }

        public double Price { get; }

        public string PriceFulltext { get; }
    }
}
