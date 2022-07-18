using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace GLA_Locker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (Session["uid"] != null && Session["password"] !=null)
            {
                Response.Redirect("Home.aspx");
            }
        }
        protected void btn_sub_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
            string user = uid.Text;
            string pwd = password.Text;
            string conq = ConfigurationManager.ConnectionStrings["MySQLconn"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(conq))
            {
                try
                {
                    connection.Open();
                    string cmdText = "SELECT * FROM login where UID = '" + user + "' && PASSWORD = '" + pwd + "';";
                    MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                    MySqlDataReader res = cmd.ExecuteReader();
                    int n = 0;
                    while (res.Read())
                    {

                        Session["uid"] = res.GetString(0);
                        Session["password"] = res.GetString(1);
                        Session["email"] = res.GetString(2);
                        Session["dis_name"] = res.GetString(3);
                        n++;
                    }
                    if (n > 0)
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Session["uid"] = null;
                        Session["password"] = null;
                        Session["email"] = null;
                        Session["dis_name"] = null;
                        err.Text = "* No Data Found !!";
                    }
                }
                catch (MySqlException ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}