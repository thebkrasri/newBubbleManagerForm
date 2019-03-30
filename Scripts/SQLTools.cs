using Microsoft.CSharp;
using System.Data.OleDb;
using System.Data;

public class SQLTools
{

    public OleDbConnection.ConnectionString vcon = new OleDbConnection.ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    public static DataTable GetDataTable(string sqlstr)
    {
        OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, vcon);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public static string GetSingleSqlValue(string sqlstr)
    {
        OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, vcon);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GetSingleSqlValue = dt.Rows[0][0];
        }
        else
        {
            GetSingleSqlValue = null;
        }
    }

    public static void Insert(string cmd)
    {
    }
    
}