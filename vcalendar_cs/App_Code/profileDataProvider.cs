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

namespace calendar.profile{ //Namespace @1-8B1D1898

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

//Record users Item Class @16-290C5ED6
public class usersItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField user_login;
    public TextField user_email;
    public TextField user_first_name;
    public TextField user_last_name;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        user_login=new TextField("", null);
        user_email=new TextField("", null);
        user_first_name=new TextField("", null);
        user_last_name=new TextField("", null);
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

//user_email validate @18-68D14CA3
        if(user_email.Value==null||user_email.Value.ToString()=="")
            errors.Add("user_email",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_email));
//End user_email validate

//user_first_name validate @19-0082B328
        if(user_first_name.Value==null||user_first_name.Value.ToString()=="")
            errors.Add("user_first_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_first_name));
//End user_first_name validate

//user_last_name validate @20-AAC525CC
        if(user_last_name.Value==null||user_last_name.Value.ToString()=="")
            errors.Add("user_last_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.user_last_name));
//End user_last_name validate

//Record users Item Class tail @16-F5FC18C5
    }
}
//End Record users Item Class tail

//Record users Data Provider Class @16-E483AB36
public class usersDataProvider:RecordDataProviderBase
{
//End Record users Data Provider Class

//Record users Data Provider Class Variables @16-1F6B326C
    protected usersItem item;
    public IntegerParameter Expr22;
//End Record users Data Provider Class Variables

//Record users Data Provider Class Constructor @16-A76E3355
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"expr22"},Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE users SET user_email={user_email}, user_first_name={user_first_name}, \n" +
          "user_last_name={user_last_name}", new string[]{"expr22"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record users Data Provider Class Constructor

//Record users Data Provider Class LoadParams Method @16-BEFB520D
    protected bool LoadParams()
    {
        return Expr22!=null;
    }
//End Record users Data Provider Class LoadParams Method

//Record users Data Provider Class CheckUnique Method @16-1E2F58F8
    public bool CheckUnique(string ControlName,usersItem item)
    {
        return true;
    }
//End Record users Data Provider Class CheckUnique Method

//Record users Data Provider Class PrepareUpdate Method @16-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record users Data Provider Class PrepareUpdate Method

//Record users Data Provider Class PrepareUpdate Method tail @16-FCB6E20C
    }
//End Record users Data Provider Class PrepareUpdate Method tail

//Record users Data Provider Class Update Method @16-C223194F
    public int UpdateItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Update Method

//Record users BeforeBuildUpdate @16-B36F6E0D
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("expr22",Expr22, "","user_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{user_email}",Update.Dao.ToSql(item.user_email.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{user_first_name}",Update.Dao.ToSql(item.user_first_name.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{user_last_name}",Update.Dao.ToSql(item.user_last_name.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record users BeforeBuildUpdate

//Record users AfterExecuteUpdate @16-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record users AfterExecuteUpdate

//Record users Data Provider Class GetResultSet Method @16-7B048C8D
    public void FillItem(usersItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record users Data Provider Class GetResultSet Method

//Record users BeforeBuildSelect @16-2A17007C
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("expr22",Expr22, "","user_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record users BeforeBuildSelect

//Record users BeforeExecuteSelect @16-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record users BeforeExecuteSelect

//Record users AfterExecuteSelect @16-F13BCC3C
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
        }
        else
            IsInsertMode=true;
//End Record users AfterExecuteSelect

//Record users AfterExecuteSelect tail @16-FCB6E20C
    }
//End Record users AfterExecuteSelect tail

//Record users Data Provider Class @16-FCB6E20C
}

//End Record users Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

