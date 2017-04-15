using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class C_View_Worker : System.Web.UI.Page
{
    StringFunctions func = new StringFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Page.IsPostBack)
        //{
        //    btnsbmit.CausesValidation = false;
        //}

        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=You+have+logged+out");
            Response.End();
        }
        // pop1.Visible = false;
        ViewworkerInTable();
    }
    private void ViewworkerInTable()
    {
       

        string sTable = "<tbody>";

        API.Service getWorkers = new API.Service();
        // API.Service getWorkers = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.get_worker(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");


        int CountRows = 1;
        sTable = "";
        string _sBackground = "";
        for (int iResponse = 0; iResponse < Response.Count; iResponse++)
        {

            if (iResponse % 2 >= 1)
            {
                //enableordisable = "";
                _sBackground = "bgcolor='#ECF0F1'";
            }
            else
            {
                // enableordisable = "disabled";
                _sBackground = "";
            }


            sTable = sTable + "<tr " + _sBackground + ">";
            sTable = sTable + "<td>" + CountRows + "</td>";
            //sTable = sTable + "<td>" + Response[iResponse].SelectSingleNode("ACTIVE").InnerText + " </TD>";
            sTable = sTable + "<td><a href='Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + Response[iResponse].SelectSingleNode("EMPLOYEE_FULL_ID").InnerText + "'>" + Response[iResponse].SelectSingleNode("EMPLOYEE_FULL_ID").InnerText + "</a> </td> ";
            sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response[iResponse].SelectSingleNode("LASTNAME").InnerText) + "</td> ";
            sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText) + " </td> ";
            sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("LOCATION").InnerText) + " </td> ";
            sTable = sTable + "<td>" + DateTime.Parse(Response[iResponse].SelectSingleNode("START_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
            sTable = sTable + "<td>" + DateTime.Parse(Response[iResponse].SelectSingleNode("END_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";

            sTable = sTable + "</tr>";
            CountRows++;
        }
        sTable = sTable + "</tbody>";
        getWorkers.Dispose();
        lblTableData.Text = sTable;
    }
}