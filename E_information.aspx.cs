using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class E_information : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();
    emailFunctions semail = new emailFunctions();
    private int iResponseq;
    protected void Page_Load(object sender, EventArgs e)
    {
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
                //getJobs
                string strGetOtherInfo = @" select a.user_id, a.job_id,  a.employee_id UserIDEmployee, b.profile_picture_path, b.pay_rate, b.email, " +
                                        " (select job_title from ovms_jobs where job_id = a.job_id and active = 1) as job_title, " +
                                        " (select roles_and_responsibilities from ovms_job_details where job_id = a.job_id and active = 1) as job_desc, " +
                                        " (select Contract_start_date from ovms_jobs where job_id = a.job_id and active = 1) as contract_Start, " +
                                        " (select Contract_End_date from ovms_jobs where job_id = a.job_id and active = 1) as contract_End, " +
                                        " getdate() as todaydate, datediff(d, getdate(), (select Contract_End_date from ovms_jobs where job_id = a.job_id and active = 1)) as days_left, " +
                                        " datediff(d, (select Contract_start_date from ovms_jobs where job_id = a.job_id and active = 1), (select Contract_End_date from ovms_jobs where job_id = a.job_id and active = 1)) as total_days " +
                                        " from ovms_employees a, ovms_employee_details b " +
                                        " where a.employee_id = b.employee_id " +
                                        " and a.user_id = " + Session["UserID"].ToString();


                SqlCommand cmdGetOtherInfo = new SqlCommand(strGetOtherInfo.Replace("'", " "), conn);
                SqlDataReader readerGetOtherInfo = cmdGetOtherInfo.ExecuteReader();
                //string _svendorList = "";
                int DaysLeft = 0;

                if (readerGetOtherInfo.HasRows == true)
                {
                    lblEmployeeStatus.Text = "<a href ='#' class='btn btn-success'>Working<i class='fa fa-check-circle fa-fw'></i></a>";
                    Session["NotWorking"] = "false";
                }
                else
                {
                    lblEmployeeStatus.Text = "<a href ='#' class='btn btn-danger'>Not Working<i class='fa fa-times-circle fa-fw'></i></a>";
                   // lblRatePerHour.Text = "$0/hr";
                    Session["NotWorking"] = "true";
                }

                while (readerGetOtherInfo.Read())
                {
                   // lblRatePerHour.Text = "$" + readerGetOtherInfo["pay_rate"].ToString() + "/hr";
                    lblJobTitle.Text = readerGetOtherInfo["job_title"].ToString();
                    //  lblJobDescription.Text = Server.HtmlDecode( readerGetOtherInfo["job_desc"].ToString());
                    //lblNameEmployee.Text = readerGetOtherInfo["first_name"].ToString() + " " + readerGetFullName["last_name"].ToString();
                    //   ContractStart.Text = DateTime.Parse(readerGetOtherInfo["contract_Start"].ToString()).ToString("dd MMM, yyyy");
                    //  ContractEnd.Text = DateTime.Parse(readerGetOtherInfo["contract_End"].ToString()).ToString("dd MMM, yyyy");
                    DaysLeft = (Convert.ToInt32(readerGetOtherInfo["total_days"].ToString()) - Convert.ToInt32(readerGetOtherInfo["days_left"].ToString()));
                    //   lblPercent.Text = "<div data-percent='" + DaysLeft + "' data-size='100' class='easy-pie inline-block primary' data-scale-color='false' data-track-color='#efefef' data-line-width= '6'>";
                    //lblvendor.Text = readerVendorActivity["vendor_name"].ToString();
                    //lblVendors.Text  = reader["num_of_jobs"].ToString();
                    String jobid = readerGetOtherInfo["job_id"].ToString();
                    {
                        API.Service getWorkers = new API.Service();
                        XmlDocument dom1 = new XmlDocument();
                        dom1.LoadXml("<XML>" + getWorkers.get_Jobs(jobid, Session["Email"].ToString(), Session["P@ss"].ToString(), "", Session["UserID"].ToString(), "").InnerXml + "</XML>");
                        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/JOBS");

                        //   lblJobDescription.Text = Server.HtmlDecode(Response[iResponseq].SelectSingleNode("JOB_DESC").InnerText);
                    }
                    //   GetRevenueforEmployee(readerGetOtherInfo["UserIDEmployee"].ToString(), readerGetOtherInfo["pay_rate"].ToString(), readerGetOtherInfo["total_days"].ToString(), "1");
                    //   GetRevenueforEmployee(readerGetOtherInfo["UserIDEmployee"].ToString(), readerGetOtherInfo["pay_rate"].ToString(), readerGetOtherInfo["total_days"].ToString(), "3");
                    //  GetTBARevenue(readerGetOtherInfo["UserIDEmployee"].ToString(), readerGetOtherInfo["pay_rate"].ToString(), readerGetOtherInfo["total_days"].ToString());

                    if (readerGetOtherInfo.HasRows == true)
                    {
                        double work_status = Convert.ToDouble(readerGetOtherInfo["days_left"].ToString());
                        //lblEmployeeStatus.Text = "<a href ='#' class='btn btn-success'>Working<i class='fa fa-check-circle fa-fw'></i></a>";
                        //Session["NotWorking"] = "false";
                        if (work_status > 0)
                        {
                            //lblEmployeeStatus.Text = "Working";
                            //Session["NotWorking"] = "false";
                            lblEmployeeStatus.Text = "<a href ='#' class='btn btn-success'>Working<i class='fa fa-check-circle fa-fw'></i></a>";
                            Session["NotWorking"] = "false";
                        }
                        else
                        {
                            lblEmployeeStatus.Text = "<a href ='#' class='btn btn-danger'>Contract Ended<i class='fa fa-times-circle fa-fw'></i></a>";
                           // lblRatePerHour.Text = "$0/hr";
                            Session["NotWorking"] = "true";
                        }
                    }
                    else
                    {
                        lblEmployeeStatus.Text = "<a href ='#' class='btn btn-danger'>Not Working<i class='fa fa-times-circle fa-fw'></i></a>";
                       // lblRatePerHour.Text = "$0/hr";
                        Session["NotWorking"] = "true";
                    }


                }

                //  Session["contract_end"] = ContractEnd.Text;
                readerGetOtherInfo.Close();
                cmdGetOtherInfo.Dispose();
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
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetFullName = " select first_name, last_name, email_id from ovms_users where user_id = " + Session["UserID"].ToString();
                SqlCommand cmdGetFullName = new SqlCommand(strGetFullName, conn);
                SqlDataReader readerGetFullName = cmdGetFullName.ExecuteReader();
                //string _svendorList = "";
                while (readerGetFullName.Read())
                {
                    lblNameEmployee.Text = func.FixString(readerGetFullName["first_name"].ToString() + " " + readerGetFullName["last_name"].ToString());


                    //lblvendor.Text = readerVendorActivity["vendor_name"].ToString();
                    //lblVendors.Text  = reader["num_of_jobs"].ToString();
                }
                readerGetFullName.Close();
                cmdGetFullName.Dispose();
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