namespace ShopCoffee.Helper
{
    public static class Utils
    {
        public static string ToVnd(this long value)
        {
            return value.ToString("N0") + "₫";
        }
    }
}
