using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Everything_365.Data.Database_Connection
{
    public class ClsDbConnection
    {
        public SqlConnection objCon = new SqlConnection();
        public SqlCommand objSqlCmd = new SqlCommand();
        public string strQuery = String.Empty;
        public DataSet objDs = new DataSet();
        public DataTable objDt = new DataTable();
        public string strErrorMsg = String.Empty;
        public SqlDataAdapter objSqlAdpt = new SqlDataAdapter();
        public static IConfiguration? Configuration;
        private static string _connectionString = String.Empty;

        public static void initialize(IConfiguration config)
        {
            Configuration = config;
        }

        public static string getConnectionString()
        {
            return Configuration.GetConnectionString("connection");
        }

        public static void connectDatabase()
        {
            _connectionString = Configuration.GetConnectionString("connection");
        }

        //Return SqlConnection
        public static SqlConnection getConnection()
        {
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(Configuration.GetConnectionString("connection"));
            }
            catch
            {
                throw new Exception("SQL Connection String is invalid.");
            }
            return conn;
        }

        //Execute Stored Procedure And Returns Dataview
        public static DataView GetSPDataView(string procedureName, SqlCommand command)
        {
            SqlConnection connection = getConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                command.CommandTimeout = 2000;
                command.CommandText = procedureName;
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = command;
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
            return ds.Tables[0].DefaultView;
        }

        //Execute Query And Returns Dataview
        public static DataView GetDataView(string sqlQuery)
        {
            SqlConnection connection = getConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataView dv = new DataView();

            try
            {
                da = new SqlDataAdapter(sqlQuery, connection);
                da.Fill(ds);
                dv.Table = ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
            return dv;
        }

        //Execute Stored Procedure And Returns Datatable 
        public static DataTable GetDataTable(string procedureName, SqlCommand command, string tableName = "")
        {
            SqlConnection connection = getConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                command.CommandText = procedureName;
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = command;
                da.Fill(dt);
                if (tableName != "")
                    dt.TableName = tableName;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
            return dt;
        }

        //Execute Query And Returns Datatable 
        public static DataTable GetDataTable(string strSQL)
        {

            SqlConnection connection = getConnection();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, connection);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return dt;

        }

        public static DataTable GetDataTable(SqlCommand objParaCmd)
        {
            SqlConnection connection = getConnection();
            SqlDataAdapter objDA = new SqlDataAdapter();
            DataTable objDtb = new DataTable();
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd = objParaCmd;
                connection.Open();
                objParaCmd.Connection = connection;
                objDA.SelectCommand = Cmd;
                objDA.Fill(objDtb);
                return objDtb;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objParaCmd.Connection.Close();
                objParaCmd.Connection.Dispose();
                objParaCmd.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

        }

        //Execute SQL Query & Doesn't Return Anything
        public static void ExecuteNonQuery(string strSQL)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                command.CommandText = strSQL;
                command.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        //Execute Strored procedure & Doesn't Return Anything
        public static int ExecuteNonQuery(string procedureName, SqlCommand command)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                command.ExecuteNonQuery();
                return 1;
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        //Execute Strored procedure & Single Return parameter
        public static int ExecuteNonQuerySP(string procedureName, SqlCommand command, String Retparm)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                command.ExecuteNonQuery();
                return Convert.ToInt16(command.Parameters[Retparm].Value);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        //Procedure to Execute Scalar
        public static object ExecuteScalar(string strSQL)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = strSQL;
                return command.ExecuteScalar();
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                command.Connection.Close();

                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

        }

        public static object ExecuteScalar(SqlCommand command)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            try
            {
                command.Connection = connection;
                return command.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        public static object ExecuteScalar(string procedureName, SqlCommand command)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                return command.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        //Execute SQL Query & Return Single Value WITH Flag to return value or not
        public static object ReturnSingleValue(string strSQL, Boolean blnNumericFlag)
        {
            object objRetVal;
            string strRetVal = string.Empty;
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = strSQL;
                objRetVal = command.ExecuteScalar();

                if (blnNumericFlag == true)
                {
                    strRetVal = Convert.ToString(objRetVal) ?? String.Empty ;
                }
                else
                {
                    strRetVal = (string)(objRetVal);
                }
                return strRetVal;
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();

                if (connection.State == ConnectionState.Open) connection.Close();
            }

        }

        //Execute Query And Returns DataSet
        public static DataSet GetDataSet(string procedureName, SqlCommand command)
        {
            SqlConnection connection = getConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter parameters = new SqlParameter();

            try
            {
                command.CommandTimeout = 2000;
                command.CommandText = procedureName;
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = command;
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
                command.Dispose();
                if (connection.State == ConnectionState.Open) connection.Close();
            }
            return ds;
        }       

    }
}
