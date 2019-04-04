using Microsoft.CSharp;
using System;
public class Customer
{
    #region fields
    private string _CustomerID;
    private string _FirstName;
    private string _LastName;
    private DateTime _BirthDate;
    private int _Gender;
    private string _Email;
    private Country _Country;
    private State _State;
    private string _Address1;
    private string _Address2;
    private string _City;
    private string _PostalCode;
    private string _Phone;
    private string _PassportNum;
    private int _HowHearTextID;
    private string _HowHearSpecific;
    private int _WhereStayID;
    private string _RoomOther;
    private string _RoomNo;
    private string _EmergencyName;
    private string _Relationship;
    private string _EmergencyNumber;
    private string _EmergencyEmail;
    private country _EmergencyCountry;
    private int _DiveLevelID;
    private int _DiveOrgID;
    private string _NumberOfDives;
    private int _Insurance;
    private string _InsuranceName;
    private string _CustImage;

    #endregion
    #region properties
    public string CustomerID
    {
        get
        {
            return _CustomerID;
        }
        set
        {
            _CusomterID = value;
        }
    }
    public string FirstName
    {
        get
        {
            return _FirstName;
        }
        set
        {
            _FirstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return _LastName;
        }
        set
        {
            _LastName = value;
        }
    }
    public date BirthDate
    {
        get
        {
            return _BirthDate;
        }
        set
        {
            _BirthDate = value;
        }
    }

    public string Gender
    {
        get
        {
            return _Gender;
        }
        set
        {
            _Gender = value;
        }
    }

    public country Country
    {
        get
        {
            return _Country;
        }
        set
        {
            _Country = value;
        }
    }

    public state State
    {
        get
        {
            return _State;
        }
        set
        {
            _State = value;
        }
    }
    public string Address1
    {
        get
        {
            return _Address1;
        }
        set
        {
            _Address1 = value;
        }
    }

    public string Address2
    {
        get
        {
            return _Address2;
        }
        set
        {
            _Address2 = value;
        }
    }

    public string City
    {
        get
        {
            return _City;
        }
        set
        {
            _City = value;
        }
    }

    public string PostalCode
    {
        get
        {
            return _PostalCode;
        }
        set
        {
            _PostalCode = value;
        }
    }

    public string Email
    {
        get
        {
            return _Email;
        }
        set
        {
            _Email = value;
        }
    }

    public string Phone
    {
        get
        {
            return _Phone;
        }
        set
        {
            _Phone = value;
        }
    }
    public string PassportNum
    {
        get
        {
            return _PassportNum;
        }
        set
        {
            _PassportNum = value;
        }
    }

    public int _HowHearTextID
    {
        get
        {
            return _HowHearTextID;
        }
        set
        {
            _HowHearTextID = value;
        }
    }
    public string HowHearSpecific
    {
        get
        {
            return _HowHearSpecific;
        }
        set
        {
            _HowHearSpecific = value;
        }
    }
    public int WhereStayID
    {
        get
        {
            return _WhereStayID;
        }
        set
        {
            _WhereStayID = value;
        }
    }
    public string RoomOther
    {
        get
        {
            return _RoomOther;
        }
        set
        {
            _RoomOther = value;
        }
    }
    public string RoomNo
    {
        get
        {
            return _RoomNo;
        }
        set
        {
            _RoomNo = value;
        }
    }
    public string EmergencyName
    {
        get
        {
            return _EmergencyName;
        }
        set
        {
            _EmergencyName = value;
        }
    }
    public string Relationship
    {
        get
        {
            return _Relationship;
        }
        set
        {
            _Relationship = value;
        }
    }
    public string EmergencyNumber
    {
        get
        {
            return _EmergencyNumber;
        }
        set
        {
            _EmergencyNumber = value;
        }
    }
    public string EmergencyEmail
    {
        get
        {
            return _EmergencyEmail;
        }
        set
        {
            _EmergencyEmail = value;
        }
    }
    public country EmergencyCountry
    {
        get
        {
            return _EmergencyCountry;
        }
        set
        {
            _EmergencyCountry = value;
        }
    }
    public int DiveLevelID
    {
        get
        {
            return _DiveLevelID;
        }
        set
        {
            _DiveLevelID = value;
        }
    }
    public int DiveOrgID
    {
        get
        {
            return _DiveOrgID;
        }
        set
        {
            _DiveOrgID = value;
        }
    }
    public string NumberOfDives
    {
        get
        {
            return _NumberOfDives;
        }
        set
        {
            _NumberOfDives = value;
        }
    }
    public int Insurance
    {
        get
        {
            return _Insurance;
        }
        set
        {
            _Insurance = value;
        }
    }
    public string InsuranceName
    {
        get
        {
            return _InsuranceName;
        }
        set
        {
            _InsuranceName = value;
        }
    }

    public string CustImage
    {
        get
        {
            return CustImage;
        }
        set
        {
            _CustImage = value;
        }
    }
    public string FullName
    {
        get
        {
            return _FirstName + " " + _LastName;
        }
    }

    public string BirthDay
    {
        get
        {
            return Day(_BirthDate);
        }
    }
    public string BirthMonth
    {
        get
        {
            return Month(_BirthDate);
        }
    }
    public string BirthYear
    {
        get
        {
            return Year(_BirthDate);
        }
    }

    public int StateID
    {
        get
        {
            return _State.StateID;
        }
    }

    public int CountryID
    {
        get
        {
            return _Country.CountryID;
        }
    }
    public int EmergencyCountryID
    {
        get
        {
            return _Country.CountryID;
        }
    }

    #endregion
    #region methods
    static void SaveMe()
    {
        string StateID = "";
        if (!IsNothing(State))
        {
            StateID = State.StateID;
        }
        bool getCustomerID = false;
        string constring = "System.Configuration.ConfigurationManager.ConnectionStrings['" + "ConnectionString" + "'].ConnectionString";
        using (OleDbConnection con = new OleDbConnection(conString))
        using (OleDbCommand command = con.CreateCommand())
        {
            if (CustomerID == null || CustomerID == "")
            {
                string.CommandText = "INSERT INTO Customer (FirstName, LastName, Gender, BirthDate ,Address1,Address2,City, StateID,CountryID,PostalCode,Email, Phone, PassportNum, LanguageID, HowHearTextID, HowHearSpecific, WhereStayID, RoomOther,RoomNo, EmergencyName, Relationship, EmergencyNumber, EmergencyEmail, DiveLevelID, DiveOrgID, NumberOfDives, Insurance, InsuranceName, EmergencyCountryID, ArrivalDate, [image]) VALUES (@FirstName,@LastName, @Gender, @BirthDate, @Address1,@Address2,@City,@StateID, @Country,@PostalCode,@Email, @Phone, @PassportNum, @LanguageID, @HowHearTextID, @HowHearSpecific, @WhereStayID, @RoomOther, @RoomNo, @EmergencyName, @Relationship, @EmergencyNumber, @EmergencyEmail, @DiveLevelID, @DiveOrgID, @NumberOfDives, @EmergencyCountryID, @ArrivalDate, @Insurance, @InsuranceName, @MyImage)";
                getCustomerID = true;
            }
            else
            {
                command.CommandText = "UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, Gender=@Gender, BirthDate=@BirthDate, Address1=@Address1,Address2=@Address2,City=@City, StateID=@StateID, CountryID=@CountryID, PostalCode=@PostalCode,Email=@Email, Phone=@Phone, PassportNum=@PassportNum, LanguageID=@LanguageID, HowHearTextID=@HowHearTextID, HowHearSpecific=@HowHearSpecific, WhereStayID =@WhereStayID, RoomOther=@RoomOther,RoomNo=@RoomNo, EmergencyName=@EmergencyName, Relationship=@Relationship, EmergencyNumber=@EmergencyNumber, EmergencyEmail=@EmergencyEmail, DiveLevelID=@DiveLevelID, DiveOrgID=@DiveOrgID, NumberOfDives=@NumberOfDives, Insurance=@Insurance, InsuranceName=@InsuranceName, EmergencyCountryID=@EmergencyCountryID, ArrivalDate=@ArrivalDate, [image]=@MyImage WHERE CustomerID=@CustomerID";
                command.Parameters.Add("@CustomerID", CustomerID);
            }
            command.Parameters.Add("@FirstName", FirstName);
            command.Parameters.Add("@LastName", LastName);
            command.Parameters.Add("@Gender", Gender);
            command.Parameters.Add("@BirthDate", DateTime.Parse(BirthDate, System.Globalization.CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy"));
            command.Parameters.Add("@Address1", Address1);
            command.Parameters.Add("@Address2", Address2);
            command.Parameters.Add("@City", City);
            command.Parameters.Add("@StateID", StateID);
            command.Parameters.Add("@CountryID", CountryID);
            command.Parameters.Add("@PostalCode", PostalCode);
            command.Parameters.Add("@Email", Email);
            command.Parameters.Add("@Phone", Phone);
            command.Parameters.Add("@PassportNum", PassportNum);
            command.Parameters.Add("@LanuguageID", languageID);
            command.Parameters.Add("@HowHearTextID", HowHearTextID);
            command.Parameters.Add("@HowHearSpecific", HowHearSpecific);
            command.Parameters.Add("@WhereStayID", WhereStayID);
            command.Parameters.Add("@RoomOther", RoomOther);
            command.Parameters.Add("@RoomNo", RoomNo);
            command.Parameters.Add("@EmergencyName", EmergencyName);
            command.Parameters.Add("@Relationship", Relationship);
            command.Parameters.Add("@EmergencyNumber", EmergencyNumber);
            command.Parameters.Add("@EmergencyEmail", EmergencyEmail);
            command.Parameters.Add("@DiveLevelID", DiveLevelID);
            command.Parameters.Add("@DiveOrgID", DiveOrgID);
            command.Parameters.Add("@NumberOfDives", NumberOfDives);
            command.Parameters.Add("@Insurance", Insurance);
            command.Parameters.Add("@InsuranceName", InsuranceName);
            command.Parameters.Add("@EmergencyCountryID", EmergencyCountryID);
            command.Parameters.Add("@ArrivalDate", DateTime.Now.ToShortDateString());
            con.Open();
            command.ExecuteNonQuery();
        }
    }
#endregion
#region constructors
    static void Customer(int CustomerID)
    {
        string constring = "System.Configuration.ConfigurationManager.ConnectionStrings['" + "ConnectionString" + "'].ConnectionString";

        srs = SQLTools.GetDataTable("Select * FROM Customer WHERE CustomerID = " + CustomerID.ToString());
        _CusomterID = srs.Rows[0][CustomerID];
        _FirstName = srs.Rows[0][FirstName];
        _LastName = srs.Rows[0][LastName];
        _BirthDate = srs.Rows[0][BirthDate];
        _Email = srs.rows[0][Email];
        _Gender = srs.Rows[0][Gender];
        _Address1 = srs.Rows[0][Address1];
        if (srs.Rows[0][Address2] != System.DBNull.Value)
        {
            _Address2 = srs.Rows[0][Address2];
        }
        _City = srs.Rows[0][City];
        _PostalCode = srs.Rows[0][PostalCode];
        _Country = Country.FindCountryByCountryID(srs.Rows[0][CountryID]);
        if (srs.Rows[0][StateID] != System.DBNull.Value)
        {
            _State = State(srs.Rows[0][StateID]);
        }
        _Phone = srs.Rows[0][Phone];
        _PassportNum = srs.Rows[0][PassportNum];
        _HowHearTextID = srs.Rows[0][HowHearTextID];
        _HowHearSpecific = srs.Rows[0][HowHearSpecific];
        _WhereStayID = srs.Rows[0][WhereStayID];
        _RoomOther = srs.Rows[0][RoomOther];
        _RoomNo = srs.Rows[0][RoomNo];
        _EmergencyName = srs.Rows[0][EmergencyName];
        _Relationship = srs.Rows[0][Relationship];
        _EmergencyNumber = srs.Rows[0][EmergencyNumber];
        _EmergencyEmail = srs.Rows[0][EmergencyEmail];
        _EmergencyCountry = Country.FindCountryByCountryID(srs.Rows[0][EmergencyCountryID]);
        _DiveLevelID = srs.Rows[0][DiveLevelID];
        _DiveOrgID = srs.Rows[0][DiveOrgID];
        _NumberOfDives = srs.Rows[0][NumberOfDives];
        _Insurance = srs.Rows[0][Insurance];
        _InsuranceName = srs.Rows[0][InsuranceName];
        _Image = srs.Rows[0][Image];
    }
    #endregion
}