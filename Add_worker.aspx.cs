using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Add_worker : System.Web.UI.Page
{
    string sVar = "";
    public string canPhoto { get; set; }
    public string canResume { get; set; }
    string fileExtension = "";
    string UniqueDateTime = "";
    int iResponse = 0;
    StringFunctions func = new StringFunctions();
    SqlConnection conn;
    string sCountry = "";
    private int intCount1;

    protected void Page_Load(object sender, EventArgs e)
    {



        //if (Request["NM"] != null)
        //{
        //    if (Request["NM"] == "Y")
        //    {
        //        Response.Redirect("Add_Worker.aspx?wopen=Y&p=AW&jobID=" + Request.QueryString["jobID"].ToString() + "&SN=T");
        //    }
        //}
        

        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=You+have+logged+out");
            Response.End();
        }
        btnpreview.Enabled = true;
        //check if employee is a dup
        if ((Request.Form["ctl00$MainContent$txtemail"] != null) && (Request.Form["ctl00$MainContent$txtemail"] != ""))
        {
            if (CheckCandidateDup(Request.Form["ctl00$MainContent$txtemail"]) == "YES")
            {
                lblDuplicate.Text = "This candidate already exists, please submit someone else";
                btnpreview.Enabled = false;
            }
            else
            {
                lblDuplicate.Text = "";

            }
        }
        
        if (Request.QueryString["jobID"] == null)
        {
            string a = "";
        }
        else
        {
            API.Service web1 = new API.Service();
          //  API.Service web1 = new API.Service();
            XmlDocument dom2 = new XmlDocument();
            int jobID = 0;
            if (Request.QueryString["jobID"] != "")
            {
                jobID = Int32.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
            }
            //  string strID = Request.QueryString["jobID"];

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

            // API.Service web3 = new API.Service();
            API.Service web3 = new API.Service();
            XmlDocument dom3 = new XmlDocument();
            dom3.LoadXml("<XML>" + web3.get_Jobs(jobID.ToString(), Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
            XmlNodeList Response8 = dom3.SelectNodes("XML/RESPONSE/JOBS ");

            lblnoofopning.Text = Response8[iResponse].SelectSingleNode("NO_OF_OPENINGS").InnerText;
            lblstartdate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy");

            lblenddate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("dd MMM, yyyy");
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
            lblpositiontype.Text = Response8[iResponse].SelectSingleNode("JOB_POSITION_TYPE").InnerText; ;

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
            //string z = Response8[iResponse].SelectSingleNode("STD_PAY_RATE").InnerText;
            //if (z == "0")
            //{
            //    x.Visible = false;
            //    y.Visible = true;
            //    lbllocation2.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
            //    lblbill.Text = Response8[iResponse].SelectSingleNode("STD_BILL_RATE").InnerText;
            //    lbladdress2.Text = Response8[iResponse].SelectSingleNode("ADDRESS1").InnerText;
            //}
            //else
            //{
            //    y.Visible = false;
            //    x.Visible = true;
            //    lblpay.Text = Response8[iResponse].SelectSingleNode("VENDER_PAY_RATE").InnerText;
            //    lbllocation.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
            //    lbladdres.Text = Response8[iResponse].SelectSingleNode("ADDRESS1").InnerText;
            //}
            if (lblUrgent.Text == "1")
            {
                lblUrgent.Text = "<blink>(Urgent Request)</blink>";
            }
            else
            {
                lblUrgent.Text = "";
            }
        }
        if (Page.IsPostBack)
        {
            if (Request.QueryString["jobID"] == null)
            {
                string v = Request.Form["ctl00$MainContent$ddljobs"];
                Response.Redirect("Add_worker.aspx?wopen=Y&p=AW&jobID=" + v.ToString());
            }

            //         @" <div class=""modal slide-down fade"" id=""modal - select1"">" +
            //     @"  < div class=""modal - dialog"">" +
            //     @"  <div class=""v - cell"" >"+
            //     @"  <div class=""modal - content"" >"+
            //     @"  <div class=""modal - header"" >+
            //     @"  <button type ='button' class='close' data-dismiss='modal'> "+
            //@"  <span aria-hidden=""true"">&times</span><span class=""sr - only"">Close</span></button> "+


            //     @" </div>" +

            //     @"  <div class=""modal - body"">" +
            //     @"    <div class=""panel - body"">" +



            //     @"    <asp:Label ID = ""lblmessege"" class=""media - heading margin - v - 5"" runat=""server""> stars are not matching</asp:Label>" +



            //     @"  </div>" +

            //     @" </div>" +
            //     @"  <div class=""modal - footer"">" +

            //     @" <button type = ""button"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>" +
            //     @" <asp:Button ID = ""btnsbmit"" class=""btn btn-primary"" OnClick=""btnsbmit_Click"" runat=""server"" Text=""Continue"" /> " +
            //     @"</div>" +

            //     @" </div> " +
            //     @" </div> " +
            //     @" </div> " +
            //     @" </div> ";
            // }

        }
        if (!Page.IsPostBack)
        {
            ///Loadcountry();
            Loadstate();
            string v = Request.QueryString["jobID"];
            if (v == null)
            {
                job.Visible = true;
                Loadjobs();
            }
            else
            {
                job.Visible = false;

            }
        }
    }
    private void Loadstate()
    {
        DataTable dt = new DataTable();
        API.Service web = new API.Service();
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml("<XML>" + web.get_state(Session["Email"].ToString(), Session["P@ss"].ToString(), "").InnerXml + "</XML>");
        XmlNodeList xResponse = xDoc.SelectNodes("XML/RESPONSE/STATE_NO ");
        dt.Columns.Add("STATE_CODE", typeof(string));
        dt.Columns.Add("STATE_ID", typeof(string));

        string sVar = "";
        string sUS = "";
        foreach (XmlNode node in xResponse)
        {
            DataRow dr = dt.NewRow();


            if (node["COUNTRY_ID"].InnerText == "2")
                sVar = "United States";

            if (node["COUNTRY_ID"].InnerText == "1")
                sVar = "Canada";


            dr["STATE_CODE"] = node["STATE_NAME"].InnerText + " / " + sVar;
            dr["STATE_ID"] = node["STATE_ID"].InnerText;
            dt.Rows.Add(dr);
        }
        ddlprivince.DataSource = dt;
        ddlprivince.DataTextField = "STATE_CODE";
        ddlprivince.DataValueField = "STATE_CODE";
        ddlprivince.DataBind();
        ddlprivince.Items.Insert(0, new ListItem("--Select one--", "0"));
    }
    //private void Loadcountry()
    //{
    //    DataTable dt = new DataTable();
    //    API.Service web = new API.Service();
    //    XmlDocument xDoc = new XmlDocument();
    //    xDoc.LoadXml("<XML>" + web.get_country(Session["Email"].ToString(), Session["P@ss"].ToString(), "").InnerXml + "</XML>");
    //    XmlNodeList xResponse = xDoc.SelectNodes("XML/RESPONSE/COUNTRY_NO ");
    //    dt.Columns.Add("COUNTRY_NAME", typeof(string));
    //    dt.Columns.Add("COUNTRY_ID", typeof(string));
    //    foreach (XmlNode node in xResponse)
    //    {
    //        DataRow dr = dt.NewRow();
    //        dr["COUNTRY_NAME"] = node["COUNTRY_NAME"].InnerText;
    //        dr["COUNTRY_ID"] = node["COUNTRY_ID"].InnerText;
    //        dt.Rows.Add(dr);
    //    }
    //    ddlcountry.DataSource = dt;
    //    ddlcountry.DataTextField = "COUNTRY_NAME";
    //    ddlcountry.DataValueField = "COUNTRY_NAME";
    //    ddlcountry.DataBind();
    //}
    private void Loadjobs()
    {
        DataTable dt = new DataTable();
        API.Service web = new API.Service();
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml("<XML>" + web.get_all_available_job_for_particuler_vendor(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString()).InnerXml + "</XML>");
        XmlNodeList xResponse = xDoc.SelectNodes("XML/RESPONSE/JOB_NO");
        dt.Columns.Add("JOB_TITLE-JOB_ID", typeof(string));
        dt.Columns.Add("JOB_ID", typeof(string));
        foreach (XmlNode node in xResponse)
        {
            DataRow dr = dt.NewRow();
            dr["JOB_TITLE-JOB_ID"] = node["JOB_TITLE-JOB_ID"].InnerText;
            dr["JOB_ID"] = node["JOB_ID"].InnerText;
            dt.Rows.Add(dr);
        }
        ddljobs.DataSource = dt;
        ddljobs.DataTextField = "JOB_TITLE-JOB_ID";
        ddljobs.DataValueField = "JOB_ID";
        ddljobs.DataBind();
    }


    //protected void btnsbmit_Click(object sender, EventArgs e)
    //{

    //    conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
    //    try
    //    {
    //        if (conn.State == System.Data.ConnectionState.Closed)
    //        {
    //            conn.Open();
    //            string sqlGetCountry = " select distinct country_id from ovms_state where state_code = '" + ddlprivince.SelectedValue.ToString() + "'  ";

    //            SqlCommand cmdGetCountry = new SqlCommand(sqlGetCountry, conn);
    //            SqlDataReader rsGetCountry = cmdGetCountry.ExecuteReader();

    //            while (rsGetCountry.Read())
    //            {
    //                if (rsGetCountry["country_id"].ToString() == "1")
    //                {
    //                    sCountry = "Canada";
    //                }
    //                if (rsGetCountry["country_id"].ToString() == "2")
    //                {
    //                    sCountry = "United States";
    //                }
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


    //    //if (Convert.ToDouble(txtRating1.Text) >= Convert.ToDouble(txtemprating1.Text))
    //    //{
    //    //    lblmessege.Text = "question 1 rating doesnt match";
    //    //}
    //    //if (Convert.ToDouble(txtRating2.Text) >= Convert.ToDouble(txtemprating2.Text))
    //    //{
    //    //    lblmessege.Text = "question 2 rating doesnt match";
    //    //}
    //    //if (Convert.ToDouble(txtRating3.Text) >= Convert.ToDouble(txtemprating3.Text))
    //    //{
    //    //    lblmessege.Text = "question 3 rating doesnt match";
    //    //}
    //    //if (Convert.ToDouble(txtRating4.Text) >= Convert.ToDouble(txtemprating4.Text))
    //    //{
    //    //    lblmessege.Text = "question 4 rating doesnt match";
    //    //}
    //    //if (Convert.ToDouble(txtRating5.Text) >= Convert.ToDouble(txtemprating5.Text))
    //    //{
    //    //    lblmessege.Text = "question 5 rating doesnt match";
    //    //}

    //    int jobID = 0;
    //    if (Request.QueryString["jobID"] != "")
    //    {
    //        jobID = Int32.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
    //    }
    //    string UserID = "";
    //    if (FileUpload1.HasFile)
    //    {
    //        if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg")
    //        {
    //            fileExtension = Path.GetExtension(FileUpload1.FileName);
    //            if (FileUpload1.PostedFile.ContentLength < 100000000)
    //            {
    //                string p = Path.GetFileName(FileUpload1.FileName);
    //                //check if vendor exist in folder
    //                if (Directory.Exists(Server.MapPath("~/images/profile_picture/" + UserID + "/ ")) == false)
    //                {
    //                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/images/profile_picture/" + UserID + "/ "));
    //                }

    //                UniqueDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
    //                if (fileExtension.ToLower() == ".jpg")
    //                {
    //                    FileUpload1.SaveAs(Server.MapPath("~/images/profile_picture/" + UserID + "/") + (FileUpload1.FileName.Replace(".jpg", "_" + UniqueDateTime + ".jpg")));
    //                    canPhoto = Server.MapPath("~/images/profile_picture/" + UserID + "/") + (FileUpload1.FileName.Replace(".jpg", "_" + UniqueDateTime + ".jpg"));
    //                }

    //                //FileUpload1.SaveAs(Server.MapPath("~/images/profile_picture" + FileUpload1.FileName));
    //                lblimagestatus.Text = "File Uploaded...";
    //                //canPhoto = "~/images/profile_picture" + FileUpload1.FileName;
    //            }
    //            else
    //            {
    //                lblimagestatus.Text = "Only JPEG files with max size 1000 KB are accepted..";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        lblimagestatus.Text = "Please select a file to upload...";
    //    }
    //    if (fileupresume.HasFile)
    //    {
    //        fileExtension = Path.GetExtension(fileupresume.FileName);
    //        if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf" && fileExtension.ToLower() != ".rtf")
    //        {
    //            lblresumestatus.Text = "Only Files with .doc or .docx extension are allowed...";
    //            lblresumestatus.ForeColor = System.Drawing.Color.White;
    //        }
    //        else
    //        {
    //            int filesize = fileupresume.PostedFile.ContentLength;
    //            if (filesize > 52428800)
    //            {
    //                lblresumestatus.Text = "Maximum file size(50 MB) exceeded";
    //                lblresumestatus.ForeColor = System.Drawing.Color.White;
    //            }
    //            else
    //            {
    //                //check if vendor exist in folder
    //                if (Directory.Exists(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/")) == false)
    //                {
    //                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/"));
    //                }
    //                //check if jobid exists for that vendor for that resume
    //                if (Directory.Exists(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"])) == false)
    //                {
    //                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"]));
    //                }
    //                UniqueDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
    //                if (fileExtension.ToLower() == ".doc")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".doc", "_" + UniqueDateTime + ".doc")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".doc", "_" + UniqueDateTime + ".doc"));
    //                }
    //                if (fileExtension.ToLower() == ".docx")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".docx", "_" + UniqueDateTime + ".docx")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".docx", "_" + UniqueDateTime + ".docx"));
    //                }
    //                if (fileExtension.ToLower() == ".rtf")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".rtf", "_" + UniqueDateTime + ".rtf")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".rtf", "_" + UniqueDateTime + ".rtf"));
    //                }
    //                if (fileExtension.ToLower() == ".pdf")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".pdf", "_" + UniqueDateTime + ".pdf")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".pdf", "_" + UniqueDateTime + ".pdf"));
    //                }
    //                //fileupresume.SaveAs(Server.MapPath("~/Resume/4/JALS000019/") + fileupresume.FileName);
    //                lblresumestatus.Text = "File uploaded...";
    //                lblresumestatus.ForeColor = System.Drawing.Color.White;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        lblresumestatus.Text = "Please select a file to upload...";
    //        lblresumestatus.ForeColor = System.Drawing.Color.White;
    //    }

    //    API.Service web = new API.Service();
    //    XmlDocument dom1 = new XmlDocument();
    //    UserID = Session["UserID"].ToString();
    //    dom1.LoadXml("<XML>" + web.get_dates(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString()).InnerXml + "</XML>");
    //    //query ovms_state and get country ID
    //    //     string strGetCountry = " select distinct country_id from ovms_state where state_code = '"+ ddlprivince.SelectedValue.ToString() + "'"
    //    //select employee_ID from ovms_employees where job_id = 5 and user_id = 20
    //    //select first_name, last_name, email_id from ovms_users where user_id = 9



    //    XmlNodeList Response3 = dom1.SelectNodes("XML/RESPONSE");
    //    string strat = Response3.Item(0).SelectSingleNode("CONTRACT_START_DATE").InnerText;
    //    string end = Response3.Item(0).SelectSingleNode("CONTRACT_END_DATE").InnerText;
    //    dom1.LoadXml("<XML>" + web.set_employee(Session["Email"].ToString(), Session["P@ss"].ToString(),
    //      txtfistname.Value, txtmiddle.Value, txtlastname.Value, txtemail.Value, txtphone.Value,
    //      txtdateofbirth.Value, txtsuite.Value, txtaddress1.Value, "", txtcity.Value, ddlprivince.SelectedValue,
    //      txtpostal.Value, sCountry, txtcomment.Text, canPhoto, txtavailable.Value, txtskype.Value,
    //      strat, end, jobID, Convert.ToInt32(Session["VendorID"]),
    //      Convert.ToInt32(Session["ClientID"]), txtlicence.Value, txtsinnumber.Value, txtstdpayf.Value).InnerXml + "</XML>");


    //    XmlNodeList Response1 = dom1.SelectNodes("XML/RESPONSE");
    //    string employeeID = Response1.Item(0).SelectSingleNode("EMPLOYEE_ID").InnerText;
    //    dom1.LoadXml("<XML>" + web.insert_resume(Session["Email"].ToString(), Session["P@ss"].ToString(), canResume, jobID.ToString(), employeeID, UserID, Session["VendorId"].ToString()).InnerXml + "</XML>");

    //    XmlNodeList Response2 = dom1.SelectNodes("XML/RESPONSE");
    //    if (txtemprating1 != null)
    //    {
    //        dom1.LoadXml("<XML>" + web.insert_rating_with_employeeid(Session["Email"].ToString(), Session["P@ss"].ToString(), txtemprating1.Text,
    //         txtemprating2.Text, txtemprating3.Text, txtemprating4.Text, txtemprating5.Text, jobID.ToString(), employeeID).InnerXml + "</XML>");
    //    }

    //    XmlNodeList Response6 = dom1.SelectNodes("XML/RESPONSE");
    //    if (Response6.Item(0).SelectSingleNode("STRING").InnerText != "")
    //    {

    //        lblTableData.Text = "New worker Added succcessfully";

    //    }
    //    Response.Redirect("Preview_Workers.aspx?empid=" + employeeID + "&jobID=" + Request.QueryString["jobID"]);
    //}


    //protected void BtnAddWorker_Click1(object sender, EventArgs e)
    //{

    //    int jobID = 0;
    //    if (Request.QueryString["jobID"] != "")
    //    {
    //        jobID = int.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
    //    }

    //    string UserID = "";
    //    if (FileUpload1.HasFile)
    //    {
    //        if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg")
    //        {
    //            fileExtension = Path.GetExtension(FileUpload1.FileName);
    //            if (FileUpload1.PostedFile.ContentLength < 100000000)
    //            {
    //                string p = Path.GetFileName(FileUpload1.FileName);
    //                //check if vendor exist in folder
    //                if (Directory.Exists(Server.MapPath("~/images/profile_picture/" + UserID + "/ ")) == false)
    //                {
    //                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/images/profile_picture/" + UserID + "/ "));
    //                }

    //                UniqueDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
    //                if (fileExtension.ToLower() == ".jpg")
    //                {
    //                    FileUpload1.SaveAs(Server.MapPath("~/images/profile_picture/" + UserID + "/") + (FileUpload1.FileName.Replace(".jpg", "_" + UniqueDateTime + ".jpg")));
    //                    canPhoto = Server.MapPath("~/images/profile_picture/" + UserID + "/") + (FileUpload1.FileName.Replace(".jpg", "_" + UniqueDateTime + ".jpg"));
    //                }

    //                //FileUpload1.SaveAs(Server.MapPath("~/images/profile_picture" + FileUpload1.FileName));
    //                lblimagestatus.Text = "File Uploaded...";
    //                //canPhoto = "~/images/profile_picture" + FileUpload1.FileName;
    //            }
    //            else
    //            {
    //                lblimagestatus.Text = "Only JPEG files with max size 1000 KB are accepted..";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        lblimagestatus.Text = "Please select a file to upload...";
    //    }
    //    if (fileupresume.HasFile)
    //    {
    //        fileExtension = Path.GetExtension(fileupresume.FileName);
    //        if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf" && fileExtension.ToLower() != ".rtf")
    //        {
    //            lblresumestatus.Text = "Only Files with .doc or .docx extension are allowed...";
    //            lblresumestatus.ForeColor = System.Drawing.Color.White;
    //        }
    //        else
    //        {
    //            int filesize = fileupresume.PostedFile.ContentLength;
    //            if (filesize > 52428800)
    //            {
    //                lblresumestatus.Text = "Maximum file size(50 MB) exceeded";
    //                lblresumestatus.ForeColor = System.Drawing.Color.White;
    //            }
    //            else
    //            {
    //                //check if vendor exist in folder
    //                if (Directory.Exists(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/")) == false)
    //                {
    //                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/"));
    //                }
    //                //check if jobid exists for that vendor for that resume
    //                if (Directory.Exists(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"])) == false)
    //                {
    //                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"]));
    //                }
    //                UniqueDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
    //                if (fileExtension.ToLower() == ".doc")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".doc", "_" + UniqueDateTime + ".doc")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".doc", "_" + UniqueDateTime + ".doc"));
    //                }
    //                if (fileExtension.ToLower() == ".docx")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".docx", "_" + UniqueDateTime + ".docx")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".docx", "_" + UniqueDateTime + ".docx"));
    //                }
    //                if (fileExtension.ToLower() == ".rtf")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".rtf", "_" + UniqueDateTime + ".rtf")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".rtf", "_" + UniqueDateTime + ".rtf"));
    //                }
    //                if (fileExtension.ToLower() == ".pdf")
    //                {
    //                    fileupresume.SaveAs(Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".pdf", "_" + UniqueDateTime + ".pdf")));
    //                    canResume = Server.MapPath("~/Resume/" + Request.QueryString["VendorID"] + "/" + Request.QueryString["id"] + "/") + (fileupresume.FileName.Replace(".pdf", "_" + UniqueDateTime + ".pdf"));
    //                }
    //                //fileupresume.SaveAs(Server.MapPath("~/Resume/4/JALS000019/") + fileupresume.FileName);
    //                lblresumestatus.Text = "File uploaded...";
    //                lblresumestatus.ForeColor = System.Drawing.Color.White;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        lblresumestatus.Text = "Please select a file to upload...";
    //        lblresumestatus.ForeColor = System.Drawing.Color.White;
    //    }

    //    API.Service web = new API.Service();
    //    XmlDocument dom1 = new XmlDocument();
    //    UserID = Session["UserID"].ToString();
    //    dom1.LoadXml("<XML>" + web.get_dates(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString()).InnerXml + "</XML>");

    //    XmlNodeList Response3 = dom1.SelectNodes("XML/RESPONSE");
    //    string strat = Response3.Item(0).SelectSingleNode("CONTRACT_START_DATE").InnerText;
    //    string end = Response3.Item(0).SelectSingleNode("CONTRACT_END_DATE").InnerText;

    //    dom1.LoadXml("<XML>" + web.set_employee(Session["Email"].ToString(), Session["P@ss"].ToString(),
    //      txtfistname.Value, txtmiddle.Value, txtlastname.Value, txtemail.Value, txtphone.Value,
    //      txtdateofbirth.Value, txtsuite.Value, txtaddress1.Value, "", txtcity.Value, ddlprivince.Value,
    //      txtpostal.Value, ddlcountry.SelectedItem.Text, txtcomment.Text, canPhoto, txtavailable.Value, txtskype.Value,
    //      strat, end, jobID, Convert.ToInt32(Session["VendorID"]),
    //      Convert.ToInt32(Session["ClientID"]), txtlicence.Value, txtsinnumber.Value, txtstdpayf.Value).InnerXml + "</XML>");

    //    XmlNodeList Response1 = dom1.SelectNodes("XML/RESPONSE");
    //    string employeeID = Response1.Item(0).SelectSingleNode("EMPLOYEE_ID").InnerText;

    //    dom1.LoadXml("<XML>" + web.insert_resume(Session["Email"].ToString(), Session["P@ss"].ToString(), canResume, jobID.ToString(), employeeID, UserID, Session["VendorId"].ToString()).InnerXml + "</XML>");
    //    //if (txtsecutity.Value == txtconformsecutity.Value)
    //    //{
    //    XmlNodeList Response2 = dom1.SelectNodes("XML/RESPONSE");
    //    if (Response2.Item(0).SelectSingleNode("STATUS").InnerText != "")
    //    {
    //        lblTableData.Text = "New worker Added succcessfully";
    //        txtfistname.Value = "";
    //        txtmiddle.Value = "";
    //        txtlastname.Value = "";
    //        txtemail.Value = "";
    //        txtphone.Value = "";
    //        txtdateofbirth.Value = "";
    //        txtsuite.Value = "";
    //        txtaddress1.Value = "";
    //        txtcity.Value = "";
    //        txtpostal.Value = "";
    //        txtcomment.Text = "";
    //        txtavailable.Value = "";
    //        txtskype.Value = "";



    //    }
    //}
    protected void btnpreview_Click1(object sender, EventArgs e)
    {
        //string stars = "";
        //stars = "no";
        //if (txtRating1.Text != null && txtemprating1.Text != "")
        //{
        //    if (Convert.ToDouble(txtRating1.Text) >= Convert.ToDouble(txtemprating1.Text) || (Convert.ToDouble(txtRating2.Text) >= Convert.ToDouble(txtemprating2.Text)) || (Convert.ToDouble(txtRating3.Text) >= Convert.ToDouble(txtemprating3.Text)) || (Convert.ToDouble(txtRating4.Text) >= Convert.ToDouble(txtemprating4.Text)) || (Convert.ToDouble(txtRating5.Text) >= Convert.ToDouble(txtemprating5.Text)))
        //    {
        //        stars = "yes";
        //    }
        //    else
        //    {
        //        stars = "no";
        //    }
        //}
        //if (stars == "yes")
        //{

        //    Response.Redirect("Add_Worker.aspx?wopen=Y&p=AW&jobID=" + Request.QueryString["jobID"].ToString() + "&star=Yes");
        //    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "Script", "document.getElementbyId('ShowPopup').click();", true);
        //}
        //else
        //{
            setEmployee();
        
    }
    public void setEmployee()
    {
        int jobID = 0;
        if (Request.QueryString["jobID"] != "")
        {
            jobID = Int32.Parse(Request.QueryString["jobID"].Substring(Request.QueryString["jobID"].Length - 5));
        }
        string UserID = "";
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg")
            {
                fileExtension = Path.GetExtension(FileUpload1.FileName);
                if (FileUpload1.PostedFile.ContentLength < 100000000)
                {
                    string p = Path.GetFileName(FileUpload1.FileName);
                    //check if vendor exist in folder
                    if (Directory.Exists(Server.MapPath("~/images/profile_picture/" + UserID + "/ ")) == false)
                    {
                        DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/images/profile_picture/" + UserID + "/ "));
                    }
                    UniqueDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    if (fileExtension.ToLower() == ".jpg")
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/images/profile_picture/" + UserID + "/") + (FileUpload1.FileName.Replace(".jpg", "_" + UniqueDateTime + ".jpg")));
                        canPhoto = Server.MapPath("~/images/profile_picture/" + UserID + "/") + (FileUpload1.FileName.Replace(".jpg", "_" + UniqueDateTime + ".jpg"));
                    }
                    //FileUpload1.SaveAs(Server.MapPath("~/images/profile_picture" + FileUpload1.FileName));
                    lblimagestatus.Text = "File Uploaded...";
                    //canPhoto = "~/images/profile_picture" + FileUpload1.FileName;
                }
                else
                {
                    lblimagestatus.Text = "Only JPEG files with max size 1000 KB are accepted..";
                }
            }
        }
        else
        {
            lblimagestatus.Text = "Please select a file to upload...";
        }
        if (fileupresume.HasFile)
        {
            fileExtension = Path.GetExtension(fileupresume.FileName);
            if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf" && fileExtension.ToLower() != ".rtf")
            {
                lblresumestatus.Text = "Only Files with .doc or .docx extension are allowed...";
                lblresumestatus.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                int filesize = fileupresume.PostedFile.ContentLength;
                if (filesize > 52428800)
                {
                    lblresumestatus.Text = "Maximum file size(50 MB) exceeded";
                    lblresumestatus.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    //check if vendor exist in folder
                    if (Directory.Exists(Server.MapPath("~/Resume/" + Session["VendorID"] + "/")) == false)
                    {
                        DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/Resume/" + Session["VendorID"] + "/"));
                    }
                    //check if jobid exists for that vendor for that resume
                    if (Directory.Exists(Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"])) == false)
                    {
                        DirectoryInfo di = Directory.CreateDirectory(Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"]));
                    }
                    UniqueDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    if (fileExtension.ToLower() == ".doc")
                    {
                        fileupresume.SaveAs(Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".doc", "_" + UniqueDateTime + ".doc")));
                        canResume = Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".doc", "_" + UniqueDateTime + ".doc"));
                    }
                    if (fileExtension.ToLower() == ".docx")
                    {
                        fileupresume.SaveAs(Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".docx", "_" + UniqueDateTime + ".docx")));
                        canResume = Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".docx", "_" + UniqueDateTime + ".docx"));
                    }
                    if (fileExtension.ToLower() == ".rtf")
                    {
                        fileupresume.SaveAs(Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".rtf", "_" + UniqueDateTime + ".rtf")));
                        canResume = Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".rtf", "_" + UniqueDateTime + ".rtf"));
                    }
                    if (fileExtension.ToLower() == ".pdf")
                    {
                        fileupresume.SaveAs(Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".pdf", "_" + UniqueDateTime + ".pdf")));
                        canResume = Server.MapPath("~/Resume/" + Session["VendorID"] + "/" + Request.QueryString["jobID"] + "/") + (fileupresume.FileName.Replace(".pdf", "_" + UniqueDateTime + ".pdf"));
                    }
                    //fileupresume.SaveAs(Server.MapPath("~/Resume/4/JALS000019/") + fileupresume.FileName);
                    lblresumestatus.Text = "File uploaded...";
                    lblresumestatus.ForeColor = System.Drawing.Color.White;
                }
            }
        }
        else
        {
            lblresumestatus.Text = "Please select a file to upload...";
            lblresumestatus.ForeColor = System.Drawing.Color.White;
        }
        API.Service web = new API.Service();
        //API.Service web = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        UserID = Session["UserID"].ToString();
        dom1.LoadXml("<XML>" + web.get_dates(Session["Email"].ToString(), Session["P@ss"].ToString(), jobID.ToString()).InnerXml + "</XML>");

        XmlNodeList Response3 = dom1.SelectNodes("XML/RESPONSE");
        string strat = Response3.Item(0).SelectSingleNode("CONTRACT_START_DATE").InnerText;
        string end = Response3.Item(0).SelectSingleNode("CONTRACT_END_DATE").InnerText;
        dom1.LoadXml("<XML>" + web.set_employee(Session["Email"].ToString(), Session["P@ss"].ToString(),
                txtfistname.Value, txtmiddle.Value, txtlastname.Value, txtemail.Text, txtphone.Value,
                txtdateofbirth.Value, txtsuite.Value, txtaddress1.Value, "", txtcity.Value, ddlprivince.SelectedValue,
                txtpostal.Value, sCountry, txtcomment.Text, canPhoto, txtavailable.Value, txtskype.Value,
                strat, end, jobID, Convert.ToInt32(Session["VendorID"]),
                Convert.ToInt32(Session["ClientID"]), txtlicence.Value, txtsinnumber.Value, txtstdpayf.Value).InnerXml + "</XML>");


        //XmlNodeList Response1 = dom1.SelectNodes("XML/RESPONSE");
        //string employeeID = "";
        string employeeID = "";
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks


                string sqlGetLastInsertedEmployee = "select max(employee_id) as employee_id from ovms_employees where vendor_id = " + Session["VendorID"].ToString() + " and client_id = " + Session["ClientID"].ToString() + " and job_id = " + jobID + "  and active = 1";
                SqlCommand cmdLastInsertedEmployee = new SqlCommand(sqlGetLastInsertedEmployee, conn);
                SqlDataReader readerInsertedEmployee = cmdLastInsertedEmployee.ExecuteReader();

                if (readerInsertedEmployee.HasRows == true)
                {
                    while (readerInsertedEmployee.Read())
                    {
                        employeeID = readerInsertedEmployee["employee_id"].ToString();
                    }
                }
                //close
                readerInsertedEmployee.Close();
                cmdLastInsertedEmployee.Dispose();

                
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
        // employeeID = Response1.Item(0).SelectSingleNode("EMPLOYEE_ID").InnerText;

        dom1.LoadXml("<XML>" + web.insert_resume(Session["Email"].ToString(), Session["P@ss"].ToString(), canResume, jobID.ToString(), employeeID, UserID, Session["VendorId"].ToString()).InnerXml + "</XML>");

        XmlNodeList Response2 = dom1.SelectNodes("XML/RESPONSE");
        if (txtemprating1 != null)
        {
            dom1.LoadXml("<XML>" + web.Insert_emp_ratings(Session["Email"].ToString(), Session["P@ss"].ToString(),employeeID, Session["VendorID"].ToString(),
             Session["ClientID"].ToString(), txtemprating1.Text,txtemprating2.Text, txtemprating3.Text, txtemprating4.Text, txtemprating5.Text, Session["UserID"].ToString(), jobID.ToString()).InnerXml + "</XML>");
        }

        XmlNodeList Response6 = dom1.SelectNodes("XML/RESPONSE");
        if (Response6.Item(0).SelectSingleNode("DATA").InnerText != "")
        {

            lblTableData.Text = "New worker Added succcessfully";

        }
        Response.Redirect("Preview_Workers.aspx?empid=" + employeeID + "&jobID=" + Request.QueryString["jobID"]);
    }

  
    public string CheckCandidateDup(string email)
    {

        //select employee_ID from ovms_employees where job_id = 5 and user_id = 20
        string _SCandDup = "NO";
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                // Session["JobID"] = jobID.ToString();

                //start, end and weeks
                string sqlGetDup = " select count(*) as DUP from ovms_users where email_id = '"+ email  + "' and Vendor_id = '"+ Session["VendorID"].ToString() +"' ";
                SqlCommand cmdGetDup = new SqlCommand(sqlGetDup, conn);
                SqlDataReader rsGetDup = cmdGetDup.ExecuteReader();
                //string _svendorList = "";
                while (rsGetDup.Read())
                {
                    if (rsGetDup["DUP"].ToString() != "0")
                    {
                        _SCandDup = "YES";
                    }
                    //Session["EmployeeIDForJob"] = rsGetEmployeeID["employee_ID"].ToString();
                    //_sArrayString = rsStartEndWeeks["contract_Start_date"].ToString() + "," + rsStartEndWeeks["contract_end_date"].ToString() + "," + rsStartEndWeeks["Num_weeks"].ToString();

                }
                rsGetDup.Close();
                cmdGetDup.Dispose();
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
        return _SCandDup;
    }
    protected void btncont_Click(object sender, EventArgs e)
    {
        setEmployee();
    }
}