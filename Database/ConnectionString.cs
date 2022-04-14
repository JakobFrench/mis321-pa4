namespace PA3.Database
{
    internal class ConnectionString
    {
        public string cs {get; set;}
        public ConnectionString()
        {
            string server = "nnsgluut5mye50or.cbetxkdyhwsb.us-east-1.rds.amazonaws.com	";
            string database = "z94yz6cl2ijkifwr";
            string port = "3306";
            string username = "on9fon07u7mcdpx6";
            string password = "tspu7vrn08v4y578";

            cs = $@"server={server};username={username};database={database};port={port};password={password};";
        }
    }
}