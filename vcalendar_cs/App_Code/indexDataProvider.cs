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

namespace calendar.index{ //Namespace @1-FD158137

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

//Calendar cal_month Item Class @5-77538276
public class cal_monthItem:ICalendarDataItem
{
    public DateField MonthDate;
    public DateField DayOfWeek;
    public DateField DayNumber;
    public object DayNumberHref;
    public LinkParameterCollection DayNumberHrefParameters;
    public TextField add_event;
    public object add_eventHref;
    public LinkParameterCollection add_eventHrefParameters;
    public TextField category_image;
    public DateField EventTime;
    public DateField EventTimeEnd;
    public TextField EventDescription;
    public object EventDescriptionHref;
    public LinkParameterCollection EventDescriptionHrefParameters;
    public TextField go_week;
    public object go_weekHref;
    public LinkParameterCollection go_weekHrefParameters;
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
    public cal_monthItem()
    {
        MonthDate=new DateField("MMMM yyyy", null);
        DayOfWeek=new DateField("dddd", null);
        DayNumber = new DateField("%d",null);
        DayNumberHrefParameters = new LinkParameterCollection();
        add_event = new TextField("",null);
        add_eventHrefParameters = new LinkParameterCollection();
        category_image=new TextField("", null);
        EventTime=new DateField("t", null);
        EventTimeEnd=new DateField("t", null);
        EventDescription = new TextField("",null);
        EventDescriptionHrefParameters = new LinkParameterCollection();
        go_week = new TextField("",null);
        go_weekHrefParameters = new LinkParameterCollection();
        YearIcon = new TextField("",null);
        YearIconHrefParameters = new LinkParameterCollection();
        MonthIcon = new TextField("",null);
        MonthIconHrefParameters = new LinkParameterCollection();
        WeekIcon = new TextField("",null);
        WeekIconHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "MonthDate":
                    return this.MonthDate;
                case "DayOfWeek":
                    return this.DayOfWeek;
                case "DayNumber":
                    return this.DayNumber;
                case "add_event":
                    return this.add_event;
                case "category_image":
                    return this.category_image;
                case "EventTime":
                    return this.EventTime;
                case "EventTimeEnd":
                    return this.EventTimeEnd;
                case "EventDescription":
                    return this.EventDescription;
                case "go_week":
                    return this.go_week;
                case "YearIcon":
                    return this.YearIcon;
                case "MonthIcon":
                    return this.MonthIcon;
                case "WeekIcon":
                    return this.WeekIcon;
                case "EventDateCalendarField":
                    return this.EventDateCalendarField;
                case "EventTimeCalendarField":
                    return this.EventTimeCalendarField;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "MonthDate":
                    this.MonthDate = (DateField)value;
                    break;
                case "DayOfWeek":
                    this.DayOfWeek = (DateField)value;
                    break;
                case "DayNumber":
                    this.DayNumber = (DateField)value;
                    break;
                case "add_event":
                    this.add_event = (TextField)value;
                    break;
                case "category_image":
                    this.category_image = (TextField)value;
                    break;
                case "EventTime":
                    this.EventTime = (DateField)value;
                    break;
                case "EventTimeEnd":
                    this.EventTimeEnd = (DateField)value;
                    break;
                case "EventDescription":
                    this.EventDescription = (TextField)value;
                    break;
                case "go_week":
                    this.go_week = (TextField)value;
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
                case "EventDateCalendarField":
                    this.EventDateCalendarField = (DateField)value;
                    break;
                case "EventTimeCalendarField":
                    this.EventTimeCalendarField = (DateField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    protected DateField m_eventDateCalendarField = new DateField("", null);
    protected DateField m_eventTimeCalendarField = new DateField("", null);
    protected bool m_IsEventTimeExists = true;
    public bool IsEventTimeExists{
        get{
            return this.m_IsEventTimeExists;
        }
        set{
            this.m_IsEventTimeExists = value;
        }
    }
    public DateField EventDateCalendarField{
        get{
            return this.m_eventDateCalendarField;
        }
        set{
            this.m_eventDateCalendarField = (DateField)value;
        }
    }
    public DateField EventTimeCalendarField{
        get{
            return this.m_eventTimeCalendarField;
        }
        set{
            this.m_eventTimeCalendarField = (DateField)value;
        }
    }
}
//End Calendar cal_month Item Class

//Calendar cal_month Data Provider Class Header @5-7F827E3B
public class cal_monthDataProvider:GridDataProviderBase
{
//End Calendar cal_month Data Provider Class Header

//Calendar cal_month Data Provider Class Variables @5-6A4BE973
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{"event_time, event_time_end"};
    private string[] SortFieldsNamesDesc=new string[]{"event_time, event_time_end"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public IntegerParameter Sescategory;
//End Calendar cal_month Data Provider Class Variables

//Calendar cal_month Data Provider Class Constructor @5-CD84F22C
    public cal_monthDataProvider()
    {
         Select=new TableCommand("SELECT category_image, event_id, event_title, event_date, event_time, \n" +
          "event_time_end, \n" +
          "event_is_public \n" +
          "FROM events LEFT JOIN categories ON\n" +
          "events.category_id = categories.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"category46"},Settings.calendarDataAccessObject);
    }
//End Calendar cal_month Data Provider Class Constructor

//Calendar cal_month Data Provider Class GetResultSet Method @5-EBC277EB
    public cal_monthItem[] GetResultSet(FormSupportedOperations ops)
    {
//End Calendar cal_month Data Provider Class GetResultSet Method

//Calendar cal_month Event BeforeBuildSelect. Action Custom Code @26-2A29BDB7
    // -------------------------
		string CurrentDateStr = System.Web.HttpContext.Current.Session["CurrentDate"].ToString();

		DateTime FirstDate = CommonFunctions.CCParseDate(CurrentDateStr + "-01", "yyyy-MM-dd");
		DateTime LastDate = FirstDate.AddMonths(1).AddDays(-1);

		((TableCommand)Select).Operation = "And";
		DataAccessObject DBcalendar = Settings.calendarDataAccessObject;
		string filter = CommonFunctions.AddReadFilter("");
		((TableCommand)Select).Where = "event_date >=" + DBcalendar.ToSql(FirstDate.ToString("yyyy-MM-dd"), FieldType.Date) +
				" AND event_date <=" + DBcalendar.ToSql(LastDate.ToString("yyyy-MM-dd"), FieldType.Date) + 
				( filter.Length>0 ? " AND " + filter : "");
    // -------------------------
//End Calendar cal_month Event BeforeBuildSelect. Action Custom Code

//Before build Select @5-3052F50C
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("category46",Sescategory, "","events.category_id",Condition.Equal,false);
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @5-7455F26B
        DataSet ds=null;
        cal_monthItem[] result = new cal_monthItem[0];
        if (ops.AllowRead) {
            try{
                ds=ExecuteSelect();
            }catch(Exception e){
                E=e;}
            finally{
//End Execute Select

//After execute Select @5-C551FEE3
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new cal_monthItem[dr.Count];
//End After execute Select

//After execute Select tail @5-33FC71A8
            for(int i=0;i<dr.Count;i++)
            {
                cal_monthItem item=new cal_monthItem();
                item.DayNumberHref = "day.aspx";
                item.add_eventHref = "events.aspx";
                item.category_image.SetValue(dr[i]["category_image"],"");
                item.EventTime.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                item.EventTimeEnd.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
                item.EventDescription.SetValue(dr[i]["event_title"],"");
                item.EventDescriptionHref = "event_view.aspx";
                item.EventDescriptionHrefParameters.Add("event_id",System.Web.HttpUtility.UrlEncode(dr[i]["event_id"].ToString()));
                item.go_weekHref = "week.aspx";
                item.YearIconHref = "year.aspx";
                item.MonthIconHref = "index.aspx";
                item.WeekIconHref = "week.aspx";
                item.EventDateCalendarField.SetValue(dr[i]["event_date"],"yyyy-MM-dd");
                item.EventTimeCalendarField.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        return result; 
    }
//End After execute Select tail

//Calendar Data Provider tail @5-FCB6E20C
}
//End Calendar Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2
