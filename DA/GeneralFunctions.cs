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
    public class GeneralFunctions
    {
        public GeneralFunctions()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static byte[] _ImageResize(int MaxSideSize, int MaxHeightSize, Stream Buffer, string fileName, string filePath)
        {
            byte[] byteArray = null;  // really make this an error gif 

            try
            {

                Bitmap bitMap = new Bitmap(Buffer);
                int intOldWidth = bitMap.Width;
                int intOldHeight = bitMap.Height;

                decimal lnRatio;
                int intNewWidth = 0;
                int intNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
                if (intOldWidth < MaxSideSize && intOldHeight < MaxHeightSize)
                {
                    intNewWidth = MaxSideSize;
                    intNewHeight = MaxHeightSize;
                }

                if (intOldWidth > intOldHeight)
                {
                    lnRatio = (decimal)MaxSideSize / intOldWidth;
                    intNewWidth = MaxSideSize;
                    decimal lnTemp = intOldHeight * lnRatio;
                    intNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)MaxHeightSize / intOldHeight;
                    intNewHeight = MaxHeightSize;
                    decimal lnTemp = intOldWidth * lnRatio;
                    intNewWidth = (int)lnTemp;
                }

                Size ThumbNailSize = new Size(intNewWidth, intNewHeight);
                System.Drawing.Image oImg = System.Drawing.Image.FromStream(Buffer);
                System.Drawing.Image oThumbNail = new Bitmap(ThumbNailSize.Width, ThumbNailSize.Height);

                Graphics oGraphic = Graphics.FromImage(oThumbNail);
                oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Rectangle oRectangle = new Rectangle
                    (0, 0, ThumbNailSize.Width, ThumbNailSize.Height);

                oGraphic.DrawImage(oImg, oRectangle);

                //Save File
                string newFileName = string.Format(System.Web.HttpContext.Current.Server.MapPath("~/{0}/{1}.jpg"), filePath, fileName);
                oThumbNail.Save(newFileName, ImageFormat.Jpeg);

                MemoryStream ms = new MemoryStream();
                oThumbNail.Save(ms, ImageFormat.Jpeg);
                byteArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

                oGraphic.Dispose();
                oImg.Dispose();
                ms.Close();
                ms.Dispose();
            }
            catch (Exception ex)
            {
                int newSize = MaxSideSize - 20;
                Bitmap bitMap = new Bitmap(newSize, newSize);
                Graphics g = Graphics.FromImage(bitMap);
                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, newSize, newSize));

                Font font = new Font("Courier", 8);
                SolidBrush solidBrush = new SolidBrush(Color.Red);
                g.DrawString("Failed To Save File or Failed File", font, solidBrush, 10, 5);
                g.DrawString(fileName, font, solidBrush, 10, 50);

                MemoryStream ms = new MemoryStream();
                bitMap.Save(ms, ImageFormat.Jpeg);
                byteArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

                ms.Close();
                ms.Dispose();
                bitMap.Dispose();
                solidBrush.Dispose();
                g.Dispose();
                font.Dispose();

            }
            return byteArray;
        }

        /// <summary>
        /// Attachments seperate with "|" seperator
        /// CCIDs seperate with "|" seperator
        /// </summary>   
        public static void _SendMail(string ToId, string FromId, string FromFullName, string Subject, string Message, string attachment, string CCIDs)
        {
            NetworkCredential logininfo = new NetworkCredential("parag@echofeel.com", "007WorldOne#12");
            //NetworkCredential logininfo = new NetworkCredential("noreply@hrfleek.com", "}n=j7]6+AO2?");
            //NetworkCredential logininfo = new NetworkCredential("smtprelays20@gmail.com", "007WorldOne#12");

            System.Net.Mail.MailMessage msgmail = new System.Net.Mail.MailMessage();

            msgmail.From = new MailAddress(FromId, FromFullName);
            msgmail.To.Add(new MailAddress(ToId));

            if (CCIDs.Trim() != "")
            {
                string[] cc = CCIDs.Split('|');

                for (int i = 0; i < cc.Length; i++)
                {
                    if (cc[i].ToString().Trim() != "")
                        msgmail.CC.Add(new MailAddress(cc[i].ToString().Trim()));
                }
            }

            msgmail.Subject = Subject;
            msgmail.Body = Message;
            msgmail.IsBodyHtml = true;

            if (attachment.Trim() != "")
            {
                string[] s1 = attachment.Split('|');

                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i].ToString().Trim() != "")
                        msgmail.Attachments.Add(new Attachment(s1[i].ToString().Trim()));
                }
            }

            SmtpClient client = new SmtpClient("monthly.smtp.com", 80);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = logininfo;
            client.Send(msgmail);
        }


        public static string _TruncateString(string input, int charaterlimit)
        {
            int characterLimit = charaterlimit;
            string output = input;

            // Check if the string is longer than the allowed amount
            // otherwise do nothing
            if (output.Length > characterLimit && characterLimit > 0)
            {
                // cut the string down to the maximum number of characters
                output = output.Substring(0, characterLimit);
                // Check if the character right after the truncate point was a space
                // if not, we are in the middle of a word and need to remove the rest of it
                if (input.Substring(output.Length, 1) != " ")
                {
                    int LastSpace = output.LastIndexOf(" ");

                    // if we found a space then, cut back to that space
                    if (LastSpace != -1)
                    {
                        output = output.Substring(0, LastSpace);
                    }
                }
                // Finally, add the "..."
                output += "...";
            }
            return output;
        }

        public static string _FormatAmount(string input)
        {
            string output = "0.00";

            try
            {
                double d = double.Parse(input);

                if (!((d % 1) == 0))
                {
                    output = string.Format("{0:#0.00}", double.Parse(input));
                }
                else
                {
                    output = string.Format("{0:#0}", double.Parse(input));
                }
            }
            catch
            {
                output = "0.00";
            }

            return output;
        }

        public static string _FormatAmountComma(string input)
        {
            string output = "0.00";

            double buffNumber = 0;
            if (double.TryParse(input, out buffNumber))
            {
                output = double.Parse(input).ToString("#,#0.00");
            }
            else
                output = "0.00";

            return output;
        }

        /// <summary>
        /// input type (DD/MM/YYYY OR DD-MM-YYYY) Output (10 Jun, 2010)
        /// </summary>    
        public static string _FormatDate(string input)
        {
            if (input != "")
            {
                if (input.Contains("/"))
                {
                    string[] r = input.Split('/');
                    string dt = r[0] + " " + GetMonthName(r[1]) + ", " + r[2];
                    return dt;
                }
                if (input.Contains("-"))
                {
                    string[] r = input.Split('-');
                    return r[0] + " " + GetMonthName(r[1]) + ", " + r[2];
                }
                else
                    return "";

            }
            else
                return "";
        }

        /// <summary>
        /// input type (YYYY-MM-dd OR yyyy/MM/dd) Output (10 Jun, 2010)
        /// </summary>    
        public static string _FormatDateNew(string input)
        {
            if (input != "")
            {
                if (input.Contains("/"))
                {
                    string[] r = input.Split('/');
                    string dt = r[2] + " " + GetMonthName(r[1]) + ", " + r[0];
                    return dt;
                }
                if (input.Contains("-"))
                {
                    string[] r = input.Split('-');
                    return r[2] + " " + GetMonthName(r[1]) + ", " + r[0];
                }
                else
                    return "";

            }
            else
                return "";
        }

        public static string GetMonthName(string dtmonth)
        {
            string result = "";

            if (dtmonth == "01" || dtmonth == "1")
                result = "Jan";
            if (dtmonth == "02" || dtmonth == "2")
                result = "Feb";
            if (dtmonth == "03" || dtmonth == "3")
                result = "Mar";
            if (dtmonth == "04" || dtmonth == "4")
                result = "Apr";
            if (dtmonth == "05" || dtmonth == "5")
                result = "May";
            if (dtmonth == "06" || dtmonth == "6")
                result = "Jun";
            if (dtmonth == "07" || dtmonth == "7")
                result = "Jul";
            if (dtmonth == "08" || dtmonth == "8")
                result = "Aug";
            if (dtmonth == "09" || dtmonth == "9")
                result = "Sep";
            if (dtmonth == "10")
                result = "Oct";
            if (dtmonth == "11")
                result = "Nov";
            if (dtmonth == "12")
                result = "Dec";

            return result;
        }

        public static void _FillDropDown(string qry, string textfield, string valuefield, string defaultsel, string defaultval, DropDownList ddl, params SqlParameter[] arrParam)
        {
            if (defaultsel != "")
            {
                ListItem li = new ListItem(defaultsel, defaultval);
                ddl.Items.Add(li);
            }

            SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(qry, arrParam);
            while (dr.Read())
            {
                ListItem li1 = new ListItem(dr[textfield].ToString(), dr[valuefield].ToString());
                ddl.Items.Add(li1);
            }
            dr.Close();
        }

        /// <summary>
        /// input type filename with path EX "mywebsite/images/test.jpg"    
        /// </summary>    
        public static void _DeleteFile(string filename)
        {
            if (filename.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        public static double _parseStringToDouble(string value)
        {
            double result = 0;
            double.TryParse(value, out result);
            return result;
        }

        public static Int32 _parseStringToInt(string value)
        {
            Int32 result = 0;
            Int32.TryParse(value, out result);
            return result;
        }

        public static decimal _parseStringToDecimal(string value)
        {
            decimal result = 0.00M;

            try
            {
                result = decimal.Parse(value);
            }
            catch
            {
            }

            return result;
        }


        public static string _GenerateNewStringID(string initialCharacter, string columnName, string substringStartIndex, string substringEndIndex, string tableName)
        {
            string NewId = "";

            string strQry = "Select '" + initialCharacter + "' + CAST(ISNULL(max(CAST(substring(" + columnName + "," + substringStartIndex + "," + substringEndIndex + ") AS int))+1, 1) as nvarchar) as NewId from " + tableName;
            SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(strQry);
            while (dr.Read())
            {
                NewId = dr["NewId"].ToString();
            }
            dr.Close();

            return NewId;
        }

        public static string _GenerateNewStringID(string initialCharacter, string columnName, string substringStartIndex, string substringEndIndex, string tableName, SqlConnection connection, SqlTransaction transaction)
        {
            string NewId = "";

            string strQry = "Select '" + initialCharacter + "' + CAST(ISNULL(max(CAST(substring(" + columnName + "," + substringStartIndex + "," + substringEndIndex + ") AS int))+1, 1) as nvarchar) as NewId from " + tableName;
            SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(strQry);
            while (dr.Read())
            {
                NewId = dr["NewId"].ToString();
            }
            dr.Close();

            return NewId;
        }

        public static int _GenerateNewIntID(string columnName, string tableName)
        {
            int NewId = 1;

            string strQry = "Select ISNULL(max(" + columnName + ")+1, 1)  as NewId from " + tableName;
            SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(strQry);
            while (dr.Read())
            {
                NewId = GeneralFunctions._parseStringToInt(dr["NewId"].ToString());
            }
            dr.Close();

            return NewId;
        }

        public static void _ChkSession(string sessionid, string redirectpage)
        {
            if (HttpContext.Current.Session[sessionid] != null)
            {
                if (HttpContext.Current.Session[sessionid].ToString() == "")
                    HttpContext.Current.Response.Redirect(redirectpage);
            }
            else
                HttpContext.Current.Response.Redirect(redirectpage);
        }

        public static string _ChkSession(string sessionid)
        {
            if (HttpContext.Current.Session[sessionid] != null)
            {
                if (HttpContext.Current.Session[sessionid].ToString() != "")
                    return HttpContext.Current.Session[sessionid].ToString();
                else
                    return "";
            }
            else
                return "";
        }

        public static DataTable ChkUser(string StrUserID, string strPwd)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[2];

            if (StrUserID == "")
            {
                sqlparam[0] = new SqlParameter("@UserName", DBNull.Value);
            }
            else
            {
                sqlparam[0] = new SqlParameter("@UserName", StrUserID);
            }

            if (strPwd == "")
            {
                sqlparam[1] = new SqlParameter("@Password", DBNull.Value);
            }
            else
            {
                sqlparam[1] = new SqlParameter("@Password", strPwd);
            }
            dtUser = DataAccessor.ExecuteProcDataTable("proc_chkUser", sqlparam);
            return dtUser;
        }

        public static DataTable ChkPanelMember_Login(string StrUserID, string strPwd)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[2];

            if (StrUserID == "")
            {
                sqlparam[0] = new SqlParameter("@UserName", DBNull.Value);
            }
            else
            {
                sqlparam[0] = new SqlParameter("@UserName", StrUserID);
            }

            if (strPwd == "")
            {
                sqlparam[1] = new SqlParameter("@Password", DBNull.Value);
            }
            else
            {
                sqlparam[1] = new SqlParameter("@Password", strPwd);
            }
            dtUser = DataAccessor.ExecuteProcDataTable("proc_chkPanel_Login", sqlparam);
            return dtUser;
        }
        public static DataTable ChkSupplierLogin(string StrUserID, string strPwd, string IP)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[3];

            if (StrUserID == "")
            {
                sqlparam[0] = new SqlParameter("@EmailId", DBNull.Value);
            }
            else
            {
                sqlparam[0] = new SqlParameter("@EmailId", StrUserID);
            }

            if (strPwd == "")
            {
                sqlparam[1] = new SqlParameter("@Password", DBNull.Value);
            }
            else
            {
                sqlparam[1] = new SqlParameter("@Password", strPwd);
            }
            if (IP == "")
            {
                sqlparam[2] = new SqlParameter("@IPAddress", DBNull.Value);
            }
            else
            {
                sqlparam[2] = new SqlParameter("@IPAddress", IP);
            }
            dtUser = DataAccessor.ExecuteProcDataTable("sp_checkSupplierLogin", sqlparam);
            return dtUser;
        }

        public static string RemoveSpecialCharactersFromFileName(string strFileName)
        {
            System.Text.RegularExpressions.Regex objSpChar = new System.Text.RegularExpressions.Regex(@"[^\w\-]");
            System.Text.RegularExpressions.Regex objWhiteSpace = new System.Text.RegularExpressions.Regex(@"\s+");

            strFileName = objSpChar.Replace(strFileName, " ");
            strFileName = objWhiteSpace.Replace(strFileName, @" ");

            strFileName = strFileName.Replace("_", "");
            strFileName = strFileName.Replace(" ", "_");

            if (strFileName.Length > 150)
            {
                strFileName = strFileName.Substring(0, 150);
            }

            return strFileName;
        }

        public static string RemoveSpecialChar(string str)
        {
            string result = System.Text.RegularExpressions.Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            return result;
        }

        public static DateTime GetDate(string date)
        {
            if (string.IsNullOrEmpty(date))
                date = "01/01/1753";
            char[] del = { '/' };

            string[] dateParts = date.Split(del);
            int day = Convert.ToInt32(dateParts[0]);
            int month = Convert.ToInt32(dateParts[1]);
            int year = Convert.ToInt32(dateParts[2]);

            return new DateTime(year, month, day);
        }

        public static string Formated_StringDate(string strDate)
        {
            string result = String.Empty;
            DateTime dt = Convert.ToDateTime(strDate);
            result = dt.ToShortDateString();
            return result;
        }

        public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        /// <summary>
        /// strExtensions e.g (JPEG|GIF|PNG)    
        /// strFileNamePath e.g (C:\web\myproject\)
        /// </summary>    
        public static bool ChkValidateFileExtension(string strExtentions, string strFileNameWithExt)
        {
            bool result = false;

            string[] ext = strExtentions.Split('|');

            for (int i = 0; i <= ext.Length - 1; i++)
            {
                if (System.IO.Path.GetExtension(strFileNameWithExt.Trim().ToLower()) == "." + ext[i].ToString().ToLower())
                {
                    result = true;
                    break;
                }
            }


            return result;
        }

        public static string ConvertStringToTitleCase(string strInput)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(strInput.ToLower());

        }

        public static void ExportDataTableToExcel(DataTable dtToExport, string exportfile)
        {
            StringBuilder sb = new StringBuilder();
            string[] columnNames = dtToExport.Columns.Cast<DataColumn>().
                                      Select(column => column.ColumnName).
                                      ToArray();
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dtToExport.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                ToArray();
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(exportfile, sb.ToString());
        }

        public static void ExporttoExcel(DataTable table)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {      //write in new column
                HttpContext.Current.Response.Write("<Td>");
                //Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static void ExporttoExcel(DataTable table, params string[] args)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers

            foreach (var item in args)
            {
                table.Columns.Remove(item);
            }

            int columnscount = table.Columns.Count;
            for (int j = 0; j < columnscount; j++)
            {      //write in new column
                HttpContext.Current.Response.Write("<Td>");
                //Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }



        public static string GetHMACSHA256(string text, string key)
        {
            UTF8Encoding encoder = new UTF8Encoding();

            byte[] hashValue;
            byte[] keybyt = encoder.GetBytes(key);
            byte[] message = encoder.GetBytes(text);

            HMACSHA256 hashString = new HMACSHA256(keybyt);
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        public static string RemoveReservedCharacters(string strValue)
        {
            char[] ReservedChars = { '/', ':', '*', '?', '"', '<', '>', '|', '#', '&', '~', '$', '%', '^', '{', '}', '+' };

            foreach (char strChar in ReservedChars)
            {
                strValue = strValue.Replace(strChar.ToString(), "");
            }
            return strValue;
        }

        public static bool CheckUserRights(string UserID, string ParentModuleName, string ModuleName, string btnType)
        {
            // btnType sholud be text add,edit,view,delete
            DataTable userRights = new DataTable();
            bool status = true;

            //if (HttpContext.Current.Session["AdminRights"] != null)
            //{

            //    userRights = (DataTable)HttpContext.Current.Session["AdminRights"];
            //    if (userRights.Rows.Count > 0)
            //    {
            //        DataRow[] pageRights = userRights.Select("ModuleName='" + ModuleName.Trim() + "' and ParentModuleName='" + ParentModuleName + "'");
            //        if (pageRights.Length > 0)
            //        {
            //            if (Convert.ToString(pageRights[0]["FullPerm"]).Trim() == "True")
            //            {
            //                return status = true;
            //            }
            //            else if (Convert.ToString(pageRights[0]["AddPerm"]).Trim() == "True" && btnType.ToLower() == "add")
            //            {
            //                return status = true;
            //            }
            //            else if (Convert.ToString(pageRights[0]["EditPerm"]).Trim() == "True" && btnType.ToLower() == "edit")
            //            {
            //                return status = true;
            //            }
            //            else if (Convert.ToString(pageRights[0]["ViewPerm"]).Trim() == "True" && btnType.ToLower() == "view")
            //            {
            //                return status = true;
            //            }
            //            else if (Convert.ToString(pageRights[0]["DeletePerm"]).Trim() == "True" && btnType.ToLower() == "delete")
            //            {
            //                return status = true;
            //            }
            //        }
            //    }
            //}
            return status;
        }

        #region "Fill Country"

        public static void FillCountry(DropDownList ddlCountry, string CountryID)
        {
            ddlCountry.Items.Clear();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CountryID", SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(CountryID))
            {
                param[0].Value = CountryID;
            }
            else
            {
                param[0].Value = DBNull.Value;
            }
            string strSQL = "Select *  from Country";
            GeneralFunctions._FillDropDown(strSQL, "name", "iso", "--Select Country--", "", ddlCountry, param);
        }

        #endregion

        public static DataTable ChkLogisticLogin(string StrUserID, string strPwd)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[2];

            if (StrUserID == "")
            {
                sqlparam[0] = new SqlParameter("@EmailId", DBNull.Value);
            }
            else
            {
                sqlparam[0] = new SqlParameter("@EmailId", StrUserID);
            }

            if (strPwd == "")
            {
                sqlparam[1] = new SqlParameter("@Password", DBNull.Value);
            }
            else
            {
                sqlparam[1] = new SqlParameter("@Password", strPwd);
            }
            dtUser = DataAccessor.ExecuteProcDataTable("proc_checkLogisticLogin", sqlparam);
            return dtUser;
        }

        //Encoding.UTF8
        public static string HashHMACSHA256(string text, string key, Encoding encoding)
        {
            byte[] textBuffer = encoding.GetBytes(text);
            byte[] keyBuffer = encoding.GetBytes(key);

            HMACSHA256 serviceProvider = new HMACSHA256(keyBuffer);
            return Convert.ToBase64String(serviceProvider.ComputeHash(textBuffer));
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file

            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            string key = "007WorldOne#12";
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            string key = "007WorldOne#12";

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        public static string EncodeString(string plainText)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(plainText);
            return Convert.ToBase64String(b, 0, b.Length);
        }

        public static string DecodeString(string encodedText)
        {
            byte[] b = Convert.FromBase64String(encodedText);
            return System.Text.Encoding.Default.GetString(b);
        }

        public static int ValidateInt(object value)
        {

            return ValidateInt(value, 0);
        }

        public static int ValidateInt(object value, int nullVal)
        {
            int _returnVal = nullVal;
            if (value == DBNull.Value || value == null)
                _returnVal = nullVal;
            else
            {
                if (!Int32.TryParse(value.ToString(), out _returnVal))
                    _returnVal = nullVal;
                if (_returnVal == nullVal && value.GetType() == typeof(double))
                    if (!Int32.TryParse(value.ToString().Remove(value.ToString().LastIndexOf('.')), out _returnVal))
                        _returnVal = nullVal;
            }
            return _returnVal;
        }

        public static string ValidateString(object value)
        {
            string _returnVal = string.Empty;
            if (value == DBNull.Value || value == null)
                _returnVal = string.Empty;
            else
                try { _returnVal = value.ToString(); }
                catch { _returnVal = string.Empty; }
            return _returnVal;
        }

        public static bool ValidateBool(object value)
        {
            bool _returnVal = false;

            if (value == DBNull.Value || value == null)
                _returnVal = false;
            else
                if (!Boolean.TryParse(value.ToString(), out _returnVal))
                _returnVal = false;
            try
            {
                if (Convert.ToInt16(value) == 1)
                    _returnVal = true;
            }
            catch { }
            return _returnVal;
        }
    }
}