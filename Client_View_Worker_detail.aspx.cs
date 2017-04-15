using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Client_View_Worker_detail : System.Web.UI.Page
{
    SqlConnection conn;
    string jobid_feed;
    private int iResponse;
    StringFunctions func = new StringFunctions();
    private int intCount1;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Email"] == null)
        {
            //logout
            Session.Abandon();
            HttpContext.Current.Response.Redirect("Login.aspx?m=You+have+logged+out");
            HttpContext.Current.Response.End();
        }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["reply"] != null)
            {
                
                string empid_url2 = Request["empid"];
                int empid_url3 = Int32.Parse(Request["empid"].Substring(Request["empid"].Length - 6));

                API.Service getWorker = new API.Service();
              //  API.Service getWorker = new API.Service();
                XmlDocument dom3 = new XmlDocument();
                dom3.LoadXml("<XML>" + getWorker.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), empid_url3.ToString(), Session["VendorID"].ToString(), Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
                XmlNodeList Response4 = dom3.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
                lblname.Text = func.FixString(Response4[iResponse].SelectSingleNode("FIRSTNAME").InnerText) + " " + func.FixString(Response4[iResponse].SelectSingleNode("LASTNAME").InnerText);
                jobid_feed = Response4[iResponse].SelectSingleNode("JOB_ID").InnerText;
            }
        }
        string empid_url = Request["empid"];
        int empid_url1 = Int32.Parse(Request["empid"].Substring(Request["empid"].Length - 6));

        API.Service getWorkers = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + getWorkers.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), empid_url1.ToString(), "", Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
       // lblprofile.Text = Response[iResponse].SelectSingleNode("PROFILE_PICTURE_PATH").InnerText;
        lblfirst.Text = func.FixString(Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText);
        lblmiddle.Text = func.FixString(Response[iResponse].SelectSingleNode("MIDDLE_NAME").InnerText);
        lbllast.Text = func.FixString(Response[iResponse].SelectSingleNode("LASTNAME").InnerText);
        lblemail.Text = Response[iResponse].SelectSingleNode("EMAIL").InnerText;
        lblphone.Text = Response[iResponse].SelectSingleNode("PHONE").InnerText;
        lbldob.Text = Response[iResponse].SelectSingleNode("DATE_OF_BIRTH").InnerText;
        lblsuite.Text = Response[iResponse].SelectSingleNode("SUITE_NO").InnerText;
        lbladdress.Text = func.FixString(Response[iResponse].SelectSingleNode("ADDRESS1").InnerText);
        lblcity.Text = func.FixString(Response[iResponse].SelectSingleNode("LOCATION").InnerText);
        lblprovince.Text = func.FixString(Response[iResponse].SelectSingleNode("PROVINCE").InnerText);
     //   lblcountry.Text = func.FixString(Response[iResponse].SelectSingleNode("COUNTRY").InnerText);
        lblpostal.Text = Response[iResponse].SelectSingleNode("POSTAL").InnerText;
        lblcomment.Text = func.FixString(Response[iResponse].SelectSingleNode("COMMENTS").InnerText);
        lblavailable.Text = Response[iResponse].SelectSingleNode("AVAILABILITY_FOR_INTERVIEW").InnerText;
        lblskype.Text = Response[iResponse].SelectSingleNode("SKYPE").InnerText;
        lbllicence.Text = Response[iResponse].SelectSingleNode("LICENCE_NO").InnerText;
        lbllastsin.Text = Response[iResponse].SelectSingleNode("LAST_4_DIGITS_OF_SSN_SIN").InnerText;
        lblpay.Text = Response[iResponse].SelectSingleNode("PAY_RATE").InnerText;
        lbljob.Text = func.FixString(Response[iResponse].SelectSingleNode("JOB_TITLE").InnerText + "-" + Response[iResponse].SelectSingleNode("JOB_ID").InnerText);
        string jobid2 = Response[iResponse].SelectSingleNode("JOB_ID").InnerText;
        Label1.Text = Response[iResponse].SelectSingleNode("PAY_RATE").InnerText;

        API.Service web1 = new API.Service();
        // API.Service web1 = new API.Service();
        XmlDocument dom2 = new XmlDocument();
        //string strID = Request.QueryString["ID"];
        dom2.LoadXml("<XML>" + web1.get_Jobs(jobid2, Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), Session["UserID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response8 = dom2.SelectNodes("XML/RESPONSE/JOBS ");

        lblnoofopning.Text = Response8[iResponse].SelectSingleNode("NO_OF_OPENINGS").InnerText;
        lblstartdate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_START_DATE").InnerText).ToString("dd MMM, yyyy");

        lblenddate.Text = DateTime.Parse(Response8[iResponse].SelectSingleNode("CONTRACT_END_DATE").InnerText).ToString("dd MMM, yyyy");
        lblUrgent.Text = Response8[iResponse].SelectSingleNode("URGENT").InnerText;
        lbljobtitle.Text = Response8[iResponse].SelectSingleNode("JOB_TITLE").InnerText;
        string z = Response8[iResponse].SelectSingleNode("STD_PAY_RATE").InnerText;
        if (z == "0")
        {
            x.Visible = false;
            y.Visible = true;
            lbllocation2.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
            lblbill.Text = Response8[iResponse].SelectSingleNode("STD_BILL_RATE").InnerText;
        }
        else
        {
            y.Visible = false;
            x.Visible = true;
            lblpay.Text = Response8[iResponse].SelectSingleNode("STD_PAY_RATE").InnerText;
            lbllocation.Text = Response8[iResponse].SelectSingleNode("JOB_LOCATION").InnerText;
        }
        if (lblUrgent.Text == "1")
        {
            lblUrgent.Text = "(Urgent Request)";
        }
        else
        {
            lblUrgent.Text = "";
        }
        dom2.LoadXml("<XML>" + web1.get_jobrating(Session["Email"].ToString(), Session["P@ss"].ToString(), jobid2).InnerXml + "</XML>");
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
        string emprating1 = "";
        string emprating2 = "";
        string emprating3 = "";
        string emprating4 = "";
        string emprating5 = "";
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

            dom2.LoadXml("<XML>" + web1.get_emprating(Session["Email"].ToString(), Session["P@ss"].ToString(), empid_url1.ToString()).InnerXml + "</XML>");
            XmlNodeList Response33 = dom2.SelectNodes("XML/RESPONSE/QUESTIONS_NO ");


            try
            {
                //que1 = Server.HtmlDecode(Response3[intCount1].SelectSingleNode("QUESTION1").InnerText);
                emprating1 = Response33[iResponse].SelectSingleNode("RATING1").InnerText;
                emprating2 = Response33[iResponse].SelectSingleNode("RATING2").InnerText;
                emprating3 = Response33[iResponse].SelectSingleNode("RATING3").InnerText;
                emprating4 = Response33[iResponse].SelectSingleNode("RATING4").InnerText;
                emprating5 = Response33[iResponse].SelectSingleNode("RATING5").InnerText;


            }
            catch (Exception ex)
            {
                //nothing
                //que1 = "";
            }


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
        txtemprat1.Text = emprating1;
        txtemprat2.Text = emprating2;
        txtemprat3.Text = emprating3;
        txtemprat4.Text = emprating4;
        txtemprat5.Text = emprating5;
      
        // dom1.LoadXml("<XML>" + getWorkers.get_resume(Session["Email"].ToString(), Session["P@ss"].ToString(), empid_url1.ToString(), "").InnerXml + "</XML>");
        //try
        //{
        //    XmlNodeList Response2 = dom1.SelectNodes("XML/RESPONSE/RESUME_ID");
        //    lblresume.Text = Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText;
        //}
        //catch (Exception ex)
        //{
        //    lblresume.Text = "";
        //}


        dom1.LoadXml("<XML>" + getWorkers.get_resume(Session["Email"].ToString(), Session["P@ss"].ToString(), empid_url1.ToString(), "").InnerXml + "</XML>");
        try
        {
            XmlNodeList Response2 = dom1.SelectNodes("XML/RESPONSE/RESUME_ID");
            string resume = Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText;
            //  string resume = Response1[iResponse2].SelectSingleNode("RESUME_PATH").InnerText;
            string resuepath = Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText.Substring(Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText.IndexOf("Resume\\"), Convert.ToInt32(Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText.Length) - Convert.ToInt32(Response2[iResponse].SelectSingleNode("RESUME_PATH").InnerText.IndexOf("Resume\\"))).Replace("\\", "//").ToString();
            lblresume.Text = "<a href = 'http://www.flentispro.com/" + resuepath.Replace("//", "/") + "'> Resume </a>";

        }
        catch (Exception ex)
        {
            lblresume.Text = "";
        }


        API.Service jobInfo2 = new API.Service();
        XmlDocument xmldoc11 = new XmlDocument();

        string sTable9 = "<tbody>";
        xmldoc11.LoadXml("<XML>" + jobInfo2.get_name_leave_request(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString(), empid_url1.ToString(), "", Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response9 = xmldoc11.SelectNodes("XML/RESPONSE/NAME");
        sTable9 = "";
        int CountRows9 = 1;
        int intCount9 = 0;
        for (intCount9 = 0; intCount9 < Response9.Count; intCount9++)
        {
            sTable9 = sTable9 + "<tr>";
            //  sTable9 = sTable9 + "<td>" + func.FixString(Response9[intCount9].SelectSingleNode("FIRST_NAME").InnerText + " " + Response9[intCount9].SelectSingleNode("LAST_NAME").InnerText) + "</td>";
            sTable9 = sTable9 + "<td>" + DateTime.Parse(Response9[intCount9].SelectSingleNode("REQUESTED_DATE").InnerText).ToString("dd MMM, yyyy") + " </td> ";
            sTable9 = sTable9 + "<td>" + func.FixString(Response9[intCount9].SelectSingleNode("REQUESTED_REASON").InnerText) + "</td> ";
            sTable9 = sTable9 + "<td>" + func.FixString(Response9[intCount9].SelectSingleNode("REQUESTED_COMMENTS").InnerText) + "</td> ";
            string status = Response9[intCount9].SelectSingleNode("ACTION").InnerText;
            if (status == "2")
            {
                sTable9 = sTable9 + "<td> Not approved</td>";
                // sTable9 = sTable9 + "<td>Absence Request Not approved</td>";
            }
            if (status == "1")
            {
                sTable9 = sTable9 + "<td> Approved</td>";
                // sTable9 = sTable9 + "<td>Absence Request Not approved</td>";
            }
            if (status == "0")
            {
                sTable9 = sTable9 + "<td> Rejected</td>";
                // sTable9 = sTable9 + "<td>Absence Request Not approved</td>";
            }
            sTable9 = sTable9 + "</tr>";
            CountRows9++;
        }
        if (Response9.Count == 0)
        {
            sTable9 = sTable9 + "<td colspan=4>" + "There are no Absence Requests at this time." + "</td> ";
            sTable9 = sTable9 + "</tr>";
        }
        sTable9 = sTable9 + "</tbody>";
        jobInfo2.Dispose();
        lblrequestleave.Text = sTable9;

        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        try
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();


                //start, end and weeks
                string sqlGetChat = " select feeedback_id, v_comments, v_create_date, c_comments, c_create_date from ovms_candidate_feedback " +
                                    " where client_id =  " + Session["ClientID"].ToString()+
                                    " and vendor_id =  " + Session["VendorID"].ToString()+
                                    " and emplyee_id = " + empid_url1+
                                    " order by feeedback_id asc";
                SqlCommand cmdGetChat = new SqlCommand(sqlGetChat, conn);
                SqlDataReader rsGetChat = cmdGetChat.ExecuteReader();
                //string _svendorList = "";
                string sMessages = "";
                while (rsGetChat.Read())
                {
                    sMessages = sMessages + "<tr>" +
                                            " <td width='50%' class='pull-left' style='color:blue'> " +
                                            " " + rsGetChat["v_comments"].ToString() + " " +
                                            " on" +
                                            " " + rsGetChat["v_create_date"].ToString() + "  " +
                                            " </td>" +
                                            " <td class='pull-right'></td>" +
                                            " </tr>" +
                                            " <tr>" +
                                            " <td></td>" +
                                            " <td style='color:red'>" +
                                            " " + rsGetChat["c_comments"].ToString() + " " +
                                            " " + rsGetChat["c_create_date"].ToString() + "";
                                            if ((rsGetChat["c_comments"].ToString() == "") || (rsGetChat["c_comments"] == null))
                                            {
                                                    
                                              //string empid_url = Request["empid"];
                                              //int empid_url1 = Int32.Parse(Request["empid"].Substring(Request["empid"].Length - 6));
    
                                              //    Response.Redirect("Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + empid_url + "&reply=y");
                                                sMessages = sMessages + "<a  class='btn btn-success' href='Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + empid_url + "&reply=y'><i class='fa fa-check - circle' ></i> Reply</a>";
                                            }
                        //<asp:Button ID='btnreplyc' ValidationGroup='n' runat='server'  OnClick='btnreplyc_Click1' Text='Reply' CssClass='form-control' />
                                     sMessages = sMessages + " </td>" +
                                            " </tr>";

                }
                //close
                rsGetChat.Close();
                cmdGetChat.Dispose();
                lblMessagesBackForth.Text = sMessages;
                //rsStartEndWeeks.Close();
                //cmdStartEndWeeks.Dispose();
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

        // ////vendor request
        // API.Service vendoreq = new API.Service();
        //// API.Service jobInfo2 = new API.Service();
        // XmlDocument xmldoc5 = new XmlDocument();
        //' lblcreply.Visible = false;
        //// btnreplyc.Visible = true;
        //xmldoc11.LoadXml("<XML>" + vendoreq.get_v_feedback(Session["Email"].ToString(), Session["P@ss"].ToString(), "", empid_url1.ToString(), "",Session["VendorID"].ToString(),  Session["ClientID"].ToString()).InnerXml + "</XML>");
        // XmlNodeList Response5 = xmldoc11.SelectNodes("XML/RESPONSE/FEEDBACK");


        // 'lblvendorcomments.Text = Response5[iResponse].SelectSingleNode("V_COMMENTS").InnerText;
        // 'lbldate.Text= DateTime.Parse(Response5[iResponse].SelectSingleNode("V_CREATE_DATE").InnerText).ToString("dd MMM, yyyy");

        // 'lblcreply.Text=  Response5[iResponse].SelectSingleNode("C_COMMENTS").InnerText;

        // if (lblcreply.Text!="")
        // {
        //     lblcreply.Visible = true;
        //     btnreplyc.Visible = false;
        //     lbldatec.Text = " on " + DateTime.Parse(Response5[iResponse].SelectSingleNode("C_CREATE_DATE").InnerText).ToString("dd MMM, yyyy");
        // }

        //     vendoreq.Dispose();

    }


    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Client_View_Worker.aspx?wopen=Y&p=VW");
    }

  
    protected void btnsend_Click(object sender, EventArgs e)
    {

        ///get job_id using employyee_id
       
        string empid_url = Request["empid"];
        int empid_url1 = Int32.Parse(Request["empid"].Substring(Request["empid"].Length - 6));
        // API.Service setfeedback = new API.Service();
        API.Service setfeedback = new API.Service();
        XmlDocument dom1 = new XmlDocument();
        dom1.LoadXml("<XML>" + setfeedback.get_employees(Session["Email"].ToString(), Session["P@ss"].ToString(), empid_url1.ToString(), Session["VendorID"].ToString(), Session["ClientID"].ToString(), "", "", "1", "").InnerXml + "</XML>");
        XmlNodeList Response = dom1.SelectNodes("XML/RESPONSE/EMPLOYEE_NAME_ID");
        // lblname.Text = func.FixString(Response[iResponse].SelectSingleNode("FIRSTNAME").InnerText) + " " + func.FixString(Response[iResponse].SelectSingleNode("LASTNAME").InnerText);
        jobid_feed = Response[iResponse].SelectSingleNode("JOB_ID").InnerText;



        ///get feedback id  using employyee_id,jobid,client id,vendor id

        dom1.LoadXml("<XML>" + setfeedback.get_v_feedback(Session["Email"].ToString(), Session["P@ss"].ToString(), "", empid_url1.ToString(), "", Session["VendorID"].ToString(), Session["ClientID"].ToString()).InnerXml + "</XML>");
        XmlNodeList Response5 = dom1.SelectNodes("XML/RESPONSE/FEEDBACK");
        string feedback_id = Response5[iResponse].SelectSingleNode("FEEEDBACK_ID").InnerText;


        /// insert comment in to table
       
        dom1.LoadXml("<XML>" + setfeedback.insert_c_comments_feedback(Session["Email"].ToString(), Session["P@ss"].ToString(),jobid_feed, txtfeedcomment.Text, empid_url1.ToString(), Session["VendorID"].ToString(), Session["ClientID"].ToString(), feedback_id).InnerXml + "</XML>");
        XmlNodeList Response2 = dom1.SelectNodes("XML/RESPONSE");
        if (Response2.Item(0).SelectSingleNode("STATUS").InnerText =="1")
        {
            HttpContext.Current.Response.Redirect("C_View_Candidate.aspx?wopen=Y&p=VW&empid=" + empid_url);
        }
    }



    //protected void btnreply_Click(object sender, EventArgs e)
    //{
    //    string empid_url = Request["empid"];
    //    int empid_url1 = Int32.Parse(Request["empid"].Substring(Request["empid"].Length - 6));

    //    Response.Redirect("Client_View_Worker.aspx?wopen=Y&p=VW&empid=" + empid_url + "reply=y");
    //}

    //protected void btnreplyc_Click(object sender, EventArgs e)
    //{
    //    string empid_url = Request["empid"];
    //    int empid_url1 = Int32.Parse(Request["empid"].Substring(Request["empid"].Length - 6));

    //    Response.Redirect("Client_View_Worker.aspx?wopen=Y&p=VW&empid=" + empid_url + "reply=y");
    //}

    //protected void btnreplyc_Click1(object sender, EventArgs e)
    //{
    //    string empid_url = Request["empid"];
    //    int empid_url1 = Int32.Parse(Request["empid"].Substring(Request["empid"].Length - 6));

    //    Response.Redirect("Client_View_Worker_detail.aspx?wopen=Y&p=VW&empid=" + empid_url + "&reply=y");
    //}

    //protected void btntestin123_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Client_View_Worker.aspx?wopen=Y&p=VW&empid=44444444");
    //}
}
