namespace rakoona.services.Config.Helpers
{
    internal static class StringExtended
    {
        public static bool IsStringEmpty(this string request)
        {
            request = request.Replace(" ", String.Empty);
            return request == null || request == "" ? true : false;
        }

        public static int ToNumber(this string request)
        {
            int value = Int32.Parse(request);
            return value;
        }
    }
}
