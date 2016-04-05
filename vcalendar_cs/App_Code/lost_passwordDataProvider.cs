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

namespace calendar.lost_password{ //Namespace @1-B31E3934

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

//Record ChangePassword Item Class @5-9D91EFB4
public class ChangePasswordItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField ContentLabel;
    public TextField new_password;
    public TextField new_password_confirm;
    public NameValueCollection errors=new NameValueCollection();
    public ChangePasswordItem()
    {
        ContentLabel=new TextField("", null);
        new_password=new TextField("", null);
        new_password_confirm=new TextField("", null);
    }

    public static ChangePasswordItem CreateFromHttpRequest()
    {
        ChangePasswordItem item = new ChangePasswordItem();
        if(DBUtility.GetInitialValue("ContentLabel") != null){
        item.ContentLabel.SetValue(DBUtility.GetInitialValue("ContentLabel"));
        }
        if(DBUtility.GetInitialValue("new_password") != null){
        item.new_password.SetValue(DBUtility.GetInitialValue("new_password"));
        }
        if(DBUtility.GetInitialValue("new_password_confirm") != null){
        item.new_password_confirm.SetValue(DBUtility.GetInitialValue("new_password_confirm"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "ContentLabel":
                    return this.ContentLabel;
                case "new_password":
                    return this.new_password;
                case "new_password_confirm":
                    return this.new_password_confirm;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "ContentLabel":
                    this.ContentLabel = (TextField)value;
                    break;
                case "new_password":
                    this.new_password = (TextField)value;
                    break;
                case "new_password_confirm":
                    this.new_password_confirm = (TextField)value;
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

    public void Validate(ChangePasswordDataProvider provider)
    {
//End Record ChangePassword Item Class

//Record ChangePassword Event OnValidate. Action Custom Code @26-2A29BDB7
    // -------------------------

	if (new_password.GetFormattedValue().Trim(' ').Length == 0)
		errors.Add("", String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"),((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_new_password")));
	else if (new_password.GetFormattedValue() != new_password_confirm.GetFormattedValue())
		errors.Add("", String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_difpass")));
	else if (!CommonFunctions.CCRegExpTest(new_password.GetFormattedValue(), "[a-zA-Z0-9-\\_]{3,16}$", true, true))
		errors.Add("", String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_pass")));

	if (errors.Count == 0)
	{
		string SQL = "UPDATE users SET user_hash= '', user_password = " + Settings.calendarDataAccessObject.ToSql(new_password.GetFormattedValue(), FieldType.Text) +
			  "WHERE user_hash=" + Settings.calendarDataAccessObject.ToSql(CommonFunctions.CCGetFromGet("pwd", ""), FieldType.Text);

		Settings.calendarDataAccessObject.RunSql(SQL);

		Hashtable Parameters = new Hashtable();
		Parameters.Add("{user_login}", System.Web.HttpContext.Current.Session["user_login"]);
		Parameters.Add("{profile_url}","profile.aspx");
		System.Web.HttpContext.Current.Session["content_param"] = Parameters;
		System.Web.HttpContext.Current.Session["content_type"]  = "password_changed";
		System.Web.HttpContext.Current.Response.Redirect("info.aspx");
	}
    // -------------------------
//End Record ChangePassword Event OnValidate. Action Custom Code

//Record ChangePassword Item Class tail @5-F5FC18C5
    }
}
//End Record ChangePassword Item Class tail

//Record ChangePassword Data Provider Class @5-07E221E5
public class ChangePasswordDataProvider:RecordDataProviderBase
{
//End Record ChangePassword Data Provider Class

//Record ChangePassword Data Provider Class Variables @5-CCB9C771
    protected ChangePasswordItem item;
    public IntegerParameter SesUserID;
//End Record ChangePassword Data Provider Class Variables

//Record ChangePassword Data Provider Class Constructor @5-ED6FC011
    public ChangePasswordDataProvider()
    {
    }
//End Record ChangePassword Data Provider Class Constructor

//Record ChangePassword Data Provider Class LoadParams Method @5-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record ChangePassword Data Provider Class LoadParams Method

//Record ChangePassword Data Provider Class GetResultSet Method @5-8E324752
    public void FillItem(ChangePasswordItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
//End Record ChangePassword Data Provider Class GetResultSet Method

//Record ChangePassword BeforeBuildSelect @5-921CE95D
        if(!IsInsertMode){
//End Record ChangePassword BeforeBuildSelect

//Record ChangePassword AfterExecuteSelect @5-54D78817
        }
            IsInsertMode=true;
//End Record ChangePassword AfterExecuteSelect

//Record ChangePassword AfterExecuteSelect tail @5-FCB6E20C
    }
//End Record ChangePassword AfterExecuteSelect tail

//Record ChangePassword Data Provider Class @5-FCB6E20C
}

//End Record ChangePassword Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

