using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Reflection;


namespace Yuan.DA
{
    public class DataAccessor
    {
        public DataAccessor()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static String ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["constr"].ConnectionString; }
        }

        public static string GetInsertedIdWithExecuteNonQuery(String storedProcedureName, params SqlParameter[] arrParam)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }

                cmd.ExecuteNonQuery();

                string insertedId = (string)cmd.Parameters[cmd.Parameters.Count - 1].Value;
                return insertedId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }

        public static int ExecuteNonQuery(string storedProcedureName, params SqlParameter[] arrParam)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }

        public static DataTable ExecuteQueryDataTable(string CsQuery, params SqlParameter[] arrParam)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(CsQuery, cn);

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }

        public static DataTable ExecuteProcDataTable(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;
            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }

        public static SqlDataReader ExecuteQueryDataReader(string CsQuery, params SqlParameter[] arrParam)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(CsQuery, cn);

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public static SqlDataReader ExecuteProcDataReader(string storedProcedureName, params SqlParameter[] arrParam)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public static void ExecuteQuery(string CsQuery, params SqlParameter[] arrParam)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            SqlCommand cmd = new SqlCommand(CsQuery, cn);

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }

        public static DataSet ExecuteProcDataSet(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataSet dt = new DataSet();
            SqlConnection cn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }
        public static DataSet ExecuteQueryDataSet(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(storedProcedureName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                cn.Open();

            try
            {
                if (arrParam != null)
                {
                    foreach (SqlParameter param in arrParam)
                        cmd.Parameters.Add(param);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }


        //Convert Datatable to LIST

        public static List<T> BindList<T>(DataTable dt)
        {
            // Example 1:
            // Get private fields + non properties
            //var fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            // Example 2: Your case
            // Get all public fields
            var fields = typeof(T).GetFields();

            List<T> lst = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                // Create the object of T
                var ob = Activator.CreateInstance<T>();

                foreach (var fieldInfo in fields)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        // Matching the columns with fields
                        if (fieldInfo.Name == dc.ColumnName)
                        {
                            // Get the value from the datatable cell                    
                            object value = (dr[dc.ColumnName] == DBNull.Value) ? null : dr[dc.ColumnName]; //if database field is nullable
                                                                                                           // Set the value into the object
                            fieldInfo.SetValue(ob, value);
                            break;
                        }
                    }
                }

                lst.Add(ob);
            }

            return lst;
        }


    }
}