namespace WebServer.Web.Services
{
    public static class Extensions
    {
        public static string GetKey(this string register)
        {
            return register.Split(':')[0];
        }

        public static string GetValue(this string register)
        {
            return register.Split(':')[1];
        }
    }
}
