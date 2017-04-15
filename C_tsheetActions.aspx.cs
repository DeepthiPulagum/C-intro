using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.IO;


public partial class C_tsheetActions : System.Web.UI.Page
{
    emailFunctions semail = new emailFunctions();
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();
    private int iResponse;

    protected void Page_Load(object sender, EventArgs e)
    {
        //update timesheet status
        if (Request.QueryString["action"] != null)
        {
            //timesheet popup modal action text
            //lblAction.Text = "Timesheet Action";
            // lblActionTimeSheet.Text = "Are you sure you want to " + Request.QueryString["action"] + " this timesheet?";
            if (Request.QueryString["ModalAction"] != null)
            {
                //update status
                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                        string _TimeSheetID = "0";
                        string sqlGetTimeSheetID = "";

                        //start, end and weeks
                        //get timesheetID + 7

                        sqlGetTimeSheetID = " select timesheet_id " +
                                                " from ovms_timesheet " +
                                                " where day =  " + Request.QueryString["fromD"].ToString() + " " +
                                                " and month =  " + Request.QueryString["FromM"].ToString() + " " +
                                                " and year = " + Request.QueryString["FromY"].ToString() + " " +
                                                " and employee_id = " + Request.QueryString["TID"].ToString() + " " +
                                                " and active =  1";

                        SqlCommand cmdGetTimeSheetID = new SqlCommand(sqlGetTimeSheetID, conn);
                        SqlDataReader rsGetTimeSheetID = cmdGetTimeSheetID.ExecuteReader();
                        if (rsGetTimeSheetID.HasRows == true)
                        {
                            while (rsGetTimeSheetID.Read())
                            {
                                _TimeSheetID = rsGetTimeSheetID["timesheet_id"].ToString();
                            }
                        }
                        //close
                        rsGetTimeSheetID.Close();
                        cmdGetTimeSheetID.Dispose();

                        string sSQLUpdate = "";
                        string sAction = "";
                        if (Request.QueryString["action"] == "Approve")
                        {
                            //update
                            sAction = "Approve";
                            sSQLUpdate = " update ovms_timesheet_details " +
                                                        " set timesheet_status_id = 1 " +
                                                        " where timesheet_id between " + _TimeSheetID + " and " + (Convert.ToInt32(_TimeSheetID.ToString()) + +Convert.ToInt32("6")) + " " +
                                                        " and active = 1";


                            string emp_id = Request.QueryString["TID"].ToString();
                            string totalhours = Request.QueryString["hours"].ToString();
                            string name = Request.QueryString["Mess"].ToString();
                            // string vendor_email = Session["Vendor_Email"].ToString();


                            semail.sendEmail("123@gmail.com", "TIMESHEET is approved - (" + name + ")", "<br>Worker ID :" + emp_id +

                                "<br>Time Sheet Billable Days : 7 days" +
                                "<br>Time Sheet Billable Hours :" + totalhours +
                                "<br>******" +
                                "<br>This notification was sent by FlentisPRO.If you have any questions regarding this notice," +
                                "<br>please contact the SAP Fieldglass Helpdesk at:" +
                                "<br>mailto:helpdesk@oveems.com" +
                                "<br>By Phone:" +
                                "<br>US(toll free) 1 800 123 1234" +
                                "<br>Please do not respond to this email, this is an automatic email message and this mailbox is not being monitored.", "", "");
                        }

                        if (Request.QueryString["action"] == "Reject")
                        {
                            //update
                            string emp_id = Request.QueryString["TID"].ToString();
                            string reason_of_rejection = Request.QueryString["reason"].ToString();
                            string day = Request.QueryString["fromD"].ToString();

                            string month = Request.QueryString["FromM"].ToString();
                            string year = Request.QueryString["FromY"].ToString();
                            // string test = year + month + day;
                            DateTime tsheet_strt_date = Convert.ToDateTime(day + "/" + month + "/" + year);
                            DateTime tsheet_end_date = tsheet_strt_date.AddDays(7);
                            sAction = "Reject";
                            sSQLUpdate = " update ovms_timesheet_details " +
                                                        " set timesheet_status_id = 2 " +
                                                        " where timesheet_id between " + _TimeSheetID + " and " + (Convert.ToInt32(_TimeSheetID.ToString()) + +Convert.ToInt32("6")) + " " +
                                                        " and active = 1";
                            sSQLUpdate = sSQLUpdate + " INSERT INTO ovms_timesheet_comments " +
                                                      " (timesheet_id, employee_id, timesheet_comments,from_date, to_date)" +
                                                      " VALUES(" + _TimeSheetID + "," + emp_id + " , ' " + reason_of_rejection + "','" + tsheet_strt_date + "' , '" + tsheet_end_date + "')";
                            string emp_id_reject = Request.QueryString["TID"].ToString();
                            API.Service name = new API.Service();
                            XmlDocument _xmlDoc = new XmlDocument();
                            _xmlDoc.LoadXml("<XML>" + name.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), emp_id_reject, "", "", "", "", "1", "").InnerXml + "</XML>");
                            XmlNodeList ea1 = _xmlDoc.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                            string name2 = "";
                            name2 = ea1[iResponse].SelectSingleNode("FIRSTNAME").InnerText;
                            string job_name = ea1[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
                            string vendor_email = Session["Vendor_Email"].ToString();






                            semail.sendEmail("aakash.brar01@gmail.com", "TIMESHEET is rejected - (" + name + ")", "<br>Worker Name :" + name2 +



                                "<br>******" +
                                "<br>This notification was sent by FlentisPRO.If you have any questions regarding this notice," +
                                "<br>please contact the SAP Fieldglass Helpdesk at:" +
                                "<br>mailto:helpdesk@oveems.com" +
                                "<br>By Phone:" +
                                "<br>US(toll free) 1 800 123 1234" +
                                "<br>Please do not respond to this email, this is an automatic email message and this mailbox is not being monitored.", "", "");

                        }
                        //    Uri uri = new Uri("http://www.opusingats.com/e_Timesheet_Email.aspx?timesheet_id=1");

                        //    string data = "field-keywords=ASP.NET 2.0";

                        //    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                        //    request.Method = WebRequestMethods.Http.Post;
                        //    request.ContentLength = data.Length;
                        //    request.ContentType = "application/x-www-form-urlencoded";
                        //    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        //    writer.Write(data);
                        //    writer.Close();
                        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        //    StreamReader reader = new StreamReader(response.GetResponseStream());

                        //    string tmp = reader.ReadToEnd();
                        //    response.Close();
                        //    Response.Write(tmp);
                        //    Response.Write(tmp);

                        //    MailMessage mail = new MailMessage();
                        //    set the addresses
                        //    mail.From = new MailAddress("notifications@opusingats.com"); //IMPORTANT: This must be same as your smtp authentication address.
                        //    mail.To.Add("greg@opusing.com");

                        //    set the content
                        //    mail.Subject = "This is an email";
                        //    mail.Body = tmp;
                        //    mail.IsBodyHtml = true;

                        //    send the message
                        //    SmtpClient smtp = new SmtpClient("mail.opusingats.com");

                        //IMPORANT: Your smtp login email MUST be same as your FROM address. 
                        //    NetworkCredential Credentials = new NetworkCredential("notifications@opusingats.com", "Maracaibo15@.");
                        //    smtp.Credentials = Credentials;
                        //    smtp.Send(mail);
                        // blMessage.Text = "Mail Sent";
                        SqlCommand cmdUpdateTimeSheet1 = new SqlCommand(sSQLUpdate, conn);
                        int iUpdate = cmdUpdateTimeSheet1.ExecuteNonQuery();
                        cmdUpdateTimeSheet1.Dispose();






                    }


                }
                catch (Exception ex)
                {
                    string abc = "";
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            } //end of ModalAction
        }
        Response.Redirect("Client.aspx?TU=True");
        Response.End();
        //end of update timesheet status
    }
}