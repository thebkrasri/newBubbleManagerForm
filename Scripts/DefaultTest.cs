using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System;
using System.Web.UI.WebControls;

    public partial class DefaultTest : System.Web.UI.Page
    {
        public string useCamera
        {
            get
            {
                if (Request.QueryString["Camera"] == null)
                    return "No";
                else
                    return Request.QueryString["Camera"];
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


                Insurance.LabelAttributes.Add("ID", "lblInsurance");
                CountryID.DataBind();
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
                //

                var Termsdt = new DataTable();
                Termsdt = SQLTools.GetDataTable("SELECT TermsText, ShowTerms, [Language] FROM GlobalSettings, [Language] WHERE GlobalSettings.LanguageID = [Language].LanguageID");

                if (Termsdt.Rows[0]["ShowTerms"] == "True")
                {
                    this.Session["ShowTerms"] = true;
                    pTerms.InnerHtml = Termsdt.Rows[0]["TermsText"].ToString().Replace(System.Environment.NewLine, "<br />");
                }
                else
                {
                    this.Session["ShowTerms"] = false;
                }

                string language = Termsdt.Rows[0]["Language"].ToString();
                optLanguage.SelectedValue = language;
                var sectionsdt = new DataTable();
                var fieldsdt = new DataTable();
                sectionsdt = SQLTools.GetDataTable("SELECT * FROM RegisterFormSection");
                this.Session["sectionsdt"] = sectionsdt;
                fieldsdt = SQLTools.GetDataTable("SELECT * FROM RegisterFormField WHERE RegisterFormSectionID in (Select RegisterFormSectionID From RegisterFormSection WHERE Display=True)");
                this.Session["fieldsdt"] = fieldsdt;
                SetColors();
                ChangeForm();
                if (useCamera == "Yes")
                {
                    FileUploadValidator.Enabled = false;
                }
            }
        }


        protected void SetColors()
        {
            var dt = new DataTable();
            dt = SQLTools.GetDataTable("SELECT SignInFormControl, SignInFormColor FROM SignInFormColor");
            foreach (DataRow row in dt.Rows)
            {
                string myControl = row["SignInFormControl"].ToString();
                if (myControl == "Page Background")
                {
                    pagebody.Attributes.Add("bgcolor", row["SignInFormColor"].ToString());
                }
                else
                {

                    this.Session[myControl + "Color"] = row["SignInFormColor"].ToString();
                }
            }
            PhotoPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
            PhotoPanel.BorderColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BorderColor"].ToString());
            PersonalInfoPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
            PersonalInfoPanel.BorderColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BorderColor"].ToString());
            AddressPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BackgroundColor"].ToString());
            AddressPanel.BorderColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section BorderColor"].ToString());
            lblPersonalInfoPanel.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section Header TextColor"].ToString());
            lblAddressPanel.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section Header TextColor"].ToString());
            cbCertifiedDiver.ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section TextColor"].ToString());

        }

        protected void ChangeForm()
        {
            DataTable sectionsdt = this.Session["sectionsdt"] as DataTable;
            DataTable fieldsdt = this.Session["fieldsdt"] as DataTable;
            string lang = optLanguage.SelectedItem.Value;
            string languageLabel = lang + "Label";
            int controlNameIndex = sectionsdt.Columns.IndexOf("ControlName");
            int displayIndex = sectionsdt.Columns.IndexOf("Display");
            int LanguageLabelIndex = sectionsdt.Columns.IndexOf(languageLabel);
            foreach (DataRow row in sectionsdt.Rows)
            {
                string controlName = row["controlNameIndex"].ToString();
                string display = row["displayIndex"].ToString();
                string langLabel = row["LanguageLabelIndex"].ToString();
                Control MyControl = Page.FindControl(controlName);
                if (MyControl != null)
                {
                    if (display == "False")
                    {
                        MyControl.Visible = false;
                    }
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
                    ((Label)MyLabel).ForeColor = System.Drawing.ColorTranslator.FromHtml(this.Session["Section Header TextColor"].ToString());

                    if (display == "False")
                    {
                        MyLabel.Visible = false;
                    }

                }
            }
            int fieldControlNameIndex = fieldsdt.Columns.IndexOf("ControlName");
            int displayTypeIndex = fieldsdt.Columns.IndexOf("DisplayType");
            int fieldLanguageLabelIndex = fieldsdt.Columns.IndexOf(languageLabel);
            string message = "";
            foreach (DataRow row in fieldsdt.Rows)
            {
                string controlName = row.ItemArray[fieldControlNameIndex].ToString();
                string langLabel = row.ItemArray[fieldLanguageLabelIndex].ToString();
                string displayType = row.ItemArray[displayTypeIndex].ToString();
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
                        label = label.Substring(0, label.Length - 1) + "*";
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
        }
        protected void optLanguage_SelectedIndexChanged(Object Sender, EventArgs E)
        {
            ChangeForm();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "showTab(currentTab);", true);

        }
        protected void prevCustClick(Object Sender, EventArgs E)
        {
            if (CustomerNumber.Text == null)
            {
                CustomerNumberError.Visible = true;
                CustomerNumberError.Text = "Please provide a customer number.";
                FirstName.Text = "";
                LastName.Text = "";
                return;
            }
            float output;
            if (!float.TryParse(CustomerNumber.Text, out output))
            {
                CustomerNumberError.Visible = true;
                CustomerNumberError.Text = "Please enter a valid number.";
                FirstName.Text = "";
                LastName.Text = "";
                return;
            }
            Customer customer = new Customer(CustomerNumber.Text);
            this.Session["Customer"] = customer;
            foreach (Control x in this.Controls)
            {
                if (customer.x != null)
                {
                    if (x is TextBox)
                    {
                        x.Text = customer.x;
                    }
                    if (x is DropDownList)
                    {
                        x.SelectedIndex = customer.x;
                    }
                    if (x is CheckBox)
                    {
                        if (customer.x = 0)
                        {
                            x.Checked = false;

                        }
                        if (customer.x = 1)
                        {
                            x.Checked = true;
                        }
                    }
                }
            }
        }

        protected void Button1_Click(Object Sender, EventArgs E)
        {
            Page.Validate("Submit");
            if (Page.IsValid)
            {
                InsertShipper();
            }
            else
            {
                ShowMessage("Missing Fields", "Please fill in ALL required fields!");
            }
        }

        private void InsertShipper()
        {

            String BDayString = "";
            BDayString = cmbDay.Text + "-" + cmbMonth.Text + "-" + cmbYear.Text;

            // Define the name and type of the client scripts on the page.
            String csname1 = "PopupScript";
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                String cstext1 = "alert('Hello World');";
                cs.RegisterStartupScript(cstype, csname1, cstext1, true);
            }

            AccessDataSource2.InsertCommand = "INSERT INTO Customer (FirstName, LastName, Gender, BirthDate ,Address1,Address2,City, StateID,CountryID,PostalCode,Email, Phone, PassportNum, LanguageID, HowHearTextID, HowHearSpecific, WhereStayID, RoomOther,RoomNo, EmergencyName, Relationship, EmergencyNumber, EmergencyEmail, DiveLevelID, DiveOrgID, NumberOfDives, Insurance, InsuranceName, EmergencyCountryID, ArrivalDate, [image]) VALUES (@FirstName,@LastName, @Gender, @BirthDate, @Address1,@Address2,@City,@StateID, @Country,@PostalCode,@Email, @Phone, @PassportNum, @LanguageID, @HowHear, @HowHearSpecific, @WhereStayID, @RoomOther, @RoomNo, @EmergencyName, @Relationship, @EmergencyNumber, @EmergencyEmail, @DiveLevelID, @DiveOrgID, @NumberOfDives, @EmergencyCountryID, @ArrivalDate, @Insurance, @InsuranceName, @MyImage)";
            AccessDataSource2.UpdateCommand = "Update Customer Set FirstName=@FirstName, LastName=@LastName, Gender=@Gender, BirthDate=@BirthDate, Address1=@Address1,Address2=@Address2,City=@City, StateID=@StateID, CountryID=@CountryID, PostalCode=@PostalCode,Email=@Email, Phone=@Phone, PassportNum=@PassportNum, LanguageID=@LanguageID, HowHearTextID=@HowHearTextID, HowHearSpecific=@HowHearSpecific, WhereStayID =@WhereStayID, RoomOther=@RoomOther,RoomNo=@RoomNo, EmergencyName=@EmergencyName, Relationship=@Relationship, EmergencyNumber=@EmergencyNumber, EmergencyEmail=@EmergencyEmail, DiveLevelID=@DiveLevelID, DiveOrgID=@DiveOrgID, NumberOfDives=@NumberOfDives, Insurance=@Insurance, InsuranceName=@InsuranceName, EmergencyCountryID=@EmergencyCountryID, ArrivalDate=@ArrivalDate, [image]=@MyImage WHERE CustomerID=" + CustomerNumberHidden.Value;
            AccessDataSource2.InsertParameters.Add("FirstName", FirstName.Text);
            AccessDataSource2.InsertParameters.Add("LastName", LastName.Text);
            AccessDataSource2.InsertParameters.Add("Gender", Gender.SelectedValue);
            AccessDataSource2.InsertParameters.Add("BirthDate", DateTime.Parse(BDayString, System.Globalization.CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy"));
            AccessDataSource2.InsertParameters.Add("Address1", Address1.Text);
            AccessDataSource2.InsertParameters.Add("Address2", Address2.Text);
            AccessDataSource2.InsertParameters.Add("City", City.Text);
            AccessDataSource2.InsertParameters.Add("StateID", StateID.SelectedValue);
            AccessDataSource2.InsertParameters.Add("CountryID", CountryID.SelectedValue);
            AccessDataSource2.InsertParameters.Add("PostalCode", PostalCode.Text);
            AccessDataSource2.InsertParameters.Add("Email", Email.Text);
            AccessDataSource2.InsertParameters.Add("Phone", Phone.Text);
            AccessDataSource2.InsertParameters.Add("PassportNum", PassportNum.Text);
            AccessDataSource2.InsertParameters.Add("LanuguageID", LanguageID.SelectedValue);
            AccessDataSource2.InsertParameters.Add("HowHear", HowHearTextID.SelectedValue);
            AccessDataSource2.InsertParameters.Add("HowHearSpecific", HowHearSpecific.Text);
            AccessDataSource2.InsertParameters.Add("WhereStayID", WhereStayID.SelectedValue);
            AccessDataSource2.InsertParameters.Add("RoomOther", RoomOther.Text);
            AccessDataSource2.InsertParameters.Add("RoomNo", RoomNo.Text);
            AccessDataSource2.InsertParameters.Add("EmergencyName", EmergencyName.Text);
            AccessDataSource2.InsertParameters.Add("Relationship", Relationship.Text);
            AccessDataSource2.InsertParameters.Add("EmergencyNumber", EmergencyNumber.Text);
            AccessDataSource2.InsertParameters.Add("EmergencyEmail", EmergencyEmail.Text);
            AccessDataSource2.InsertParameters.Add("DiveLevelID", DiveLevelID.SelectedValue);
            AccessDataSource2.InsertParameters.Add("DiveOrgID", DiveOrgID.SelectedValue);
            AccessDataSource2.InsertParameters.Add("NumberOfDives", NumberOfDives.Text);
            AccessDataSource2.InsertParameters.Add("Insurance", "1");
            AccessDataSource2.InsertParameters.Add("InsuranceName", InsuranceName.Text);
            AccessDataSource2.InsertParameters.Add("EmergencyCountryID", EmergencyCountryID.Text);
            AccessDataSource2.InsertParameters.Add("ArrivalDate", DateTime.Now.ToShortDateString());
            AccessDataSource2.UpdateParameters.Add("FirstName", FirstName.Text);
            AccessDataSource2.UpdateParameters.Add("LastName", LastName.Text);
            AccessDataSource2.UpdateParameters.Add("Gender", Gender.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("BirthDate", BDayString);
            AccessDataSource2.UpdateParameters.Add("Address1", Address1.Text);
            AccessDataSource2.UpdateParameters.Add("Address2", Address2.Text);
            AccessDataSource2.UpdateParameters.Add("City", City.Text);
            AccessDataSource2.UpdateParameters.Add("StateID", StateID.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("CountryID", CountryID.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("PostalCode", PostalCode.Text);
            AccessDataSource2.UpdateParameters.Add("Email", Email.Text);
            AccessDataSource2.UpdateParameters.Add("Phone", Phone.Text);
            AccessDataSource2.UpdateParameters.Add("PassportNum", PassportNum.Text);
            AccessDataSource2.UpdateParameters.Add("LanuguageID", LanguageID.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("HowHear", HowHearTextID.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("HowHearSpecific", HowHearSpecific.Text);
            AccessDataSource2.UpdateParameters.Add("WhereStayID", WhereStayID.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("RoomOther", RoomOther.Text);
            AccessDataSource2.UpdateParameters.Add("RoomNo", RoomNo.Text);
            AccessDataSource2.UpdateParameters.Add("EmergencyName", EmergencyName.Text);
            AccessDataSource2.UpdateParameters.Add("Relationship", Relationship.Text);
            AccessDataSource2.UpdateParameters.Add("EmergencyNumber", EmergencyNumber.Text);
            AccessDataSource2.UpdateParameters.Add("EmergencyEmail", EmergencyEmail.Text);
            AccessDataSource2.UpdateParameters.Add("DiveLevelID", DiveLevelID.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("DiveOrgID", DiveOrgID.SelectedValue);
            AccessDataSource2.UpdateParameters.Add("NumberOfDives", NumberOfDives.Text);
            AccessDataSource2.UpdateParameters.Add("Insurance", "1");
            AccessDataSource2.UpdateParameters.Add("InsuranceName", InsuranceName.Text);
            AccessDataSource2.UpdateParameters.Add("EmergencyCountryID", EmergencyCountryID.Text);
            AccessDataSource2.UpdateParameters.Add("ArrivalDate", DateTime.Now.ToShortDateString());


            DataView dv = (DataView)LatestCustomerDataSource.Select(DataSourceSelectArguments.Empty);
            int lastID = (int)dv.Table.Rows[0][0];
            string fileName = "";
            if (CustomerNumberHidden.Value == null || CustomerNumberHidden.Value == "")
                fileName = FirstName.Text + " " + LastName.Text + "-" + lastID + ".jpg";
            else
                fileName = FirstName.Text + " " + LastName.Text + "-" + CustomerNumberHidden.Value + ".jpg";

            //dv = (DataView)ImageFolderDataSource.Select(DataSourceSelectArguments.Empty);
            string imagefolder = "C:/BubbleManager/Customer Photos/";
            //(string)dv.Table.Rows[0][0];

            if (!Directory.Exists(imagefolder))
            {
                //If it doesn't then we just create it before going any further
                Directory.CreateDirectory(imagefolder);
            }

            if (useCamera == "Yes")
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
                AccessDataSource2.InsertParameters.Add("MyImage", fileName);
                AccessDataSource2.UpdateParameters.Add("MyImage", fileName);

            }
            else
            {
                if (FileUpload1.FileName != "")
                {


                    //UpdateImageDataSource.UpdateParameters[0].DefaultValue = fileName;
                    // UpdateImageDataSource.UpdateParameters[1].DefaultValue = "" + lastID;

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
                    //int sngRatio = origWidth / origHeight;
                    //int newWidth = 240;
                    //int newHeight = newWidth / sngRatio;


                    // Create a new bitmap which will hold the previous resized bitmap
                    Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
                    // Create a graphic based on the new bitmap
                    Graphics oGraphics = Graphics.FromImage(newBMP);

                    // Set the properties for the new graphic file
                    oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // Draw the new graphic based on the resized bitmap
                    oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

                    //dv = (DataView)ImageFolderDataSource.Select(DataSourceSelectArguments.Empty);
                    //string imagefolder = (string)dv.Table.Rows[0][0];
                    // Save the new graphic file to the server
                    newBMP.Save(imagefolder + fileName);
                    AccessDataSource2.InsertParameters.Add("MyImage", fileName);
                    AccessDataSource2.UpdateParameters.Add("MyImage", fileName);

                    // Once finished with the bitmap objects, we deallocate them.
                    originalBMP.Dispose();
                    newBMP.Dispose();
                    oGraphics.Dispose();
                    //UpdateImageDataSource.Update();
                }
                else
                {
                    AccessDataSource2.InsertParameters.Add("MyImage", "");
                    AccessDataSource2.UpdateParameters.Add("MyImage", "");
                }
            }
            if (CustomerNumberHidden.Value == null || CustomerNumberHidden.Value == "")
                AccessDataSource2.Insert();
            else
                AccessDataSource2.Update();

            Response.Redirect("FormSubmitted.aspx");
        }

        protected void CountryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataView dv = (System.Data.DataView)this.HasStateDataSource.Select(DataSourceSelectArguments.Empty);
            string hasState = dv[0][0].ToString();
            if (hasState == "True")
            {
                this.lblStateID.Style.Add("display", "");
                StateID.Style.Add("display", "");
                StateID.DataBind();
                StateID.Items.Insert(0, new ListItem("--Select--", "0"));
                StateID.SelectedIndex = -1;
                StateValidator.Enabled = true;
            }
            else
            {
                this.lblStateID.Style.Add("display", "none");
                StateID.Style.Add("display", "none");
                StateValidator.Enabled = false;
            }
        }

        protected void cbCertifiedDiver_Checked(object sender, EventArgs e)
        {
            if (cbCertifiedDiver.Checked)
            {
                this.DiveCertTypes.Style.Add("display", "");
                this.NumberOfDivesDiv.Style.Add("display", "block");
            }
            else
            {
                this.DiveCertTypes.Style.Add("display", "none");
                this.NumberOfDivesDiv.Style.Add("display", "none");
            }
        }
    }