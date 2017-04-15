using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Client_Job_Details : System.Web.UI.Page
{
    public string canPhoto { get; set; }
    public string canResume { get; set; }
    string fileExtension = "";
    string UniqueDateTime = "";
    private int iResponse;
    private int intCount1;
    SqlConnection conn;
    DateTime comp_end_date;
    DateTime thisday = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        string previous_commntss = "";
        string cJOB_ID = (Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
        API.Service addcmnt = new API.Service();
        XmlDocument commments = new XmlDocument();
        commments.LoadXml("<XML>" + addcmnt.get_client_job_comment(Session["Email"].ToString(), Session["P@ss"].ToString(), cJOB_ID).InnerXml + "</XML>");
        XmlNodeList Responses12 = commments.SelectNodes("XML/RESPONSE/COMMENT_ID");
        for (int iResponse1 = 0; iResponse1 < Responses12.Count; iResponse1++)
        {
            previous_commntss = Server.HtmlDecode(previous_commntss + "\n" + "(" + Responses12[iResponse1].SelectSingleNode("CLIENT_COMMENT_TIME").InnerText + "):  " + (Responses12[iResponse1].SelectSingleNode("CLIENT_JOB_COMMENT").InnerText));

        }

        Txtarea_client_comment.Value = previous_commntss;
        if (Request.QueryString["c_confirm7"] == "1")
        {

            string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblReschCand.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lblReschJOB.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
            lblReschSCh.Text = DateTime.Parse(Request.QueryString["date"].Replace("12:00:00 AM", "")).ToString("dd MMM, yyyy")+"at"+Request.QueryString["time"];



        }
        if (Request.QueryString["c_confirm6"] == "1")
        {

            string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblCancelIntcand.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lblcancelIntJob.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;



        }
        if (Request.QueryString["c_confirm5"] == "1")
        {

            string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblrejctCand.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            LblRejctJob.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;



        }
        if (Request.QueryString["c_confirm4"] == "1")
        {

            string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblaprove.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lblaprovejob.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;



        }
        if (Request.QueryString["c_confirm3"] == "1")
        {

            string emp_id = (Request.QueryString["Reject1"].Substring(Request.QueryString["Reject1"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblRejectname.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lblRejectJobTitle.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
           


        }
        if (Request.QueryString["c_confirm2"] == "1")
        {

            string emp_id = (Request.QueryString["Approve"].Substring(Request.QueryString["Approve"].Length - 5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblInterviewCJ.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lblJbtitleCJ.Text = Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
            lblscheduleCJ.Text = Request.QueryString["date"]+" at &nbsp"+ Request.QueryString["time"];


        }
        if (Request.QueryString["c_confirm1"] == "1")
        {

            string emp_id =( Request.QueryString["Approve"].Substring(Request.QueryString["Approve"].Length-5));
            API.Service getWorkers2 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            dom2.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "", "").InnerXml + "</XML>");
            XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");

            lblAprvename.Text = Response2[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response2[iResponse].SelectSingleNode("LASTNAME").InnerText;
            lblaprvejob.Text= Response2[iResponse].SelectSingleNode("JOB_TITLE").InnerText;


        }


            if (Request.QueryString["popchek"] == "1")
        {
            string test = "";
        }
        else
        {
            if (Session["Email"] == null)
            {
                //logout
                Session.Abandon();
                Response.Redirect("Login.aspx?m=Your+session+has+timed+out");
                Response.End();
            }
            if (Page.IsPostBack)
            {
                btnsbmit.CausesValidation = false;
            }
            // if (Page.IsPostBack)
            if (Request.QueryString["c_jobchat"] == "1")
            {
                //  following code is for getting all interview comment from i button
              
                string employeeID = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 5));
                API.Service getWorkers2 = new API.Service();
                XmlDocument dom07 = new XmlDocument();
                dom07.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
                XmlNodeList Response03 = dom07.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                string interview_date01 = Response03[iResponse].SelectSingleNode("INTERVIEW_DATE").InnerText;
                string interview_time01 = Response03[iResponse].SelectSingleNode("INTERVIEW_TIME").InnerText;
                lblCandidateRE.Text = Response03[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response03[iResponse].SelectSingleNode("LASTNAME").InnerText;
                lbljobRE.Text = Response03[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
                LblScheduleRE.Text = (interview_date01.ToString().Replace("12:00:00 AM", "")) + (interview_time01.ToString()).ToString(); ;


                API.Service getComments2 = new API.Service();
                XmlDocument doc1 = new XmlDocument();
                doc1.LoadXml("<XML>" + getComments2.get_interview_msg(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                XmlNodeList Response01 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
                string previous_commnt = "";
                string comment_chek = Response03[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                string initial_comment_time = "";
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
                    conn.Close();
                }
                string initial_comment = "";
                if (comment_chek != "")
                {
                    initial_comment = "(" + initial_comment_time + ") Client: " + Response03[iResponse].SelectSingleNode("INTERVIEW_REQUEST_COMMENT").InnerText;
                }
                else
                {
                    initial_comment = "";
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

                txtfrstaction.Text = previous_commnt + "\n" + initial_comment;
                txtAllchats.Text = previous_commnt + "\n" + initial_comment;
                //this code is to chek msg status from the vendor in interview table
                API.Service isreadStatus = new API.Service();
                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");

            }
            if (Request.QueryString["Resch_int_msg"] == "1")
            {
                //  following code is for getting all interview comment from i button
                string employeeID = (Request.QueryString["Resch_int1"].Substring(Request.QueryString["Resch_int1"].Length - 5));
                API.Service getWorkers2 = new API.Service();
                XmlDocument dom07 = new XmlDocument();
                dom07.LoadXml("<XML>" + getWorkers2.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "", "", "", "", "", "").InnerXml + "</XML>");
                XmlNodeList Response03 = dom07.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                string interview_date01 = Response03[iResponse].SelectSingleNode("INTERVIEW_DATE").InnerText;
                string interview_time01 = Response03[iResponse].SelectSingleNode("INTERVIEW_TIME").InnerText;
                lblCandidateRE.Text = Response03[iResponse].SelectSingleNode("FIRSTNAME").InnerText + " " + Response03[iResponse].SelectSingleNode("LASTNAME").InnerText;
                lbljobRE.Text = Response03[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
                LblScheduleRE.Text = (interview_date01.ToString().Replace("12:00:00 AM", "")) + (interview_time01.ToString()).ToString(); ;

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
                txtAllchats.Text = previous_commnt.ToString();
                //this code is to chek msg status from the vendor in interview table
                API.Service isreadStatus = new API.Service();
                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml("<XML>" + isreadStatus.message_has_been_read2(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID, "1").InnerXml + "</XML>");

            }

            int jobID = 0;
            if (Request.QueryString["jobID"] != "")
            {
                jobID = Int32.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
            }

            API.Service jobDetails = new API.Service();
            XmlDocument _xjobDetails = new XmlDocument();
            _xjobDetails.LoadXml("<XML>" + jobDetails.get_Jobs(Convert.ToString(jobID), Session["Email"].ToString(), Session["P@ss"].ToString(), "", Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
            // _xjobDetails.LoadXml("<XML>" + jobDetails.get_Jobs("2", "srinivas.gadde@pamten.ca", "ferivan").InnerXml + "</XML>");
            string _Error = "";
            try
            {
                _Error = _xjobDetails.SelectSingleNode("XML/RESPONSE/ERROR").InnerText;
                //_xUserInfo.SelectNodes("XML/RESPONSE/JOB_NO")
            }
            catch (Exception ex)
            {
                _Error = "";
            }
            XmlNodeList Response2 = _xjobDetails.SelectNodes("XML/RESPONSE/JOBS");

            //int CountRows = 1;
            string _Job_Description = "";
            string _Job_Title = "";
            string _No_Of_Opennings = "";
            string _DepartmentName = "";
            string _ClientName = "";
            string _Job_Position_Type = "";

            string _Job_Location = "";
            string _Hours_Per_Day = "";
            string _Hiring_Manager = "";
            string _Job_Currency = "";
            string _Job_TimeZone = "";
            string _Contract_Start_Date = "";
            string _Contract_End_Date = "";
            string _Max_submittion = "";
            string _ReasonForOpen = "";
            string _Urgent = "";
            string _PayRate = "";
            string _comments = "";

            for (int intCount = 0; intCount < Response2.Count; intCount++)
            {
                _Job_Description = Server.HtmlDecode(Response2[intCount].SelectSingleNode("JOB_DESC").InnerText);
                _Job_Title = Server.HtmlDecode(Response2[intCount].SelectSingleNode("JOB_TITLE").InnerText);
                _No_Of_Opennings = Response2[intCount].SelectSingleNode("NO_OF_OPENINGS").InnerText;
                _DepartmentName = Response2[intCount].SelectSingleNode("DEPARTMENT_NAME").InnerText;
                _ClientName = Response2[intCount].SelectSingleNode("CLIENT_NAME").InnerText;
                _Job_Position_Type = Response2[intCount].SelectSingleNode("JOB_POSITION_TYPE").InnerText;
                // _Contract_Start_Date = DateTime.Parse(Response2[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("MMMM dd, yyyy");
                //_Contract_End_Date = DateTime.Parse(Response2[intCount].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("MMMM dd, yyyy");
                _Job_Location = Response2[intCount].SelectSingleNode("JOB_LOCATION").InnerText;
                _Hours_Per_Day = Response2[intCount].SelectSingleNode("HOURS_PER_DAY").InnerText;
                _Hiring_Manager = Response2[intCount].SelectSingleNode("HIRING_MANAGER_NAME").InnerText;
                _Job_Currency = Response2[intCount].SelectSingleNode("JOB_CURRENCY").InnerText;
                _Contract_Start_Date = Response2[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText;
                _Contract_End_Date = Response2[intCount].SelectSingleNode("CONTRACT_END_DATE").InnerText;
                _Job_TimeZone = Response2[intCount].SelectSingleNode("JOB_TIMEZONE").InnerText;
                _Max_submittion = Response2[intCount].SelectSingleNode("MAX_SUBMISSION_PER_SUPPLIER").InnerText;
                _ReasonForOpen = Response2[intCount].SelectSingleNode("REASON_FOR_OPEN").InnerText;
                _Urgent = Response2[intCount].SelectSingleNode("URGENT").InnerText;
                _PayRate = Response2[intCount].SelectSingleNode("STD_PAY_RATE").InnerText;
                _comments = Response2[intCount].SelectSingleNode("COMMENTS").InnerText;
                comp_end_date = DateTime.Parse(Response2[intCount].SelectSingleNode("CONTRACT_END_DATE").InnerText);

            }
            if (_Urgent == "1")
            {
                lblUrgent.Text = "(Urgent Request)";
            }
            DateTime dt = Convert.ToDateTime(_Contract_Start_Date);
            DateTime dtt = Convert.ToDateTime(_Contract_End_Date);
            //lblPostingDate.Text = dt.ToString("dddd, dd MMMM yyyy HH:mm:ss").Replace("00:00:00", "");
            lbljobtitle.Text = Server.HtmlDecode(_Job_Title);
            lblJobDescription.Text = Server.HtmlDecode(_Job_Description);
            lblpositiontype.Text = _Job_Position_Type;
            //lblNumberofPOsitions.Text = _No_Of_Opennings + " position(s) available, please respond by " + dtt.ToString("dddd, dd MMMM yyyy HH:mm:ss").Replace("00:00:00", ""); ;
            // lblLocation.Text = _Job_Location;
            //lblnoofopning.Text = _No_Of_Opennings;
            //lblstartdate.Text = _Job_Posting_Start_Date;
            //lblenddate.Text = _Job_Posting_End_Date;
            //lbllocation.Text = _Job_Location;
            //lblpayrate.Text = _PayRate;
            if (_comments == "")
            {
                lblcomments.Text = "N/A";
            }
            else
            {
                lblcomments.Text = _comments;
            }





            // API.Service web3 = new API.Service();
            API.Service web3 = new API.Service();
            XmlDocument dom33 = new XmlDocument();
            dom33.LoadXml("<XML>" + web3.get_Jobs(jobID.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
            XmlNodeList Response8 = dom33.SelectNodes("XML/RESPONSE/JOBS ");

            lblnoofopning.Text = Response8[iResponse].SelectSingleNode("NO_OF_OPENINGS").InnerText;
            lblstartdate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy");

            if (comp_end_date <= thisday) { lblenddate.Text = "Permanent Position"; }
            else
            {
                lblenddate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("dd MMM, yyyy");
            }
            lblUrgent.Text = Response8[iResponse].SelectSingleNode("URGENT").InnerText;
            lbljobtitle.Text = Server.HtmlDecode(Response8[iResponse].SelectSingleNode("JOB_TITLE").InnerText);
            lbllocation2.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
            lblbill.Text = Response8[iResponse].SelectSingleNode("STD_BILL_RATE").InnerText;
            lbladdress2.Text = Response8[iResponse].SelectSingleNode("ADDRESS1").InnerText;
            lblpay2.Text = Response8[iResponse].SelectSingleNode("STD_PAY_RATE").InnerText;
            lbllocation.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
            lbladdres.Text = Response8[iResponse].SelectSingleNode("ADDRESS1").InnerText;
            lblsalary.Text = Response8[iResponse].SelectSingleNode("BASE_SALARY").InnerText;
            lbllocation3.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
            lbladdress3.Text = Response8[iResponse].SelectSingleNode("ADDRESS1").InnerText;

            if (lblpay2.Text == "" || lblpay2.Text == "0" && (lblbill.Text == "" || lblbill.Text == "0") && (lblsalary.Text != "" || lblsalary.Text != "0"))
            //  if (z == "0" && p != "0" && q == "0")
            {
                y.Visible = false;
                x.Visible = false;
                w.Visible = true;

            }
            else if (lblbill.Text == null || lblbill.Text == "0" && (lblpay2.Text != null || lblpay2.Text != "0") && (lblsalary.Text == "" || lblsalary.Text == "0"))
            // else if (z != "0" && p == "0" && q == "0")
            {
                y.Visible = false;
                x.Visible = true;
                w.Visible = false;
            }
            else
            {
                x.Visible = false;
                y.Visible = true;
                w.Visible = false;
            }
            if (lblUrgent.Text == "1")
            {
                lblUrgent.Text = "(Urgent Request)";
            }
            else
            {
                lblUrgent.Text = "";
            }


            //API.Service web1 = new API.Service();
            //XmlDocument dom2 = new XmlDocument();
            ////string strID = Request.QueryString["ID"];
            //dom2.LoadXml("<XML>" + web1.get_rating_with_jobid(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString()).InnerXml + "</XML>");


            //XmlNodeList Response3 = dom2.SelectNodes("XML/RESPONSE/QUESTIONS_NO ");
            API.Service web1 = new API.Service();
            // API.Service web1 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            //  int jobID = 0;

            //string strID = Request.QueryString["ID"];
            dom2.LoadXml("<XML>" + web1.get_jobrating(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString()).InnerXml + "</XML>");
            XmlNodeList Response3 = dom2.SelectNodes("XML/RESPONSE/QUESTIONS_NO ");

            string que1 = "";
            string que2 = "";
            string que3 = "";
            string que4 = "";
            string que5 = "";
            string rating1 = "";
            string rating2 = "";
            string rating3 = "";
            string rating4 = "";
            string rating5 = "";

            try
            {
                //que1 = Server.HtmlDecode(Response3[intCount1].SelectSingleNode("QUESTION1").InnerText);
                que1 = Server.HtmlDecode(Response3[intCount1].SelectSingleNode("QUESTION1").InnerText);
                que2 = Response3[intCount1].SelectSingleNode("QUESTION2").InnerText;
                que3 = Response3[intCount1].SelectSingleNode("QUESTION3").InnerText;
                que4 = Response3[intCount1].SelectSingleNode("QUESTION4").InnerText;
                que5 = Response3[intCount1].SelectSingleNode("QUESTION5").InnerText;
                rating1 = Response3[intCount1].SelectSingleNode("RATING1").InnerText;
                rating2 = Response3[intCount1].SelectSingleNode("RATING2").InnerText;
                rating3 = Response3[intCount1].SelectSingleNode("RATING3").InnerText;
                rating4 = Response3[intCount1].SelectSingleNode("RATING4").InnerText;
                rating5 = Response3[intCount1].SelectSingleNode("RATING5").InnerText;
            }
            catch (Exception ex)
            {
                //nothing
                //que1 = "";
            }
            if (que1 == "")
            {
                divstar.Visible = false;
            }
            else
            {
                divstar.Visible = true;
            }


            lblque1.Text = que1;
            labque2.Text = que2;
            lblque3.Text = que3;
            lblque4.Text = que4;
            lblque5.Text = que5;
            txtRating1.Text = rating1;
            txtRating2.Text = rating2;
            txtRating3.Text = rating3;
            txtRating4.Text = rating4;
            txtRating5.Text = rating5;

            string sTable = "<tbody>";
            // API.Service web = new API.Service();
            API.Service web = new API.Service();
            XmlDocument dom1 = new XmlDocument();
            //string strID = Request.QueryString["ID"];
            dom1.LoadXml("<XML>" + web.get_candiate_for_that_particuler_job(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString(), Session["VendorID"].ToString()).InnerXml + "</XML>");
            XmlNodeList Response1 = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NO");
            string emp_id = "";
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

            sTable = "";
            //string _messageVariable = "";

            //   _messageVariable = _messageVariable +

            for (int iResponse2 = 0; iResponse2 < Response1.Count; iResponse2++)
            {

                emp_id = Response1[iResponse2].SelectSingleNode("EMPLOYEE_ID").InnerText;
                //if (emp_id.Length > 2)
                //    emp_id = (emp_id.Substring(emp_id.Length - 6));

                API.Service getWorkers = new API.Service();
                //  API.Service getWorkers = new API.Service();
                XmlDocument dom3 = new XmlDocument();
                dom1.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "1", "").InnerXml + "</XML>");
                XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                emp_end_date = Response[iResponse].SelectSingleNode("ENDDATE").InnerText;
                job_end_date = Response[iResponse].SelectSingleNode("CONTRACT_END_DATE").InnerText;
                sTable = sTable + "<tr>";
                //    sTable = sTable + "<td>" + @" <div class=""checkbox checkbox-single margin-none"">  <input id=""checkAll"" type=""checkbox"" ></input> <label for=""checkbox2"" > Label </label> </div>" + " </TD>";
                //  sTable = sTable + "<td>" + _messageVariable + " </TD>";
                //sTable = sTable + "<td><a href='preview_employee.aspx?empid=" + Response1[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobId=" + Request.QueryString["jobID"] + "'>Edit</a> </td> ";
                sTable = sTable + "<td>" + DateTime.Parse(Response1[iResponse2].SelectSingleNode("SUBMIT_DATE").InnerText).ToString("MMMM dd, yyyy") + " </td>";
                sTable = sTable + "<td>" + Response1[iResponse2].SelectSingleNode("FIRST_NAME").InnerText + " " + Response1[iResponse2].SelectSingleNode("LAST_NAME").InnerText + " </td> ";
                sTable = sTable + "<td>" + Response1[iResponse2].SelectSingleNode("EMAIL").InnerText + " </td> ";
                sTable = sTable + "<td>" + Response1[iResponse2].SelectSingleNode("LOCATION").InnerText + " </td> ";
                sTable = sTable + "<td>" + Response1[iResponse2].SelectSingleNode("STATUS").InnerText + " </td> ";
                sTable = sTable + "<td>" + Response1[iResponse2].SelectSingleNode("PAY_RATE").InnerText + " </td> ";
                //string resume = Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText;
                //string resuepath = Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText.Substring(Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText.IndexOf("Resume\\"), Convert.ToInt32(Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText.Length) - Convert.ToInt32(Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText.IndexOf("Resume\\"))).Replace("\\", "//").ToString();
                //sTable = sTable + "<td><a  href='http://www.flentispro.com/" + resuepath + "'>Resume</a> </td> ";
                dom1.LoadXml("<XML>" + getWorkers.get_resume(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "").InnerXml + "</XML>");
                try
                {
                    XmlNodeList Response22 = dom1.SelectNodes("XML/RESPONSE/RESUME_ID");
                    string resume = Response22[iResponse].SelectSingleNode("RESUME_PATH").InnerText;
                    //  string resume = Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText;
                    string resuepath = Response22[iResponse].SelectSingleNode("RESUME_PATH").InnerText.Substring(Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText.IndexOf("Resume\\"), Convert.ToInt32(Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText.Length) - Convert.ToInt32(Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText.IndexOf("Resume\\"))).Replace("\\", "//").ToString();
                    sTable = sTable + "<td><a href = 'http://www.flentispro.com/" + resuepath.Replace("//", "/") + "'> Resume </a> </td>";

                }
                catch (Exception ex)
                {
                    sTable = sTable + "<td> No Resume </td> ";
                }
                try
                {
                    disable = Response[iResponse2].SelectSingleNode("INTERVIEW_REQUESTED").InnerText;
                    interview_date = Response[iResponse2].SelectSingleNode("INTERVIEW_DATE").InnerText;
                    interview_time = Response[iResponse2].SelectSingleNode("INTERVIEW_TIME").InnerText;
                    rejected = Response[iResponse2].SelectSingleNode("CANDIDATE_REJECTED").InnerText;
                    more_info = Response[iResponse2].SelectSingleNode("MORE_INFO").InnerText;
                    cand_approve = Response[iResponse2].SelectSingleNode("CANDIDATE_APPROVE").InnerText;
                    interview_confirm1 = Response[iResponse2].SelectSingleNode("INTERVIEW_CONFIRM").InnerText;
                    schedule = (interview_date.ToString().Replace("12:00:00 AM", "")) + (interview_time.ToString()).ToString();

                }
                catch (Exception ex)
                {
                    disable = "";
                    interview_date = "";
                    interview_time = "";
                    rejected = "";
                    more_info = "";
                    cand_approve = "";
                    interview_confirm1 = "";
                    schedule = "";
                }
                DateTime cand_start_date = DateTime.Parse(Response[iResponse].SelectSingleNode("STARTDATE").InnerText);
                cand_start_date = DateTime.Parse(Response[iResponse].SelectSingleNode("STARTDATE").InnerText);
                string cand_start_date1 = (cand_start_date.ToString().Replace("12:00:00 AM", ""));
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
                string actionID = Response[iResponse].SelectSingleNode("ACTION_ID").InnerText;
                if (interview_date != "" && interview_time != "")
                {
                    schedule = "for:" + DateTime.Parse((interview_date.ToString().Replace("12:00:00 AM", ""))).ToString("dd MMM, yyyy") + " at " + (interview_time.ToString()).ToString();
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
                string interview_rescheduled = Response[iResponse].SelectSingleNode("INTERVIEW_RESHEDULED").InnerText;

                DateTime today = DateTime.Now;
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
                        sTable = sTable + "<td>Interview Cancelled by Client<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;<a href='Client_Job_Details.aspx?open=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&jobID=" + Request.QueryString["jobID"].ToString() + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";


                    }
                    else
                    {

                        sTable = sTable + "<td>Interview Cancelled by Client<br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;<a href='Client_Job_Details.aspx?open=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&jobID=" + Request.QueryString["jobID"].ToString() + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";



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
                                sTable = sTable + "<td><a href='C_View_Candidate.aspx?wopen=Y&p=VW&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='Reschedule Interview'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<br>Interview confirmed for:<br>" + schedule + "</ td>";
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
                                    sTable = sTable + "<td>Interview confirmed for:<br>" + schedule + "<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;&nbsp;<a href='Client_Job_Details.aspx?wopen=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"].ToString() + "&schedule_int=" + schedule + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></ td>";
                                }
                                else
                                {
                                    sTable = sTable + "<td>Interview confirmed for:<br>" + schedule + "<br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;&nbsp;<a href='Client_Job_Details.aspx?wopen=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"].ToString() + "&schedule_int=" + schedule + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></ td>";

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



                                    sTable = sTable + "<td>Interview Rescheduled for:<br>" + schedule + "<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;&nbsp;<a href='Client_Job_Details.aspx?wopen=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"].ToString() + "&schedule_int=" + schedule + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";
                                }
                                else
                                {
                                    sTable = sTable + "<td>Interview Rescheduled for:<br>" + schedule + "<br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;&nbsp;<a href='Client_Job_Details.aspx?wopen=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"].ToString() + "&schedule_int=" + schedule + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";


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
                                        sTable = sTable + "<td><br>Interview Requested for:<br>" + schedule + "<br><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;&nbsp;<a href='Client_Job_Details.aspx?wopen=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"].ToString() + "&schedule_int=" + schedule + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";
                                    }
                                    else
                                    {
                                        sTable = sTable + "<td>Interview Requested for:<br>" + schedule + "<br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&Resch_int1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&Resch_int_msg=1" + "&schedule=" + schedule + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "&action_id1=" + actionID + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;<a href='Client_Job_Details.aspx?open=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&jobID=" + Request.QueryString["jobID"].ToString() + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";

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
                        sTable = sTable + "<td>Rejected</td>";
                    }
                    else

                            if ((rejected == "0") && (disable == "") && (more_info != "") && (cand_approve == ""))
                    {

                        if (more_info_reply != "")

                        {
                            //lblinformationneeded.Text = "Other Information Required by Client: " + more_info + "<br>";
                            // lblinformationneeded.Text = "Information Required: " + more_info;
                            // lblMoreinfomsg.Text = "Information provided by the vendor: " + more_info_reply + " &nbsp; &nbsp; &nbsp; &nbsp; ";
                            string replied_msg = "Information provided by the vendor:" + more_info_reply + "...for message view click button";
                            sTable = sTable + "<td>Information received<br><a href='C_View_Candidate.aspx?jopen=Y&p=JV&actionID2=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&moreinfomsg=" + 1 + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='" + replied_msg + "'><i class='fa fa-fw fa-info'></i></a>&nbsp; " +
                             "<a href='C_View_Candidate.aspx?jopen=Y&p=JV&actionID2=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&employeeid1=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&moreinfomsg1=" + 1 + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-success btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Request interview schedule'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;" +
                             "<a href='C_View_Candidate.aspx?jopen=Y&p=JV&actionID3=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&employeeid2=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&moreinfomsg2=" + 1 + "&job_id=" + job_id + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a></td>";

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
                        rejection_reason.Text = Response[iResponse].SelectSingleNode("VENDOR_REJECT_CANDIDATE_COMMENT").InnerText;

                        string employeeID = ((Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText).Substring(Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText.Length - 5));

                        API.Service getMSGcount = new API.Service();
                        XmlDocument doc1 = new XmlDocument();
                        doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                        XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");
                        // rejection_reason.Text = (Response[iResponse].SelectSingleNode("VENDOR_REJECT_CANDIDATE_COMMENT").InnerText);
                        if (Response07.Count != 0)
                        {

                            sTable = sTable + "<td ><a href='Client_Job_Details.aspx?jopen=Y&p=JV&reject_reasonbyVendor=1'><font color='red'>Candidate Rejected By Vendor</font></a><br></td>";
                            //  </blink>   < i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href = 'C_View_Candidate.aspx?wopen=Y&p=VW&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href = 'C_View_Candidate.aspx?wopen=Y&p=VW&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a>
                        }
                        else
                        {
                            sTable = sTable + "<td ><a href='Client_Job_Details.aspx?jopen=Y&p=JV&reject_reasonbyVendor=1&jobID=" + Request.QueryString["jobID"] + "'><font color='red'>Candidate Rejected By Vendor</font></a><br></td>";

                            // sTable = sTable + "<td><a href='C_View_Candidate.aspx?wopen=Y&p=VW&reject_reason=1'><font color='red'>Candidate Rejected By Vendor</font></a><br><a href='C_View_Candidate.aspx?wopen=Y&p=VW&action_id=" + Response[iResponse].SelectSingleNode("ACTION_ID").InnerText + "&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&popchat=1" + "&schedule=" + schedule + "&cand_name=" + Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText + "&job_title=" + Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "'  data-toggle='tooltip' data-placement='top' name='abc' title='More Actions'> <button class='btn btn-primary btn-xs'><i class='fa fa-calendar fa-fw'></i></button></i></a>&nbsp;<a href='C_View_Candidate.aspx?wopen=Y&p=VW&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&schedule_int=" + schedule + "&foreyecon=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title=''><i class='fa fa-comment''></i></a></td>";
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
                            sTable = sTable + "<td><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a href='Client_Job_Details.aspx?jopen=Y&p=JV&done=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-calendar fa-fw'></i></a>&nbsp; " +
                                              "<a href='Client_Job_Details.aspx?jopen=Y&p=JV&Reject=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a>&nbsp; " +
                                              "<a href='Client_Job_Details.aspx?jopen=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "&schedule_int=" + schedule + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";

                        }
                        else
                        {
                            sTable = sTable + "<td><a href='Client_Job_Details.aspx?jopen=Y&p=JV&job_done=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-calendar fa-fw'></i></a>&nbsp; " +
                                                  "<a href='Client_Job_Details.aspx?jopen=Y&p=JV&job_Reject=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "&job_end_date=" + job_end_date + "&emp_enddate=" + emp_end_date + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a>&nbsp; " +
                                                  "<a href='Client_Job_Details.aspx?wjpen=Y&p=JV&emp_id=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "&c_jobchat=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";

                        }

                    }

                }

                sTable = sTable + "</tr>";
            }

            sTable = sTable + "</tbody>";
            web.Dispose();
            lblTableData.Text = sTable;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Client_Edit_job.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);
        //Response.Redirect("Edit_jobs.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);
    }



    protected void btnDeletethejob_Click(object sender, EventArgs e)
    {
        string job_id1 = Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5);
        DateTime thisday = DateTime.Now;
        API.Service del_job = new API.Service();
        XmlDocument dom1 = new XmlDocument();

        dom1.LoadXml("<XML>" + del_job.delete_a_job(Session["Email"].ToString(), Session["P@ss"].ToString(), job_id1, thisday).InnerXml + "</XML>");

        Response.Redirect("Client_View_jobs.aspx?jopen=Y&p=JV");

    }


    protected void btnCOMMENTs_Click1(object sender, EventArgs e)
    {
        string coments = txtfrstaction2.Text;
        string emp_id = (Request.QueryString["emp_id"].Substring(Request.QueryString["emp_id"].Length - 6));
        DateTime thisDay = DateTime.Now;
        API.Service eye_msg = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + eye_msg.more_info_msg_eye(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, Session["VendorID"].ToString(), "1", Session["ClientID"].ToString(), coments, thisDay, "", "1") + "</XML>");
        Response.Redirect("Client_Job_Details.aspx?wopen=Y&p=VW&jobID=" + Request.QueryString["jobID"]);
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if ((checkurgent.Checked) == true)
        {
            string chk = "yes";
            //Response.Redirect("client_job_emp_actions.aspx?txtComments=" + txtsubmitintervew.Text + "&approve=" + Request.QueryString["job_done"].ToString() + "&chkapprove=" + chk + "&job_id=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + " &emp_end=" + Request.QueryString["emp_enddate"].ToString());
            Response.Redirect("Client_Job_Details.aspx?txtComments=" + txtsubmitintervew.Text +"&c_confirm1=1"+ "&jobID=" + Request.QueryString["jobID"] + "&approve=" + Request.QueryString["job_done"].ToString() + "&chkapprove=" + chk + "&job_id=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + " &emp_end=" + Request.QueryString["emp_enddate"].ToString());
            Response.End();


        }
        string interview_comment = txtsubmitintervew.Text;
        string date = Textdate.Value;
        string time = ddtime.Text;
        Response.Redirect("Client_Job_Details.aspx?txtComments=" + txtsubmitintervew.Text + "&c_confirm2=1" + "&approve=" + Request.QueryString["job_done"].ToString() + "&intComment=" + interview_comment + "&jobID=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + "&time=" + time + "&date=" + date + " &emp_end=" + Request.QueryString["emp_enddate"].ToString());
        Response.End();
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        string reason = txtComments1.Text;
       // Response.Redirect("client_job_emp_actions.aspx?txtComments=" + txtComments1.Text +  "&Reject=" + Request.QueryString["job_Reject"].ToString() + "&job_id=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + "&emp_end=" + Request.QueryString["emp_enddate"].ToString());
        Response.Redirect("Client_Job_Details.aspx?txtComments=" + txtComments1.Text + "&c_confirm3=1" + "&Reject1=" + Request.QueryString["job_Reject"].ToString() + "&jobID=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + "&emp_end=" + Request.QueryString["emp_enddate"].ToString());

        Response.End();
    }

    protected void btnRescdhle_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id1"]);
        DateTime new_date = DateTime.Parse(TxtNewdate1.Value);
        string new_time = DDnewtime1.Text;
        Response.Redirect("Client_Job_Details.aspx?action_id1="+action_id+"&emp_id=" + Request.QueryString["Resch_int1"] + "&c_confirm7=1" + "&jobID=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end_date"].ToString() + "&time=" + new_time + "&date=" + new_date + " &emp_end=" + Request.QueryString["emp_enddate"].ToString());

        //string action_id = (Request.QueryString["action_id1"]);
        //DateTime new_date = DateTime.Parse(TxtNewdate1.Value);
        //string new_time = DDnewtime1.Text;
        //API.Service getWorkers = new API.Service();
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + getWorkers.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, new_date, new_time, "1", "null", "1", "", "", "", "", "", "", thisDay.ToString()).InnerXml + " </XML>");
        //Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);


    }

    protected void btnApproveCandidate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]+"&actionID="+Request.QueryString["action_id1"]+"&c_confirm4=1&emp_id="+Request.QueryString["Resch_int1"]);
        //string action_id = (Request.QueryString["action_id1"]);
        //API.Service getWorkers = new API.Service();
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + getWorkers.candidate_approve_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        //Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);
    }

    protected void btnRejectCandidate_Click(object sender, EventArgs e)
    {

        Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]+ "&c_confirm5=1&action_id1=" + Request.QueryString["action_id1"]+"&emp_id="+Request.QueryString["Resch_int1"]);
        //string action_id = (Request.QueryString["action_id1"]);
        //API.Service getWorkers = new API.Service();
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + getWorkers.candidate_reject_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        //Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);
    }


    protected void btndeletejob_Click(object sender, EventArgs e)
    {
        string job_id1 = Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5);
        DateTime thisday = DateTime.Now;
        API.Service del_job = new API.Service();
        XmlDocument dom1 = new XmlDocument();

        dom1.LoadXml("<XML>" + del_job.delete_a_job(Session["Email"].ToString(), Session["P@ss"].ToString(), job_id1, thisday).InnerXml + "</XML>");

        Response.Redirect("Client_View_jobs.aspx?jopen=Y&p=JV");
    }
    protected void btncancelINTErview_Click(object sender, EventArgs e)
    {
        Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"] + "&c_confirm6=1&action_id1=" + Request.QueryString["action_id1"] + "&emp_id=" + Request.QueryString["Resch_int1"]);

        //string actionID = Request.QueryString["action_id1"];
        //string cancel_comment = "Interview cancelled by client";
        //DateTime thisDay = DateTime.Now.AddHours(1);
        //API.Service cancel_interview = new API.Service();
        //XmlDocument dom1 = new XmlDocument();
        //dom1.LoadXml("<XML>" + cancel_interview.interview_cancel_by_client(Session["Email"].ToString(), Session["P@ss"].ToString(), actionID, "", "", "", "", "", "1", thisDay.ToString(), cancel_comment) + "</XML>");
        //Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);
    }

    protected void btnApprove_cj_Click(object sender, EventArgs e)
    {
        string chk = "yes";
       Response.Redirect("client_job_emp_actions.aspx?txtComments=" + txtsubmitintervew.Text + "&approve=" + Request.QueryString["approve"].ToString() + "&chkapprove=" + chk + "&job_id=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + " &emp_end=" + Request.QueryString["emp_end"].ToString());

    }

   

    protected void btnIntscheduleCJ_Click(object sender, EventArgs e)
    {
        string interview_comment = Request.QueryString["txtComments"];
        string date = Request.QueryString["date"];
        string time = Request.QueryString["time"];
        Response.Redirect("client_job_emp_actions.aspx?txtComments=" + txtsubmitintervew.Text + "&c_confirm2=1" + "&approve=" + Request.QueryString["approve"].ToString() + "&intComment=" + interview_comment + "&job_id=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + "&time=" + time + "&date=" + date + " &emp_end=" + Request.QueryString["emp_end"].ToString());

    }

    protected void btnreject_c_Click(object sender, EventArgs e)
    {
         Response.Redirect("client_job_emp_actions.aspx?txtComments=" + Request.QueryString["txtComments"] +  "&Reject=" + Request.QueryString["Reject1"].ToString() + "&job_id=" + Request.QueryString["jobID"].ToString() + "&job_end=" + Request.QueryString["job_end"].ToString() + "&emp_end=" + Request.QueryString["emp_end"].ToString());

    }

    protected void btnaprovCandidate_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["actionID"]);
        API.Service getWorkers = new API.Service();
        DateTime thisDay = DateTime.Now.AddHours(1);
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.candidate_approve_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);

    }

    protected void btnRejectCandidate_cj_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id1"]);
        API.Service getWorkers = new API.Service();
        DateTime thisDay = DateTime.Now.AddHours(1);
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.candidate_reject_after_interview(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, "1", thisDay).InnerXml + "</XML>");
        Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);

    }

    protected void btnCancelINt_Click(object sender, EventArgs e)
    {
        string actionID = Request.QueryString["action_id1"];
        string cancel_comment = "Interview cancelled by client";
        DateTime thisDay = DateTime.Now.AddHours(1);
        API.Service cancel_interview = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + cancel_interview.interview_cancel_by_client(Session["Email"].ToString(), Session["P@ss"].ToString(), actionID, "", "", "", "", "", "1", thisDay.ToString(), cancel_comment) + "</XML>");
        Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);
    }

    protected void rescheduleINT_Click(object sender, EventArgs e)
    {
        string action_id = (Request.QueryString["action_id1"]);
        DateTime new_date = DateTime.Parse(Request.QueryString["date"]);
        string new_time = (Request.QueryString["time"]);
        API.Service getWorkers = new API.Service();
        DateTime thisDay = DateTime.Now.AddHours(1);
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.interview_Reschedule(Session["Email"].ToString(), Session["P@ss"].ToString(), action_id, new_date, new_time, "1", "null", "1", "", "", "", "", "", "", thisDay.ToString()).InnerXml + " </XML>");
        Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);

    }
    protected void brnAddNewComment_Click(object sender, EventArgs e)
    {

        string JOBID = (Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
        string comment = Server.HtmlEncode(Txtarea_client_new_commnt.Value);
        DateTime thisday = DateTime.Now.AddHours(3);


        API.Service addCOMMENT = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + addCOMMENT.client_job_details_comments(Session["Email"].ToString(), Session["P@ss"].ToString(), JOBID, comment, thisday) + "</XML>");
        Response.Redirect("Client_Job_Details.aspx?wopen=Y&p=VW&jobID=" + Request.QueryString["jobID"]);

    }
}