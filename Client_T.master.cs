using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Client_T : System.Web.UI.MasterPage
{
    StringFunctions func = new StringFunctions();
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=You+have+logged+out");
            Response.End();
        }
        if (!IsPostBack)
        {
          //  PopulateEmployeeListForTimeSheet();
            PopulateMagicSearch();
        }
       lblname.Text = Session["FirstName"] + " " + Session["LastName"]+" "+(Session["Email"]);
        // XmlDocument xmldoc1 = new XmlDocument();
        // //API.Service MessageList1 = new API.Service();
        // API.Service MessageList1 = new API.Service();
        // // API1.Service MessageList1 = new API1.Service();
        //xmldoc1.LoadXml("<XML>" + MessageList1.Show_notification_for_Vendor(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["UserID"].ToString()).InnerXml + "</XML>");
        // XmlNodeList response1 = xmldoc1.SelectNodes("XML/RESPONSE/NOTIFICATION");

        // string _messageVariable = " ";

        // // string UnRead = "";
        // if (response1.Count >= 1)
        // {
        //     _messageVariable = _messageVariable + @"   <div class=""navbar-collapse collapse"" id=""collapse"">" +

        //                                          @" <ul class=""nav navbar-nav navbar-right"">" +
        //                                          @"   <li class=""dropdown notifications hidden-xs hidden-sm"">" +
        //                                          @"     <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">" +
        //                                          @"       <i class=""fa fa-envelope-o""></i>" +

        //                                          @"       <span class=""badge floating badge-danger"">" + response1[0].SelectSingleNode("ISREAD").InnerText + "</span>" +

        //                                          @"     </a>" +
        //                                          @"     <ul class=""dropdown-menu"">";

        //     for (int iResponse1 = 0; iResponse1 < response1.Count; iResponse1++)
        //     {
        //         string messid = response1[iResponse1].SelectSingleNode("MESSAGE_ID").InnerText;
        //         string subject = response1[iResponse1].SelectSingleNode("MESSAGE_SUBJECT").InnerText;
        //         _messageVariable = _messageVariable + @" <li class=""media"">" +
        //                                                           @" <div class=""media-left"">" +
        //                                                           @" <a href=""#"">" +
        //                                                           @" <img class=""media-object thumb"" src=""images/people/50/guy-2.jpg"" alt=""people"">" +
        //                                                           @" </a>" +
        //                                                           @" </div>" +
        //                                                           @" <div class=""media-body"">" +
        //                                                           @" <div class=""pull-right"">" +
        //                                                           @" <span class=""label label-default""><a href='Vendors_Reply.aspx?id=" + messid + "&subject=" + subject + "'>" + response1[iResponse1].SelectSingleNode("TIME").InnerText + "</a></span>" +
        //                                                           @" </div>" +
        //                                                           //@" <h5 class=""media-heading""><a href='Vendors_Reply.aspx?id=" + messid + "&subject=" + subject + "'>" + response1[iResponse1].SelectSingleNode("PMO_NAME").InnerText + "</a></h5>" +
        //                                                           //@" <p class=""margin-none""><a href='Vendors_Reply.aspx?id=" + messid + "&subject=" + subject + "'>" + response1[iResponse1].SelectSingleNode("MESSAGE_SUBJECT").InnerText + "</a></p>" +
        //                                                           //@" </div>" +
        //                                                           //@" </li>";
        //                                                           @" <h5 class=""media-heading""><a href='Vendors_Reply.aspx?id=" + messid + "&subject=" + subject + "'>" + response1[iResponse1].SelectSingleNode("PMO_NAME").InnerText + "</a></h5>" +

        //                                                           @" <p class=""margin-none""><a href='Vendors_Reply.aspx?id=" + messid + "&subject=" + subject + "'>" + response1[iResponse1].SelectSingleNode("MESSAGE_SUBJECT").InnerText + "</a></p>" +
        //                                                           @" </div>" +
        //                                                           @" </li>";

        //     }


        //     _messageVariable = _messageVariable + @"  </ul>" +
        //                                           @"  </li>" +
        //                                           @"  </ul>" +
        //                                           @"</div> ";


        // }
        // else
        // {
        //     _messageVariable = _messageVariable + @"   <div class=""navbar-collapse collapse"" id=""collapse"">" +

        //                                         @" <ul class=""nav navbar-nav navbar-right"">" +
        //                                         @"   <li class=""dropdown notifications hidden-xs hidden-sm"">" +
        //                                         @"     <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">" +
        //                                         @"       <i class=""fa fa-envelope-o""></i>" +

        //                                         //   @"       <span class=""badge floating badge-danger"">" + response1[0].SelectSingleNode("").InnerText + "</span>" +

        //                                         @"     </a>" +
        //                                         @"     <ul class=""dropdown-menu"">  </ul>" +
        //                                          @"  </li>" +
        //                                          @"  </ul>" +
        //                                          @"</div> ";


        // }

        // LbMessage.Text = _messageVariable;

        string interview_alert="";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

        if (conn.State == System.Data.ConnectionState.Closed)
        {
            DateTime thisDay = DateTime.Now;
            string vendorID = Session["VendorID"].ToString();
            conn.Open();
            //string strSql = "   select cast(interview_date as datetime) + (select cast(interview_time as datetime) ) as interview " +
            //                  "  from ovms_employee_actions " +
            //                  "  where client_id = '" + Session["ClientID"].ToString() + "' and interview_confirm = 1 and(cast(interview_date as datetime) + (select cast(interview_time as datetime)))  BETWEEN DATEADD(HOUR, 3, GETDATE()) and DATEADD(minute, +15, DATEADD(HOUR, 3, GETDATE())) ";

            string strSql = " select cast(interview_date as datetime) + (select cast(interview_time as datetime) ) as interview " +
                           "  from ovms_employee_actions where client_id = '" + Session["ClientID"].ToString() + "' and interview_confirm = 1 and(cast(interview_date as datetime) + (select cast(interview_time as datetime))) " +
                           "    BETWEEN DATEADD(HOUR, 3, DATEADD(minute, 10, GETDATE())) and DATEADD(minute, +15, DATEADD(HOUR, 3, GETDATE())) ";

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                interview_alert = "1";

            }
            if (interview_alert == "1")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "Script", "interviewTIME('','','');", true);
                // Response.End();

            }
        }
    }

    public void PopulateMagicSearch()
    {

        //select employee_ID from ovms_employees where job_id = 5 and user_id = 20
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetDataMagicSearch = "select em.*, em.employee_id,ed.*, dbo.CamelCase(ed.first_name + ' '+ ed.last_name) fullname, ed.email,ed.suite_no, " +
                                                " dbo.CamelCase(j.job_title) job_title,  dbo.CamelCase(ed.city) city, upper(ed.province) province, " +
                                                " concat('J', clt.client_alias, '00', right('0000' + convert(varchar(4), em.job_id), 4)) job_idfull,	 concat('w', clt.client_alias, '00', right('0000' + convert(varchar(4), em.employee_id), 4))empfull " +
                                                " from ovms_employees as em " +
                                                " join ovms_employee_details as ed on em.employee_id = ed.employee_id " +
                                                " join ovms_vendors as ven on em.vendor_id = ven.vendor_id " +
                                                " join ovms_clients as clt on em.client_id = clt.client_id " +
                                                " join ovms_job_accounting as ja on ja.job_id = em.job_id " +
                                                " join ovms_jobs as j on ja.job_id = j.job_id " +
                                                " where 1 = 1 " +
                                                " and em.client_id = " + Session["ClientID"].ToString() + " " +
                                                 " and em.vendor_id = " + Session["VendorID"].ToString() + " ";

                SqlCommand cmdGetDataMagicSearch = new SqlCommand(sqlGetDataMagicSearch, conn);
                SqlDataReader rsGetMagicSearch = cmdGetDataMagicSearch.ExecuteReader();
                string _sCategoryPostal = "";
                string _sCountry = "";
                string _sPhone = "";
                string _sAddress1 = "";
                string _sEmail = "";

                string _sProvince = "";

                string _sName = "";

                if (rsGetMagicSearch.HasRows == true)
                {
                    _sEmail = "<optgroup label='e-mail'>";

                    _sName = "<optgroup label='Full Name'>";




                    while (rsGetMagicSearch.Read())
                    {


                        _sName = _sName + "<option value='View_worker_detail.aspx?wopen=Y&p=VW&empid=" + rsGetMagicSearch["empfull"].ToString() + "'>" + func.FixString(rsGetMagicSearch["FullName"].ToString()) + "  &nbsp; - &nbsp; " + "No: " + func.FixString(rsGetMagicSearch["suite_no"].ToString()) + ", " + func.FixString(rsGetMagicSearch["address1"].ToString()) + ", " + func.FixString(rsGetMagicSearch["city"].ToString()) + ", " + func.FixString(rsGetMagicSearch["province"].ToString()) + "&nbsp; - &nbsp; " + rsGetMagicSearch["email"].ToString().ToLower() + "</option>";



                    }

                    _sEmail = _sEmail + "</optgroup>";

                    _sName = _sName + "</optgroup>";



                }

                //timesheet
                string _sMain = "";
                string _sTimeSheetMain = "";
                string _sJobsMain = "";
                string _sWorkersMain = "";
                string _sInvoicesMain = "";
                string _sReportsMain = "";
                string _sMessagesMain = "";

                _sMain = "<optgroup label=' '><option value=' '></option></optgroup>";
                _sJobsMain = "<optgroup label='Jobs'><option value='Jobs'>Go To Jobs</option></optgroup>";
                _sWorkersMain = "<optgroup label='Workers'><option value='View_Worker.aspx?wopen=Y&p=VW'>Go To Workers</option></optgroup>";

                _sTimeSheetMain = "<optgroup label='TimeSheet'><option value='TimeSheets'>Go To TimeSheets</option></optgroup>";
                rsGetMagicSearch.Close();
                cmdGetDataMagicSearch.Dispose();

                /* *** Job_ID *** */

                string sqlGetDataMagicjobid = "select distinct concat('J', clt.client_alias, '00', right('0000' + convert(varchar(4), em.job_id), 4)) job_idfull, dbo.CamelCase(j.job_title) as Job_Title  "
                                                + "from ovms_employees as em join ovms_employee_details as ed on em.employee_id = ed.employee_id "
                                                + "join ovms_vendors as ven on em.vendor_id = ven.vendor_id " +
                                                "join ovms_clients as clt on em.client_id = clt.client_id "
                                                + "join ovms_job_accounting as ja on ja.job_id = em.job_id "
                                                + " join ovms_jobs as j on ja.job_id = j.job_id "
                                                + " where 1 = 1";

                SqlCommand cmdGetDataMagicjobid = new SqlCommand(sqlGetDataMagicjobid, conn);
                SqlDataReader rsGetMagicjobid = cmdGetDataMagicjobid.ExecuteReader();

                string _JobID = "";

                if (rsGetMagicjobid.HasRows == true)
                {
                    _JobID = "<optgroup label='Job ID'>";
                    while (rsGetMagicjobid.Read())
                    {
                        _JobID = _JobID + "<option value='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + rsGetMagicjobid["job_idfull"].ToString() + "'>" + rsGetMagicjobid["job_idfull"].ToString().ToUpper() + " &nbsp; - &nbsp;" + rsGetMagicjobid["Job_Title"].ToString() + "</option>";
                    }
                    _JobID = _JobID + "</optgroup>";
                }
                //Close()
                rsGetMagicjobid.Close();
                rsGetMagicjobid.Dispose();


                /* *** Job_Title *** */

                string sqlGetDataMagicjobtitle = "select distinct dbo.CamelCase(j.job_title) as Job_Title, concat('J', clt.client_alias, '00', right('0000' + convert(varchar(4), em.job_id), 4)) job_idfull "
                                                + " from ovms_employees as em join ovms_employee_details as ed on em.employee_id = ed.employee_id  "
                                                + " join ovms_vendors as ven on em.vendor_id = ven.vendor_id   " +
                                                " join ovms_clients as clt on em.client_id = clt.client_id  "
                                                + "join ovms_job_accounting as ja on ja.job_id = em.job_id "
                                                + " join ovms_jobs as j on ja.job_id = j.job_id  where 1 = 1 ";

                SqlCommand cmdGetDataMagicjobtitle = new SqlCommand(sqlGetDataMagicjobtitle, conn);
                SqlDataReader rsGetMagicjobtitle = cmdGetDataMagicjobtitle.ExecuteReader();

                string _sJobTitle = "";

                if (rsGetMagicjobtitle.HasRows == true)
                {
                    _sJobTitle = "<optgroup label = 'Job Title'>";

                    while (rsGetMagicjobtitle.Read())
                    {
                        _sJobTitle = _sJobTitle + "<option value='Job_Details.aspx?jopen=Y&p=JV&jobID=" + rsGetMagicjobtitle["job_idfull"].ToString() + "'>" + rsGetMagicjobtitle["Job_Title"].ToString() + "&nbsp; &nbsp; &nbsp;" + " </option>";
                    }
                    _sJobTitle = _sJobTitle + "</optgroup>";
                }
                //Close()
                rsGetMagicjobtitle.Close();
                rsGetMagicjobtitle.Dispose();

                lblMagicSearch.Text = _sMain + _sJobsMain + _sWorkersMain + _sTimeSheetMain + _JobID + _sName + _sAddress1 + _sEmail + _sJobTitle;


            }
            //selEmployee.Items.Insert(0, new ListItem("-- Select Worker --", "0"));
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

    //public void PopulateMagicSearch()
    //{

    //    //select employee_ID from ovms_employees where job_id = 5 and user_id = 20
    //    //select first_name, last_name, email_id from ovms_users where user_id = 9
    //    conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
    //    try
    //    {
    //        if (conn.State == System.Data.ConnectionState.Closed)
    //        {
    //            conn.Open();
    //            string sqlGetDataMagicSearch = "select em.*, em.employee_id,ed.*, dbo.CamelCase(ed.first_name + ' '+ ed.last_name) fullname, ed.email,ed.suite_no, " +
    //                                            " dbo.CamelCase(j.job_title) job_title,  dbo.CamelCase(ed.city) city, upper(ed.province) province, " +
    //                                            " concat('J', clt.client_alias, '00', right('0000' + convert(varchar(4), em.job_id), 4)) job_idfull,	 concat('w', clt.client_alias, '00', right('0000' + convert(varchar(4), em.employee_id), 4))empfull " +
    //                                            " from ovms_employees as em " +
    //                                            " join ovms_employee_details as ed on em.employee_id = ed.employee_id " +
    //                                            " join ovms_vendors as ven on em.vendor_id = ven.vendor_id " +
    //                                            " join ovms_clients as clt on em.client_id = clt.client_id " +
    //                                            " join ovms_job_accounting as ja on ja.job_id = em.job_id " +
    //                                            " join ovms_jobs as j on ja.job_id = j.job_id " +
    //                                            " where 1 = 1 " +
    //                                            " and em.client_id = " + Session["ClientID"].ToString() + " " +
    //                                            " and j.user_id  = " + Session["UserID"].ToString() + " ";


    //            SqlCommand cmdGetDataMagicSearch = new SqlCommand(sqlGetDataMagicSearch, conn);
    //            SqlDataReader rsGetMagicSearch = cmdGetDataMagicSearch.ExecuteReader();
    //            string _sCategoryPostal = "";
    //            string _sCountry = "";
    //            string _sPhone = "";
    //            string _sAddress1 = "";
    //            // string _sCity = "";
    //            string _spayRate = "";
    //            string _sEmail = "";
    //            string _sJobTitle = "";
    //            string _sProvince = "";
    //            string _JobID = "";
    //            string _skypeID = "";
    //            string _sName = "";

    //            if (rsGetMagicSearch.HasRows == true)
    //            {
    //                _sEmail = "<optgroup label='e-mail'>";
    //                _JobID = "<optgroup label='Job ID'>";
    //                _sName = "<optgroup label='Full Name'>";
    //                //   _sCity = "<optgroup label = ''>";
    //                _sAddress1 = "<optgroup label = 'Address,'>";
    //                _sJobTitle = "<optgroup label = 'Job Title'>";
    //                while (rsGetMagicSearch.Read())
    //                {
    //                    _sEmail = _sEmail + "<option value='Client_View_worker_detail.aspx?wopen=Y&p=VW&empid=" + rsGetMagicSearch["empfull"].ToString() + "'>" + rsGetMagicSearch["email"].ToString().ToLower() + "</option>";
    //                    _JobID = _JobID + "<option value='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + rsGetMagicSearch["job_idfull"].ToString() + "'>" + rsGetMagicSearch["job_idfull"].ToString().ToUpper() + "</option>";
    //                    _sName = _sName + "<option value='Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + rsGetMagicSearch["empfull"].ToString() + "'>" + func.FixString(rsGetMagicSearch["FullName"].ToString()) + "</option>";
    //                    _sAddress1 = _sAddress1 + "<option value='Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + rsGetMagicSearch["empfull"].ToString() + "'>" + "No: " + func.FixString(rsGetMagicSearch["suite_no"].ToString()) + ", " + func.FixString(rsGetMagicSearch["address1"].ToString()) + ", " + func.FixString(rsGetMagicSearch["city"].ToString()) + ", " + func.FixString(rsGetMagicSearch["province"].ToString()) + "</option>";
    //                    _sJobTitle = _sJobTitle + "<option value='Client_Job_Details.aspx?jopen=Y&p=JV&jobID=" + rsGetMagicSearch["job_idfull"].ToString() + "'>" + rsGetMagicSearch["job_title"].ToString() + " </option>";

    //                }
    //                _sEmail = _sEmail + "</optgroup>";
    //                _JobID = _JobID + "</optgroup>";
    //                _sName = _sName + "</optgroup>";
    //                //    _sCity = _sCity + "</optgroup>";
    //                _sAddress1 = _sAddress1 + "</optgroup>";
    //                _sJobTitle = _sJobTitle + "</optgroup>";

    //            }
    //            //timesheet
    //            string _sMain = "";
    //            string _sTimeSheetMain = "";
    //            string _sJobsMain = "";
    //            string _sWorkersMain = "";
    //            string _sInvoicesMain = "";
    //            string _sReportsMain = "";
    //            string _sMessagesMain = "";

    //            _sMain = "<optgroup label=' '><option value=' '></option></optgroup>";
    //            _sJobsMain = "<optgroup label='Jobs'><option value='Jobs'>Go To Jobs</option></optgroup>";
    //            _sWorkersMain = "<optgroup label='Workers'><option value='Client_View_Worker.aspx?wopen=Y&p=VW'>Go To Workers</option></optgroup>";

    //            _sTimeSheetMain = "<optgroup label='TimeSheet'><option value='C_Timesheet_View.aspx?topen=Y&p=VT'>Go To TimeSheets</option></optgroup>";
    //            lblMagicSearch.Text = _sMain + _sJobsMain + _sWorkersMain + _sTimeSheetMain + _JobID + _sName + _sAddress1 + _sEmail + _sJobTitle;

    //            //Close()
    //            rsGetMagicSearch.Close();
    //            cmdGetDataMagicSearch.Dispose();
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
    protected void GotoTimeSheetForEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {

        string Employee_Name = selEmployee.SelectedItem.Text;
        //Session["EmployeeIDForJob"] = "";
        //Session["Employee_Name"] = "";
       // Session["V_EmployeeIDForJob"] = ;
        //Session["Employee_Name"] = Employee_Name;
        Response.Redirect("Add_jobs.aspx?jopen=Y&p=JA&type="+ selEmployee.SelectedItem.Value);
        Response.End();
    }

}

