using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ERP
{
    class clsConnection
    {
        public static string Host = "209.209.40.85";
        static  List<string> IPList = new List<string>();
        public static Microsoft.Data.SqlClient.SqlConnection sqlcon;
        
        public static void Con()
        {
            IPList.Add("localhost");
            //IPList.Add("192.168.2.1");
            //IPList.Add("192.168.2.10");

            try
            {
                string s = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ToString();
                //string connection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ToString().Replace("MyIP", IPList[0]).Replace("odb","orcl");
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ToString().Replace("localhost", IPList[0]);
                OpenConnection(connection);
                Host = IPList[0];
            }
            catch 
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ToString().Replace("MyIP", IPList[0]);
                OpenConnection(connection);
                Host = IPList[0];
            }           
        }
        #region Worked by Usman (micro sql connection)
        public static bool sqlCon()
        {
            try
            {
                if (sqlcon == null)
                {
                    sqlcon = new Microsoft.Data.SqlClient.SqlConnection(@"Server=192.168.2.110\SQLServerAuthentication;Database=LIMS;User Id=MMCHBB;Password=Nubit@101171;TrustServerCertificate=True;");
                }
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
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
