using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data;

public partial class Country
{
    #region fields
    private string _CountryID;
    private string _CountryName;
    private List<State> _States;
    private static List<Country> _Countries;
    #endregion
    #region methods
    static Country FindCountryByCountryID(string CountryID)
    {
        return _Countries.Find(p => p.GetId() == CountryID);
    }

    static State FindStateByStateID(string StateID)
    {
        if (_States = null)
        {
            return null;
        }
        return _States.Find.SingleOrDefault(s => s.GetId() == StateID);
    }

    static void InitCountries()
    {
        List<Country> Countries = new List<Country>();
        DataTable srs = new DataTable();
        srs = OleDbTools.GetDataTable("Select * from Country Left JOIN [State] on State.CountryID = Country.Country ID ORDER BY CountryName, StateName");
        double PrevCountryID = -999;
        foreach  (dr in srs.Rows)
        {
            if (PrevCountryID != dr[CountryID])
            {
                Countries.Add(new Country(dr[CountryID], dr[CountryName], Not(dr[StateID] = DBNull)));

                PrevCountryID = dr[CountryID];
            }
            if ((dr[StateID] != DBNull))
            {
                Countries(Countries.Count - 1).States.Add(new State(dr[StateID], dr[StateName]));
            }
        }

    }
    #endregion

    #region constructors

    static void Country(string CountryID)
    {
        _CountryID = CountryID;
        Data.DataTable srs;
        srs = SQLTools.GetDataTable("Select CountryName from Country Where CountryID = " + _CountryID);
        _CountryName = srs.Rows[0][CountryName];

    }

    static void Country(string CountryID, string CountryNam, bool hasStates)
    {
        _CountryID = CountryID;
        _CountryName = CountryName;
        if (hasStates)
        {
            States = new List<State>();
            States.Add(new State("0"));
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

    public string _CountryName
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

    public List<Countries> Countries
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

    public List<States> States
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
