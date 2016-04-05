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

namespace calendar.admin.index{ //Namespace @1-18CBE5C9

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

//Grid users Item Class @4-A652D396
public class usersItem:IDataItem
{
    public TextField users_TotalRecords;
    public IntegerField user_id;
    public TextField user_login;
    public object user_loginHref;
    public LinkParameterCollection user_loginHrefParameters;
    public TextField user_first_name;
    public TextField user_last_name;
    public TextField user_email;
    public DateField user_date_add;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        users_TotalRecords=new TextField("", null);
        user_id=new IntegerField("", null);
        user_login = new TextField("",null);
        user_loginHrefParameters = new LinkParameterCollection();
        user_first_name=new TextField("", null);
        user_last_name=new TextField("", null);
        user_email=new TextField("", null);
        user_date_add=new DateField(Settings.DateFormat, null);
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
                case "user_email":
                    return this.user_email;
                case "user_date_add":
                    return this.user_date_add;
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
                case "user_email":
                    this.user_email = (TextField)value;
                    break;
                case "user_date_add":
                    this.user_date_add = (DateField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid users Item Class

//Grid users Data Provider Class Header @4-FDACFC2D
public class usersDataProvider:GridDataProviderBase
{
//End Grid users Data Provider Class Header

//Grid users Data Provider Class Variables @4-683642A4
    public enum SortFields {Default,Sorter_user_id,Sorter_user_login,Sorter_user_first_name,Sorter_user_last_name,Sorter_user_email,Sorter_user_date_add}
    private string[] SortFieldsNames=new string[]{"user_id","user_id","user_login","user_first_name","user_last_name","user_email","user_date_add"};
    private string[] SortFieldsNamesDesc=new string[]{"user_id","user_id DESC","user_login DESC","user_first_name DESC","user_last_name DESC","user_email DESC","user_date_add DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=20;
    public int PageNumber=1;
    public IntegerParameter Expr61;
//End Grid users Data Provider Class Variables

//Grid users Data Provider Class Constructor @4-D2327433
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  user_id, user_login, user_email, user_first_name, \n" +
          "user_last_name, user_date_add \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"expr61"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users", new string[]{"expr61"},Settings.calendarDataAccessObject);
    }
//End Grid users Data Provider Class Constructor

//Grid users Data Provider Class GetResultSet Method @4-87BDA9E9
    public usersItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid users Data Provider Class GetResultSet Method

//Before build Select @4-3B4D64C0
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("expr61",Expr61, "","user_level",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @4-6870EE9B
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

//After execute Select @4-7836DC72
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new usersItem[dr.Count];
//End After execute Select

//After execute Select tail @4-AF2C3A1D
            for(int i=0;i<dr.Count;i++)
            {
                usersItem item=new usersItem();
                item.user_id.SetValue(dr[i]["user_id"],"");
                item.user_login.SetValue(dr[i]["user_login"],"");
                item.user_loginHref = "users_activate.aspx";
                item.user_loginHrefParameters.Add("user_id",System.Web.HttpUtility.UrlEncode(dr[i]["user_id"].ToString()));
                item.user_first_name.SetValue(dr[i]["user_first_name"],"");
                item.user_last_name.SetValue(dr[i]["user_last_name"],"");
                item.user_email.SetValue(dr[i]["user_email"],"");
                item.user_date_add.SetValue(dr[i]["user_date_add"],Select.DateFormat);
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @4-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

