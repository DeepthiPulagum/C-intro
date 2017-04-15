using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class C_View_Interview : System.Web.UI.Page
{
    private int iresponse;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=You+have+logged+out");
            Response.End();
        }
        // pop1.Visible = false;
        ViewinterviewInTable();
    }
    private void ViewinterviewInTable()
    {
        string sTable = "<tbody>";
        API.Service jobInfo = new API.Service();
        XmlDocument xmldoc = new XmlDocument();

        XmlDocument empcomment = new XmlDocument();
        API.Service getWorkers = new API.Service();

        DateTime datetoday = System.DateTime.Now;
        //xmldoc.LoadXml("<XML>" + jobInfo.get_JobView("srinivas.gadde@pamten.ca", "ferivan", "2", "", "", "", "", "", "", "").InnerXml + "</XML>");
        xmldoc.LoadXml("<XML>" + jobInfo.get_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["ClientID"].ToString(), datetoday.ToString()).InnerXml + "</XML>");
        XmlNodeList Response = xmldoc.SelectNodes("XML/RESPONSE/INTERVIEW ");
        sTable = "";
        int CountRows = 1;

        string _sBackground = "";
        for (int intCount = 0; intCount < Response.Count; intCount++)
        {

            //if (intCount % 2 >= 1)
            //{
            //    //enableordisable = "";
            //    _sBackground = "bgcolor='#ECF0F1'";
            //}
            //else
            //{
            //    // enableordisable = "disabled";
            //    _sBackground = "";
            //}

           

                string iDate = Response[intCount].SelectSingleNode("INTERVIEW_DATE").InnerText;
            if (iDate != string.Empty)
            {
                iDate = DateTime.Parse(Response[intCount].SelectSingleNode("INTERVIEW_DATE").InnerText).ToString("dd MMM, yyyy");
            }
            else
            {
                iDate = "N/A";
            }
            string check_status = Response[intCount].SelectSingleNode("STATUS").InnerText;
            if (check_status != "Rejected by Client" && check_status != "Rejected by Vendor")
            {
                string empid = Response[intCount].SelectSingleNode("EMP_ID").InnerText;
                string empid2 = Response[intCount].SelectSingleNode("EMP_ID").InnerText.Substring((empid).Length - 5);
                string comment = "";
                empcomment.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), empid2, Session["VendorID"].ToString(), Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
                XmlNodeList commentsemp = empcomment.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                try
                {
                    comment = commentsemp[iresponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                }
                catch
                {
                    comment = "";
                }
                    if (comment == "" || comment == null)
                    comment = "No comments given";
                sTable = sTable + "<tr " + _sBackground + ">";
                sTable = sTable + "<td>" + CountRows + "</td>";
                
                sTable = sTable + "<td><a href='Client_View_Worker_detail.aspx?&empID=" + Response[intCount].SelectSingleNode("EMP_ID").InnerText + "'>" + Response[intCount].SelectSingleNode("EMP_ID").InnerText + "</td>";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("CANDIDATE_NAME").InnerText + "</td> ";
                sTable = sTable + "<td>" + Server.HtmlDecode(Response[intCount].SelectSingleNode("JOB_TITLE").InnerText) + " </td> ";
                //sTable = sTable + "<td>" + DateTime.Parse(Response[intCount].SelectSingleNode("INTERVIEW_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                sTable = sTable + "<td align='center'>" + iDate + " </td> ";
                sTable = sTable + "<td align='center'>" + Response[intCount].SelectSingleNode("INTERVIEW_START_TIME").InnerText + "</td>";
                sTable = sTable + "<td align='center'>" + Response[intCount].SelectSingleNode("INTERVIEW_END_TIME").InnerText + "</td>";

                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("INTERVIEWER").InnerText + "</td>";
                sTable = sTable + "<td>" + comment + "</td>";
                sTable = sTable + "</tr>";
                CountRows++;
            }
        }

        sTable = sTable + "</tbody>";
        jobInfo.Dispose();
        lblTableData.Text = sTable;



    }

}