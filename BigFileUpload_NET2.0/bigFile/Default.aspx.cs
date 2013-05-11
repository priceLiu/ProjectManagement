using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpSoft;
using System.IO;

namespace bigFile
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UploadContext context = UploadContextFactory.InitUploadContext(this, @"c:\myupload\");
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UploadContext context = UploadContextFactory.GetUploadContext();
            if ((context != null) && (context.Status == uploadStatus.Complete))
            {
                context.SaveFile(file1.ClientID, Request.MapPath("/myupload/"));
            }
            //this.file1.PostedFile.SaveAs(Path.Combine(Request.MapPath("/myupload/"), Path.GetFileName(this.file1.PostedFile.FileName)));
        }
    }
}
