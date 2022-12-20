using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Yuan.Model;
using Yuan.DA;
using System.Configuration;

namespace Yuan.BL
{
    public class AppointmentBL
    {
        public DataTable GetBookedAppointments(int AppointmentID)
        {
            return AppointmentDL.GetBookedAppointments(GeneralFunctions.ValidateInt(AppointmentID));
        }
        public string CancelAppointment(int AppointmentID)
        {
            string res;
            try
            {
                DataTable dt = AppointmentDL.CancelAppointment(AppointmentID);
                if (dt.Rows[0]["RETVAL"].ToString() == "Cancel")
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
                res = ex.Message;
            }
            return res;
        }

        public DataTable getAppointmentSlots(int CompanyID, string Date, int ServiceID)
        {
            return AppointmentDL.GetAppointmentSlots(CompanyID, Date, ServiceID);
        }

        public string AddAppointment(int GuestID, int OrderID, int SlotID, string Date, int CompanyID, string Source, int StaffID, int UserID, string Remark)
        {
            string Message = "";
            string AppointmentID = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                dt = AppointmentDL.AddAppointment(GuestID, OrderID, SlotID, CompanyID, Date, Source, Remark, StaffID, UserID);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RETVAL"].ToString() != "")
                    {
                        Message = "Success";
                        AppointmentID = dt.Rows[0]["AppointmentID"].ToString();
                    }
                    SendAppointmentEmail(GeneralFunctions.ValidateInt(AppointmentID), SlotID);
                }
                else
                {
                    Message = "Fail";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }

        public string UpdateAppointment(int AppointmentID, int GuestID, int OrderID, int SlotID, string Date, int CompanyID, string Source, int StaffID, int UserID, string Remark)
        {
            string Message = "";
            DataTable dt = new DataTable();
            try
            {
                dt = AppointmentDL.UpdateAppointment(AppointmentID,GuestID, OrderID, SlotID, CompanyID, Date, Source, Remark, StaffID, UserID);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RETVAL"].ToString() != "")
                    {
                        Message = "Success";

                    }
                }
                else
                {
                    Message = "Fail";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }


        public Model.Appointments GetAppointments(int OrderID, int SlotID)
        {
            DataTable DT = AppointmentDL.GetAppointmentDetails(OrderID, SlotID);
            Model.Appointments appointments = new Model.Appointments();

            if (DT.Rows.Count > 0)
            {
                appointments.OrderID = GeneralFunctions._parseStringToInt(DT.Rows[0]["OrderID"].ToString());
                appointments.SlotID = GeneralFunctions._parseStringToInt(DT.Rows[0]["SlotID"].ToString());
                appointments.ServiceID = GeneralFunctions._parseStringToInt(DT.Rows[0]["ServiceID"].ToString());
                appointments.CompanyID = GeneralFunctions._parseStringToInt(DT.Rows[0]["CompanyID"].ToString());
                appointments.TimeofAppoint = DT.Rows[0]["TimeofAppoint"].ToString();
                appointments.DateofAppoint = DT.Rows[0]["DateofAppoint"].ToString();
                appointments.CompanyName = DT.Rows[0]["CompanyName"].ToString();
                appointments.ServiceName = DT.Rows[0]["ServiceName"].ToString();
                appointments.DayofAppoint = DT.Rows[0]["DayofWeek"].ToString();
                appointments.GuestEmail = DT.Rows[0]["GuestEmail"].ToString();
                appointments.GuestName = DT.Rows[0]["GuestName"].ToString();
            }

            return appointments;
        }

        public bool SendAppointmentEmail(int AppointmentID, int SlotID)
        {
            bool IsSuccess = true;
            try
            {
                Model.Appointments appointments = GetAppointments(AppointmentID, SlotID);

                string MSGSTR = "";
                MSGSTR += "<table cellpadding='5' cellspacing='5' style='font-family:Arial;font-size:14px;width:700px;'>";
                MSGSTR += "<tr>";
                MSGSTR += "<td>";
                MSGSTR += "<h1 style='font-size: 25px;margin: 0;padding: 0;line-height: 1;font-weight: 700;letter-spacing: 2px;text-transform: uppercase;text-transform: uppercase;font-family: ' Alata', sans-serif;'>";
                MSGSTR += "<img src='" + ConfigurationManager.AppSettings["HostingUrl"].ToString() + "/img/logo.png' style='max-height: 40px;vertical-align: middle;' />";
                MSGSTR += "</h1>";
                MSGSTR += "</td>";
                MSGSTR += "</tr>";
                MSGSTR += "<tr><td style='height:5px;background:#b17c0d'></td></tr>";
                MSGSTR += "<tr>";
                MSGSTR += "<td>";
                MSGSTR += "<br /><br />";
                MSGSTR += "Dear " + appointments.GuestName + ",";
                MSGSTR += "<br /><br />";
                MSGSTR += "Your appointment for a " + appointments.ServiceName + " is confirmed for " + appointments.DayofAppoint + ", " + appointments.DateofAppoint + " at " + appointments.TimeofAppoint;
                MSGSTR += "<br /><br />";
                MSGSTR += "For queries, call us on 9892901220.";
                MSGSTR += "<br /><br />";
                MSGSTR += "Regards,<br /><br/>";
                MSGSTR += "Team @Yuan Thai spa";
                MSGSTR += "<br /><br />";
                MSGSTR += "</td>";
                MSGSTR += "</tr>";
                MSGSTR += "<tr><td style='height:5px;background:#b17c0d;text-align:right;padding-right:10px;'><a href='" + ConfigurationManager.AppSettings["HostingUrl"].ToString() + "' target='_blank' style='color:black;text-decoration:underline'>Yuan Thai Spa</td></tr>";
                MSGSTR += "</table>";


                GeneralFunctions._SendMail(appointments.GuestEmail, "yuanthaispa@gmail.com", "Yuan Thai Spa", "Your upcoming Appointment at " + appointments.CompanyID, MSGSTR, "", "echofeelservices@gmail.com");

            }
            catch (Exception ex)
            {
                IsSuccess = false;
            }

            return IsSuccess;
        }
    }
}