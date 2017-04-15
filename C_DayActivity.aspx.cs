using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class C_DayActivity : System.Web.UI.Page
{
    DateTime sDate;
    string sJobCount = "";
    SqlConnection conn;
    StringFunctions func = new StringFunctions();
    string sEmployeee = "";
    string s8AMText = "";
    string s9AMText = "";
    string s10AMText = "";
    string s11AMText = "";
    string s12PMText = "";
    string s1PMText = "";
    string s2PMText = "";
    string s3PMText = "";
    string s4PMText = "";
    string s5PMText = "";
    string s6PMText = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //sDate = DateTime.Today;
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
       

        lblDate.Text = DateTime.Today.DayOfWeek.ToString() + ", " +
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month).ToString() + " " +
                            DateTime.Today.Day.ToString() + " " +
                            DateTime.Today.Year.ToString();

        //if (Request["sPReviousDate"] != null)
        //{
        //    sDate = Convert.ToDateTime(Request["sPReviousDate"].ToString());
        //    //       lblDate.Text = Convert.ToDateTime(Request["sPReviousDate"].ToString()).DayOfWeek.ToString() + ", " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToDateTime(Request["sPReviousDate"].ToString()).Month).ToString() + " " + Convert.ToDateTime(Request["sPReviousDate"].ToString()).Day.ToString() + " " + Convert.ToDateTime(Request["sPReviousDate"].ToString()).Year.ToString();
        //}
        //if (Request["sNextDate"] != null)
        //{
        //    sDate = Convert.ToDateTime(Request["sNextDate"].ToString());
        //    //       lblDate.Text = Convert.ToDateTime(Request["sPReviousDate"].ToString()).DayOfWeek.ToString() + ", " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToDateTime(Request["sPReviousDate"].ToString()).Month).ToString() + " " + Convert.ToDateTime(Request["sPReviousDate"].ToString()).Day.ToString() + " " + Convert.ToDateTime(Request["sPReviousDate"].ToString()).Year.ToString();
        //}
        //lblDate.Text = sDate.DayOfWeek.ToString() + ", " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(sDate.Month).ToString() + " " + sDate.Day.ToString() + " " + sDate.Year.ToString();

        if (Request["sPReviousDate"] != null)
        {
            lblDate.Text = Convert.ToDateTime(Request["sPReviousDate"]).DayOfWeek.ToString() + ", " +
                       CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToDateTime(Request["sPReviousDate"]).Month).ToString() + " " +
                       Convert.ToDateTime(Request["sPReviousDate"]).Day.ToString() + " " +
                       Convert.ToDateTime(Request["sPReviousDate"]).Year.ToString();
        }
        else if (Request["sNextDate"] != null)
        {
            lblDate.Text = Convert.ToDateTime(Request["sNextDate"]).DayOfWeek.ToString() + ", " +
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToDateTime(Request["sNextDate"]).Month).ToString() + " " +
                            Convert.ToDateTime(Request["sNextDate"]).Day.ToString() + " " +
                            Convert.ToDateTime(Request["sNextDate"]).Year.ToString();
        }
        else
        {
            lblDate.Text = DateTime.Today.DayOfWeek.ToString() + ", " +
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month).ToString() + " " +
                            DateTime.Today.Day.ToString() + " " +
                            DateTime.Today.Year.ToString();
        }
        sDate = Convert.ToDateTime(lblDate.Text);

        if (!IsPostBack)
        {
            GetSubmittedCandidate();
            //GetNoActionCandidates();
            GetInterviewCount();
            GetCancelInterviewCount();
            GetContractStart();
            GetContractEnd();
            GetNewCandidate();
            GetPausedJobs();
            //GetAbsenceRequest();
            GetCandidateApproval();
            GetCandidateRejected();
        }
    }


    public void GetSubmittedCandidate()
    {
        string sDates = "";
        string sDateDetails = "";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

        try
        {
            if(conn.State==System.Data.ConnectionState.Closed)
            {
                conn.Open();

                //string sqlGetSubmittedCandidateDate = "select distinct e.create_date" +
                //                        " from ovms_employees as e " +
                //                        " join ovms_employee_details as ed on ed.employee_id=e.employee_id " +
                //                        " left join ovms_employee_actions as ea on ea.employee_id=e.employee_id " +
                //                        " where e.employee_id not in (SELECT employee_id from ovms_employee_actions) " +
                //                         "  and ea.client_id = " + Session["ClientID"].ToString() + 
                //                        " and ed.active=1 ";

                string sqlGetSubmittedCandidateDate = "select distinct e.create_date" +
                                        " from ovms_employees as e " +
                                        " join ovms_employee_details as ed on ed.employee_id=e.employee_id " +
                                        " left join ovms_employee_actions as ea on ea.employee_id=e.employee_id " +
                                        " where e.employee_id not in (SELECT employee_id from ovms_employee_actions) " +
                                        " and ed.active=1 and e.client_id= " + Session["ClientID"].ToString();

                SqlCommand cmdGetSubmittedCandidateDate = new SqlCommand(sqlGetSubmittedCandidateDate, conn);
                SqlDataReader rsGetSubmittedCandidateDate = cmdGetSubmittedCandidateDate.ExecuteReader();

                string sPopulateDrop = "";

                if (rsGetSubmittedCandidateDate.HasRows == true)
                {

                    //lblNoFeedback.Text = "Feedback Needed on: ";
                    //get all dates
                    sDates = "";

                    while (rsGetSubmittedCandidateDate.Read())
                    {
                        sDates = sDates + "<optgroup label='" + rsGetSubmittedCandidateDate["create_date"].ToString().Replace("12:00:00 AM", "") + "'>here";
                        //Details for the sDate in the dropdown list- change getdate to sDate

                        //string sqlGetSubmittedCandidate = "select concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),e.employee_id),4)) as emp_alias, " +
                        //                                " dbo.CamelCase(ed.First_Name) as First_Name, dbo.CamelCase(ed.Last_Name) as Last_Name, " +
                        //                                " e.employee_id,e.job_id,j.job_title, dbo.CamelCase(ed.First_Name) + ' ' + dbo.CamelCase(ed.Last_Name) as candidate_name,e.create_date " +
                        //                                " from ovms_employees as e " +
                        //                                " join ovms_employee_details as ed on ed.employee_id=e.employee_id " +
                        //                                " join ovms_jobs as j on j.job_id=e.job_id " +
                        //                                " left join ovms_employee_actions as ea on ea.employee_id=e.employee_id " +
                        //                                " join ovms_clients as clt on clt.client_id=e.client_id " +
                        //                                " where e.employee_id not in (SELECT employee_id from ovms_employee_actions) " +
                        //                                " and ed.active=1 " +
                        //                                 //"  ea.client_id = " + Session["ClientID"].ToString() + 
                        //                                 " and ed.create_date = '" + rsGetSubmittedCandidateDate["create_date"].ToString() + "'"; 

                        string sqlGetSubmittedCandidate = "select concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),e.employee_id),4)) as emp_alias, " +
                                                        " dbo.CamelCase(ed.First_Name) as First_Name, dbo.CamelCase(ed.Last_Name) as Last_Name, " +
                                                        " e.employee_id,e.job_id,j.job_title, dbo.CamelCase(ed.First_Name) + ' ' + dbo.CamelCase(ed.Last_Name) as candidate_name,e.create_date " +
                                                        " from ovms_employees as e " +
                                                        " join ovms_employee_details as ed on ed.employee_id=e.employee_id " +
                                                        " join ovms_jobs as j on j.job_id=e.job_id " +
                                                        " left join ovms_employee_actions as ea on ea.employee_id=e.employee_id " +
                                                        " join ovms_clients as clt on clt.client_id=e.client_id " +
                                                        " where e.employee_id not in (SELECT employee_id from ovms_employee_actions) " +
                                                        " and ed.active=1 " +
                                                         " and ed.create_date = '" + rsGetSubmittedCandidateDate["create_date"].ToString() + "'";

                        SqlCommand cmdGetSubmittedCandidate = new SqlCommand(sqlGetSubmittedCandidate, conn);
                        SqlDataReader rsGetSubmittedCandidate = cmdGetSubmittedCandidate.ExecuteReader();
                        sDateDetails = "";
                        while (rsGetSubmittedCandidate.Read())
                        {
                            sDateDetails = sDateDetails + "<option value='" + rsGetSubmittedCandidate["employee_id"].ToString() + "'>" +
                                           //rsGetSubmittedCandidate["First_Name"].ToString() +
                                           //" " + rsGetSubmittedCandidate["Last_Name"].ToString() + 
                                           rsGetSubmittedCandidate["candidate_name"].ToString() +
                                           " for " + rsGetSubmittedCandidate["job_Title"].ToString() + "</option>";
                        }
                        //close

                        rsGetSubmittedCandidate.Close();
                        cmdGetSubmittedCandidate.Dispose();

                        sDates = sDates + sDateDetails + "</optgroup>";

                    }
                    sPopulateDrop = sDates + sPopulateDrop;
                    //sEmployeee = "<optgroup label='No Feedback on:'> " + sEmployeee + " </optgroup>";


                }
                //Close()
                rsGetSubmittedCandidateDate.Close();
                cmdGetSubmittedCandidateDate.Dispose();

                lblselNoAction.Text = sDates;

            }
        }

        catch(Exception e)
        {

        }
        finally
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }

    //public void GetNoActionCandidates()
    //{
    //    string sDates = "";
    //    string sDateDetails = "";
    //    //select employee_ID from ovms_employees where job_id = 5 and user_id = 20
    //    //select first_name, last_name, email_id from ovms_users where user_id = 9
    //    conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
    //    try
    //    {
    //        if (conn.State == System.Data.ConnectionState.Closed)
    //        {
    //            conn.Open();

    //            // Session["JobID"] = jobID.ToString();

    //            //start, end and weeks
    //            //string sqlGetJobCountNoAction = " select distinct ed.employee_id, ed.create_date, " +
    //            //                               " dbo.CamelCase(ed.First_Name) as First_Name, " +
    //            //                               " (dbo.CamelCase(ed.First_Name) + ' ' + dbo.CamelCase(ed.Last_Name) + ' submitted on: ' + convert(nvarchar(500),ed.create_date)) as FullName, " +
    //            //                               " dbo.CamelCase(ed.Last_Name) as Last_Name, " +
    //            //                               " em.vendor_id, em.client_Id, em.job_id,em.user_id " +
    //            //                               " from ovms_employee_details ed, ovms_employees em, ovms_employee_actions ea " +
    //            //                               " where ed.employee_id = em.employee_id " +
    //            //                               " and ed.create_date <= getdate() - 1 " +
    //            //                               " and ed.active = 1 " +
    //            //                               " and em.active = 1 " +
    //            //                               " and ea.client_id = em.client_id " +
    //            //                               " and em.client_id = " + Session["ClientID"].ToString() + " " +
    //            //                               " and ea.employee_id<> em.employee_id " +
    //            //                               " and ed.first_name <> '' " +
    //            //                               " and em.vendor_id = " + Session["VendorID"].ToString() + " " +
    //            //                               " order by ed.create_date desc";


    //            //Add sDate for createdate<sDate  --  Change getdate() to sDate
    //            string sqlGetJobCountNoAction = " select distinct  ed.create_date " +
    //                                           " from ovms_employee_details ed, ovms_employees em, ovms_employee_actions ea " +
    //                                         " where ed.employee_id = em.employee_id " +
    //                                         " and ed.create_date <= '" + sDate + "' " +
    //                                         " and ed.active = 1 " +
    //                                         " and em.active = 1 " +
    //                                         " and ea.client_id = em.client_id " +
    //                                         " and em.client_id = " + Session["ClientID"].ToString() + " " +
    //                                         " and em.employee_id not in (select employee_id from ovms_employee_actions as ea ) " +
    //                                         " and ed.first_name <> '' " +
    //                                         " order by ed.create_date asc";
    //            SqlCommand cmdGetNoAction = new SqlCommand(sqlGetJobCountNoAction, conn);
    //            SqlDataReader rsGetNoAction = cmdGetNoAction.ExecuteReader();

    //            string sPopulateDrop = "";
    //            if (rsGetNoAction.HasRows == true)
    //            {

    //                //lblNoFeedback.Text = "Feedback Needed on: ";
    //                //get all dates
    //                sDates = "";

    //                while (rsGetNoAction.Read())
    //                {
    //                    sDates = sDates + "<optgroup label='" + rsGetNoAction["create_date"].ToString().Replace("12:00:00 AM", "") + "'>here";
    //                    //" < option value='" + rsGetNoAction["create_date"].ToString() + "'>";
    //                    //go through and get all details
    //                    //string sqlGetActionDetailsNoFeedback = " select distinct ed.employee_id, ed.create_date, " +
    //                    //                               " (select job_title from ovms_jobs where job_id  = (select job_id from ovms_employees where employee_id = ed.employee_id)) as job_Title, " +
    //                    //                               " dbo.CamelCase(ed.First_Name) as First_Name, " +
    //                    //                               " (dbo.CamelCase(ed.First_Name) + ' ' + dbo.CamelCase(ed.Last_Name) + ' submitted on: ' + convert(nvarchar(500),ed.create_date)) as FullName, " +
    //                    //                               " dbo.CamelCase(ed.Last_Name) as Last_Name, " +
    //                    //                               " em.vendor_id, em.client_Id, em.job_id,em.user_id " +
    //                    //                               " from ovms_employee_details ed, ovms_employees em, ovms_employee_actions ea " +
    //                    //                               " where ed.employee_id = em.employee_id " +
    //                    //                               " and ed.create_date <= getdate() - 1 " +
    //                    //                               " and ed.active = 1 " +
    //                    //                               " and em.active = 1 " +
    //                    //                               " and ea.client_id = em.client_id " +
    //                    //                               " and em.client_id = " + Session["ClientID"].ToString() + " " +
    //                    //                               " and em.employee_id not in (select employee_id from ovms_employee_actions as ea ) " +
    //                    //                               " and ed.first_name <> '' " +
    //                    //                               " and ed.create_date = '" + rsGetNoAction["create_date"].ToString() + "'";

    //                    //Details for the sDate in the dropdown list- change getdate to sDate
    //                    string sqlGetActionDetailsNoFeedback = " select distinct ed.employee_id, ed.create_date, " +
    //                                                  " (select job_title from ovms_jobs where job_id  = (select job_id from ovms_employees where employee_id = ed.employee_id)) as job_Title, " +
    //                                                  " dbo.CamelCase(ed.First_Name) as First_Name, " +
    //                                                  " (dbo.CamelCase(ed.First_Name) + ' ' + dbo.CamelCase(ed.Last_Name) + ' submitted on: ' + convert(nvarchar(500),ed.create_date)) as FullName, " +
    //                                                  " dbo.CamelCase(ed.Last_Name) as Last_Name, " +
    //                                                  " em.vendor_id, em.client_Id, em.job_id,em.user_id " +
    //                                                  " from ovms_employee_details ed, ovms_employees em, ovms_employee_actions ea " +
    //                                                  " where ed.employee_id = em.employee_id " +
    //                                                  " and ed.create_date <= Convert(DateTime,'" + sDate.ToString() + "') " +
    //                                                  " and ed.active = 1 " +
    //                                                  " and em.active = 1 " +
    //                                                  " and ea.client_id = em.client_id " +
    //                                                  " and em.client_id = " + Session["ClientID"].ToString() + " " +
    //                                                  " and em.employee_id not in (select employee_id from ovms_employee_actions as ea ) " +
    //                                                  " and ed.first_name <> '' " +
    //                                                  " and ed.create_date = '" + rsGetNoAction["create_date"].ToString() + "'";

    //                    SqlCommand cmdActionDetails = new SqlCommand(sqlGetActionDetailsNoFeedback, conn);
    //                    SqlDataReader rsGetNoActionDetails = cmdActionDetails.ExecuteReader();
    //                    sDateDetails = "";
    //                    while (rsGetNoActionDetails.Read())
    //                    {
    //                        sDateDetails = sDateDetails + "<option value='0'>" + rsGetNoActionDetails["First_Name"].ToString() + " " + rsGetNoActionDetails["Last_Name"].ToString() + " for " + rsGetNoActionDetails["job_Title"].ToString() + "</option>";
    //                    }
    //                    //close

    //                    rsGetNoActionDetails.Close();
    //                    cmdActionDetails.Dispose();

    //                    sDates = sDates + sDateDetails + "</optgroup>";

    //                }
    //                sPopulateDrop = sDates + sPopulateDrop;
    //                //sEmployeee = "<optgroup label='No Feedback on:'> " + sEmployeee + " </optgroup>";


    //            }
    //            //Close()
    //            rsGetNoAction.Close();
    //            cmdGetNoAction.Dispose();

    //            lblselNoAction.Text = sDates;


    //        }
    //        //selEmployee.Items.Insert(0, new ListItem("-- Select Worker --", "0"));
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


    

    public void GetInterviewCount()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                //string sqlGetInterviewCount = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
                //                              " dbo.GetJobNo(ea.employee_id) as job_num, " +
                //                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                //                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                //                              "  and eac.employee_id = ea.employee_id " +
                //                              "  and ea.active = 1 " +
                //                              "  and eac.active = 1 " +
                //                              "  and convert(datetime, ea.interview_date) between Convert(DateTime,'" + sDate.ToString() + "') - 1 and getdate() + 7  ";

                //Change the getdate() to sDate to check the interviews between sDate - 1 and sDate + 7
                string sqlGetInterviewCount = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                                              " dbo.GetJobNo(job_id) as job_num, " +
                                              " concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),eac.employee_id),4)) as emp_id, " +
                                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title " +
                                              " from ovms_employee_actions ea, ovms_employee_details eac, ovms_clients as clt  " +
                                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                              "  and eac.employee_id = ea.employee_id " +
                                              " and ea.client_id=clt.client_id " +
                                              "  and ea.active = 1 " +
                                              "  and eac.active = 1 " +
                                              //" and ea.interview_confirm=1 " +
                                              "  and convert(datetime, ea.interview_date) between Convert(DateTime,'" + sDate.ToString() + "') - 1 and Convert(DateTime,'" + sDate.ToString() + "') + 7  ";


                SqlCommand cmdInterviewCount = new SqlCommand(sqlGetInterviewCount, conn);
                SqlDataReader rsInterviewCount = cmdInterviewCount.ExecuteReader();
                //string _svendorList = "";
                int iCount = 0;
        
                while (rsInterviewCount.Read())
                {
                    //interview status
                    string iRequested = rsInterviewCount["interview_requested"].ToString();
                    string iCancelled = rsInterviewCount["interview_cancel_by_client"].ToString();
                    string iConfirmed = rsInterviewCount["interview_confirm"].ToString();
                    string iReschedule = rsInterviewCount["interview_resheduled"].ToString();

                    //increment count
                    // iCount = iCount + 1;
                    //get date of interview
                    if (Convert.ToDateTime(rsInterviewCount["interview_date"].ToString()) == sDate)
                    {
                        if (iConfirmed == "1")
                        {

                            if (rsInterviewCount["interview_time"].ToString().Trim() == "8:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "8:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "8:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "8:45 AM")
                            {
                                s8AMText = s8AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: "+
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "9:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "9:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "9:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "9:45 AM")
                            {
                                s9AMText = s9AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: "+
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "10:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "10:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "10:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "10:45 AM")
                            {
                                s10AMText = s10AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                                " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "11:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "11:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "11:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "11:45 AM")
                            {
                                s11AMText = s11AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "12:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "12:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "12:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "12:45 AM")
                            {
                                s12PMText = s12PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "1:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "1:15 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "1:30 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "1:45 PM")
                            {
                                s1PMText = s1PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "2:00 PM"|| rsInterviewCount["interview_time"].ToString().Trim() == "2:15 PM"|| rsInterviewCount["interview_time"].ToString().Trim() == "2:30 PM"|| rsInterviewCount["interview_time"].ToString().Trim() == "2:45 PM")
                            {
                                s2PMText = s2PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "3:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "3:15 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "3:30 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "3:45 PM")
                            {
                                s3PMText = s3PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "4:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "4:15 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "4:30 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "4:45 PM")
                            {
                                s4PMText = s4PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "5:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "5:15 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "5:30 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "5:45 PM")
                            {
                                s5PMText = s5PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview confirmed: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                               " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-green-900'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            lbl8am.Text = s8AMText;
                            lbl9am.Text = s9AMText;
                            lbl10am.Text = s10AMText;
                            lbl11am.Text = s11AMText;
                            lbl12pm.Text = s12PMText;
                            lbl1pm.Text = s1PMText;
                            lbl2pm.Text = s2PMText;
                            lbl3pm.Text = s3PMText;
                            lbl4pm.Text = s4PMText;
                            lbl5pm.Text = s5PMText;
                        }

                        //Reschedule
                        else if (iReschedule =="1" && iConfirmed == "")
                        {

                            if (rsInterviewCount["interview_time"].ToString().Trim() == "8:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "8:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "8:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "8:45 AM")
                            {
                                s8AMText = s8AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "9:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "9:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "9:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "9:45 AM")
                            {
                                s9AMText = s9AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                            " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "10:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "10:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "10:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "10:45 AM")
                            {
                                s10AMText = s10AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "11:00 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "11:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "11:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "11:45 AM")
                            {
                                s11AMText = s11AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                            " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "12:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "12:15 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "12:30 AM" || rsInterviewCount["interview_time"].ToString().Trim() == "12:45 AM")
                            {
                                s12PMText = s12PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                            " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "1:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "1:15 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "1:30 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "1:45 PM")
                            {
                                s1PMText = s1PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "2:00 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "2:15 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "2:30 PM" || rsInterviewCount["interview_time"].ToString().Trim() == "2:45 PM")
                            {
                                s2PMText = s2PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                            " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "3:00 PM")
                            {
                                s3PMText = s3PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "4:00 PM")
                            {
                                s4PMText = s4PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (rsInterviewCount["interview_time"].ToString().Trim() == "5:00 PM")
                            {
                                s5PMText = s5PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Interview rescheduled: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsInterviewCount["first_name"].ToString()) + " " + func.FixString(rsInterviewCount["last_name"].ToString()) + "</a>" +
                                            " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsInterviewCount["job_num"].ToString() + "' class='text-warning'>" + (rsInterviewCount["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            lbl8am.Text = s8AMText;
                            lbl9am.Text = s9AMText;
                            lbl10am.Text = s10AMText;
                            lbl11am.Text = s11AMText;
                            lbl12pm.Text = s12PMText;
                            lbl1pm.Text = s1PMText;
                            lbl2pm.Text = s2PMText;
                            lbl3pm.Text = s3PMText;
                            lbl4pm.Text = s4PMText;
                            lbl5pm.Text = s5PMText;
                        }

                    }
                }
                rsInterviewCount.Close();
                cmdInterviewCount.Dispose();
                //sInterviewCount = iCount.ToString();
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

    public void GetCancelInterviewCount()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //Change the getdate() to sDate to check the interviews between sDate - 1 and sDate + 7
                string sqlGetCancelInterviewCount = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                                              " dbo.GetJobNo(job_id) as job_num, " +
                                             " concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),eac.employee_id),4)) as emp_id, " +
                                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title " +
                                              " from ovms_employee_actions ea, ovms_employee_details eac, ovms_clients as clt  " +
                                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                              "  and eac.employee_id = ea.employee_id " +
                                              " and ea.client_id=clt.client_id " +
                                              "  and ea.active = 1 " +
                                              "  and eac.active = 1 " +
                                              "  and convert(datetime, interview_cancel_by_client_time) between Convert(DateTime,'" + sDate.ToString() + "') - 1 and Convert(DateTime,'" + sDate.ToString() + "') + 7  ";

                SqlCommand cmdCancelInterviewCount = new SqlCommand(sqlGetCancelInterviewCount, conn);
                SqlDataReader rsCancelInterviewCount = cmdCancelInterviewCount.ExecuteReader();
                //string _svendorList = "";
                int iCount = 0;
                //string s8AMText = "";
                //string s9AMText = "";
                //string s10AMText = "";
                //string s11AMText = "";
                //string s12PMText = "";
                //string s1PMText = "";
                //string s2PMText = "";
                //string s3PMText = "";
                //string s4PMText = "";
                //string s5PMText = "";
                //string s6PMText = "";

                while (rsCancelInterviewCount.Read())
                {
                    //interview status
                    string iCancelled = rsCancelInterviewCount["interview_cancel_by_client"].ToString();
                    string Cancelled = Convert.ToDateTime(rsCancelInterviewCount["interview_cancel_by_client_time"]).AddHours(-1).ToShortTimeString();
                    string cancel_time = rsCancelInterviewCount["interview_cancel_by_client_time"].ToString();
                    //string canceltime = Convert.ToDateTime(rsCancelInterviewCount["interview_cancel_by_client_time"]).ToShortTimeString();
                    string canceltime = Convert.ToDateTime(Cancelled).ToString(@"hh:00 tt", new CultureInfo("en-US"));
                    //if(canceltime=="12:00 PM")
                    //{

                    //}
                    //increment count
                    // iCount = iCount + 1;
                    //get date of interview
                    if (Convert.ToDateTime(cancel_time).Date == sDate)
                    {
                        //rsInterviewCount["interview_time"].ToString().Trim() == "8:00 AM"
                        ////////
                        if (iCancelled == "1")
                        {

                            if (canceltime.Trim() == "08:00 AM")
                            {
                                s8AMText = s8AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (canceltime == "09:00 AM")
                            {
                                s9AMText = s9AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (canceltime.Trim() == "10:00 AM")
                            {
                                s10AMText = s10AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (canceltime.Trim() == "11:00 AM")
                            {
                                s11AMText = s11AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (canceltime.Trim() == "12:00 PM")
                            {
                                s12PMText = s12PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (canceltime.Trim() == "01:00 PM")
                            {
                                s1PMText = s1PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            if (canceltime.Trim() == "02:00 PM")
                            {
                                s2PMText = s2PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            if (canceltime.Trim() == "03:00 PM")
                            {
                                s3PMText = s3PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            if (canceltime.Trim() == "04:00 PM")
                            {
                                s4PMText = s4PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            if (canceltime.Trim() == "05:00 PM")
                            {
                                s5PMText = s5PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right text-warning strong'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCancelInterviewCount["job_num"].ToString() + "' class='btn btn-warning'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +
                                              "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Interview cancelled for:</b> </span>" + rsCancelInterviewCount["job_title"].ToString() + " -  " +
                                               "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCancelInterviewCount["emp_id"].ToString() + "' class='text-warning strong'>" +
                                              "" + func.FixString(rsCancelInterviewCount["first_name"].ToString()) + " " + func.FixString(rsCancelInterviewCount["last_name"].ToString()) + "</a>" +
                                              "</div>";
                            }
                            lbl8am.Text = s8AMText;
                            lbl9am.Text = s9AMText;
                            lbl10am.Text = s10AMText;
                            lbl11am.Text = s11AMText;
                            lbl12pm.Text = s12PMText;
                            lbl1pm.Text = s1PMText;
                            lbl2pm.Text = s2PMText;
                            lbl3pm.Text = s3PMText;
                            lbl4pm.Text = s4PMText;
                            lbl5pm.Text = s5PMText;
                        }
                        //////////////

                        //lbl8am.Text = s8AMText;
                        //lbl9am.Text = s9AMText;
                        //lbl10am.Text = s10AMText;
                        //lbl11am.Text = s11AMText;
                        //lbl12pm.Text = s12PMText;
                        //lbl1pm.Text = s1PMText;
                        //lbl2pm.Text = s2PMText;
                        //lbl3pm.Text = s3PMText;
                        //lbl4pm.Text = s4PMText;
                        //lbl5pm.Text = s5PMText;
                    }

                }




                rsCancelInterviewCount.Close();
                cmdCancelInterviewCount.Dispose();
                //sInterviewCount = iCount.ToString();
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
    public void GetContractStart()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                //string sqlGetContractStart = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
                //                              " dbo.GetJobNo(ea.employee_id) as job_num, " +
                //                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                //                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                //                              "  and eac.employee_id = ea.employee_id " +
                //                              "  and ea.active = 1 " +
                //                              "  and eac.active = 1 " +
                //                              "  and convert(datetime,ea.interview_date) between getdate()-1 and getdate()  and ea.candidate_approve = 1";

                //change getdate() to sDate()
                //string sqlGetContractStart = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                //                              " dbo.GetJobNo(ea.employee_id) as job_num, " +
                //                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                //                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                //                              "  and eac.employee_id = ea.employee_id " +
                //                              "  and ea.active = 1 " +
                //                              "  and eac.active = 1 " +
                //                              "  and convert(datetime,ea.interview_date) between Convert(DateTime,'" + sDate.ToString() + "')-1 and Convert(DateTime,'" + sDate.ToString() + "')  and ea.candidate_approve = 1";

                string sqlGetContractStart = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                                             " dbo.GetJobNo(job_id) as job_num, " +
                                             " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                                             "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                             "  and eac.employee_id = ea.employee_id " +
                                             "  and ea.active = 1 " +
                                             "  and eac.active = 1 " +
                                             "  and convert(datetime,eac.start_date) ='" + sDate + "'  and ea.candidate_approve = 1";


                SqlCommand cmdContractStarts = new SqlCommand(sqlGetContractStart, conn);
                SqlDataReader rsContractStarts = cmdContractStarts.ExecuteReader();
                //string _svendorList = "";
                int iCount = 0;
                string s8AMStartText = "";


                while (rsContractStarts.Read())
                {
                    //increment count
                    // iCount = iCount + 1;
                    //get date of interview
                    if (Convert.ToDateTime(rsContractStarts["start_date"].ToString()) == DateTime.Today)
                    {
                        //get time

                        s8AMStartText = s8AMStartText = "<div class='apt'>" +
                                      "<div class='btn-group btn-group-xs pull-right'>" +
                                      "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid==" + rsContractStarts["employee_Id"].ToString() + "' class='btn btn-primary'>" +
                                      "<i class='fa  fa-info-circle'></i></a></div>" +
                                      "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsContractStarts["employee_Id"].ToString() + "' class='text-primary strong'>" +
                                      "" + func.FixString(rsContractStarts["first_name"].ToString()) + " " + func.FixString(rsContractStarts["last_name"].ToString()) + "</a>" +
                                      "<i class='fa fa-fw fa-check'></i>Starting today as " + rsContractStarts["job_title"].ToString() + "</div>";


                        lbl8amStarts.Text = s8AMStartText;


                    }

                }
                rsContractStarts.Close();
                cmdContractStarts.Dispose();
                //sInterviewCount = iCount.ToString();
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
    public void GetContractEnd()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                //string sqlGetContractEnd = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
                //                              " dbo.GetJobNo(ea.employee_id) as job_num, " +
                //                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                //                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                //                              "  and eac.employee_id = ea.employee_id " +
                //                              "  and ea.active = 1 " +
                //                              "  and eac.active = 1 " +
                //                              "  and convert(datetime,ea.candidate_enddate) between getdate()-1 and getdate() ";

                //change getdate() to sDate()
                //string sqlGetContractEnd = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                //                             " dbo.GetJobNo(ea.employee_id) as job_num, " +
                //                             " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                //                             "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                //                             "  and eac.employee_id = ea.employee_id " +
                //                             "  and ea.active = 1 " +
                //                             "  and eac.active = 1 " +
                //                             "  and convert(datetime,ea.candidate_enddate) between Convert(DateTime,'" + sDate.ToString() + "')-1 and Convert(DateTime,'" + sDate.ToString() + "') ";

                string sqlGetContractEnd = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                                           " dbo.GetJobNo(job_id) as job_num, " +
                                           " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                                           "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                           "  and eac.employee_id = ea.employee_id " +
                                           "  and ea.active = 1 " +
                                           "  and eac.active = 1 " + "and ea.candidate_approve = 1" +
                                           "  and convert(datetime,eac.end_date) ='" + sDate + "' ";

                SqlCommand cmdContractEnd = new SqlCommand(sqlGetContractEnd, conn);
                SqlDataReader rsContractEnd = cmdContractEnd.ExecuteReader();
                //string _svendorList = "";
                int iCount = 0;
                string s5pmEndText = "";


                while (rsContractEnd.Read())
                {
                    //increment count
                    // iCount = iCount + 1;
                    //get date of interview
                    //get date for contract end
                    if (Convert.ToDateTime(rsContractEnd["end_date"].ToString()) == DateTime.Today)
                    {
                        //get time

                        s5pmEndText = s5pmEndText = "<div class='apt'>" +
                                      "<div class='btn-group btn-group-xs pull-right'>" +
                                      "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsContractEnd["employee_Id"].ToString() + "' class='btn btn-danger'>" +
                                      "<i class='fa  fa-info-circle'></i></a></div>" +
                                      "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsContractEnd["employee_Id"].ToString() + "' class='text-danger strong'>" +
                                      "" + func.FixString(rsContractEnd["first_name"].ToString()) + " " + func.FixString(rsContractEnd["last_name"].ToString()) + "</a>" +
                                      "<i class='fa fa-fw fa-check'></i>Ending today as " + rsContractEnd["job_title"].ToString() + "</div>";
                        //ending contract
                        lbl5pmContractEnding.Text = s5pmEndText;


                    }

                }
                rsContractEnd.Close();
                cmdContractEnd.Dispose();
                //sInterviewCount = iCount.ToString();
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
    public void GetNewCandidate()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                string sqlNewCandidate = "select concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),e.employee_id),4)) as emp_alias, " +
                                        " e.employee_id,ed.first_name + ' ' + ed.last_name as candidate_name,e.create_date, " +
                                        " dbo.GetJobNo(j.job_id) as job_alias, " +
                                        " j.job_title " +
                                        " from ovms_employees as e " +
                                        " join ovms_employee_details as ed on ed.employee_id=e.employee_id " +
                                        " left join ovms_employee_actions as ea on ea.employee_id=e.employee_id " +
                                        " join ovms_clients as clt on clt.client_id=e.client_id " +
                                         " inner join ovms_jobs as j on j.job_id=e.job_id " +
                                        " where e.employee_id not in (SELECT employee_id from ovms_employee_actions) " +
                                        " and ed.active=1 " +
                                        " and e.client_id = " + Session["ClientID"].ToString() +
                                        " and convert(datetime,e.create_date) between Convert(DateTime, '" + sDate + "') and " +
                                       " Convert(DateTime,'" + sDate + "') +1 ";

                SqlCommand cmdNewCandidate = new SqlCommand(sqlNewCandidate, conn);
                SqlDataReader rsNewCandidate = cmdNewCandidate.ExecuteReader();

                //string _svendorList = "";

                string sNewCandidateText = "";
                
                try
                {
                    if (rsNewCandidate.HasRows)
                    {
                        while (rsNewCandidate.Read())
                        {
                            //sNewCandidateText = sNewCandidateText + "<div class='apt'>New candidate: " +
                            //                    // "<div class='btn-group btn-group-xs pull-right'>" +
                            //                    "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsNewCandidate["emp_alias"].ToString() + "'>" +
                            //                    //"<i class='fa fa-fw fa-check'></i>" + 
                            //                    func.FixString(rsNewCandidate["candidate_name"].ToString()) + "</a>" + " </div>";

                            sNewCandidateText = sNewCandidateText + "<div class='apt'>New candidate: " +
                                                    // "<div class='btn-group btn-group-xs pull-right'>" +
                                                    "<a target='_blank' href='Client_View_Worker_Detail.aspx?wopen=Y&p=VW&empid=" + rsNewCandidate["emp_alias"].ToString() + "'>" +
                                                    //"<i class='fa fa-fw fa-check'></i>" + 
                                                    func.FixString(rsNewCandidate["candidate_name"].ToString()) + "</a> - " +
                                                    "<a target='_blank' href='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + rsNewCandidate["job_alias"].ToString() + "'>" +
                                                    //"<i class='fa fa-fw fa-check'></i>" + 
                                                    func.FixString(rsNewCandidate["job_title"].ToString()) + "</a>" +
                                                    " </div>";


                        }
                        //New Jobs
                        //lblnewjobs.Text = "New Job added: " + sNewJobsText;
                        lblnewCandidate.Text = sNewCandidateText;
                    }
                    rsNewCandidate.Close();
                    cmdNewCandidate.Dispose();
                    //sInterviewCount = iCount.ToString();
                }
                catch (Exception ex)
                {
                    //
                }

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
    public void GetPausedJobs()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
                string sPausedJobsText = "";

                string sqlGetPausedJobs = " select j.job_id,dbo.GetJobNo(j.job_id) job_alias,j.create_date,j.job_title,j.active as active,j.contract_start_date,j.contract_end_date , jl.city + ',' + jl.province as Location" +
                                " from ovms_jobs as j " +
                                " inner join ovms_Client_job_details as jd on jd.job_id=j.job_id " +
                                " inner join ovms_job_locations as jl on jl.job_location_id=jd.job_location_id " +
                                " where j.active != 1 and " +
                                "  ea.client_id = " + Session["ClientID"].ToString() +
                                " j.job_delete_time between Convert(DateTime, '" + sDate + "') and " +
                                " Convert(DateTime,'" + sDate + "') +1";

                SqlCommand cmdPausedJobs = new SqlCommand(sqlGetPausedJobs, conn);
                SqlDataReader rsPausedJobs = cmdPausedJobs.ExecuteReader();
                try
                {
                    if (rsPausedJobs.HasRows)
                    {
                        while (rsPausedJobs.Read())
                        {
                            sPausedJobsText = sPausedJobsText + "<div class='apt'>Job Paused: " +
                                                 // "<div class='btn-group btn-group-xs pull-right'>" +
                                                 "<a target='_blank' href='Client_Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsPausedJobs["job_alias"].ToString() + "'>" +
                                                 //"<i class='fa fa-fw fa-check'></i>" + 
                                                 rsPausedJobs["job_title"].ToString() + "</a> </div>";


                        }
                        //Paused Jobs
                        //lblnewjobs.Text = "New Job added: " + sNewJobsText;
                        lblpausedjobs.Text = sPausedJobsText;
                    }
                    rsPausedJobs.Close();
                    cmdPausedJobs.Dispose();
                 }
                catch (Exception ex)
                {
                    //
                }
                  

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

    //public void GetAbsenceRequest()
    //{
    //    try
    //    {
    //        if (conn.State == System.Data.ConnectionState.Closed)
    //        {
    //            conn.Open();
    //            string sAbsenceRequestText = "";

    //            string sqlGetAbsenceRequest = " select j.job_id,dbo.GetJobNo(j.job_id) job_alias,j.create_date,j.job_title,j.active as active,j.contract_start_date,j.contract_end_date , jl.city + ',' + jl.province as Location" +
    //                            " from ovms_jobs as j " +
    //                            " inner join ovms_Client_job_details as jd on jd.job_id=j.job_id " +
    //                            " inner join ovms_job_locations as jl on jl.job_location_id=jd.job_location_id " +
    //                            " where j.active != 1 and " +
    //                            " j.create_date between Convert(DateTime, '" + sDate + "') and " +
    //                            " Convert(DateTime,'" + sDate + "') +1";
    //            SqlCommand cmdAbsenceRequest = new SqlCommand(sqlGetAbsenceRequest, conn);
    //            SqlDataReader rsAbsenceRequest = cmdAbsenceRequest.ExecuteReader();
    //            try
    //            {
    //                if (rsAbsenceRequest.HasRows)
    //                {
    //                    while (rsAbsenceRequest.Read())
    //                    {
    //                        sAbsenceRequestText = sAbsenceRequestText + "<div class='apt'>Job Paused: " +
    //                                             // "<div class='btn-group btn-group-xs pull-right'>" +
    //                                             "<a target='_blank' href='Client_Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsAbsenceRequest["job_alias"].ToString() + "'>" +
    //                                             //"<i class='fa fa-fw fa-check'></i>" + 
    //                                             rsAbsenceRequest["job_title"].ToString() + "</a> </div>";


    //                    }
    //                    //Paused Jobs
    //                    //lblnewjobs.Text = "New Job added: " + sNewJobsText;
    //                    lblabsencerequest.Text = sAbsenceRequestText;
    //                }
    //                rsAbsenceRequest.Close();
    //                cmdAbsenceRequest.Dispose();
    //            }
    //            catch (Exception ex)
    //            {
    //                //
    //            }
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

    public void GetCandidateApproval()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                //string sqlGetInterviewCount = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
                //                              " dbo.GetJobNo(ea.employee_id) as job_num, " +
                //                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                //                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                //                              "  and eac.employee_id = ea.employee_id " +
                //                              "  and ea.active = 1 " +
                //                              "  and eac.active = 1 " +
                //                              "  and convert(datetime, ea.interview_date) between Convert(DateTime,'" + sDate.ToString() + "') - 1 and getdate() + 7  ";


                //Change the getdate() to sDate to check the interviews between sDate - 1 and sDate + 7
                string sqlGetCandidateApproval = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                                              " dbo.GetJobNo(job_id) as job_num, " +
                                             " concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),eac.employee_id),4)) as emp_id, " +
                                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title " +
                                              " from ovms_employee_actions ea, ovms_employee_details eac, ovms_clients as clt  " +
                                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                              "  and eac.employee_id = ea.employee_id " +
                                              " and ea.client_id=clt.client_id " +
                                              "  and ea.active = 1 " +
                                              "  and eac.active = 1 " +
                                              "  and convert(datetime, ea.candidate_aprove_time) between Convert(DateTime,'" + sDate.ToString() + "') and Convert(DateTime,'" + sDate.ToString() + "') + 7  ";

                // "  and(select vendor_id from ovms_employees where employee_id = ea.employee_id) = " + Session["VendorID"].ToString() + " " +

                SqlCommand cmdCandidateApproval = new SqlCommand(sqlGetCandidateApproval, conn);
                SqlDataReader rsCandidateApproval = cmdCandidateApproval.ExecuteReader();
                //string _svendorList = "";
                int iCount = 0;

                while (rsCandidateApproval.Read())
                {
                    string iApproved = rsCandidateApproval["candidate_approve"].ToString();
                    string iRequested = rsCandidateApproval["interview_requested"].ToString();
                    string Approved = Convert.ToDateTime(rsCandidateApproval["candidate_aprove_time"]).AddHours(-1).ToShortTimeString();
                    string approve_time = rsCandidateApproval["candidate_aprove_time"].ToString();
                    string approvetime = Convert.ToDateTime(Approved).ToString(@"hh:00 tt", new CultureInfo("en-US"));

                    //increment count
                    // iCount = iCount + 1;
                    //get date of approved by client
                    if (Convert.ToDateTime(approve_time).Date == sDate)
                    {
                        //Check for the interiew status
                        if (iApproved == "1" && iRequested != "1")
                        {

                            if (approvetime.Trim() == "08:00 AM")
                            {
                                s8AMText = s8AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +"Candidate Approved: "+
                                                 "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (approvetime.Trim() == "09:00 AM")
                            {
                                s9AMText = s9AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approve: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (approvetime.Trim() == "10:00 AM")
                            {
                                s10AMText = s10AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0,10)+"..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (approvetime.Trim() == "11:00 AM")
                            {
                                s11AMText = s11AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (approvetime.Trim() == "12:00 PM")
                            {
                                s12PMText = s12PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (approvetime.Trim() == "01:00 PM")
                            {
                                s1PMText = s1PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                               " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (approvetime.Trim() == "02:00 PM")
                            {
                                s2PMText = s2PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                              " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (approvetime.Trim() == "03:00 PM")
                            {
                                s3PMText = s3PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (approvetime.Trim() == "04:00 PM")
                            {
                                s4PMText = s4PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }
                            if (approvetime.Trim() == "05:00 PM")
                            {
                                s5PMText = s5PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "'class='btn btn-success'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + "Candidate Approved: " +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateApproval["emp_id"].ToString() + "' class='text-green-900'>" +
                                              "" + func.FixString(rsCandidateApproval["first_name"].ToString()) + " " + func.FixString(rsCandidateApproval["last_name"].ToString()) + "</a>" +
                                             " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateApproval["job_num"].ToString() + "' class='text-green-900'>" + (rsCandidateApproval["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                       "</div>";
                            }

                            lbl8am.Text = s8AMText;
                            lbl9am.Text = s9AMText;
                            lbl10am.Text = s10AMText;
                            lbl11am.Text = s11AMText;
                            lbl12pm.Text = s12PMText;
                            lbl1pm.Text = s1PMText;
                            lbl2pm.Text = s2PMText;
                            lbl3pm.Text = s3PMText;
                            lbl4pm.Text = s4PMText;
                            lbl5pm.Text = s5PMText;
                        }
                    }



                }

                rsCandidateApproval.Close();
                rsCandidateApproval.Dispose();
                //sInterviewCount = iCount.ToString();
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

    public void GetCandidateRejected()
    {
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                //string sqlGetInterviewCount = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
                //                              " dbo.GetJobNo(ea.employee_id) as job_num, " +
                //                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
                //                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                //                              "  and eac.employee_id = ea.employee_id " +
                //                              "  and ea.active = 1 " +
                //                              "  and eac.active = 1 " +
                //                              "  and convert(datetime, ea.interview_date) between Convert(DateTime,'" + sDate.ToString() + "') - 1 and getdate() + 7  ";


                //Change the getdate() to sDate to check the interviews between sDate - 1 and sDate + 7
                string sqlGetCandidateRejected = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
                                              " dbo.GetJobNo(job_id) as job_num, " +
                                             " concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),eac.employee_id),4)) as emp_id, " +
                                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title " +
                                              " from ovms_employee_actions ea, ovms_employee_details eac, ovms_clients as clt  " +
                                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
                                              "  and eac.employee_id = ea.employee_id " +
                                              " and ea.client_id=clt.client_id " +
                                              "  and ea.active = 1 " +
                                              "  and eac.active = 1 " +
                                              "  and convert(datetime, ea.vendor_reject_candidate_time) between Convert(DateTime,'" + sDate.ToString() + "') and Convert(DateTime,'" + sDate.ToString() + "') + 7  ";

                // "  and(select vendor_id from ovms_employees where employee_id = ea.employee_id) = " + Session["VendorID"].ToString() + " " +

                SqlCommand cmdCandidateRejected = new SqlCommand(sqlGetCandidateRejected, conn);
                SqlDataReader rsCandidateRejected = cmdCandidateRejected.ExecuteReader();
                //string _svendorList = "";
                int iCount = 0;

                while (rsCandidateRejected.Read())
                {
                    string iRejected = rsCandidateRejected["vendor_reject_candidate"].ToString();
                    string Rejected = Convert.ToDateTime(rsCandidateRejected["vendor_reject_candidate_time"]).AddHours(-1).ToShortTimeString();
                    string Reject_time = rsCandidateRejected["vendor_reject_candidate_time"].ToString();
                    string Rejecttime = Convert.ToDateTime(Rejected).ToString(@"hh:00 tt", new CultureInfo("en-US"));


                    //interview status
                    //string iApproved = rsCandidateRejected["candidate_approve"].ToString();

                    //increment count
                    // iCount = iCount + 1;
                    //get date of interview
                    if (Convert.ToDateTime(Reject_time).Date == sDate)
                    {
                        //Candidate Rejected
                        if (iRejected == "1")
                        {

                            if (Rejecttime.Trim() == "08:00 AM")
                            {
                                s8AMText = s8AMText + "<div class='apt'>" +
                                       "<div class='btn-group btn-group-xs pull-right'>" +
                                       "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                       "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                       "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                       "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                           " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>" +( rsCandidateRejected["job_title"].ToString()).Substring(0,10)+"..." + "</a>" +
                                       "</div>";
                            }
                            //get time
                            if (Rejecttime.Trim() == "09:00 AM")
                            {
                                s9AMText = s9AMText + "<div class='apt'>" +
                                             "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>" + (rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (Rejecttime.Trim() == "10:00 AM")
                            {
                                s10AMText = s10AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>" + (rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (Rejecttime.Trim() == "11:00 AM")
                            {
                                s11AMText = s11AMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" +" Interview Declined:"+
                                                 "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " / " + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>" + (rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (Rejecttime.Trim() == "12:00 PM")
                            {
                                s12PMText = s12PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>" + (rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            //get time
                            if (Rejecttime.Trim() == "01:00 PM")
                            {
                                s1PMText = s1PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>" + (rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            if (Rejecttime.Trim() == "02:00 PM")
                            {
                                s2PMText = s2PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>"+(rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            if (Rejecttime.Trim() == "03:00 PM")
                            {
                                s3PMText = s3PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  "/ " + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>"+(rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            if (Rejecttime.Trim() == "04:00 PM")
                            {
                                s4PMText = s4PMText + "<div class='apt'>" +
                                              "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>"+(rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            if (Rejecttime.Trim() == "05:00 PM")
                            {
                                s5PMText = s5PMText + "<div class='apt'>" +
                                             "<div class='btn-group btn-group-xs pull-right'>" +
                                              "<a target='_blank' href='C_Dashboard.aspx?Rejectedempid=" + rsCandidateRejected["emp_id"].ToString() + "' class='btn btn-primary'>" +
                                              "<i class='fa  fa-info-circle'></i></a></div>" + " Interview Declined:" +
                                              "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-primary strong'>" +
                                              "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
                                  " /" + "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "'>" + (rsCandidateRejected["job_title"].ToString()).Substring(0, 10) + "..." + "</a>" +
                                              "</div>";
                            }
                            lbl8am.Text = s8AMText;
                            lbl9am.Text = s9AMText;
                            lbl10am.Text = s10AMText;
                            lbl11am.Text = s11AMText;
                            lbl12pm.Text = s12PMText;
                            lbl1pm.Text = s1PMText;
                            lbl2pm.Text = s2PMText;
                            lbl3pm.Text = s3PMText;
                            lbl4pm.Text = s4PMText;
                            lbl5pm.Text = s5PMText;
                        }
                    }

                }

                rsCandidateRejected.Close();
                rsCandidateRejected.Dispose();
                //sInterviewCount = iCount.ToString();
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
    //public void GetCandidateRejected()
    //{
    //    try
    //    {
    //        if (conn.State == System.Data.ConnectionState.Closed)
    //        {
    //            conn.Open();

    //            // Session["JobID"] = jobID.ToString();

    //            //start, end and weeks
    //            //string sqlGetInterviewCount = " select *, convert(datetime,ea.interview_date),getdate() -1 ,getdate() + 7 , " +
    //            //                              " dbo.GetJobNo(ea.employee_id) as job_num, " +
    //            //                              " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title from ovms_employee_actions ea, ovms_employee_details eac  " +
    //            //                              "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
    //            //                              "  and eac.employee_id = ea.employee_id " +
    //            //                              "  and ea.active = 1 " +
    //            //                              "  and eac.active = 1 " +
    //            //                              "  and convert(datetime, ea.interview_date) between Convert(DateTime,'" + sDate.ToString() + "') - 1 and getdate() + 7  ";


    //            //Change the getdate() to sDate to check the interviews between sDate - 1 and sDate + 7
    //            string sqlGetCandidateRejected = " select *, convert(datetime,ea.interview_date),Convert(DateTime,'" + sDate.ToString() + "') -1 ,Convert(DateTime,'" + sDate.ToString() + "') + 7 , " +
    //                                          " dbo.GetJobNo(job_id) as job_num, " +
    //                                         " concat('W',clt.client_alias, '00', right('0000' + convert(varchar(4),eac.employee_id),4)) as emp_id, " +
    //                                          " (select Job_Title from ovms_jobs where job_id = (select job_ID from ovms_employees where employee_id = ea.employee_id)) as Job_Title " +
    //                                          " from ovms_employee_actions ea, ovms_employee_details eac, ovms_clients as clt  " +
    //                                          "  where ea.client_id = " + Session["ClientID"].ToString() + " " +
    //                                          "  and eac.employee_id = ea.employee_id " +
    //                                          " and ea.client_id=clt.client_id " +
    //                                          "  and ea.active = 1 " +
    //                                          "  and eac.active = 1 " +
    //                                          "  and convert(datetime, ea.vendor_reject_candidate_time) between Convert(DateTime,'" + sDate.ToString() + "') and Convert(DateTime,'" + sDate.ToString() + "') + 7  ";

    //            // "  and(select vendor_id from ovms_employees where employee_id = ea.employee_id) = " + Session["VendorID"].ToString() + " " +

    //            SqlCommand cmdCandidateRejected = new SqlCommand(sqlGetCandidateRejected, conn);
    //            SqlDataReader rsCandidateRejected = cmdCandidateRejected.ExecuteReader();
    //            //string _svendorList = "";
    //            int iCount = 0;

    //            while (rsCandidateRejected.Read())
    //            {
    //                string iRejected = rsCandidateRejected["vendor_reject_candidate"].ToString();
    //                string Rejected = Convert.ToDateTime(rsCandidateRejected["vendor_reject_candidate_time"]).AddHours(-1).ToShortTimeString();
    //                string Reject_time = rsCandidateRejected["vendor_reject_candidate_time"].ToString();
    //                string Rejecttime = Convert.ToDateTime(Rejected).ToString(@"hh:00 tt", new CultureInfo("en-US"));


    //                //interview status
    //                //string iApproved = rsCandidateRejected["candidate_approve"].ToString();

    //                //increment count
    //                // iCount = iCount + 1;
    //                //get date of interview
    //                if (Convert.ToDateTime(Reject_time).Date == sDate)
    //                {
    //                    //Candidate Rejected
    //                    if (iRejected == "1")
    //                    {

    //                        if (Rejecttime.Trim() == "8:00 AM")
    //                        {
    //                            s8AMText = s8AMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        //get time
    //                        if (Rejecttime.Trim() == "9:00 AM")
    //                        {
    //                            s9AMText = s9AMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        //get time
    //                        if (Rejecttime.Trim() == "10:00 AM")
    //                        {
    //                            s10AMText = s10AMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        //get time
    //                        if (Rejecttime.Trim() == "11:00 AM")
    //                        {
    //                            s11AMText = s11AMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        //get time
    //                        if (Rejecttime.Trim() == "12:00 PM")
    //                        {
    //                            s12PMText = s12PMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        //get time
    //                        if (Rejecttime.Trim() == "1:00 PM")
    //                        {
    //                            s1PMText = s1PMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        if (Rejecttime.Trim() == "2:00 PM")
    //                        {
    //                            s2PMText = s2PMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        if (Rejecttime.Trim() == "3:00 PM")
    //                        {
    //                            s3PMText = s3PMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        if (Rejecttime.Trim() == "4:00 PM")
    //                        {
    //                            s4PMText = s4PMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        if (Rejecttime.Trim() == "5:00 PM")
    //                        {
    //                            s5PMText = s5PMText + "<div class='apt'>" +
    //                                          "<div class='btn-group btn-group-xs pull-right'>" +
    //                                          "<a target='_blank' href='Client_job_details.aspx?jopen=Y&p=JV&jobID=" + rsCandidateRejected["job_num"].ToString() + "' class='btn btn-warning'>" +
    //                                          "<i class='fa  fa-info-circle'></i></a></div>" +
    //                                          "<a target='_blank' href='Client_View_Worker_Detail.aspx?empid=" + rsCandidateRejected["emp_id"].ToString() + "' class='text-warning strong'>" +
    //                                          "" + func.FixString(rsCandidateRejected["first_name"].ToString()) + " " + func.FixString(rsCandidateRejected["last_name"].ToString()) + "</a>" +
    //                                          "<i class='fa fa-fw fa-users'></i><span class='text-red-900'><b>Candidate Rejected for:</b></span> " + rsCandidateRejected["job_title"].ToString() +
    //                                          "</div>";
    //                        }
    //                        lbl8am.Text = s8AMText;
    //                        lbl9am.Text = s9AMText;
    //                        lbl10am.Text = s10AMText;
    //                        lbl11am.Text = s11AMText;
    //                        lbl12pm.Text = s12PMText;
    //                        lbl1pm.Text = s1PMText;
    //                        lbl2pm.Text = s2PMText;
    //                        lbl3pm.Text = s3PMText;
    //                        lbl4pm.Text = s4PMText;
    //                        lbl5pm.Text = s5PMText;
    //                    }
    //                }

    //            }

    //            rsCandidateRejected.Close();
    //            rsCandidateRejected.Dispose();
    //            //sInterviewCount = iCount.ToString();
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
    //    //return _sArrayString;
    //}
}