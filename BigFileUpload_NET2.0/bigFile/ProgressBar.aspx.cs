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

namespace bigFile
{
    
    public partial class ProgressBar : System.Web.UI.Page
    {
        private double percentage = 0;

        public double Percentage
        {
            get
            {
                return percentage;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_ok.Enabled=false;
            UploadContext upload = UploadContextFactory.GetUploadContext(Request["UploadID"]);
            if (upload.Status != uploadStatus.HasError)
            {
                txt_progressinfo.Text = upload.FormatStatus;
                txt_filename.Text = upload.CurrentFile;
                if (upload.TotalLength > 1)
                {
                    percentage = Convert.ToInt32((upload.Readedlength * 100.0 / upload.TotalLength));
                }
                if (upload.Status == uploadStatus.Initializing)
                {
                    Response.AppendHeader("Refresh", "3");
                }
                else if (upload.Status == uploadStatus.Complete)
                {
                    txt_filename.Text = upload.FileNames.Length.ToString() + " file(s) uploaded successfully!";
                    txt_speed.Text = upload.FormatRatio;
                    txt_leftTime.Text = "上传完成.";

                    btn_ok.Attributes.Add("onclick", "javascript:if(window.dialogArguments==undefined)window.opener=self;window.close();return false;");
                    btn_ok.Enabled = true;
                }
                else
                {
                    txt_speed.Text = upload.FormatRatio;
                    txt_leftTime.Text = upload.FormatLeftTime;
                    Response.AppendHeader("Refresh", "3");
                }
                if (upload.Status == uploadStatus.Complete)
                    btn_cancle.Attributes.Add("onclick", "javascript:if(window.dialogArguments==undefined)window.opener=self;window.close();return false;");
                else
                    btn_cancle.Attributes.Add("onclick", "javascript:var win=null;if(window.dialogArguments==undefined){win=window.opener;}else{win=dialogArguments;}win.document.location.href=win.document.location.href;return true;");
            }
            else
            {
                if (!IsClientScriptBlockRegistered("closeScript"))
                    RegisterClientScriptBlock("closeScript", "<script>window.opener=self;window.close();</script>");
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
        
        }

        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            UploadContext upload = UploadContextFactory.GetUploadContext(Request["UploadID"]);
			upload.Abort = true;
			btn_cancle.Enabled = false;
        }
    }
}
