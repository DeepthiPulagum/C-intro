using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public partial class C_View_rejectedCandidate : System.Web.UI.Page
{
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

        string sTable = "<tbody>";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
                string rejectCandidData = "select ea.vendor_id, ea.client_id, " +
                                             " concat('W', clt.client_alias, '00', right('0000' + convert(varchar(4), ea.employee_id), 4))empfull, " +
                                             " ea.job_id, (ea.candidate_rejected)rejected, (ea.reason_of_rejection)reason, " +
                                            " (ea.candidate_reject_time)times, dbo.CamelCase(ed.first_name + ' ' + ed.last_name) full_name, (j.job_title)job_title,  " +
                                            " dbo.CamelCase(clt.client_name) rejected_by " +
                                            " from ovms_employee_actions as ea " +
                                            " join ovms_employee_details as ed on ea.employee_id = ed.employee_id " +
                                            " join ovms_jobs as j on ea.job_id = j.job_id " +
                                            " join ovms_clients as clt on clt.client_id = ea.client_id " +
                                            " where ea.candidate_rejected =1 and ea.client_id = " + Session["ClientID"].ToString() +
                                            " union select ea.vendor_id, ea.client_id, " +
                                             " concat('W', clt.client_alias, '00', right('0000' + convert(varchar(4), ea.employee_id), 4))empfull,  " +
                                             " ea.job_id, (ea.vendor_reject_candidate)rejected, (ea.vendor_reject_candidate_comment)reason, " +
                                             " (ea.vendor_reject_candidate_time)times, dbo.CamelCase(ed.first_name + ' ' + ed.last_name) full_name,(j.job_title)job_title, " +
                                             " dbo.CamelCase(v.vendor_name) rejected_by " +
                                             " from ovms_employee_actions as ea " +
                                            " join ovms_employee_details as ed on ea.employee_id = ed.employee_id " +
                                            " join ovms_jobs as j on ea.job_id = j.job_id " +
                                            " join ovms_clients as clt on clt.client_id = ea.client_id " +
                                            " join ovms_vendors as v on v.vendor_id = ea.vendor_id " +
                                            " where ea.vendor_reject_candidate = 1 and ea.client_id = " + Session["ClientID"].ToString() +
                                            " ORDER BY ea.candidate_reject_time desc";
                SqlCommand cmdrejectCandidate = new SqlCommand(rejectCandidData, conn);
                SqlDataReader readRejectCandid = cmdrejectCandidate.ExecuteReader();
                int intCount = 1;

                if (readRejectCandid.HasRows == true)
                {

                    while (readRejectCandid.Read())
                    {
                        string reason = readRejectCandid["reason"].ToString();
                        if (reason == "" || reason == null)
                            reason = "No reason given";
                        sTable = sTable + " ";
                        sTable = sTable + "<tr >";
                        sTable = sTable + "<td>" + intCount + "</td>";
                        sTable = sTable + "<td><a href='Client_View_Worker_detail.aspx?&empID=" + readRejectCandid["empfull"].ToString() + "'</a>" + readRejectCandid["empfull"].ToString() + "</td>";

                        sTable = sTable + "<td>" + readRejectCandid["full_name"].ToString() + "</td>";
                        sTable = sTable + "<td>" + readRejectCandid["job_title"].ToString() + "</td> ";
                        sTable = sTable + "<td>" + String.Format("{0:dd-MM-yyyy}", readRejectCandid["times"]) + " </td> ";
                        sTable = sTable + "<td >" + String.Format("{0:hh:mm tt}", readRejectCandid["times"]) + " </td> ";
                        sTable = sTable + "<td>" + reason + "</td> ";
                        sTable = sTable + "<td >" + readRejectCandid["rejected_by"].ToString() + " </td>";
                        intCount++;
                        sTable = sTable + "</tr>";

                    }
                }
                readRejectCandid.Close();
                readRejectCandid.Dispose();
            }

        }
        catch (Exception ex)
        {
            sTable = sTable + "<tr>" + ex.Message + "</tr>";
        }
        finally
        {
            sTable = sTable + "</tbody>";
            lblTableData.Text = sTable;
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

    }
    public void rejected_candidate()
    {

    }

}