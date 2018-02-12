namespace Globo.Common
{
    public static class StringExtensions
    {
        public static bool NullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}