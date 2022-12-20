using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Text;
using System.Linq;

using System.Security.Cryptography;

namespace Yuan.DA
{
    public class GlobalFunctions
    {
        public GlobalFunctions()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static bool chkAdminLogin(string strUserName, string strPassword)
        {
            bool result = false;

            //string sqlQry = "select tblUser.*, tblLevel.LevelName from tblUser inner join tblLevel on tblUser.LevelID = tblLevel.LevelID where (UserName=@UserName and Password=@Password) and tblUser.Active = 1 ";

            string sqlQry = "select Users.*,Levels.LevelName" +
                            " from Users inner join Levels on Users.LevelID = Levels.LevelID " +
                            //" inner join StaffDetails s on s.StaffID = Users.StaffID" +
                            //inner join Company c on s.CompanyID = c.CompanyID"                             
                            " where (UName = @UserName and Pass = @Password) ";

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            param[0].Value = strUserName;

            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            param[1].Value = strPassword;

            SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sqlQry, param);
            while (dr.Read())
            {
                HttpContext.Current.Session["UserID"] = dr["UserID"].ToString();
                HttpContext.Current.Session["UName"] = dr["UName"].ToString().Trim();
                HttpContext.Current.Session["UserType"] = dr["UType"].ToString().Trim();
                HttpContext.Current.Session["UserRole"] = dr["LevelName"].ToString().Trim();
                //HttpContext.Current.Session["CompanyId"] = dr["CompanyID"].ToString().Trim();
                result = true;
            }
            dr.Close();

            if (result == true)
            {
                SqlParameter[] param1 = new SqlParameter[3];

                string Query = @"UPDATE Users SET LastLoggedIn = GETDATE() WHERE UserID = @UserID AND (UName=@UserName and Pass=@Password)";

                param1[0] = new SqlParameter("@UserID", SqlDbType.NVarChar, 50);
                param1[0].Value = HttpContext.Current.Session["UserID"].ToString();

                param1[1] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                param1[1].Value = strUserName;

                param1[2] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                param1[2].Value = strPassword;

                DataAccessor.ExecuteQuery(Query, param1);

            }

            return result;
        }
        public static void SendRegEmail(string stUserEmail, string strUserMobile, string strUserPass)
        {
            string strSubject = "Successful registration on the Uchumi Debt Service Portal";

            string strBody = "";
            strBody += "<table style='width:800px;font-family:Arial;font-size:12px;background: url(images/white-back.jpg)'>";
            strBody += "<tr> ";
            //strBody += "<td style='padding:10px;text-align:center'><img src='" + ConfigurationManager.AppSettings["HostingUrl"].ToString() + "/images/DentalFriend_logo.png' /></td> ";
            strBody += "</tr>";
            strBody += "<tr style='background-color:#fff'>";
            strBody += "<td style='padding:20px;'>";
            strBody += "Dear Valued Vendor,<br><br>";
            strBody += "We are pleased to inform you that your registration on our portal  " + ConfigurationManager.AppSettings["DomainName"].ToString() + " has been successful.<br><br>";
            strBody += "Please note your login credentials:<br><br>";
            strBody += "<ol style='margin:0px;padding-left:15px;'>";
            strBody += "<li>Username : " + strUserMobile + "<br></li>";
            strBody += "<li>Password : " + strUserPass + "</li>";
            strBody += "</ol>";
            strBody += "<br><br>";
            strBody += "For any doubt, please write back to us on support@" + ConfigurationManager.AppSettings["DomainName"].ToString() + " and we will get back to you in the shortest possible time.";
            strBody += "<br /><br />";
            strBody += "Thanks and regards,<br /><br />";
            strBody += "Team Uchumi<br />";
            strBody += "</td>";
            strBody += "</tr>";
            strBody += "<tr style='background-color:#ede4e9;'>";
            strBody += "<td style='padding:5px 5px 5px 5px;text-align:center;'><a href='http://www." + ConfigurationManager.AppSettings["DomainName"].ToString() + "' target='_blank' style='color:black;'>www." + ConfigurationManager.AppSettings["DomainName"].ToString() + "</a></td>";
            strBody += "</tr>";
            strBody += "</table>";

            GeneralFunctions._SendMail(stUserEmail, "support@" + ConfigurationManager.AppSettings["DomainName"].ToString(), "Administrator - " + ConfigurationManager.AppSettings["DomainName"].ToString(), strSubject, strBody, "", "support@" + ConfigurationManager.AppSettings["DomainName"].ToString());

        }

        public static void SendContactUsInfo(string name, string email, string phone, string message)
        {
            string strSubject = "Enquiry from website";

            string strBody = "";
            strBody += "<table style='width:800px;font-family:Arial;font-size:12px;'>";
            strBody += "<tr style='background-color:#221f6d;'> ";
            strBody += "<td style='padding:10px;'><img src='http://www.echofeel.com/rajanivivah/images/logo.png' style='width:200px;' /></td> ";
            strBody += "</tr>";
            strBody += "<tr>";
            strBody += "<td style='padding:20px;'>";
            strBody += "Dear Sir/Madam,<br><br>";
            strBody += "Enquiry details from website.<br><br>";
            strBody += "<ol style='margin:0px;padding-left:15px;'>";
            strBody += "<li>Name : " + name + "</li>";
            strBody += "<li>Email : " + email + "</li>";
            strBody += "<li>Phone : " + phone + "</li>";
            strBody += "<li>Message : " + message + "</li>";
            strBody += "</ol>";
            strBody += "<br><br>";
            strBody += "</td>";
            strBody += "</tr>";
            strBody += "<tr style='background-color:#221f6d;'>";
            strBody += "<td style='padding:5px 15px 5px 5px;text-align:right;'><a href='http://www.rajanivivah.com' target='_blank' style='color:white;'>www.rajanivivah.com</a></td>";
            strBody += "</tr>";
            strBody += "</table>";

            GeneralFunctions._SendMail("prakashbgada@gmail.com", email, "Administrator - rajanivivah.com", strSubject, strBody, "", "");

        }

        public static void SendNewsLetter(string email)
        {
            string strSubject = "Newsletter subscription from website";

            string strBody = "";
            strBody += "<table style='width:800px;font-family:Arial;font-size:12px;'>";
            strBody += "<tr style='background-color:#221f6d;'> ";
            strBody += "<td style='padding:10px;'><img src='http://www.echofeel.com/rajanivivah/images/logo.png' style='width:200px;' /></td> ";
            strBody += "</tr>";
            strBody += "<tr>";
            strBody += "<td style='padding:20px;'>";
            strBody += "Dear Sir/Madam,<br><br>";
            strBody += "News Letter subscription from website.<br><br>";
            strBody += "<ol style='margin:0px;padding-left:15px;'>";
            strBody += "<li>Email : " + email + "</li>";
            strBody += "</ol>";
            strBody += "<br><br>";
            strBody += "</td>";
            strBody += "</tr>";
            strBody += "<tr style='background-color:#221f6d;'>";
            strBody += "<td style='padding:5px 15px 5px 5px;text-align:right;'><a href='http://www.rajanivivah.com' target='_blank' style='color:white;'>www.rajanivivah.com</a></td>";
            strBody += "</tr>";
            strBody += "</table>";

            GeneralFunctions._SendMail("prakashbgada@gmail.com", email, "Administrator - rajanivivah.com", strSubject, strBody, "", "");

        }

        public static void sendSMS(string MobileNo, string MSG)
        {
            //string url = "http://login.redsms.in/API/SendMessage.ashx?user=c2create&password=create207&type=t&senderid=CTCCRM&phone=";
            string url = "http://login.redsms.in/API/SendMessage.ashx?user=focusdental&password=focus334&type=t&senderid=FOCUSD&phone=";
            string smsUrl = url + MobileNo + "&text=Dental Friend - " + GeneralFunctions.RemoveReservedCharacters(MSG);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(smsUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream(), true);

            string returnMsg = string.Empty;

            try
            {
                returnMsg = streamReader.ReadToEnd();
            }
            finally
            {
                streamReader.Close();
            }
        }

        public static string GenerateRandomNo()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            characters += alphabets + small_alphabets + numbers;
            int length = 10;

            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }

            return otp;
        }

        public static bool sendSMS(string MobileNo, string Msg, string SmsType)
        {
            bool result = false;
            try
            {
                WebClient client = new WebClient();
                string baseurl = "http://bulksmsmumbai.mobi/sendurlcomma.aspx?user=20087877&pwd=dddirn&senderid=Colgit&mobileno=" + MobileNo + "&msgtext=" + Msg + "&smstype=" + SmsType;
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

    }
}