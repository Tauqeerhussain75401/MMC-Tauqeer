using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;

namespace ERP
{
    class clsConnection
    {
        public static string Host = "209.209.40.85";
        static  List<string> IPList = new List<string>();
        
        public static void Con()
        {
            IPList.Add("localhost");
            //IPList.Add("192.168.2.1");
            //IPList.Add("192.168.2.10");

            try
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ToString().Replace("MyIP", IPList[0]).Replace("odb","orcl");
                OpenConnection(connection);
                Host = IPList[0];
            }
            catch 
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ToString().Replace("MyIP", IPList[1]);
                OpenConnection(connection);
                Host = IPList[1];
            }           
        }

        private static void OpenConnection(string connection)
        {
            if (con == null)
                con = new OracleConnection(connection);
            else
            {
                con.Close();
                OracleConnection.ClearPool(con);
                con.ConnectionString = connection;
            }
            con.Open();
        }
        public static OracleConnection con;
    }
}
