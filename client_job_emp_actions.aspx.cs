using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class client_job_emp_actions : System.Web.UI.Page
{
    private int iResponse;
    string name2 = "";
    string job_name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string jobID = Request.QueryString["job_id"];
        string jobID1 = (Request.QueryString["job_id"].Substring(Request.QueryString["job_id"].Length - 5));
        if (Request.QueryString["approve"] != null)
        {
            string job_end_date = Request.QueryString["job_end"];
            string emp_end_date = Request.QueryString["emp_end"];
            string employee_id = (Request.QueryString["approve"].Substring(Request.QueryString["approve"].Length - 5));
            DateTime thisDay = DateTime.Now.AddHours(1);
            if (Request.QueryString["chkapprove"] == "yes")
            {
                API.Service approve = new API.Service();
                // API.Service approve = new API.Service();
                XmlDocument _xmlDoc1 = new XmlDocument();
                _xmlDoc1.LoadXml("<XML>" + approve.candidate_approve(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["ClientID"].ToString(), employee_id.ToString(), Session["VendorID"].ToString(), "1", jobID1, emp_end_date, job_end_date, thisDay.ToString()).InnerXml + "</XML>");
                XmlNodeList ea = _xmlDoc1.SelectNodes("XML/RESPONSE");
                API.Service name = new API.Service();
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.LoadXml("<XML>" + name.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employee_id, "", "", "", "", "1", "").InnerXml + "</XML>");
                XmlNodeList ea1 = _xmlDoc.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                name2 = ea1[iResponse].SelectSingleNode("FIRSTNAME").InnerText;
                job_name = ea1[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
                //*** Sms Notify**** ///////
                SqlConnection conn;
                string readsms;
                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                        string smsquery = "select vendor_id from ovms_employee_actions where job_id = " + jobID1;
                        SqlCommand smscmd = new SqlCommand(smsquery, conn);
                        SqlDataReader datareders = smscmd.ExecuteReader();
                        if (datareders.HasRows == true)
                        {
                            while (datareders.Read())
                            {
                                readsms = datareders["vendor_id"].ToString();
                                string message = "Candidate Approved \n" + name2 + "\n " + job_name;
                                localhost.Service files = new localhost.Service();
                                files.client_smsNotification(readsms, message, Session["ClientID"].ToString(), "candid_approve_notify");
                            }
                        }
                        datareders.Close();
                        smscmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                ///////// ** end of sms notify** /////////////


                Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + jobID);
            }
            else
            {

                string intw_time = Request.QueryString["time"];
                string intw_date = Request.QueryString["date"];
                DateTime int_date = DateTime.Parse(intw_date);
                string comment = Request.QueryString["intComment"];
                API.Service int_req = new API.Service();

                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.LoadXml("<XML>" + int_req.interview_request(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["ClientID"].ToString(), Session["VendorID"].ToString(), employee_id.ToString(), "1", int_date, intw_time, jobID1.ToString(), emp_end_date.ToString(), job_end_date.ToString(), comment, "", "", thisDay.ToString()).InnerXml + "</XML>");
                // _xmlDoc.LoadXml("<XML>" + int_req.interview_request(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["UserID"].ToString(), employee_id.ToString(), "1", int_date, intw_time).InnerXml + "</XML>");
                XmlNodeList ea = _xmlDoc.SelectNodes("XML/RESPONSE");
                API.Service name = new API.Service();
                XmlDocument _xmlDoc1 = new XmlDocument();
                _xmlDoc1.LoadXml("<XML>" + name.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employee_id, "", "", "", "", "1", "").InnerXml + "</XML>");
                XmlNodeList ea1 = _xmlDoc1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                name2 = ea1[iResponse].SelectSingleNode("FIRSTNAME").InnerText;
                job_name = ea1[iResponse].SelectSingleNode("JOB_TITLE").InnerText;

                //*** Sms Notify**** ///////
                SqlConnection conn;
                string readsms;
                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                        string smsquery = "select vendor_id from ovms_employee_actions where job_id =  " + jobID1;
                        SqlCommand smscmd = new SqlCommand(smsquery, conn);
                        SqlDataReader datareders = smscmd.ExecuteReader();
                        if (datareders.HasRows == true)
                        {
                            while (datareders.Read())
                            {
                                readsms = datareders["vendor_id"].ToString();
                                string message = "Candidate Interview schedule \n" + name2 + "\n " + job_name;
                                localhost.Service files = new localhost.Service();
                                files.client_smsNotification(readsms, message, Session["ClientID"].ToString(), "interview_schedule_notify");
                            }
                        }
                        datareders.Close();
                        smscmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }


                ///////// ** end of sms notify** /////////////
                Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + jobID);
            }
        }
        if (Request.QueryString["Reject"] != null)
        {
            string job_end_date = Request.QueryString["job_end"];
            string emp_end_date = Request.QueryString["emp_end"];
            string employee_id = Request.QueryString["Reject"].Substring(Request.QueryString["Reject"].Length - 5);
            string reason = Request.QueryString["txtComments"];

            DateTime thisDay = DateTime.Now.AddHours(1);
            API.Service int_req = new API.Service();
            //  API.Service int_req = new API.Service();
            XmlDocument _xmlDoc = new XmlDocument();
            _xmlDoc.LoadXml("<XML>" + int_req.reject_candidate(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["ClientID"].ToString(), employee_id.ToString(), Session["VendorID"].ToString(), "1", reason, jobID1.ToString(), emp_end_date.ToString(), job_end_date.ToString(), thisDay.ToString()).InnerXml + "</XML>");
            XmlNodeList ea = _xmlDoc.SelectNodes("XML/RESPONSE");
            API.Service name = new API.Service();
            XmlDocument _xmlDoc1 = new XmlDocument();
            _xmlDoc1.LoadXml("<XML>" + name.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employee_id, "", "", "", "", "1", "").InnerXml + "</XML>");
            XmlNodeList ea1 = _xmlDoc1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            name2 = ea1[iResponse].SelectSingleNode("FIRSTNAME").InnerText;
            job_name = ea1[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
            //*** Sms Notify**** ///////
            SqlConnection conn;
            string readsms;
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    string smsquery = "select vendor_id from ovms_employee_actions where job_id = " + jobID1;
                    SqlCommand smscmd = new SqlCommand(smsquery, conn);
                    SqlDataReader datareders = smscmd.ExecuteReader();
                    if (datareders.HasRows == true)
                    {
                        while (datareders.Read())
                        {
                            readsms = datareders["vendor_id"].ToString();
                            string message = "Candidate rejected \n" + name2 + "\n " + job_name;
                            localhost.Service files = new localhost.Service();
                            files.client_smsNotification(readsms, message, Session["ClientID"].ToString(), "candid_reject_notify");
                        }
                    }
                    datareders.Close();
                    smscmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }



            ///////// ** end of sms notify** /////////////
            Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + jobID);
        }
        if (Request.QueryString["More"] != null)
        {
            string employee_id = Request.QueryString["More"];
            string moreinf = Request.QueryString["txtComments"].ToString();
            string job_end_date = Request.QueryString["job_end"];
            string emp_end_date = Request.QueryString["emp_end"];


            API.Service more_info = new API.Service();
            XmlDocument _xmlDoc = new XmlDocument();
            _xmlDoc.LoadXml("<XML>" + more_info.more_info_candidate(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["ClientID"].ToString(), employee_id.ToString(), moreinf, jobID1.ToString(), emp_end_date.ToString(), job_end_date.ToString()).InnerXml + "</XML>");
            XmlNodeList ea = _xmlDoc.SelectNodes("XML/RESPONSE");
            Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + jobID);

        }
        if (Request.QueryString["reshedule"] != null)
        {

            // following code is to get inderview comments for rescheduling the interview comments
            API.Service getWorkers = new API.Service();
            XmlDocument dom1 = new XmlDocument();
            dom1.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), "", "", Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
            XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            string comment2 = "";
            string comment3 = "";
            string comment4 = "";
            string comment5 = "";

            for (int iResponse = 0; iResponse < Response.Count; iResponse++)
            {
                comment2 = Response[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT2").InnerText;
                comment3 = Response[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT3").InnerText;
                comment4 = Response[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT4").InnerText;
                comment5 = Response[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT5").InnerText;


            }

            string comment = Request.QueryString["newcomments"].ToString();
            {
                string action_id1 = Request.QueryString["action_id"];
                string newdate1 = Request.QueryString["newdate"];
                DateTime newdate2 = DateTime.Parse(newdate1);
                string newtime1 = Request.QueryString["newtime"].ToString();
                DateTime thisDay = DateTime.Now.AddHours(1);
                API.Service reshedule = new API.Service();
                XmlDocument _xmlDoc1 = new XmlDocument();
                if (comment2 == "")
                {
                    _xmlDoc1.LoadXml("<XML>" + reshedule.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id1, newdate2, newtime1, "1", "null", "1", comment, "", "", "", "", "", thisDay.ToString()).InnerXml + "</XML>");

                }
                else
                    if (comment3 == "")
                {


                    _xmlDoc1.LoadXml("<XML>" + reshedule.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id1, newdate2, newtime1, "1", "null", "1", comment2, comment, "", "", "", "", thisDay.ToString()).InnerXml + "</XML>");

                }
                else
                    if (comment4 == "")
                {


                    _xmlDoc1.LoadXml("<XML>" + reshedule.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id1, newdate2, newtime1, "1", "null", "1", comment2, comment3, comment, "", "", "", thisDay.ToString()).InnerXml + " </XML>");

                }
                else
                    if (comment5 == "")
                {


                    _xmlDoc1.LoadXml("<XML>" + reshedule.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id1, newdate2, newtime1, "1", "null", "1", comment2, comment3, comment4, comment, "", "", thisDay.ToString()).InnerXml + " </XML>");

                }



                HttpContext.Current.Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + jobID);
            }

        }
    }

}