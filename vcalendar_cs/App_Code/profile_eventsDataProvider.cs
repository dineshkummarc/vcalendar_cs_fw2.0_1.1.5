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

namespace calendar.profile_events{ //Namespace @1-6F39DEE8

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

//Record events_groupsSearch Item Class @9-35235B85
public class events_groupsSearchItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField s_keyword;
    public TextField s_category;
    public ItemCollection s_categoryItems;
    public DateField s_date_from;
    public DateField s_date_to;
    public NameValueCollection errors=new NameValueCollection();
    public events_groupsSearchItem()
    {
        s_keyword=new TextField("", null);
        s_category = new TextField("", null);
        s_categoryItems = new ItemCollection();
        s_date_from=new DateField("d", null);
        s_date_to=new DateField("d", null);
    }

    public static events_groupsSearchItem CreateFromHttpRequest()
    {
        events_groupsSearchItem item = new events_groupsSearchItem();
        if(DBUtility.GetInitialValue("s_keyword") != null){
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"));
        }
        if(DBUtility.GetInitialValue("s_category") != null){
        item.s_category.SetValue(DBUtility.GetInitialValue("s_category"));
        }
        if(DBUtility.GetInitialValue("s_date_from") != null){
        item.s_date_from.SetValue(DBUtility.GetInitialValue("s_date_from"));
        }
        if(DBUtility.GetInitialValue("s_date_to") != null){
        item.s_date_to.SetValue(DBUtility.GetInitialValue("s_date_to"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "s_keyword":
                    return this.s_keyword;
                case "s_category":
                    return this.s_category;
                case "s_date_from":
                    return this.s_date_from;
                case "s_date_to":
                    return this.s_date_to;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "s_keyword":
                    this.s_keyword = (TextField)value;
                    break;
                case "s_category":
                    this.s_category = (TextField)value;
                    break;
                case "s_date_from":
                    this.s_date_from = (DateField)value;
                    break;
                case "s_date_to":
                    this.s_date_to = (DateField)value;
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

    public void Validate(events_groupsSearchDataProvider provider)
    {
//End Record events_groupsSearch Item Class

//Record events_groupsSearch Item Class tail @9-F5FC18C5
    }
}
//End Record events_groupsSearch Item Class tail

//Record events_groupsSearch Data Provider Class @9-CDF4A8DA
public class events_groupsSearchDataProvider:RecordDataProviderBase
{
//End Record events_groupsSearch Data Provider Class

//Record events_groupsSearch Data Provider Class Variables @9-C28C6EBB
    protected DataCommand s_categoryDataCommand;
    protected events_groupsSearchItem item;
    public TextParameter Seslocale;
//End Record events_groupsSearch Data Provider Class Variables

//Record events_groupsSearch Data Provider Class Constructor @9-8823792E
    public events_groupsSearchDataProvider()
    {
         s_categoryDataCommand=new TableCommand("SELECT category_name, \n" +
          "category_id \n" +
          "FROM categories_langs {SQL_Where} {SQL_OrderBy}", new string[]{"locale42"},Settings.calendarDataAccessObject);
    }
//End Record events_groupsSearch Data Provider Class Constructor

//Record events_groupsSearch Data Provider Class LoadParams Method @9-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record events_groupsSearch Data Provider Class LoadParams Method

//Record events_groupsSearch Data Provider Class GetResultSet Method @9-0747E9FF
    public void FillItem(events_groupsSearchItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record events_groupsSearch Data Provider Class GetResultSet Method

//Record events_groupsSearch BeforeBuildSelect @9-921CE95D
        if(!IsInsertMode){
//End Record events_groupsSearch BeforeBuildSelect

//Record events_groupsSearch AfterExecuteSelect @9-C5999683
        }
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record events_groupsSearch AfterExecuteSelect

//ListBox s_category Initialize Data Source @29-1FBFB903
        int s_categorytableIndex = 0;
        s_categoryDataCommand.OrderBy = "";
        s_categoryDataCommand.Parameters.Clear();
        ((TableCommand)s_categoryDataCommand).AddParameter("locale42",Seslocale, "","language_id",Condition.Equal,false);
//End ListBox s_category Initialize Data Source

//ListBox s_category BeforeExecuteSelect @29-3C27F2D2
        try{
            ListBoxSource=s_categoryDataCommand.Execute().Tables[s_categorytableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_category BeforeExecuteSelect

//ListBox s_category AfterExecuteSelect @29-104C4990
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["category_name"];
            string key = (new TextField("", ListBoxSource[li]["category_id"])).GetFormattedValue("");
            item.s_categoryItems.Add(key,val);
        }
//End ListBox s_category AfterExecuteSelect

//Record events_groupsSearch AfterExecuteSelect tail @9-FCB6E20C
    }
//End Record events_groupsSearch AfterExecuteSelect tail

//Record events_groupsSearch Data Provider Class @9-FCB6E20C
}

//End Record events_groupsSearch Data Provider Class

//Grid events_groups Item Class @5-DC7F2AF4
public class events_groupsItem:IDataItem
{
    public TextField events_groups_TotalRecords;
    public TextField EditLink;
    public object EditLinkHref;
    public LinkParameterCollection EditLinkHrefParameters;
    public TextField event_title;
    public object event_titleHref;
    public LinkParameterCollection event_titleHrefParameters;
    public DateField event_date;
    public DateField event_time;
    public DateField event_time_end;
    public TextField category_name;
    public NameValueCollection errors=new NameValueCollection();
    public events_groupsItem()
    {
        events_groups_TotalRecords=new TextField("", null);
        EditLink = new TextField("",null);
        EditLinkHrefParameters = new LinkParameterCollection();
        event_title = new TextField("",null);
        event_titleHrefParameters = new LinkParameterCollection();
        event_date=new DateField("d", null);
        event_time=new DateField("t", null);
        event_time_end=new DateField("t", null);
        category_name=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "events_groups_TotalRecords":
                    return this.events_groups_TotalRecords;
                case "EditLink":
                    return this.EditLink;
                case "event_title":
                    return this.event_title;
                case "event_date":
                    return this.event_date;
                case "event_time":
                    return this.event_time;
                case "event_time_end":
                    return this.event_time_end;
                case "category_name":
                    return this.category_name;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "events_groups_TotalRecords":
                    this.events_groups_TotalRecords = (TextField)value;
                    break;
                case "EditLink":
                    this.EditLink = (TextField)value;
                    break;
                case "event_title":
                    this.event_title = (TextField)value;
                    break;
                case "event_date":
                    this.event_date = (DateField)value;
                    break;
                case "event_time":
                    this.event_time = (DateField)value;
                    break;
                case "event_time_end":
                    this.event_time_end = (DateField)value;
                    break;
                case "category_name":
                    this.category_name = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid events_groups Item Class

//Grid events_groups Data Provider Class Header @5-5C9ED32C
public class events_groupsDataProvider:GridDataProviderBase
{
//End Grid events_groups Data Provider Class Header

//Grid events_groups Data Provider Class Variables @5-69A1917B
    public enum SortFields {Default,Sorter_event_title,Sorter_event_date,Sorter_event_time,Sorter_category}
    private string[] SortFieldsNames=new string[]{"","event_title","event_date","event_time","categories.category_name"};
    private string[] SortFieldsNamesDesc=new string[]{"","event_title DESC","event_date DESC","event_time DESC","categories.category_name DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public MemoParameter Urls_keyword;
    public IntegerParameter Urls_category;
    public TextParameter Seslocale;
    public IntegerParameter Urlcategories_langs_category_id;
    public IntegerParameter SesUserID;
    public DateParameter Urls_date_from;
    public DateParameter Urls_date_to;
//End Grid events_groups Data Provider Class Variables

//Grid events_groups Data Provider Class Constructor @5-51FDE678
    public events_groupsDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  events.*, \n" +
          "category_name \n" +
          "FROM events LEFT JOIN categories_langs ON\n" +
          "events.category_id = categories_langs.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"(","s_keyword14","Or","s_keyword15",")","And","s_category16","And","(","locale52","Or","categories_langs_category_id57",")","And","UserID58","And","s_date_from66","And","s_date_to67"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM events LEFT JOIN categories_langs ON\n" +
          "events.category_id = categories_langs.category_id", new string[]{"(","s_keyword14","Or","s_keyword15",")","And","s_category16","And","(","locale52","Or","categories_langs_category_id57",")","And","UserID58","And","s_date_from66","And","s_date_to67"},Settings.calendarDataAccessObject);
    }
//End Grid events_groups Data Provider Class Constructor

//Grid events_groups Data Provider Class GetResultSet Method @5-C7C2A414
    public events_groupsItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid events_groups Data Provider Class GetResultSet Method

//Grid events_groups Event BeforeBuildSelect. Action Custom Code @33-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Grid events_groups Event BeforeBuildSelect. Action Custom Code

//Before build Select @5-38E9DA3F
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("s_keyword14",Urls_keyword, "","events.event_title",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_keyword15",Urls_keyword, "","events.event_desc",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_category16",Urls_category, "","events.category_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("locale52",Seslocale, "","categories_langs.language_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("categories_langs_category_id57",Urlcategories_langs_category_id, "","categories_langs.category_id",Condition.IsNull,true);
        ((TableCommand)Select).AddParameter("UserID58",SesUserID, "","events.user_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_date_from66",Urls_date_from, Select.DateFormat,"events.event_date",Condition.GreaterThanOrEqual,false);
        ((TableCommand)Select).AddParameter("s_date_to67",Urls_date_to, Select.DateFormat,"events.event_date",Condition.LessThanOrEqual,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @5-A699D44C
        DataSet ds=null;
        _pagesCount=0;
        events_groupsItem[] result = new events_groupsItem[0];
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

//After execute Select @5-D95040A7
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new events_groupsItem[dr.Count];
//End After execute Select

//After execute Select tail @5-1886D4B3
            for(int i=0;i<dr.Count;i++)
            {
                events_groupsItem item=new events_groupsItem();
                item.EditLinkHref = "events.aspx";
                item.EditLinkHrefParameters.Add("event_id",System.Web.HttpUtility.UrlEncode(dr[i]["event_id"].ToString()));
                item.event_title.SetValue(dr[i]["event_title"],"");
                item.event_titleHref = "event_view.aspx";
                item.event_titleHrefParameters.Add("event_id",System.Web.HttpUtility.UrlEncode(dr[i]["event_id"].ToString()));
                item.event_date.SetValue(dr[i]["event_date"],"yyyy-MM-dd");
                item.event_time.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                item.event_time_end.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
                item.category_name.SetValue(dr[i]["category_name"],"");
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @5-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

