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

namespace calendar.registration{ //Namespace @1-8EBE6325

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

//Record users Item Class @5-8B605912
public class usersItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField user_login;
    public TextField user_password;
    public TextField ConfirmPassword;
    public TextField user_first_name;
    public TextField user_last_name;
    public TextField user_email;
    public IntegerField user_is_approved;
    public IntegerField user_level;
    public IntegerField user_access_code;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        user_login=new TextField("", null);
        user_password=new TextField("", null);
        ConfirmPassword=new TextField("", null);
        user_first_name=new TextField("", null);
        user_last_name=new TextField("", null);
        user_email=new TextField("", null);
        user_is_approved=new IntegerField("", null);
        user_level=new IntegerField("", null);
        user_access_code=new IntegerField("", null);
    }

    public static usersItem CreateFromHttpRequest()
    {
        usersItem item = new usersItem();
        if(DBUtility.GetInitialValue("user_login") != null){
        item.user_login.SetValue(DBUtility.GetInitialValue("user_login"));
        }
        if(DBUtility.GetInitialValue("user_password") != null){
        item.user_password.SetValue(DBUtility.GetInitialValue("user_password"));
        }
        if(DBUtility.GetInitialValue("ConfirmPassword") != null){
        item.ConfirmPassword.SetValue(DBUtility.GetInitialValue("ConfirmPassword"));
        }
        if(DBUtility.GetInitialValue("user_first_name") != null){
        item.user_first_name.SetValue(DBUtility.GetInitialValue("user_first_name"));
        }
        if(DBUtility.GetInitialValue("user_last_name") != null){
        item.user_last_name.SetValue(DBUtility.GetInitialValue("user_last_name"));
        }
        if(DBUtility.GetInitialValue("user_email") != null){
        item.user_email.SetValue(DBUtility.GetInitialValue("user_email"));
        }
        if(DBUtility.GetInitialValue("user_is_approved") != null){
        item.user_is_approved.SetValue(DBUtility.GetInitialValue("user_is_approved"));
        }
        if(DBUtility.GetInitialValue("user_level") != null){
        item.user_level.SetValue(DBUtility.GetInitialValue("user_level"));
        }
        if(DBUtility.GetInitialValue("user_access_code") != null){
        item.user_access_code.SetValue(DBUtility.GetInitialValue("user_access_code"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "user_login":
                    return this.user_login;
                case "user_password":
                    return this.user_password;
                case "ConfirmPassword":
                    return this.ConfirmPassword;
                case "user_first_name":
                    return this.user_first_name;
                case "user_last_name":
                    return this.user_last_name;
                case "user_email":
                    return this.user_email;
                case "user_is_approved":
                    return this.user_is_approved;
                case "user_level":
                    return this.user_level;
                case "user_access_code":
                    return this.user_access_code;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user_login":
                    this.user_login = (TextField)value;
                    break;
                case "user_password":
                    this.user_password = (TextField)value;
                    break;
                case "ConfirmPassword":
                    this.ConfirmPassword = (TextField)value;
                    break;
                case "user_first_name":
                    this.user_first_name = (TextField)value;
                    break;
                case "user_last_name":
                    this.user_last_name = (TextField)value;
                    break;
                case "user_email":
                    this.user_email = (TextField)value;
                    break;
                case "user_is_approved":
                    this.user_is_approved = (IntegerField)value;
                    break;
                case "user_level":
                    this.user_level = (IntegerField)value;
                    break;
                case "user_access_code":
                    this.user_access_code = (IntegerField)value;
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

    public void Validate(usersDataProvider provider)
    {
//End Record users Item Class

//user_login validate @9-B48BE424
        if(user_login.Value==null||user_login.Value.ToString()=="")
            errors.Add("user_login",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_login));
        if(user_login!=null&&!provider.CheckUnique("user_login",this))
                errors.Add("user_login",String.Format(Resources.strings.CCS_UniqueValue,Resources.strings.user_login));
//End user_login validate

//user_password validate @10-F71FF037
        if(user_password.Value==null||user_password.Value.ToString()=="")
            errors.Add("user_password",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_password));
//End user_password validate

//ConfirmPassword validate @16-0FCDB5BA
        if(ConfirmPassword.Value==null||ConfirmPassword.Value.ToString()=="")
            errors.Add("ConfirmPassword",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_confirm_password));
//End ConfirmPassword validate

//user_first_name validate @12-0082B328
        if(user_first_name.Value==null||user_first_name.Value.ToString()=="")
            errors.Add("user_first_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_first_name));
//End user_first_name validate

//user_last_name validate @13-AAC525CC
        if(user_last_name.Value==null||user_last_name.Value.ToString()=="")
            errors.Add("user_last_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_last_name));
//End user_last_name validate

//user_email validate @11-7704B497
        if(user_email.Value==null||user_email.Value.ToString()=="")
            errors.Add("user_email",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_email));
        if(user_email!=null&&!provider.CheckUnique("user_email",this))
                errors.Add("user_email",String.Format(Resources.strings.CCS_UniqueValue,Resources.strings.user_email));
//End user_email validate

//Record users Event OnValidate. Action Custom Code @20-2A29BDB7
    // -------------------------
	if ( (string)user_password.Value != (string)ConfirmPassword.Value )  {
		errors.Add("user_password", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_difpass"));
	}
	if ( user_login.Value!=null && ((string)user_login.Value).Length > 0 && !CommonFunctions.CCRegExpTest((string)user_login.Value,"^[a-zA-Z0-9_\\-]{3,16}$", true, false) )  {
		errors.Add("user_login", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_login"));
	}
	if ( user_password.Value!=null && ((string)user_password.Value).Length > 0 && !CommonFunctions.CCRegExpTest((string)user_password.Value, "^[a-zA-Z0-9]{3,16}$", true, false) )  { 
		errors.Add("user_password", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_pass"));
	}
	if ( user_email.Value!=null && ((string)user_email.Value).Length > 0 && !CommonFunctions.CCRegExpTest((string)user_email.Value, "^[\\w\\.-]{1,}\\@([\\da-zA-Z-]{1,}\\.){1,}[\\da-zA-Z-]+$", true, false) )  { 
		errors.Add("user_email", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_email"));
	}
    // -------------------------
//End Record users Event OnValidate. Action Custom Code

//Record users Item Class tail @5-F5FC18C5
    }
}
//End Record users Item Class tail

//Record users Data Provider Class @5-E483AB36
public class usersDataProvider:RecordDataProviderBase
{
//End Record users Data Provider Class

//Record users Data Provider Class Variables @5-38B70BC9
    protected usersItem item;
    public IntegerParameter Urluser_id;
    public TextParameter Ctrluser_login;
    public TextParameter Ctrluser_password;
    public TextParameter Ctrluser_first_name;
    public TextParameter Ctrluser_last_name;
    public TextParameter Ctrluser_email;
    public IntegerParameter Ctrluser_is_approved;
    public IntegerParameter Ctrluser_level;
    public IntegerParameter Ctrluser_access_code;
    public DateParameter Expr34;
//End Record users Data Provider Class Variables

//Record users Data Provider Class Constructor @5-582992C7
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"user_id8"},Settings.calendarDataAccessObject);
         Insert=new TableCommand("INSERT INTO users(user_login, user_password, user_first_name, user_last_name, \n" +
          "user_email, user_is_approved, user_level, user_access_code, \n" +
          "user_date_add) VALUES ({user_login}, {user_password}, {user_first_name}, {user_last_name}," +
          " {user_email}, \n" +
          "{user_is_approved}, {user_level}, {user_access_code}, {user_date_add})", new string[0],Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record users Data Provider Class Constructor

//Record users Data Provider Class LoadParams Method @5-6A4B88F3
    protected bool LoadParams()
    {
        return Urluser_id!=null;
    }
//End Record users Data Provider Class LoadParams Method

//Record users Data Provider Class CheckUnique Method @5-1B7C7EB6
    public bool CheckUnique(string ControlName,usersItem item)
    {
        TableCommand Check=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users",
            new string[]{"user_id8"}
          ,Settings.calendarDataAccessObject);
        string CheckWhere="";
        switch(ControlName){
        case "user_login":
            CheckWhere="user_login="+Check.Dao.ToSql(item.user_login.GetFormattedValue(""),FieldType.Text);
            break;
        case "user_email":
            CheckWhere="user_email="+Check.Dao.ToSql(item.user_email.GetFormattedValue(""),FieldType.Text);
            break;
        }
        Check.Where=CheckWhere;
        Check.Operation="AND NOT";
        Check.Parameters.Clear();
        ((TableCommand)Check).AddParameter("user_id8",Urluser_id, "","user_id",Condition.Equal,false);
        if(Convert.ToInt32(Check.ExecuteScalar())>0)
            return false;
        else
        return true;
    }
//End Record users Data Provider Class CheckUnique Method

//Record users Data Provider Class PrepareInsert Method @5-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record users Data Provider Class PrepareInsert Method

//Record users Data Provider Class PrepareInsert Method tail @5-FCB6E20C
    }
//End Record users Data Provider Class PrepareInsert Method tail

//Record users Data Provider Class Insert Method @5-E2C0BE06
    public int InsertItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Insert Method

//Record users Build insert @5-C00FF0C0
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{user_login}",Insert.Dao.ToSql(item.user_login.Value==null?null:item.user_login.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_password}",Insert.Dao.ToSql(item.user_password.Value==null?null:item.user_password.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_first_name}",Insert.Dao.ToSql(item.user_first_name.Value==null?null:item.user_first_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_last_name}",Insert.Dao.ToSql(item.user_last_name.Value==null?null:item.user_last_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_email}",Insert.Dao.ToSql(item.user_email.Value==null?null:item.user_email.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_is_approved}",Insert.Dao.ToSql(item.user_is_approved.Value==null?null:item.user_is_approved.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{user_level}",Insert.Dao.ToSql(item.user_level.Value==null?null:item.user_level.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{user_access_code}",Insert.Dao.ToSql(item.user_access_code.Value==null?null:item.user_access_code.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{user_date_add}",Insert.Dao.ToSql(Expr34==null?null:Expr34.GetFormattedValue(Insert.DateFormat),FieldType.Date));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record users Build insert

//Record users AfterExecuteInsert @5-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record users AfterExecuteInsert

//Record users Data Provider Class GetResultSet Method @5-7B048C8D
    public void FillItem(usersItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record users Data Provider Class GetResultSet Method

//Record users BeforeBuildSelect @5-2171934A
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("user_id8",Urluser_id, "","user_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record users BeforeBuildSelect

//Record users BeforeExecuteSelect @5-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record users BeforeExecuteSelect

//Record users AfterExecuteSelect @5-103E26FE
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.user_login.SetValue(dr[i]["user_login"],"");
            item.user_password.SetValue(dr[i]["user_password"],"");
            item.user_first_name.SetValue(dr[i]["user_first_name"],"");
            item.user_last_name.SetValue(dr[i]["user_last_name"],"");
            item.user_email.SetValue(dr[i]["user_email"],"");
            item.user_is_approved.SetValue(dr[i]["user_is_approved"],"");
            item.user_level.SetValue(dr[i]["user_level"],"");
            item.user_access_code.SetValue(dr[i]["user_access_code"],"");
        }
        else
            IsInsertMode=true;
//End Record users AfterExecuteSelect

//Record users AfterExecuteSelect tail @5-FCB6E20C
    }
//End Record users AfterExecuteSelect tail

//Record users Data Provider Class @5-FCB6E20C
}

//End Record users Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

