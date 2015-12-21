namespace WhatsHoppening.Extensions
{
    public static class Extensions
    {
        public static string FormatWith(this string text, params object[] args)
        {
            return string.Format(text, args);
        }
    }
}
