using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuan.DA;
using System.Data;
using Yuan.Model;

namespace Yuan.BL
{
    public class BLEnquiry
    {
        public DataTable GetEnquiryList(int Id =0)
        {
            return DAEnquiry.selectEnquiry(Id);
        }
        public string InsertUpdateEnquiry(Enquiry Obj)
        {
            string Message = "";
            try
            {
                if (Obj.EnquiryID == 0)
                {
                    DataTable dt = DAEnquiry.insertEnquiry(Obj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                        {
                            Message = "success";
                            //rid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        }
                    }
                }
                else
                {
                    DataTable dt = DAEnquiry.updateEnquiry(Obj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                        {
                            Message = "success";
                            //rid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }

        public string deleteEnquiry(int Id)
        {
            string str = "";
            DataTable dtEnq = DAEnquiry.deleteEnquiry(Id);
            if (dtEnq.Rows[0]["RETVAL"].ToString() == "DELETE")
            {
                str = "success";
            }

            return str;
        }
    }
}