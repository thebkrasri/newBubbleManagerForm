<%@Page Title="Bubble Manager" Language="C#" AutoEventWireup="true" CodeFile="DefaultCamera.aspx.cs" Inherits="DefaultCamera" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">



<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Raleway" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>

    <script src="DefaultCamera.js" type="text/javascript"></script>

    <title>Bubble Manager</title>
</head>

<body runat="server" id="pagebody">
    <form runat="server">


        <asp:SqlDataSource id="LanguageDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [LanguageID], [Language] from [Language] ORDER BY [Language]">
        </asp:SqlDataSource>


        <asp:SqlDataSource id="CountryDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [CountryID], [CountryName] from Country ORDER BY [CountryName]">
        </asp:SqlDataSource>

        <asp:SqlDataSource id="HowHearDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [HowHearID], [HowHear] from [HowHear] ORDER BY [HowHear]" DataSourceMode="DataSet">
        </asp:SqlDataSource>

        <asp:SqlDataSource id="WhereStayDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [WhereStayID], [WhereStay] from [WhereStay] ORDER BY [WhereStay]">
        </asp:SqlDataSource>

        <asp:SqlDataSource id="DiveLevelDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [DiveLevelID], [DiveLevel] from [DiveLevel] ORDER BY [DiveLevel]">

        </asp:SqlDataSource>


        <asp:SqlDataSource id="DiveOrgDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [DiveOrgID], [DiveOrg] from [DiveOrg] ORDER BY [DiveOrg]">
        </asp:SqlDataSource>


        <asp:SqlDataSource id="YearDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM tblYear UNION Select 0, 'Year' from GlobalSettings order by yearID">
        </asp:SqlDataSource>


        <asp:SqlDataSource id="MonthDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT MonthVal, MonthEng, MonthID FROM tblMonth UNION Select 0, 'Month', 0 from GlobalSettings order by MonthID">
        </asp:SqlDataSource>


        <asp:SqlDataSource id="DayDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM tblDay UNION Select 0, 'Day' from GlobalSettings order by DayID">
        </asp:SqlDataSource>


        <asp:SqlDataSource id="HasStateDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT HasState from Country WHERE CountryID = ?">
            <SelectParameters>
                <asp:ControlParameter ControlID="CountryID" Name="CountryID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>

        </asp:SqlDataSource>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:SqlDataSource id="StatesDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [StateID], [StateName] from [State] WHERE CountryID = ? ORDER BY StateName">
            <SelectParameters>
                <asp:ControlParameter ControlID="CountryID" Name="CountryID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource id="LatestCustomerDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT TOP 1 CustomerID from [Customer] ORDER BY [CustomerID] DESC">
        </asp:SqlDataSource>

        <asp:SqlDataSource id="ImageFolderDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [SavedImagesFolder] from [GlobalSettings]">
        </asp:SqlDataSource>

        <asp:SqlDataSource id="UpdateImageDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            UpdateCommand="UPDATE Customer Set `image`= @ImageText WHERE CustomerID = @CustomerID">
            <UpdateParameters>
                <asp:Parameter Name="ImageText" Type="String" />
                <asp:Parameter Name="CustomerID" Type="int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource id="AccessDataSource2" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
        </asp:SqlDataSource>

        <center>
            <asp:RadioButtonList ForeColor="white" BorderColor="white" BorderStyle="solid" BorderWidth="2px"
                BackColor="black" RepeatDirection="Horizontal" AutoPostBack="true"
                OnSelectedIndexChanged="optLanguage_SelectedIndexChanged" ID="optLanguage" runat="server"
                CssClass="RadioButton">
                <asp:ListItem Value="English">English</asp:ListItem>
                <asp:ListItem Value="Spanish">Español</asp:ListItem>
            </asp:RadioButtonList>
        </center>

      



        <asp:Panel ID="PreviousPanel" runat="server">




        </asp:Panel>

        <div class="row">
            <br />
            <h3>
                <asp:label runat="server" ID="lblPersonalInfo">Personal Info</asp:Label></span><br />
            </h3>
        </div>





        <asp:Panel ID="PersonalInfoPanel" runat="server" CssClass="pnlCSS">
            <asp:HiddenField runat="server" ID="TermsTextID" Value="test" />

            <div class="row">
                <div class="col-12">
                    <asp:label runat="server" ID="lblFirstName" Text="lblFirstName"></asp:label><span>
                        <asp:RequiredFieldValidator runat="server" ID="FirstNameValidator" ControlToValidate="FirstName"
                            Display="Dynamic" ErrorMessage="Please Fill in First Name" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="FirstName" runat="server" AutoCompleteType="FirstName" cssClass="tbCSS"
                        ValidateRequestMode="Enabled" />
                    <br />
                    <asp:label runat="server" ID="lblLastName" Text="lblLastName"></asp:label><span>
                        <asp:RequiredFieldValidator runat="server" ID="LastNameValidator" ControlToValidate="LastName"
                            Display="Dynamic" ErrorMessage="Please Fill in Last Name" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="LastName" runat="server" AutoCompleteType="LastName" cssClass="tbCSS" />
                    <br />
                    <asp:label runat="server" ID="lblBirthDate" Text="lblBirthDate"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="cmbDayValidator" runat="server" ControlToValidate="cmbDay"
                            ErrorMessage="Please Select a Birth Day" Display="Dynamic" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" InitialValue="0" /></span>
                    <span>
                        <asp:RequiredFieldValidator ID="cmbMonthValidator" runat="server" ControlToValidate="cmbMonth"
                            ErrorMessage="Please Select a Birth Month" Display="Dynamic" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" InitialValue="0" /></span>
                    <span>
                        <asp:RequiredFieldValidator ID="cmbYearValidator" runat="server" ControlToValidate="cmbYear"
                            ErrorMessage="Please Select a Birth Year" Display="Dynamic" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" InitialValue="0" /></span>

                    <asp:DropDownList ID="cmbDay" DataSourceID="DayDataSource" DataTextField="Day"
                        DataValueField="DayID" runat="server" CssClass="ddCSS">

                    </asp:DropDownList>
                    <asp:DropDownList ID="cmbMonth" DataSourceID="MonthDataSource" DataTextField="MonthEng"
                        DataValueField="MonthVal" runat="server" CssClass="ddCSS">

                    </asp:DropDownList>
                    <asp:DropDownList ID="cmbYear" runat="server" DataSourceID="YearDataSource" DataTextField="YearText"
                        DataValueField="YearID" CssClass="ddCSS">

                    </asp:DropDownList>
                    <br />
                    <asp:label runat="server" ID="lblGender" Text="lblGender"></asp:label>
                    <span>
                        <asp:RequiredFieldValidator ID="GenderValidator" runat="server" ControlToValidate="Gender"
                            ErrorMessage="Please Select a Gender" Display="Dynamic" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" InitialValue="0" /></span>
                    <asp:DropDownList ID="Gender" runat="server">
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                    </asp:DropDownList>

                    <br />
                    <asp:label runat="server" ID="lblEmail" Text="lblEmail"></asp:label>
                    <span>
                        <asp:RegularExpressionValidator ID="RegValEmailValidator" runat="server"
                            ControlToValidate="Email" Display="Dynamic" ErrorMessage="Please enter valid email"
                            ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" />
                        <asp:RequiredFieldValidator runat="server" ID="EmailValidator" ControlToValidate="Email"
                            Display="Dynamic" ErrorMessage="Please Fill in Email" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" />
                    </span>
                    <asp:TextBox ID="Email" runat="server" AutoCompleteType="Email" CssClass="tbCSS" />

                    <br />



                    <asp:label runat="server" ID="lblPhone" Text="lblPhone"></asp:label>
                    <span>
                        <asp:RequiredFieldValidator ID="PhoneValidator" runat="server" ControlToValidate="Phone"
                            Display="Dynamic" ErrorMessage="Please fill in a phone number" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>

                    <asp:TextBox ID="Phone" runat="server" AutoCompleteType="HomePhone" CssClass="tbCSS" />


                    <asp:label runat="server" ID="lblPassportNum" Text="lblPassPortNum"></asp:label>
                    <span>
                        <asp:RequiredFieldValidator ID="PassportNumValidator" runat="server"
                            ControlToValidate="PassportNum" Display="Dynamic"
                            ErrorMessage="Please fill in a passport number." CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="PassportNum" runat="server" CssClass="tbCSS" />

                </div>
            </div>
        </asp:Panel>

        <div class="row">
            <h3><span>
                    <asp:label runat="server" ID="lblMailingAddress">Mailing Address</asp:label>
                </span></h3>
        </div>

        <asp:Panel ID="AddressPanel" runat="server" CssClass="pnlCSS">
            <div class="row">
                <div class="col-12">
                    <asp:label runat="server" ID="lblAddress1" Text="lblAddress1"></asp:label>
                    <span>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="Address1" Display="Dynamic"
                            ErrorMessage="Please Fill in Street Address, Not Email!" CssClass="ReqFieldCSS"
                            ValidationExpression="^((?!@).)*$" ValidationGroup="Submit" />
                        <asp:RequiredFieldValidator ID="Address1Validator" runat="server" ControlToValidate="Address1"
                            Display="Dynamic" ErrorMessage="Please Fill in Street Address" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="Address1" runat="server" AutoCompleteType="HomeStreetAddress" CssClass="tbCSS" />
                    <br />
                    <asp:label runat="server" ID="lblAddress2" Text="lblAddress2"></asp:label>
                    <span>
                        <asp:RequiredFieldValidator ID="Address2Validator" runat="server" ControlToValidate="Address2"
                            Display="Dynamic" ErrorMessage="Please Fill in Street Address 2" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="Address2" runat="server" CssClass="tbCSS" />
                    <br />
                    <asp:label runat="server" ID="lblCity" Text="lblCity"></asp:label>
                    <span>
                        <asp:RegularExpressionValidator ID="RegExpressCityValidator" runat="server"
                            ControlToValidate="City" Display="Dynamic"
                            ErrorMessage="Please enter City in Alpha-Latin Characters"
                            ValidationExpression="^([A-Za-z\u00C0-\u00D6\u00D8-\u00f6\u00f8-\u00ff\s]*)$"
                            CssClass="ReqFieldCSS" ValidationGroup="Submit" />
                        <asp:RequiredFieldValidator runat="server" ID="CityValidator" ControlToValidate="City"
                            Display="Dynamic" ErrorMessage="Please Fill in City" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="City" runat="server" AutoCompleteType="HomeCity" CssClass="tbCSS"></asp:TextBox>
                    <br />
                    <asp:label runat="server" ID="lblPostalCode" Text="lblPostalCode"></asp:label>
                    <span>
                        <asp:RequiredFieldValidator ID="PostalCodeValidator" runat="server"
                            ControlToValidate="PostalCode" Display="Dynamic" ErrorMessage="Please Fill in Postal Code"
                            CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="PostalCode" runat="server" AutoCompleteType="HomeZipCode" CssClass="tbCSS" />
                    <asp:UpdatePanel ID="StateUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:label runat="server" ID="lblCountryID" Text="lblCountryID"></asp:label>
                            <span>
                                <asp:RequiredFieldValidator ID="CountryIDValidator" runat="server"
                                    ControlToValidate="CountryID" ErrorMessage="Please Select a Country"
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit"
                                    InitialValue="0" /></span>
                            <asp:DropDownList ID="CountryID" runat="server" AutoPostBack="True"
                                datasourceid="CountryDataSource" datatextfield="CountryName" datavaluefield="CountryID"
                                OnSelectedIndexChanged="CountryID_SelectedIndexChanged" CssClass="ddCSS" />
                </div>
            </div>
            <div class="row">
                <asp:label runat="server" ID="lblStateID" Text="State/Province*" AutoPostBack="True"
                    style="display:none;" />
                <span>
                    <asp:RequiredFieldValidator ID="StateValidator" runat="server" ControlToValidate="StateID"
                        ErrorMessage="Please Select a State" Display="Dynamic" CssClass="ReqFieldCSS"
                        ValidationGroup="Submit" InitialValue="0" Enabled="false" /></span>
                <asp:DropDownList ID="StateID" runat="server" AutoPostBack="True" datasourceid="StatesDataSource"
                    datatextfield="StateName" datavaluefield="StateID" CssClass="ddCSS" style="display:none;" />

            </div>
            </ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>

        <h3>
            <asp:label runat="server" ID="lblEmergencyContactDiv" Text="lblEmergencyContactDiv"></asp:Label>
        </h3>

        <asp:Panel ID="EmergencyContactDiv" runat="server" CssClass="pnlCSS">
            <div class="row">
                <div class="col-12">
                    <asp:label runat="server" ID="lblEmergencyName" Text="lblEmergencyName"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="EmergencyNameValidator" runat="server"
                            ControlToValidate="EmergencyName" ErrorMessage="Please enter an emergency contact name"
                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="EmergencyName" runat="server" CssClass="tbCSS" />


                    <asp:label runat="server" ID="lblRelationship" Text="lblRelationship"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="RelationshipValidator" runat="server"
                            ControlToValidate="Relationship" ErrorMessage="Please enter an emergency relationship"
                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="Relationship" runat="server" CssClass="tbCSS" />

                    <asp:label runat="server" ID="lblEmergencyCountryID" Text="lblEmergencyCountryID"></asp:label>
                    <span>
                        <asp:RequiredFieldValidator ID="EmergencyCountryIDValidator" runat="server"
                            ControlToValidate="EmergencyCountryID" ErrorMessage="Please Select a Country"
                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                    <asp:DropDownList ID="EmergencyCountryID" runat="server" datasourceid="CountryDataSource"
                        datatextfield="CountryName" datavaluefield="CountryID" CssClass="ddCSS" />



                    <asp:label runat="server" ID="lblEmergencyNumber" Text="lblEmergencyNumber"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="EmergencyNumberValidator" runat="server"
                            ControlToValidate="EmergencyNumber" ErrorMessage="Please enter an emergency number"
                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="EmergencyNumber" runat="server" CssClass="tbCSS" />

                    <asp:label runat="server" ID="lblEmergencyEmail" Text="lblEmergencyEmail"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="EmergencyEmailValidator" runat="server"
                            ControlToValidate="EmergencyEmail" ErrorMessage="Please enter an emergency email"
                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="EmergencyEmail" runat="server" CssClass="tbCSS" />

                </div>
            </div>
        </asp:Panel>


        <h3>
            <asp:label runat="server" ID="lblCertifiedDiverDiv" Text="lblCertifiedDiverDiv"></asp:Label>
        </h3>

        <asp:Panel ID="CertifiedDiverDiv" runat="server" CssClass="pnlCSS">
            <asp:UpdatePanel ID="CertifiedDiverUpdatePanel" runat="server">
                <ContentTemplate>
                    <div class="row">

                        <asp:CheckBox id="cbCertifiedDiver" AutoPostBack="True"
                            Text="Check if you are already a Certified Diver" TextAlign="Right" Checked="False"
                            OnCheckedChanged="cbCertifiedDiver_Checked" runat="server" />


                    </div>
                    <div id="DiveCertTypes" class="row" style="display:none;" runat="server">
                        <div class="col-6">
                            <asp:label runat="server" ID="lblDiveOrgID" Text="lblDiveOrgID"></asp:Label>
                            <asp:DropDownList ID="DiveOrgID" runat="server" DataSourceID="DiveOrgDataSource"
                                DataTextField="DiveOrg" DataValueField="DiveOrgID">
                            </asp:DropDownList>
                            <span>
                                <asp:RequiredFieldValidator ID="DiveOrgIDValidator" runat="server"
                                    ControlToValidate="DiveOrgID" ErrorMessage="Please enter a dive organization."
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" InitialValue=0 />
                            </span>
                        </div>
                        <div class="col-6">
                            <asp:label runat="server" ID="lblDiveLevelID" Text="lblDiveLevelID"></asp:Label>
                            <asp:DropDownList ID="DiveLevelID" runat="server" DataSourceID="DiveLevelDataSource"
                                DataTextField="DiveLevel" DataValueField="DiveLevelID">
                            </asp:DropDownList>
                            <span>
                                <asp:RequiredFieldValidator ID="DiveLevelIDValidator" runat="server"
                                    ControlToValidate="DiveLevelID" ErrorMessage="Please enter a dive level."
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" InitialValue=0 />
                            </span>
                        </div>
                        <br>
                        <span>
                            <asp:label runat="server" ID="lblNumberOfDives" Text="lblNumberOfDives"></asp:Label>
                            <asp:TextBox ID="NumberOfDives" runat="server" CssClass="tbCSS" />
                            <span>
                                <asp:RequiredFieldValidator ID="NumberOfDivesValidator" runat="server"
                                    ControlToValidate="NumberOfDives" Display="Dynamic"
                                    ErrorMessage="Please fill in number of dives." CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                        </span>
                        <br>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>


        <div class="row" runat="server">
            <h3>
                <asp:label runat="server" ID="lblLanguageDiv" Text="lblLanguageDiv"></asp:Label>
            </h3>


            <asp:Panel ID="LanguageDiv" runat="server" CssClass="pnlCSS">
                <div class="row">
                    <div class="col-12">
                        <asp:label runat="server" ID="lblLanguageID" Text="lblLanguageID"></asp:Label>
                        <span>
                            <asp:RequiredFieldValidator ID="LanguageIDValidator" runat="server"
                                ControlToValidate="LanguageID" ErrorMessage="Please enter a prefered language"
                                Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" InitialValue="0" />
                        </span>
                        <asp:DropDownList ID="LanguageID" runat="server" DataSourceID="LanguageDataSource"
                            DataTextField="Language" DataValueField="LanguageID">
                        </asp:DropDownList>

                    </div>
                </div>
            </asp:Panel>
        </div>

        <h3>
            <asp:label runat="server" ID="lblWhereStayDiv" Text="lblWhereStayDiv"></asp:Label>
        </h3>


        <asp:Panel ID="WhereStayDiv" runat="server" CssClass="pnlCSS">
            <div class="row">
                <div class="col-12">
                    <asp:label runat="server" ID="lblWhereStayID" Text="lblWhereStayID"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="WhereStayIDValidator" runat="server"
                            ControlToValidate="WhereStayID" ErrorMessage="Please enter a resort/hotel" Display="Dynamic"
                            CssClass="ReqFieldCSS" ValidationGroup="Submit" InitialValue="0" /></span>
                    <asp:DropDownList ID="WhereStayID" runat="server" DataSourceID="WhereStayDataSource"
                        DataTextField="WhereStay" DataValueField="WhereStayID">
                    </asp:DropDownList>

                    <span>
                        <asp:label runat="server" ID="lblRoomOther" Text="lblRoomOther"></asp:Label>
                    </span>
                    <span>
                        <asp:RequiredFieldValidator ID="RoomOtherValidator" runat="server" ControlToValidate="RoomOther"
                            ErrorMessage="Please enter other room info" Display="Dynamic" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="RoomOther" runat="server" CssClass="tbCSS" />

                    <span>
                        <asp:label runat="server" ID="lblRoomNo" Text="lblRoomNo"></asp:Label>
                    </span>
                    <span>
                        <asp:RequiredFieldValidator ID="RoomNoValidator" runat="server" ControlToValidate="RoomNo"
                            ErrorMessage="Please enter a room number" Display="Dynamic" CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="RoomNo" runat="server" CssClass="tbCSS" />
                </div>
            </div>
        </asp:Panel>


        <h3>
            <asp:label runat="server" ID="lblHowHearDiv" Text="lblHowHearDiv"></asp:label><br />
        </h3>

        <asp:Panel ID="HowHearDiv" runat="server" cssClass="pnlCSS">
            <div class="row">
                <div class="col-12">
                    <span>
                        <asp:RequiredFieldValidator ID="HowHearTextIDValidator" runat="server"
                            ControlToValidate="HowHearTextID" Display="Dynamic"
                            ErrorMessage="Please fill in how you heard about us." CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" InitialValue="0" /></span>
                    <asp:label runat="server" ID="lblHowHearTextID" Text="lblHowHearTextID"></asp:Label>
                    <asp:DropDownList ID="HowHearTextID" runat="server" DataSourceID="HowHearDataSource"
                        DataTextField="HowHear" DataValueField="HowHearID">
                    </asp:DropDownList>
                    <asp:label runat="server" ID="lblHowHearSpecific" Text="lblHowHearSpecific"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="HowHearSpecificValidator" runat="server"
                            ControlToValidate="HowHearSpecific" Display="Dynamic"
                            ErrorMessage="Please fill in a other how hear info." CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="HowHearSpecific" runat="server" CssClass="tbCSS" />
                </div>
            </div>
        </asp:Panel>


        <h3>
            <asp:label runat="server" ID="lblInsuranceDiv" Text="lblInsuranceDiv"></asp:label><br />
        </h3>

        <asp:Panel ID="InsuranceDiv" runat="server" cssClass="pnlCSS">
            <div class="row">
                <div class="col-12">


                    <asp:label runat="server" ID="lblInsurance" Text="lblInsuranceName"></asp:Label>
                    <asp:CheckBox id="Insurance" TextAlign="Right" Checked="False" runat="server" />

                    <asp:label runat="server" ID="lblInsuranceName" Text="lblInsuranceName"></asp:Label>
                    <span>
                        <asp:RequiredFieldValidator ID="InsuranceNameValidator" runat="server"
                            ControlToValidate="InsuranceName" Display="Dynamic"
                            ErrorMessage="Please fill in an insurance company." CssClass="ReqFieldCSS"
                            ValidationGroup="Submit" /></span>
                    <asp:TextBox ID="InsuranceName" runat="server" CssClass="tbCSS" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="cameraPanel" cssClass="pnlCSS">

        </asp:Panel>


        <div class="row">
            <h3>
                <asp:Label ID="lblSelfie" runat="Server">Please upload a photo or take a selfie!</asp:Label></span>
            </h3>
            <asp:Panel ID="PhotoPanel" runat="server" cssClass="pnlCSS">
                <br />
                <div id="cameraDiv" runat="server">
                    <div id="captureDiv">
                        <video id="player" controls autoplay width=240 height=320></video>
                        <input type="button" id="capture" value="Capture" />
                    </div>
                    <div id="canvasDiv" style="display: none">
                        <canvas id="canvas" width=240 height=320></canvas>
                        <input type="button" id="btnSave" value="Save" />
                        <input type="button" id="redo" value="Redo" />
                    </div>
                </div>
                <div id="fileUploadDiv" runat="server">
                    <asp:RequiredFieldValidator ID="FileUploadValidator" runat="server" ControlToValidate="FileUpload1"
                        Display="Dynamic" ErrorMessage="Please Upload a Photo<br />" ValidationGroup="Submit"
                        CssClass="ReqFieldCSS" />
                    <div class="imageLoader">
                        <label class="fileContainer">
                            <img src="Content/upload.png" height="20" />Upload Image
                            <asp:FileUpload ID="FileUpload1" accept="image/*" runat="server"
                                text="Choose Photo or Take Selfie" style="display:none" />
                        </label>
                    </div>

                    <div id="dvPreview">
                        <img src="" id="imgPreview" height="100" alt="Preview" />
                    </div>
                </div>

                <br />
            </asp:Panel>
        </div>


        <br />

        <!-- Trigger/Open The Modal -->
        <asp:button id="myBtn" class="btn">Submit</asp:button>

        <br />
        <br />

        <!-- The Modals -->

        <div id="onloadModal" class="modal" style="display:block">
                <input id="btnClose" type="button" class="close" value="X" />
            <!-- Modal content -->
            <div class="modal-header">Client Number
                
            </div>
            <div class="modal-content" >
                    
                    <asp:label runat="server" ID="lblCustNum1">If the front desk has given you a customer number enter
                        it here:</asp:label>
                    <br>
                    <asp:TextBox ID="CustomerNumber" runat="server" style="width:100px; text-align:right;"></asp:TextBox>
                    <asp:HiddenField ID="CustomerNumberHidden" runat="server"></asp:HiddenField>
                    <asp:button ID="prevBtn" runat="server" onClick="prevCustClick" Text="Enter"></asp:button>
                    
                    <br>
                    <center>
                        <asp:Label ID="CustomerNumberError" runat="server"
                            style="width:100%; text-align:center; border-style:none; background:transparent; color:red;" ReadOnly="true">
                        </asp:Label>
                    </center>
            </div>
        </div>
        <div id="myModal" class="modal">

            <!-- Modal content -->
            <div class="modal-header">Terms & Conditions</div>
            <div class="modal-content">
                <p ID="pTerms" runat="server" />
                <div class="btn-group">
                    <asp:button id="btnCancel" runat="server" class="button" text="Cancel" />
                    <asp:button id="btnShipper" runat="server" class="button" onclick="Button1_Click" text="Accept" />
                </div>
            </div>

        </div>


    </form>
</body>

</html>