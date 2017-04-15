using System;
using System.Web.UI;
using System.Xml;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class Client_Edit_job : System.Web.UI.Page
{
    int i, j;
    string JobDescription = "";
    SqlConnection conn;
    public int display = 0;
    StringFunctions func = new StringFunctions();
    emailFunctions semail = new emailFunctions();
    private int iResponse;
    string clientname = "";
    private int intCount1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=Your+session+has+expired");
            Response.End();
        }
        int i, j;

        if (!IsPostBack)
        {
            for (i = 1; i <= 50; i++)
            {
                txtnumberofopning.Items.Add(i.ToString());
            }
            for (j = 5; j <= 100; j += 5)
            {
                txttraveltime.Items.Add(j.ToString());
            }
            Loaddata();
        }
        //else
        //{
        //    LoadJobStatus();
        //    Loaddepartment();
        //    Loadjoblocation();

        //    //Loadclient();
        //    Loadpositiontype();
        //    Loadvendor();
        //}
    }
    private void Loaddata()
    {
        int jobID = 0;
        if (Request.QueryString["jobID"] != "")
        {
            jobID = Int32.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
        }
        API.Service getWorkers = new API.Service();
        //  API.Service getWorkers = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.get_Jobs(jobID.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/JOBS");

        ddljobStatus.Text = Response[iResponse].SelectSingleNode("JOB_STATUS_ID").InnerText;
        //  LoadJobStatusnew(Response[iResponse].SelectSingleNode("JOB_STATUS").InnerText);
        txtjobtitle.Value = Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText;

        //  Loadjoblocationnew(Response[iResponse].SelectSingleNode("JOB_LOCATION").InnerText);
        ddllocation.Text = Response[iResponse].SelectSingleNode("JOB_LOCATION_ID").InnerText;
        txtnumberofopning.Value = Response[iResponse].SelectSingleNode("NO_OF_OPENINGS").InnerText;
        //  txtpositonstarrt.Value = Response[iResponse].SelectSingleNode("POSTING_START_DATE").InnerText;
        //txtpositionend.Value = Response[iResponse].SelectSingleNode("POSTING_END_DATE").InnerText;
        txthoursperday.Value = Response[iResponse].SelectSingleNode("HOURS_PER_DAY").InnerText;
        ddldepartment.Text = Response[iResponse].SelectSingleNode("DEPARTMENT_ID").InnerText;
        // Loaddepartmentnew(Response[iResponse].SelectSingleNode("DEPARTMENT_NAME").InnerText);
        txtroles_and_responsibility.Text = Server.HtmlDecode(Response[iResponse].SelectSingleNode("JOB_DESC").InnerText);
        ddlpositiontype.Text = Response[iResponse].SelectSingleNode("POSITION_TYPE_ID").InnerText;
        // LoadpositiontypeSel(Response[iResponse].SelectSingleNode("JOB_POSITION_TYPE").InnerText);
        // Loadvendornew(Response[iResponse].SelectSingleNode("VENDOR_NAME").InnerText);
        ddlmove.SelectedValue = Response[iResponse].SelectSingleNode("ABLE_TO_MOVE").InnerText;
        ddlvendor.Text = Response[iResponse].SelectSingleNode("VENDOR_ID").InnerText;
        txttraveltime.Value = Response[iResponse].SelectSingleNode("TRAVEL_TIME").InnerText;
        txthiremanagername.Value = Response[iResponse].SelectSingleNode("HIRING_MANAGER_NAME").InnerText;
        txtcoordinator.Value = Response[iResponse].SelectSingleNode("COORDINATOR").InnerText;
        // txtcreatedate.Value = Response[iResponse].SelectSingleNode("CREATE_DATE").InnerText;
        txtmaxsub.Value = Response[iResponse].SelectSingleNode("MAX_SUBMISSION_PER_SUPPLIER").InnerText;
        ddlreasonforopen.SelectedValue = Response[iResponse].SelectSingleNode("REASON_FOR_OPEN").InnerText;
        ddlinterviw.SelectedValue = Response[iResponse].SelectSingleNode("INTERVIEW").InnerText;
        txtbasesallary.Value = Response[iResponse].SelectSingleNode("BASE_SALARY").InnerText;
        txtmarkup.Value = Response[iResponse].SelectSingleNode("MARK_UP").InnerText;
        txtstd_pay_rate_from.Value = Response[iResponse].SelectSingleNode("STD_PAY_RATE").InnerText;
        txtvendor_pay.Value = Response[iResponse].SelectSingleNode("VENDER_PAY_RATE").InnerText;
        // lblovertime.Text = Response[iResponse].SelectSingleNode("OVERTIME_PAY_RATE").InnerText;
        txtvendorot_pay.Value = Response[iResponse].SelectSingleNode("VENDER_OT_PAY_RATE").InnerText;
        //lbldouble.Text = Response[iResponse].SelectSingleNode("DOUBLE_PAY_RATE").InnerText;
        txtvendordbl_pay.Value = Response[iResponse].SelectSingleNode("VENDER_DT_PAY_RATE").InnerText;
        txtst_bill_rate_from.Value = Response[iResponse].SelectSingleNode("STD_BILL_RATE").InnerText;
        txtbasesallary.Value = Response[iResponse].SelectSingleNode("BASE_SALARY").InnerText;
        txtmarkup.Value = Response[iResponse].SelectSingleNode("MARK_UP").InnerText;
        txtbenifits.Text = Response[iResponse].SelectSingleNode("BENIFITS").InnerText;
        txtbouns.Value = Response[iResponse].SelectSingleNode("BONUS").InnerText;
        txtcontstart.Value = DateTime.Parse(Response[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy");
        txtendstart.Value = DateTime.Parse(Response[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy");
        txtjobstart.Value = DateTime.Parse(Response[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy");
        if ((txtstd_pay_rate_from.Value == "" || txtstd_pay_rate_from.Value == "0") && (txtst_bill_rate_from.Value == "" || txtst_bill_rate_from.Value == "0") && (txtbasesallary.Value != "" || txtbasesallary.Value != "0"))
        {
            newdiv.Visible = false;
            markupdiv.Visible = false;
            permentdiv.Visible = true;
            divposition.Visible = false;
            divjobstart.Visible = true;
        }

        else if ((txtst_bill_rate_from.Value == null || txtst_bill_rate_from.Value == "0") && (txtstd_pay_rate_from.Value != null || txtstd_pay_rate_from.Value != "0") && (txtbasesallary.Value == "" || txtbasesallary.Value == "0"))
        {

            newdiv.Visible = false;
            markupdiv.Visible = true;
            permentdiv.Visible = false;
            divposition.Visible = true;
            divjobstart.Visible = false;
        }
        else
        {
            newdiv.Visible = true;
            markupdiv.Visible = false;
            permentdiv.Visible = false;
            divposition.Visible = true;
            divjobstart.Visible = false;

        }


        txtcomment.Text = Server.HtmlDecode(Response[iResponse].SelectSingleNode("COMMENTS").InnerText);
        string job = Response[iResponse].SelectSingleNode("JOB_ID").InnerText;

        //API.Service web1 = new API.Service();
        //XmlDocument dom2 = new XmlDocument();
        ////string strID = Request.QueryString["ID"];
        //dom2.LoadXml("<XML>" + web1.get_rating_with_jobid(Session["Email"].ToString(), Session["P@ss"].ToString(), job).InnerXml + "</XML>");
        //XmlNodeList Response88 = dom2.SelectNodes("XML/RESPONSE");

        //    XmlNodeList Response3 = dom2.SelectNodes("XML/RESPONSE/QUESTIONS_NO ");

        //    txtQuestion1.Text = Response3[iResponse].SelectSingleNode("QUESTION1").InnerText;

        //    if (txtQuestion1.Text == "")
        //    {

        //    }
        //    else
        //    {
        //        display = 1;

        //    }
        //    txtQuestion2.Text = Response3[iResponse].SelectSingleNode("QUESTION2").InnerText;
        //    txtquestion3.Text = Response3[iResponse].SelectSingleNode("QUESTION3").InnerText;
        //    txtquestion4.Text = Response3[iResponse].SelectSingleNode("QUESTION4").InnerText;
        //    txtquestion5.Text = Response3[iResponse].SelectSingleNode("QUESTION5").InnerText;
        //    txtRating1.Text = Response3[iResponse].SelectSingleNode("RATING1").InnerText;
        //    txtRating2.Text = Response3[iResponse].SelectSingleNode("RATING2").InnerText;
        //    txtRating3.Text = Response3[iResponse].SelectSingleNode("RATING3").InnerText;
        //    txtRating4.Text = Response3[iResponse].SelectSingleNode("RATING4").InnerText;
        //    txtRating5.Text = Response3[iResponse].SelectSingleNode("RATING5").InnerText;
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
        //if (que1 == "")
        //{
        //    divstar.Visible = false;
        //}
        //else
        //{
        //    divstar.Visible = true;
        //}


        txtQuestion1.Text = que1;
        txtQuestion2.Text = que2;
        txtquestion3.Text = que3;
        txtquestion4.Text = que4;
        txtquestion5.Text = que5;
        txtRating1.Text = rating1;
        txtRating2.Text = rating2;
        txtRating3.Text = rating3;
        txtRating4.Text = rating4;
        txtRating5.Text = rating5;
    }

    public void Getclientname()
    {
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetFullName = " select client_name from   ovms_clients where client_id= " + Session["ClientID"].ToString();
                SqlCommand cmdGetFullName = new SqlCommand(strGetFullName, conn);
                SqlDataReader readerGetFullName = cmdGetFullName.ExecuteReader();
                //string _svendorList = "";
                while (readerGetFullName.Read())
                {
                    Session["clientname"] = func.FixString(readerGetFullName["client_name"].ToString());

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

    protected void btnaddjob_Click(object sender, EventArgs e)
    {

        string UserID = "";
        int sCheckedUrgent = 0;
        if (checkurgent.Checked.ToString() == "true")
        {
            sCheckedUrgent = 1;
        }
        else
        {
            sCheckedUrgent = 0;
        }
        int jobID = 0;
        if (Request.QueryString["jobID"] != "")
        {
            jobID = Int32.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 7));
        }

        // string UserID = "";
        API.Service web = new API.Service();
        // API.Service web = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        UserID = Session["UserID"].ToString();
        dom1.LoadXml("<XML>" + web.get_job_detail_id(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString()).InnerXml + "</XML>");

        XmlNodeList Response1 = dom1.SelectNodes("XML/RESPONSE");
        string detailid = Response1.Item(0).SelectSingleNode("JOB_DETAIL_ID").InnerText;
        if (newdiv.Visible == true && markupdiv.Visible == false && permentdiv.Visible == false && divposition.Visible == true && divjobstart.Visible == false)
        {
            dom1.LoadXml("<XML>" + web.update_job(jobID.ToString(), detailid, ddljobStatus.Text,
       txtjobtitle.Value, ddldepartment.Text, Convert.ToString(Session["ClientID"]),
       ddlpositiontype.Text, txtnumberofopning.Value,
      ddlvendor.Text, ddllocation.Text, txttraveltime.Value, txthoursperday.Value,
       txtroles_and_responsibility.Text, txthiremanagername.Value, txtcoordinator.Value,
       txtcontstart.Value, txtendstart.Value, txtmaxsub.Value, ddlreasonforopen.SelectedValue,
       ddlinterviw.SelectedValue, sCheckedUrgent.ToString(), Session["Email"].ToString(),
       Session["P@ss"].ToString(), "0", ddlmove.SelectedValue, "0", txtst_bill_rate_from.Value
       , "0", "0", txtcomment.Text, "0", "0", "0", UserID, "0", "0", "0", "1").InnerXml + "</XML>");
        }
        else if (newdiv.Visible == false && markupdiv.Visible == true && permentdiv.Visible == false && divposition.Visible == true && divjobstart.Visible == false)
        {
            dom1.LoadXml("<XML>" + web.update_job(jobID.ToString(), detailid, ddljobStatus.Text,
            txtjobtitle.Value, ddldepartment.Text, Convert.ToString(Session["ClientID"]),
            ddlpositiontype.Text, txtnumberofopning.Value,
            ddlvendor.Text, ddllocation.Text, txttraveltime.Value, txthoursperday.Value,
            txtroles_and_responsibility.Text, txthiremanagername.Value, txtcoordinator.Value,
            txtcontstart.Value, txtendstart.Value, txtmaxsub.Value, ddlreasonforopen.SelectedValue,
            ddlinterviw.SelectedValue, sCheckedUrgent.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(), txtstd_pay_rate_from.Value,
             ddlmove.SelectedValue, txtmarkup.Value, "0", "0", "0",
            txtcomment.Text, txtvendor_pay.Value, txtvendorot_pay.Value, txtvendordbl_pay.Value,
            UserID, "0", "0", "0", "1").InnerXml + "</XML>");
        }
        else
        {
            dom1.LoadXml("<XML>" + web.update_job(jobID.ToString(), detailid, ddljobStatus.Text,
            txtjobtitle.Value, ddldepartment.Text, Convert.ToString(Session["ClientID"]),
            ddlpositiontype.Text, txtnumberofopning.Value,
            ddlvendor.Text, ddllocation.Text, txttraveltime.Value, txthoursperday.Value,
            txtroles_and_responsibility.Text, txthiremanagername.Value, txtcoordinator.Value,
            txtjobstart.Value, "", txtmaxsub.Value, ddlreasonforopen.SelectedValue,
            ddlinterviw.SelectedValue, sCheckedUrgent.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(), txtstd_pay_rate_from.Value,
            ddlmove.SelectedValue, txtmarkup.Value, "0", "0", "0",
            txtcomment.Text, txtvendor_pay.Value, txtvendorot_pay.Value, txtvendordbl_pay.Value,
            UserID, txtbouns.Value, txtbenifits.Text.Replace("'", "''"), txtbasesallary.Value, "1").InnerXml + "</XML>");
        }

        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE");

        if (Response.Item(0).SelectSingleNode("UPDATE_VALUE").InnerText == "1")
        {
            if (txtQuestion1.Text != "")
            {
                API.Service web1 = new API.Service();
               // localhost.Service web1 = new localhost.Service();
                XmlDocument dom2 = new XmlDocument();
                dom2.LoadXml("<XML>" + web1.update_jobrating(Session["Email"].ToString(), Session["P@ss"].ToString(), ddlvendor.Text, Session["ClientID"].ToString(), txtQuestion1.Text, txtRating1.Text, txtQuestion2.Text, txtRating2.Text, txtquestion3.Text, txtRating3.Text, txtquestion4.Text, txtRating4.Text, txtquestion5.Text, txtRating5.Text, UserID, jobID.ToString()).InnerXml + "</XML>");

                // dom1.LoadXml("<XML>" + web.Insert_Job_Questions(Session["Email"].ToString(), Session["P@ss"].ToString(), "0",   ddlvendor.DataValueField , Session["ClientID"].ToString(), txtQuestion1.Text, txtRating1.Text, txtQuestion2.Text, txtRating2.Text, txtquestion3.Text, txtRating3.Text, txtquestion4.Text, txtRating4.Text, txtquestion5.Text, txtRating5.Text, UserID, job).InnerXml + "</XML>");
                XmlNodeList Response2 = dom2.SelectNodes("XML/RESPONSE");
                if (Response2.Item(0).SelectSingleNode("STATUS").InnerText == "1")
                {

                    lblTableData.Text = "New Job Added succcessfully";

                    //   lblTableData.Text = " Job updated succcessfully";
                    API.Service jobInfo = new API.Service();
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml("<XML>" + jobInfo.get_Jobs(jobID.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(), ddlvendor.Text, Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
                    XmlNodeList Response7 = xmldoc.SelectNodes("XML/RESPONSE/JOBS ");
                    string jobtitle = Server.HtmlDecode(Response7[iResponse].SelectSingleNode("JOB_TITLE").InnerText);
                    string location = Response7[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
                    string noofopning = Response7[iResponse].SelectSingleNode("NO_OF_OPENINGS").InnerText;
                    string desc = Server.HtmlDecode(Response7[iResponse].SelectSingleNode("JOB_DESC").InnerText);
                    semail.sendEmail("greg@opusing.com", " job upated by client " + Session["clientname"].ToString(), "<br>Client ID :" + Session["ClientID"].ToString() +
                                     "<br>Client Name :" + Session["clientname"].ToString() +
                                     "<br>jobId :" + jobID +
                                     "<br>job Title :" + jobtitle +
                                     "<br>job Description :" + desc +
                                     "<br>location :" + location +
                                     "<br>No of Openings :" + noofopning +
                                     "<br><br>**" +
                                    "<br>This notification was sent by FlentisPRO.If you have any questions regarding this notice," +
                                    "<br>please contact the SAP Fieldglass Helpdesk at:" +
                                    "<br>mailto:helpdesk@oveems.com" +
                                    "<br>By Phone:" +
                                    "<br>US(toll free) 1 800 123 1234" +
                                    "<br>Please do not respond to this email, this is an automatic email message and this mailbox is not being monitored.", "", "");



                    HttpContext.Current.Response.Redirect("Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + Request.QueryString["jobID"] + "&u=y");
                }
            }
            else
            {
                lblTableData.Text = " rating not updated ";
            }
        }
        else
        {
            lblTableData.Text = " Job not updated ";
        }


    }



}