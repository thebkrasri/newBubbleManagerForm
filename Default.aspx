<%@ Page Title="Bubble Manager" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Raleway" />
    <link rel="icon" href="Content/logo.ico" />
    <title>Bubble Manager</title>
</head>

<body runat="server" id="pagebody">
    <form runat="server" id="regform">

        <asp:SqlDataSource ID="LanguageDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [LanguageID], [Language] from [Language] ORDER BY [Language]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="InstructorDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [InstructorID], [InstructorName] from [Instructor] ORDER BY [InstructorName]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="HowHearDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [HowHearID], [HowHear] from [HowHear] ORDER BY [HowHear]" DataSourceMode="DataSet"></asp:SqlDataSource>
        <asp:SqlDataSource ID="WhereStayDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [WhereStayID], [WhereStay] from [WhereStay] ORDER BY [WhereStay]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="DiveLevelDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [DiveLevelID], [DiveLevel] from [DiveLevel] ORDER BY [DiveLevel]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="DiveOrgDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT [DiveOrgID], [DiveOrg] from [DiveOrg] ORDER BY [DiveOrg]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="YearDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM tblYear UNION Select 0, 'Year' from GlobalSettings order by yearID"></asp:SqlDataSource>
        <asp:SqlDataSource ID="MonthDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT MonthVal, MonthEng, MonthID FROM tblMonth UNION Select 0, 'Month', 0 from GlobalSettings order by MonthID"></asp:SqlDataSource>
        <asp:SqlDataSource ID="DayDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM tblDay UNION Select 0, 'Day' from GlobalSettings order by DayID"></asp:SqlDataSource>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>


        <img src="Content/logo.png" alt="Welcome to Bubble Manager!" id="imgLogo" />

        <div id="prevCustomerModal" class="modal" style="display: none" runat="server">

            <!-- Modal content -->
            <div class="modal-body">
                <input id="btnClose" type="button" class="close" value="X" />
                <div class="modal-header">

                    <span>Customer Number</span>

                </div>
                <div class="modal-content">
                    <asp:Label runat="server" ID="lblCustNum1" Style="line-height: 2">If the front desk has given you a customer number enter
                        it here</asp:Label>
                    <asp:Label ID="CustomerNumberError" runat="server"
                        Style="width: 100%; text-align: center; border-style: none; background: transparent; color: red; line-height: 2"
                        ReadOnly="true">
                    </asp:Label>
                    <asp:TextBox ID="CustomerNumber" runat="server" Style="width: 100px; text-align: right;"
                        autocomplete="off">
                    </asp:TextBox>
                    <asp:Button ID="prevCustBtn" runat="server" OnClick="prevCustClick" Text="Submit" CssClass="button" Style="margin-left: 5px;margin-bottom:0px"></asp:Button>
                    <asp:HiddenField ID="CustomerNumberHidden" runat="server"></asp:HiddenField>
                </div>
            </div>
        </div>
        <input type="button" id="btnCustomerNumber" value="I have a Customer #" class="button" />
        <div class="row" style="margin-top: 10px">
            <asp:RadioButtonList RepeatDirection="Horizontal" AutoPostBack="true"
                OnSelectedIndexChanged="optLanguage_SelectedIndexChanged" ID="optLanguage" runat="server"
                CssClass="RadioButton">
                <asp:ListItem Value="English">English</asp:ListItem>
                <asp:ListItem Value="Spanish">Espa&ntilde;ol</asp:ListItem>
            </asp:RadioButtonList>
        </div>
                <asp:Panel ID="PersonalInfoPanel" runat="server" CssClass="pnlCSS tab">
                    <asp:HiddenField runat="server" ID="TermsTextID" Value="test" />
                    <asp:Label runat="server" class="sectionHeader" ID="lblPersonalInfoPanel">Personal Details</asp:Label>
                    <div class="row">
                        <div class="col-12">
                            <asp:Label runat="server" class="controlLabel" ID="lblFirstName" Text="lblFirstName"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator runat="server" ID="FirstNameValidator" ControlToValidate="FirstName"
                                    Display="Dynamic" ErrorMessage="Please Fill in First Name" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="FirstName" runat="server" AutoCompleteType="FirstName" CssClass="req"
                                ValidateRequestMode="Enabled" />
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblLastName" Text="lblLastName"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator runat="server" ID="LastNameValidator" ControlToValidate="LastName"
                                    Display="Dynamic" ErrorMessage="Please Fill in Last Name" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="LastName" runat="server" AutoCompleteType="LastName" CssClass="req" />
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblBirthDate" Text="lblBirthDate"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="cmbDayValidator" runat="server" ControlToValidate="cmbDay"
                                    ErrorMessage="Please Select a Birth Day" Display="Dynamic" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" InitialValue="0" /></span>
                            <span>
                                <asp:RequiredFieldValidator ID="cmbMonthValidator" runat="server" ControlToValidate="cmbMonth"
                                    ErrorMessage="Please Select a Birth Month" Display="Dynamic" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" InitialValue="0" />
                            </span>
                            <span>
                                <asp:RequiredFieldValidator ID="cmbYearValidator" runat="server" ControlToValidate="cmbYear"
                                    ErrorMessage="Please Select a Birth Year" Display="Dynamic" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" InitialValue="0" /></span>
                            <asp:DropDownList ID="cmbDay" DataSourceID="DayDataSource" DataTextField="Day"
                                DataValueField="DayID" runat="server" CssClass="req ddCSS">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbMonth" DataSourceID="MonthDataSource" DataTextField="MonthEng"
                                DataValueField="MonthVal" runat="server" CssClass="req ddCSS">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbYear" runat="server" DataSourceID="YearDataSource" DataTextField="YearText"
                                DataValueField="YearID" CssClass="req ddCSS">
                            </asp:DropDownList>
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblGender" Text="lblGender"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="GenderValidator" runat="server" ControlToValidate="Gender"
                                    ErrorMessage="Please Select a Gender" Display="Dynamic" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" InitialValue="0" /></span>
                            <asp:DropDownList ID="Gender" runat="server" CssClass="req">
                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                <asp:ListItem Value="Female">Female</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblEmail" Text="lblEmail"></asp:Label>
                            <span>
                                <asp:RegularExpressionValidator ID="EmailRegExValidator" runat="server"
                                    ControlToValidate="Email" Display="Dynamic" ErrorMessage="Please enter valid email"
                                    ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" CssClass="ReqFieldCSS"
                                    ValidationGroup="validator" />
                                <asp:RequiredFieldValidator runat="server" ID="EmailValidator" ControlToValidate="Email"
                                    Display="Dynamic" ErrorMessage="Please Fill in Email" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" />
                            </span>
                            <asp:TextBox ID="Email" runat="server" AutoCompleteType="Email" CssClass="req" />
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblPhone" Text="lblPhone"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="PhoneValidator" runat="server" ControlToValidate="Phone"
                                    Display="Dynamic" ErrorMessage="Please fill in a phone number" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="Phone" runat="server" AutoCompleteType="HomePhone" CssClass=" " />
                            <asp:Label runat="server" ID="lblFacebook" Text="lblFacebook" class="controlLabel"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="FacebookValidator" runat="server" ControlToValidate="Facebook"
                                    Display="Dynamic" ErrorMessage="Please fill in a Facebook/Instagram/WhatsApp account" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="Facebook" runat="server" CssClass=" " />
                            <asp:Label runat="server" ID="lblDietaryRestrictions" Text="lblDietaryRestrictions" class="controlLabel"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="DietaryRestrictionsValidator" runat="server" ControlToValidate="DietaryRestrictions"
                                    Display="Dynamic" ErrorMessage="Please fill in dietary restrictions" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>

                            <asp:TextBox ID="DietaryRestrictions" runat="server" CssClass=" " />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="AddressPanel" runat="server" CssClass="pnlCSS tab">
                    <asp:Label runat="server" class="sectionHeader" ID="lblAddressPanel">Home Address</asp:Label>
                    <div class="row">
                        <div class="col-12">
                            <asp:Label runat="server" class="controlLabel" ID="lblAddress1" Text="lblAddress1"></asp:Label>
                            <span>
                                <asp:RegularExpressionValidator ID="Address1RegExValidator" runat="server" ControlToValidate="Address1" Display="Dynamic"
                                    ErrorMessage="Please Fill in Street Address, Not Email!" CssClass="ReqFieldCSS"
                                    ValidationExpression="^((?!@).)*$" ValidationGroup="validator" />
                                <asp:RequiredFieldValidator ID="Address1Validator" runat="server" ControlToValidate="Address1"
                                    Display="Dynamic" ErrorMessage="Please Fill in Street Address" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="Address1" MaxLength="50" runat="server" AutoCompleteType="HomeStreetAddress" CssClass="req" />
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblAddress2" Text="lblAddress2"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="Address2Validator" runat="server" ControlToValidate="Address2"
                                    Display="Dynamic" ErrorMessage="Please Fill in Street Address 2" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="Address2" MaxLength="50" runat="server" />
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblCity" Text="lblCity"></asp:Label>
                            <span>
                                <asp:RegularExpressionValidator ID="CityRegExValidator" runat="server"
                                    ControlToValidate="City" Display="Dynamic"
                                    ErrorMessage="Please enter City in Alpha-Latin Characters"
                                    ValidationExpression="^([A-Za-z\u00C0-\u00D6\u00D8-\u00f6\u00f8-\u00ff\-\'\.\s]*)$"
                                    CssClass="ReqFieldCSS" ValidationGroup="validator" />
                                <asp:RequiredFieldValidator runat="server" ID="CityValidator" ControlToValidate="City"
                                    Display="Dynamic" ErrorMessage="Please Fill in City" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="City" MaxLength="50" runat="server" AutoCompleteType="HomeCity" CssClass="req"></asp:TextBox>
                            <br />
                            <asp:Label runat="server" class="controlLabel" ID="lblPostalCode" Text="lblPostalCode"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="PostalCodeValidator" runat="server"
                                    ControlToValidate="PostalCode" Display="Dynamic" ErrorMessage="Please Fill in Postal Code"
                                    CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="PostalCode" runat="server" AutoCompleteType="HomeZipCode" CssClass="req" />
                            <asp:UpdatePanel ID="StateUpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:Label runat="server" class="controlLabel" ID="lblCountryID" Text="lblCountryID">
                                    </asp:Label>
                                    <span>
                                        <asp:RequiredFieldValidator ID="CountryIDValidator" runat="server"
                                            ControlToValidate="CountryID" ErrorMessage="Please Select a Country"
                                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit"
                                            InitialValue="0" /></span>
                                    <asp:DropDownList ID="CountryID" runat="server" AutoPostBack="True"
                                        DataTextField="CountryName" DataValueField="CountryID"
                                        OnSelectedIndexChanged="CountryID_SelectedIndexChanged" CssClass="req" />

                                    <div class="row" id="StateDiv" runat="server" style="display: none">
                                        <asp:Label runat="server" class="controlLabel" ID="lblStateID" Text="State/Province*"
                                            AutoPostBack="True" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="StateValidator" runat="server" ControlToValidate="StateID"
                                                ErrorMessage="Please Select a State" Display="Dynamic" CssClass="ReqFieldCSS"
                                                ValidationGroup="Submit" InitialValue="0" Enabled="false" /></span>
                                        <asp:DropDownList ID="StateID" runat="server" AutoPostBack="True"
                                            DataTextField="StateName" DataValueField="StateID" CssClass="req" />
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="prevCustBtn" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="EmergencyContactDiv" runat="server" CssClass="pnlCSS tab">
                    <asp:Label runat="server" class="sectionHeader" ID="lblEmergencyContactDiv">Emergency Contact</asp:Label>
                    <div class="row">
                        <div class="col-12">
                            <asp:Label runat="server" class="controlLabel" ID="lblEmergencyName" Text="lblEmergencyName">
                            </asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="EmergencyNameValidator" runat="server"
                                    ControlToValidate="EmergencyName" ErrorMessage="Please enter an emergency contact name"
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="EmergencyName" runat="server" CssClass=" " />
                            <asp:Label runat="server" class="controlLabel" ID="lblRelationship" Text="lblRelationship">
                            </asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="RelationshipValidator" runat="server"
                                    ControlToValidate="Relationship" ErrorMessage="Please enter an emergency relationship"
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="Relationship" runat="server" CssClass=" " />
                            <asp:Label runat="server" class="controlLabel" ID="lblEmergencyCountryID"
                                Text="lblEmergencyCountryID"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="EmergencyCountryIDValidator" runat="server"
                                    ControlToValidate="EmergencyCountryID" ErrorMessage="Please Select a Country"
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                            <asp:DropDownList ID="EmergencyCountryID" runat="server"
                                DataTextField="CountryName" DataValueField="CountryID" CssClass="ddCSS" />
                            <asp:Label runat="server" class="controlLabel" ID="lblEmergencyNumber" Text="lblEmergencyNumber">
                            </asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="EmergencyNumberValidator" runat="server"
                                    ControlToValidate="EmergencyNumber" ErrorMessage="Please enter an emergency number"
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="EmergencyNumber" runat="server" CssClass=" " />

                            <asp:Label runat="server" class="controlLabel" ID="lblEmergencyEmail" Text="lblEmergencyEmail">
                            </asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="EmergencyEmailValidator" runat="server"
                                    ControlToValidate="EmergencyEmail" ErrorMessage="Please enter an emergency email"
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="EmergencyEmail" runat="server" CssClass=" " />

                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="DivingDiv" runat="server" CssClass="pnlCSS tab">
                    <asp:Label runat="server" class="sectionHeader" ID="lblDivingDiv">SCUBA Diving Background
                    </asp:Label>
                    <div class="row" id="InsuranceDiv" style="padding-bottom: 0">
                        <asp:Label runat="server" class="controlLabel" ID="lblInsurance" Text=""></asp:Label>
                        <asp:RadioButtonList ID="Insurance" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList>
                    </div>
                    <div class="row" id="InsuranceNameDiv" style="display: none; text-align: center" runat="server">
                        <asp:Label runat="server" class="controlLabel" ID="lblInsuranceName" Text="lblInsuranceName">
                        </asp:Label>
                        <asp:TextBox ID="InsuranceName" runat="server" CssClass=" " />
                        <span>
                            <asp:RequiredFieldValidator ID="InsuranceNameValidator" runat="server"
                                ControlToValidate="InsuranceName" Display="Dynamic"
                                ErrorMessage="Please fill in an insurance company." CssClass="ReqFieldCSS"
                                ValidationGroup="Submit" /></span>
                        <asp:Label runat="server" class="controlLabel" ID="lblInsurancePolicyNumber" Text="lblInsurancePolicyNumber">
                        </asp:Label>
                        <asp:TextBox ID="InsurancePolicyNumber" runat="server" CssClass=" " />
                        <span>
                            <asp:RequiredFieldValidator ID="InsurancePolicyNumberValidator" runat="server"
                                ControlToValidate="InsurancePolicyNumber" Display="Dynamic"
                                ErrorMessage="Please fill in an insurance policy number." CssClass="ReqFieldCSS"
                                ValidationGroup="Submit" /></span>
                         <asp:Label runat="server" class="controlLabel" ID="lblInsuranceContactPhone" Text="lblInsuranceContactPhone">
                        </asp:Label>
                        <asp:TextBox ID="InsuranceContactPhone" runat="server" CssClass=" " />
                        <span>
                            <asp:RequiredFieldValidator ID="InsuranceContactPhoneValidator" runat="server"
                                ControlToValidate="InsuranceContactPhone" Display="Dynamic"
                                ErrorMessage="Please fill in an insurance contact number." CssClass="ReqFieldCSS"
                                ValidationGroup="Submit" /></span>

                    </div>
                    <asp:UpdatePanel ID="CertifiedDiverUpdatePanel" runat="server">
                        <ContentTemplate>
                            <div class="row" id="CertifiedDiverDiv">
                                <asp:Label runat="server" class="controlLabel" ID="lblCertifiedDiver" Text="lblCertifiedDiver">
                                </asp:Label>
                                <asp:RadioButtonList ID="CertifiedDiver" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="CertifiedDiver_SelectedIndexChanged">
                                    <asp:ListItem Text="Yes" Value="1" />
                                    <asp:ListItem Text="No" Value="0" />
                                </asp:RadioButtonList>
                            </div>
                            <div id="DiveCertTypes" class="row" style="display: none; margin: auto" runat="server">
                                <div class="col-6">
                                    <asp:Label runat="server" class="controlLabel" ID="lblDiveOrgID" Text="lblDiveOrgID">
                                    </asp:Label>
                                    <asp:DropDownList ID="DiveOrgID" runat="server" DataSourceID="DiveOrgDataSource"
                                        DataTextField="DiveOrg" DataValueField="DiveOrgID">
                                    </asp:DropDownList>
                                    <span>
                                        <asp:RequiredFieldValidator ID="DiveOrgIDValidator" runat="server"
                                            ControlToValidate="DiveOrgID" ErrorMessage="Please enter a dive organization."
                                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" InitialValue="0" />
                                    </span>
                                </div>
                                <div class="col-6">
                                    <asp:Label runat="server" class="controlLabel" ID="lblDiveLevelID" Text="lblDiveLevelID">
                                    </asp:Label>
                                    <asp:DropDownList ID="DiveLevelID" runat="server" DataSourceID="DiveLevelDataSource"
                                        DataTextField="DiveLevel" DataValueField="DiveLevelID">
                                    </asp:DropDownList>
                                    <span>
                                        <asp:RequiredFieldValidator ID="DiveLevelIDValidator" runat="server"
                                            ControlToValidate="DiveLevelID" ErrorMessage="Please enter a dive level."
                                            Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" InitialValue="0" />
                                    </span>
                                </div>
                            </div>
                            <div class="row" id="LastDiveDateDiv" runat="server" style="display: none; text-align: center">
                                <asp:Label runat="server" class="controlLabel" ID="lblLastDiveDate" Text="" Style="display: block"></asp:Label>
                                <asp:TextBox ID="LastDiveDate" runat="server" CssClass=" " Style="display: block" />
                                <span>
                                    <asp:RequiredFieldValidator ID="LastDiveDateValidator" runat="server" ControlToValidate="LastDiveDate"
                                        Display="Dynamic" ErrorMessage="Please fill in a date last dived" CssClass="ReqFieldCSS"
                                        ValidationGroup="Submit" />
                                </span>
                            </div>
                            <div class="row" id="NumberOfDivesDiv" runat="server" style="display: none; text-align: center">
                                <asp:Label runat="server" class="controlLabel" ID="lblNumberOfDives" Text=""
                                    Style="display: block"></asp:Label>
                                <asp:TextBox ID="NumberOfDives" runat="server" CssClass="" Style="display: block" />
                                <span>
                                    <asp:RequiredFieldValidator ID="NumberOfDivesValidator" runat="server"
                                        ControlToValidate="NumberOfDives" Display="Dynamic"
                                        ErrorMessage="Please fill in number of dives." CssClass="ReqFieldCSS"
                                        ValidationGroup="Submit" />
                                </span>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:Panel ID="WhereStayDiv" runat="server" CssClass="pnlCSS tab">
                    <asp:Label runat="server" class="sectionHeader" ID="lblWhereStayDiv">Accommodation</asp:Label>
                    <div class="row">
                        <div class="col-12">
                            <asp:Label runat="server" class="controlLabel" ID="lblWhereStayID" Text="lblWhereStayID">
                            </asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="WhereStayIDValidator" runat="server"
                                    ControlToValidate="WhereStayID" ErrorMessage="Please enter a resort/hotel" Display="Dynamic"
                                    CssClass="ReqFieldCSS" ValidationGroup="Submit" InitialValue="0" />
                            </span>
                            <asp:DropDownList ID="WhereStayID" runat="server" DataSourceID="WhereStayDataSource"
                                DataTextField="WhereStay" DataValueField="WhereStayID">
                            </asp:DropDownList>
                            <span>
                                <asp:Label runat="server" class="controlLabel" ID="lblRoomOther" Text="lblRoomOther">
                                </asp:Label>
                            </span>
                            <span>
                                <asp:RequiredFieldValidator ID="RoomOtherValidator" runat="server" ControlToValidate="RoomOther"
                                    ErrorMessage="Please enter other room info" Display="Dynamic" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="RoomOther" runat="server" CssClass=" " />

                            <span>
                                <asp:Label runat="server" class="controlLabel" ID="lblRoomNo" Text="lblRoomNo"></asp:Label>
                            </span>
                            <span>
                                <asp:RequiredFieldValidator ID="RoomNoValidator" runat="server" ControlToValidate="RoomNo"
                                    ErrorMessage="Please enter a room number" Display="Dynamic" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="RoomNo" runat="server" CssClass=" " />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="LanguageDiv" runat="server" CssClass="pnlCSS tab">
                    <asp:Label runat="server" class="sectionHeader" ID="lblLanguageDiv">Nationality</asp:Label>
                    <div class="row">
                        <div class="col-12">
                             <asp:Label runat="server" class="controlLabel" ID="lblNationalityCountryID"
                                Text="lblNationalityCountryID"></asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="NationalityCountryIDValidator" runat="server"
                                    ControlToValidate="NationalityCountryID" ErrorMessage="Please Select a Country"
                                    Display="Dynamic" CssClass="ReqFieldCSS" ValidationGroup="Submit" /></span>
                            <asp:DropDownList ID="NationalityCountryID" runat="server"
                                DataTextField="CountryName" DataValueField="CountryID" CssClass="ddCSS" />
                            <asp:Label runat="server" class="controlLabel" ID="lblPassportNum" Text="lblPassPortNum">
                            </asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="PassportNumValidator" runat="server"
                                    ControlToValidate="PassportNum" Display="Dynamic"
                                    ErrorMessage="Please fill in a passport number." CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="PassportNum" runat="server" CssClass=" " />
                            <asp:Label runat="server" class="controlLabel" ID="lblLanguageID" Text="lblLanguageID"></asp:Label>
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
                <asp:Panel ID="HowHearDiv" runat="server" CssClass="pnlCSS tab">
                    <div class="row">
                        <div class="col-12">
                            <span>
                                <asp:Label runat="server" class="controlLabel" ID="lblCheckinInstructorID" Text="lblCheckinInstructorID">
                                </asp:Label>
                                <asp:RequiredFieldValidator ID="CheckinInstructorIDValidator" runat="server"
                                    ControlToValidate="CheckinInstructorID" Display="Dynamic"
                                    ErrorMessage="Who helped you check in?" CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" InitialValue="0"/>
                            </span>
                            <asp:DropDownList ID="CheckinInstructorID" runat="server" DataSourceID="InstructorDataSource"
                                DataTextField="InstructorName" DataValueField="InstructorID" >
                            </asp:DropDownList>
                            <span>
                                <asp:Label runat="server" class="controlLabel" ID="lblHowHearTextID" Text="lblHowHearTextID">
                                </asp:Label>
                                <asp:RequiredFieldValidator ID="HowHearTextIDValidator" runat="server"
                                    ControlToValidate="HowHearTextID" Display="Dynamic"
                                    ErrorMessage="Please tell us how you heard about us." CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" InitialValue="0" />
                            </span>
                            <asp:DropDownList ID="HowHearTextID" runat="server" DataSourceID="HowHearDataSource"
                                DataTextField="HowHear" DataValueField="HowHearID">
                            </asp:DropDownList>
                            <asp:Label runat="server" class="controlLabel" ID="lblHowHearSpecific" Text="lblHowHearSpecific">
                            </asp:Label>
                            <span>
                                <asp:RequiredFieldValidator ID="HowHearSpecificValidator" runat="server"
                                    ControlToValidate="HowHearSpecific" Display="Dynamic"
                                    ErrorMessage="Please tell us how you heard about us." CssClass="ReqFieldCSS"
                                    ValidationGroup="Submit" /></span>
                            <asp:TextBox ID="HowHearSpecific" runat="server" CssClass=" " />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PhotoPanel" runat="server" CssClass="pnlCSS tab">
                    <br />
                    <div id="cameraDiv" runat="server">
                        <asp:Label id="lblCamera" class="sectionHeader" runat="server">Take a photo of yourself!</asp:Label>
                        <div id="cameraAlert">Capture a selfie!</div>
                        <div id="captureDiv" style="width: auto; height: auto">
                            <div style="display: table; position: relative;">
                                <div id="loadingImg">
                                    <img src="Content/loading.gif" alt="Camera Loading..." />
                                </div>
                                <div id="pictureBox"></div>
                                <video id="player" autoplay style="border: none;">
                                </video>
                            </div>

                            <input type="button" id="capture" value="Capture" />
                        </div>
                        <div id="canvasDiv" style="display: none">
                            <canvas id="canvas" width="240" height="320" runat="server"></canvas>
                            <input type="button" id="redo" value="Take a new photo" />
                            <input type="hidden" name="imageData" id="imageData" runat="server" />
                        </div>
                    </div>
                    <div id="fileUploadDiv" runat="server">
                        <asp:Label id="lblFileUpload" class="sectionHeader" runat="server">Add a photo of yourself!</asp:Label>
                        <asp:RequiredFieldValidator ID="FileUploadValidator" runat="server" ControlToValidate="FileUpload1"
                            Display="Dynamic" ErrorMessage="Please Upload a Photo<br />" ValidationGroup="Submit"
                            CssClass="ReqFieldCSS" />
                        <div class="imageLoader">
                            <label class="fileContainer" id="fileContainer" runat="server">
                                <img src="Content/upload.png" height="30" id="uploadImg" />Choose Image
                        <asp:FileUpload ID="FileUpload1" accept="image/*" runat="server"
                            text="Choose Photo or Take Selfie" Style="display: none" />
                            </label>
                        </div>

                        <div id="dvPreview" runat="server">
                            <img src="" id="imgPreview" alt="Preview" runat="server" />
                        </div>
                    </div>
                    <br />
                </asp:Panel>
                <!-- Circles which indicates the steps of the form: -->
                <div id="stepsDiv">
                </div>

                <div id="stepbuttons">
                    <div>
                        <button type="button" id="prevBtn" onclick="nextPrev(-1)" class="button">Previous</button>
                        <button type="button" id="nextBtn" onclick="nextPrev(1)" class="button">Next</button>
                    </div>
                </div>
                <div id="termsModal" class="modal">
                    <!-- Modal content -->
                    <div class="modal-body">
                        <div class="modal-header">Terms & Conditions</div>
                        <div class="modal-content">
                            <p id="pTerms" runat="server" />
                            <div class="btn-group">
                                <asp:Button ID="btnCancel" runat="server" class="button" Text="Cancel" />
                                <asp:Button ID="btnShipper" runat="server" class="button" onclientclick="disableButton()" OnClick="Button1_Click" Text="Accept" />
                            </div>
                        </div>
                    </div>
                </div>
        <img id="submittingGif" src="Content/loading.gif" style="display:none"/>
        <asp:HiddenField runat="server" ID="CameraUsed"></asp:HiddenField>
    </form>
</body>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

<script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>

<script src="Scripts/Default.js" type="text/javascript"></script>

</html>
