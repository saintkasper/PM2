using System;
using System.Collections.Generic;
using System.Text;

namespace Demo130423.Assets.Classes
{
    internal class Connection
    {
        public static MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; uid = root; pwd = 251436; database = trade");
    }
}
