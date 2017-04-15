using System;
using System.Xml;

public partial class Client_View_Jobs : System.Web.UI.Page
{
    StringFunctions func = new StringFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
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

            sTable = sTable + "<tr " + _sBackground + ">";
            sTable = sTable + "<td>" + CountRows + "</td>";

            if (Response[intCount].SelectSingleNode("URGENT").InnerText == "1")
            {
                sTable = sTable + "<td style=color:red><blink>" + "Urgent" + "</blink> </td> ";
                sTable = sTable + "<td style=color:red><a style=color:red href='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "'>" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "</td>";
                sTable = sTable + "<td style=color:red>" + func.FixString(Server.HtmlDecode(Response[intCount].SelectSingleNode("JOB_TITLE").InnerText)) + "</td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("JOB_LOCATION").InnerText.Replace(",Canada", "") + " </td> ";
                sTable = sTable + "<td style=color:red>" + DateTime.Parse(Response[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                sTable = sTable + "<td style=color:red>" + DateTime.Parse(Response[intCount].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("NO_OF_OPENINGS").InnerText + " </td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("HIRED").InnerText + " </td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("AVAILABLE_JOBS").InnerText + " </td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("RECENT").InnerText + " day(s)</td> ";
                sTable = sTable + "<td style=color:red>" + Response[intCount].SelectSingleNode("USERNAME").InnerText + " </td> ";
                sTable = sTable + "</tr>";
            }
            else
            {
                
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("JOB_STATUS").InnerText + "</td>";
                sTable = sTable + "<td><a href='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "'>" + Response[intCount].SelectSingleNode("JOB_ALIAS").InnerText + "</td>";
                sTable = sTable + "<td>" + Server.HtmlDecode(Response[intCount].SelectSingleNode("JOB_TITLE").InnerText) + "</td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("JOB_LOCATION").InnerText.Replace(",Canada", "") + " </td> ";
                sTable = sTable + "<td>" + DateTime.Parse(Response[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                sTable = sTable + "<td>" + DateTime.Parse(Response[intCount].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("NO_OF_OPENINGS").InnerText + " </td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("HIRED").InnerText + " </td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("AVAILABLE_JOBS").InnerText + " </td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("RECENT").InnerText + " day(s)</td> ";
                sTable = sTable + "<td>" + Response[intCount].SelectSingleNode("USERNAME").InnerText + " </td> ";
                sTable = sTable + "</tr>";


            }
            CountRows++;


        }

        sTable = sTable + "</tbody>";
        jobInfo.Dispose();
        lblTableData.Text = sTable;



    }
}