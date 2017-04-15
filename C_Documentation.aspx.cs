using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class C_Documentation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //check if file has been request for download and then decode URL
        if (Request["sFile"] != null)
        {
            Response.Redirect("http://API:2614/Documentation/Client/" + Server.UrlDecode(Request["sFile"]));
            Response.End();
        }
        string[] filePaths = Directory.GetFiles(Server.MapPath("//Documentation//Client//"));

        string sLine = "";
        sLine = "<tbody id='responsive-table-body'>";
        for (int i = 0; i < filePaths.Length; i++)
        {
            //string a = "";
            //filePaths[i].ToString()
            //filePaths[i].ToString()
            //
            //filePaths[i].ToString().EndsWith(".docx")
            string type_of_file = Path.GetExtension(filePaths[i].ToString());
            sLine = sLine + "<tr>";
            sLine = sLine + "<td>" + File.GetCreationTime(filePaths[i].ToString()) + " </td>";
            sLine = sLine + "<td>" + Path.GetFileName(filePaths[i].ToString()) + "</td>";
            if (type_of_file.ToLower() == ".txt")
            {
                sLine = sLine + "<td class='text-subhead text-primary margin-none'>Text</td>";
            }
            else
                if (type_of_file.ToLower() == ".docx")
            {
                sLine = sLine + "<td class='text-subhead text-primary margin-none'>Word</td>";
            }
            else
                if (type_of_file.ToLower() == ".pdf")
            {
                sLine = sLine + "<td class='text-subhead text-primary margin-none'>PDF </td>";
            }
            else
                if (type_of_file.ToLower() == ".xlsx")
            {
                sLine = sLine + "<td class='text-subhead text-primary margin-none'>Excel</td>";
            }
            else
                if (type_of_file.ToLower() == ".pptx")
            {
                sLine = sLine + "<td class='text-subhead text-primary margin-none'>Power Point</td>";
            }
            else
                if (type_of_file.ToLower() == ".zip")
            {
                sLine = sLine + "<td class='text-subhead text-primary margin-none'>ZIP</td>";
            }
            else
            {
                sLine = sLine + "<td class='text-subhead text-primary margin-none'>OTHER</td>";
            }
            sLine = sLine + "<td class='text-subhead text-primary margin-none'><a href=C_Documentation.aspx?sFile=" + Server.UrlEncode(Path.GetFileName(filePaths[i].ToString())) + ">Download</a></td>";
            sLine = sLine + "</tr>";

        }
        sLine = sLine + "</tbody>";
        lblFileDocument.Text = sLine;


    }
}