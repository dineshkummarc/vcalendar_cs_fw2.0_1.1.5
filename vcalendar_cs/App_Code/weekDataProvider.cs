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

namespace calendar.week{ //Namespace @1-768B85A6

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

//Grid ShortViewEventsGrid Item Class @144-79197B86
public class ShortViewEventsGridItem:IDataItem
{
    public DateField week_date_begin;
    public DateField week_date_end;
    public TextField NoEventsDay;
    public DateField event_date;
    public object event_dateHref;
    public LinkParameterCollection event_dateHrefParameters;
    public TextField add_event;
    public object add_eventHref;
    public LinkParameterCollection add_eventHrefParameters;
    public DateField event_time;
    public DateField event_time_end;
    public TextField event_title;
    public object event_titleHref;
    public LinkParameterCollection event_titleHrefParameters;
    public TextField category_image;
    public TextField category_name;
    public TextField NoEventsLastDay;
    public NameValueCollection errors=new NameValueCollection();
    public ShortViewEventsGridItem()
    {
        week_date_begin=new DateField("MMMM d, yyyy", null);
        week_date_end=new DateField("MMMM d, yyyy", null);
        NoEventsDay=new TextField("", null);
        event_date = new DateField("d",null);
        event_dateHrefParameters = new LinkParameterCollection();
        add_event = new TextField("",null);
        add_eventHrefParameters = new LinkParameterCollection();
        event_time=new DateField("t", null);
        event_time_end=new DateField("t", null);
        event_title = new TextField("",null);
        event_titleHrefParameters = new LinkParameterCollection();
        category_image=new TextField("", null);
        category_name=new TextField("", null);
        NoEventsLastDay=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "week_date_begin":
                    return this.week_date_begin;
                case "week_date_end":
                    return this.week_date_end;
                case "NoEventsDay":
                    return this.NoEventsDay;
                case "event_date":
                    return this.event_date;
                case "add_event":
                    return this.add_event;
                case "event_time":
                    return this.event_time;
                case "event_time_end":
                    return this.event_time_end;
                case "event_title":
                    return this.event_title;
                case "category_image":
                    return this.category_image;
                case "category_name":
                    return this.category_name;
                case "NoEventsLastDay":
                    return this.NoEventsLastDay;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "week_date_begin":
                    this.week_date_begin = (DateField)value;
                    break;
                case "week_date_end":
                    this.week_date_end = (DateField)value;
                    break;
                case "NoEventsDay":
                    this.NoEventsDay = (TextField)value;
                    break;
                case "event_date":
                    this.event_date = (DateField)value;
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
                case "event_title":
                    this.event_title = (TextField)value;
                    break;
                case "category_image":
                    this.category_image = (TextField)value;
                    break;
                case "category_name":
                    this.category_name = (TextField)value;
                    break;
                case "NoEventsLastDay":
                    this.NoEventsLastDay = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid ShortViewEventsGrid Item Class

//Grid ShortViewEventsGrid Data Provider Class Header @144-9343EDBB
public class ShortViewEventsGridDataProvider:GridDataProviderBase
{
//End Grid ShortViewEventsGrid Data Provider Class Header

//Grid ShortViewEventsGrid Data Provider Class Variables @144-82F71237
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{"event_date, event_time, event_time_end"};
    private string[] SortFieldsNamesDesc=new string[]{"event_date, event_time, event_time_end"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=0;
    public int PageNumber=1;
    public TextParameter Seslocale;
    public IntegerParameter Urlevents_category_id;
    public IntegerParameter Sescategory;
//End Grid ShortViewEventsGrid Data Provider Class Variables

//Grid ShortViewEventsGrid Data Provider Class Constructor @144-6465B7E9
    public ShortViewEventsGridDataProvider()
    {
         Select=new TableCommand("SELECT categories_langs.category_name AS category_name, event_id, event_title, \n" +
          "event_date, event_time, event_time_end, \n" +
          "category_image,\n" +
          "event_is_public \n" +
          "FROM (events LEFT JOIN categories_langs ON\n" +
          "events.category_id = categories_langs.category_id) LEFT JOIN categories ON\n" +
          "events.category_id = categories.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"(","locale153","Or","events_category_id154",")","And","category180"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM (events LEFT JOIN categories_langs ON\n" +
          "events.category_id = categories_langs.category_id) LEFT JOIN categories ON\n" +
          "events.category_id = categories.category_id", new string[]{"(","locale153","Or","events_category_id154",")","And","category180"},Settings.calendarDataAccessObject);
    }
//End Grid ShortViewEventsGrid Data Provider Class Constructor

//Grid ShortViewEventsGrid Data Provider Class GetResultSet Method @144-A601A2BE
    public ShortViewEventsGridItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid ShortViewEventsGrid Data Provider Class GetResultSet Method

//Grid ShortViewEventsGrid Event BeforeBuildSelect. Action Custom Code @179-2A29BDB7
    // -------------------------
		DateTime SelDay = System.Web.HttpContext.Current.Request.QueryString["day"]!=null?DBUtility.ParseDate(System.Web.HttpContext.Current.Request.QueryString["day"],""):DateTime.Now;

  		int FirstWeekDay = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

		DateTime FirstDay = SelDay.AddDays((FirstWeekDay-7-(int)SelDay.DayOfWeek) % 7);
		DateTime LastDay = FirstDay.AddDays(6);

		((TableCommand)Select).Operation = "And";
					
		DataAccessObject DBcalendar = Settings.calendarDataAccessObject;
		string filter = CommonFunctions.AddReadFilter("");
		((TableCommand)Select).Where = "(event_date >=" + DBcalendar.ToSql(FirstDay.ToString("yyyy-MM-dd"), FieldType.Date) +
					" AND event_date <=" + DBcalendar.ToSql(LastDay.ToString("yyyy-MM-dd"), FieldType.Date) + ") " + 
					( filter.Length>0 ? " AND " + filter : "");
    // -------------------------
//End Grid ShortViewEventsGrid Event BeforeBuildSelect. Action Custom Code

//Before build Select @144-1C3DC6DA
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale153",Seslocale, "","categories_langs.language_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("events_category_id154",Urlevents_category_id, "","events.category_id",Condition.IsNull,true);
        ((TableCommand)Select).AddParameter("category180",Sescategory, "","events.category_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @144-1BA3E73D
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

//After execute Select @144-7D8CD050
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new ShortViewEventsGridItem[dr.Count];
//End After execute Select

//After execute Select tail @144-590AF7E4
            for(int i=0;i<dr.Count;i++)
            {
                ShortViewEventsGridItem item=new ShortViewEventsGridItem();
                item.event_date.SetValue(dr[i]["event_date"],Select.DateFormat);
                item.event_dateHref = "day.aspx";
                item.event_dateHrefParameters.Add("day",System.Web.HttpUtility.UrlEncode(dr[i]["event_date"].ToString()));
                item.add_eventHref = "events.aspx";
                item.event_time.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                item.event_time_end.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
                item.event_title.SetValue(dr[i]["event_title"],"");
                item.event_titleHref = "event_view.aspx";
                item.event_titleHrefParameters.Add("event_id",System.Web.HttpUtility.UrlEncode(dr[i]["event_id"].ToString()));
                item.category_image.SetValue(dr[i]["category_image"],"");
                item.category_name.SetValue(dr[i]["category_name"],"");
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @144-FCB6E20C
}
//End Grid Data Provider tail

//Record ShortViewEventsNavigator Item Class @102-987050EE
public class ShortViewEventsNavigatorItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField prev_week_link;
    public object prev_week_linkHref;
    public LinkParameterCollection prev_week_linkHrefParameters;
    public TextField week;
    public ItemCollection weekItems;
    public TextField next_week_link;
    public object next_week_linkHref;
    public LinkParameterCollection next_week_linkHrefParameters;
    public TextField month;
    public ItemCollection monthItems;
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
        prev_week_link = new TextField("",null);
        prev_week_linkHrefParameters = new LinkParameterCollection();
        week = new TextField("", null);
        weekItems = new ItemCollection();
        next_week_link = new TextField("",null);
        next_week_linkHrefParameters = new LinkParameterCollection();
        month = new TextField("", null);
        monthItems = new ItemCollection();
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
        if(DBUtility.GetInitialValue("prev_week_link") != null){
        item.prev_week_link.SetValue(DBUtility.GetInitialValue("prev_week_link"));
        }
        if(DBUtility.GetInitialValue("week") != null){
        item.week.SetValue(DBUtility.GetInitialValue("week"));
        }
        if(DBUtility.GetInitialValue("next_week_link") != null){
        item.next_week_link.SetValue(DBUtility.GetInitialValue("next_week_link"));
        }
        if(DBUtility.GetInitialValue("month") != null){
        item.month.SetValue(DBUtility.GetInitialValue("month"));
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
                case "prev_week_link":
                    return this.prev_week_link;
                case "week":
                    return this.week;
                case "next_week_link":
                    return this.next_week_link;
                case "month":
                    return this.month;
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
                case "prev_week_link":
                    this.prev_week_link = (TextField)value;
                    break;
                case "week":
                    this.week = (TextField)value;
                    break;
                case "next_week_link":
                    this.next_week_link = (TextField)value;
                    break;
                case "month":
                    this.month = (TextField)value;
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

//Record ShortViewEventsNavigator Item Class tail @102-F5FC18C5
    }
}
//End Record ShortViewEventsNavigator Item Class tail

//Record ShortViewEventsNavigator Data Provider Class @102-B2E717B8
public class ShortViewEventsNavigatorDataProvider:RecordDataProviderBase
{
//End Record ShortViewEventsNavigator Data Provider Class

//Record ShortViewEventsNavigator Data Provider Class Variables @102-6A822029
    protected ShortViewEventsNavigatorItem item;
//End Record ShortViewEventsNavigator Data Provider Class Variables

//Record ShortViewEventsNavigator Data Provider Class Constructor @102-B541C646
    public ShortViewEventsNavigatorDataProvider()
    {
    }
//End Record ShortViewEventsNavigator Data Provider Class Constructor

//Record ShortViewEventsNavigator Data Provider Class LoadParams Method @102-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record ShortViewEventsNavigator Data Provider Class LoadParams Method

//Record ShortViewEventsNavigator Data Provider Class GetResultSet Method @102-903D9CE0
    public void FillItem(ShortViewEventsNavigatorItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
//End Record ShortViewEventsNavigator Data Provider Class GetResultSet Method

//Record ShortViewEventsNavigator BeforeBuildSelect @102-921CE95D
        if(!IsInsertMode){
//End Record ShortViewEventsNavigator BeforeBuildSelect

//Record ShortViewEventsNavigator AfterExecuteSelect @102-54D78817
        }
            IsInsertMode=true;
//End Record ShortViewEventsNavigator AfterExecuteSelect

//Record ShortViewEventsNavigator AfterExecuteSelect tail @102-FCB6E20C
    }
//End Record ShortViewEventsNavigator AfterExecuteSelect tail

//Record ShortViewEventsNavigator Data Provider Class @102-FCB6E20C
}

//End Record ShortViewEventsNavigator Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

