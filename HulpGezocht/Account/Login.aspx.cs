using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace HulpGezocht.Account
{
    public partial class Login : Page
    {
        static string connectionstring = "Data Source=localhost; User Id=twan; password=ytcazk";
        OracleConnection connection;
        OracleCommand cmd = new OracleCommand();
        OracleDataReader reader;
        string query = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
        }

        protected void LogIn(object sender, EventArgs e)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetQuestionz";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.BindByName = true;

                try 
                {
                    connection.Open();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_email", "dep");
                    
                    
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    string bert = reader.GetValue(3).ToString();

                               
                }
                catch (Exception ex)
                {
                    
                }
            }

        }
    }
}