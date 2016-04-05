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

namespace calendar.admin.users_activate{ //Namespace @1-5391A87D

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

//Record users Item Class @3-C5A27935
public class usersItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField user_login;
    public TextField user_email;
    public TextField user_first_name;
    public TextField user_last_name;
    public DateField user_date_add;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        user_login=new TextField("", null);
        user_email=new TextField("", null);
        user_first_name=new TextField("", null);
        user_last_name=new TextField("", null);
        user_date_add=new DateField("G", null);
    }

    public static usersItem CreateFromHttpRequest()
    {
        usersItem item = new usersItem();
        if(DBUtility.GetInitialValue("user_login") != null){
        item.user_login.SetValue(DBUtility.GetInitialValue("user_login"));
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
        if(DBUtility.GetInitialValue("user_date_add") != null){
        item.user_date_add.SetValue(DBUtility.GetInitialValue("user_date_add"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "user_login":
                    return this.user_login;
                case "user_email":
                    return this.user_email;
                case "user_first_name":
                    return this.user_first_name;
                case "user_last_name":
                    return this.user_last_name;
                case "user_date_add":
                    return this.user_date_add;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user_login":
                    this.user_login = (TextField)value;
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
                case "user_date_add":
                    this.user_date_add = (DateField)value;
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

//Record users Item Class tail @3-F5FC18C5
    }
}
//End Record users Item Class tail

//Record users Data Provider Class @3-E483AB36
public class usersDataProvider:RecordDataProviderBase
{
//End Record users Data Provider Class

//Record users Data Provider Class Variables @3-2147C7F2
    protected usersItem item;
    public IntegerParameter Expr26;
    public IntegerParameter Expr27;
    public IntegerParameter Expr20;
    public IntegerParameter Expr22;
    public IntegerParameter Urluser_id;
//End Record users Data Provider Class Variables

//Record users Data Provider Class Constructor @3-894BEB33
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  user_login, user_email, user_first_name, user_last_name, \n" +
          "user_date_add \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"user_id8","And","expr26","And","expr27"},Settings.calendarDataAccessObject);
         Insert=new TableCommand("INSERT INTO users() VALUES ()", new string[0],Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE users SET user_is_approved={user_is_approved}, user_level={user_level}", new string[]{"user_id19"},Settings.calendarDataAccessObject);
         Delete=new TableCommand("DELETE FROM users", new string[]{"user_id18"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record users Data Provider Class Constructor

//Record users Data Provider Class LoadParams Method @3-A6BCCB15
    protected bool LoadParams()
    {
        return Urluser_id!=null&&Expr26!=null&&Expr27!=null;
    }
//End Record users Data Provider Class LoadParams Method

//Record users Data Provider Class CheckUnique Method @3-1E2F58F8
    public bool CheckUnique(string ControlName,usersItem item)
    {
        return true;
    }
//End Record users Data Provider Class CheckUnique Method

//Record users Data Provider Class PrepareInsert Method @3-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record users Data Provider Class PrepareInsert Method

//Record users Data Provider Class PrepareInsert Method tail @3-FCB6E20C
    }
//End Record users Data Provider Class PrepareInsert Method tail

//Record users Data Provider Class Insert Method @3-E2C0BE06
    public int InsertItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Insert Method

//Record users Build insert @3-E8FDDC6E
        Insert.Parameters.Clear();
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record users Build insert

//Record users AfterExecuteInsert @3-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record users AfterExecuteInsert

//Record users Data Provider Class PrepareUpdate Method @3-6CE3012C
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = Urluser_id!=null;
//End Record users Data Provider Class PrepareUpdate Method

//Record users Data Provider Class PrepareUpdate Method tail @3-FCB6E20C
    }
//End Record users Data Provider Class PrepareUpdate Method tail

//Record users Data Provider Class Update Method @3-C223194F
    public int UpdateItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Update Method

//Record users BeforeBuildUpdate @3-970B1045
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("user_id19",Urluser_id, "","user_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{user_is_approved}",Update.Dao.ToSql(Expr20==null?null:Expr20.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{user_level}",Update.Dao.ToSql(Expr22==null?null:Expr22.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record users BeforeBuildUpdate

//Record users AfterExecuteUpdate @3-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record users AfterExecuteUpdate

//Record users Data Provider Class PrepareDelete Method @3-4B93CB8F
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = Urluser_id!=null;
//End Record users Data Provider Class PrepareDelete Method

//Record users Data Provider Class PrepareDelete Method tail @3-FCB6E20C
    }
//End Record users Data Provider Class PrepareDelete Method tail

//Record users Data Provider Class Delete Method @3-B98CC950
    public int DeleteItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Delete Method

//Record users BeforeBuildDelete @3-DA3DB619
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("user_id18",Urluser_id, "","user_id",Condition.Equal,false);
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record users BeforeBuildDelete

//Record users BeforeBuildDelete @3-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record users BeforeBuildDelete

//Record users Data Provider Class GetResultSet Method @3-7B048C8D
    public void FillItem(usersItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record users Data Provider Class GetResultSet Method

//Record users BeforeBuildSelect @3-264AE601
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("user_id8",Urluser_id, "","user_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("expr26",Expr26, "","user_is_approved",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("expr27",Expr27, "","user_level",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record users BeforeBuildSelect

//Record users BeforeExecuteSelect @3-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record users BeforeExecuteSelect

//Record users AfterExecuteSelect @3-3791F3FC
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.user_login.SetValue(dr[i]["user_login"],"");
            item.user_email.SetValue(dr[i]["user_email"],"");
            item.user_first_name.SetValue(dr[i]["user_first_name"],"");
            item.user_last_name.SetValue(dr[i]["user_last_name"],"");
            item.user_date_add.SetValue(dr[i]["user_date_add"],Select.DateFormat);
        }
        else
            IsInsertMode=true;
//End Record users AfterExecuteSelect

//Record users AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record users AfterExecuteSelect tail

//Record users Data Provider Class @3-FCB6E20C
}

//End Record users Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

