using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class FormSubmitted : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            OleDbConnection mycon = new OleDbConnection();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            mycon.ConnectionString = connection;
            var dt = new DataTable();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT SignInFormControl, SignInFormColor FROM SignInFormColor", mycon))
            {
                adapter.Fill(dt);
            }
            foreach (DataRow row in dt.Rows)
            {
                string myControl = row.ItemArray[0].ToString();
                if (myControl == "Page Background")
                {
                    pagebody.Attributes.Add("bgcolor", row.ItemArray[1].ToString());
                }
                else
                {

                    this.Session[myControl + "Color"] = row.ItemArray[1].ToString();
                }
            }
             pagebody.Attributes.CssStyle.Add("color", this.Session["Section TextColor"].ToString());
            pnlFormSubmitted.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
            pnlFormSubmitted.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
        }
    }
}