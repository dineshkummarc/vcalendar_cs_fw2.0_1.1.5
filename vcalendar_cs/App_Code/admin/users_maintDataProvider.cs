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

namespace calendar.admin.users_maint{ //Namespace @1-613859CD

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

//Record users_maint Item Class @2-3555B480
public class users_maintItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField user_login;
    public TextField user_login_label;
    public TextField user_password;
    public IntegerField user_level;
    public ItemCollection user_levelItems;
    public TextField user_email;
    public TextField user_first_name;
    public TextField user_last_name;
    public IntegerField user_is_approved;
    public IntegerField user_is_approvedCheckedValue;
    public IntegerField user_is_approvedUncheckedValue;
    public DateField user_date_add;
    public DateField user_date_add_h;
    public NameValueCollection errors=new NameValueCollection();
    public users_maintItem()
    {
        user_login=new TextField("", null);
        user_login_label=new TextField("", null);
        user_password=new TextField("", null);
        user_level = new IntegerField("", null);
        user_levelItems = new ItemCollection();
        user_email=new TextField("", null);
        user_first_name=new TextField("", null);
        user_last_name=new TextField("", null);
        user_is_approved = new IntegerField("", null);
        user_is_approvedCheckedValue = new IntegerField("", 1);
        user_is_approvedUncheckedValue = new IntegerField("", 0);
        user_date_add=new DateField(Settings.DateFormat, null);
        user_date_add_h=new DateField("G", DateTime.Now);
    }

    public static users_maintItem CreateFromHttpRequest()
    {
        users_maintItem item = new users_maintItem();
        if(DBUtility.GetInitialValue("user_login") != null){
        item.user_login.SetValue(DBUtility.GetInitialValue("user_login"));
        }
        if(DBUtility.GetInitialValue("user_login_label") != null){
        item.user_login_label.SetValue(DBUtility.GetInitialValue("user_login_label"));
        }
        if(DBUtility.GetInitialValue("user_password") != null){
        item.user_password.SetValue(DBUtility.GetInitialValue("user_password"));
        }
        if(DBUtility.GetInitialValue("user_level") != null){
        item.user_level.SetValue(DBUtility.GetInitialValue("user_level"));
        }
        if(DBUtility.GetInitialValue("user_email") != null){
        item.user_email.SetValue(DBUtility.GetInitialValue("user_email"));
        }
        if(DBUtility.GetInitialValue("user_first_name") != null){
        item.user_first_name.SetValue(DBUtility.GetInitialValue("user_first_name"));
        }
        if(DBUtility.GetInitialValue("user_last_name") != null){
        item.user_last_name.SetValue(DBUtility.GetInitialValue("user_last_name"));
        }
        if(DBUtility.GetInitialValue("user_is_approved") != null){
        if(System.Web.HttpContext.Current.Request["user_is_approved"]!=null)
            item.user_is_approved.Value = item.user_is_approvedCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("user_date_add") != null){
        item.user_date_add.SetValue(DBUtility.GetInitialValue("user_date_add"));
        }
        if(DBUtility.GetInitialValue("user_date_add_h") != null){
        item.user_date_add_h.SetValue(DBUtility.GetInitialValue("user_date_add_h"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "user_login":
                    return this.user_login;
                case "user_login_label":
                    return this.user_login_label;
                case "user_password":
                    return this.user_password;
                case "user_level":
                    return this.user_level;
                case "user_email":
                    return this.user_email;
                case "user_first_name":
                    return this.user_first_name;
                case "user_last_name":
                    return this.user_last_name;
                case "user_is_approved":
                    return this.user_is_approved;
                case "user_date_add":
                    return this.user_date_add;
                case "user_date_add_h":
                    return this.user_date_add_h;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user_login":
                    this.user_login = (TextField)value;
                    break;
                case "user_login_label":
                    this.user_login_label = (TextField)value;
                    break;
                case "user_password":
                    this.user_password = (TextField)value;
                    break;
                case "user_level":
                    this.user_level = (IntegerField)value;
                    break;
                case "user_email":
                    this.user_email = (TextField)value;
                    break;
                case "user_first_name":
                    this.user_first_name = (TextField)value;
                    break;
                case "user_last_name":
                    this.user_last_name = (TextField)value;
                    break;
                case "user_is_approved":
                    this.user_is_approved = (IntegerField)value;
                    break;
                case "user_date_add":
                    this.user_date_add = (DateField)value;
                    break;
                case "user_date_add_h":
                    this.user_date_add_h = (DateField)value;
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

    public void Validate(users_maintDataProvider provider)
    {
//End Record users_maint Item Class

//user_login validate @3-8131EDC0
        if(user_login!=null&&!provider.CheckUnique("user_login",this))
                errors.Add("user_login",String.Format(Resources.strings.CCS_UniqueValue,Resources.strings.user_login));
//End user_login validate

//user_password validate @4-F71FF037
        if(user_password.Value==null||user_password.Value.ToString()=="")
            errors.Add("user_password",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_password));
//End user_password validate

//user_level validate @5-363DF65E
        if(user_level.Value==null||user_level.Value.ToString()=="")
            errors.Add("user_level",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_level));
//End user_level validate

//user_email validate @6-EDC1C74F
        if(user_email.Value==null||user_email.Value.ToString()=="")
            errors.Add("user_email",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_email));
        if(user_email.Value!=null){
            Regex mask = new Regex(@"^[\w\.-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase|RegexOptions.Multiline);
            if(!mask.Match(user_email.Value.ToString()).Success)
                errors.Add("user_email",String.Format(Resources.strings.CCS_MaskValidation,Resources.strings.user_email));
        }
//End user_email validate

//user_first_name validate @7-0082B328
        if(user_first_name.Value==null||user_first_name.Value.ToString()=="")
            errors.Add("user_first_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_first_name));
//End user_first_name validate

//user_last_name validate @8-AAC525CC
        if(user_last_name.Value==null||user_last_name.Value.ToString()=="")
            errors.Add("user_last_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_last_name));
//End user_last_name validate

//Record users_maint Event OnValidate. Action Custom Code @37-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Record users_maint Event OnValidate. Action Custom Code

//Record users_maint Item Class tail @2-F5FC18C5
    }
}
//End Record users_maint Item Class tail

//Record users_maint Data Provider Class @2-B9AEF954
public class users_maintDataProvider:RecordDataProviderBase
{
//End Record users_maint Data Provider Class

//Record users_maint Data Provider Class Variables @2-63D28775
    protected users_maintItem item;
    public TextParameter Ctrluser_login;
    public DateParameter Ctrluser_date_add_h;
    public IntegerParameter Urluser_id;
    public TextParameter Ctrluser_password;
    public IntegerParameter Ctrluser_level;
    public TextParameter Ctrluser_email;
    public TextParameter Ctrluser_first_name;
    public TextParameter Ctrluser_last_name;
    public IntegerParameter Ctrluser_is_approved;
//End Record users_maint Data Provider Class Variables

//Record users_maint Data Provider Class Constructor @2-20359868
    public users_maintDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"user_id14"},Settings.calendarDataAccessObject);
         Insert=new TableCommand("INSERT INTO users(user_login, user_password, user_level, user_email, \n" +
          "user_first_name, user_last_name, user_is_approved, user_date_add) VALUES ({user_login}, \n" +
          "{user_password}, {user_level}, {user_email}, {user_first_name}, {user_last_name}, \n" +
          "{user_is_approved}, {user_date_add})", new string[0],Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE users SET user_password={user_password}, user_level={user_level}, \n" +
          "user_email={user_email}, user_first_name={user_first_name}, \n" +
          "user_last_name={user_last_name}, user_is_approved={user_is_approved}", new string[]{"user_id27"},Settings.calendarDataAccessObject);
         Delete=new TableCommand("DELETE FROM users", new string[]{"user_id14"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record users_maint Data Provider Class Constructor

//Record users_maint Data Provider Class LoadParams Method @2-6A4B88F3
    protected bool LoadParams()
    {
        return Urluser_id!=null;
    }
//End Record users_maint Data Provider Class LoadParams Method

//Record users_maint Data Provider Class CheckUnique Method @2-8E044A14
    public bool CheckUnique(string ControlName,users_maintItem item)
    {
        TableCommand Check=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users",
            new string[]{"user_id14"}
          ,Settings.calendarDataAccessObject);
        string CheckWhere="";
        switch(ControlName){
        case "user_login":
            CheckWhere="user_login="+Check.Dao.ToSql(item.user_login.GetFormattedValue(""),FieldType.Text);
            break;
        }
        Check.Where=CheckWhere;
        Check.Operation="AND NOT";
        Check.Parameters.Clear();
        ((TableCommand)Check).AddParameter("user_id14",Urluser_id, "","user_id",Condition.Equal,false);
        if(Convert.ToInt32(Check.ExecuteScalar())>0)
            return false;
        else
        return true;
    }
//End Record users_maint Data Provider Class CheckUnique Method

//Record users_maint Data Provider Class PrepareInsert Method @2-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record users_maint Data Provider Class PrepareInsert Method

//Record users_maint Data Provider Class PrepareInsert Method tail @2-FCB6E20C
    }
//End Record users_maint Data Provider Class PrepareInsert Method tail

//Record users_maint Data Provider Class Insert Method @2-B42CB300
    public int InsertItem(users_maintItem item)
    {
        this.item = item;
//End Record users_maint Data Provider Class Insert Method

//Record users_maint Build insert @2-8E44BFD2
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{user_login}",Insert.Dao.ToSql(item.user_login.Value==null?null:item.user_login.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_password}",Insert.Dao.ToSql(item.user_password.Value==null?null:item.user_password.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_level}",Insert.Dao.ToSql(item.user_level.Value==null?null:item.user_level.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{user_email}",Insert.Dao.ToSql(item.user_email.Value==null?null:item.user_email.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_first_name}",Insert.Dao.ToSql(item.user_first_name.Value==null?null:item.user_first_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_last_name}",Insert.Dao.ToSql(item.user_last_name.Value==null?null:item.user_last_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{user_is_approved}",Insert.Dao.ToSql(item.user_is_approved.Value==null?null:item.user_is_approved.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{user_date_add}",Insert.Dao.ToSql(item.user_date_add_h.Value==null?null:item.user_date_add_h.GetFormattedValue(Insert.DateFormat),FieldType.Date));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record users_maint Build insert

//Record users_maint AfterExecuteInsert @2-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record users_maint AfterExecuteInsert

//Record users_maint Data Provider Class PrepareUpdate Method @2-6CE3012C
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = Urluser_id!=null;
//End Record users_maint Data Provider Class PrepareUpdate Method

//Record users_maint Data Provider Class PrepareUpdate Method tail @2-FCB6E20C
    }
//End Record users_maint Data Provider Class PrepareUpdate Method tail

//Record users_maint Data Provider Class Update Method @2-A2FB0314
    public int UpdateItem(users_maintItem item)
    {
        this.item = item;
//End Record users_maint Data Provider Class Update Method

//Record users_maint BeforeBuildUpdate @2-CC66444A
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("user_id27",Urluser_id, "","user_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{user_password}",Update.Dao.ToSql(item.user_password.Value==null?null:item.user_password.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{user_level}",Update.Dao.ToSql(item.user_level.Value==null?null:item.user_level.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{user_email}",Update.Dao.ToSql(item.user_email.Value==null?null:item.user_email.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{user_first_name}",Update.Dao.ToSql(item.user_first_name.Value==null?null:item.user_first_name.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{user_last_name}",Update.Dao.ToSql(item.user_last_name.Value==null?null:item.user_last_name.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{user_is_approved}",Update.Dao.ToSql(item.user_is_approved.Value==null?null:item.user_is_approved.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record users_maint BeforeBuildUpdate

//Record users_maint AfterExecuteUpdate @2-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record users_maint AfterExecuteUpdate

//Record users_maint Data Provider Class PrepareDelete Method @2-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record users_maint Data Provider Class PrepareDelete Method

//Record users_maint Data Provider Class PrepareDelete Method tail @2-FCB6E20C
    }
//End Record users_maint Data Provider Class PrepareDelete Method tail

//Record users_maint Data Provider Class Delete Method @2-942242E1
    public int DeleteItem(users_maintItem item)
    {
        this.item = item;
//End Record users_maint Data Provider Class Delete Method

//Record users_maint BeforeBuildDelete @2-4D9A275A
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("user_id14",Urluser_id, "","user_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{user_login}",Delete.Dao.ToSql(item.user_login.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{user_password}",Delete.Dao.ToSql(item.user_password.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{user_level}",Delete.Dao.ToSql(item.user_level.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{user_email}",Delete.Dao.ToSql(item.user_email.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{user_first_name}",Delete.Dao.ToSql(item.user_first_name.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{user_last_name}",Delete.Dao.ToSql(item.user_last_name.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{user_is_approved}",Delete.Dao.ToSql(item.user_is_approved.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record users_maint BeforeBuildDelete

//Record users_maint BeforeBuildDelete @2-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record users_maint BeforeBuildDelete

//Record users_maint Data Provider Class GetResultSet Method @2-B683C4BA
    public void FillItem(users_maintItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record users_maint Data Provider Class GetResultSet Method

//Record users_maint BeforeBuildSelect @2-85B10683
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("user_id14",Urluser_id, "","user_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record users_maint BeforeBuildSelect

//Record users_maint BeforeExecuteSelect @2-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record users_maint BeforeExecuteSelect

//Record users_maint AfterExecuteSelect @2-550D7CF4
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.user_login.SetValue(dr[i]["user_login"],"");
            item.user_login_label.SetValue(dr[i]["user_login"],"");
            item.user_password.SetValue(dr[i]["user_password"],"");
            item.user_level.SetValue(dr[i]["user_level"],"");
            item.user_email.SetValue(dr[i]["user_email"],"");
            item.user_first_name.SetValue(dr[i]["user_first_name"],"");
            item.user_last_name.SetValue(dr[i]["user_last_name"],"");
            item.user_is_approved.SetValue(dr[i]["user_is_approved"],"");
            item.user_date_add.SetValue(dr[i]["user_date_add"],Select.DateFormat);
        }
        else
            IsInsertMode=true;
//End Record users_maint AfterExecuteSelect

//ListBox user_level AfterExecuteSelect @5-9C03B4A0
        
item.user_levelItems.Add("1",Resources.strings.non_confirmed_user);
item.user_levelItems.Add("10",Resources.strings.user);
item.user_levelItems.Add("100",Resources.strings.admin);
//End ListBox user_level AfterExecuteSelect

//Record users_maint AfterExecuteSelect tail @2-FCB6E20C
    }
//End Record users_maint AfterExecuteSelect tail

//Record users_maint Data Provider Class @2-FCB6E20C
}

//End Record users_maint Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

