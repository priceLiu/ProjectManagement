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
using System.Reflection;
using System.Globalization;

namespace bigFile
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {   //Assem
        //    Type RawContent = typeof(System.Web.HttpRawUploadedContent);
            CreateNewHttpPostedFile();
        }
        protected HttpPostedFile CreateNewHttpPostedFile()
        {
            Assembly web = Assembly.GetAssembly(typeof(HttpRequest));
            Type hraw = web.GetType("System.Web.HttpRawUploadedContent");
            object[] argList = new object[2];
            argList[0] = 1;
            argList[1] = 1;
            CultureInfo currCulture = CultureInfo.CurrentCulture;
            object httpRawUploadedContent = Activator.CreateInstance(hraw,
                                                                     BindingFlags.NonPublic | BindingFlags.Instance,
                                                                     null,
                                                                     argList,
                                                                     currCulture,
                                                                     null);

            Type httpInputStreamType = web.GetType("System.Web.HttpInputStream");

            object[] argList1 = new object[3];
            argList1[0] = httpRawUploadedContent;
            argList1[1] = 1;
            argList1[2] = 1;

            object httpInputStream = Activator.CreateInstance(httpInputStreamType,
                                                              BindingFlags.NonPublic | BindingFlags.Instance,
                                                              null,
                                                              argList1,
                                                              currCulture,
                                                              null);

            Type httpPostedFileType = typeof(HttpPostedFile);
            object[] argList2 = new object[3];
            argList2[0] = "FileName.txt";
            argList2[1] = "mimetype";
            argList2[2] = httpInputStream;

            HttpPostedFile httpPostedFile = (HttpPostedFile)Activator.CreateInstance(httpPostedFileType,
                                                                                      BindingFlags.NonPublic | BindingFlags.Instance,
                                                                                      null,
                                                                                      argList2,
                                                                                      currCulture,
                                                                                      null);

            return httpPostedFile;
        }

    }
}
