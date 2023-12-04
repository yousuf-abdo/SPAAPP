using System;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Net;
using System.Web;
using System.Net.NetworkInformation;
using System.Globalization;

/// <summary>
/// Summary description for DatabaseClass
/// </summary>
/// 

public class DatabaseClass
{

    private static string dbName;
    private static string serverName;


    private DataSet ds;
    private SqlCommand cmd;
    private SqlDataAdapter da;


    public static string connectionString;
    public SqlConnection cn;

    public static string DBName
    {
        get { return DatabaseClass.dbName; }
        //set { DatabaseClass.dBName = value; }
    }

    public int ExecuteInsertWithIDReturn(SqlCommand cmd, string tableName)
    {
        int returnValue, recordsAffected;

        try
        {
            //cmd = new SqlCommand(sql, cn);
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
            if (recordsAffected == 1)
            {
                string sql = string.Format("select ident_current('{0}') ", tableName);
                returnValue = Int32.Parse(ExecuteScalar(sql).ToString());
                return returnValue;
            }
            else
                return 0;

        }
        catch (Exception ex)
        {
            throw ex; //new Exception(ex.Message);
        }

        // return recordsAffected;
    }

    public static string ServerName
    {
        get { return DatabaseClass.serverName; }
        //set { DatabaseClass.serverName = value; }
    }

    public object ExecuteInsertWithIDReturn(string sql)
    {
        throw new NotImplementedException();
    }

    public string DatabaseClassConnectionString
    {
        get { return connectionString; }
    }


    #region Constructors

    /// <summary>
    /// Creates a connection to the database using the connection string saved in app.config
    /// </summary>
    public DatabaseClass()
    {
        //local server name
        //serverName = @".\SQLEXPRESS";

        //hosting server name
        //serverName = @"T\SQLEXPRESS";
        //serverName = @"ISLAM-PC\SQLEXPRESS";
        //serverName = @"172.27.1.2\SQLEXPRESS";
        //serverName = @"DESKTOP-FBTCFBU\SQLEXPRESS";
        //serverName = @"USER-PC\SQLEXPRESS";
        // serverName = @"MAZIN-PC\SQLEXPRESS";
        //serverName = @"ISLAM-PC\SQLEXPRESS";
        //serverName = @"T\SQLEXPRESS";
        // serverName = @"KHALIFA-PC\SQLEXPRESS";
        //serverName = @"AHMED-PC\SQLEXPRESS";
        //serverName = @"sa";
        //serverName = @"DESKTOP-MH6IQPG\Yousuf";
        //        serverName = @"DESKTOP-MH6IQPG\SQLEXPRESS";
          serverName = @".";
        //serverName = @".";
        dbName = "SPADB";
        //dbName = "winbest_StudentResults";
        connectionString = string.Format("server={0}; database={1};trusted_connection=yes", serverName, dbName);
        // connectionString = string.Format("server={0}; Pooling=True;Min Pool Size=10;Max Pool Size=100;database={1}; uid=onlinereg; pwd=onlinereg123; Trusted_Connection=false; Connect Timeout=600 ", ServerName, DBName);
        // connectionString = string.Format("server={0}; database={1}; uid=onlinereg; pwd=onlinereg123; Trusted_Connection=false; Connect Timeout=600 ", ServerName, DBName);

        //connectionString = string.Format("Data Source={0};Initial Catalog={1};User Id=sa;Password=y60601010; ", ServerName, DBName);

        cn = new SqlConnection(connectionString);
    }


    /// <summary>
    /// Creates a connection to the database using a customized connection string 
    /// </summary>
    /// <param name="sName">Server Name</param>
    /// <param name="dName">Database Name</param>
    public DatabaseClass(string sName, string dName)
    {
        dbName = dName;
        serverName = sName;
        //trusted_connection=yes
        connectionString = string.Format("server={0}; database={1};trusted_connection=yes", ServerName, DBName);
        //connectionString = string.Format(@" Server=tcp:{0},1433; Network Library=DBMSSOCN; Database={1}; User ID=test_att; Password=123; ", ServerName, DBName);
        // connectionString = string.Format(@" Server={0}; Database={1}; uid=test_att; pwd=123; trusted_connection=false; Connect Timeout=600 ", ServerName, DBName);
        //connectionString = string.Format("DSN=AcademyAttend;Uid=test_att;Pwd=123;");
        cn = new SqlConnection(connectionString);
    }

    public DatabaseClass(string dName)
    {
        if (dName == "RegisterationFormData")
        {
            //serverName = @"ISLAM-PC\SQLEXPRESS";
            //serverName = @"USER-PC\SQLEXPRESS";
            //serverName = @"MAZIN-PC\SQLEXPRESS";
            //serverName = @"ISLAM-PC\SQLEXPRESS";
            //serverName = @"KHALIFA-PC\SQLEXPRESS";
            // serverName = @"172.27.1.2\SQLEXPRESS";
            //serverName = @"DESKTOP-FBTCFBU\SQLEXPRESS";
            //serverName = @"BANSERVER";

            //serverName = @"DESKTOP-FBTCFBU\SQLEXPRESS"; 
            serverName = @"NAJI\NAJI";
            // serverName = @"192.168.1.11";

            dName = "RegisterationFormData";
            //  connectionString = string.Format("server={0}; database={1};trusted_connection=yes", serverName, dName);
            //connectionString = string.Format("server={0};Pooling=True;Min Pool Size=10;Max Pool Size=100; database={1}; uid=StudentsInformation; pwd=StudentsInformation123; trusted_connection=false; Connect Timeout=600 ", serverName, dName);
            connectionString = string.Format("server={0}; database={1};trusted_connection=yes", serverName, dName);
            cn = new SqlConnection(connectionString);
        }
        if (dName == "library")
        {
            //serverName = @"ISLAM\SQLEXPRESS";
            //serverName = @"USER-PC\SQLEXPRESS";
            //serverName = @"MAZIN-PC\SQLEXPRESS";
            //serverName = @"T\SQLEXPRESS";
            //serverName = @"KHALIFA-PC\SQLEXPRESS";
            //serverName = @"172.27.1.2\SQLEXPRESS";
            //serverName = @"DESKTOP-FBTCFBU\SQLEXPRESS";
            //serverName = @"BANSERVER";
            //serverName = @"192.168.1.11";
            serverName = @"DESKTOP-FBTCFBU\SQLEXPRESS";

            dName = "Library";
            connectionString = string.Format("server={0}; database={1};trusted_connection=yes", serverName, dName);
            // connectionString = string.Format("server={0};Pooling=True;Min Pool Size=10;Max Pool Size=100; database={1}; uid=library; pwd=library123; trusted_connection=false; Connect Timeout=600 ", serverName, dName);
            cn = new SqlConnection(connectionString);
        }
        if (dName == "UniSet")
        {
            //serverName = @"ISLAM-PC\SQLEXPRESS";
            //serverName = @"USER-PC\SQLEXPRESS";
            //serverName = @"MAZIN-PC\SQLEXPRESS";
            //serverName = @"ISLAM-PC\SQLEXPRESS";
            //serverName = @"KHALIFA-PC\SQLEXPRESS";
            // serverName = @"172.27.1.2\SQLEXPRESS";
            //serverName = @"DESKTOP-FBTCFBU\SQLEXPRESS";
            serverName = @"DESKTOP-FBTCFBU\SQLEXPRESS";
            //serverName = @"BANSERVER";
            // serverName = @"192.168.1.11";
            dName = "UniversitySettings";
            // connectionString = string.Format("server={0}; database={1};trusted_connection=yes", serverName, dName);
            connectionString = string.Format("server={0};Pooling=True;Min Pool Size=10;Max Pool Size=100; database={1}; uid=umstis; pwd=umstis123; trusted_connection=false; Connect Timeout=600 ", serverName, dName);
            cn = new SqlConnection(connectionString);
        }
    }
    #endregion


    /// <summary>
    /// Opens a connection to the database
    /// </summary>
    public void OpenConnection()
    {
        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Closes the open connection
    /// </summary>
    public void CloseConnection()
    {
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    ///  To Execute SQL statement that returns result in rows
    /// </summary>
    /// <param name="sqlStmt">SQL Statement</param>
    /// <returns>result rows</returns>
    public DataTable ExecuteQuery(string sqlStmt)
    {
        cmd = new SqlCommand(sqlStmt, cn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        cmd.CommandTimeout = 600;

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return ds.Tables[0];
    }

    /// <summary>
    /// To Execute SQL command containing SQL Statement that returns result in rows
    /// </summary>
    /// <param name="cmd">QL command containing SQL Statement</param>
    /// <returns>result rows</returns>
    public DataTable ExecuteQuery(SqlCommand cmd)
    {
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        cmd.CommandTimeout = 600;

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return ds.Tables[0];
    }

    /// <summary>
    /// To execute insert/update/delete SQL statement
    /// </summary>
    /// <param name="sql">insert/update/delete SQL statement</param>
    /// <returns>No. of rows affected by the statement</returns>
    public int ExecuteNonQuery(string sql)
    {
        int recordsAffected;

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return recordsAffected;
    }

    /// <summary>
    /// To execute SQL command containing insert/update/delete SQL statement
    /// </summary>
    /// <param name="cmd">SQL command containing insert/update/delete SQL statement</param>
    /// <returns>No. of rows affected by the statement</returns>
    public int ExecuteNonQuery(SqlCommand cmd)
    {
        int recordsAffected;
        cmd.CommandTimeout = 600;

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return recordsAffected;
    }

    /// <summary>
    /// To execute SQL command containing insert SQL statement returning the new identity column value
    /// </summary>
    /// <param name="sql">Insert SQL Statement</param>
    /// <param name="tableName">Table affected by the insert statement</param>
    /// <returns>New identity value</returns>
    public int ExecuteInsertWithIDReturn(string sql, string tableName)
    {
        int returnValue, recordsAffected;

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
            if (recordsAffected == 1)
            {
                sql = string.Format("select ident_current('{0}')", tableName);
                returnValue = Int32.Parse(ExecuteScalar(sql).ToString());
                return returnValue;
            }
            else
                return 0;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        // return recordsAffected;
    }


    /// <summary>
    /// To execute SQL Statement that returns one value
    /// </summary>
    /// <param name="sql">SQL statement</param>
    /// <returns>Retrieved value</returns>
    public Object ExecuteScalar(string sql)
    {
        Object returnValue;

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            returnValue = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        if (returnValue == null)
            return 0;
        else
            return returnValue;
    }

    /// <summary>
    /// To execute SQL Statement that returns one value
    /// </summary>
    /// <param name="cmd">SQL command containing SQL statement</param>
    /// <returns>Retrieved value</returns>
    public decimal ExecuteScalar(SqlCommand cmd)
    {
        decimal returnValue;

        try
        {
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            returnValue = (decimal)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return returnValue;
    }

    /// <summary>
    /// To format date string to be in the format DMY
    /// </summary>
    /// <param name="dt">Date the must be formatted</param>
    /// <returns>date in string formatted in DMY</returns>
    public static string FormatDateDMY(DateTime dt)
    {
        // To format date string to be in the format DMY
        string date = string.Format("{0}/{1}/{2}", dt.Day, dt.Month, dt.Year);
        return date;
    }

    /// <summary>
    /// To format date string to be in the format MDY
    /// </summary>
    /// <param name="dt">Date the must be formatted</param>
    /// <returns>date in string formatted in MDY</returns>
    public static string FormatDateMDY(DateTime dt)
    {
        // To format date string to be in the format DMY
        string date = string.Format("{1}/{0}/{2}", dt.Day, dt.Month, dt.Year);
        return date;
    }


    /// <summary>
    ///  To format date string to be in the format MDY after parsing it
    /// </summary>
    /// <param name="strDate">String of date the must be formatted</param>
    /// <returns>date in string formatted in MDY</returns>
    public static string FormatDateString(string strDate)
    {
        DateTime passedDate = DateTime.Parse(strDate);
        string date = string.Format("{1}/{0}/{2}", passedDate.Day, passedDate.Month, passedDate.Year);
        return date;
    }


    /// <summary>
    /// To format date string after parsing it to be in a determined format
    /// </summary>
    /// <param name="dateText">String of date the must be formatted</param>
    /// <param name="localeName">Locale short name (e.g: ar-eg, en-us, ar-sa, ...)</param>
    /// <param name="dateFormat">Date format, such as MM/dd/yyyy: MDY, dd/MM/yyyy</param>
    /// <returns>date in string formatted</returns>
    public static string FormatDateByLocale(string dateText, string localeName, string dateFormat)
    {
        DateTime parsedDateTime = Convert.ToDateTime(dateText, new CultureInfo(localeName));
        string parsedDateTimeString = parsedDateTime.ToString(dateFormat);
        return parsedDateTimeString;
    }

    /// <summary>
    /// To format date string after parsing according to Ar-Egypt locale it to be in MDY format
    /// </summary>
    /// <param name="dateText">String of date the must be formatted</param>
    /// <returns>ate in string formatted</returns>
    public static string FormatDateArEgMDY(string dateText)
    {
        return FormatDateByLocale(dateText, "ar-eg", "MM/dd/yyyy");
    }


    public static string FormatDatTimeArEgMDY(string dateText)
    {
        return FormatDateTimeByLocale(dateText, "ar-eg", "MM/dd/yyyy hh:mm");
    }
    public static string FormatDateTimeArEgMDY(string dateText)
    {
        return FormatDateByLocale(dateText, "ar-eg", "MM/dd/yyyy HH:mm:ss.fff");
    }
    public static string FormatDateTimeByLocale(string dateText, string localeName, string dateFormat)
    {
        DateTime parsedDateTime = DateTime.Parse(dateText, new CultureInfo(localeName));
        string parsedDateTimeString = parsedDateTime.ToString(dateFormat);
        return parsedDateTimeString;
    }
    /// <summary>
    /// This function helps to make sure that there are no children rows for a parent row that we need to delete
    /// </summary>
    /// <param name="childTableName">Name of table that contains child rows</param>
    /// <param name="foreignKeyColName">Foreign key column name, which reference the parent row that we want to delete</param>
    /// <param name="foreignKeyColValue">The parent row value that we want to delete</param>
    /// <returns>number of children rows that refernce that parent row to be delete</returns>
    public int GetCountOfChildRecordsBeforeDeletingParent(string childTableName, string foreignKeyColName,
        string foreignKeyColValue)
    {
        string sql = string.Format("select count(*) from {0} where {1}={2}", childTableName, foreignKeyColName, foreignKeyColValue);
        int records = int.Parse(ExecuteScalar(sql).ToString());
        return records;
    }


    /// <summary>
    /// This function helps to make sure that there are no children rows for a parent row that we need to delete
    /// </summary>
    /// <param name="childTableName">Name of table that contains child rows</param>
    /// <param name="foreignKeyColName">Foreign key column name, which reference the parent row that we want to delete</param>
    /// <param name="foreignKeyColValue">The parent row value that we want to delete</param>
    /// <returns>number of children rows that refernce that parent row to be delete</returns>
    public int GetCountOfChildRecordsBeforeDeletingParent(string childTableName, string foreignKeyColName,
        int foreignKeyColValue)
    {
        string sql = string.Format("select count(*) from {0} where {1}={2}", childTableName, foreignKeyColName, foreignKeyColValue);
        int records = int.Parse(ExecuteScalar(sql).ToString());
        return records;
    }


    /// <summary>
    /// To convert boolean value to integer values
    /// </summary>
    /// <param name="value">Boolean value (True or False)</param>
    /// <returns>1 if true, 0 if false</returns>
    /// 
    public static int Bool2Int(bool value)
    {
        // if the passed value was true, return 1, otherwise return 0
        if (value)
            return 1;
        else
            return 0;
    }


    /// <summary>
    /// To validate if the passed value is number or not
    /// </summary>
    /// <param name="s">Value to check if it is a number</param>
    /// <returns>Confirmation if it is or not</returns>
    public static bool IsNumeric(string s)
    {
        try
        {
            int.Parse(s);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// to get two characters string of the passed in number
    /// </summary>
    /// <param name="number">integer number</param>
    /// <returns>string of that number</returns>
    public static string GetNumberCode(int number)
    {
        if (number < 10)
            return string.Format("0{0}", number);
        else
            return number.ToString();
    }


    public enum OperationType
    {
        Save = 0,
        Update = 1
    }


    /// <summary>
    /// to add auditing values for the recently inserted/updated row
    /// </summary>
    /// <param name="userID">ID of the user who has done that insertion/updating operatiobn</param>
    /// <param name="operationType">row manipulation type: insertion or updating</param>
    /// <param name="tableName">table that has been inserted to/updated</param>
    /// <param name="idColumnName">Name of the ID column in the table that has been updated</param>
    /// <param name="idColumnValue">value of the ID column in the table that has been updated</param>
    /// <returns>Flag if the auditing values addition operation has been done successfully or not</returns>
    public static bool AddAuditingValues(int userID, OperationType operationType, string tableName,
        string idColumnName, int idColumnValue)
    {
        if (userID == 0)
            return false;

        try
        {
            string sql = "";
            DatabaseClass db = new DatabaseClass();

            if (operationType == OperationType.Save)
                sql = string.Format("update {0} set add_dt=getdate(), add_by={1} where {2}={3}", tableName, userID, idColumnName, idColumnValue);

            else if (operationType == OperationType.Update)
                sql = string.Format("update {0} set update_dt=getdate(), update_by={1} where {2}={3}", tableName, userID, idColumnName, idColumnValue); ;

            int rows = db.ExecuteNonQuery(sql);
            if (rows == 1)
                return true;
            else
                return false;

        }
        catch (Exception ex)
        {
            //return false;
            throw new Exception(ex.Message);
        }


    }




    public DataTable SelectData(string stored_procedure, SqlParameter[] param)
    {
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = stored_procedure;
        sqlcmd.Connection = cn;
        if (param != null)
        {
            for (int i = 0; i < param.Length; i++)
            {
                sqlcmd.Parameters.Add(param[i]);
            }
        }
        SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
    {
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = stored_procedure;
        sqlcmd.Connection = cn;
        if (param != null)
        {
            sqlcmd.Parameters.AddRange(param);
        }
        sqlcmd.ExecuteNonQuery();
    }









}



