using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Xml;

public partial class Client : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        string sTable = "";
        //get timesheet
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=You+have+logged+out");
            Response.End();
        }
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

        API.Service jobInfo2 = new API.Service();
        XmlDocument xmldoc11 = new XmlDocument();

        string sTable9 = "<tbody>";
        xmldoc11.LoadXml("<XML>" + jobInfo2.get_name_leave_request(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), "", "", Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response9 = xmldoc11.SelectNodes("XML/RESPONSE/NAME");
        sTable9 = "";
        int CountRows9 = 1;
        int intCount9 = 0;

        for (intCount9 = 0; intCount9 < Response9.Count; intCount9++)
        {
            DateTime requestdate = DateTime.Parse(Response9[intCount9].SelectSingleNode("REQUESTED_DATE").InnerText);
            if (isMoreThanToday(DateTime.Today.Date, requestdate))
            {
                string original = Response9[intCount9].SelectSingleNode("REQUESTED_REASON").InnerText;
                //first option
                string test = original.Substring(0, 4);
                //string reason = Response9[intCount9].SelectSingleNode("REQUESTED_REASON").InnerText;
                //string subreson = reason.Substring(reason.Length -5);
                //0,10
                sTable9 = sTable9 + "<tr>";
                sTable9 = sTable9 + "<td>" + func.FixString(Response9[intCount9].SelectSingleNode("FIRST_NAME").InnerText + " " + Response9[intCount9].SelectSingleNode("LAST_NAME").InnerText) + "</td>";
                sTable9 = sTable9 + "<td>" + DateTime.Parse(Response9[intCount9].SelectSingleNode("REQUESTED_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                sTable9 = sTable9 + "<td><a href = '#'  data-toggle='tooltip' data-placement='top' name='abc'  title='" + original + "'>" + test + "..."+" </a></td>";
                //  sTable9 = sTable9 + "<td>" + func.FixString(Response9[intCount9].SelectSingleNode("REQUESTED_REASON").InnerText) + " </td> ";
                sTable9 = sTable9 + "<td><a href='#' class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc'  title='" + func.FixString(Response9[intCount9].SelectSingleNode("REQUESTED_COMMENTS").InnerText) + "'><i class='fa fa-info-circle'></i></a>&nbsp;</td> ";
                string status = Response9[intCount9].SelectSingleNode("ACTION").InnerText;
                if (status == "2")
                {
                    sTable9 = sTable9 + "<td> Not approved</td>";
                    // sTable9 = sTable9 + "<td>Absence Request Not approved</td>";
                }
                if (status == "1")
                {
                    sTable9 = sTable9 + "<td> Approved</td>";
                    // sTable9 = sTable9 + "<td>Absence Request Not approved</td>";
                }
                if (status == "0")
                {
                    sTable9 = sTable9 + "<td> Rejected</td>";
                    // sTable9 = sTable9 + "<td>Absence Request Not approved</td>";
                }
                sTable9 = sTable9 + "</tr>";
                CountRows9++;
            }
        }

        if (Response9.Count == 0)
        {
            sTable9 = sTable9 + "<td colspan=4>" + "There are no Absence Requests at this time." + "</td> ";
            sTable9 = sTable9 + "</tr>";
        }
        sTable9 = sTable9 + "</tbody>";
        jobInfo2.Dispose();
        lblrequestleave.Text = sTable9;

        if (Request.QueryString["action"] != null)
        {
            //timesheet popup modal action text
            lblAction.Text = "Timesheet Action (Approve)";
            if (Request.QueryString["mess"] != null)
            {
                int DollarTextposition = Request.QueryString["mess"].ToString().Replace("(", "<br>(").IndexOf("for $");
                //Request.QueryString["mess"].ToString().Replace("(", "<br>(").Substring(0, DollarTextposition) + " for " + Request.QueryString["time"].ToString().Replace("(", "<br>(") + " hours";
                //lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " the timesheet for <br>" + Request.QueryString["mess"].ToString().Replace("(", "<br>(");
                lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " the timesheet for <br>"  + Request.QueryString["mess"].ToString().Replace("(", " <br>  ").Substring(0, DollarTextposition) + " for " + Request.QueryString["time"].ToString().Replace("(", " < br > (") + " hours";
            }
        }
        if (Request.QueryString["action2"] != null)
        {
            lblaction2.Text = " Timesheet Action (Reject)";
            int DollarTextposition2 = Request.QueryString["mess"].ToString().Replace("(", "<br>(").IndexOf("for $");
            //Request.QueryString["mess"].ToString().Replace("(", "<br>(").Substring(0, DollarTextposition) + " for " + Request.QueryString["time"].ToString().Replace("(", "<br>(") + " hours";
            //lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " the timesheet for <br>" + Request.QueryString["mess"].ToString().Replace("(", "<br>(");
            lblActionTimeSheet2.Text = "Are you sure you want to " + Request.QueryString["action2"] + " the timesheet for <br>" + Request.QueryString["mess"].ToString().Replace("(", " <br>  ").Substring(0, DollarTextposition2) + " for " + Request.QueryString["time"].ToString().Replace("(", " < br > (") + " hours";


            //lblaction2.Text = "Timesheet Action";
            //lblActionTimeSheet2.Text = "Are you sure you want to " + Request.QueryString["action2"] + " this timesheet<br>" + Request.QueryString["mess"].ToString().Replace("(", "<br>(");

        }
        //show timesheets needed to be approved
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetTimeSheettobeApproved = " select timesheet_status_id, timesheet_id_from, timesheet_status, weeknum, employee_id, first_name, last_name, pay_rate,job_id,JobManager_ID, " +
                                                    " (select  top 1 CONCAT(month, '-', day, '-', year) from ovms_timesheet  where employee_id = employee_id and DatePart(week, dateadd(d,-1,CONCAT(month, '-', day, '-', year))) = weeknum) as date_from, " +
                                                    " (select sum(a.hours) as hours_total from ovms_timesheet a, ovms_timesheet_details b where a.employee_id = employee_id and a.timesheet_id = b.timesheet_id and a.active = 1 and b.active = 1 and b.timesheet_status_id = 3 and DatePart(week, dateadd(d, -1, CONCAT(a.month, '-', a.day, '-', a.year))) = weeknum) as hours_reported, " +
                                                    " (select  top 1 dateadd(d,6,CONCAT(month, '-', day, '-', year)) from ovms_timesheet  where employee_id = employee_id and DatePart(week, dateadd(d,-1,CONCAT(month, '-', day, '-', year))) = weeknum) as date_to " +
                                                    " from (select distinct ts.timesheet_status_id, " +
                                                    " ts.timesheet_status, e.job_id, " +
                                                    " (select user_id from ovms_jobs where job_id = e.job_id) as JobManager_ID, " +
                                                    " DatePart(week, dateadd(d,-1,CONCAT(month, '-', day, '-', year))) as weeknum, " +
                                                    " (select top 1 a.timesheet_id from ovms_timesheet a, ovms_timesheet_details b where a.timesheet_id = b.timesheet_id and a.employee_id =e.employee_id and a.active = 1 and b.active = 1 and b.timesheet_status_id=3) as timesheet_id_from,	 " +
                                                    " e.employee_id, " +
                                                    " dbo.CamelCase(ed.first_name) as first_name, " +
                                                    " dbo.CamelCase(ed.last_name) as last_name, " +
                                                    " ed.pay_rate " +
                                                    " from ovms_timesheet_status as ts  " +
                                                    " join ovms_timesheet_details as td " +
                                                    " on ts.timesheet_status_id = td.timesheet_status_id " +
                                                    " join ovms_timesheet as t " +
                                                    " on td.timesheet_id = t.timesheet_id " +
                                                    " join ovms_employees as e " +
                                                    " on t.employee_id = e.employee_id " +
                                                    " join ovms_employee_details as ed " +
                                                    " on e.employee_id = ed.employee_id  " +
                                                    " where ts.timesheet_status_id=3 " +
                                                    " and e.client_id = " + Session["ClientID"].ToString() + " " +
                                                    " and e.active = 1) as times " +
                                                    " where timesheet_status_id=3 " +
                                                    " and JobManager_ID= " + Session["UserID"].ToString() + " order by first_name asc";

                SqlCommand cmdGetTimeSheets = new SqlCommand(strGetTimeSheettobeApproved, conn);
                SqlDataReader readerGetTimeSheets = cmdGetTimeSheets.ExecuteReader();
                sTable = sTable + "<tbody>";
                if (readerGetTimeSheets.HasRows == true)
                {
                    while (readerGetTimeSheets.Read())
                    {

                        string hours = readerGetTimeSheets["HOURS_REPORTED"].ToString();
                        string chk = "1";
                        string chk2 = "1";

                        //DateTime.Parse(readerGetTimeSheets["DATE+_FROM"].ToString()).ToString("dd MMM, yyyy") +
                        string sAction = readerGetTimeSheets["timesheet_status"].ToString();
                        sTable = sTable + "<tr>";
                        sTable = sTable + "<td>" + func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString()) + "<p>(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ")</p></td> ";
                        //sTable = sTable + "<td>" + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + " </td> ";
                        sTable = sTable + "<td>" + readerGetTimeSheets["HOURS_REPORTED"].ToString() + " </td> ";                        //sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=123&action=Approve&fromD=1&FromM=1&FromY=1' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve TimeSheet'><i class='fa fa-check'></i></a>&nbsp;<a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=1&action=Reject&fromD=1&FromM=1&FromY=1' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                        sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + readerGetTimeSheets["employee_id"].ToString() + "' class='btn btn-warning btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='View Details'><i class='fa fa-table'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&chk=" + chk + "&time=" + hours + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + " (" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve Timesheet'><i class='fa fa-check'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&chk2=" + chk2 + "&time=" + hours + "&action2=reject&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + "(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-danger btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Reject Timesheet'><i class='fa fa-times'></i></a>&nbsp;</i></a></td>";
                        //sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + readerGetTimeSheets["employee_id"].ToString() + "' class='btn btn-warning btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='View Details'><i class='fa fa-table'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + "(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve Timesheet'><i class='fa fa-check'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                        //sTable = sTable = "<td>12</td>";
                        //C_TimeSheet_View.aspx?topen=Y&p=VT&TID=1
                        sTable = sTable + "</tr>";
                        //string a = "";
                        //}
                    }

                    // lblJobs.Text = reader["num_of_jobs"].ToString();
                    //lblVendors.Text  = reader["num_of_jobs"].ToString();
                }
                else
                {
                    sTable = sTable + "<tr>";
                    sTable = sTable + "<td colspan=3>No Timesheets to be approved</td>";
                    sTable = sTable + "</tr>";
                }

                sTable = sTable + "</tbody>";
                readerGetTimeSheets.Close();
                cmdGetTimeSheets.Dispose();
                lblTableData.Text = sTable;
            }
        }
        catch (Exception ex)
        {
            //
        }
        finally
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }



        //for (int iResponse = 0; iResponse < Response.Count; iResponse++)
        //{

        //sstring.Format("{0:c0}", (8 * Convert.ToDouble(PayRate) * Convert.ToDouble(ContractLength)));
        //sTable = sTable + "<tr>";
        //sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("FIRST_NAME").InnerText + " " + Response[iResponse].SelectSingleNode("LAST_NAME").InnerText) + "</td> ";
        //sTable = sTable + "<td>" + string.Format("{0:c0}",Convert.ToDouble(Response[iResponse].SelectSingleNode("PAY_RATE").InnerText)  * Convert.ToDouble(Response[iResponse].SelectSingleNode("HOURS").InnerText))+ " </td> ";
        //sTable = sTable + "<td><a href='approve_timesheet.aspx?wopen=Y&p=VW&empid=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "'class='btn btn-success btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Approve'><i class='fa fa-check'></i></a>&nbsp;<a href='show_timesheet.aspx?wopen=Y&p=VW&empid=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "' class='btn btn-default btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='More details'><i class='fa fa-pencil'></i></a>&nbsp;<a href='decline_timesheet.aspx?wopen=Y&p=VW&empid=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject'><i class='fa fa-times'></i></a></td>";
        //sTable = sTable + "</tr>";
        //string a = "";
        //}

        //sTable = sTable + "</tbody>";
        //getWorkers.Dispose();
        //lblTableData.Text = sTable;

        //}
        //table end

        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=Your+session+has+timed+out");
            Response.End();
        }
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);


        //vendor contribution
        VendorContribution();
        //get recently added by manager
        //recently added jobs API
        API.Service web = new API.Service();

        // XmlDocument _xmlWorkers = new XmlDocument();

        //Create XML Stuff
        XmlDocument _xmlDoc = new XmlDocument();
        XmlNodeList nodeList;
        string _Error = "";
        int intCount = 1;
        //Load XML Element into document
        _xmlDoc.LoadXml("<XML>" + web.get_Recent_jobs(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["UserTypeID"].ToString(), Session["UserID"].ToString(), "").InnerXml + "</XML>");
        //loop through
        nodeList = _xmlDoc.SelectNodes("XML/RESPONSE/JOB_ID");
        string strGOTO = "";
        //declare variables

        string strjob = "";
        intCount = nodeList.Count;
        try
        {
            //_Error = nodeList[0].SelectSingleNode("JOB_ALIAS").InnerText;
            //_Error = nodeList[0].ChildNodes[0].SelectSingleNode("JOB_ALIAS").InnerText;
            _Error = nodeList[0].SelectSingleNode("JOB_ALIAS").InnerText;
        }
        catch (Exception ex)
        {
            _Error = "error";
        }
        if (_Error == "error")
        {
            strjob = strjob + @"<li class=""list-group-item"">" +
                                   @"<div id=""lbl1"" runat=""server"">" +
                                   @"No jobs have been added " +
                                   @"</div>" +
                                   @"</li>";
        }
        else
        {
            int i = 0;
            //loop through nodes
            foreach (XmlNode book in nodeList)
            {

                //job id show jobs
                strjob = strjob + @"<li class=""list-group-item"">" +
                                    @"<div id=""lbl1"" runat=""server"">" +
                                    @"		<span class='label label-default'>" + nodeList[i].SelectSingleNode("JOB_ALIAS").InnerText + "</span>&nbsp;<a href='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + nodeList[i].SelectSingleNode("JOB_ALIAS").InnerText + "'><b>" + func.FixString(nodeList[i].SelectSingleNode("JOB_TITLE").InnerText) + "</b><br>" +
                                    @"		" + nodeList[i].SelectSingleNode("NO_OF_OPENINGS").InnerText + " position(s) | " + func.FixString(nodeList[i].SelectSingleNode("LOCATION").InnerText) + " - " + nodeList[i].SelectSingleNode("LENGTH_OF_DAYS").InnerText + " day(s)  </a>" +
                                    @"</div>" +
                                    @"</li>";
                if (i == 0)
                {


                    strGOTO = @"<li class=""list-group-item text-right"">" +
                                   @"<a class=""btn btn-sm btn-primary"" href=""Add_jobs.aspx?jopen=Y&p=JA"">Add a Job<i class=""fa fa-fw fa-arrow-right""></i></a>" +
                                   @"</li>";
                }

                //increment
                i = i + 1;
            }

        }
        lblshowrecentlyadded.Text = strjob + strGOTO;

        //get top vendor
        API.Service gettopvendor = new API.Service();
        //get_all_vendors_for_a_client
        XmlDocument XMLDoc = new XmlDocument();
        XMLDoc.LoadXml("<XML>" + gettopvendor.get_all_vendors_for_a_client(Session["ClientID"].ToString(), Session["Email"].ToString(), Session["P@ss"].ToString()).InnerXml + "</XML>");
        XmlNodeList xResponse = XMLDoc.SelectNodes("XML/RESPONSE/VENDORS");
        string _sTopVendorName = "";
        for (int iResponse = 0; iResponse < xResponse.Count; iResponse++)
        {
            if (iResponse == 0)
            {
                _sTopVendorName = xResponse[iResponse].SelectSingleNode("VENDOR_NAME").InnerText.ToUpper();
                break;
            }
            iResponse = iResponse + 1;
        }

        lblTopVendorName.Text = _sTopVendorName;
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strSQLGetJobs = "select count(*) as num_of_jobs from ovms_jobs where client_ID = " + Session["ClientID"].ToString() + " and active = 1 ";
                SqlCommand cmdGetJobs = new SqlCommand(strSQLGetJobs, conn);
                SqlDataReader reader = cmdGetJobs.ExecuteReader();
                while (reader.Read())
                {
                    lblJobs.Text = reader["num_of_jobs"].ToString();
                    //lblVendors.Text  = reader["num_of_jobs"].ToString();
                }
                reader.Close();
                cmdGetJobs.Dispose();
                //getVendors
                string strSQLGetVendors = "select count(*) as NumVendors from  ovms_users where utype_id = 2 and client_id =" + Session["ClientID"].ToString() + " and active = 1 ";
                SqlCommand cmdGetVendors = new SqlCommand(strSQLGetVendors, conn);
                SqlDataReader readerVendors = cmdGetVendors.ExecuteReader();
                while (readerVendors.Read())
                {
                    lblVendors.Text = readerVendors["NumVendors"].ToString();
                    //lblVendors.Text  = reader["num_of_jobs"].ToString();
                }
                readerVendors.Close();
                cmdGetVendors.Dispose();
            }
        }
        catch (Exception ex)
        {
            //
        }
        finally
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }

    protected void btnVendorContribution_Click(object sender, EventArgs e)
    {

    }

    public void VendorContribution()
    {
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetVendorActivity = "select distinct " +
                                        " a.vendor_id, b.vendor_name,  " +
                                        " (select count(*) as employee_count from ovms_employees " +
                                        " where vendor_id = a.vendor_id and active = 1) active_employee_count " +
                                        " from ovms_users a, ovms_vendors b " +
                                        " where a.vendor_id = b.vendor_id " +
                                        " and a.utype_id = 2 " +
                                        " and a.client_id = " + Session["ClientID"].ToString() + " " +
                                        " and a.active = 1 ";
                SqlCommand cmdGetVendorActivity = new SqlCommand(strGetVendorActivity, conn);
                SqlDataReader readerVendorActivity = cmdGetVendorActivity.ExecuteReader();
                string _svendorList = "";
                while (readerVendorActivity.Read())
                {
                    _svendorList = _svendorList + "<tr>" +
                                    "<td>" + func.FixString(readerVendorActivity["vendor_name"].ToString()) + "</td> " +
                                    "<td>" + readerVendorActivity["active_employee_count"].ToString() + "</td> " +
                                    "</tr>";



                    //lblvendor.Text = readerVendorActivity["vendor_name"].ToString();
                    //lblVendors.Text  = reader["num_of_jobs"].ToString();
                }
                lblVendorContribution.Text = "Vendor Contribution as of today";
                lblVendorList.Text = _svendorList;
                readerVendorActivity.Close();
                cmdGetVendorActivity.Dispose();
            }
        }
        catch (Exception ex)
        {
            //
        }
        finally
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

    }
    public static bool isMoreThanToday(DateTime input, DateTime date1)
    {
        return (input < date1);
    }


    protected void Send3_Click(object sender, EventArgs e)
    {
        // if (Request.QueryString["TID"] != null)
        if (Request.QueryString["chk"] != null)
        {
            string thours = Request.QueryString["time"].ToString();

            Response.Redirect("ClientActionPage.aspx?TID=" + Request.QueryString["TID"].ToString() + "&hours=" + thours + " &action=" + Request.QueryString["action"].ToString() + "&fromD=" + Request.QueryString["fromD"].ToString() + "&FromM=" + Request.QueryString["FromM"].ToString() + " &FromY=" + Request.QueryString["FromY"].ToString() + "&Mess=" + Request.QueryString["Mess"].ToString() + "&ModalAction=Y");
        }
    }

    protected void Send4_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["chk2"] != null)
        {
            string emp_id = Request.QueryString["TID"].ToString();
            string loc_reject = "Reject";
            try
            {


                HttpContext.Current.Response.Redirect("ClientActionPage.aspx?TID=" + emp_id + " &action=" + loc_reject + "&fromD=" + Request.QueryString["fromD"].ToString() + "&FromM=" + Request.QueryString["FromM"].ToString() + " &FromY=" + Request.QueryString["FromY"].ToString() + "&Mess=" + Request.QueryString["Mess"].ToString() + "&ModalAction=Y");

                // Response.Redirect("ClientActionPage.aspx?TID=" + emp_id +  " &action2=" + loc_reject + "&fromD=" + Request.QueryString["fromD"].ToString() + "&FromM=" + Request.QueryString["FromM"].ToString() + " &FromY=" + Request.QueryString["FromY"].ToString() + "&Mess=" + Request.QueryString["Mess"].ToString() + "&ModalAction=Y");

            }
            catch (System.Threading.ThreadAbortException)
            {
                // ignore it
            }
            catch (Exception ex)
            {

                string excp = "";
            }

        }
    }
}