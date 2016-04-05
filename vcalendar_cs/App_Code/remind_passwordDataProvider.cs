//Using Statements @1-B4A43F2B
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using calendar;
using calendar.Data;
using calendar.Controls;
using calendar.Security;
using calendar.Configuration;

//End Using Statements

namespace calendar.remind_password{ //Namespace @1-ECF96655

//Page Data Class @1-3FCDCDA8
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public PageItem()
    {
    }
}
//End Page Data Class

//Page Data Provider Class @1-50FE4D41
public class PageDataProvider
{
//End Page Data Provider Class

//Page Data Provider Class Constructor @1-9A44B219
    public PageDataProvider()
    {
    }
//End Page Data Provider Class Constructor

//Page Data Provider Class GetResultSet Method @1-052161C6
    public void FillItem(PageItem item)
    {
//End Page Data Provider Class GetResultSet Method

//Page Data Provider Class GetResultSet Method tail @1-FCB6E20C
    }
//End Page Data Provider Class GetResultSet Method tail

//Page Data Provider class Tail @1-FCB6E20C
}
//End Page Data Provider class Tail

//Record remind Item Class @4-70D3591E
public class remindItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField login;
    public NameValueCollection errors=new NameValueCollection();
    public remindItem()
    {
        login=new TextField("", null);
    }

    public static remindItem CreateFromHttpRequest()
    {
        remindItem item = new remindItem();
        if(DBUtility.GetInitialValue("login") != null){
        item.login.SetValue(DBUtility.GetInitialValue("login"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "login":
                    return this.login;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "login":
                    this.login = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public bool IsNew{
        get{
            return _isNew;
        }
        set{
            _isNew = value;
        }
    }

    public bool IsDeleted{
        get{
            return _isDeleted;
        }
        set{
            _isDeleted = value;
        }
    }

    public void Validate(remindDataProvider provider)
    {
//End Record remind Item Class

//login validate @5-E6B924CD
        if(login.Value==null||login.Value.ToString()=="")
            errors.Add("login",String.Format(Resources.strings.CCS_RequiredField,"login"));
//End login validate

//Record remind Event OnValidate. Action Custom Code @8-2A29BDB7
    // -------------------------
	if (login.Value!=null && ((string)login.Value).Trim().Length > 0) {
		DataAccessObject Conn =	Settings.calendarDataAccessObject;
		string SQL = "SELECT user_id, user_login, user_email, user_password, user_first_name FROM users " +
			  "WHERE user_login=" + Conn.ToSql((string)login.Value,FieldType.Text) +
			  " OR user_email=" + Conn.ToSql((string)login.Value,FieldType.Text);

		DataRowCollection dr = Conn.RunSql(SQL).Tables[0].Rows;
		for	(int i = 0;	i<dr.Count;	i++) 
		{
			string UserID = dr[i]["user_id"].ToString();
			string EmailTo = dr[i]["user_email"].ToString();

			//Generate new hash for password
			string NewHash = CommonFunctions.generateNewPassword(32);
			SQL = "UPDATE users SET user_hash=" + Conn.ToSql(NewHash, FieldType.Text) +
				 " WHERE user_id=" + Conn.ToSql(UserID, FieldType.Integer);
			Conn.RunSql(SQL);

			Hashtable Parameters = new Hashtable();
				Parameters.Add("{activate_url}", Settings.ServerURL + "lost_password.aspx?pwd=" + NewHash);

			CommonFunctions.SendEmailMessage("forgot_password", EmailTo, Parameters);

			System.Web.HttpContext.Current.Session["content_param"] = Parameters;
			System.Web.HttpContext.Current.Session["content_type"]  = "password_was_sent";
			System.Web.HttpContext.Current.Response.Redirect("info.aspx");
		}
		
		if (dr.Count == 0) errors.Add("login", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_nouser"));
	}
    // -------------------------
//End Record remind Event OnValidate. Action Custom Code

//Record remind Item Class tail @4-F5FC18C5
    }
}
//End Record remind Item Class tail

//Record remind Data Provider Class @4-271B2E36
public class remindDataProvider:RecordDataProviderBase
{
//End Record remind Data Provider Class

//Record remind Data Provider Class Variables @4-C761DE48
    protected remindItem item;
//End Record remind Data Provider Class Variables

//Record remind Data Provider Class Constructor @4-CDB6E5AD
    public remindDataProvider()
    {
    }
//End Record remind Data Provider Class Constructor

//Record remind Data Provider Class LoadParams Method @4-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record remind Data Provider Class LoadParams Method

//Record remind Data Provider Class GetResultSet Method @4-F66C93E6
    public void FillItem(remindItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
//End Record remind Data Provider Class GetResultSet Method

//Record remind BeforeBuildSelect @4-921CE95D
        if(!IsInsertMode){
//End Record remind BeforeBuildSelect

//Record remind AfterExecuteSelect @4-54D78817
        }
            IsInsertMode=true;
//End Record remind AfterExecuteSelect

//Record remind AfterExecuteSelect tail @4-FCB6E20C
    }
//End Record remind AfterExecuteSelect tail

//Record remind Data Provider Class @4-FCB6E20C
}

//End Record remind Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

