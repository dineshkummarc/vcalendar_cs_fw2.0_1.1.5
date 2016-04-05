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

namespace calendar.login{ //Namespace @1-978FDA69

//Page Data Class @1-9FB804F5
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.register.SetValue(DBUtility.GetInitialValue("register"));
        item.remind.SetValue(DBUtility.GetInitialValue("remind"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "register":
                    return this.register;
                case "remind":
                    return this.remind;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "register":
                    this.register = (TextField)value;
                    break;
                case "remind":
                    this.remind = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField register;
    public object registerHref;
    public LinkParameterCollection registerHrefParameters;
    public TextField remind;
    public object remindHref;
    public LinkParameterCollection remindHrefParameters;
    public PageItem()
    {
        register = new TextField("",null);
        registerHrefParameters = new LinkParameterCollection();
        remind = new TextField("",null);
        remindHrefParameters = new LinkParameterCollection();
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

//Record Login Item Class @5-E0166CA2
public class LoginItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField login;
    public TextField password;
    public NameValueCollection errors=new NameValueCollection();
    public LoginItem()
    {
        login=new TextField("", null);
        password=new TextField("", null);
    }

    public static LoginItem CreateFromHttpRequest()
    {
        LoginItem item = new LoginItem();
        if(DBUtility.GetInitialValue("login") != null){
        item.login.SetValue(DBUtility.GetInitialValue("login"));
        }
        if(DBUtility.GetInitialValue("password") != null){
        item.password.SetValue(DBUtility.GetInitialValue("password"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "login":
                    return this.login;
                case "password":
                    return this.password;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "login":
                    this.login = (TextField)value;
                    break;
                case "password":
                    this.password = (TextField)value;
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

    public void Validate(LoginDataProvider provider)
    {
//End Record Login Item Class

//login validate @8-E6B924CD
        if(login.Value==null||login.Value.ToString()=="")
            errors.Add("login",String.Format(Resources.strings.CCS_RequiredField,"login"));
//End login validate

//password validate @9-6A65C92B
        if(password.Value==null||password.Value.ToString()=="")
            errors.Add("password",String.Format(Resources.strings.CCS_RequiredField,"password"));
//End password validate

//Record Login Item Class tail @5-F5FC18C5
    }
}
//End Record Login Item Class tail

//Record Login Data Provider Class @5-12FA80C0
public class LoginDataProvider:RecordDataProviderBase
{
//End Record Login Data Provider Class

//Record Login Data Provider Class Variables @5-4973BB56
    protected LoginItem item;
//End Record Login Data Provider Class Variables

//Record Login Data Provider Class Constructor @5-362D05AD
    public LoginDataProvider()
    {
    }
//End Record Login Data Provider Class Constructor

//Record Login Data Provider Class LoadParams Method @5-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record Login Data Provider Class LoadParams Method

//Record Login Data Provider Class GetResultSet Method @5-EDBF3038
    public void FillItem(LoginItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
//End Record Login Data Provider Class GetResultSet Method

//Record Login BeforeBuildSelect @5-921CE95D
        if(!IsInsertMode){
//End Record Login BeforeBuildSelect

//Record Login AfterExecuteSelect @5-54D78817
        }
            IsInsertMode=true;
//End Record Login AfterExecuteSelect

//Record Login AfterExecuteSelect tail @5-FCB6E20C
    }
//End Record Login AfterExecuteSelect tail

//Record Login Data Provider Class @5-FCB6E20C
}

//End Record Login Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

