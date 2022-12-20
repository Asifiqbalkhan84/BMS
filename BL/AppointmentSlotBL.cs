using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Yuan.DA;

namespace Yuan.BL
{
    public class AppointmentSlotBL
    {
        public string InsertUpdateSlot(Model.Slots objSlot)
        {
            //objCompayDL = new CompanyDL();
            DataTable dt;
            string res = "";
            if (objSlot.SlotID > 0)
            {
                dt = AppointmentSlotDL.UpdateSlot(objSlot);
                if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                {
                    res = "Success";
                    //ServiceID = 0;
                }
            }
            else
            {
                dt = AppointmentSlotDL.InsertSlot(objSlot);
                if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                {
                    res = "Success";                    
                }
            }

            return res;
        }

        public DataTable getSlotDetails(int SlotId = 0)
        {
            DataTable dt;
            try
            {
                dt = AppointmentSlotDL.GetSlots(SlotId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public string DeleteSlotbyID(int SlotId)
        {
            string res;
            try
            {
               DataTable dt = AppointmentSlotDL.DeleteSlot(SlotId);
                if (dt.Rows[0]["RETVAL"].ToString() == "delete")
                {
                    res = "Success";
                }  
                else
                {
                    res = "error";
                }
            }
            catch (Exception ex)
            {
                res = "error";
                throw new Exception(ex.Message);
            }
            return res;
        }
    }
}