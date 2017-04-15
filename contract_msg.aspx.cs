using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class contract_msg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string empID= Request.Form["workerid"];
        int workerid = Int32.Parse(Request.Form["workerid"].Substring(Request.Form["workerid"].Length - 6));
        string msgs = Request.Form["txtComments"];
        string varMSG = "";
        
        if (msgs == "")
        {
            varMSG = "Hi PMO this message is regarding Contract Extension is required for "+empID+"";
        }
        else {
            varMSG = msgs;
        }
       
        API.Service contract = new API.Service();
        API.Service msg = new API.Service();
        XmlDocument _xmlDoc = new XmlDocument();

      _xmlDoc.LoadXml("<XML>" + msg.Send_Message_Vendor(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["UserID"].ToString(),"contract extension for: ", varMSG, Session["PMOID"].ToString(), Session["VendorID"].ToString(), Session["ClientID"].ToString(), workerid.ToString(), "Send_V_C").InnerXml + "</XML>");
      // _xmlDoc.LoadXml("<XML>" + msg.Send_Message_Vendor("greg@opusing.com", "1234", "14", "abc", "def", "4", "2", "1", "1", "Send_V_P").InnerXml + "</XML>");
        XmlNodeList r = _xmlDoc.SelectNodes("XML/RESPONSE");
        _xmlDoc.LoadXml("<XML>" + contract.ext_contract(Session["Email"].ToString(), Session["P@ss"].ToString(), workerid.ToString()).InnerXml + "</XML>");
        //_xmlDoc.LoadXml("<XML>" + contract.ext_contract("greg@opusing.com","1234", "1").InnerXml + "</XML>");
        XmlNodeList ra = _xmlDoc.SelectNodes("XML/RESPONSE");

        Response.Redirect("view_worker.aspx?wopen=Y&p=VW");

    }

    protected void btnCancelEmail_Click(object sender, EventArgs e)
    {
       // Response.Redirect("View_worker.aspx");
    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {

       
    }
       
    }

    