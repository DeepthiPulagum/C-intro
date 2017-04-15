using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class C_feedback_request : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        string sDates = "";
        string sDateDetails = "";
        string sTable = "";
        string disable = "";
        string rejected = "";
        string more_info = "";
        string cand_approve = "";
        string interview_date = "";
        string interview_confirm1 = "";
        string interview_time = "";
        string schedule = "";
        string job_end_date = "";
        string emp_end_date = "";
        string job_id = "";
        string more_info_reply = "";
        string message_time = "";
        string vendor_reject_candidate = "";
        string interview_rescheduled;

        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);


        //show timesheets needed to be approved
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //string sqlGetJobCountNoAction = " select distinct  ed.create_date " +
                //                                " from ovms_employee_details ed, ovms_employees em, ovms_employee_actions ea " +
                //                              " where ed.employee_id = em.employee_id " +
                //                              " and ed.create_date <= '" + sDate + "' " +
                //                              " and ed.active = 1 " +
                //                              " and em.active = 1 " +
                //                              " and ea.client_id = em.client_id " +
                //                              " and em.client_id = " + Session["ClientID"].ToString() + " " +
                //                              " and em.employee_id not in (select employee_id from ovms_employee_actions as ea ) " +
                //                              " and ed.first_name <> '' " +
                //                              " order by ed.create_date asc";
                //SqlCommand cmdGetNoAction = new SqlCommand(sqlGetJobCountNoAction, conn);
                //SqlDataReader rsGetNoAction = cmdGetNoAction.ExecuteReader();

                //string sPopulateDrop = "";
                //if (rsGetNoAction.HasRows == true)
                //{

                //    sDates = "";

                //    while (rsGetNoAction.Read())
                //    {
                //        sDates = sDates + "<optgroup label='" + rsGetNoAction["create_date"].ToString().Replace("12:00:00 AM", "") + "'>here";

                string sqlGetActionDetailsNoFeedback = " select distinct concat('W', clt.client_alias, '00', right('0000' + convert(varchar(4), em.employee_id), 4)) employee_id, ed.create_date , " +
                                                           " (select job_title from ovms_jobs where job_id = (select job_id from ovms_employees where employee_id = ed.employee_id)) as job_Title, " +
                                                           " dbo.CamelCase(ed.First_Name) as First_Name, " +
                                                           " dbo.CamelCase(ed.Last_Name) as Last_Name, " +
                                                           " em.vendor_id, em.client_Id, em.job_id,j.contract_start_date,j.contract_end_date,ed.end_date,ed.start_date, " +
                                                           " em.user_id from ovms_employee_details ed " +
                                                           " inner join ovms_candidate_feedback as f on f.emplyee_id = ed.employee_id, " +
                                                           " ovms_jobs as j  , " +
                                                           " ovms_employees em, ovms_clients as clt, ovms_employee_actions eact " +
                                                           " where ed.employee_id = em.employee_id " +
                                                           " and em.client_id = clt.client_id and ed.active = 1 " +
                                                           " and em.active = 1 " +
                                                           " and j.job_id = em.job_id " +
                                                           " and eact.client_id = em.client_id " +
                                                           " and em.client_id = " + Session["ClientID"].ToString() + " " +
                                                           " and em.employee_id not in (select employee_id from ovms_employee_actions as eact ) " +
                                                           " and ed.first_name <> ''";

                SqlCommand cmdActionDetails = new SqlCommand(sqlGetActionDetailsNoFeedback, conn);
                SqlDataReader rsGetNoActionDetails = cmdActionDetails.ExecuteReader();
                sDateDetails = "";




                sTable = sTable + "<tbody>";
                if (rsGetNoActionDetails.HasRows == true)
                {
                    while (rsGetNoActionDetails.Read())
                    {
                        sTable = sTable + "<tr>";
                        sTable = sTable + "<td><a target='_blank'  href='Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + rsGetNoActionDetails["employee_id"].ToString() + "'>" + rsGetNoActionDetails["employee_id"].ToString() + " </a></td> ";
                        sTable = sTable + "<td>" + func.FixString(rsGetNoActionDetails["First_Name"].ToString()) + " " + func.FixString(rsGetNoActionDetails["Last_Name"].ToString()) + "</td> ";
                        sTable = sTable + "<td>" + rsGetNoActionDetails["job_Title"].ToString() + " </td> ";
                        string employee2 = rsGetNoActionDetails["employee_id"].ToString();
                        string employeeID = (employee2.Substring(employee2.Length - 6));
                        API.Service getMSGcount = new API.Service();
                        XmlDocument doc1 = new XmlDocument();
                        doc1.LoadXml("<XML>" + getMSGcount.get_message_count_interview_client(Session["Email"].ToString(), Session["P@ss"].ToString(), employeeID).InnerXml + "</XML>");
                        XmlNodeList Response07 = doc1.SelectNodes("XML/RESPONSE/MESSAGE ");

                        if (Response07.Count != 0)

                        {
                            sTable = sTable + "<td><font color='red'><blink><i class='fa fa-fw fa-envelope-o'></i></blink></font><br><a target='_blank' href='C_Dashboard.aspx?wopen=Y&p=VW&done_dash=" + rsGetNoActionDetails["employee_id"].ToString() + "&job_id=" + rsGetNoActionDetails["job_id"].ToString() + "&job_end_date=" + rsGetNoActionDetails["contract_end_date"].ToString() + "&emp_enddate=" + rsGetNoActionDetails["end_date"].ToString() + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-calendar fa-fw'></i></a> " +
                                                 "<a target='_blank' href='C_Dashboard.aspx?wopen=Y&p=VW&Reject_dash=" + rsGetNoActionDetails["employee_id"].ToString() + "&job_id=" + rsGetNoActionDetails["job_id"].ToString() + "&job_end_date=" + rsGetNoActionDetails["contract_end_date"].ToString() + "&emp_enddate=" + rsGetNoActionDetails["end_date"].ToString() + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a> " +
                                                 "<a target='_blank' href='C_Dashboard.aspx?wopen=Y&p=VW&emp_id=" + rsGetNoActionDetails["employee_id"].ToString() + "&schedule_int=" + schedule + "&forImsgDash=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";
                        }
                        else
                        {
                            sTable = sTable + "<td><a target='_blank' href='C_Dashboard.aspx?wopen=Y&p=VW&done_dash=" + rsGetNoActionDetails["employee_id"].ToString() + "&job_id=" + rsGetNoActionDetails["job_id"].ToString() + "&job_end_date=" + rsGetNoActionDetails["contract_end_date"].ToString() + "&emp_enddate=" + rsGetNoActionDetails["end_date"].ToString() + "'class='btn btn-success btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Request for an Interview or Approve candidate'><i class='fa fa-calendar fa-fw'></i></a> " +
                                               "<a target='_blank' href='C_Dashboard.aspx?wopen=Y&p=VW&Reject_dash=" + rsGetNoActionDetails["employee_id"].ToString() + "&job_id=" + rsGetNoActionDetails["job_id"].ToString() + "&job_end_date=" + rsGetNoActionDetails["contract_end_date"].ToString() + "&emp_enddate=" + rsGetNoActionDetails["end_date"].ToString() + "' class='btn btn-danger btn-xs' data-toggle='tooltip' data-placement='top' name='abc' title='Reject Candidate'><i class='fa fa-times'></i></a> " +
                                               "<a target='_blank' href='C_Dashboard.aspx?wopen=Y&p=VW&emp_id=" + rsGetNoActionDetails["employee_id"].ToString() + "&schedule_int=" + schedule + "&forImsgDash=" + 1 + "'class='btn btn-primary btn-xs'  data-toggle='tooltip' data-placement='top' name='abc' title='Send Comments To Vendor'><i class='fa fa-comment''></i></a></td>";
                        }

                        sTable = sTable + "</tr>";
                    }
                    //close
                    rsGetNoActionDetails.Close();
                    cmdActionDetails.Dispose();

                }


                else
                {
                    sTable = sTable + "<tr>";
                    sTable = sTable + "<td colspan=3>No Candidate at this time</td>";
                    sTable = sTable + "</tr>";
                }

                sTable = sTable + "</tbody>";

                lblTableData.Text = sTable;
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