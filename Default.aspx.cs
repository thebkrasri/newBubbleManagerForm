using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{

    public string useCamera
    {
        get
        {
            if (Request.QueryString["Camera"] == null || Request.QueryString["Camera"].ToLower() != "yes")
                return "No";
            else
                return Request.QueryString["Camera"].ToLower();
        }

    }
    private void ShowMessage(string Message, string Title)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{1}', '{0}');", Message, Title), true);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.Session["imgFilePath"] = "";
            Country.InitCountries();
            CountryID.DataSource = Country.Countries;
            CountryID.DataBind();
            Insurance.SelectedValue = "-1";
            CertifiedDiver.SelectedValue = "-1";
            EmergencyCountryID.DataSource = Country.Countries;
            EmergencyCountryID.DataBind();
            HowHearTextID.DataBind();
            WhereStayID.DataBind();
            DiveLevelID.DataBind();
            DiveOrgID.DataBind();
            LanguageID.DataBind();
            //Add blank item at index 0
            CountryID.Items.Insert(0, new ListItem("--Select--", "0"));
            CountryID.SelectedIndex = -1;
            EmergencyCountryID.Items.Insert(0, new ListItem("--Select--", "0"));
            EmergencyCountryID.SelectedIndex = -1;
            Gender.Items.Insert(0, new ListItem("--Select--", "0"));
            DiveOrgID.Items.Insert(0, new ListItem("--Select--", "0"));
            DiveLevelID.Items.Insert(0, new ListItem("--Select--", "0"));
            WhereStayID.Items.Insert(0, new ListItem("--Select--", "0"));
            HowHearTextID.Items.Insert(0, new ListItem("--Select--", "0"));
            LanguageID.Items.Insert(0, new ListItem("--Select--", "0"));

            var Termsdt = new DataTable();
            Termsdt = OleDbTools.GetDataTable("SELECT TermsText, ShowTerms, [Language] FROM GlobalSettings, [Language] WHERE GlobalSettings.LanguageID = [Language].LanguageID");
            if (Termsdt.Rows[0]["ShowTerms"].ToString() == "True")
            {
                this.Session["ShowTerms"] = true;
                pTerms.InnerHtml = Termsdt.Rows[0].ItemArray[0].ToString().Replace(System.Environment.NewLine, "<br />");
            }
            else
            {
                this.Session["ShowTerms"] = false;
            }
            SetColors();

            string language = Termsdt.Rows[0]["Language"].ToString();
            optLanguage.SelectedValue = language;

            var sectionsdt = new DataTable();
            sectionsdt = OleDbTools.GetDataTable("SELECT * FROM RegisterFormSection");
            var fieldsdt = new DataTable();
            fieldsdt = OleDbTools.GetDataTable("SELECT * FROM RegisterFormField WHERE RegisterFormSectionID in (Select RegisterFormSectionID From RegisterFormSection WHERE Display=True)");
            this.Session["sectionsdt"] = sectionsdt;
            this.Session["fieldsdt"] = fieldsdt;
            ChangeForm();
            if (useCamera.ToLower() == "yes")
            {
                FileUploadValidator.Enabled = false;
            }
        }
    }


    protected void SetColors()
    {
        var dt = new DataTable();
        dt = OleDbTools.GetDataTable("SELECT SignInFormControl, SignInFormColor FROM SignInFormColor");
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
        PhotoPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
        PersonalInfoPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
        AddressPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
        lblPersonalInfoPanel.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
        lblAddressPanel.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
        CertifiedDiver.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
        lblCamera.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
        lblFileUpload.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
    }

    protected void ChangeForm()
    {
        string lang = optLanguage.SelectedItem.Value;
        DataTable sectionsdt = this.Session["sectionsdt"] as DataTable;
        DataTable fieldsdt = this.Session["fieldsdt"] as DataTable;
        string languageLabel = lang + "Label";
        int controlNameIndex = sectionsdt.Columns.IndexOf("ControlName");
        int displayIndex = sectionsdt.Columns.IndexOf("Display");
        int LanguageLabelIndex = sectionsdt.Columns.IndexOf(languageLabel);
        foreach (DataRow row in sectionsdt.Rows)
        {
            string controlName = row.ItemArray[controlNameIndex].ToString();
            string display = row.ItemArray[displayIndex].ToString();
            string langLabel = row.ItemArray[LanguageLabelIndex].ToString();

            Control MyControl = Page.FindControl(controlName);

            if (MyControl != null)
            {
                if (display == "False")
                    MyControl.Visible = false;
                else
                {
                    Panel p = (Panel)MyControl;
                    p.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
                    p.BorderColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BorderColor"].ToString());
                }
            }

            Control MyLabel = FindControl("lbl" + controlName);
            if (MyLabel != null)
            {
                ((Label)MyLabel).Text = langLabel;
                ((Label)MyLabel).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());

                if (display == "False")
                    MyLabel.Visible = false;
            }
        }
        string message = "";
        foreach (DataRow row in fieldsdt.Rows)
        {
            string controlName = row["ControlName"].ToString();
            string langLabel = row[languageLabel].ToString();
            string displayType = row["DisplayType"].ToString();
            message = message + "</br>" + controlName + " " + langLabel + " " + displayType;

            Control MyControl = FindControl(controlName);
            if (MyControl != null)
            {
                if (displayType == "Do Not Include")
                {
                    MyControl.Visible = false;
                }
                else
                {
                    if (MyControl is CheckBox)
                    {
                        if (displayType == "Included and Required")
                        {
                            ((CheckBox)MyControl).CssClass = "req";
                        }
                         ((CheckBox)MyControl).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["TextBox BackgroundColor"].ToString());
                    }
                    else if (MyControl is RadioButtonList)
                    {
                        if (displayType == "Included and Required")
                        {
                            ((RadioButtonList)MyControl).CssClass = "req";
                        }
                         ((RadioButtonList)MyControl).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
                    }
                    else if (MyControl is DropDownList)
                    {
                        if (displayType == "Included and Required")
                        {
                            ((DropDownList)MyControl).CssClass = "req";
                        }
                        ((DropDownList)MyControl).BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["TextBox BackgroundColor"].ToString());
                        ((DropDownList)MyControl).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["TextBox TextColor"].ToString());

                    }
                    else if (MyControl is TextBox)
                    {
                        if (displayType == "Included and Required")
                        {
                            ((TextBox)MyControl).CssClass = "req";
                        }
                        ((TextBox)MyControl).BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["TextBox BackgroundColor"].ToString());
                        ((TextBox)MyControl).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["TextBox TextColor"].ToString());
                    }
                }
            }
            Control MyLabel = FindControl("lbl" + controlName);
            if (MyLabel != null)
            {
                string label = langLabel;
                if (displayType == "Included and Required")
                    label = label.Substring(0, label.Length) + "*";
                else if (displayType == "Do Not Include")
                {
                    MyLabel.Visible = false;
                }
                ((Label)MyLabel).Text = label;
                ((Label)MyLabel).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
            }
            Control MyValidator = FindControl(controlName + "Validator");
            if (MyValidator != null)
            {
                ((RequiredFieldValidator)MyValidator).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Required Field MessageColor"].ToString());
                ((RequiredFieldValidator)MyValidator).Enabled = false;
                if (displayType == "Included and Required")
                {
                    ((RequiredFieldValidator)MyValidator).Enabled = true;
                }
                else if (displayType == "Do Not Include")
                {
                    MyValidator.Visible = false;
                }
            }
        }
        lblBirthDate.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());
        if (lang == "Spanish")
        {
            lblBirthDate.Text = "Fecha de Nacimiento*";
        }
        else if (lang == "English")
        {
            lblBirthDate.Text = "Birth Date*";
        }
    }
    protected void optLanguage_SelectedIndexChanged(Object Sender, EventArgs E)
    {
        ChangeForm();
        //var tabNum = currentTab.Value;
        //ScriptManager.RegisterStartupScript(this, GetType(), "none", "showTab(" + tabNum.ToString() + ");", true);
    }

    protected void prevCustClick(Object Sender, EventArgs E)
    {
        CustomerNumberError.Style["color"] = "red";
        if (CustomerNumber.Text == null)
        {
            CustomerNumberError.Visible = true;
            CustomerNumberError.Text = "Please provide a customer number.";
            FirstName.Text = "";
            LastName.Text = "";
            prevCustomerModal.Style["display"] = "table";
            return;
        }
        float output;
        if (!float.TryParse(CustomerNumber.Text, out output))
        {
            CustomerNumberError.Visible = true;
            CustomerNumberError.Text = "Please enter a valid number.";
            FirstName.Text = "";
            LastName.Text = "";
            prevCustomerModal.Style["display"] = "table";
            return;
        }
        var dt = new DataTable();
        dt = OleDbTools.GetDataTable("SELECT * FROM Customer WHERE CustomerID = " + CustomerNumber.Text);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            InitializeCustomer(dr);
            CustomerNumberError.Text = "Customer " + FirstName.Text + " " + LastName.Text + " Found";
            CustomerNumberError.Style["color"] = "green";
            CustomerNumberHidden.Value = CustomerNumber.Text;
            prevCustomerModal.Style["display"] = "none";
        }
        else
        {
            CustomerNumberError.Style["color"] = "red";
            CustomerNumberError.Text = "Customer Number not found.";
            FirstName.Text = "";
            LastName.Text = "";
            prevCustomerModal.Style["display"] = "table";
        }
    }

    protected void Button1_Click(Object Sender, EventArgs E)
    {
        Page.Validate("Submit");
        List<IValidator> errored = this.Validators.Cast<IValidator>().Where(v => !v.IsValid).ToList();
        if (Page.IsValid)
        {
            InsertShipper();
        }
        else
        {
            var errs = "";
            foreach (IValidator i in errored)
            {
                errs = errs + "\n" + i.ErrorMessage.ToString();
            }
            ShowMessage("Missing Fields", "Please fill in ALL required fields!\n" + errs);
        }
    }

    private void InsertShipper()
    {
        int CustomerID = 0;
        String BDayString = "";
        BDayString = cmbDay.Text + "-" + cmbMonth.Text + "-" + cmbYear.Text;
        string sqlStr;
        if (CustomerNumberHidden.Value == null || CustomerNumberHidden.Value == "")
        {
            sqlStr = "INSERT INTO Customer (FirstName, LastName, Gender, BirthDate ,Address1,Address2,City, StateID,CountryID,PostalCode,Email, Phone, PassportNum, LanguageID, HowHearTextID, HowHearSpecific, WhereStayID, RoomOther,RoomNo, EmergencyName, Relationship, EmergencyNumber, EmergencyEmail, DiveLevelID, DiveOrgID, NumberOfDives, Insurance, InsuranceName, EmergencyCountryID, Facebook, DietaryRestrictions, LastDiveDate, ArrivalDate) VALUES (@FirstName,@LastName, @Gender, @BirthDate, @Address1,@Address2,@City,@StateID, @Country,@PostalCode,@Email, @Phone, @PassportNum, @LanguageID, @HowHear, @HowHearSpecific, @WhereStayID, @RoomOther, @RoomNo, @EmergencyName, @Relationship, @EmergencyNumber, @EmergencyEmail, @DiveLevelID, @DiveOrgID, @NumberOfDives, @EmergencyCountryID, @Facebook, @DietaryRestrictions, @LastDiveDate, @ArrivalDate, @Insurance, @InsuranceName)";
        }
        else
        {
            CustomerID = Convert.ToInt32(CustomerNumberHidden.Value);
            sqlStr = "Update Customer Set FirstName=@FirstName, LastName=@LastName, Gender=@Gender, BirthDate=@BirthDate, Address1=@Address1,Address2=@Address2,City=@City, StateID=@StateID, CountryID=@CountryID, PostalCode=@PostalCode,Email=@Email, Phone=@Phone, PassportNum=@PassportNum, LanguageID=@LanguageID, HowHearTextID=@HowHearTextID, HowHearSpecific=@HowHearSpecific, WhereStayID =@WhereStayID, RoomOther=@RoomOther,RoomNo=@RoomNo, EmergencyName=@EmergencyName, Relationship=@Relationship, EmergencyNumber=@EmergencyNumber, EmergencyEmail=@EmergencyEmail, DiveLevelID=@DiveLevelID, DiveOrgID=@DiveOrgID, NumberOfDives=@NumberOfDives, Insurance=@Insurance, InsuranceName=@InsuranceName, EmergencyCountryID=@EmergencyCountryID, Facebook=@Facebook, DietaryRestrictions=@DietaryRestrictions, LastDiveDate=@LastDiveDate, ArrivalDate=@ArrivalDate WHERE CustomerID=" + CustomerID;
        }
        List<OleDbParameter> parameters = GenerateCustomerParams();
        OleDbTools.ExecuteSqlStatement(sqlStr, parameters);
        if (CustomerID == 0)
        {
            CustomerID = Convert.ToInt32(OleDbTools.GetSingleSqlValue("SELECT TOP 1 CustomerID from [Customer] ORDER BY [CustomerID] DESC"));
        }
        UploadImage(CustomerID);
        sqlStr = "UPDATE Customer SET [image]=@MyImage WHERE CustomerID=" + CustomerID;
        parameters.Clear();
        parameters.Add(new OleDbParameter("Image", OleDbType.VarChar) { Value = this.Session["imgFilePath"] });
        OleDbTools.ExecuteSqlStatement(sqlStr, parameters);
        string urlStr = "FormSubmitted.aspx?Camera=" + useCamera + "&ID=" + CustomerID;
        Response.Redirect(urlStr);
        //IDnum.InnerText = CustomerID.ToString();
        //submittingImg.Style.Add("display", "none");
        //divThankYou.Style.Add("display", "block");
        //pnlFormSubmitted.Style.Add("display", "block");
        //stepbuttons.Style.Add("display", "none");
    }

    protected void CountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList CountryDD = sender as DropDownList;
        DropDownList StateDD = (DropDownList)Page.FindControl("StateID") as DropDownList;
        Label StateLabel = (Label)Page.FindControl("lblStateID") as Label;
        FindStates(CountryDD, StateDD, StateLabel);
    }

    protected void FindStates(DropDownList CountryDD, DropDownList StateDD, Label StateLabel)
    {
        Country c = Country.FindCountryByCountryID(CountryDD.SelectedValue);
        if (c.States != null)
        {
            StateDiv.Style.Add("display", "block");
            StateDD.DataSource = c.States;
            StateDD.DataBind();
            StateDD.SelectedIndex = 0;
            StateDD.CssClass = "req";
        }
        else
        {
            StateDiv.Style.Add("display", "none");
            StateDD.CssClass = StateDD.CssClass.Replace("req", "");
        }
    }
    protected void CertifiedDiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CertifiedDiver.SelectedValue == "1")
        {
            this.DiveCertTypes.Style.Add("display", "");
            this.NumberOfDivesDiv.Style.Add("display", "block");
            this.LastDiveDateDiv.Style.Add("display", "block");
        }
        else
        {
            this.DiveCertTypes.Style.Add("display", "none");
            this.NumberOfDivesDiv.Style.Add("display", "none");
            this.LastDiveDateDiv.Style.Add("display", "none");
            DiveLevelID.SelectedIndex = 0;
            DiveOrgID.SelectedIndex = 0;
            NumberOfDives.Text = "";
            LastDiveDate.Text = "";
        }
    }

    protected List<OleDbParameter> GenerateCustomerParams()
    {
        String BDayString = "";
        BDayString = cmbDay.Text + "-" + cmbMonth.Text + "-" + cmbYear.Text;

        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("FirstName", OleDbType.VarChar) { Value = FirstName.Text });
        parameters.Add(new OleDbParameter("LastName", OleDbType.VarChar) { Value = LastName.Text });
        parameters.Add(new OleDbParameter("Gender", OleDbType.VarChar) { Value = Gender.SelectedValue });
        parameters.Add(new OleDbParameter("BirthDate", OleDbType.DBDate) { Value = DateTime.Parse(BDayString, System.Globalization.CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy") });
        parameters.Add(new OleDbParameter("Address1", OleDbType.VarChar) { Value = Address1.Text });
        parameters.Add(new OleDbParameter("Address2", OleDbType.VarChar) { Value = Address2.Text });
        parameters.Add(new OleDbParameter("City", OleDbType.VarChar) { Value = City.Text });
        if (StateID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("StateID", OleDbType.Numeric) { Value = Convert.ToInt32(StateID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("StateID", OleDbType.Numeric) { Value = DBNull.Value });
        }
        if (CountryID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("CountryID", OleDbType.Numeric) { Value = Convert.ToInt32(CountryID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("CountryID", OleDbType.Numeric) { Value = DBNull.Value });
        }
        parameters.Add(new OleDbParameter("PostalCode", OleDbType.VarChar) { Value = PostalCode.Text });
        parameters.Add(new OleDbParameter("Email", OleDbType.VarChar) { Value = Email.Text });
        parameters.Add(new OleDbParameter("Phone", OleDbType.VarChar) { Value = Phone.Text });
        parameters.Add(new OleDbParameter("PassportNum", OleDbType.VarChar) { Value = PassportNum.Text });
        if (LanguageID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("LanuguageID", OleDbType.Numeric) { Value = Convert.ToInt32(LanguageID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("LanuguageID", OleDbType.Numeric) { Value = DBNull.Value });
        }
        if (HowHearTextID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("HowHear", OleDbType.Numeric) { Value = Convert.ToInt32(HowHearTextID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("HowHear", OleDbType.Numeric) { Value = DBNull.Value });
        }
        parameters.Add(new OleDbParameter("HowHearSpecific", OleDbType.VarChar) { Value = HowHearSpecific.Text });
        if (WhereStayID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("WhereStayID", OleDbType.Numeric) { Value = Convert.ToInt32(WhereStayID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("WhereStayID", OleDbType.Numeric) { Value = DBNull.Value });
        }
        parameters.Add(new OleDbParameter("RoomOther", OleDbType.VarChar) { Value = RoomOther.Text });
        parameters.Add(new OleDbParameter("RoomNo", OleDbType.VarChar) { Value = RoomNo.Text });
        parameters.Add(new OleDbParameter("EmergencyName", OleDbType.VarChar) { Value = EmergencyName.Text });
        parameters.Add(new OleDbParameter("Relationship", OleDbType.VarChar) { Value = Relationship.Text });
        parameters.Add(new OleDbParameter("EmergencyNumber", OleDbType.VarChar) { Value = EmergencyNumber.Text });
        parameters.Add(new OleDbParameter("EmergencyEmail", OleDbType.VarChar) { Value = EmergencyEmail.Text });
        if (DiveLevelID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("DiveLevelID", OleDbType.Numeric) { Value = Convert.ToInt32(DiveLevelID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("DeveLevelID", OleDbType.Numeric) { Value = DBNull.Value });
        }
        if (DiveOrgID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("DiveOrgID", OleDbType.Numeric) { Value = Convert.ToInt32(DiveOrgID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("DiveOrgID", OleDbType.Numeric) { Value = DBNull.Value });
        }
        if (NumberOfDives.Text != "")
        {
            parameters.Add(new OleDbParameter("NumberOfDives", OleDbType.Numeric) { Value = Convert.ToInt32(NumberOfDives.Text) });
        }
        else
        {
            parameters.Add(new OleDbParameter("NumberOfDives", OleDbType.Numeric) { Value = DBNull.Value });
        }
        if (Insurance.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("Insurance", OleDbType.Boolean) { Value = Convert.ToBoolean(Convert.ToInt32(Insurance.SelectedValue)) });
        }
        else
        {
            parameters.Add(new OleDbParameter("Insurance", OleDbType.Boolean) { Value = DBNull.Value });
        }
        parameters.Add(new OleDbParameter("InsuranceName", OleDbType.VarChar) { Value = InsuranceName.Text });
        if (EmergencyCountryID.SelectedValue != "")
        {
            parameters.Add(new OleDbParameter("EmergencyCountryID", OleDbType.Numeric) { Value = Convert.ToInt32(EmergencyCountryID.SelectedValue) });
        }
        else
        {
            parameters.Add(new OleDbParameter("EmergencyCountryID", OleDbType.Numeric) { Value = DBNull.Value });
        }
        parameters.Add(new OleDbParameter("Facebook", OleDbType.VarChar) { Value = Facebook.Text });
        parameters.Add(new OleDbParameter("DietaryRestrictions", OleDbType.VarChar) { Value = DietaryRestrictions.Text });
        parameters.Add(new OleDbParameter("LastDiveDate", OleDbType.VarChar) { Value = LastDiveDate.Text });
        parameters.Add(new OleDbParameter("ArrivalDate", OleDbType.DBDate) { Value = DateTime.Now.ToShortDateString() });
        return parameters;
    }

    protected void UploadImage(int CustomerID)
    {
        string fileName = FirstName.Text + " " + LastName.Text + "-" + CustomerID.ToString() + ".jpg";
        string imagefolder = "C:/BubbleManager/Customer Photos/";

        if (!Directory.Exists(imagefolder))
        {
            //If it doesn't then we just create it before going any further
            Directory.CreateDirectory(imagefolder);
        }
        //Check if Camera was actually used
        if (this.CameraUsed.Value == "true")
        {
            using (var fs = new FileStream(imagefolder + fileName, FileMode.Create))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    var image = this.imageData.Value;
                    var data = Convert.FromBase64String(image);
                    bw.Write(data);
                    bw.Close();
                }
                fs.Close();
            }
            this.Session["imgFilePath"] = fileName;
        }
        else
        {
            if (FileUpload1.FileName != "")
            {
                // Create a bitmap of the content of the fileUpload control in memory
                Bitmap originalBMP = new Bitmap(FileUpload1.FileContent);

                // Calculate the new image dimensions
                int origWidth = originalBMP.Width;
                int origHeight = originalBMP.Height;
                int maxSize = 240;
                int newHeight = (origHeight * maxSize) / origWidth;
                int newWidth = maxSize;
                if (origHeight > origWidth)
                {
                    newWidth = (origWidth * maxSize) / origHeight;
                    newHeight = maxSize;
                }
                // Create a new bitmap which will hold the previous resized bitmap
                Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
                // Create a graphic based on the new bitmap
                Graphics oGraphics = Graphics.FromImage(newBMP);
                // Set the properties for the new graphic file
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Draw the new graphic based on the resized bitmap
                oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                // Save the new graphic file to the server
                newBMP.Save(imagefolder + fileName);
                //AccessDataSource2.InsertParameters.Add("MyImage", fileName);
                //AccessDataSource2.UpdateParameters.Add("MyImage", fileName);
                this.Session["imgFilePath"] = fileName;
                // Once finished with the bitmap objects, we deallocate them.
                originalBMP.Dispose();
                newBMP.Dispose();
                oGraphics.Dispose();
            }
        }
        // return imgFilePath;
    }

    protected void InitializeCustomer(DataRow dr)
    {
        for (int i = 0; i < dr.ItemArray.Length; i++)
        {
            if (dr.Table.Columns[i].DataType == System.Type.GetType("System.String") && dr[i] == DBNull.Value)
            {
                dr[i] = "";
            }
            if (dr.Table.Columns[i].DataType == System.Type.GetType("System.Int32") && dr[i] == DBNull.Value)
            {
                dr[i] = -1;
            }
            /* if (dr.Table.Columns[i].DataType == System.Type.GetType("System.Boolean") && dr[i].ToString() == "False")
             {
               dr[i] = 0;
             }
             else if (dr.Table.Columns[i].DataType == System.Type.GetType("System.Boolean") && dr[i].ToString() == "True")
             {
                 dr[i] = 1;
             }*/
        }
        //Personal Info Panel
        FirstName.Text = (string)dr["FirstName"];
        LastName.Text = (string)dr["LastName"];
        Email.Text = (string)dr["Email"];
        Phone.Text = (string)dr["Phone"];
        Facebook.Text = (string)dr["Facebook"];
        PassportNum.Text = (string)dr["PassportNum"];
        DietaryRestrictions.Text = (string)dr["DietaryRestrictions"];
        DateTime BirthDate = (DateTime)dr["BirthDate"];
        cmbDay.SelectedValue = BirthDate.Day.ToString();
        cmbMonth.SelectedIndex = BirthDate.Month;
        cmbYear.SelectedValue = BirthDate.Year.ToString();
        Gender.SelectedValue = (string)dr["Gender"];
        //Address Panel
        Address1.Text = (string)dr["Address1"];
        Address2.Text = (string)dr["Address2"];
        City.Text = (string)dr["City"];
        PostalCode.Text = (string)dr["PostalCode"];
        DropDownList CountryDD = (DropDownList)Page.FindControl("CountryID");
        DropDownList StateDD = (DropDownList)Page.FindControl("StateID");
        Label StateLabel = (Label)Page.FindControl("lblStateID");
        CountryDD.SelectedValue = dr["CountryID"].ToString();
        FindStates(CountryDD, StateDD, StateLabel);
        StateDD.SelectedValue = dr["StateID"].ToString();
        //Emergency Contact Panel
        EmergencyName.Text = (string)dr["EmergencyName"];
        Relationship.Text = (string)dr["Relationship"];
        EmergencyNumber.Text = (string)dr["EmergencyNumber"];
        EmergencyEmail.Text = (string)dr["EmergencyEmail"];
        EmergencyCountryID.SelectedValue = dr["EmergencyCountryID"].ToString();
        //Diving Panel
        if (dr["Insurance"] == DBNull.Value)
        {
            Insurance.ClearSelection();
        }
        else
        {
            Insurance.SelectedValue = (dr["Insurance"].ToString() == "False" ? "0" : "1");
            if (Insurance.SelectedValue == "1")
            {
                InsuranceNameDiv.Style.Add("display", "block");
            }
        }
        InsuranceName.Text = (string)dr["InsuranceName"];
        if (dr["DiveLevelID"] == DBNull.Value || dr["DiveLevelID"].ToString() == "0")
        {
            CertifiedDiver.ClearSelection();
        }
        else
        {
            CertifiedDiver.SelectedValue = "1";
            this.DiveCertTypes.Style.Add("display", "");
            this.NumberOfDivesDiv.Style.Add("display", "block");
            this.LastDiveDateDiv.Style.Add("display", "block");
        }
        DiveLevelID.SelectedValue = dr["DiveLevelID"].ToString();
        DiveOrgID.SelectedValue = dr["DiveOrgID"].ToString();
        LastDiveDate.Text = (string)dr["LastDiveDate"];
        NumberOfDives.Text = (dr["NumberOfDives"].ToString() == "-1" ? "" : dr["NumberOfDives"].ToString());
        //Where Staying Panel
        WhereStayID.SelectedValue = dr["WhereStayID"].ToString();
        RoomOther.Text = (string)dr["RoomOther"];
        RoomNo.Text = (string)dr["RoomNo"];
        //Language Panel
        LanguageID.SelectedValue = dr["LanguageID"].ToString();
        //How Hear Panel
        HowHearTextID.SelectedValue = dr["HowHearTextID"].ToString();
        HowHearSpecific.Text = dr["HowHearSpecific"].ToString();
        //Image
        string imagefolder = "C:\\BubbleManager\\Customer Photos\\";
        string srcPath = imagefolder + dr["Image"].ToString();
        if (File.Exists(srcPath))
        {
            this.Session["imgFilePath"] = dr["Image"].ToString();
            FileUploadValidator.ValidationGroup = "";
            FileUploadValidator.Enabled = false;
            FileStream fs = new FileStream(srcPath, FileMode.Open);
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            var base64 = Convert.ToBase64String(byData);
            var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
            imgPreview.Attributes["src"] = imgSrc;
            dvPreview.Style.Add("display", "block");
        }
    }
    public class OleDbTools
    {
        static readonly string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static DataTable GetDataTable(string sqlstr)
        {
            OleDbConnection vcon = new OleDbConnection(conString);
            OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, vcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static string GetSingleSqlValue(string sqlstr)
        {
            OleDbConnection vcon = new OleDbConnection();
            vcon.ConnectionString = conString;
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

        public static int ExecuteSqlStatement(string sqlStr, List<OleDbParameter> parameters)
        {
            // sqlStr = "Update Customer Set FirstName=@FirstName, LastName=@LastName, Gender=@Gender, BirthDate=@BirthDate, Address1=@Address1, Address2=@Address2, City=@City, StateID=@StateID, CountryID=@CountryID, PostalCode=@PostalCode, Email=@Email, Phone=@Phone, PassportNum=@PassportNum, LanguageID=@LanguageID WHERE CustomerID=29007";

            using (OleDbConnection conn = new OleDbConnection(conString))
            using (OleDbCommand cmd = new OleDbCommand(sqlStr, conn))
            {
                if (parameters != null)
                {

                    foreach (OleDbParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);

                    }
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }


    }

    public class Country
    {
        #region fields
        private string _CountryID;
        private string _CountryName;
        private List<State> _States;
        private static List<Country> _Countries;
        #endregion
        #region methods
        public static Country FindCountryByCountryID(string CountryID)
        {
            return _Countries.Find(p => p.CountryID == CountryID);
        }

        public static void InitCountries()
        {
            Countries = new List<Country>();
            DataTable srs = new DataTable();
            srs = OleDbTools.GetDataTable("Select * from Country Left JOIN [State] on State.CountryID = Country.CountryID ORDER BY CountryName, StateName");
            double PrevCountryID = -999;
            foreach (DataRow dr in srs.Rows)
            {
                if (PrevCountryID != Convert.ToDouble(dr["Country.CountryID"]))
                {
                    Countries.Add(new Country(dr["Country.CountryID"].ToString(), dr["CountryName"].ToString(), (dr["StateID"] != DBNull.Value)));

                    PrevCountryID = Convert.ToDouble(dr["Country.CountryID"]);
                }
                if ((dr["StateID"] != DBNull.Value))
                {
                    Countries[Countries.Count - 1]._States.Add(new State(dr["StateID"].ToString(), dr["StateName"].ToString()));
                }
            }

        }
        #endregion

        #region constructors

        public Country(string CountryID)
        {

            _CountryID = CountryID;
            DataTable srs = new DataTable();
            srs = OleDbTools.GetDataTable("Select CountryName from Country Where CountryID = " + _CountryID);
            _CountryName = srs.Rows[0]["CountryName"].ToString();

        }

        public Country(string CountryID, string CountryName, bool hasStates)
        {
            _CountryID = CountryID;
            _CountryName = CountryName;
            if (hasStates)
            {
                _States = new List<State>();
                _States.Add(new State("0"));
            }
        }
        #endregion

        #region properties
        public string CountryID
        {
            get
            {
                return _CountryID;
            }

        }

        public string CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
            }
        }

        public static List<Country> Countries
        {
            get
            {
                return _Countries;
            }
            set
            {
                _Countries = value;
            }
        }
        public List<State> States
        {
            get
            {
                return _States;
            }
            set
            {
                _States = value;
            }
        }


        #endregion
    }

    public class State
    {
        #region fields
        private string _StateID;
        private string _StateName;
        private static List<State> _States;
        #endregion

        #region methods
        static State FindStateByStateID(string StateID)
        {
            if (_States == null)
            {
                return null;
            }
            return _States.Find(s => s.StateID == StateID);
        }
        #endregion
        #region constructors
        public State(string StateID)
        {
            _StateID = StateID;
            if (StateID == "0")
            {
                _StateName = "--Select--";
            }
            else
            {
                DataTable srs;
                srs = OleDbTools.GetDataTable("Select StateName from State Where StateID = " + StateID);
                _StateName = srs.Rows[0]["StateName"].ToString();
            }
        }

        public State(string StateID, string StateName)
        {
            _StateID = StateID;
            if (StateID == "0")
            {
                _StateName = "--Select--";
            }
            else
            {
                _StateName = StateName;
            }
        }

        #endregion
        #region properties
        public string StateID
        {
            get
            {
                return _StateID;
            }

        }

        public string StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }

        public static List<State> States
        {
            get
            {
                return _States;
            }
            set
            {
                _States = value;
            }
        }
        #endregion
    }
}



