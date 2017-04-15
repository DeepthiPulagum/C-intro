using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class C_Dashboard : System.Web.UI.Page
{
    int iCountTSAction = 0;
    string sTimesheetActionCount = "0";
    string sJobCount = "";
    string sInterviewCount = "";
    string sWorkers = "";
    string sNoFeedback = "0";
    string sContractStarting = "";
    string sContractEnding = "";

    SqlConnection conn;
    StringFunctions func = new StringFunctions();
    private int iResponse;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["dash_conS"] == "1")
        {

            string employeeID = (Request.QueryString["approve_dash07"].Substring(Request.QueryString["approve_dash07"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            lblscheduleintname.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lblschedulejab.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
            lblschedul.Text = DateTime.Parse(Request.QueryString["date"].Replace("12:00:00 AM", "")).ToString("dd MMM, yyyy") + " at " + Request.QueryString["time"];


        }
        if (Request.QueryString["dash_con2"] == "1")
        {

            string employeeID = (Request.QueryString["approve_dash"].Substring(Request.QueryString["approve_dash"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            lblaprovedash.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lbljobaprdash.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;


        }

        if (Request.QueryString["dash_con1"] == "1")
        {

            string employeeID = (Request.QueryString["Reject_dash1"].Substring(Request.QueryString["Reject_dash1"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            lbldashrejectCand.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lbldashjob.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;


        }
        if (Page.IsPostBack)
        {
            btndash_interview.CausesValidation = false;
            // BtnReshedule.CausesValidation = false;

        }
        if (Request.QueryString["forImsgDash"] == "1")
        {
            //  following code is for getting all interview comment from i button
            string employeeID = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getComments2 = new API.Service();
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml("<XML>" + getComments2.get_interview_msg(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
            XmlNodeList Response01 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
            string previous_commnt = "";


            for (int iResponse13 = 0; iResponse13 < Response01.Count; iResponse13++)
            {
                string vendor_msg = Response01[iResponse13].SelectSingleNode("FROM_VENDOR").InnerText;
                if (vendor_msg == "1")
                {
                    previous_commnt = Server.HtmlDecode(previous_commnt + "\n" + "(" + Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG_TIME").InnerText + ")Vendor:  " + (Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG").InnerText));
                }
                else
                {
                    previous_commnt = Server.HtmlDecode(previous_commnt + "\n" + "(" + Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG_TIME").InnerText + ")Client:  " + (Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG").InnerText));

                }
            }

            txtfrstaction.Text = previous_commnt.ToString();
            //this code is to chek msg status from the vendor in interview table
            API.Service isreadStatus = new API.Service();
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");

        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Rejectedempid"] != null)
            {
                string id1 = Request.QueryString["Rejectedempid"];
                string id = Request["Rejectedempid"].Substring(Request["Rejectedempid"].Length - 6);

                API.Service getWorkers = new API.Service();
                XmlDocument dom1 = new XmlDocument();
                dom1.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), id, Session["VendorID"].ToString(), Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
                XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                lblrejectedname.Text = func.FixString(Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText) + " " + func.FixString(Response[iResponse].SelectSingleNode("LASTNAME").InnerText);
                lblrejected_comment.Text = Response[iResponse].SelectSingleNode("REASON_OF_REJECTION").InnerText;
                if(lblrejected_comment.Text==null || lblrejected_comment.Text=="")
                {
                    lblrejected_comment.Text = Response[iResponse].SelectSingleNode("VENDOR_REJECT_CANDIDATE_COMMENT").InnerText;
                }
                ////sDate = DateTime.Today;
            }
        }
        if (Request.QueryString["action"] != null)
        {
            //timesheet popup modal action text
            lblAction.Text = "Timesheet Action (Approve)";
            if (Request.QueryString["mess"] != null)
            {
                int DollarTextposition = Request.QueryString["mess"].ToString().Replace("(", "<br>(").IndexOf("for $");
                //Request.QueryString["mess"].ToString().Replace("(", "<br>(").Substring(0, DollarTextposition) + " for " + Request.QueryString["time"].ToString().Replace("(", "<br>(") + " hours";
                //lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " the timesheet for <br>" + Request.QueryString["mess"].ToString().Replace("(", "<br>(");
                lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " the timesheet for <br>" + Request.QueryString["mess"].ToString().Replace("(", " <br>  ").Substring(0, DollarTextposition) + " for " + Request.QueryString["time"].ToString().Replace("(", " < br > (") + " hours";
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

        //Session["Job_Count"] = "0";
        //declare connection
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        GetJobCount();
        GetInterviewCount();
        GetWorkers();
        GetNoFeedback();
        GetContractStarting();
        GetContractEnding();
        //labels
        lblJobCount.Text = sJobCount;
        lblInterviewCount.Text = sInterviewCount;
        lblWorkers.Text = sWorkers;
        //lblNoFeedback.Text = sNoFeedback;
        //lblContractStarting.Text = sContractStarting;
        //lblContractEnding.Text = sContractEnding;
        //lblTimeSheetAction = 
    }
    public void TimesheetAction()
    {
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
                //sTable = sTable + "<tbody>";

                if (readerGetTimeSheets.HasRows == true)
                {

                    while (readerGetTimeSheets.Read())
                    {
                        iCountTSAction = iCountTSAction + 1;
                        string hours = readerGetTimeSheets["HOURS_REPORTED"].ToString();
                        string chk = "1";
                        string chk2 = "1";

                        //DateTime.Parse(readerGetTimeSheets["DATE+_FROM"].ToString()).ToString("dd MMM, yyyy") +
                        string sAction = readerGetTimeSheets["timesheet_status"].ToString();
                        //sTable = sTable + "<tr>";
                        //sTable = sTable + "<td>" + func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString()) + "<p>(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ")</p></td> ";
                        ////sTable = sTable + "<td>" + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + " </td> ";
                        //sTable = sTable + "<td>" + readerGetTimeSheets["HOURS_REPORTED"].ToString() + " </td> ";                        //sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=123&action=Approve&fromD=1&FromM=1&FromY=1' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve TimeSheet'><i class='fa fa-check'></i></a>&nbsp;<a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=1&action=Reject&fromD=1&FromM=1&FromY=1' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                        //sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + readerGetTimeSheets["employee_id"].ToString() + "' class='btn btn-warning btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='View Details'><i class='fa fa-table'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&chk=" + chk + "&time=" + hours + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + " (" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve Timesheet'><i class='fa fa-check'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&chk2=" + chk2 + "&time=" + hours + "&action2=reject&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + "(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-danger btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Reject Timesheet'><i class='fa fa-times'></i></a>&nbsp;</i></a></td>";
                        ////sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + readerGetTimeSheets["employee_id"].ToString() + "' class='btn btn-warning btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='View Details'><i class='fa fa-table'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + "(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve Timesheet'><i class='fa fa-check'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                        ////sTable = sTable = "<td>12</td>";
                        ////C_TimeSheet_View.aspx?topen=Y&p=VT&TID=1
                        //sTable = sTable + "</tr>";
                        //string a = "";
                        //}
                    }

                    // lblJobs.Text = reader["num_of_jobs"].ToString();
                    //lblVendors.Text  = reader["num_of_jobs"].ToString();
                }
                else
                {
                    //sTable = sTable + "<tr>";
                    //sTable = sTable + "<td colspan=3>No Timesheets to be approved</td>";
                    //sTable = sTable + "</tr>";
                }

                //   sTable = sTable + "</tbody>";
                readerGetTimeSheets.Close();
                cmdGetTimeSheets.Dispose();
                //lblTableData.Text = sTable;
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
        // lblTimeSheetAction.Text = iCountTSAction.ToString();
    }
    public void GetJobCount()
    {
        string sdiff = "NO";
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetJobCount = " select sum(b.vender_pay_rate * d.hours) as totalspent" +
                                        " from ovms_jobs a, ovms_job_accounting b, ovms_employees c, ovms_timesheet d, ovms_timesheet_details e  " +
                                        " where a.job_id = b.job_id  " +
                                        " and a.job_id = c.job_id  " +
                                        " and a.user_id = " + Session["UserID"].ToString() + " " +
                                        "  and c.active = 1  " +
                                        " and c.client_id = " + Session["ClientID"].ToString() + "  " +
                                        " and d.timesheet_id = e.timesheet_id  " +
                                        " and c.employee_id = d.employee_id  " +
                                        " and a.client_id = " + Session["ClientID"].ToString() + " and a.active = 1  " +
                                        " and d.active = 1  " +
                                        " and e.active = 1  " +
                                        " and e.timesheet_status_id = 1";
                //  " where vendor_ID = " + Session["vendorID"].ToString() + " " +
                SqlCommand cmdGetJobCount = new SqlCommand(sqlGetJobCount, conn);
                SqlDataReader rsGetJobCount = cmdGetJobCount.ExecuteReader();
                //string _svendorList = "";
                //string sdiff = "NO";
                while (rsGetJobCount.Read())
                {
                    sJobCount = "$" + rsGetJobCount["totalspent"].ToString();

                }
                rsGetJobCount.Close();
                cmdGetJobCount.Dispose();
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

        string sJobID = "";
        string sJobDetails = "";
        string sNoOpenings = "";
        if (sdiff == "YES")
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    string strgetJobDetailsNotification = " select a.job_title, a.No_of_openings, dbo.createJobNo(a.job_id) as full_Job_ID, b.roles_and_responsibilities" +
                                              " from ovms_jobs a, ovms_job_details b " +
                                              " where a.job_id = b.Job_id " +
                                              " and a.client_id = " + Session["ClientID"].ToString() + " " +
                                              " and a.active = 1 " +
                                              " order by a.job_id asc";
                    //" and a.vendor_Id = " + Session["VendorID"].ToString() + " " +
                    SqlCommand cmdGetJobDetailNotification = new SqlCommand(strgetJobDetailsNotification, conn);
                    SqlDataReader rsGetJobDetailsNotification = cmdGetJobDetailNotification.ExecuteReader();


                    while (rsGetJobDetailsNotification.Read())
                    {
                        sJobID = rsGetJobDetailsNotification["full_Job_ID"].ToString();
                        sJobDetails = rsGetJobDetailsNotification["roles_and_responsibilities"].ToString();
                        sNoOpenings = rsGetJobDetailsNotification["No_of_openings"].ToString();
                    }
                    //close
                    rsGetJobDetailsNotification.Close();
                    cmdGetJobDetailNotification.Dispose();

                    //notify
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "Script", "notifyMe('" + sJobID + "','" + sNoOpenings + "','" + sJobDetails + "');", true);
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
        //return _sArrayString;
    }
    public void GetInterviewCount()
    {

        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetInterviewCount = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
                                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                              "  and eac.employee_id = ea.employee_id " +
                                               "  and ea.active = 1 " +
                                              "  and eac.active = 1 " +
                                              "  and convert(datetime, ea.interview_date) between getdate() - 1 and getdate() + 7  ";
                //"  and(select vendor_id from ovms_employees where employee_id = ea.employee_id) = " + Session["VendorID"].ToString() + " " +

                SqlCommand cmdInterviewCount = new SqlCommand(sqlGetInterviewCount, conn);
                SqlDataReader rsInterviewCount = cmdInterviewCount.ExecuteReader();
                //string _svendorList = "";
                int iCount = 0;
                while (rsInterviewCount.Read())
                {
                    //increment count
                    iCount = iCount + 1;
                    //get date of interview

                }
                rsInterviewCount.Close();
                cmdInterviewCount.Dispose();
                sInterviewCount = iCount.ToString();
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
        //return _sArrayString;
    }
    public void GetWorkers()
    {

        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetWorkers = " select count(*) as employee_Count " +
                                             " from ovms_employees as e  join ovms_employee_details as ed on ed.employee_id=e.employee_id  " +
                                             " left join ovms_employee_actions as ea on ea.employee_id=e.employee_id   " +
                                             " join ovms_clients as clt on clt.client_id=e.client_id   " +
                                              "where ea.client_id = " + Session["ClientID"].ToString() +
                                              " and ed.active=1 and ea.candidate_approve=1  ";
                //" vendor_id = " + Session["VendorID"].ToString() + " " + 

                SqlCommand cmdGetWorkers = new SqlCommand(sqlGetWorkers, conn);
                SqlDataReader rsGetWorker = cmdGetWorkers.ExecuteReader();
                //string _svendorList = "";
                while (rsGetWorker.Read())
                {
                    sWorkers = rsGetWorker["employee_Count"].ToString();
                }
                rsGetWorker.Close();
                cmdGetWorkers.Dispose();
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
        //return _sArrayString;
    }
    public void GetNoFeedback()
    {

        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //start, end and weeks
                string sqlGetNoFeedback = " select distinct ed.employee_id " +
                                    " from ovms_employee_details ed, ovms_employees em, ovms_employee_actions ea " +
                                    " where ed.employee_id = em.employee_id " +
                                    " and ed.create_date <= getdate() - 1 " +
                                    " and ed.active = 1 " +
                                    " and em.active = 1 " +
                                    " and ea.client_id = em.client_id " +
                                    " and em.client_id = " + Session["ClientID"].ToString() + " " +
                                     " and em.employee_id not in (select employee_id from ovms_employee_actions as ea ) " +
                                    " and ed.first_name <> '' ";
                //" and em.vendor_id = " + Session["VendorID"].ToString();
                SqlCommand cmdGetNoFeedback = new SqlCommand(sqlGetNoFeedback, conn);
                SqlDataReader rsGetNoFeedback = cmdGetNoFeedback.ExecuteReader();
                //string _svendorList = "";
                int iNoFeedback = 0;
                while (rsGetNoFeedback.Read())
                {
                    iNoFeedback = iNoFeedback + 1;
                }
                sNoFeedback = iNoFeedback.ToString();
                rsGetNoFeedback.Close();
                cmdGetNoFeedback.Dispose();
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
        //return _sArrayString;
    }
    public void GetContractStarting()
    {

        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetContractStarting = " select count(*) as contract_Starting " +
                                          " from ovms_employee_actions ea, ovms_employee_details eac " +
                                          " where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                          " and eac.employee_id = ea.employee_id " +
                                          " and ea.active = 1 " +
                                          " and eac.active = 1 " +
                                          " and eac.availability_for_interview between getdate() and getdate() + 7 " +
                                          " and ea.candidate_approve = 1 ";

                //" and(select vendor_id from ovms_employees where employee_id = ea.employee_id) = " + Session["VendorID"].ToString() + " " +
                SqlCommand cmdGetContractStarting = new SqlCommand(sqlGetContractStarting, conn);
                SqlDataReader rsGetContractStarting = cmdGetContractStarting.ExecuteReader();
                //string _svendorList = "";
                while (rsGetContractStarting.Read())
                {
                    sContractStarting = rsGetContractStarting["contract_Starting"].ToString();
                }
                rsGetContractStarting.Close();
                cmdGetContractStarting.Dispose();
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
        //return _sArrayString;
    }
    public void GetContractEnding()
    {

        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();
                sContractEnding = "0";
                //start, end and weeks
                string sqlGetContractEnd = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
                                         " dbo.GetJobNo(ea.employee_id) as job_num, " +
                                         " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                                         "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                         "  and eac.employee_id = ea.employee_id " +
                                         "  and ea.active = 1 " +
                                         "  and eac.active = 1 " +
                                         "  and convert(datetime,ea.candidate_enddate) between getdate()-1 and getdate() ";

                //"  and(select vendor_id from ovms_employees where employee_id = ea.employee_id) = " + Session["VendorID"].ToString() + " " +
                SqlCommand cmdGetContractEnding = new SqlCommand(sqlGetContractEnd, conn);
                SqlDataReader rsGetContractEnding = cmdGetContractEnding.ExecuteReader();
                //string _svendorList = "";
                int iEnding = 0;
                while (rsGetContractEnding.Read())
                {
                    iEnding = iEnding + 1;
                }
                sContractEnding = iEnding.ToString();
                rsGetContractEnding.Close();
                cmdGetContractEnding.Dispose();
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
        //return _sArrayString;
    }
    protected void Button2_Click(object sender, EventArgs e)
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

    protected void Send3_Click(object sender, EventArgs e)
    {
        // if (Request.QueryString["TID"] != null)
        if (Request.QueryString["chk"] != null)
        {
            string thours = Request.QueryString["time"].ToString();

            Response.Redirect("ClientActionPage.aspx?TID=" + Request.QueryString["TID"].ToString() + "&hours=" + thours + " &action=" + Request.QueryString["action"].ToString() + "&fromD=" + Request.QueryString["fromD"].ToString() + "&FromM=" + Request.QueryString["FromM"].ToString() + " &FromY=" + Request.QueryString["FromY"].ToString() + "&Mess=" + Request.QueryString["Mess"].ToString() + "&ModalAction=Y");
        }
    }
    protected void btndash_interview_Click(object sender, EventArgs e)
    {
        if ((checkurgent.Checked) == true)
        {
            string chk = "yes";
            Response.Redirect("C_Dashboard.aspx?txtComments=" + txtcomments.Text + "&dash_con2=1" + "&approve_dash=" + Request.QueryString["done_dash"].ToString() + "&chkapprove=" + chk + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + " &emp_end=" + Request["emp_enddate"].ToString());
            Response.End();


        }
        string interview_comment = txtcomments.Text;
        string date = Textdate.Value;
        string time = ddtime.Text;
        Response.Redirect("C_Dashboard.aspx?txtComments=" + txtcomments.Text + "&dash_conS=1" + "&approve_dash07=" + Request.QueryString["done_dash"].ToString() + "&intComment=" + interview_comment + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + "&time=" + time + "&date=" + date + " &emp_end=" + Request.QueryString["emp_enddate"].ToString());
        Response.End();
    }

    protected void btnDashReject_Click(object sender, EventArgs e)
    {
        string test;
        if (txtComments1.Text == "")
        {
            test = "No Reason Given";
        }
        else
        {

            test = txtComments1.Text;
        }

        Response.Redirect("C_Dashboard.aspx?txtComments=" + test +"&dash_con1=1" +"&Reject_dash1=" + Request.QueryString["Reject_dash"].ToString() + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + "&emp_end=" + Request.QueryString["emp_enddate"].ToString());
        Response.End();
    }

    protected void btnCHAT_Click(object sender, EventArgs e)
    {
        string coments = txtfrstaction2.Text;
        string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 6));
        DateTime thisDay = DateTime.Now;
        API.Service eye_msg = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + eye_msg.more_info_msg_eye(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, Session["VendorID"].ToString(), "1", Session["ClientID"].ToString(), coments, thisDay, "", "1") + "</XML>");
        Response.Redirect("C_Dashboard.aspx");
    }

    protected void dashREJECT_Click(object sender, EventArgs e)
    {
        string interview_comment = txtcomments.Text;
        string date = Textdate.Value;
        string time = ddtime.Text;
        Response.Redirect("emp_action_from_dashboard.aspx?txtComments=" + Request.QueryString["txtComments"] + "&approve=" + Request.QueryString["Reject"].ToString() + "&intComment=" +Request.QueryString["txtComments"] + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + "&time=" + time + "&date=" + date + " &emp_end=" + Request.QueryString["emp_end"].ToString());

    }

    protected void btnrejectDAsh_Click(object sender, EventArgs e)
    {
        Response.Redirect("emp_action_from_dashboard.aspx?txtComments=" + Request.QueryString["txtComments"] +  "&Reject_dash1=" + Request.QueryString["Reject_dash1"].ToString() + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + "&emp_end=" + Request.QueryString["emp_end"].ToString());

    }

    protected void dashAproveConfirm_Click(object sender, EventArgs e)
    {
        string chk = "yes";
        Response.Redirect("emp_action_from_dashboard.aspx?txtComments=" + Request.QueryString["txtComments"]  + "&approve=" + Request.QueryString["approve_dash"].ToString() + "&chkapprove=" + chk + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + " &emp_end=" + Request["emp_end"].ToString());

    }

    protected void btnscheduleint_dash_Click(object sender, EventArgs e)
    {
        Response.Redirect("emp_action_from_dashboard.aspx?txtComments=" + Request.QueryString["txtComments"] +  "&approve=" + Request.QueryString["approve_dash07"].ToString() + "&intComment=" + Request.QueryString["txtComments"] + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + "&time=" +Request.QueryString[ "time"] + "&date=" +Request.QueryString[ "date"] + " &emp_end=" + Request.QueryString["emp_end"].ToString());

    }
}