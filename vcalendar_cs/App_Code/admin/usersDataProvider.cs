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

namespace calendar.admin.users{ //Namespace @1-B68E7F41

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

//Record usersSearch Item Class @3-FDB090C7
public class usersSearchItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField s_keyword;
    public IntegerField s_user_level;
    public ItemCollection s_user_levelItems;
    public TextField s_user_is_approved;
    public ItemCollection s_user_is_approvedItems;
    public NameValueCollection errors=new NameValueCollection();
    public usersSearchItem()
    {
        s_keyword=new TextField("", null);
        s_user_level = new IntegerField("", null);
        s_user_levelItems = new ItemCollection();
        s_user_is_approved = new TextField("", null);
        s_user_is_approvedItems = new ItemCollection();
    }

    public static usersSearchItem CreateFromHttpRequest()
    {
        usersSearchItem item = new usersSearchItem();
        if(DBUtility.GetInitialValue("s_keyword") != null){
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"));
        }
        if(DBUtility.GetInitialValue("s_user_level") != null){
        item.s_user_level.SetValue(DBUtility.GetInitialValue("s_user_level"));
        }
        if(DBUtility.GetInitialValue("s_user_is_approved") != null){
        item.s_user_is_approved.SetValue(DBUtility.GetInitialValue("s_user_is_approved"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "s_keyword":
                    return this.s_keyword;
                case "s_user_level":
                    return this.s_user_level;
                case "s_user_is_approved":
                    return this.s_user_is_approved;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "s_keyword":
                    this.s_keyword = (TextField)value;
                    break;
                case "s_user_level":
                    this.s_user_level = (IntegerField)value;
                    break;
                case "s_user_is_approved":
                    this.s_user_is_approved = (TextField)value;
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

    public void Validate(usersSearchDataProvider provider)
    {
//End Record usersSearch Item Class

//Record usersSearch Item Class tail @3-F5FC18C5
    }
}
//End Record usersSearch Item Class tail

//Record usersSearch Data Provider Class @3-3C5EF1B1
public class usersSearchDataProvider:RecordDataProviderBase
{
//End Record usersSearch Data Provider Class

//Record usersSearch Data Provider Class Variables @3-95FE7174
    protected usersSearchItem item;
//End Record usersSearch Data Provider Class Variables

//Record usersSearch Data Provider Class Constructor @3-7778E04E
    public usersSearchDataProvider()
    {
    }
//End Record usersSearch Data Provider Class Constructor

//Record usersSearch Data Provider Class LoadParams Method @3-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record usersSearch Data Provider Class LoadParams Method

//Record usersSearch Data Provider Class GetResultSet Method @3-9C23C200
    public void FillItem(usersSearchItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record usersSearch Data Provider Class GetResultSet Method

//Record usersSearch BeforeBuildSelect @3-921CE95D
        if(!IsInsertMode){
//End Record usersSearch BeforeBuildSelect

//Record usersSearch AfterExecuteSelect @3-54D78817
        }
            IsInsertMode=true;
//End Record usersSearch AfterExecuteSelect

//ListBox s_user_level AfterExecuteSelect @59-310717D5
        
item.s_user_levelItems.Add("1",Resources.strings.non_confirmed_user);
item.s_user_levelItems.Add("10",Resources.strings.user);
item.s_user_levelItems.Add("100",Resources.strings.admin);
//End ListBox s_user_level AfterExecuteSelect

//ListBox s_user_is_approved AfterExecuteSelect @67-B1CD451A
        
item.s_user_is_approvedItems.Add("1",Resources.strings.yes);
item.s_user_is_approvedItems.Add("0",Resources.strings.no);
//End ListBox s_user_is_approved AfterExecuteSelect

//Record usersSearch AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record usersSearch AfterExecuteSelect tail

//Record usersSearch Data Provider Class @3-FCB6E20C
}

//End Record usersSearch Data Provider Class

//Grid users Item Class @2-0DBA0A9D
public class usersItem:IDataItem
{
    public TextField users_TotalRecords;
    public IntegerField user_id;
    public TextField user_login;
    public object user_loginHref;
    public LinkParameterCollection user_loginHrefParameters;
    public TextField user_first_name;
    public TextField user_last_name;
    public TextField user_level;
    public TextField user_email;
    public DateField user_date_add;
    public TextField user_last_login;
    public BooleanField user_is_approved;
    public TextField users_Insert;
    public object users_InsertHref;
    public LinkParameterCollection users_InsertHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        users_TotalRecords=new TextField("", null);
        user_id=new IntegerField("", null);
        user_login = new TextField("",null);
        user_loginHrefParameters = new LinkParameterCollection();
        user_first_name=new TextField("", null);
        user_last_name=new TextField("", null);
        user_level=new TextField("", null);
        user_email=new TextField("", null);
        user_date_add=new DateField("G", null);
        user_last_login=new TextField("", null);
        user_is_approved=new BooleanField(Settings.BoolFormat, null);
        users_Insert = new TextField("",null);
        users_InsertHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "users_TotalRecords":
                    return this.users_TotalRecords;
                case "user_id":
                    return this.user_id;
                case "user_login":
                    return this.user_login;
                case "user_first_name":
                    return this.user_first_name;
                case "user_last_name":
                    return this.user_last_name;
                case "user_level":
                    return this.user_level;
                case "user_email":
                    return this.user_email;
                case "user_date_add":
                    return this.user_date_add;
                case "user_last_login":
                    return this.user_last_login;
                case "user_is_approved":
                    return this.user_is_approved;
                case "users_Insert":
                    return this.users_Insert;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "users_TotalRecords":
                    this.users_TotalRecords = (TextField)value;
                    break;
                case "user_id":
                    this.user_id = (IntegerField)value;
                    break;
                case "user_login":
                    this.user_login = (TextField)value;
                    break;
                case "user_first_name":
                    this.user_first_name = (TextField)value;
                    break;
                case "user_last_name":
                    this.user_last_name = (TextField)value;
                    break;
                case "user_level":
                    this.user_level = (TextField)value;
                    break;
                case "user_email":
                    this.user_email = (TextField)value;
                    break;
                case "user_date_add":
                    this.user_date_add = (DateField)value;
                    break;
                case "user_last_login":
                    this.user_last_login = (TextField)value;
                    break;
                case "user_is_approved":
                    this.user_is_approved = (BooleanField)value;
                    break;
                case "users_Insert":
                    this.users_Insert = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid users Item Class

//Grid users Data Provider Class Header @2-FDACFC2D
public class usersDataProvider:GridDataProviderBase
{
//End Grid users Data Provider Class Header

//Grid users Data Provider Class Variables @2-3B91CCEF
    public enum SortFields {Default,Sorter_user_id,Sorter_user_login,Sorter_user_first_name,Sorter_user_last_name,Sorter_user_level,Sorter_user_email,Sorter_user_date_add,Sorter_user_last_login,Sorter_user_is_approved}
    private string[] SortFieldsNames=new string[]{"user_id","user_id","user_login","user_first_name","user_last_name","user_level","user_email","user_date_add","user_last_login","user_is_approved"};
    private string[] SortFieldsNamesDesc=new string[]{"user_id","user_id DESC","user_login DESC","user_first_name DESC","user_last_name DESC","user_level DESC","user_email DESC","user_date_add DESC","user_last_login DESC","user_is_approved DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=20;
    public int PageNumber=1;
    public TextParameter Urls_keyword;
    public IntegerParameter Urls_user_level;
    public IntegerParameter Urls_user_is_approved;
//End Grid users Data Provider Class Variables

//Grid users Data Provider Class Constructor @2-F11ECA90
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  user_id, user_login, user_level, user_email, \n" +
          "user_first_name, user_last_name, user_is_approved, user_access_code, \n" +
          "user_date_add,\n" +
          "user_last_login \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"(","s_keyword10","Or","s_keyword11","Or","s_keyword12","Or","s_keyword13",")","And","s_user_level61","And","s_user_is_approved68"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users", new string[]{"(","s_keyword10","Or","s_keyword11","Or","s_keyword12","Or","s_keyword13",")","And","s_user_level61","And","s_user_is_approved68"},Settings.calendarDataAccessObject);
    }
//End Grid users Data Provider Class Constructor

//Grid users Data Provider Class GetResultSet Method @2-87BDA9E9
    public usersItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid users Data Provider Class GetResultSet Method

//Before build Select @2-B1CF0730
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("s_keyword10",Urls_keyword, "","user_login",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_keyword11",Urls_keyword, "","user_email",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_keyword12",Urls_keyword, "","user_first_name",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_keyword13",Urls_keyword, "","user_last_name",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_user_level61",Urls_user_level, "","user_level",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_user_is_approved68",Urls_user_is_approved, "","user_is_approved",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @2-6870EE9B
        DataSet ds=null;
        _pagesCount=0;
        usersItem[] result = new usersItem[0];
        if (ops.AllowRead) {
            try{
                if(RecordsPerPage>0)
                {
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage);
                    _pagesCount = ExecuteCount();
                    mRecordCount = _pagesCount;
                    _pagesCount = _pagesCount%RecordsPerPage>0?(int)(_pagesCount/RecordsPerPage)+1:(int)(_pagesCount/RecordsPerPage);
                }
                else
                {
                ds=ExecuteSelect();
                if(ds.Tables[tableIndex].Rows.Count!=0){
                    _pagesCount=1;mRecordCount = ds.Tables[tableIndex].Rows.Count;}
                }
            }catch(Exception e){
                E=e;}
            finally{
//End Execute Select

//After execute Select @2-7836DC72
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new usersItem[dr.Count];
//End After execute Select

//After execute Select tail @2-BA90A217
            for(int i=0;i<dr.Count;i++)
            {
                usersItem item=new usersItem();
                item.user_id.SetValue(dr[i]["user_id"],"");
                item.user_login.SetValue(dr[i]["user_login"],"");
                item.user_loginHref = "users_maint.aspx";
                item.user_loginHrefParameters.Add("user_id",System.Web.HttpUtility.UrlEncode(dr[i]["user_id"].ToString()));
                item.user_first_name.SetValue(dr[i]["user_first_name"],"");
                item.user_last_name.SetValue(dr[i]["user_last_name"],"");
                item.user_level.SetValue(dr[i]["user_level"],"");
                item.user_email.SetValue(dr[i]["user_email"],"");
                item.user_date_add.SetValue(dr[i]["user_date_add"],Select.DateFormat);
                item.user_last_login.SetValue(dr[i]["user_last_login"],"");
                item.user_is_approved.SetValue(dr[i]["user_is_approved"],"1;0");
                item.users_InsertHref = "users_maint.aspx";
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @2-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

