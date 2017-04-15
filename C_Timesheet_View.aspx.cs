using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class C_Timesheet_View : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    string _sListofWorkers, _sListofWorkers1 = "";
    StringFunctions func = new StringFunctions();
    string NumberOfWeeks = "";
    string FirstMonday = "";
    string FirstSunday = "";
    string LastContractDate = "";
    string ContractWeeks = "";
    string sTimeValues;
    string _sTimeSheetLines = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            //logout2
            Session.Abandon();
            Response.Redirect("Login.aspx?m=Your+session+has+timed+out");
            Response.End();
        }
        if (Request.QueryString["action"] != null)
        {
            //timesheet popup modal action text
            lblAction.Text = "Timesheet Action";
            if (Request.QueryString["mess"] != null)
            {
                lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " the timesheet for <br>" + Request.QueryString["mess"].ToString().Replace("(", "<br>(");
            }
            else
            {
                lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " this timesheet";
            }
        }
        ////update timesheet status
        //if (Request.QueryString["action"] != null)
        //{
        //    //update status
        //    conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        //    try
        //    {
        //        if (conn.State == System.Data.ConnectionState.Closed)
        //        {
        //            conn.Open();
        //            string _TimeSheetID = "0";
        //            string sqlGetTimeSheetID = "";
                    
        //            //start, end and weeks
        //            //get timesheetID + 7
                       
        //                sqlGetTimeSheetID = " select timesheet_id " +
        //                                        " from ovms_timesheet " +
        //                                        " where day =  " + Request.QueryString["fromD"].ToString() + " " +
        //                                        " and month =  " + Request.QueryString["FromM"].ToString() + " " +
        //                                        " and year = " + Request.QueryString["FromY"].ToString() + " " +
        //                                        " and employee_id = " + Request.QueryString["TID"].ToString() + " " +
        //                                        " and active =  1";
                   
        //            SqlCommand cmdGetTimeSheetID = new SqlCommand(sqlGetTimeSheetID, conn);
        //            SqlDataReader rsGetTimeSheetID = cmdGetTimeSheetID.ExecuteReader();
        //            if (rsGetTimeSheetID.HasRows == true)
        //            {
        //                while (rsGetTimeSheetID.Read())
        //                {
        //                    _TimeSheetID = rsGetTimeSheetID["timesheet_id"].ToString();
        //                }
        //            }
        //            //close
        //            rsGetTimeSheetID.Close();
        //            cmdGetTimeSheetID.Dispose();

        //            string sSQLUpdate = "";
        //            if (Request.QueryString["action"] == "Approve")
        //            {
        //                //update
        //                sSQLUpdate = " update ovms_timesheet_details " +
        //                                            " set timesheet_status_id = 1 " +
        //                                            " where timesheet_id between " + _TimeSheetID + " and " + (Convert.ToInt32(_TimeSheetID.ToString()) + +Convert.ToInt32("6")) + " " +
        //                                            " and active = 1";
        //            }
        //            if (Request.QueryString["action"] == "Reject")
        //            {
        //                //update
        //                sSQLUpdate = " update ovms_timesheet_details " +
        //                                            " set timesheet_status_id = 2 " +
        //                                            " where timesheet_id between " + _TimeSheetID + " and " + (Convert.ToInt32(_TimeSheetID.ToString()) + +Convert.ToInt32("6")) + " " +
        //                                            " and active = 1";
                        
        //            }
        //            SqlCommand cmdUpdateTimeSheet1 = new SqlCommand(sSQLUpdate, conn);
        //            int iUpdate = cmdUpdateTimeSheet1.ExecuteNonQuery();
        //            cmdUpdateTimeSheet1.Dispose();
                   
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //
        //    }
        //    finally
        //    {
        //        if (conn.State == System.Data.ConnectionState.Open)
        //            conn.Close();
        //    }

        //}
        //end of update timesheet status


        if (Request["TID"] != null)
        {
            GetListOfWorkers(Request.QueryString["TID"].ToString());
        }
        else
        {
            GetListOfWorkers("");
        }

      


    }

    public string CheckValTime(string sDay, string sMonth, string sYear)
    {
        string aHours = "";
        string aDatePassed = sMonth + "-" + sDay + "-" + sYear;
        if (sTimeValues != "")
        {
            string[] stringArray;
            try
            {
                stringArray = sTimeValues.Split('@');

                for (int ix = 0; ix < stringArray.Length; ix++)
                {
                    if (stringArray[ix].Split(',')[0].ToString().Trim() == aDatePassed.ToString().Trim())
                    {
                        //aHours = stringArray[ix].Split(',')[1].ToString();
                        aHours = stringArray[ix].Split(',')[1].ToString() + "," + stringArray[ix].Split(',')[2].ToString();

                        break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        //return
        if (aHours == "")
            aHours = "0,Not Sent";
        return aHours;
    }
    public static bool Between(DateTime input, DateTime date1, DateTime date2)
    {
        return (input > date1 && input < date2);
    }
    public static bool isLessThanToday(DateTime input, DateTime date1)
    {
        return (input >= date1);
    }
    public static bool isMoreThanToday(DateTime input, DateTime date1)
    {
        return (input <= date1);
    }
    public DateTime AddWorkingDays(DateTime dtFrom, int nDays)
    {
        // determine if we are increasing or decreasing the days
        int nDirection = 1;
        if (nDays < 0)
        {
            nDirection = -1;
        }

        // move ahead the day of week
        int nWeekday = nDays % 5;
        while (nWeekday != 0)
        {
            dtFrom = dtFrom.AddDays(nDirection);

            if (dtFrom.DayOfWeek != DayOfWeek.Saturday
                && dtFrom.DayOfWeek != DayOfWeek.Sunday)
            {
                nWeekday -= nDirection;
            }
        }

        // move ahead the number of weeks
        int nDayweek = (nDays / 5) * 7;
        dtFrom = dtFrom.AddDays(nDayweek);

        return dtFrom;
    }
    public void GetListOfWorkers(string EmployeeID)
    {
        //_sListofWorkers = "";
        string _sGetListofWorkers = "";
        _sListofWorkers1 = "";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
                
                 //_sGetListofWorkers = " select distinct  (select user_ID from ovms_employees where employee_id = ed.employee_id) as User_ID, " +
                 //                          " (select email_id from ovms_users where user_ID = (select user_ID from ovms_employees where employee_id = ed.employee_id)) as User_Email, " +
                 //                          " (select user_password from ovms_users where user_ID = (select user_ID from ovms_employees where employee_id = ed.employee_id)) as User_Password, " +
                 //                          " e.employee_id,dbo.CamelCase(ed.first_name) as first_name,dbo.CamelCase(ed.last_name) as last_name,ed.pay_rate from ovms_timesheet_status as ts " +
                 //                          " join ovms_timesheet_details as td on ts.timesheet_status_id = td.timesheet_status_id " +
                 //                          " join ovms_timesheet as t on td.timesheet_id = t.timesheet_id " +
                 //                          " join ovms_employees as e on t.employee_id = e.employee_id " +
                 //                          " join ovms_employee_details as ed on e.employee_id = ed.employee_id " +
                 //                          " and e.active = 1 " +
                 //                          " and t.active = 1 ";

                _sGetListofWorkers = " select distinct  (select user_ID from ovms_employees where employee_id = ed.employee_id) as User_ID,  e.job_id, " + 
                                        " (select email_id from ovms_users where user_ID = (select user_ID from ovms_employees where employee_id = ed.employee_id)) as User_Email,  " +
                                        "  (select user_password from ovms_users where user_ID = (select user_ID from ovms_employees where employee_id = ed.employee_id)) as User_Password, " +
                                        "  e.employee_id,dbo.CamelCase(ed.first_name) as first_name,dbo.CamelCase(ed.last_name) as last_name,ed.pay_rate, " +
                                        "  (select user_id as Manager_ID from ovms_jobs where job_id = e.job_id  and active = 1) as Manager_ID " +
                                        "  from ovms_timesheet_status as ts " +
                                        "  join ovms_timesheet_details as td on ts.timesheet_status_id = td.timesheet_status_id " +
                                        "  join ovms_timesheet as t on td.timesheet_id = t.timesheet_id  join ovms_employees as e " +
                                        "  on t.employee_id = e.employee_id  join ovms_employee_details as ed " +
                                        "  on e.employee_id = ed.employee_id " +
                                        "  and e.active = 1 " +
                                        "  and t.active = 1 " +
                                        "  and td.active = 1 " +
                                        "  and(select user_id as Manager_ID from ovms_jobs where job_id = e.job_id  and active = 1) =  " + Session["UserID"].ToString() + "";
                _sGetListofWorkers = _sGetListofWorkers + " and td.active = 1 order by first_name asc ";
                SqlCommand cmdGetListofWorkers = new SqlCommand(_sGetListofWorkers, conn);
                SqlDataReader rsGetListOfWorker = cmdGetListofWorkers.ExecuteReader();
                _sTimeSheetLines = "";
                while (rsGetListOfWorker.Read())
                {
                    if (EmployeeID != "")
                    {
                        if (rsGetListOfWorker["employee_ID"].ToString() == EmployeeID)
                        {


                            Session["sFullNameClient"] = rsGetListOfWorker["first_name"].ToString() + " " + rsGetListOfWorker["last_name"].ToString();
                            Session["EmailClient"] = rsGetListOfWorker["User_Email"].ToString();
                            Session["P@ssClient"] = rsGetListOfWorker["User_Password"].ToString();
                            Session["UserIDClient"] = rsGetListOfWorker["User_ID"].ToString();
                            _sTimeSheetLines =  "<tr><td>" +
                                                                                        " <a class='btn btn-primary' href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + rsGetListOfWorker["employee_id"] + "'><i class='icon-user-1'></i> " + rsGetListOfWorker["first_name"].ToString() + " " + rsGetListOfWorker["last_name"].ToString() + "</a>" +
                                                                                        " </td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                        " <td></td>" +
                                                                                          " <td></td>" +
                                                                                        " </tr>";
                            //Do details

                            Session["EmployeeIDForJob"] = EmployeeID;
                            //pull person information
                            //GetListOfWorkers(Request["TID"]);


                            NumberOfWeeks = GetNumberOfWeeks();
                            FirstMonday = GetMonday(NumberOfWeeks.Split(',')[0].ToString());
                            FirstSunday = GetSunday(NumberOfWeeks.Split(',')[0].ToString());
                            ContractWeeks = NumberOfWeeks.Split(',')[2].ToString(); //week num
                            LastContractDate = NumberOfWeeks.Split(',')[1].ToString(); //last contract date
                            GetEmployeeID();
                            //draw table but first read from file
                            int counter = 0;
                            string line;
                            string TimeSheet_Line = "";
                            string TimeSheetFileRead = "";
                            int iloop = 0;



                            DateTime MonDate;
                            DateTime SunDate;
                            string _sMonday;
                            string _sMondayDay = "";
                            string _sMondayMonth = "";
                            string _sMondayYear = "";
                            string _sTuesday;
                            string _sWednesday;
                            string _sThursday;
                            string _sFriday;
                            string _sSaturday;
                            string _sSunday;
                            string enableordisable = "";
                            string _sBackground = "";
                            double _dTotal = 0;


                            //get all time values for this timesheet
                            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
                            try
                            {
                                if (conn.State == System.Data.ConnectionState.Closed)
                                {
                                    conn.Open();

                                    // Session["JobID"] = jobID.ToString();

                                    //start, end and weeks
                                    //string sqlGetTime = "select concat(month,-day, -year) as tDate, hours " +
                                    //            " from ovms_timesheet where employee_id = " + Session["EmployeeIDForJob"].ToString();

                                    string sqlGetTime = "select concat(a.month,-a.day, -a.year) as tDate, a.hours, b.timesheet_status_id,  " +
                                                      " (select timesheet_status from ovms_timesheet_status where timesheet_status_id = b.timesheet_status_id and active = 1) as TimeSheet_Status_Name " +
                                                      " from ovms_timesheet a, ovms_timesheet_details b " +
                                                      " where a.employee_id =  " + Session["EmployeeIDForJob"].ToString() + " " +
                                                      " and a.timesheet_id = b.timesheet_id " +
                                                      " and a.active = 1 " +
                                                      " and b.active = 1 ";


                                    SqlCommand cmdGetTime = new SqlCommand(sqlGetTime, conn);
                                    SqlDataReader rsGetTime = cmdGetTime.ExecuteReader();
                                    //string _svendorList = "";
                                    while (rsGetTime.Read())
                                    {
                                        //Session["EmployeeIDForJob"] = rsGetTime["employee_ID"].ToString();
                                        //_sArrayString = rsStartEndWeeks["contract_Start_date"].ToString() + "," + rsStartEndWeeks["contract_end_date"].ToString() + "," + rsStartEndWeeks["Num_weeks"].ToString();
                                        //sTimeValues = sTimeValues + rsGetTime["tDate"].ToString() + "," + rsGetTime["hours"].ToString() + "@";
                                        sTimeValues = sTimeValues + rsGetTime["tDate"].ToString() + "," + rsGetTime["hours"].ToString() + "," + rsGetTime["TimeSheet_Status_Name"].ToString() + "@";
                                       
                                     }
                                    rsGetTime.Close();
                                    cmdGetTime.Dispose();
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
                            for (iloop = 0; iloop <= Convert.ToInt32(ContractWeeks); iloop++)
                            {





                                if (iloop == 0)
                                {
                                    MonDate = Convert.ToDateTime(FirstMonday);
                                    SunDate = Convert.ToDateTime(FirstSunday);
                                }
                                else
                                {
                                    MonDate = AddWorkingDays(Convert.ToDateTime(FirstMonday), iloop * 5);
                                    SunDate = AddWorkingDays(Convert.ToDateTime(FirstSunday), iloop * 5);
                                    //MonDate = Convert.ToDateTime(FirstMonday),AddDays(iloop * 7 + 1);
                                }

                                //Monday
                                if (Convert.ToDateTime(MonDate).Day.ToString().Length == 1)
                                {
                                    _sMonday = "0" + Convert.ToDateTime(MonDate).Day.ToString();
                                    _sMondayDay = Convert.ToDateTime(MonDate).Day.ToString();
                                    _sMondayMonth = Convert.ToDateTime(MonDate).Month.ToString();
                                    _sMondayYear = Convert.ToDateTime(MonDate).Year.ToString();
                                }
                                else
                                {
                                    _sMonday = Convert.ToDateTime(MonDate).Day.ToString();
                                }
                                //Tuesday
                                if (Convert.ToDateTime(MonDate).AddDays(1).Day.ToString().Length == 1)
                                {
                                    _sTuesday = "0" + Convert.ToDateTime(MonDate).AddDays(1).Day.ToString();
                                }
                                else
                                {
                                    _sTuesday = Convert.ToDateTime(MonDate).AddDays(1).Day.ToString();
                                }
                                //Wednesday
                                if (Convert.ToDateTime(MonDate).AddDays(2).Day.ToString().Length == 1)
                                {
                                    _sWednesday = "0" + Convert.ToDateTime(MonDate).AddDays(1).Day.ToString();
                                }
                                else
                                {
                                    _sWednesday = Convert.ToDateTime(MonDate).AddDays(2).Day.ToString();
                                }
                                //Thursday
                                if (Convert.ToDateTime(MonDate).AddDays(3).Day.ToString().Length == 1)
                                {
                                    _sThursday = "0" + Convert.ToDateTime(MonDate).AddDays(3).Day.ToString();
                                }
                                else
                                {
                                    _sThursday = Convert.ToDateTime(MonDate).AddDays(3).Day.ToString();
                                }
                                //Friday
                                if (Convert.ToDateTime(MonDate).AddDays(4).Day.ToString().Length == 1)
                                {
                                    _sFriday = "0" + Convert.ToDateTime(MonDate).AddDays(4).Day.ToString();
                                }
                                else
                                {
                                    _sFriday = Convert.ToDateTime(MonDate).AddDays(4).Day.ToString();
                                }
                                //Saturday
                                if (Convert.ToDateTime(MonDate).AddDays(5).Day.ToString().Length == 1)
                                {
                                    _sSaturday = "0" + Convert.ToDateTime(MonDate).AddDays(5).Day.ToString();
                                }
                                else
                                {
                                    _sSaturday = Convert.ToDateTime(MonDate).AddDays(5).Day.ToString();
                                }
                                //Sunday
                                if (Convert.ToDateTime(MonDate).AddDays(6).Day.ToString().Length == 1)
                                {
                                    _sSunday = "0" + Convert.ToDateTime(MonDate).AddDays(6).Day.ToString();
                                }
                                else
                                {
                                    _sSunday = Convert.ToDateTime(MonDate).AddDays(6).Day.ToString();
                                }

                                if (iloop % 2 >= 1)
                                {
                                    enableordisable = "";
                                    _sBackground = "bgcolor='#ECF0F1'";
                                }
                                else
                                {
                                    enableordisable = "disabled";
                                    _sBackground = "";
                                }

                                //load all values from database for this employeeID
                                _dTotal = Convert.ToDouble(CheckValTime(MonDate.AddDays(0).Day.ToString(), MonDate.AddDays(0).Month.ToString(), MonDate.AddDays(0).Year.ToString()).Split(',')[0].ToString()) + Convert.ToDouble(CheckValTime(MonDate.AddDays(1).Day.ToString(), MonDate.AddDays(1).Month.ToString(), MonDate.AddDays(1).Year.ToString()).Split(',')[0].ToString()) + Convert.ToDouble(CheckValTime(MonDate.AddDays(2).Day.ToString(), MonDate.AddDays(2).Month.ToString(), MonDate.AddDays(2).Year.ToString()).Split(',')[0].ToString()) + Convert.ToDouble(CheckValTime(MonDate.AddDays(3).Day.ToString(), MonDate.AddDays(3).Month.ToString(), MonDate.AddDays(3).Year.ToString()).Split(',')[0].ToString()) + Convert.ToDouble(CheckValTime(MonDate.AddDays(4).Day.ToString(), MonDate.AddDays(4).Month.ToString(), MonDate.AddDays(4).Year.ToString()).Split(',')[0].ToString()) + Convert.ToDouble(CheckValTime(MonDate.AddDays(5).Day.ToString(), MonDate.AddDays(5).Month.ToString(), MonDate.AddDays(5).Year.ToString()).Split(',')[0].ToString()) + Convert.ToDouble(CheckValTime(MonDate.AddDays(6).Day.ToString(), MonDate.AddDays(6).Month.ToString(), MonDate.AddDays(6).Year.ToString()).Split(',')[0].ToString());
                                if (_dTotal > 0)
                                {


                                    _sTimeSheetLines = _sTimeSheetLines + "<tr " + _sBackground + ">" +
                                                    "    <td>" + Session["sFullNameClient"].ToString() + "</td>" +
                                                    "    <td>" + Convert.ToInt32(iloop + 1) + "</td>" +
                                                    "    <td>" + DateTime.Parse(MonDate.ToString()).ToString("dd MMM, yyyy") + "</td>" +
                                                    "    <td>" + DateTime.Parse(SunDate.ToString()).ToString("dd MMM, yyyy") + "</td>" +
                                                    "    <td>" +
                                                    "        <div class='input-group'>" +
                                                    "            " + CheckValTime(MonDate.AddDays(0).Day.ToString(), MonDate.AddDays(0).Month.ToString(), MonDate.AddDays(0).Year.ToString()).Split(',')[0].ToString() +
                                                    "        </div>" +
                                                    "    </td>" +
                                                    "    <td>" +
                                                    "        <div class='input-group'>" +
                                                    "          " + CheckValTime(MonDate.AddDays(1).Day.ToString(), MonDate.AddDays(1).Month.ToString(), MonDate.AddDays(1).Year.ToString()).Split(',')[0].ToString() +
                                                    "        </div>" +
                                                    "    </td>" +
                                                    "    <td>" +
                                                    "        <div class='input-group'>" +
                                                    "            " + CheckValTime(MonDate.AddDays(2).Day.ToString(), MonDate.AddDays(2).Month.ToString(), MonDate.AddDays(2).Year.ToString()).Split(',')[0].ToString() +
                                                    "        </div>" +
                                                    "    </td>" +
                                                    "    <td>" +
                                                    "        <div class='input-group'>" +
                                                    "            " + CheckValTime(MonDate.AddDays(3).Day.ToString(), MonDate.AddDays(3).Month.ToString(), MonDate.AddDays(3).Year.ToString()).Split(',')[0].ToString() +
                                                    "        </div>" +
                                                    "    </td>" +
                                                    "    <td>" +
                                                    "        <div class='input-group'>" +
                                                    "           " + CheckValTime(MonDate.AddDays(4).Day.ToString(), MonDate.AddDays(4).Month.ToString(), MonDate.AddDays(4).Year.ToString()).Split(',')[0].ToString() +
                                                    "        </div>" +
                                                    "    </td>" +
                                                    "    <td>" +
                                                    "        <div class='input-group'>" +
                                                    "           " + CheckValTime(MonDate.AddDays(5).Day.ToString(), MonDate.AddDays(5).Month.ToString(), MonDate.AddDays(5).Year.ToString()).Split(',')[0].ToString() +
                                                    "        </div>" +
                                                    "    </td>" +
                                                    "    <td>" +
                                                    "        <div class='input-group'>" +
                                                    "            " + CheckValTime(MonDate.AddDays(6).Day.ToString(), MonDate.AddDays(6).Month.ToString(), MonDate.AddDays(6).Year.ToString()).Split(',')[0].ToString() +
                                                    "        </div>" +
                                                    "    </td>";
                                    _sTimeSheetLines = _sTimeSheetLines + "<td>" + _dTotal + " </td>";
                                    //_sTimeSheetLines = _sTimeSheetLines + "<td><a href='Client_View_Worker.aspx?wopen=Y&p=VW&done=' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-check'></i></a>&nbsp;<a href='Client_View_Worker.aspx?wopen=Y&p=VW&more=' class='btn btn-default btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Request more details'><i class='fa fa-pencil'></i></a>&nbsp;<a href='Client_View_Worker.aspx?wopen=Y&p=VW&Reject=' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a></td>";
                                    //_sTimeSheetLines = _sTimeSheetLines + "<td>" + CheckValTime(MonDate.AddDays(0).Day.ToString(), MonDate.AddDays(0).Month.ToString(), MonDate.AddDays(0).Year.ToString()).Split(',')[1].ToString() + " </td>";
                                    string sAction = CheckValTime(MonDate.AddDays(0).Day.ToString(), MonDate.AddDays(0).Month.ToString(), MonDate.AddDays(0).Year.ToString()).Split(',')[1].ToString();
                                    if (sAction == "Pending Review")
                                    {
                                        //    _sTimeSheetLines = _sTimeSheetLines + "<td><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID="+Request.QueryString["TID"].ToString()+ "&action=Approve&fromD="+ MonDate.AddDays(0).Day.ToString() +"&FromM="+ MonDate.AddDays(0).Month.ToString() +"&FromY="+ MonDate.AddDays(0).Year.ToString() + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve TimeSheet'><i class='fa fa-check'></i></a>&nbsp;<a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + Request.QueryString["TID"].ToString() + "&action=Reject&fromD=" + MonDate.AddDays(0).Day.ToString() + "&FromM=" + MonDate.AddDays(0).Month.ToString() + "&FromY=" + MonDate.AddDays(0).Year.ToString() + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                                        _sTimeSheetLines = _sTimeSheetLines + "<td><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + Request.QueryString["TID"].ToString() + "&action=Approve&fromD=" + MonDate.AddDays(0).Day.ToString() + "&FromM=" + MonDate.AddDays(0).Month.ToString() + "&FromY=" + MonDate.AddDays(0).Year.ToString() + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve TimeSheet'><i class='fa fa-check'></i></a>&nbsp;<a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + Request.QueryString["TID"].ToString() + "&action=Reject&fromD=" + MonDate.AddDays(0).Day.ToString() + "&FromM=" + MonDate.AddDays(0).Month.ToString() + "&FromY=" + MonDate.AddDays(0).Year.ToString() + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                                    }
                                    else
                                    {
                                        _sTimeSheetLines = _sTimeSheetLines + "<td>" + CheckValTime(MonDate.AddDays(0).Day.ToString(), MonDate.AddDays(0).Month.ToString(), MonDate.AddDays(0).Year.ToString()).Split(',')[1].ToString() + " </td>";
                                    }
                                    _sTimeSheetLines = _sTimeSheetLines + "</tr>";

                                }
                            }
                        }
                        else
                        {
                          
                            _sListofWorkers1 = _sListofWorkers1 + " <tr>" +
                                                          " <td>" +
                                                          " <a class='btn btn-primary' href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + rsGetListOfWorker["employee_id"] + "'><i class='icon-user-1'></i> " + rsGetListOfWorker["first_name"].ToString() + " " + rsGetListOfWorker["last_name"].ToString() + "</a>" +
                                                          " </td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " <td></td>" +
                                                          " </tr>";

                        }
                        //lblTimeSheet.Text = _sTimeSheetLines;

                    }
                    
                    if (EmployeeID == "")
                    {
                        _sListofWorkers = _sListofWorkers + " <tr>" +
                                                            " <td>" +
                                                            " <a class='btn btn-primary' href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + rsGetListOfWorker["employee_id"] + "'><i class='icon-user-1'></i> " + rsGetListOfWorker["first_name"].ToString() + " " + rsGetListOfWorker["last_name"].ToString() + "</a>" +
                                                            " </td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                            " <td></td>" +
                                                              " <td></td>" +
                                                            " </tr>";
                                                            

                    }                 
                        
                    
                }
                rsGetListOfWorker.Close();
                cmdGetListofWorkers.Dispose();
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
        
        if (EmployeeID == "") //first load
        {
            lblNames.Text = _sListofWorkers;
        }
        //second and other loads
        if (EmployeeID != "")
            lblNames.Text = _sTimeSheetLines + "</tr><tr></tr>" +  _sListofWorkers1;




    }
    public void GetEmployeeID()
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
                string sqlGetEmployeeIDForJob = " select employee_ID " +
                                             " from ovms_employees " +
                                             " where job_id =  " + Session["JobID"].ToString().Trim() + "  " +
                                             " and user_id = " + Session["UserID"].ToString();
                SqlCommand cmdEmployeeID = new SqlCommand(sqlGetEmployeeIDForJob, conn);
                SqlDataReader rsGetEmployeeID = cmdEmployeeID.ExecuteReader();
                //string _svendorList = "";
                while (rsGetEmployeeID.Read())
                {
                    Session["EmployeeIDForJob"] = rsGetEmployeeID["employee_ID"].ToString();
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
    public string GetNumberOfWeeks()
    {
        string _sArrayString = "";
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();




                API.Service timesheet = new API.Service();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml("<XML>" + timesheet.Add_TimeSheet(Session["EmailClient"].ToString(), Session["P@ssClient"].ToString(), Session["UserIDClient"].ToString()).InnerXml + "</XML>");
                string FileName = Server.MapPath("temp") + "\\response_get_timesheet_" + DateTime.Now.Millisecond.ToString() + ".xml";
                XmlNodeList Response = xmldoc.SelectNodes("XML/RESPONSE/TIMESHEET");
                // string weeks;
                // string timesheetVariable = "";
                string jobID = "";
                jobID = Response[0].SelectSingleNode("JOB_ID").InnerText;
                Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetStartEndWeeks = " select contract_Start_date, contract_end_date, " +
                                        " DATEDIFF(wk, contract_Start_date, contract_end_date + 7) as Num_weeks " +
                                        " from ovms_jobs where job_id =  " + Session["JobID"].ToString().Trim();
                SqlCommand cmdStartEndWeeks = new SqlCommand(sqlGetStartEndWeeks, conn);
                SqlDataReader rsStartEndWeeks = cmdStartEndWeeks.ExecuteReader();
                //string _svendorList = "";
                while (rsStartEndWeeks.Read())
                {
                    _sArrayString = rsStartEndWeeks["contract_Start_date"].ToString() + "," + rsStartEndWeeks["contract_end_date"].ToString() + "," + rsStartEndWeeks["Num_weeks"].ToString();
                }
                rsStartEndWeeks.Close();
                cmdStartEndWeeks.Dispose();
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
        return _sArrayString;
    }
    public string GetMonday(string StartDate)
    {
        string _sStartDate = "";
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string sqlGetStartDate = " select DATEADD(DD, 1 - DATEPART(DW, '" + StartDate + "'), '" + StartDate + "') + 1 as startd ";
                SqlCommand cmdGetStartDate = new SqlCommand(sqlGetStartDate, conn);
                SqlDataReader rsGetStartDate = cmdGetStartDate.ExecuteReader();
                //string _svendorList = "";
                while (rsGetStartDate.Read())
                {
                    _sStartDate = rsGetStartDate["startd"].ToString();
                }
                rsGetStartDate.Close();
                cmdGetStartDate.Dispose();
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
        return _sStartDate;
    }
    public string GetSunday(string StartDate)
    {
        string _sEndDate = "";
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string sqlGetEndDate = " select DATEADD(DAY , 7-DATEPART(WEEKDAY,'" + StartDate + "'),'" + StartDate + "') + 1  as endd ";
                SqlCommand cmdGetEndDate = new SqlCommand(sqlGetEndDate, conn);
                SqlDataReader rsGetEndDate = cmdGetEndDate.ExecuteReader();
                //string _svendorList = "";
                while (rsGetEndDate.Read())
                {
                    _sEndDate = rsGetEndDate["endd"].ToString();
                }
                rsGetEndDate.Close();
                cmdGetEndDate.Dispose();
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
        return _sEndDate;
    }

    protected void Send3_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {

            Response.Redirect("c_timesheet_action.aspx?TID=" + Request.QueryString["TID"].ToString() + " &action=" + Request.QueryString["action"].ToString() + "&fromD=" + Request.QueryString["fromD"].ToString() + "&FromM=" + Request.QueryString["FromM"].ToString() + " &FromY=" + Request.QueryString["FromY"].ToString() + "&ModalAction=Y");
        }

    }


    protected void Send4_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {

            Response.Redirect("c_timesheet_action.aspx?TID=" + Request.QueryString["TID"].ToString() + " &action=" + Request.QueryString["action"].ToString() + "&fromD=" + Request.QueryString["fromD"].ToString() + "&FromM=" + Request.QueryString["FromM"].ToString() + " &FromY=" + Request.QueryString["FromY"].ToString() + "&ModalAction=Y");

        }
    }
}