using System;
using System.Xml;

public partial class All_Messages_to_VENDOR : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
        {
        XmlDocument xmldoc = new XmlDocument();

        API.Service MessageList = new API.Service();
        xmldoc.LoadXml("<XML>" + MessageList.get_All_Messages_for_Vendor(Session["Email"].ToString(), Session["P@ss"].ToString(), Session["VendorID"].ToString()).InnerXml + "</XML>");

        XmlNodeList Response = xmldoc.SelectNodes("XML/RESPONSE/MESSAGE");
       string Actions1 = "";
        string IsRead = "";
        string subject = "";
        string PMO_Name = "";
        string Vendor_Name = "";
        string Date_PMO = "";
        string messid = "";
        string _messageID = "";
        string msg_id = "";
        string PMO_Message = "";
        string Date_Vendor = "";
        string Vendor_Message = "";
        string Actions = "";
        
        string subjectcheck = "";
        string line;
        string _lineRead = "";
        string previous_msgID = Request["id"];
        XmlDocument xmldoc1 = new XmlDocument();
        API.Service MessageList1 = new API.Service();
        for (int iResponse = 0; iResponse < Response.Count; iResponse++)
            {
            
            // string response = "";
            subject = Response[iResponse].SelectSingleNode("MESSAGE_SUBJECT").InnerText;
            messid = Response[iResponse].SelectSingleNode("MESSAGE_ID").InnerText;
            xmldoc1.LoadXml("<XML>" + MessageList1.get_Message(Session["Email"].ToString(), Session["P@ss"].ToString(), (messid), 1).InnerXml + "</XML>");
            Actions= Response[iResponse].SelectSingleNode("ACTIONS").InnerText;
            IsRead = Response[iResponse].SelectSingleNode("IS_READ").InnerText;
            XmlNodeList Response1 = xmldoc1.SelectNodes("XML/RESPONSE/MESSAGE");
            //if (Response[iResponse].SelectSingleNode("IS_READ").InnerText == "1")
            //    {
            //    IsRead = " Read";
            //    }
            //else
            //    {  
            //    IsRead = "UnRead";
            //    }
            for (int iResponse2 = 0; iResponse2 < Response1.Count; iResponse2++)
                {
                msg_id = Response1[iResponse2].SelectSingleNode("MESSAGE_ID").InnerText;
                PMO_Name = Response[iResponse].SelectSingleNode("PMO_NAME").InnerText;
                Vendor_Name = Response[iResponse].SelectSingleNode("VENDOR_NAME").InnerText;
                Date_Vendor = Response1[iResponse2].SelectSingleNode("DATE").InnerText;
                PMO_Message = Response[iResponse].SelectSingleNode("MESSAGE").InnerText;
                Date_PMO = Response[iResponse].SelectSingleNode("DATE").InnerText;
                Vendor_Message = Response1[iResponse2].SelectSingleNode("MESSAGE").InnerText;
                Actions1 = Response1[iResponse2].SelectSingleNode("ACTIONS").InnerText;
                IsRead=Response1[iResponse2].SelectSingleNode("ACTIONS").InnerText;
                System.IO.StreamReader file =
                new System.IO.StreamReader(Server.MapPath("Messagelist.html"));
                while ((line = file.ReadLine()) != null)
                    {
                    _lineRead = _lineRead.Replace("####MESSAGE_ID####", messid);
                    _lineRead = _lineRead.Replace("####SUBJECT####", subject);
                    _lineRead = _lineRead.Replace("####PMONAME####", PMO_Name);
                    _lineRead = _lineRead.Replace("####PMOMESSAGE####", PMO_Message);
                    _lineRead = _lineRead.Replace("####VENDORNAME####", Vendor_Name);
                    _lineRead = _lineRead.Replace("####PMO_DATE_AND_TIME####", Date_PMO);
                    _lineRead = _lineRead.Replace("####VENDOR_DATE_AND_TIME####", Date_Vendor);
                    _lineRead = _lineRead.Replace("####VENDOR_MESSAGE####", Vendor_Message);
                    _lineRead = _lineRead + line;
                    //counter++;
                    }
                file.Close();
                subjectcheck = subjectcheck + subject;
                
                }
            lblMessageList.Text = _lineRead;
            //_messageID = _messageID + msg_id;


            ///basically if m correct......its overwriting variables . .....hm ik mint may be actions as well
            // read line by lline for vendor compose messages only
            //if (Actions1 == "Send_V_P")
            //    {
            //    System.IO.StreamReader vfile =
            //  new System.IO.StreamReader(Server.MapPath("Vendor_Message.html"));
            //    while ((line = vfile.ReadLine()) != null)
            //        {
            //        _lineRead = _lineRead.Replace("####MESSAGE_ID####", msg_id);
            //        _lineRead = _lineRead.Replace("####SUBJECT####", subject);
            //        _lineRead = _lineRead.Replace("####VENDORNAME####", Vendor_Name);
            //        _lineRead = _lineRead.Replace("####VENDOR_DATE_AND_TIME####", Date_Vendor);
            //        _lineRead = _lineRead.Replace("####VENDOR_MESSAGE####", Vendor_Message);
            //        _lineRead = _lineRead + line;
            //        //counter++;
            //        }

            //    vfile.Close();

            //    //subjectcheck = subjectcheck + subject;
            //    lblMessageList.Text = _lineRead;
            //    }
            //////read line by lline for PMO New messages only
            //if (Actions == "Send_P_V")
            //    {
            //    System.IO.StreamReader pfile =
            //  new System.IO.StreamReader(Server.MapPath("PMO_Message.html"));
            //    while ((line = pfile.ReadLine()) != null)
            //        {
            //        _lineRead = _lineRead.Replace("####MESSAGE_ID####", messid);
            //        _lineRead = _lineRead.Replace("####SUBJECT####", subject);
            //        _lineRead = _lineRead.Replace("####PMONAME####", PMO_Name);
            //        _lineRead = _lineRead.Replace("####PMOMESSAGE####", PMO_Message);
            //        _lineRead = _lineRead.Replace("####PMO_DATE_AND_TIME####", Date_PMO);
            //        _lineRead = _lineRead + line;
            //        // counter++;
            //        }
            //    pfile.Close();
            //    lblMessageList.Text = _lineRead;
            //    subjectcheck = subjectcheck + subject;
            //    }
            }
        }
    }



