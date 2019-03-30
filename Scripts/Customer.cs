using Microsoft.CSharp;
public class Customer
{
    #region fields
    private string _CustomerID;
    private string _FirstName;
    private string _LastName;
    private datetime _BirthDate;
    private string _Gender;
    private string _Email;
    private country _Country;
    private state _State;
    private string _Address1;
    private string _Address2;
    private string _City;
    private string _PostalCode;
    private string _CustImage;

    #endregion
    #region properties
    public string FullName
    {
        get
        {
            return _FirstName + " " + _LastName;
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

    public string StateName
    {
        get
        {
            return _State.StateName;
        }
    }

    public string CountryName
    {
        get
        {
            return _Country.CountryName;
        }
    }


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

    public string _Address1
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

    public string _Address2
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

    public string _City
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

    public string _PostalCode
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

    public string _Email
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

    public state _State
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
    #endregion
    #region constructors
    static void SaveMe()
    {
        string StateID = "";
        if (!IsNothing(State))
        {
            StateID = State.StateID;
        }
        SQLTools.ExecuteSqlCmd("UPDATE Customer Set FirstName = '" + FirstName + "', LastName = '" + LastName + "', Birthdate= '" + BirthDate + "', Gender = '" + Gender + "', Address1 = '" + Address1 + "', Address2 = '" + Address2 + "', City = '" + City + "', CountryID = '" + Country.CountryID + "', StateID = '" + StateID + "', PostalCode = '" + PostalCode + "', Email = '" + Email + "'  WHERE CustomerID = " + CustomerID.ToString());
    }

    static void New(int CustomerID)
    {
        Data.DataTable srs;
        srs = SQLTools.GetDataTable("Select CustomerID, FirstName, lastName, CustImage, Birthdate, Gender, CountryID, Address1, Address2, City, PostalCode, Email, StateID FROM Customer WHERE CustomerID = " + CustomerID.ToString());
        _StudentID = srs.Rows[0][StudentID];
        _FirstName = srs.Rows[0][FirstName];
        _LastName = srs.Rows[0][LastName];
        _BirthDate = srs.Rows[0][BirthDate];
        _Email = srs.rows[0][Email];
        _City = srs.Rows[0][City];
        _Gender = srs.Rows[0][Gender];
        _Address1 = srs.Rows[0][Address1];
        if (srs.Rows[0][Address2] != System.DBNull.Value)
        {
            _Address2 = srs.Rows[0][Address2];
        }
        _PostalCode = srs.Rows[0][PostalCode];
        _Country = Country.FindCountryByCountryID(srs.Rows[0][CountryID]);
        if (srs.Rows[0][StateID] != System.DBNull.Value)
        {
            _State = new State(srs.Rows[0][StateID]);
        }
    }
    #endregion
}