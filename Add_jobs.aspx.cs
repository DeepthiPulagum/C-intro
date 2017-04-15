using System;
using System.Web.UI;
using System.Xml;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class Add_jobs : System.Web.UI.Page
{
    int i, j;
    string JobDescription = "";
    SqlConnection conn;

    StringFunctions func = new StringFunctions();
    emailFunctions semail = new emailFunctions();
    private int iResponse;
    string clientname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // string markup = Session["Employee_Name"].ToString();
        string idmarkup = Request.QueryString["type"];
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=Your+session+has+timed+out");
            Response.End();
        }


        //System.Web.UI.HtmlControls.HtmlGenericControl rateYo1 = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("rateYo1");
        //  all.Visible = false;
        for (i = 1; i <= 50; i++)
        {
            txtnumberofopning.Items.Add(i.ToString());
        }
        for (j = 0; j <= 100; j += 5)
        {
            txttraveltime.Items.Add(j.ToString());
        }
        if (!IsPostBack)
        {
            LoadJobStatus();
            Loaddepartment();
            Loadjoblocation();
            //Loadclient();
            Loadpositiontype();
            Loadvendor();
        }
        if (idmarkup == "2")
        {
            newdiv.Visible = false;
            markupdiv.Visible = true;
            permentdiv.Visible = false;
            divposition.Visible = true;
            divjobstart.Visible = false;

        }
        else if (idmarkup == "3")
        {
            newdiv.Visible = true;
            markupdiv.Visible = false;
            permentdiv.Visible = false;
            divposition.Visible = true;
            divjobstart.Visible = false;
        }
        else
        {
            newdiv.Visible = false;
            markupdiv.Visible = false;
            permentdiv.Visible = true;
            divposition.Visible = false;
            divjobstart.Visible = true;
        }
        //  all.Visible = true;
        // ddlinterviw.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlmove.Items[0].Attributes["disabled"] = "disabled";
        ddlreasonforopen.Items[0].Attributes["disabled"] = "disabled";
        ddlinterviw.Items[0].Attributes["disabled"] = "disabled";
    }
    private void LoadJobStatus()
    {
        DataTable dt = new DataTable();
        API.Service web = new API.Service();
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml("<XML>" + web.get_Job_Status("", Session["Email"].ToString(), Session["P@ss"].ToString()).InnerXml + "</XML>");
        XmlNodeList xResponse = xDoc.SelectNodes("XML/RESPONSE/JOB_STATUS");
        dt.Columns.Add("JOB_STATUS", typeof(string));
        dt.Columns.Add("JOB_STATUS_ID", typeof(string));
        foreach (XmlNode node in xResponse)
        {
            DataRow dr = dt.NewRow();
            dr["JOB_STATUS"] = node["JOB_STATUS"].InnerText;
            dr["JOB_STATUS_ID"] = node["JOB_STATUS_ID"].InnerText;
            dt.Rows.Add(dr);
        }
        ddljobStatus.DataSource = dt;
        ddljobStatus.DataTextField = "JOB_STATUS";
        ddljobStatus.DataValueField = "JOB_STATUS_ID";
        ddljobStatus.DataBind();
    }
    private void Loadjoblocation()
    {
        DataTable dt = new DataTable();
        API.Service web = new API.Service();
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml("<XML>" + web.get_job_location("", Session["ClientID"].ToString(), "", "", "", "", "", "", Session["Email"].ToString(), Session["P@ss"].ToString()).InnerXml + "</XML>");
        XmlNodeList xResponse = xDoc.SelectNodes("XML/RESPONSE/JOB_LOCATIONS");
        dt.Columns.Add("ADDRESS1", typeof(string));
        dt.Columns.Add("JOB_LOCATION_ID", typeof(string));
        foreach (XmlNode node in xResponse)
        {
            DataRow dr = dt.NewRow();
            dr["ADDRESS1"] = node["ADDRESS1"].InnerText;
            dr["JOB_LOCATION_ID"] = node["JOB_LOCATION_ID"].InnerText;
            dt.Rows.Add(dr);
        }
        ddllocation.DataSource = dt;
        ddllocation.DataTextField = "ADDRESS1";
        ddllocation.DataValueField = "JOB_LOCATION_ID";
        ddllocation.DataBind();
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
    private void Loaddepartment()
    {
        DataTable dt = new DataTable();
        //string sTable = "<tbody>";
        API.Service web = new API.Service();
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml("<XML>" + web.get_department(Session["Email"].ToString(), Session["P@ss"].ToString(), "", Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList iResponse = xDoc.SelectNodes("XML/RESPONSE/DEPARTMENT_ID");
        dt.Columns.Add("DEPARTMENT_NAME", typeof(string));
        dt.Columns.Add("DEPARTMENT_ID", typeof(string));
        foreach (XmlNode node in iResponse)
        {
            DataRow dr = dt.NewRow();
            dr["DEPARTMENT_NAME"] = node["DEPARTMENT_NAME"].InnerText;
            dr["DEPARTMENT_ID"] = node["DEPARTMENT_ID"].InnerText;
            dt.Rows.Add(dr);
        }
        ddldepartment.DataSource = dt;
        ddldepartment.DataTextField = "DEPARTMENT_NAME";
        ddldepartment.DataValueField = "DEPARTMENT_ID";
        ddldepartment.DataBind();
    }
    private void Loadpositiontype()
    {
        DataTable dt = new DataTable();
        //string sTable = "<tbody>";
        XmlDocument xDoc = new XmlDocument();
        API.Service web = new API.Service();
        xDoc.LoadXml("<XML>" + web.get_job_position_type_MB(Session["Email"].ToString(), Session["P@ss"].ToString(), "3").InnerXml + "</XML>");
        //  xDoc.LoadXml("<XML>" + web.get_job_position_type(Session["Email"].ToString(), Session["P@ss"].ToString(), "3").InnerXml + "</XML>");
        XmlNodeList iResponse = xDoc.SelectNodes("XML/RESPONSE/JOB_POSITION_TYPE_ID");

        dt.Columns.Add("JOB_POSITION_TYPE", typeof(string));
        dt.Columns.Add("JOB_POSITION_TYPE_ID", typeof(string));
        foreach (XmlNode node in iResponse)
        {
            DataRow dr = dt.NewRow();
            dr["JOB_POSITION_TYPE"] = node["JOB_POSITION_TYPE"].InnerText;
            dr["JOB_POSITION_TYPE_ID"] = node["JOB_POSITION_TYPE_ID"].InnerText;
            dt.Rows.Add(dr);
        }
        ddlpositiontype.DataSource = dt;
        ddlpositiontype.DataTextField = "JOB_POSITION_TYPE";
        ddlpositiontype.DataValueField = "JOB_POSITION_TYPE_ID";
        ddlpositiontype.DataBind();
    }
    private void Loadvendor()
    {
        DataTable dt = new DataTable();
        XmlDocument xDoc = new XmlDocument();
        API.Service web = new API.Service();
        xDoc.LoadXml("<XML>" + web.get_vendor(Session["ClientID"].ToString(), Session["Email"].ToString(), Session["P@ss"].ToString()).InnerXml + "</XML>");
        XmlNodeList iResponse = xDoc.SelectNodes("XML/RESPONSE/VENDOR_ID");
        dt.Columns.Add("VENDOR_NAME", typeof(string));
        dt.Columns.Add("VENDOR_ID", typeof(string));
        foreach (XmlNode node in iResponse)
        {
            DataRow dr = dt.NewRow();
            dr["VENDOR_NAME"] = node["VENDOR_NAME"].InnerText;
            dr["VENDOR_ID"] = node["VENDOR_ID"].InnerText;
            dt.Rows.Add(dr);
        }
        ddlvendor.DataSource = dt;
        ddlvendor.DataTextField = "vendor_name";
        ddlvendor.DataValueField = "VENDOR_ID";
        ddlvendor.DataBind();
        // ddlvendor.Items.Insert(0, new ListItem("ALL VENDORS", "0"));
        //ddlvendor.Items.Insert(0, new ListItem("-- Select --", "0"));
        ddlvendor.Items.Insert(0, new ListItem("ALL VENDORS", "4"));
    }
    protected void btnaddjob_Click(object sender, EventArgs e)
    {
       // localhost.Service web = new localhost.Service();
        API.Service web = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        string UserID = "";


        int sCheckedUrgent = 0;
        if (checkurgent.Checked == true)
        {
            sCheckedUrgent = 1;
        }
        DateTime todayDate = DateTime.Today;
        // txtstd_pay_rate_from.Value = (Convert.ToInt32(txtdbl_pay_rate_from.Value) * (TextBox1.Text));

        UserID = Session["UserID"].ToString();

        if (newdiv.Visible == true && markupdiv.Visible == false && permentdiv.Visible == false && divposition.Visible == true && divjobstart.Visible == false)
        {
            dom1.LoadXml("<XML>" + web.set_jobs(ddljobStatus.Value, txtjobtitle.Value, ddldepartment.Value,
                        Session["ClientID"].ToString(), ddlpositiontype.Value, txtnumberofopning.Value, ddlvendor.Value,
                        ddllocation.Value, txttraveltime.Value, txthoursperday.Value, txtroles_and_responsibility.Text.Replace("'", "''"),
                        txthiremanagername.Value, txtcoordinator.Value, txtcontstart.Value.ToString(), txtendstart.Value.ToString(),
                         txtmaxsub.Value, ddlreasonforopen.SelectedValue, ddlinterviw.SelectedValue,
                         sCheckedUrgent.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(),
                         "0", ddlmove.SelectedValue, "0", txtst_bill_rate_from.Value, "0", "0",
                         "0", "0", "0", UserID, "0", "0", "0", "0").InnerXml + "</XML>");
        }
        else if (newdiv.Visible == false && markupdiv.Visible == true && permentdiv.Visible == false && divposition.Visible == true && divjobstart.Visible == false)
        {
            dom1.LoadXml("<XML>" + web.set_jobs(ddljobStatus.Value, Server.HtmlEncode(txtjobtitle.Value), ddldepartment.Value,
                    Session["ClientID"].ToString(), ddlpositiontype.Value, txtnumberofopning.Value, ddlvendor.Value,

                     ddllocation.Value, txttraveltime.Value,
                    txthoursperday.Value, Server.HtmlEncode(txtroles_and_responsibility.Text.Replace("'", "''")), txthiremanagername.Value, txtcoordinator.Value, txtcontstart.Value.ToString(), txtendstart.Value.ToString(),
                     txtmaxsub.Value, ddlreasonforopen.SelectedValue, ddlinterviw.SelectedValue,
                     sCheckedUrgent.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(),
                     txtstd_pay_rate_from.Value, ddlmove.SelectedValue, txtmarkup.Value,
                     "0", "0", "0", txtvendor_pay.Value, txtvendorot_pay.Value, txtvendordbl_pay.Value, UserID, "0", "0", "0", "0").InnerXml + "</XML>");
        }
        else
        {
            dom1.LoadXml("<XML>" + web.set_jobs(ddljobStatus.Value, txtjobtitle.Value, ddldepartment.Value,
                       Session["ClientID"].ToString(), "3", txtnumberofopning.Value, ddlvendor.Value,
                       ddllocation.Value, txttraveltime.Value, txthoursperday.Value, txtroles_and_responsibility.Text.Replace("'", "''"),
                       txthiremanagername.Value, txtcoordinator.Value, txtjobstart.Value.ToString(), "",
                        txtmaxsub.Value, ddlreasonforopen.SelectedValue, ddlinterviw.SelectedValue,
                        sCheckedUrgent.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(),
                        "0", ddlmove.SelectedValue, "0", "0", "0", "0",
                        "0", "0", "0", UserID, txtbouns.Value, txtbenifits.Text.Replace("'", "''"), txtbasesallary.Value, "0").InnerXml + "</XML>");

        }
        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE");
        string job = Response.Item(0).SelectSingleNode("JOB_ID").InnerText;
        string jobdetailid = Response.Item(0).SelectSingleNode("JOB_DETAIL_ID").InnerText;
        Session["jobdeailID"] = jobdetailid;
        dom1.LoadXml("<XML>" + web.insert_job_comments(Session["Email"].ToString(), Session["P@ss"].ToString(), txtcomment.Text, Convert.ToInt32(job), todayDate, Convert.ToInt32(UserID)).InnerXml + "</XML>");
        XmlNodeList Response1 = dom1.SelectNodes("XML/RESPONSE");
        if (txtQuestion1 != null)
        {
            dom1.LoadXml("<XML>" + web.Insert_Jobquestions_ratings(Session["Email"].ToString(), Session["P@ss"].ToString(), ddlvendor.Value, Session["ClientID"].ToString(), txtQuestion1.Text, txtRating1.Text, txtQuestion2.Text, txtRating2.Text, txtquestion3.Text, txtRating3.Text, txtquestion4.Text, txtRating4.Text, txtquestion5.Text, txtRating5.Text, UserID, job).InnerXml + "</XML>");

            // dom1.LoadXml("<XML>" + web.Insert_Job_Questions(Session["Email"].ToString(), Session["P@ss"].ToString(), "0",   ddlvendor.DataValueField , Session["ClientID"].ToString(), txtQuestion1.Text, txtRating1.Text, txtQuestion2.Text, txtRating2.Text, txtquestion3.Text, txtRating3.Text, txtquestion4.Text, txtRating4.Text, txtquestion5.Text, txtRating5.Text, UserID, job).InnerXml + "</XML>");
            XmlNodeList Response2 = dom1.SelectNodes("XML/RESPONSE");
            if (Response2.Item(0).SelectSingleNode("DATA").InnerText != "")
            {

                lblTableData.Text = "New Job Added succcessfully";
            }
        }
        API.Service jobInfo = new API.Service();
        XmlDocument xmldoc = new XmlDocument();
      
        xmldoc.LoadXml("<XML>" + jobInfo.preview_job(job, Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response7 = xmldoc.SelectNodes("XML/RESPONSE/JOBS ");
        string jobtitle = func.FixString(Server.HtmlDecode(Response7[iResponse].SelectSingleNode("JOB_TITLE").InnerText));
        string location = Response7[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
        string noofopning = Response7[iResponse].SelectSingleNode("NO_OF_OPENINGS").InnerText;
        string desc = Server.HtmlDecode(Response7[iResponse].SelectSingleNode("JOB_DESC").InnerText);
        semail.sendEmail("greg@opusing.com", "New job added by client " + Session["clientname"].ToString(), "<br>Client ID :" + Session["ClientID"].ToString() +
                         "<br>Client Name :" + Session["clientname"].ToString() +
                         "<br>jobId :" + job +
                         "<br>job Title :" + jobtitle +
                         "<br>job Description :" + desc +
                         // "<br>location :" + location +
                         "<br>No of Openings :" + noofopning +
                         "<br><br>******" +
                        "<br>This notification was sent by FlentisPRO.If you have any questions regarding this notice," +
                        "<br>please contact the SAP Fieldglass Helpdesk at:" +
                        "<br>mailto:helpdesk@oveems.com" +
                        "<br>By Phone:" +
                        "<br>US(toll free) 1 800 123 1234" +
                        "<br>Please do not respond to this email, this is an automatic email message and this mailbox is not being monitored.", "", "");

        Session["clientname"] = "";



        dom1.LoadXml("<XML>" + web.get_job_alias(Session["Email"].ToString(), Session["P@ss"].ToString(), job.ToString()).InnerXml + "</XML>");

        XmlNodeList Response3 = dom1.SelectNodes("XML/RESPONSE");
        string jobalias = Response3.Item(0).SelectSingleNode("JOB_ALIAS").InnerText;
        string end = Response3.Item(0).SelectSingleNode("JOB_ID").InnerText;
        HttpContext.Current.Response.Redirect("Preview_job.aspx?jobId=" + jobalias);
        // Response.Redirect(");

        /* ******* SMS Notification ******* */
        SqlConnection conn;
        string readsms;
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
                string smsquery = "select vendors from ovms_jobs where job_id = " + job;
                SqlCommand smscmd = new SqlCommand(smsquery, conn);
                 readsms = smscmd.ExecuteReader().ToString();

                string message = jobtitle + "\n" + desc;
                ConvertPdf.converter files = new ConvertPdf.converter();
                files.client_smsNotification(readsms, message, Session["ClientID"].ToString(), "newjob_notify");

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
       
    }
}