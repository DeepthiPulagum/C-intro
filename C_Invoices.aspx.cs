using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Xml;

public partial class C_Invoices : System.Web.UI.Page
{
    SqlConnection conn;
    string errString = "";
    StringFunctions func = new StringFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

        string sTable = "";
        string overtime = "";
        string svendorPay = "";
        //show timesheets needed to be approved
        try
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();

                //getJobs
                string strGetDetails = " select distinct timesheet_status_id, vendor_id,(select vendor_name from ovms_vendors where vendor_id= " + Session["VendorID"].ToString() + " ) as vendor_name, timesheet_id_from, timesheet_status, weeknum, employee_id, first_name, last_name, Agency_Pay_Employee, " +
                                    " job_id,JobManager_ID,Province_State, (select  top 1 CONCAT(month, '-', day, '-', year) from ovms_timesheet  where employee_id = employee_id and DatePart(week, dateadd(d,-1, CONCAT(month, '-', day, '-', year))) = weeknum) as date_from, " +
                                    " (select sum(a.hours) as hours_total from ovms_timesheet a, ovms_timesheet_details b where a.employee_id = employee_id and a.timesheet_id = b.timesheet_id and a.active = 1 and b.active = 1 and b.timesheet_status_id = 1 and DatePart(week, dateadd(d, -1, CONCAT(a.month, '-', a.day, '-', a.year))) = weeknum) as hours_reported, " +
                                    " (select  top 1 dateadd(d, 6, CONCAT(month, '-', day, '-', year)) from ovms_timesheet  where employee_id = employee_id and DatePart(week, dateadd(d,-1, CONCAT(month, '-', day, '-', year))) = weeknum) as date_to " +
                                    " from(select distinct ts.timesheet_status_id, ts.timesheet_status, e.job_id, (select user_id from ovms_jobs where job_id = e.job_id) as JobManager_ID,   " +
                                    " DatePart(week, dateadd(d, -1, CONCAT(month, '-', day, '-', year))) as weeknum, " +
                                    " (select top 1 a.timesheet_id from ovms_timesheet a, ovms_timesheet_details b where a.timesheet_id = b.timesheet_id and a.employee_id = e.employee_id and a.active = 1 and b.active = 1 and b.timesheet_status_id = 1) as timesheet_id_from, " +
                                    " e.employee_id, e.vendor_id, " +
                                    " (select province from ovms_employee_details where employee_id =  e.employee_id) as Province_State, " +
                                    " dbo.CamelCase(ed.first_name) as first_name, " +
                                    " dbo.CamelCase(ed.last_name) as last_name,  " +
                                    " ed.pay_rate as Agency_Pay_Employee " +
                                    " from ovms_timesheet_status as ts " +
                                    " join ovms_timesheet_details as td on " +
                                    " ts.timesheet_status_id = td.timesheet_status_id  join ovms_timesheet as t on " +
                                    " td.timesheet_id = t.timesheet_id  join ovms_employees as e on " +
                                    " t.employee_id = e.employee_id  join ovms_employee_details as ed on " +
                                    " e.employee_id = ed.employee_id " +
                                    " where " +
                                    " ts.timesheet_status_id = 1 " +
                                    " and e.client_id = " + Session["ClientID"].ToString() + " " +
                                    " and e.active = 1) as times " +
                                    " where timesheet_status_id = 1 " +
                                    " order by first_name asc ";
                SqlCommand cmdGetDetails = new SqlCommand(strGetDetails, conn);
                SqlDataReader readerGetDetails = cmdGetDetails.ExecuteReader();
                sTable = sTable + "<tbody>";
                string _sBackground = "";
                int intCount = 0;
                if (readerGetDetails.HasRows == true)
                {
                    while (readerGetDetails.Read())
                    {
                        if (intCount % 2 >= 1)
                        {
                            //enableordisable = "";
                            _sBackground = "bgcolor='#ECF0F1'";
                        }
                        else
                        {
                            // enableordisable = "disabled";
                            _sBackground = "";
                        }
                        intCount = intCount + 1;
                        sTable = sTable + "<tr " + _sBackground + "> ";
                        //<th>Contractor Name</th>

                        sTable = sTable + "<td>" + func.FixString(readerGetDetails["FIRST_NAME"].ToString()) + " " + func.FixString(readerGetDetails["LAST_NAME"].ToString()) + "</p></td> ";
                        //<th>Week Starting</th>
                        sTable = sTable + "<td>" + DateTime.Parse(func.FixString(readerGetDetails["DATE_FROM"].ToString())).ToString("dd MMM, yyyy") + "</td>";
                        //<th>Week Ending</th>
                        sTable = sTable + "<td>" + DateTime.Parse(func.FixString(readerGetDetails["DATE_TO"].ToString())).ToString("dd MMM, yyyy") + "</td>";
                        //<th>Total Hours</th>
                        //sTable = sTable + "<td>" + func.FixString(readerGetDetails["HOURS_REPORTED"].ToString()) + "</td>";
                        //get rates
                        svendorPay = GetVendorPay(readerGetDetails["JOB_ID"].ToString());
                        //get Overtime of State/Province of Person
                        overtime = GetStateProvinceOverTime(readerGetDetails["Province_State"].ToString());
                        double overTimeDiff = 0;
                        double overTimeAmount = 0;
                        double standardTimeAmount = 0;
                        if (Convert.ToDouble(readerGetDetails["HOURS_REPORTED"].ToString()) <= Convert.ToDouble(overtime))
                        {
                            standardTimeAmount = Convert.ToDouble(readerGetDetails["HOURS_REPORTED"].ToString()) * Convert.ToDouble(svendorPay.Split(',')[0].ToString());
                        }
                        if (Convert.ToDouble(readerGetDetails["HOURS_REPORTED"].ToString()) > (Convert.ToDouble(overtime)))
                        {
                            //get the difference 
                            overTimeDiff = (Convert.ToDouble(readerGetDetails["HOURS_REPORTED"].ToString()) - Convert.ToDouble(overtime));
                            overTimeAmount = Convert.ToDouble(overTimeDiff) * Convert.ToDouble(svendorPay.Split(',')[1].ToString());
                        }
                        //<th>Total Hours</th>
                        sTable = sTable + "<td>" + readerGetDetails["HOURS_REPORTED"].ToString() + "</td>";//bill rate
                        //<th>Standard Hours</th>
                        double sTimeStandard = 0;
                        //if (overTimeDiff > 0)
                        //{
                        //    sTable = sTable + "<td>" + overtime + "</td>"; //standard per province
                        //    sTimeStandard = Convert.ToDouble(overtime);
                        //}
                        if (Convert.ToDouble(readerGetDetails["HOURS_REPORTED"].ToString()) <= Convert.ToDouble(overtime))
                        {
                            //sTable = sTable + "<td>" + standardTimeAmount + "</td>"; //diff of hours
                            sTimeStandard = Convert.ToDouble(readerGetDetails["HOURS_REPORTED"].ToString());
                            sTable = sTable + "<td>" + readerGetDetails["HOURS_REPORTED"].ToString() + "</td>";
                        }
                        else
                        {
                            sTimeStandard = Convert.ToDouble(overtime.ToString());
                            //sTable = sTable + "<td>" + overTimeDiff + "</td>";
                            sTable = sTable + "<td>" + overtime.ToString() + "</td>";
                        }
                        //<th>Standard Rate</th>
                        sTable = sTable + "<td>" + svendorPay.Split(',')[0].ToString() + "</td>";//bill rate
                        //<td>Standard Amount</td>
                        sTable = sTable + "<td>" + string.Format("{0:c0}", (Convert.ToDouble(sTimeStandard) * Convert.ToDouble(svendorPay.Split(',')[0].ToString()))) + "</td>"; //overtime
                        //<th>Overtime Hours</th>
                        sTable = sTable + "<td>" + overTimeDiff + "</td>";
                        //<th>Overtime Rate</th>
                        sTable = sTable + "<td>" + "$" + svendorPay.Split(',')[1].ToString() + "</td>";
                        //<td>Overtime Amount</td>
                        sTable = sTable + "<td>" + string.Format("{0:c0}", Convert.ToDouble(overTimeDiff) * Convert.ToDouble(svendorPay.Split(',')[1].ToString())) + " </td>";
                        //<th>Gross Amount</th>
                        string dGrossAmount = "0";
                        string sGrossAmount = "0";
                        sGrossAmount = (Convert.ToDouble(sTimeStandard) * Convert.ToDouble(svendorPay.Split(',')[0].ToString())) + (Convert.ToDouble(overTimeDiff) * Convert.ToDouble(svendorPay.Split(',')[1].ToString())).ToString();
                        dGrossAmount = string.Format("{0:c0}", (Convert.ToDouble(sTimeStandard) * Convert.ToDouble(svendorPay.Split(',')[0].ToString())) + (Convert.ToDouble(overTimeDiff) * Convert.ToDouble(svendorPay.Split(',')[1].ToString())));
                        sTable = sTable + "<td>" + dGrossAmount + "</td>";
                        //<th>Volume Discount</th>
                        sTable = sTable + "<td>$0.00</td>";
                        //<th>Program Fee</th>
                        string ProgramFee = GetProgramFee(readerGetDetails["vendor_ID"].ToString());
                        sTable = sTable + "<td>" + "$" + (Convert.ToDouble(dGrossAmount.Replace("$", "")) * Convert.ToDouble(ProgramFee)) / Convert.ToDouble(100) + "</td>";
                        //Province State Tax
                        string sProvTax = GetStateProvinceTax(readerGetDetails["PROVINCE_STATE"].ToString());
                        //province Tax A
                        string sProvinceTaxA = sProvTax.Split(',')[1].ToString();
                        // <th>Tax Amount</th>
                        sTable = sTable + "<td>" + "$" + ((Convert.ToDouble(dGrossAmount.Replace("$", "")) * Convert.ToDouble(sProvinceTaxA)) / Convert.ToDouble(100)) + "</td>";
                        //<th>Net Supplier Payable</th>
                        sTable = sTable + "<td>" + "$" + (Convert.ToDouble(dGrossAmount.Replace("$", "")) + ((Convert.ToDouble(dGrossAmount.Replace("$", "")) * Convert.ToDouble(sProvinceTaxA)) / Convert.ToDouble(100))) + "</td>";
                        sTable = sTable + "<td>" + func.FixString(readerGetDetails["vendor_name"].ToString()) +  "</p></td> ";
                        sTable = sTable + "</tr>";

                    }

                }
                else
                {
                    sTable = sTable + "<tr>";
                    sTable = sTable + "<td>No Invoices at this time</td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";
                    sTable = sTable + "<td></td>";

                    sTable = sTable + "</tr>";
                }

                sTable = sTable + "</tbody>";
                readerGetDetails.Close();
                cmdGetDetails.Dispose();
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

    public string GetStateProvinceTax(string StateProvince)
    {
        string sTax = "0,0,0";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetTax = "select rate_type, province_rate, canada_rate from ovms_tax where province = '" + StateProvince + "' and country = 'CA'";
                SqlCommand cmdGetTax = new SqlCommand(strGetTax, conn);
                SqlDataReader readerGetTax = cmdGetTax.ExecuteReader();
                //string _svendorList = "";
                while (readerGetTax.Read())
                {
                    sTax = readerGetTax["rate_type"].ToString() + "," + (Convert.ToDouble(readerGetTax["province_rate"].ToString()) + Convert.ToDouble(readerGetTax["canada_rate"].ToString()));
                }
                //close
                readerGetTax.Close();
                cmdGetTax.Dispose();
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
        return sTax;

    }
    public string GetVendorPay(string Job_ID)
    {
        string vendorPay = "0,0,0";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetVendorPay = "select vender_pay_rate, vender_ot_pay_rate, vender_dt_pay_rate from ovms_job_accounting where job_id = " + Job_ID;
                SqlCommand cmdGetVendorPay = new SqlCommand(strGetVendorPay, conn);
                SqlDataReader readerVendorPay = cmdGetVendorPay.ExecuteReader();
                //string _svendorList = "";
                while (readerVendorPay.Read())
                {
                    vendorPay = readerVendorPay["vender_pay_rate"].ToString() + "," + readerVendorPay["vender_ot_pay_rate"].ToString() + "," + readerVendorPay["vender_dt_pay_rate"].ToString();
                }
                //close
                readerVendorPay.Close();
                cmdGetVendorPay.Dispose();
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
        return vendorPay;

    }
    public string GetStateProvinceOverTime(string StateProvince)
    {
        string overtime = "0";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetStateProvince_Overtime = "select state_overtime from ovms_state where state_code ='ON' ";
                SqlCommand cmdGetStateProvince_Overtime = new SqlCommand(strGetStateProvince_Overtime, conn);
                SqlDataReader readerStateProvince_Overtime = cmdGetStateProvince_Overtime.ExecuteReader();
                //string _svendorList = "";
                while (readerStateProvince_Overtime.Read())
                {
                    overtime = readerStateProvince_Overtime["state_overtime"].ToString();
                }
                //close
                readerStateProvince_Overtime.Close();
                cmdGetStateProvince_Overtime.Dispose();
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
        return overtime;

    }

    public string GetProgramFee(string vendorID)
    {
        string sVendorFee = "0";
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //getJobs
                string strGetProgramFee = "select program_fee from ovms_vendor_details where vendor_id = " + vendorID + "";
                SqlCommand cmdGetProgramFee = new SqlCommand(strGetProgramFee, conn);
                SqlDataReader readerGetProgramFee = cmdGetProgramFee.ExecuteReader();
                //string _svendorList = "";
                while (readerGetProgramFee.Read())
                {
                    sVendorFee = readerGetProgramFee["program_fee"].ToString();
                }
                //close
                readerGetProgramFee.Close();
                cmdGetProgramFee.Dispose();
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
        return sVendorFee;
    }
}