using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class C_settings : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {



        if (Request.QueryString["C_settingPop"] == "1")
        {
            lbladdress1.Text = Request.QueryString["address1"];
            lbladdress2.Text = Request.QueryString["address2"];
            lblcity.Text = Request.QueryString["city"];
            lblcopname.Text = Request.QueryString["compamy_name"];
            lblcountry.Text = Request.QueryString["country"];
            lblphone.Text = Request.QueryString["phone"];
            lblemail.Text = Request.QueryString["email"];
            lblSecEmail.Text = Request.QueryString["secemail"];
            lblfax.Text = Request.QueryString["fax"];
            lblpostal.Text = Request.QueryString["postal"];
            
        }
       
        if (!Page.IsPostBack)
            {


                XmlDocument xmldoc = new XmlDocument();
                API.Service prof = new API.Service();
                // API.Service prof = new API.Service();
                xmldoc.LoadXml("<XML>" + prof.get_Profile(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["UserID"].ToString()).InnerXml + "</XML>");
                // xmldoc.LoadXml("<XML>" + prof.get_Profile("greg@opusing.com ", "1234", "9").InnerXml + "</XML>");
                XmlNodeList Response = xmldoc.SelectNodes("XML/RESPONSE/USER_NO");

                txtfirst.Text = xmldoc.SelectSingleNode("XML/RESPONSE/USER_NO/FIRST_NAME").InnerText;
                txtsecond.Text = xmldoc.SelectSingleNode("XML/RESPONSE/USER_NO/LAST_NAME").InnerText;
                txtemail.Text = xmldoc.SelectSingleNode("XML/RESPONSE/USER_NO/EMAIL").InnerText;

                // Password1.Value = xmldoc.SelectSingleNode("XML/RESPONSE/USER_NO/PASSWORD").InnerText;

                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();

                    // Session["JobID"] = jobID.ToString();

                    //start, end and weeks
                    string sqlgetvenddetails = " select * from ovms_clients as clt " +
                                              " join ovms_client_details as cltd on clt.client_id = cltd.client_id where clt.client_id =  '" + Session["ClientID"].ToString() + "'";
                    SqlCommand v_details = new SqlCommand(sqlgetvenddetails, conn);
                    SqlDataReader reader = v_details.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            string address1 = "";
                            txtPhone.Text = reader["client_phoneNumber"].ToString();
                            Txtcompemail.Text = reader["Primary_email"].ToString();
                            address1 = "Suite: " + reader["client_address1"].ToString();
                            // address1 = Server.HtmlDecode(address1 + " Postal Code: " + reader["vendor_postal_code"].ToString());
                            // address1 = address1 + "  Country:" + reader["vendor_country"].ToString();
                            txtComp_name.Text = reader["client_name"].ToString();
                            txtsecEmail.Text = reader["secondary_email"].ToString();
                            txtSuite.Text = reader["client_address1"].ToString();
                            txtPostal.Text = reader["client_postal_code"].ToString();
                            txtcity.Text = reader["client_city"].ToString();
                            txtcountry.Text = reader["client_country"].ToString();
                            txtfax.Text = reader["client_faxNumber"].ToString();
                            txtadrres2.Text = reader["client_address2"].ToString();
                            // Txtaddres.Text = address1;
                        }

                    }
                    reader.Close();
                    v_details.Dispose();
                    conn.Close();
                }

            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    string querystr = "SELECT TOP 1 client_id FROM ovms_client_smsnotification WHERE client_id = " + Session["ClientID"].ToString();
                    SqlCommand cmd = new SqlCommand(querystr, conn);
                    SqlDataReader readers = cmd.ExecuteReader();
                    if (readers.HasRows == true)
                    {
                        while (readers.Read())
                        {
                            if (readers["client_id"].ToString() == Session["ClientID"].ToString())
                            {
                                string selectstr = "select * from ovms_client_smsnotification";
                                SqlCommand cmdsel = new SqlCommand(selectstr, conn);
                                SqlDataReader reads = cmdsel.ExecuteReader();
                                if (reads.HasRows == true)
                                {
                                    while (reads.Read())
                                    {
                                        RadioButtonList1.SelectedValue = reads["newjob_notify"].ToString();
                                        RadioButtonList2.SelectedValue = reads["interview_schedule_notify"].ToString();
                                        RadioButtonList3.SelectedValue = reads["interview_reschedule_notify"].ToString();
                                        RadioButtonList4.SelectedValue = reads["candid_approve_notify"].ToString();
                                        RadioButtonList5.SelectedValue = reads["candid_reject_notify"].ToString();
                                        RadioButtonList6.SelectedValue = reads["timesheet_approve_notify"].ToString();
                                        RadioButtonList7.SelectedValue = reads["timesheet_reject_notify"].ToString();
                                    }
                                }
                                reads.Close();
                                cmdsel.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorDisp.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        

    }



    // protected void Button1_Click1(object sender, EventArgs e)


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (txtfirst.Text == "" || txtsecond.Text == "" || txtemail.Text == "")
        {
            Label4.Text = "*Fields can not be empty";
            Label4.ForeColor = System.Drawing.Color.Red;
            Label4.Focus();
        }


        else
        {

            XmlDocument xmldoc = new XmlDocument();
            API.Service updateP = new API.Service();
            // API.Service updateP = new API.Service();
            xmldoc.LoadXml("<XML>" + updateP.update_Basic_Profile(Session["Email"].ToString(), Session["P@ss"].ToString(), txtfirst.Text, txtsecond.Text, txtemail.Text, Session["UserID"].ToString()).InnerXml + "</XML>");
            Session["Email"] = "";
            Session["Email"] = txtemail.Text;
            Response.Redirect("V_settings.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (txtnewpass.Text == "" || txtcompass.Text == "")
        {

            Label1.Text = "*Fields can not be empty";
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Focus();
        }
        else
        {
            if (txtnewpass.Text != txtcompass.Text)
            {

                Label1.Text = "*Passwords do not match";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Focus();

            }
            else
            {
                XmlDocument xmldoc = new XmlDocument();
                API.Service updateP = new API.Service();
                xmldoc.LoadXml("<XML>" + updateP.update_Personal_Profile(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["UserID"].ToString(), txtnewpass.Text).InnerXml + "</XML>");
                Session["P@ss"] = "";
                Session["P@ss"] = txtnewpass.Text;
                Response.Redirect("V_settings.aspx");
            }


        }

    }

    protected void btnupdateCompInfo_Click(object sender, EventArgs e)
    {
        string compname = txtComp_name.Text;
        string phone = txtPhone.Text;
        string fax = txtfax.Text;
        string address1 = txtSuite.Text;
        string address2 = txtadrres2.Text;
        string country = txtcountry.Text;
        string email = Txtcompemail.Text;
        string secndemail = txtsecEmail.Text;
        string city = txtcity.Text;
        string postal = txtPostal.Text;
        Response.Redirect("C_settings.aspx?compamy_name=" + compname + "&C_settingPop=1&postal=" + postal + "&phone=" + phone + "&fax=" + fax + "&address1=" + address1 + "&address2=" + address2 + "&country=" + country + "&email=" + email + "&secemail=" + secndemail + "&city=" + city);

    }

    protected void btnchangeprofile_client_Click(object sender, EventArgs e)
    {
        string compname = Request.QueryString["compamy_name"];
        string phone = Request.QueryString["phone"];
        string fax = Request.QueryString["fax"];
        string address1 = Request.QueryString["address1"];
        string address2 = Request.QueryString["address2"];
        string country = Request.QueryString["country"];
        string email = Request.QueryString["email"];
        string secndemail = Request.QueryString["secemail"];
        string city = Request.QueryString["city"];
        string postal = Request.QueryString["postal"];



        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);


        if (conn.State == System.Data.ConnectionState.Closed)
        {
            conn.Open();


            string updateClient2 = "update ovms_clients set client_name='" + compname + "' where client_id='" + Session["ClientID"].ToString() + "'";
            string updateClient = updateClient2 + "update ovms_client_details set client_address1='" + address1 + "',client_address2='" + address2 + "'," +
             " client_postal_code='" + postal + "',client_city='" + city + "',client_faxNumber='" + fax + "',client_phoneNumber='" + phone + "',client_country='" + country + "',Primary_email='" + email + "',secondary_email='" + secndemail + "'" +
             " where client_id='" + Session["ClientID"].ToString() + "'";

            SqlCommand c_details = new SqlCommand(updateClient, conn);
            SqlDataReader reader = c_details.ExecuteReader();

            c_details.Dispose();
            conn.Close();
            reader.Close();
        }

        Response.Redirect("C_settings.aspx");
    }

    protected void updatesms_Click(object sender, EventArgs e)
    {
        int newjob = Int32.Parse(RadioButtonList1.SelectedValue);
        int interviewSch = Int32.Parse(RadioButtonList2.SelectedValue);
        int interviewRedch = Int32.Parse(RadioButtonList3.SelectedValue);
        int candidApp = Int32.Parse(RadioButtonList4.SelectedValue);
        int candidRej = Int32.Parse(RadioButtonList5.SelectedValue);
        int timesheetApp = Int32.Parse(RadioButtonList6.SelectedValue);
        int timesheetrej = Int32.Parse(RadioButtonList7.SelectedValue);
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
                string querystr = "SELECT TOP 1 client_id FROM ovms_client_smsnotification WHERE client_id = " + Session["ClientID"].ToString();
                SqlCommand cmd = new SqlCommand(querystr, conn);
                SqlDataReader readers = cmd.ExecuteReader();
                if (readers.HasRows == true)
                {
                    while (readers.Read())
                    {
                        if(readers["client_id"].ToString()== Session["ClientID"].ToString())
                            {
                            string updatequery = " UPDATE ovms_client_smsnotification " +
                                                 " SET newjob_notify = " + newjob + ", interview_schedule_notify = " + interviewSch + ", interview_reschedule_notify = " + interviewRedch +
                                                 ", candid_approve_notify = " + candidApp + ", candid_reject_notify = " + candidRej + ", timesheet_approve_notify = " + timesheetApp + ", timesheet_reject_notify = " + timesheetrej +
                                                 " WHERE client_id = " + Session["ClientID"].ToString();
                            SqlCommand cmdupdatequery = new SqlCommand(updatequery, conn);
                            cmdupdatequery.ExecuteReader();
                            cmdupdatequery.Dispose();
                        }
                        else
                        {
                            string insertquerys = "INSERT INTO ovms_client_smsnotification (client_id, newjob_notify, interview_schedule_notify, interview_reschedule_notify, candid_approve_notify, candid_reject_notify, timesheet_approve_notify,timesheet_reject_notify) " +
                                            " VALUES(" + Session["ClientID"].ToString() + ", " + newjob + "," + interviewSch + "," + interviewRedch + "," + candidApp + "," + candidRej + "," + timesheetApp + "," + timesheetrej + " ) ";
                            SqlCommand cmdquery = new SqlCommand(insertquerys, conn);
                            cmdquery.ExecuteReader();
                            cmdquery.Dispose();
                        }
                    }
                }
                else
                {
                    string insertquerys = "INSERT INTO ovms_client_smsnotification (client_id, newjob_notify, interview_schedule_notify, interview_reschedule_notify, candid_approve_notify, candid_reject_notify, timesheet_approve_notify,timesheet_reject_notify) " +
                                    " VALUES(" + Session["ClientID"].ToString() + ", " + newjob + "," + interviewSch + "," + interviewRedch + "," + candidApp + "," + candidRej + "," + timesheetApp + "," + timesheetrej + " ) ";
                    SqlCommand cmdinsquery = new SqlCommand(insertquerys, conn);
                    cmdinsquery.ExecuteReader();
                    cmdinsquery.Dispose();
                }
                readers.Close();
                cmd.Dispose();
                //
                //SqlCommand cmd = new SqlCommand(querystr, connect);
                //SqlDataReader reader = cmd.ExecuteReader();
            }
        }
        catch (Exception error)
        {
            errorDisp.Text = error.Message;
        }
        finally
        {
            conn.Close();
        }
    }
}

