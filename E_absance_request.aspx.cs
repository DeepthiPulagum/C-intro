using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class E_absance_request : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();
    emailFunctions semail = new emailFunctions();
    private int iResponseq;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["action"] != null)
        {
            lblAbsenceSent.Text = "<a href ='#' class='btn btn-success'>Thank you - Request has been sent<i class='fa fa-check-circle fa-fw'></i></a>";
        }
    }
    protected void btnSendRequest_Click(object sender, EventArgs e)
    {

        //connect to database insert the request and send back to employee side and then notify request has been send
        //select first_name, last_name, email_id from ovms_users where user_id = 9
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                string sqlInsertRequest = " insert into ovms_requests (employee_id, vendor_id, client_id, requested_date, requested_Reason, requested_Comments, user_id) " +
                                           " values((select employee_id from ovms_employees where user_id = " + Session["UserID"].ToString() + " and active = 1), " + Session["VendorID"].ToString() + ", " + Session["ClientID"].ToString() + ", '" + datepicker.Value + "', '" + textreason.InnerText + "', '" + textcomment.InnerText + "', " + Session["UserID"].ToString() + ")";
                SqlCommand cmdInsertReq = new SqlCommand(sqlInsertRequest, conn);
                int ReqInsert = cmdInsertReq.ExecuteNonQuery();


                //close connection
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();

                Response.Redirect("E_dashboard?action=RI");
                Response.End();
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
}