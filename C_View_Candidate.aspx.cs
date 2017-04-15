using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Xml;


public partial class C_View_Candidate : System.Web.UI.Page
{
    StringFunctions func = new StringFunctions();
    private int iResponse13;
    SqlConnection conn;
    string interview_requirement = "";
    private int iResponse;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            btnsbmit.CausesValidation = false;
            // BtnReshedule.CausesValidation = false;

        }
        if (Request.QueryString["makesure7"] == "1")
        {

            string employeeID = (Request.QueryString["Reject02"].Substring(Request.QueryString["Reject02"].Length - 5));
        API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            lblrejctname.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lbljobtitle.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;


        }
        if (Request.QueryString["makesure6"] == "1")
        {

            lblrejectintname.Text = Request.QueryString["cand_name"];
            lblrejecttitlejob.Text = Request.QueryString["job_title"];


        }
        if (Request.QueryString["makesure5"] == "1")
        {

            lblrjctname.Text = Request.QueryString["cand_name"];
            lblrjctjob.Text = Request.QueryString["job_title"];


        }
        if (Request.QueryString["makesure4"] == "1")
        {

            lblapprvcandiate.Text = Request.QueryString["cand_name"];
            LbltitleJOB.Text = Request.QueryString["job_title"];


        }
        if (Request.QueryString["makesure3"] == "1")
        {

            string employeeID = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblname_C.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            string schedule_int = DateTime.Parse(Request.QueryString["new_date"].Replace("12:00:00 AM", "")).ToString("dd MMM, yyyy");
            lbltimeC.Text = Request.QueryString["new_time"];
            lbldateC.Text = schedule_int;


        }
        if (Request.QueryString["makesure2"] == "1")
        {

            string employeeID = (Request.QueryString["approve"].Substring(Request.QueryString["approve"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
           
            lblcandname.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
           string schedule_int  =DateTime.Parse( Request.QueryString["date"].Replace("12:00:00 AM", "")).ToString("dd MMM, yyyy");
            lbltime.Text = Request.QueryString["time"];
            lblinterviewdate.Text = schedule_int;


        }
        if (Request.QueryString["makesure"] == "1")
        {
           
            string employeeID = (Request.QueryString["approve"].Substring(Request.QueryString["approve"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            lbljobname.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
            lblempname.Text= Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText+" "+ Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;

        }
        if (Request.QueryString["reject_reason1"] == "1")
        {
            string reason_of_rejection = "";
            string employeeID = (Request.QueryString["emp_id"]);
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            reason_of_rejection = Response2[iResponse].SelectSingleNode("VENDOR_REJECT_CANDIDATE_COMMENT").InnerText;
            //rejection_reasonfromclient = reason_of_rejection;
            rejection_reason.Text = reason_of_rejection;

        }
        if (Request.QueryString["popchat"] == "1")
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
                API.Service getWorkers_coment = new API.Service();
                XmlDocument dom3 = new XmlDocument();
                dom3.LoadXml("<XML>" + getWorkers_coment.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
                XmlNodeList Response3 = dom3.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                string comment_chek = Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                string initial_comment_time = "";
                string initial_comment = "";
                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    DateTime thisDay = DateTime.Now;
                    string vendorID = Session["VendorID"].ToString();
                    conn.Open();
                    //string strSql = "   select cast(interview_date as datetime) + (select cast(interview_time as datetime) ) as interview " +
                    //                  "  from ovms_employee_actions " +
                    //                  "  where client_id = '" + Session["ClientID"].ToString() + "' and interview_confirm = 1 and(cast(interview_date as datetime) + (select cast(interview_time as datetime)))  BETWEEN DATEADD(HOUR, 3, GETDATE()) and DATEADD(minute, +15, DATEADD(HOUR, 3, GETDATE())) ";

                    string strSql = "select create_date as cd from ovms_employee_actions where employee_id=" + employeeID;

                    SqlCommand cmd12 = new SqlCommand(strSql, conn);
                    SqlDataReader reader23 = cmd12.ExecuteReader();
                    if (reader23.HasRows)
                    {
                        while (reader23.Read())
                        {
                            initial_comment_time = reader23["cd"].ToString();


                        }
                        cmd12.Dispose();
                        reader23.Close();
                        conn.Close();
                    }
                   
                    if (comment_chek != "")
                    {
                        initial_comment = "(" + initial_comment_time + ") Client: " + Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                    }
                    else
                    {
                        initial_comment = "";
                    }
                 
                }
                string vendor_msg = Response01[iResponse13].SelectSingleNode("FROM_VENDOR").InnerText;
                if (vendor_msg == "1")
                {
                    previous_commnt = Server.HtmlDecode(previous_commnt + "\n" + "(" + Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG_TIME").InnerText + ")Vendor:  " + (Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG").InnerText));
                }
                else
                {
                    previous_commnt = Server.HtmlDecode(previous_commnt + "\n" + "(" + Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG_TIME").InnerText + ")Client:  " + (Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG").InnerText));

                }


                txtAllchats.Text = previous_commnt + "\n" + initial_comment;
            }
            //txtREschedulechat.Text = previous_commnt.ToString();

            //this code is to chek msg status from the vendor in interview table
            API.Service isreadStatus = new API.Service();
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");

        }
        if (Request.QueryString["foreyecon"] == "1")
        {
            //  following code is for getting all interview comment from i button
            string employeeID = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getComments2 = new API.Service();
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml("<XML>" + getComments2.get_interview_msg(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
            XmlNodeList Response01 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
            string previous_commnt = "";
            API.Service getWorkers_coment = new API.Service();
            XmlDocument dom3 = new XmlDocument();
            dom3.LoadXml("<XML>" + getWorkers_coment.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response3 = dom3.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            string comment_chek = Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
            string initial_comment_time = "";
            string initial_comment = "";
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                DateTime thisDay = DateTime.Now;
                string vendorID = Session["VendorID"].ToString();
                conn.Open();
                //string strSql = "   select cast(interview_date as datetime) + (select cast(interview_time as datetime) ) as interview " +
                //                  "  from ovms_employee_actions " +
                //                  "  where client_id = '" + Session["ClientID"].ToString() + "' and interview_confirm = 1 and(cast(interview_date as datetime) + (select cast(interview_time as datetime)))  BETWEEN DATEADD(HOUR, 3, GETDATE()) and DATEADD(minute, +15, DATEADD(HOUR, 3, GETDATE())) ";

                string strSql = "select create_date as cd from ovms_employee_actions where employee_id=" + employeeID;

                SqlCommand cmd12 = new SqlCommand(strSql, conn);
                SqlDataReader reader23 = cmd12.ExecuteReader();
                if (reader23.HasRows)
                {
                    while (reader23.Read())
                    {
                        initial_comment_time = reader23["cd"].ToString();


                    }
                }

                if (comment_chek != "")
                {
                    initial_comment = "(" + initial_comment_time + ") Client: " + Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                }
                else
                {
                    initial_comment = "";
                }
                conn.Close();
                reader23.Close();
                cmd12.Dispose();
            }

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

            txtConfirmINT.Text = previous_commnt + "\n" + initial_comment;
            //this code is to chek msg status from the vendor in interview table
            API.Service isreadStatus = new API.Service();
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");

        }
        if (Request.QueryString["forImsg"] == "1")
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
                API.Service getWorkers_coment = new API.Service();
                XmlDocument dom3 = new XmlDocument();
                dom3.LoadXml("<XML>" + getWorkers_coment.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
                XmlNodeList Response3 = dom3.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                string comment_chek = Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                string initial_comment_time = "";
                string initial_comment = "";
                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    DateTime thisDay = DateTime.Now;
                    string vendorID = Session["VendorID"].ToString();
                    conn.Open();
                    //string strSql = "   select cast(interview_date as datetime) + (select cast(interview_time as datetime) ) as interview " +
                    //                  "  from ovms_employee_actions " +
                    //                  "  where client_id = '" + Session["ClientID"].ToString() + "' and interview_confirm = 1 and(cast(interview_date as datetime) + (select cast(interview_time as datetime)))  BETWEEN DATEADD(HOUR, 3, GETDATE()) and DATEADD(minute, +15, DATEADD(HOUR, 3, GETDATE())) ";

                    string strSql = "select create_date as cd from ovms_employee_actions where employee_id=" + employeeID;

                    SqlCommand cmd12 = new SqlCommand(strSql, conn);
                    SqlDataReader reader23 = cmd12.ExecuteReader();
                    if (reader23.HasRows)
                    {
                        while (reader23.Read())
                        {
                            initial_comment_time = reader23["cd"].ToString();


                        }
                    }

                    if (comment_chek != "")
                    {
                        initial_comment = "\n(" + initial_comment_time + ") Client: " + Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                    }
                    else
                    {
                        initial_comment = "";
                    }
                    conn.Close();
                    cmd12.Dispose();
                    reader23.Close();
                }
                string vendor_msg = Response01[iResponse13].SelectSingleNode("FROM_VENDOR").InnerText;
                if (vendor_msg == "1")
                {
                    previous_commnt = Server.HtmlDecode(previous_commnt + "\n" + "(" + Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG_TIME").InnerText + ")Vendor:  " + (Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG").InnerText));
                }
                else
                {
                    previous_commnt = Server.HtmlDecode(previous_commnt + "\n" + "(" + Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG_TIME").InnerText + ")Client:  " + (Response01[iResponse13].SelectSingleNode("MORE_INFO_MSG").InnerText));

                }
                txtfrstaction.Text = previous_commnt + "\n" + initial_comment;
            }

           
            //this code is to chek msg status from the vendor in interview table
            API.Service isreadStatus = new API.Service();
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");

        }
        if (Request.QueryString["foreye1"] == "1")
        {
            //  following code is for getting all interview comment from i button
            string employeeID = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getComments2 = new API.Service();
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml("<XML>" + getComments2.get_interview_msg(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
            XmlNodeList Response01 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
            string previous_commnt = "";

            API.Service getWorkers_coment = new API.Service();
            XmlDocument dom3 = new XmlDocument();
            dom3.LoadXml("<XML>" + getWorkers_coment.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response3 = dom3.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            string comment_chek = Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
            string initial_comment_time = "";
            string initial_comment = "";
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                DateTime thisDay = DateTime.Now;
                string vendorID = Session["VendorID"].ToString();
                conn.Open();
                //string strSql = "   select cast(interview_date as datetime) + (select cast(interview_time as datetime) ) as interview " +
                //                  "  from ovms_employee_actions " +
                //                  "  where client_id = '" + Session["ClientID"].ToString() + "' and interview_confirm = 1 and(cast(interview_date as datetime) + (select cast(interview_time as datetime)))  BETWEEN DATEADD(HOUR, 3, GETDATE()) and DATEADD(minute, +15, DATEADD(HOUR, 3, GETDATE())) ";

                string strSql = "select create_date as cd from ovms_employee_actions where employee_id=" + employeeID;

                SqlCommand cmd12 = new SqlCommand(strSql, conn);
                SqlDataReader reader23 = cmd12.ExecuteReader();
                if (reader23.HasRows)
                {
                    while (reader23.Read())
                    {
                        initial_comment_time = reader23["cd"].ToString();


                    }
                }

                if (comment_chek != "")
                {
                    initial_comment = "\n(" + initial_comment_time + ") Client: " + Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                }
                else
                {
                    initial_comment = "";
                }
                conn.Close();
                reader23.Close();
                cmd12.Dispose();
            }
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

            txtMessage2.Text = previous_commnt + "\n" + initial_comment;
            //this code is to chek msg status from the vendor in interview table
            API.Service isreadStatus = new API.Service();
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");

        }

        // upper code is for getting all interview comment from i button
        //  following code is for getting all interview comment from i button

        if (Request.QueryString["foreye"] == "1")
        {

            string employeeID = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getComments = new API.Service();
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml("<XML>" + getComments.get_interview_msg(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
            XmlNodeList Response01 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
            string previous_commnt = "";
            API.Service getWorkers_coment = new API.Service();
            XmlDocument dom3 = new XmlDocument();
            dom3.LoadXml("<XML>" + getWorkers_coment.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response3 = dom3.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
            string comment_chek = Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
            string initial_comment_time = "";
            string initial_comment = "";
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                DateTime thisDay = DateTime.Now;
                string vendorID = Session["VendorID"].ToString();
                conn.Open();
                //string strSql = "   select cast(interview_date as datetime) + (select cast(interview_time as datetime) ) as interview " +
                //                  "  from ovms_employee_actions " +
                //                  "  where client_id = '" + Session["ClientID"].ToString() + "' and interview_confirm = 1 and(cast(interview_date as datetime) + (select cast(interview_time as datetime)))  BETWEEN DATEADD(HOUR, 3, GETDATE()) and DATEADD(minute, +15, DATEADD(HOUR, 3, GETDATE())) ";

                string strSql = "select create_date as cd from ovms_employee_actions where employee_id=" + employeeID;

                SqlCommand cmd12 = new SqlCommand(strSql, conn);
                SqlDataReader reader23 = cmd12.ExecuteReader();
                if (reader23.HasRows)
                {
                    while (reader23.Read())
                    {
                        initial_comment_time = reader23["cd"].ToString();


                    }
                }

                if (comment_chek != "")
                {
                    initial_comment = "(" + initial_comment_time + ") Client: " + Response3[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                }
                else
                {
                    initial_comment = "";
                }
                conn.Close();
                reader23.Close();
                cmd12.Dispose();
            }

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

            messages.Text = previous_commnt + "\n" + initial_comment;
            //this code is to chek msg status from the vendor in interview table
            API.Service isreadStatus = new API.Service();
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");


        }
        // upper code is for getting all interview comment from i button


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
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), "", "", Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
        string disable = "";
        string rejected = "";
        string more_info = "";
        string cand_approve = "";
        string interview_date = "";
        string interview_confirm1 = "";
        string interview_time = "";
        string schedule = "";
        string job_end_date = "";
        string emp_end_date = "";
        string job_id = "";
        string more_info_reply = "";
        string message_time = "";
        string vendor_reject_candidate = "";
        string interview_rescheduled;

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
            rejected = Response[iResponse].SelectSingleNode("CANDIDATE_REJECTED").InnerText;
            vendor_reject_candidate = Response[iResponse].SelectSingleNode("VENDOR_REJECT_CANDIDATE").InnerText;


            DateTime thisday = DateTime.Today;

            //  if (worker_status != "1" || (candidate_start_date >= thisday) )
            if ((worker_status != "1" || (candidate_start_date >= thisday)) && (rejected != "1" && vendor_reject_candidate != "1"))
            {
               

                    sTable = sTable + "<tr " + _sBackground + ">";
                    sTable = sTable + "<td>" + CountRows + "</td>";
                    //sTable = sTable + "<td>" + Response[iResponse].SelectSingleNode("ACTIVE").InnerText + " </TD>";
                    sTable = sTable + "<td><a href='Client_View_Worker_detail.aspx?copen=Y&p=VW&empid=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "'>" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "</a> </td> ";
                    sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response[iResponse].SelectSingleNode("LASTNAME").InnerText) + "</td> ";
                    sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText) + " </td> ";
                    sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("LOCATION").InnerText) + " </td> ";
                    sTable = sTable + "<td>" + DateTime.Parse(Response[iResponse].SelectSingleNode("STARTDATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                    sTable = sTable + "<td>" + DateTime.Parse(Response[iResponse].SelectSingleNode("ENDDATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
                    sTable = sTable + "<td>" + func.FixString(Response[iResponse].SelectSingleNode("VENDOR_NAME").InnerText) + " </td> ";
                    DateTime cand_start_date = DateTime.Parse(Response[iResponse].SelectSingleNode("STARTDATE").InnerText);
                    cand_start_date = DateTime.Parse(Response[iResponse].SelectSingleNode("STARTDATE").InnerText);
                    string cand_start_date1 = DateTime.Parse((cand_start_date.ToString().Replace("12:00:00 AM", ""))).ToString("dd MMM, yyyy");
                    job_end_date = Response[iResponse].SelectSingleNode("CONTRACT_END_DATE").InnerText;
                    job_id = Response[iResponse].SelectSingleNode("JOB_ID").InnerText;
                    emp_end_date = Response[iResponse].SelectSingleNode("ENDDATE").InnerText;
                    disable = Response[iResponse].SelectSingleNode("INTERVIEW_REQUESTED").InnerText;
                    interview_date = Response[iResponse].SelectSingleNode("INTERVIEW_DATE").InnerText;
                    interview_time = Response[iResponse].SelectSingleNode("INTERVIEW_TIME").InnerText;
                    rejected = Response[iResponse].SelectSingleNode("CANDIDATE_REJECTED").InnerText;
                    more_info = Response[iResponse].SelectSingleNode("MORE_INFO").InnerText;
                    cand_approve = Response[iResponse].SelectSingleNode("CANDIDATE_APPROVE").InnerText;
                    interview_confirm1 = Response[iResponse].SelectSingleNode("INTERVIEW_CONFIRM").InnerText;
                    if (interview_date != "" && interview_time != "")
                    {
                        schedule = " " + DateTime.Parse((interview_date.ToString().Replace("12:00:00 AM", ""))).ToString("dd MMM, yyyy") + " at " + (interview_time.ToString()).ToString();
                    }
                    //schedule = DateTime.Parse((interview_date.ToString().Replace("12:00:00 AM", ""))).ToString("dd MMM, yyyy") + "at " +(interview_time.ToString());

                    DateTime contract_start_date = DateTime.Parse(Response[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText);
                    vendor_reject_candidate = Response[iResponse].SelectSingleNode("VENDOR_REJECT_CANDIDATE").InnerText;
                    if (Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT").InnerText != "" || Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT2").InnerText != "" || Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT3").InnerText != "" || Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT4").InnerText != "" || Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT5").InnerText != "")
                    {
                        // divcomments.Visible = false; // to hide comment on reschedule popup
                        if (Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT").InnerText != "")
                        {
                            // lblmsg.Visible = true;
                            // lblmsg.Text = "Comment1: " + Server.HtmlEncode(Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT").InnerText);
                        }
                        if (Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT2").InnerText != "")
                        {
                            //  lblmsg.Visible = true;
                            // lblmsg2.Visible = true;
                            // lblmsg2.Text = "Comment2: " + Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT2").InnerText;
                        }
                        if (Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT3").InnerText != "")
                        {
                            // lblmsg.Visible = true;
                            // lblmsg2.Visible = true;
                            // lblmsg3.Visible = true;
                            // lblmsg3.Text = "Comment3: " + Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT3").InnerText;
                        }
                        if (Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT4").InnerText != "")
                        {
                            //  lblmsg.Visible = true;
                            //  lblmsg2.Visible = true;
                            //  lblmsg3.Visible = true;
                            //  lblmsg4.Visible = true;
                            //  lblmsg4.Text = "Comment4: " + Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT4").InnerText;

                        }
                        if (Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT5").InnerText != "")
                        {
                            //  lblmsg.Visible = true;
                            // lblmsg2.Visible = true;
                            //  lblmsg3.Visible = true;
                            //   lblmsg4.Visible = true;
                            ///  lblmsg5.Visible = true;
                            //   lblmsg5.Text = "Comment5: " + Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT5").InnerText;
                        }
                    }
                    more_info_reply = Response[iResponse].SelectSingleNode("VENDOR_MOREINFO_REPLY").InnerText;
                    message_time = Response[iResponse].SelectSingleNode("ACTION_CREATE_DATE").InnerText;
                    interview_rescheduled = Response[iResponse].SelectSingleNode("INTERVIEW_RESHEDULED").InnerText;

                    DateTime today = DateTime.Now;
                string job_id1 = Response[iResponse].SelectSingleNode("JOB_ID").InnerText;
                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    DateTime thisDay = DateTime.Now;
                    string vendorID = Session["VendorID"].ToString();
                    conn.Open();

                    string strSql = "select interview_requirement from ovms_job_posting_info where job_id = '" + job_id1 + "'";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        interview_requirement = reader["interview_requirement"].ToString();
                    }
                }
                if (interview_requirement == "No")
                {
                    sTable = sTable + "<td>No Interview Required</td>";

                }
                else
                {
                    if (Response[iResponse].SelectSingleNode("INTERVIEW_CANCEL_BY_CLIENT").InnerText == "1")
                    {
                        string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));
                        API.Service getMSGcount = new API.Service();
                        XmlDocument doc1 = new XmlDocument();
                        doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                        XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
                        if (Response07.Count != 0)
                        // upper code is for getting all interview comment from i button
                        {
                            int no_of_msg = Response07.Count;
                            sTable = sTable + "<td>Interview Cancelled by Client<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a></td>";


                        }
                        else
                        {

                            sTable = sTable + "<td>Interview Cancelled by Client<br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a></td>";



                        }
                    }
                    else
                    {
                        if ((interview_date != "") && (rejected == "0") && (more_info == "") && (cand_approve == ""))
                        {


                            if (interview_confirm1 == "1")
                            {
                                string vendor_comment = Response[iResponse].SelectSingleNode("VENDOR_INTERVIEW_COMMENT").InnerText;
                                if (vendor_comment == "")
                                {
                                    sTable = sTable + "<td><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='Reschedule Interview'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<br>Interview confirmed for:<br>" + schedule + "</ td>";
                                }
                                else
                                {

                                    string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));
                                    API.Service getMSGcount = new API.Service();
                                    XmlDocument doc1 = new XmlDocument();
                                    doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                                    XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
                                    if (Response07.Count != 0)
                                    // upper code is for getting all interview comment from i button
                                    {
                                        int no_of_msg = Response07.Count;
                                        sTable = sTable + "<td>Interview confirmed for:<br>" + schedule + "<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></ td>";
                                    }
                                    else
                                    {
                                        sTable = sTable + "<td>Interview confirmed for:<br>" + schedule + "<br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a><br></ td>";

                                    }
                                }
                            }
                            else

                            {
                                if (interview_rescheduled == "1")
                                {
                                    string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));
                                    API.Service getMSGcount = new API.Service();
                                    XmlDocument doc1 = new XmlDocument();
                                    doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                                    XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");

                                    if (Response07.Count != 0)
                                    {


                                        int no_of_msg = Response07.Count;



                                        sTable = sTable + "<td>Interview Rescheduled for:<br>" + schedule + "<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreye=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";
                                    }
                                    else
                                    {
                                        sTable = sTable + "<td>Interview Rescheduled for:<br>" + schedule + "<br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreye=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a>&nbsp;<br></td>";


                                    }

                                }
                                else
                                {
                                    if (interview_rescheduled == "")
                                    {
                                        string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));

                                        API.Service getMSGcount = new API.Service();
                                        XmlDocument doc1 = new XmlDocument();
                                        doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                                        XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");

                                        if (Response07.Count != 0)
                                        {
                                            int no_of_msg = Response07.Count;
                                            sTable = sTable + "<td>Interview Requested for:<br>" + schedule + "<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreye1=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";
                                        }
                                        else
                                        {
                                            sTable = sTable + "<td>Interview Requested for:<br>" + schedule + "<br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreye1=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";

                                        }
                                    }
                                }
                            }

                            //else

                            //{
                            //    sTable = sTable + "<td>Interview Requested</td>";
                            //}
                        }
                        else

                           if ((rejected != "") && (disable == "") && (more_info == "") && (rejected != "0") && (cand_approve == ""))
                        {
                            string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));
                            API.Service getMSGcount = new API.Service();
                            XmlDocument doc1 = new XmlDocument();
                            doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                            XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
                            if (Response07.Count != 0)
                            // upper code is for getting all interview comment from i button
                            {
                                sTable = sTable + "<td>Rejected<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a></td>";
                            }
                            else

                            {
                                sTable = sTable + "<td>Rejected<br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a></td>";

                            }
                        }
                        else

                                if ((rejected == "0") && (disable == "") && (more_info != "") && (cand_approve == ""))
                        {

                            if (more_info_reply != "")

                            {
                                lblinformationneeded.Text = "Other Information Required by Client: " + more_info + "<br>";
                                // lblinformationneeded.Text = "Information Required: " + more_info;
                                lblMoreinfomsg.Text = "Information provided by the vendor: " + more_info_reply + " &nbsp; &nbsp; &nbsp; &nbsp; ";
                                string replied_msg = "Information provided by the vendor:" + more_info_reply + "...for message view click button";
                                sTable = sTable + "<td>Information received<br><a href='C_View_Candidate.aspx?copen=Y&p=VC&actionID2=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&moreinfomsg=" + 1 + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='" + replied_msg + "'><i class='fa fa-fw fa-info'></i></a>&nbsp; " +
                                 "<a href='C_View_Candidate.aspx?copen=Y&p=VC&actionID2=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&employeeid1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&moreinfomsg1=" + 1 + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-success btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Request interview schedule'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;" +
                                 "<a href='C_View_Candidate.aspx?copen=Y&p=VC&actionID3=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&employeeid2=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&moreinfomsg2=" + 1 + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a></td>";

                            }
                            else
                                sTable = sTable + "<td>More Information Needed</td>";
                        }
                        else

                                if ((rejected == "0") && (disable == "") && (more_info == "") && (cand_approve != ""))
                        {

                            sTable = sTable + "<td> Candidate set to start on:<br>" + cand_start_date1 + " </td>";
                        }
                        else
                        if (vendor_reject_candidate == "1")
                        {
                            string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));

                            API.Service getMSGcount = new API.Service();
                            XmlDocument doc1 = new XmlDocument();
                            doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                            XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
                            //rejection_reason.Text = (Response[iResponse].SelectSingleNode("VENDOR_REJECT_CANDIDATE_COMMENT").InnerText);
                            if (Response07.Count != 0)
                            {

                                sTable = sTable + "<td ><a href='C_View_Candidate.aspx?copen=Y&p=VC&reject_reason1=1&emp_id=" + employeeID + "'><font color='red'>Candidate Rejected By Vendor</font></a><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreye1=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";
                                //  </blink>   < i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href = 'C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href = 'C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a>
                            }
                            else
                            {
                                sTable = sTable + "<td ><a href='C_View_Candidate.aspx?copen=Y&p=VC&reject_reason1=1&emp_id=" + employeeID + "'><font color='red'>Candidate Rejected By Vendor</font></a><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreye1=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";

                                // sTable = sTable + "<td><a href='C_View_Candidate.aspx?copen=Y&p=VC&reject_reason=1'><font color='red'>Candidate Rejected By Vendor</font></a><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a></td>";
                            }
                        }

                        else
                        {
                            string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));
                            API.Service getMSGcount = new API.Service();
                            XmlDocument doc1 = new XmlDocument();
                            doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                            XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");

                            if (Response07.Count != 0)
                            {
                                int no_of_msg = Response07.Count;
                                sTable = sTable + "<td><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='C_View_Candidate.aspx?copen=Y&p=VC&done=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-calendar fa-fw'></i></a>&nbsp; " +
                                                  "<a href='C_View_Candidate.aspx?copen=Y&p=VC&Reject=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a>&nbsp; " +
                                                  "<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&forImsg=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";

                            }
                            else
                            {
                                sTable = sTable + "<td><a href='C_View_Candidate.aspx?copen=Y&p=VC&done=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-calendar fa-fw'></i></a>&nbsp; " +
                                                  "<a href='C_View_Candidate.aspx?copen=Y&p=VC&Reject=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a>&nbsp; " +
                                                  "<a href='C_View_Candidate.aspx?copen=Y&p=VC&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&forImsg=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";


                            }

                        }

                    }
                    
                }

                CountRows++;
            }
            sTable = sTable + "</tr>";
          

        }
        sTable = sTable + "</tbody>";
        getWorkers.Dispose();
        lblTableData.Text = sTable;

    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("C_View_Candidate.aspx?txtComments=" + txtComments1.Text + "&job_id="+Request.QueryString["job_id"].ToString() + "&Reject02=" + Request.QueryString["Reject"].ToString() +  "&makesure7=" + 1 +"&job_end=" + Request.QueryString["job_end_date"].ToString() +" &emp_end=" + Request.QueryString["emp_enddate"].ToString());


        //Response.Redirect("emp_actions.aspx?txtComments=" + txtComments1.Text + "&Reject=" + Request["Reject"].ToString() + "&job_id=" + Request["job_id1"].ToString() + "&job_end=" + Request["job_end_date1"].ToString() + "&emp_end=" + Request["emp_end_date1"].ToString());
        //Response.End();
    }

    protected void BtnMoreInfo_Click(object sender, EventArgs e)
    {


       // Response.Redirect("emp_actions.aspx?txtComments=" + txtComments2.Text + "&More=" + Request["More"].ToString() + "&job_id=" + Request["job_id1"].ToString() + "&job_end=" + Request["job_end_date1"].ToString() + "&emp_end=" + Request["emp_end_date1"].ToString());
        Response.End();
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if ((checkurgent.Checked) == true)
        {
            string chk = "yes";
            Response.Redirect("C_View_Candidate.aspx?txtComments=" + txtComments2.Text + "&approve=" + Request["approve"].ToString() +"&makesure="+1+"&job_id=" + Request["job_id1"].ToString() + "&job_end=" + Request["job_end_date1"].ToString() + " &emp_end=" + Request["emp_end_date1"].ToString());

            

        }
        string interview_comment = txtsubmitintervew.Text;
        string date = Textdate.Value;
        string time = ddtime.Text;
       Response.Redirect("C_View_Candidate.aspx?txtComments=" + txtComments2.Text + "&approve=" + Request["approve"].ToString() + "&intComment=" + interview_comment + "&makesure2=" + 1 + "&job_id=" + Request["job_id1"].ToString() + "&job_end=" + Request["job_end_date1"].ToString() + "&time=" + time + "&date=" + date + " &emp_end=" + Request["emp_end_date1"].ToString());
        Response.End();
    }



    //protected void BtnReshedule_Click(object sender, EventArgs e)
    //{
    //    string abc = "";

    //  //  if (ChkApproveCand.Checked == true)
    //    {
    //        //approve after interview
    //        string action_id = (Request.QueryString["action_id"]);
    //        API.Service getWorkers = new API.Service();
    //        DateTime thisDay = DateTime.Now.AddHours(1);
    //        XmlDocument dom1 = new XmlDocument();
    //        dom1.LoadXml("<XML>" + getWorkers.candidate_approve_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
    //        Response.Redirect("Client_View_worker.aspx?copen=Y&p=VC");

    //    }
    //    else
    //    //    if (chkRejectCand.Checked == true)

    //    {
    //        //reject after interview
    //        string action_id = (Request.QueryString["action_id"]);
    //        API.Service getWorkers = new API.Service();
    //        DateTime thisDay = DateTime.Now.AddHours(1);
    //        XmlDocument dom1 = new XmlDocument();
    //        dom1.LoadXml("<XML>" + getWorkers.candidate_reject_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
    //        Response.Redirect("Client_View_worker.aspx?copen=Y&p=VC");

    //    }
    //    else
    //    {
    //        string action_id = Request["action_id"].ToString();

    //        string new_interview_date = TxtNewdate.Value;
    //        string new_interview_time = DDnewtime.Text;
    //        string new_comments = "hardcoded value";
    //        Response.Redirect("emp_actions.aspx?newcomments=" + new_comments + "&action_id=" + action_id + "&reshedule=" + 1 + "&newdate=" + new_interview_date + "&newtime=" + new_interview_time);
    //    }
    //    }

    protected void Btninterview_moreinfo_Click(object sender, EventArgs e)
    {
        string action_id3 = Request["actionID"].ToString();
        DateTime new_interview_date = DateTime.Parse(Txtinterview_date.Value);
        string new_interview_time = ddinterview_moreinfo.Text;
        string new_comments = txtcommnt_int_moreinfo.Text;
        string emp_id = (Request.QueryString["employeeid1"].Substring(Request.QueryString["employeeid1"].Length - 6));
        string job_id3 = Request["job_id1"].ToString();
        string job_end = Request["job_end_date1"].ToString();
        string emp_end = Request["emp_end_date1"].ToString();
        string test = "";
        API.Service getWorkers = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.interview_request2(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["ClientID"].ToString(), emp_id, "1", new_interview_date, new_interview_time, job_id3, emp_end, job_end, "", "", action_id3, new_comments).InnerXml + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    }

    protected void btnreject2_Click(object sender, EventArgs e)
    {

        string emp_id = (Request.QueryString["employeeid2"].Substring(Request.QueryString["employeeid2"].Length - 6));
        string reject_reason2 = txtReason2.Text;


        //API.Service getWorkers = new API.Service();
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + getWorkers.reject_candidate2(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["ClientID"].ToString(), emp_id, reject_reason2).InnerXml + "</XML>");
        //Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    }

    //protected void btncancelinterview_Click(object sender, EventArgs e)
    //{
    //    string actionID = Request.QueryString["action_id"];
    //    //string cancel_comment = "Interview cancelled by client";
    //    //DateTime thisDay = DateTime.Now.AddHours(1);
    //    //API.Service cancel_interview = new API.Service();
    //    //XmlDocument dom1 = new XmlDocument();
    //    //dom1.LoadXml("<XML>" + cancel_interview.interview_cancel_by_client(Session["Email"].ToString(), Session["P@ss"].ToString(), actionID, "", "", "", "", "", "1", thisDay.ToString(), cancel_comment) + "</XML>");
    //    //Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    //    Response.Redirect("C_View_Candidate.aspx?txtComments=" + txtComments2.Text + "&approve=" + Request["approve"].ToString() +"&makesure="+1+"&job_id=" + Request["job_id1"].ToString() + "&job_end=" + Request["job_end_date1"].ToString() + " &emp_end=" + Request["emp_end_date1"].ToString());


    //}

    protected void btneye_Click(object sender, EventArgs e)
    {
        string coments = txtEYEMSG.Text;
        string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 6));
        DateTime thisDay = DateTime.Now;
        API.Service eye_msg = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + eye_msg.more_info_msg_eye(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, Session["VendorID"].ToString(), "1", Session["ClientID"].ToString(), coments, thisDay, "", "1") + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    }

    protected void BtnMSG2_Click(object sender, EventArgs e)
    {
        string coments = TxtMSG2.Text;
        string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 6));
        DateTime thisDay = DateTime.Now;
        API.Service eye_msg = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + eye_msg.more_info_msg_eye(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, Session["VendorID"].ToString(), "1", Session["ClientID"].ToString(), coments, thisDay, "", "1") + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");

    }

    protected void btnConfirmintcomment_Click(object sender, EventArgs e)
    {
        string coments = txtConfirmInt2.Text;
        string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 6));
        DateTime thisDay = DateTime.Now;
        API.Service eye_msg = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + eye_msg.more_info_msg_eye(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, Session["VendorID"].ToString(), "1", Session["ClientID"].ToString(), coments, thisDay, "", "1") + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    }

    protected void btnFRSTaction_Click(object sender, EventArgs e)
    {
        string coments = txtfrstaction2.Text;
        string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 6));
        DateTime thisDay = DateTime.Now;
        API.Service eye_msg = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + eye_msg.more_info_msg_eye(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, Session["VendorID"].ToString(), "1", Session["ClientID"].ToString(), coments, thisDay, "", "1") + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    }

    protected void btnCOMMENTs_Click(object sender, EventArgs e)
    {
        string coments = txtfrstaction2.Text;
        string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 6));
        DateTime thisDay = DateTime.Now;
        API.Service eye_msg = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + eye_msg.more_info_msg_eye(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, Session["VendorID"].ToString(), "1", Session["ClientID"].ToString(), coments, thisDay, "", "1") + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    }



    protected void btncancelINTErview_Click(object sender, EventArgs e)
    {
        string actionID = Request.QueryString["action_id"];
        //string cancel_comment = "Interview cancelled by client";
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //API.Service cancel_interview = new API.Service();
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + cancel_interview.interview_cancel_by_client(Session["Email"].ToString(), Session["P@ss"].ToString(), actionID, "", "", "", "", "", "1", thisDay.ToString(), cancel_comment) + "</XML>");
        //Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
        Response.Redirect("C_View_Candidate.aspx?action_id03=" + actionID + "&emp_id=" + Request["emp_id"].ToString() + "&makesure6=" + 1 + "&cand_name=" + Request.QueryString["cand_name"] + "&job_title=" + Request.QueryString["job_title"]);


    }

    protected void btnRejectCandidate_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id"]);
        //API.Service getWorkers = new API.Service();
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + getWorkers.candidate_reject_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        //Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
        Response.Redirect("C_View_Candidate.aspx?action_id02=" + action_id + "&makesure5=" + 1 + "&job_title=" + Request.QueryString["job_title"] + "&cand_name=" + Request.QueryString["cand_name"]);

    }

    protected void btnApproveCandidate_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id"]);
        //API.Service getWorkers = new API.Service();
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + getWorkers.candidate_approve_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        //Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
        Response.Redirect("C_View_Candidate.aspx?action_id02=" + action_id + "&makesure4=" + 1 + "&job_title=" + Request.QueryString["job_title"] + "&cand_name=" + Request.QueryString["cand_name"]);

    }

    protected void btnRescdhle_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id"]);
        DateTime new_date = DateTime.Parse(TxtNewdate1.Value);
        string new_time = DDnewtime1.Text;
        Response.Redirect("C_View_Candidate.aspx?action_id01=" + action_id + "&makesure3=" + 1+"&new_date="+new_date+"&new_time="+new_time+"&emp_id="+Request.QueryString["emp_id"] +"&cand_name="+Request.QueryString["cand_name"] );

        //API.Service getWorkers = new API.Service();
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + getWorkers.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, new_date, new_time, "1", "null", "1", "", "", "", "", "", "", thisDay.ToString()).InnerXml + " </XML>");
      


    }

    protected void btnApproveCand_Click(object sender, EventArgs e)
    {
        string chk = "yes";
        Response.Redirect("emp_actions.aspx?txtComments=" + txtComments2.Text + "&approve=" + Request.QueryString["approve"].ToString() + "&chkapprove=" + chk + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + " &emp_end=" + Request.QueryString["emp_end"].ToString());
        Response.End();

    }

    protected void btninterviewReqConfrm_Click(object sender, EventArgs e)
    {
        string interview_comment = Request.QueryString["intComment"];
        string date = Request.QueryString["date"];
        string time = Request.QueryString["time"];
        Response.Redirect("emp_actions.aspx?txtComments=" + interview_comment + "&approve=" + Request.QueryString["approve"].ToString() + "&intComment=" + interview_comment +  "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + "&time=" +Request.QueryString [ "time"] + "&date=" +Request.QueryString[ "date"] + " &emp_end=" + Request.QueryString["emp_end"].ToString());
        Response.End();
    }

    protected void btnREscheduleTime_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id01"]);
        DateTime new_date = DateTime.Parse(Request.QueryString["new_date"]);
        string new_time = Request.QueryString["new_time"];
        API.Service getWorkers = new API.Service();
        DateTime thisDay = DateTime.Now.AddHours(1);
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, new_date, new_time, "1", "null", "1", "", "", "", "", "", "", thisDay.ToString()).InnerXml + " </XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");


    }

    protected void btnapprovePerson_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id02"]);
        API.Service getWorkers = new API.Service();
        DateTime thisDay = DateTime.Now.AddHours(1);
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.candidate_approve_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");

    }

    protected void btnrjctperson_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id02"]);
        API.Service getWorkers = new API.Service();
        DateTime thisDay = DateTime.Now.AddHours(1);
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.candidate_reject_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");


    }

    protected void btnCancelIntview_Click(object sender, EventArgs e)
    {
        string actionID = Request.QueryString["action_id03"];
        string cancel_comment = "Interview cancelled by client";
        DateTime thisDay = DateTime.Now.AddHours(1);
        API.Service cancel_interview = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + cancel_interview.interview_cancel_by_client(Session["Email"].ToString(), Session["P@ss"].ToString(), actionID, "", "", "", "", "", "1", thisDay.ToString(), cancel_comment) + "</XML>");
        Response.Redirect("C_View_Candidate.aspx?copen=Y&p=VC");
    }

    protected void btnrejectcan_Click(object sender, EventArgs e)
    {
        string employeeID = (Request.QueryString["Reject02"].Substring(Request.QueryString["Reject02"].Length - 5));
        Response.Redirect("emp_actions.aspx?txtComments=" + Request.QueryString["txtComments"] + "&Reject=" + Request.QueryString["Reject02"].ToString() + "&job_id=" + Request.QueryString["job_id"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + "&emp_end=" + Request["emp_end"].ToString());
        Response.End();
    }
}