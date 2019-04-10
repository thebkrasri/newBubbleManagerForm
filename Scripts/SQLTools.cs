using Microsoft.CSharp;
using System.Data.OleDb;
using System.Data;

public partial class Default {
public class OleDbTools
{
    static string conString = "System.Configuration.ConfigurationManager.ConnectionStrings['" + "ConnectionString" + "'].ConnectionString";
        
    public static DataTable GetDataTable(string sqlstr)
    {
        OleDbConnection vcon = new OleDbConnection(conString);
        OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, vcon);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    static string GetSingleSqlValue(string sqlstr)
    {
        OleDbConnection vcon = new OleDbConnection(conString);
        OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, vcon);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        else
        {
            return null;
        }
    }


}
}