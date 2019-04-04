using Microsoft.VisualBasic;
using System.Data;

public partial class Default {
public class State
{
    #region fields
    private string _StateID;
    private string _StateName;
    #endregion

#region constructors
    public State(string StateID)
    {
        _StateID = StateID;
        if (StateID == "0")
        {
            _StateName = "none";
        }
        else
        {
            DataTable srs;
            srs = SQLTools.GetDataTable("Select StateName from State Where StateID = " + StateID);
            _StateName = srs.Rows[0]["StateName"];
        }
    }

    static void New(string StateID, string StateName)
    {
        StateID = StateID;
        if (StateID == 0)
        {
            _StateName = "none";
        }
        else
        {
            _StateName = StateName;
        }
    }

#endregion
#region properties
    string StateID
    {
        get
        {
            return _StateID;
        }

    }

    string StateName
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
    #endregion
}
}