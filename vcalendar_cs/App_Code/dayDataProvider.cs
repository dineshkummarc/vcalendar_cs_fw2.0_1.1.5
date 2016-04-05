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

namespace calendar.day{ //Namespace @1-E6CB5B89

//Page Data Class @1-DC035894
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.FullViewEvents.SetValue(DBUtility.GetInitialValue("FullViewEvents"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "FullViewEvents":
                    return this.FullViewEvents;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "FullViewEvents":
                    this.FullViewEvents = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField FullViewEvents;
    public PageItem()
    {
        FullViewEvents=new TextField("", null);
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

//Grid ShortViewEventsGrid Item Class @237-08DD4C73
public class ShortViewEventsGridItem:IDataItem
{
    public DateField CalendarDate;
    public DateField add_event_spacer;
    public TextField add_event;
    public object add_eventHref;
    public LinkParameterCollection add_eventHrefParameters;
    public DateField event_time;
    public DateField event_time_end;
    public TextField category_image;
    public TextField event_title;
    public object event_titleHref;
    public LinkParameterCollection event_titleHrefParameters;
    public TextField category_name;
    public NameValueCollection errors=new NameValueCollection();
    public ShortViewEventsGridItem()
    {
        CalendarDate=new DateField("MMMM d, yyyy, dddd", null);
        add_event_spacer=new DateField("MMMM d, yyyy, dddd", null);
        add_event = new TextField("",null);
        add_eventHrefParameters = new LinkParameterCollection();
        event_time=new DateField("t", null);
        event_time_end=new DateField("t", null);
        category_image=new TextField("", null);
        event_title = new TextField("",null);
        event_titleHrefParameters = new LinkParameterCollection();
        category_name=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "CalendarDate":
                    return this.CalendarDate;
                case "add_event_spacer":
                    return this.add_event_spacer;
                case "add_event":
                    return this.add_event;
                case "event_time":
                    return this.event_time;
                case "event_time_end":
                    return this.event_time_end;
                case "category_image":
                    return this.category_image;
                case "event_title":
                    return this.event_title;
                case "category_name":
                    return this.category_name;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "CalendarDate":
                    this.CalendarDate = (DateField)value;
                    break;
                case "add_event_spacer":
                    this.add_event_spacer = (DateField)value;
                    break;
                case "add_event":
                    this.add_event = (TextField)value;
                    break;
                case "event_time":
                    this.event_time = (DateField)value;
                    break;
                case "event_time_end":
                    this.event_time_end = (DateField)value;
                    break;
                case "category_image":
                    this.category_image = (TextField)value;
                    break;
                case "event_title":
                    this.event_title = (TextField)value;
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
//End Grid ShortViewEventsGrid Item Class

//Grid ShortViewEventsGrid Data Provider Class Header @237-9343EDBB
public class ShortViewEventsGridDataProvider:GridDataProviderBase
{
//End Grid ShortViewEventsGrid Data Provider Class Header

//Grid ShortViewEventsGrid Data Provider Class Variables @237-24D7C287
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{"events.event_time desc"};
    private string[] SortFieldsNamesDesc=new string[]{"events.event_time desc"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=100;
    public int PageNumber=1;
    public DateParameter Urlday;
    public IntegerParameter Sescategory;
    public TextParameter Seslocale;
    public IntegerParameter Urlevents_category_id;
//End Grid ShortViewEventsGrid Data Provider Class Variables

//Grid ShortViewEventsGrid Data Provider Class Constructor @237-612BACDC
    public ShortViewEventsGridDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  event_title, event_time, event_id, \n" +
          "categories_langs.category_name AS category_name, category_image, event_time_end, \n" +
          "event_is_public \n" +
          "FROM events LEFT JOIN (categories LEFT JOIN categories_langs ON\n" +
          "categories.category_id = categories_langs.category_id) ON\n" +
          "events.category_id = categories.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"day71","And","category72","And","(","locale73","Or","events_category_id74",")"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM events LEFT JOIN (categories LEFT JOIN categories_langs ON\n" +
          "categories.category_id = categories_langs.category_id) ON\n" +
          "events.category_id = categories.category_id", new string[]{"day71","And","category72","And","(","locale73","Or","events_category_id74",")"},Settings.calendarDataAccessObject);
    }
//End Grid ShortViewEventsGrid Data Provider Class Constructor

//Grid ShortViewEventsGrid Data Provider Class GetResultSet Method @237-A601A2BE
    public ShortViewEventsGridItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid ShortViewEventsGrid Data Provider Class GetResultSet Method

//Grid ShortViewEventsGrid Event BeforeBuildSelect. Action Custom Code @243-2A29BDB7
    // -------------------------
		if (CommonFunctions.CCGetFromGet("day", "").Length == 0) 
			Urlday = DateParameter.GetParam(DateTime.Today, "yyyy-MM-dd");

		string WhereClause = CommonFunctions.AddReadFilter("");
		((TableCommand)Select).Operation = "And";
		((TableCommand)Select).Where = WhereClause;
		((TableCommand)Count).Operation = "And";
		((TableCommand)Count).Where = WhereClause;
    // -------------------------
//End Grid ShortViewEventsGrid Event BeforeBuildSelect. Action Custom Code

//Before build Select @237-A1BED129
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("day71",Urlday, Select.DateFormat,"events.event_date",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("category72",Sescategory, "","events.category_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("locale73",Seslocale, "","categories_langs.language_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("events_category_id74",Urlevents_category_id, "","events.category_id",Condition.IsNull,true);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @237-1BA3E73D
        DataSet ds=null;
        _pagesCount=0;
        ShortViewEventsGridItem[] result = new ShortViewEventsGridItem[0];
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

//After execute Select @237-7D8CD050
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new ShortViewEventsGridItem[dr.Count];
//End After execute Select

//After execute Select tail @237-F4FDB820
            for(int i=0;i<dr.Count;i++)
            {
                ShortViewEventsGridItem item=new ShortViewEventsGridItem();
                item.add_eventHref = "events.aspx";
                item.event_time.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                item.event_time_end.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
                item.category_image.SetValue(dr[i]["category_image"],"");
                item.event_title.SetValue(dr[i]["event_title"],"");
                item.event_titleHref = "event_view.aspx";
                item.event_titleHrefParameters.Add("event_id",System.Web.HttpUtility.UrlEncode(dr[i]["event_id"].ToString()));
                item.category_name.SetValue(dr[i]["category_name"],"");
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @237-FCB6E20C
}
//End Grid Data Provider tail

//Record ShortViewEventsNavigator Item Class @85-F20595FD
public class ShortViewEventsNavigatorItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField prev_day_link;
    public object prev_day_linkHref;
    public LinkParameterCollection prev_day_linkHrefParameters;
    public TextField date_day;
    public ItemCollection date_dayItems;
    public TextField next_day_link;
    public object next_day_linkHref;
    public LinkParameterCollection next_day_linkHrefParameters;
    public TextField week;
    public ItemCollection weekItems;
    public TextField YearIcon;
    public object YearIconHref;
    public LinkParameterCollection YearIconHrefParameters;
    public TextField MonthIcon;
    public object MonthIconHref;
    public LinkParameterCollection MonthIconHrefParameters;
    public TextField WeekIcon;
    public object WeekIconHref;
    public LinkParameterCollection WeekIconHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public ShortViewEventsNavigatorItem()
    {
        prev_day_link = new TextField("",null);
        prev_day_linkHrefParameters = new LinkParameterCollection();
        date_day = new TextField("", null);
        date_dayItems = new ItemCollection();
        next_day_link = new TextField("",null);
        next_day_linkHrefParameters = new LinkParameterCollection();
        week = new TextField("", null);
        weekItems = new ItemCollection();
        YearIcon = new TextField("",null);
        YearIconHrefParameters = new LinkParameterCollection();
        MonthIcon = new TextField("",null);
        MonthIconHrefParameters = new LinkParameterCollection();
        WeekIcon = new TextField("",null);
        WeekIconHrefParameters = new LinkParameterCollection();
    }

    public static ShortViewEventsNavigatorItem CreateFromHttpRequest()
    {
        ShortViewEventsNavigatorItem item = new ShortViewEventsNavigatorItem();
        if(DBUtility.GetInitialValue("prev_day_link") != null){
        item.prev_day_link.SetValue(DBUtility.GetInitialValue("prev_day_link"));
        }
        if(DBUtility.GetInitialValue("date_day") != null){
        item.date_day.SetValue(DBUtility.GetInitialValue("date_day"));
        }
        if(DBUtility.GetInitialValue("next_day_link") != null){
        item.next_day_link.SetValue(DBUtility.GetInitialValue("next_day_link"));
        }
        if(DBUtility.GetInitialValue("week") != null){
        item.week.SetValue(DBUtility.GetInitialValue("week"));
        }
        if(DBUtility.GetInitialValue("YearIcon") != null){
        item.YearIcon.SetValue(DBUtility.GetInitialValue("YearIcon"));
        }
        if(DBUtility.GetInitialValue("MonthIcon") != null){
        item.MonthIcon.SetValue(DBUtility.GetInitialValue("MonthIcon"));
        }
        if(DBUtility.GetInitialValue("WeekIcon") != null){
        item.WeekIcon.SetValue(DBUtility.GetInitialValue("WeekIcon"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "prev_day_link":
                    return this.prev_day_link;
                case "date_day":
                    return this.date_day;
                case "next_day_link":
                    return this.next_day_link;
                case "week":
                    return this.week;
                case "YearIcon":
                    return this.YearIcon;
                case "MonthIcon":
                    return this.MonthIcon;
                case "WeekIcon":
                    return this.WeekIcon;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "prev_day_link":
                    this.prev_day_link = (TextField)value;
                    break;
                case "date_day":
                    this.date_day = (TextField)value;
                    break;
                case "next_day_link":
                    this.next_day_link = (TextField)value;
                    break;
                case "week":
                    this.week = (TextField)value;
                    break;
                case "YearIcon":
                    this.YearIcon = (TextField)value;
                    break;
                case "MonthIcon":
                    this.MonthIcon = (TextField)value;
                    break;
                case "WeekIcon":
                    this.WeekIcon = (TextField)value;
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

    public void Validate(ShortViewEventsNavigatorDataProvider provider)
    {
//End Record ShortViewEventsNavigator Item Class

//Record ShortViewEventsNavigator Item Class tail @85-F5FC18C5
    }
}
//End Record ShortViewEventsNavigator Item Class tail

//Record ShortViewEventsNavigator Data Provider Class @85-B2E717B8
public class ShortViewEventsNavigatorDataProvider:RecordDataProviderBase
{
//End Record ShortViewEventsNavigator Data Provider Class

//Record ShortViewEventsNavigator Data Provider Class Variables @85-6A822029
    protected ShortViewEventsNavigatorItem item;
//End Record ShortViewEventsNavigator Data Provider Class Variables

//Record ShortViewEventsNavigator Data Provider Class Constructor @85-B541C646
    public ShortViewEventsNavigatorDataProvider()
    {
    }
//End Record ShortViewEventsNavigator Data Provider Class Constructor

//Record ShortViewEventsNavigator Data Provider Class LoadParams Method @85-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record ShortViewEventsNavigator Data Provider Class LoadParams Method

//Record ShortViewEventsNavigator Data Provider Class GetResultSet Method @85-903D9CE0
    public void FillItem(ShortViewEventsNavigatorItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
//End Record ShortViewEventsNavigator Data Provider Class GetResultSet Method

//Record ShortViewEventsNavigator BeforeBuildSelect @85-921CE95D
        if(!IsInsertMode){
//End Record ShortViewEventsNavigator BeforeBuildSelect

//Record ShortViewEventsNavigator AfterExecuteSelect @85-54D78817
        }
            IsInsertMode=true;
//End Record ShortViewEventsNavigator AfterExecuteSelect

//Record ShortViewEventsNavigator AfterExecuteSelect tail @85-FCB6E20C
    }
//End Record ShortViewEventsNavigator AfterExecuteSelect tail

//Record ShortViewEventsNavigator Data Provider Class @85-FCB6E20C
}

//End Record ShortViewEventsNavigator Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

