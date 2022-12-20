using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Yuan.DA
{
    public class CompanyDL
    {
        public static DataTable GetCompanyDet(int CompanyId)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@CompanyId", CompanyId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("SP_SELECT_COMPANY", param);
            return dt;
        }
        public static DataTable insertCompany(Model.Company ObjCompany)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@CompanyName", ObjCompany.CompanyName),
                new SqlParameter("@OutletName", ObjCompany.OutletName),
                new SqlParameter("@Location", ObjCompany.Location),
                new SqlParameter("@AddressLine1", ObjCompany.AddressLine1),
                new SqlParameter("@AddressLine2", ObjCompany.AddressLine2),
                new SqlParameter("@Area", ObjCompany.Area),
                new SqlParameter("@City", ObjCompany.City),
                new SqlParameter("@Landmark", ObjCompany.Landmark),
                new SqlParameter("@Postcode", ObjCompany.Postcode),
                new SqlParameter("@ContactPerson", ObjCompany.ContactPerson),
                new SqlParameter("@ContactNo", ObjCompany.ContactNo),
                new SqlParameter("@SupportContact", ObjCompany.SupportContact),
                new SqlParameter("@SupportContactNo", ObjCompany.SupportContactNo),
                new SqlParameter("@TotalSlot", ObjCompany.TotalSlot),
                new SqlParameter("@TaxApplicable", ObjCompany.TaxApplicable),
                new SqlParameter("@GSTNo", ObjCompany.GSTNo),
                new SqlParameter("@TaxRate", ObjCompany.TaxRate),
                new SqlParameter("@IsOnlyOffice", ObjCompany.IsOnlyOffice),
                new SqlParameter("@CreatedBy", ObjCompany.CreatedBy)
                
            };

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_company", param);
            return dt;
        }

        public static DataTable UpdateCompany(Model.Company ObjCompany)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@CompanyId", ObjCompany.CompanyID),
                new SqlParameter("@CompanyName", ObjCompany.CompanyName),
                new SqlParameter("@OutletName", ObjCompany.OutletName),
                new SqlParameter("@Location", ObjCompany.Location),
                new SqlParameter("@AddressLine1", ObjCompany.AddressLine1),
                new SqlParameter("@AddressLine2", ObjCompany.AddressLine2),
                new SqlParameter("@Area", ObjCompany.Area),
                new SqlParameter("@City", ObjCompany.City),
                new SqlParameter("@Landmark", ObjCompany.Landmark),
                new SqlParameter("@Postcode", ObjCompany.Postcode),
                new SqlParameter("@ContactPerson", ObjCompany.ContactPerson),
                new SqlParameter("@ContactNo", ObjCompany.ContactNo),
                new SqlParameter("@SupportContact", ObjCompany.SupportContact),
                new SqlParameter("@SupportContactNo", ObjCompany.SupportContactNo),
                new SqlParameter("@TotalSlot", ObjCompany.TotalSlot),
                new SqlParameter("@TaxApplicable", ObjCompany.TaxApplicable),
                new SqlParameter("@GSTNo", ObjCompany.GSTNo),
                new SqlParameter("@TaxRate", ObjCompany.TaxRate),
                new SqlParameter("@IsOnlyOffice", ObjCompany.IsOnlyOffice),                
                new SqlParameter("@UpdatedBy", ObjCompany.UpdatedBy)
            };

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_company", param);
            return dt;
        }

        public static DataTable DeleteCompany(ref string err, int CompanyId)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@CompanyId",CompanyId)
                };
                dt = DataAccessor.ExecuteProcDataTable("sp_delete_company", param);
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return dt;
        }
    }
}