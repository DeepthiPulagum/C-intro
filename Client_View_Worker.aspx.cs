using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;

public partial class Client_View_Worker : System.Web.UI.Page
{
    StringFunctions func = new StringFunctions();
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
        ViewcandidateInTable();
    }
    private void ViewcandidateInTable()
    {
        string sTable = "<tbody>";

        API.Service getWorkers = new API.Service();
        // API.Service getWorkers = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), "", "", Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");


        int CountRows = 1;
        sTable = "";
        string _sBackground = "";
        for (int iResponse = 0; iResponse < Response.Count; iResponse++)
        {

            if (CountRows % 2 >= 1)
            {
                //enableordisable = "";
                _sBackground = "bgcolor='#ECF0F1'";
            }
            else
            {
                // enableordisable = "disabled";
                _sBackground = "";
            }
            string worker_status = Response[iResponse].SelectSingleNode("CANDIDATE_APPROVE").InnerText;
            DateTime candidate_start_date = DateTime.Parse(Response[iResponse].SelectSingleNode("STARTDATE").InnerText);
            DateTime job_start_date = DateTime.Parse(Response[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText);
            DateTime thisday = DateTime.Today;
            if (worker_status == "1" && (candidate_start_date <= thisday) )
            {

                sTable = sTable + "<tr " + _sBackground + ">";
                sTable = sTable + "<td>" + CountRows + "</td>";
                //sTable = sTable + "<td>" + Response[iResponse].SelectSingleNode("ACTIVE").InnerText + " </TD>";
                sTable = sTable + "<td><a href='Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "'>" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "</a> </td> ";
                sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response[iResponse].SelectSingleNode("LASTNAME").InnerText) + "</td> ";
                sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText) + " </td> ";
                sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("LOCATION").InnerText) + " </td> ";
                sTable = sTable + "<td>" + DateTime.Parse(Response[iResponse].SelectSingleNode("STARTDATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                sTable = sTable + "<td>" + DateTime.Parse(Response[iResponse].SelectSingleNode("ENDDATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";

                sTable = sTable + "</tr>";
                CountRows++;
            }
        }
        sTable = sTable + "</tbody>";
        getWorkers.Dispose();
        lblTableData.Text = sTable;
    }
}