using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Client_Job_Detail_Add_Email : System.Web.UI.Page
{
    public string canPhoto { get; set; }
    public string canResume { get; set; }
    string fileExtension = "";
    string UniqueDateTime = "";
    private int iResponse;
    private int intCount1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=Your+session+has+timed+out");
            Response.End();
        }
        if (!Page.IsPostBack)
        {

            int jobID = 0;
            if (Request.QueryString["jobID"] != "")
            {
                jobID = Int32.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
            }
            API.Service jobDetails = new API.Service();
            XmlDocument _xjobDetails = new XmlDocument();
            _xjobDetails.LoadXml("<XML>" + jobDetails.get_Jobs(Convert.ToString(jobID), Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
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
                _Job_Description = Response2[intCount].SelectSingleNode("JOB_DESC").InnerText;
                _Job_Title = Server.HtmlDecode(Response2[intCount].SelectSingleNode("JOB_TITLE").InnerText);
                _No_Of_Opennings = Response2[intCount].SelectSingleNode("NO_OF_OPENINGS").InnerText;
                _DepartmentName = Response2[intCount].SelectSingleNode("DEPARTMENT_NAME").InnerText;
                _ClientName = Response2[intCount].SelectSingleNode("CLIENT_NAME").InnerText;
                _Job_Position_Type = Response2[intCount].SelectSingleNode("JOB_POSITION_TYPE").InnerText;
                _Contract_Start_Date = DateTime.Parse(Response2[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("MMMM dd, yyyy");
                _Contract_End_Date = DateTime.Parse(Response2[intCount].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("MMMM dd, yyyy");
                _Job_Location = Response2[intCount].SelectSingleNode("JOB_LOCATION").InnerText;
                _Hours_Per_Day = Response2[intCount].SelectSingleNode("HOURS_PER_DAY").InnerText;
                _Hiring_Manager = Response2[intCount].SelectSingleNode("HIRING_MANAGER_NAME").InnerText;
                _Job_Currency = Response2[intCount].SelectSingleNode("JOB_CURRENCY").InnerText;
                //_Contract_Start_Date = Response2[intCount].SelectSingleNode("CONTRACT_START_DATE").InnerText;
                //_Contract_End_Date = Response2[intCount].SelectSingleNode("CONTRACT_END_DATE").InnerText;
                _Job_TimeZone = Response2[intCount].SelectSingleNode("JOB_TIMEZONE").InnerText;
                _Max_submittion = Response2[intCount].SelectSingleNode("MAX_SUBMISSION_PER_SUPPLIER").InnerText;
                _ReasonForOpen = Response2[intCount].SelectSingleNode("REASON_FOR_OPEN").InnerText;
                _Urgent = Response2[intCount].SelectSingleNode("URGENT").InnerText;
                _PayRate = Response2[intCount].SelectSingleNode("STD_PAY_RATE").InnerText;
                _comments = Response2[intCount].SelectSingleNode("COMMENTS").InnerText;

            }
            if (_Urgent == "1")
            {
                lblUrgent.Text = "(Urgent Request)";
            }
            DateTime dt = Convert.ToDateTime(_Contract_Start_Date);
            DateTime dtt = Convert.ToDateTime(_Contract_End_Date);
            lblPostingDate.Text = dt.ToString("dddd, dd MMMM yyyy HH:mm:ss").Replace("00:00:00", "");
            lbljobtitle.Text = _Job_Title;
            lblJobDescription.Text = Server.HtmlDecode(_Job_Description);
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





            //API.Service web3 = new API.Service();
            API.Service web3 = new API.Service();
            XmlDocument dom33 = new XmlDocument();
            dom33.LoadXml("<XML>" + web3.get_Jobs(jobID.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
            XmlNodeList Response8 = dom33.SelectNodes("XML/RESPONSE/JOBS ");

            lblnoofopning.Text = Response8[iResponse].SelectSingleNode("NO_OF_OPENINGS").InnerText;
            lblstartdate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy");

            lblenddate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("dd MMM, yyyy");
            lblUrgent.Text = Response8[iResponse].SelectSingleNode("URGENT").InnerText;
            lbljobtitle.Text = Server.HtmlDecode(Response8[iResponse].SelectSingleNode("JOB_TITLE").InnerText);
            string z = Response8[iResponse].SelectSingleNode("STD_PAY_RATE").InnerText;
            if (z == "0")
            {
                x.Visible = false;
                y.Visible = true;
                lbllocation2.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
                lblbill.Text = Response8[iResponse].SelectSingleNode("STD_BILL_RATE").InnerText;
                lbladdress2.Text = Response8[iResponse].SelectSingleNode("ADDRESS1").InnerText;
            }
            else
            {
                y.Visible = false;
                x.Visible = true;
                lblpay2.Text = Response8[iResponse].SelectSingleNode("STD_PAY_RATE").InnerText;
                lbllocation.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
                lbladdres.Text = Response8[iResponse].SelectSingleNode("ADDRESS1").InnerText;
            }
            if (lblUrgent.Text == "1")
            {
                lblUrgent.Text = "(Urgent Request)";
            }
            else
            {
                lblUrgent.Text = "";
            }


            API.Service web1 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            //string strID = Request.QueryString["ID"];
            dom2.LoadXml("<XML>" + web1.get_rating_with_jobid(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString()).InnerXml + "</XML>");
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
            string emp_id = "";
            string disable = "";
            string rejected = "";
            string more_info = "";
            string cand_approve = "";
            string interview_date = "";
            string interview_confirm1 = "";
            string interview_time = "";
            string schedule = "";


            que1 = Server.HtmlDecode(Response3[intCount1].SelectSingleNode("QUESTION1").InnerText);
            if (que1 == "")
            {
                divstar.Visible = false;
            }
            else
            {
                divstar.Visible = true;
            }
            que2 = Response3[intCount1].SelectSingleNode("QUESTION2").InnerText;
            que3 = Response3[intCount1].SelectSingleNode("QUESTION3").InnerText;
            que4 = Response3[intCount1].SelectSingleNode("QUESTION4").InnerText;
            que5 = Response3[intCount1].SelectSingleNode("QUESTION5").InnerText;
            rating1 = Response3[intCount1].SelectSingleNode("RATING1").InnerText;
            rating2 = Response3[intCount1].SelectSingleNode("RATING2").InnerText;
            rating3 = Response3[intCount1].SelectSingleNode("RATING3").InnerText;
            rating4 = Response3[intCount1].SelectSingleNode("RATING4").InnerText;
            rating5 = Response3[intCount1].SelectSingleNode("RATING5").InnerText;

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

            sTable = "";
            //string _messageVariable = "";

            //   _messageVariable = _messageVariable +

            for (int iResponse2 = 0; iResponse2 < Response1.Count; iResponse2++)
            {
                emp_id = Response1[iResponse2].SelectSingleNode("EMPLOYEE_ID").InnerText;
                if (emp_id.Length > 2)
                    emp_id = (emp_id.Substring(emp_id.Length - 6));

                API.Service getWorkers = new API.Service();
                //  API.Service getWorkers = new API.Service();
                XmlDocument dom3 = new XmlDocument();
                dom1.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id, "", "", "", "", "1", "").InnerXml + "</XML>");
                XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
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
                sTable = sTable + "<td><a href='" + Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText + "'>Resume</a> </td> ";

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
                DateTime cand_start_date = DateTime.Parse(Response[iResponse2].SelectSingleNode("STARTDATE").InnerText);
                cand_start_date = DateTime.Parse(Response[iResponse2].SelectSingleNode("STARTDATE").InnerText);
                string cand_start_date1 = (cand_start_date.ToString().Replace("12:00:00 AM", ""));
                cand_start_date = DateTime.Parse(Response[iResponse2].SelectSingleNode("STARTDATE").InnerText);
                DateTime contract_start_date = DateTime.Parse(Response[iResponse2].SelectSingleNode("CONTRACT_START_DATE").InnerText);

                if ((interview_date != "") && (rejected == "0") && (more_info == "") && (cand_approve == ""))
                {
                    if ((interview_date != "") && (rejected == "0") && (more_info == "") && (cand_approve == ""))
                    {
                        //sTable = sTable + "<td><a href='Client_View_Worker.aspx?wopen=Y&p=VW&approve=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "'class='btn btn-success btn-xs' disabled data-toggle='tooltip' data-placement='top' name='abc' title='Interview Requested'><i class='fa fa-check'></i></a>&nbsp;<a href='Client_View_Worker.aspx?wopen=Y&p=VW&more=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "' class='btn btn-default btn-xs' disabled data-toggle='tooltip' data-placement='top' name='abc' title='More details'><i class='fa fa-pencil'></i></a>&nbsp;<a href='Client_View_Worker.aspx?wopen=Y&p=VW&Reject=" + Response[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "' class='btn btn-danger btn-xs' disabled data-toggle='tooltip' data-placement='top' name='abc' title='Reject'><i class='fa fa-times'></i></a></td>";
                        if (interview_confirm1 == "1")
                        {
                            sTable = sTable + "<td>Interview confirm for:<br>" + schedule + "</td>";

                        }
                        else

                        {
                            sTable = sTable + "<td>Interview Requested for:<br>" + schedule + "</td>";
                        }
                    }
                    else

                    {
                        sTable = sTable + "<td>Interview Requested</td>";
                    }
                }
                else

                   if ((rejected != "") && (disable == "") && (more_info == "") && (rejected != "0") && (cand_approve == ""))
                {
                    sTable = sTable + "<td>Rejected</td>";
                }
                else

                        if ((rejected == "0") && (disable == "") && (more_info != "") && (cand_approve == ""))
                {
                    sTable = sTable + "<td>More Information Needed</td>";
                }
                else

                        if ((rejected == "0") && (disable == "") && (more_info == "") && (cand_approve != ""))
                {
                    if (contract_start_date <= cand_start_date)
                    {
                        sTable = sTable + "<td>Working</td>";
                    }
                    else
                    {
                        sTable = sTable + "<td> Candidate set to start on:<br>" + cand_start_date1 + " </td>";

                    }
                }
                else
                {
                    sTable = sTable + "<td><a href='Client_Job_Details.aspx?wopen=Y&p=VW&done=" + Response1[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-calendar fa-fw'></i></a>&nbsp;<a href='Client_Job_Details.aspx?wopen=Y&p=VW&more=" + Response1[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "' class='btn btn-default btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Request more details'><i class='fa fa-pencil'></i></a>&nbsp;<a href='Client_Job_Details.aspx?wopen=Y&p=VW&Reject=" + Response1[iResponse].SelectSingleNode("EMPLOYEE_ID").InnerText + "&jobID=" + Request.QueryString["jobID"] + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a></td>";


                }
                // sTable = sTable + "<td><select name='selDrop'><option name='option1' value='1'>Request For Interview</option><option name='option1' value='2'>Rejected</option><option name='option1' value='3'>More Details</option></select></td>";
                sTable = sTable + "</tr>";
            }
            sTable = sTable + "</tbody>";
            web.Dispose();
            lblTableData.Text = sTable;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit_jobs.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"]);
    }
}