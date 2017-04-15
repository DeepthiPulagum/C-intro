using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Diagnostics;
using System.Net;

public class ViaNettSMS
{
    // Declarations
    private string username;
    private string password;

    /// <summary>
    /// Constructor with username and password to ViaNett gateway. 
    /// </summary>
    public ViaNettSMS(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
    /// <summary>
    /// Send SMS message through the ViaNett HTTP API.
    /// </summary>
    /// <returns>Returns an object with the following parameters: Success, ErrorCode, ErrorMessage</returns>
    /// <param name="msgsender">Message sender address. Mobile number or small text, e.g. company name</param>
    /// <param name="destinationaddr">Message destination address. Mobile number.</param>
    /// <param name="message">Text message</param>
    public Result sendSMS(string msgsender, string destinationaddr, string message)
    {
        // Declarations
        string url;
        string serverResult;
        long l;
        Result result;

        // Build the URL request for sending SMS.
        url = "http://smsc.vianett.no/ActiveServer/MT/?"
            + "username=" + HttpUtility.UrlEncode(username)
            + "&password=" + HttpUtility.UrlEncode(password)
            + "&destinationaddr=" + HttpUtility.UrlEncode(destinationaddr, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            + "&message=" + HttpUtility.UrlEncode(message, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            + "&refno=1";

        // Check if the message sender is numeric or alphanumeric.
        if (long.TryParse(msgsender, out l))
        {
            url = url + "&sourceAddr=" + msgsender;
        }
        else
        {
            url = url + "&fromAlpha=" + msgsender;
        }
        // Send the SMS by submitting the URL request to the server. The response is saved as an XML string.
        serverResult = DownloadString(url);
        // Converts the XML response from the server into a more structured Result object.
        result = ParseServerResult(serverResult);
        // Return the Result object.
        return result;
    }
    /// <summary>
    /// Downloads the URL from the server, and returns the response as string.
    /// </summary>
    /// <param name="URL"></param>
    /// <returns>Returns the http/xml response as string</returns>
    /// <exception cref="WebException">WebException is thrown if there is a connection problem.</exception>
    private string DownloadString(string URL)
    {
        using (System.Net.WebClient wlc = new System.Net.WebClient())
        {
            // Create WebClient instanse.
            try
            {
                // Download and return the xml response
                return wlc.DownloadString(URL);
            }
            catch (WebException ex)
            {
                // Failed to connect to server. Throw an exception with a customized text.
                throw new WebException("Error occurred while connecting to server. " + ex.Message, ex);
            }
        }
    }


    /// <summary>
    /// Parses the XML code and returns a Result object.
    /// </summary>
    /// <param name="ServerResult">XML data from a request through HTTP API.</param>
    /// <returns>Returns a Result object with the parsed data.</returns>
    private Result ParseServerResult(string ServerResult)
    {
        System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
        System.Xml.XmlNode ack;
        Result result = new Result();
        xDoc.LoadXml(ServerResult);
        ack = xDoc.GetElementsByTagName("ack")[0];
        result.ErrorCode = int.Parse(ack.Attributes["errorcode"].Value);
        result.ErrorMessage = ack.InnerText;
        result.Success = (result.ErrorCode == 0);
        return result;
    }

    /// <summary>
    /// The Result object from the SendSMS function, which returns Success(Boolean), ErrorCode(Integer), ErrorMessage(String).
    /// </summary>
    public class Result
    {
        public bool Success;
        public int ErrorCode;
        public string ErrorMessage;
    }
}

public partial class C_SmsNotification : System.Web.UI.Page
{
    string username = "deepthi.karri1990@gmail.com";
    string password = "s3dr1";
    string msgsender = "16479663639";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            Response.Redirect("Login.aspx?m=You+have+logged+out");
            Response.End();
        }
       
        if (!Page.IsPostBack)
            {
            venderPone();
            }

    }
     protected void venderPone()
    {
        SqlConnection connect;
        connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
                string querystr = "select v.vendor_name, vd.vendor_PhoneNumber from ovms_vendors as v " +
                            " join ovms_vendor_details as vd on v.vendor_id = vd.vendor_id where v.client_id = " + Session["ClientID"].ToString();
                SqlCommand cmd = new SqlCommand(querystr, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Vendor_Name", typeof(string));
                dt.Columns.Add("Vendor_Phone", typeof(string));
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["Vendor_Name"] = reader["vendor_name"];
                        dr["Vendor_Phone"] = reader["vendor_PhoneNumber"];
                        dt.Rows.Add(dr);
                    }
                }
                vendor_ph.DataSource = dt;
                vendor_ph.DataTextField = "Vendor_Name";
                vendor_ph.DataValueField = "Vendor_Phone";
                vendor_ph.DataBind();
                reader.Close();
                cmd.Dispose();
            }
        }
        catch (Exception exception)
        {
            error.Text = exception.Message;
        }
        finally
        {
           
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }
    }
    protected void sendmessage_Click(object sender, EventArgs e)
    {
        string destinationaddr = vendor_ph.SelectedValue;
        string message = sublab.Value + "\n" + messagesend.Value ;

        
        error.Text = message;
        ViaNettSMS s = new ViaNettSMS(username, password);
        // Declare Result object returned by the SendSMS function
        ViaNettSMS.Result result;
        try
        {
            // Send SMS through HTTP API
            result = s.sendSMS(msgsender, destinationaddr, message);
            // Show Send SMS response
            if (result.Success)
            {
                Debug.WriteLine("Message successfully sent");
            }
            else
            {
                Debug.WriteLine("Received error: " + result.ErrorCode + " " + result.ErrorMessage);
            }
        }
        catch (System.Net.WebException ex)
        {
            //Catch error occurred while connecting to server.
            Debug.WriteLine(ex.Message);
        }

    }





   
}