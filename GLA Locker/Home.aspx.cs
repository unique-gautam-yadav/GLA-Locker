using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GLA_Locker
{
    public partial class Home : System.Web.UI.Page
    {
        string dis_name, email, uid, path;
        double size;
        string[] filePaths;
        protected void search(object sender, EventArgs e)
        {
            string keyword = itm.Text;
            if (keyword != null && keyword.Length > 0 && keyword != "")
            {
                //
            }
        }
        protected void logout(object sender, EventArgs e)
        {
            Session["uid"] = null;
            Session["password"] = null;
            Session["email"] = null;
            Session["dis_name"] = null;
            Response.Redirect("Login.aspx");
        }
        protected void delete (object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gv.RowIndex;
            string path = filePaths[index];
            File.Delete(path);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void download (object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gv.RowIndex;
            string path = filePaths[index];
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=file"+(index+1));
            Response.WriteFile(path);
            Response.End();
        }

        protected void upload(object sender, EventArgs e)
        {
            if (size < 100)
            {
                string file = in_file.PostedFile.FileName.ToString();
                if (file != null && file != "")
                {
                    in_file.PostedFile.SaveAs(path + @"\" + file);
                    Response.Redirect(Request.Url.AbsoluteUri);
                }

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null || Session["password"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                uid = Session["uid"].ToString();
                dis_name = Session["dis_name"].ToString();
                email = Session["email"].ToString();
                disp_name.Text = dis_name;
                mail.Text = email;
                path = @"D:\GlaLocker\" + uid;
                if (!(Directory.Exists(path)))
                {
                    Directory.CreateDirectory(path);
                }
                size = GetDirSize(path) / 1024;
                double t = size * 1024;
                size = size / 20 * 100;
                size = Math.Round(size, 2);
                percent.Text = size + "%";
                if (t < 1024)
                {
                    t = Math.Round(t, 2);
                    storage.Text = t + " MB ";
                }
                else
                {
                    t = t / 1024;
                    t = Math.Round(t, 2);
                    storage.Text = t + " GB ";
                }
                filePaths = Directory.GetFiles(path);
                List<ListItem> files = new List<ListItem>();
                foreach (string file in filePaths)
                {
                    files.Add(new ListItem(Path.GetFileName(file), file));
                }
                _cont_files.DataSource= files;
                _cont_files.DataBind();

            }
        }
        private double GetDirSize(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            long size = 0;
            foreach (string file in Directory.GetFiles(path))
            {
                size += new FileInfo(file).Length;
            }
            return Math.Round((double)size / (double)(1024 * 1024), 2);
        }
    }
}