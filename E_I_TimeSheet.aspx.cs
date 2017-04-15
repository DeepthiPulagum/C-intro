using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class E_I_TimeSheet : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();

    string _strinsertTimeSheet = "";
    string _strinsertTimeSheetDetail = "";
    emailFunctions semail = new emailFunctions();
    string emailjobid = "";
    string emailemployeeid = "";
    string employee_name_email = "";
    string email_job_id = "";
    string email_worker_name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=Your+session+has+timed+out");
            Response.End();
        }


        //?Day=" + s_Day + "&Month=" + s_Month + "&Year=" + s_Year + "&M=" + MondVal + "&T=" + TuesVal + "&W=" + WedVal + "&TH=" + ThurVal + "&F=" + FriVal + "&S=" + SatVal + "&S=" + SunVal + "", true);
        //xhr.send();
        GetEmployeename(Session["EmployeeIDForJob"].ToString());
        string _sInsertTimeSheet = "";
        _sInsertTimeSheet = InsertTimeSheet(emailemployeeid, Request.QueryString["Day"].ToString(), Request.QueryString["Month"].ToString(), Request.QueryString["Year"].ToString());
        //InsertTimesheet
        lblResponse.Text = _sInsertTimeSheet;
        
        // InsertTimeSheet.ToString(), );
    }

    public static double ConvertToDouble(string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            double OutVal;
            double.TryParse(Value, out OutVal);

            if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            {
                return 0;
            }
            return OutVal;
        }
    }

    public string InsertTimeSheet(string Employee_ID, string day, string month, string year)
    {
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

        int newtsid = 0;
        double _dhours = 0;
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                for (int iDate = 0; iDate <= 6; iDate++)
                {
                    DateTime _dt = Convert.ToDateTime(month + "/" + day + "/" + year).AddDays(iDate);


                    if (iDate == 0)
                    {
                        _dhours = ConvertToDouble(Request.QueryString["M"].ToString());
                    }
                    if (iDate == 1)
                    {
                        _dhours = ConvertToDouble(Request.QueryString["T"].ToString());
                    }
                    if (iDate == 2)
                    {
                        _dhours = ConvertToDouble(Request.QueryString["W"].ToString());
                    }
                    if (iDate == 3)
                    {
                        _dhours = ConvertToDouble(Request.QueryString["TH"].ToString());
                    }
                    if (iDate == 4)
                    {
                        _dhours = ConvertToDouble(Request.QueryString["F"].ToString());
                    }
                    if (iDate == 5)
                    {
                        _dhours = ConvertToDouble(Request.QueryString["S"].ToString());
                    }
                    if (iDate == 6)
                    {
                        _dhours = ConvertToDouble(Request.QueryString["SU"].ToString());
                    }
                    //delete first allowing for update
                    //string strDeleteOldTime = " Delete from ovms_timesheet where day = '" + _dt.Day + "' and month = '" + _dt.Month + "' and year = '" + _dt.Year + "' where employee_id='"+ Session["EmployeeIDForJob"].ToString() +"' ";
                    string strDeleteOldTime = " Delete from ovms_timesheet where day = '" + _dt.Day + "' and month = '" + _dt.Month + "' and year = '" + _dt.Year + "' and employee_id='" + Session["EmployeeIDForJob"].ToString() + "'";
                    SqlCommand cmdDeleteOldTime = new SqlCommand(strDeleteOldTime, conn);
                    cmdDeleteOldTime.ExecuteScalar();


                    string strSql = "INSERT INTO ovms_timesheet(employee_id, day, month, year,hours,overtime)" +
                       " VALUES(" + Session["EmployeeIDForJob"].ToString() + "," + _dt.Day + "," + _dt.Month + "," + _dt.Year + "," + _dhours + ",0)" +
                       " SELECT CAST(scope_identity() AS int)";

                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    newtsid = (int)cmd.ExecuteScalar();

                    if (newtsid > 0)
                    {
                        _strinsertTimeSheet = "DONE";
                    }
                    else
                    {
                        _strinsertTimeSheet = "NOT";
                    }

                    strSql = "insert into ovms_timesheet_details(timesheet_id,timesheet_status_id, timesheet_comment_id)" +
                               "values(" + newtsid + ", '3', ''); ";

                    cmd = new SqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        _strinsertTimeSheet = "DONE";

                    }
                    else
                    {
                        _strinsertTimeSheet += "NOT";
                        //logService.set_log(125, HttpContext.Current.Request.Url.AbsoluteUri, "Unable to create new timesheet");
                    }
                    //dispose
                    cmd.Dispose();
                }
                

            }
        }
        catch (Exception ex)
        {
            _strinsertTimeSheet += "NOT";
            //logService.set_log(125, HttpContext.Current.Request.Url.AbsoluteUri, ex.Message);
        }
        finally
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        if (_strinsertTimeSheet == "DONE")
        {

            DateTime _dt_From = Convert.ToDateTime(month + "/" + day + "/" + year);
            DateTime _dt_To = _dt_From.AddDays(7);

            string total = Request.QueryString["total"];
            emailemployeeid = Session["EmployeeIDForJob"].ToString();
            semail.sendEmail("greg@opusing.com", "TIMESHEET HAS BEEN CREATED - ( " + Session["employee_name_email"].ToString() + " ) - [Time Sheet Start Date: " + _dt_From.ToString() + " - " + "Time Sheet End Date:" + _dt_To.ToString() + "]",
                            "Time Sheet Start Date : " + _dt_From.ToString() +
                            "<br>Time Sheet End Date : " + _dt_To.ToString() +
                            "<br>jobId :" + Session["emailjobid"].ToString() +
                            "<br>Worker ID :" + emailemployeeid +
                            "<br>Worker Name :" + Session["employee_name_email"].ToString() +
                            "<br>Time Sheet Billable Days : 7 days" +
                            "<br>Time Sheet Billable Hours :" + total +
                            "<br><br>**************" +
                            "<br>This notification was sent by FlentisPRO.If you have any questions regarding this notice," +
                            "<br>please contact the SAP Fieldglass Helpdesk at:" +
                            "<br>mailto:helpdesk@oveems.com" +
                            "<br>By Phone:" +
                            "<br>US(toll free) 1 800 123 1234" +
                            "<br>Please do not respond to this email, this is an automatic email message and this mailbox is not being monitored.", "", "");
        }
        Session["EmployeeIDForJob"] = null;
        Session["emailjobid"] = null;
        Session["employee_name_email"] = null;

        return _strinsertTimeSheet;
    }

    public void GetEmployeename(string emailemployeeid)
    {

        //select employee_ID from ovms_employees where job_id = 5 and user_id = 20
        string _sArrayString = "";
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetEmployeeIDForJob = " select first_name,last_name, " +
                    "(select job_id from ovms_employees as ed where employee_id=e.employee_id) jobid," +
                    "(select job_title from ovms_jobs where job_id = (select job_id from ovms_employees as ed where employee_id = e.employee_id) )job_title" +
                    " from ovms_employee_details as e  where employee_id =  " + emailemployeeid;

                SqlCommand cmdEmployeeID = new SqlCommand(sqlGetEmployeeIDForJob, conn);
                SqlDataReader rsGetEmployeeID = cmdEmployeeID.ExecuteReader();
                //string _svendorList = "";
                while (rsGetEmployeeID.Read())
                {

                    Session["employee_name_email"] = rsGetEmployeeID["first_name"].ToString() + " " + rsGetEmployeeID["last_name"].ToString();
                    Session["emailjobid"] = rsGetEmployeeID["jobid"].ToString();
                    //_sArrayString = rsStartEndWeeks["contract_Start_date"].ToString() + "," + rsStartEndWeeks["contract_end_date"].ToString() + "," + rsStartEndWeeks["Num_weeks"].ToString();


                }
                rsGetEmployeeID.Close();
                cmdEmployeeID.Dispose();
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



}