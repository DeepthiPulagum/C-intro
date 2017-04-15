using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class C_JobGrid : System.Web.UI.Page
{
    StringFunctions func = new StringFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            Response.Write("An Error has occured, please log in again");
            Response.End();
        }

        //API.Service web = new API.Service();

        //// XmlDocument _xmlWorkers = new XmlDocument();

        ////Create XML Stuff
        //XmlDocument _xmlDoc = new XmlDocument();
        //_xmlDoc.LoadXml("<XML>" + web.get_Recent_jobs(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["UserTypeID"].ToString(), Session["UserID"].ToString(), Session["VendorID"].ToString()).InnerXml + "</XML>");
        //XmlNodeList nodeList = _xmlDoc.SelectNodes("XML/RESPONSE/JOB_ID");
        //// nodeList = _xmlDoc.SelectNodes("XML/RESPONSE/JOB_ID");
        //string sTablejob = "<tbody>";
        //int CountRowsjob = 1;
        //int intCountjobs = 0;

        //for (intCountjobs = 0; intCountjobs < nodeList.Count; intCountjobs++)
        //{
        //    sTablejob = sTablejob + "<tr>";
        //    sTablejob = sTablejob + "<td> " + nodeList[intCountjobs].SelectSingleNode("JOB_ALIAS").InnerText + " </td>";
        //    sTablejob = sTablejob + "<td>" + func.FixString(nodeList[intCountjobs].SelectSingleNode("JOB_TITLE").InnerText) + "</td>";
        //    sTablejob = sTablejob + "<td>" + nodeList[intCountjobs].SelectSingleNode("NO_OF_OPENINGS").InnerText + "</td>";
        //    sTablejob = sTablejob + "<td>" + func.FixString(nodeList[intCountjobs].SelectSingleNode("LOCATION").InnerText) + "</td>";
        //    sTablejob = sTablejob + "<td>" + nodeList[intCountjobs].SelectSingleNode("DATE_CREATED").InnerText + "</td>";
        //    sTablejob = sTablejob + "</tr>";
        //    CountRowsjob++;
        //}
        //if (nodeList.Count == 0)
        //{
        //    sTablejob = sTablejob + "<td colspan=4>" + "There are no Job Added at this time." + "</td> ";
        //    sTablejob = sTablejob + "</tr>";
        //}
        //sTablejob = sTablejob + "</tbody>";
        //web.Dispose();
        //lblshowrecentlyadded.Text = sTablejob;

        ViewJobsInTable();
    }
    private void ViewJobsInTable()
    {
        string sTable = "<tbody>";
        API.Service jobInfo = new API.Service();
        XmlDocument xmldoc = new XmlDocument();

        //xmldoc.LoadXml("<XML>" + jobInfo.get_JobView("srinivas.gadde@pamten.ca", "ferivan", "2", "", "", "", "", "", "", "").InnerXml + "</XML>");
        xmldoc.LoadXml("<XML>" + jobInfo.get_Jobs("", Session["Email"].ToString(), Session["P@ss"].ToString(), "", Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response = xmldoc.SelectNodes("XML/RESPONSE/JOBS ");
        sTable = "";
        int CountRows = 1;

        string _sBackground = "";
        for (int intCount = 0; intCount < Response.Count; intCount++)
        {
            //wrap text for title
            string original_jobtitle = Response[intCount].SelectSingleNode("JOB_TITLE").InnerText;

            string job_title = "";
            if (original_jobtitle.Length > 10)
            {
                job_title = original_jobtitle.Substring(0, original_jobtitle.Length);
            }
            else
            {
                job_title = original_jobtitle;
            }

            string urgent_job = Response[intCount].SelectSingleNode("URGENT").InnerText;
            if (intCount % 2 >= 1)
            {
                //enableordisable = "";
                _sBackground = "bgcolor='#ECF0F1'";
            }
            else
            {
                // enableordisable = "disabled";
                _sBackground = "";
            }

            if (urgent_job == "1")
            {
                sTable = sTable + "<tr " + _sBackground + ">";
                sTable = sTable + "<td style=color:red><blink>" + "Urgent" + "</blink> </td> ";
                sTable = sTable + "<td style=color:red><a target='_blank' style=color:red href='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "'>" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "</td>";
                //sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("JOB_TITLE").InnerText.ToString() + "</td> ";
                sTable = sTable + "<td style=color:red>" + func.FixString(job_title) + "</td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("JOB_LOCATION").InnerText.Replace(",Canada", "") + " </td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("NO_OF_OPENINGS").InnerText + " </td> ";
               // sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("RECENT").InnerText + " day(s)</td> ";
                sTable = sTable + "<td style=color:red>" + DateTime.Parse(Response[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
            }
            else

            {

                sTable = sTable + "<tr " + _sBackground + ">";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("JOB_STATUS").InnerText + " </td> ";

                sTable = sTable + "<td><a  target='_blank' href='Job_Details.aspx?jopen=Y&p=JV&jobID=" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "'>" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "</td>";
                //sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("JOB_TITLE").InnerText.ToString() + "</td> ";
                sTable = sTable + "<td>" + func.FixString(job_title) + "</td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("JOB_LOCATION").InnerText.Replace(",Canada", "") + " </td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("NO_OF_OPENINGS").InnerText + " </td> ";
               // sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("RECENT").InnerText + " day(s)</td> ";
                sTable = sTable + "<td>" + DateTime.Parse(Response[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";

                sTable = sTable + "</tr>";
                CountRows++;
            }
            //closes
            sTable = sTable + "</tbody>";
            jobInfo.Dispose();
            lblTableData.Text = sTable;

        }
    }
}