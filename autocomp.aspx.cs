using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class autocomp : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        SqlConnection conn;
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);

        //using (SqlConnection conn = new SqlConnection())
        //{
            //conn.ConnectionString = ConfigurationManager
            //        .ConnectionStrings["constr"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select em.employee_id,ed.first_name + ' '+ ed.last_name fullname, ed.email,j.job_title,  ed.city,ed.province,   " +
                        "concat('J', clt.client_alias, '00', right('0000' + convert(varchar(4), em.job_id), 4)) job_id " +
                        "from ovms_employees as em " +
                        "join ovms_employee_details as ed on em.employee_id = ed.employee_id " +
                        "join ovms_vendors as ven on em.vendor_id = ven.vendor_id " +
                        "join ovms_clients as clt on em.client_id = clt.client_id " +
                        "join ovms_job_accounting as ja on ja.job_id = em.job_id " +
                        "join ovms_jobs as j on ja.job_id = j.job_id " +
                        "where 1 = 1 " +
                        "and concat('J', clt.client_alias, '00', right('0000' + convert(varchar(4), em.job_id), 4)) like '%" + prefixText + "%' " +
                        "and concat('W', clt.client_alias, '00', right('0000' + convert(varchar(4), em.employee_id), 4)) like'%" + prefixText + "%' " +
                        "or ed.first_name like '%" + prefixText + "%'   or ed.last_name like '%" + prefixText + "%' " +
                        "or ed.city like '%" + prefixText + "%' " +
                        "or ed.province like '%" + prefixText + "%' " +
                        "or j.job_title like '%" + prefixText + "%' " +
                        "or ed.email like '%" + prefixText + "%' ";
            //cmd.Parameters.AddWithValue("@SearchText", prefixText);
            cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add("Name: " + sdr["fullname"].ToString() + " working as:" + sdr["job_title"].ToString() + "(" + sdr["job_id"].ToString() +")");
                    }
                }
                conn.Close();
                return customers;
            }
        //}
    }
}