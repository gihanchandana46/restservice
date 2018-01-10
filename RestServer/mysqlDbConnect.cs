using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServer
{
    public class mysqlDbConnect
    {

        public static MySqlConnection GetConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myconnectionString;

            myconnectionString = "server=127.0.0.1;uid=root;pwd=123456789;database=restaurant";
         
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myconnectionString;
                conn.Open();
                return conn;  
            
           
        }
    }
}