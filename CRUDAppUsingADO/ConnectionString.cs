namespace CRUDAppUsingADO
{
    public static class ConnectionString
    {
        //Create a private connection string variables :-cs
        private static string cs = "Server = ; Database = ; Trusted_Connection = True; TrustServerCertificate=True;";

        // create a string for get the private connection...
        public static string dbcs { get => cs; }
    }
}
