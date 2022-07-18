using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace GLA_Locker
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string[] filePaths = Directory.GetFiles(@"D:\");
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            GridView1.DataSource = files;
            GridView1.DataBind();

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string file = Path.GetFileName(input.PostedFile.FileName);
            input.PostedFile.SaveAs(@"D:\Locc\" + file);
            Response.Write("Doing!!");
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}