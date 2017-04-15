using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class C_TimesheetApproval : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        string sTable = "";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

        
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

                        string strGetHours = "select sum(a.hours) as hours_total from ovms_timesheet a,  " + 
                                             " ovms_timesheet_details b where a.employee_id = employee_id  " +
                                             " and a.timesheet_id = b.timesheet_id and a.active = 1 and b.active = 1  " +
                                             " and b.timesheet_status_id = 3  " +
                                             " and a.employee_id = " +  readerGetTimeSheets["employee_ID"].ToString() + " " +
                                             " and DatePart(week, dateadd(d, -1, CONCAT(a.month, '-', a.day, '-', a.year))) = " + readerGetTimeSheets["weeknum"].ToString() + " ";
                        SqlCommand cmdGetHours = new SqlCommand(strGetHours, conn);
                        SqlDataReader rsGetHours = cmdGetHours.ExecuteReader();
                        while (rsGetHours.Read())
                        {
                            string hours = readerGetTimeSheets["HOURS_REPORTED"].ToString();
                            string chk = "1";
                            string chk2 = "1";

                            //DateTime.Parse(readerGetTimeSheets["DATE+_FROM"].ToString()).ToString("dd MMM, yyyy") +
                            string sAction = readerGetTimeSheets["timesheet_status"].ToString();
                            sTable = sTable + "<tr>";
                            sTable = sTable + "<td>" + func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString()) + "<p>(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ")</p></td> ";
                            //sTable = sTable + "<td>" + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + " </td> ";
                            sTable = sTable + "<td>" + rsGetHours["hours_total"].ToString() + " </td> ";                        //sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=123&action=Approve&fromD=1&FromM=1&FromY=1' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve TimeSheet'><i class='fa fa-check'></i></a>&nbsp;<a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=1&action=Reject&fromD=1&FromM=1&FromY=1' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                            sTable = sTable + "<td class='text-right width-100'><a target='_blank' href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + readerGetTimeSheets["employee_id"].ToString() + "' class='btn btn-warning btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='View Details'><i class='fa fa-table'></i></a>&nbsp;<a target='_blank'  href='C_TimeSheet_View.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&chk=" + chk + "&time=" + hours + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + " (" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve Timesheet'><i class='fa fa-check'></i></a>&nbsp;<a target='_blank'  href='C_TimeSheet_View.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&chk2=" + chk2 + "&time=" + hours + "&action2=reject&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + "(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-danger btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Reject Timesheet'><i class='fa fa-times'></i></a>&nbsp;</i></a></td>";
                            //sTable = sTable + "<td class='text-right width-100'><a href='C_TimeSheet_View.aspx?topen=Y&p=VT&TID=" + readerGetTimeSheets["employee_id"].ToString() + "' class='btn btn-warning btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='View Details'><i class='fa fa-table'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "&Mess=" + Server.UrlEncode(func.FixString(readerGetTimeSheets["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetTimeSheets["LAST_NAME"].ToString())) + "(" + DateTime.Parse(readerGetTimeSheets["DATE_FROM"].ToString()).ToString("dd MMM, yyyy") + " - " + DateTime.Parse(readerGetTimeSheets["DATE_TO"].ToString()).ToString("dd MMM, yyyy") + ") for " + string.Format("{0:c0}", Convert.ToDouble(readerGetTimeSheets["PAY_RATE"].ToString()) * Convert.ToDouble(readerGetTimeSheets["HOURS_REPORTED"].ToString())) + "' class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Approve Timesheet'><i class='fa fa-check'></i></a>&nbsp;<a href='Client.aspx?TID=" + readerGetTimeSheets["employee_id"].ToString() + "&action=Approve&fromD=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Day.ToString() + "&FromM=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Month.ToString() + "&FromY=" + Convert.ToDateTime(readerGetTimeSheets["date_from"].ToString()).Year.ToString() + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject TimeSheet'><i class='fa fa-times'></i></a></td>";
                            //sTable = sTable = "<td>12</td>";
                            //C_TimeSheet_View.aspx?topen=Y&p=VT&TID=1
                            sTable = sTable + "</tr>";
                        }
                        //close
                        rsGetHours.Close();
                        cmdGetHours.Dispose();
                       



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


    }

   
}