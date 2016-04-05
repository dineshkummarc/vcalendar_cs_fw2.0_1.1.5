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

namespace calendar.year{ //Namespace @1-55B23A03

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

//Calendar year_events Item Class @5-362DFE97
public class year_eventsItem:ICalendarDataItem
{
    public TextField CurYearLabel;
    public DateField MonthDate;
    public object MonthDateHref;
    public LinkParameterCollection MonthDateHrefParameters;
    public DateField DayOfWeek;
    public DateField DayNumber;
    public object DayNumberHref;
    public LinkParameterCollection DayNumberHrefParameters;
    public TextField div_begin;
    public TextField CategoryImage;
    public DateField EventTime;
    public DateField EventTimeEnd;
    public TextField EventDescription;
    public TextField div_end;
    public TextField GoWeek;
    public object GoWeekHref;
    public LinkParameterCollection GoWeekHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public year_eventsItem()
    {
        CurYearLabel=new TextField("", null);
        MonthDate = new DateField("MMMM",null);
        MonthDateHrefParameters = new LinkParameterCollection();
        DayOfWeek=new DateField("ddd", null);
        DayNumber = new DateField("%d",null);
        DayNumberHrefParameters = new LinkParameterCollection();
        div_begin=new TextField("", null);
        CategoryImage=new TextField("", null);
        EventTime=new DateField("t", null);
        EventTimeEnd=new DateField("t", null);
        EventDescription=new TextField("", null);
        div_end=new TextField("", null);
        GoWeek = new TextField("",null);
        GoWeekHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "CurYearLabel":
                    return this.CurYearLabel;
                case "MonthDate":
                    return this.MonthDate;
                case "DayOfWeek":
                    return this.DayOfWeek;
                case "DayNumber":
                    return this.DayNumber;
                case "div_begin":
                    return this.div_begin;
                case "CategoryImage":
                    return this.CategoryImage;
                case "EventTime":
                    return this.EventTime;
                case "EventTimeEnd":
                    return this.EventTimeEnd;
                case "EventDescription":
                    return this.EventDescription;
                case "div_end":
                    return this.div_end;
                case "GoWeek":
                    return this.GoWeek;
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
                case "CurYearLabel":
                    this.CurYearLabel = (TextField)value;
                    break;
                case "MonthDate":
                    this.MonthDate = (DateField)value;
                    break;
                case "DayOfWeek":
                    this.DayOfWeek = (DateField)value;
                    break;
                case "DayNumber":
                    this.DayNumber = (DateField)value;
                    break;
                case "div_begin":
                    this.div_begin = (TextField)value;
                    break;
                case "CategoryImage":
                    this.CategoryImage = (TextField)value;
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
                case "div_end":
                    this.div_end = (TextField)value;
                    break;
                case "GoWeek":
                    this.GoWeek = (TextField)value;
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
//End Calendar year_events Item Class

//Calendar year_events Data Provider Class Header @5-22DA2B4F
public class year_eventsDataProvider:GridDataProviderBase
{
//End Calendar year_events Data Provider Class Header

//Calendar year_events Data Provider Class Variables @5-7ADF9102
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public IntegerParameter Urlcategories;
//End Calendar year_events Data Provider Class Variables

//Calendar year_events Data Provider Class Constructor @5-D94B4871
    public year_eventsDataProvider()
    {
         Select=new TableCommand("SELECT category_image, event_time, event_time_end, event_is_public, event_date, \n" +
          "event_desc, event_title, \n" +
          "event_id \n" +
          "FROM events LEFT JOIN categories ON\n" +
          "events.category_id = categories.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"categories53"},Settings.calendarDataAccessObject);
    }
//End Calendar year_events Data Provider Class Constructor

//Calendar year_events Data Provider Class GetResultSet Method @5-F089DFD2
    public year_eventsItem[] GetResultSet(FormSupportedOperations ops)
    {
//End Calendar year_events Data Provider Class GetResultSet Method

//Calendar year_events Event BeforeBuildSelect. Action Custom Code @24-2A29BDB7
    // -------------------------
		string CurrentDateStr = CommonFunctions.CCGetFromGet("year_eventsDate", "");
		if (CurrentDateStr.Length > 0)
			CurrentDateStr = CommonFunctions.CCParseDate(CurrentDateStr + "-01", "yyyy-MM-dd").ToString("yyyy");
		else
			CurrentDateStr = CommonFunctions.CCGetFromGet("year_eventsYear", DateTime.Now.ToString("yyyy"));

		DateTime FirstDate = CommonFunctions.CCParseDate(CurrentDateStr + "-01-01", "yyyy-MM-dd");
		DateTime LastDate = FirstDate.AddYears(1).AddDays(-1);

		((TableCommand)Select).Operation = "And";
		DataAccessObject DBcalendar = Settings.calendarDataAccessObject;
		string filter = CommonFunctions.AddReadFilter("");
		((TableCommand)Select).Where = "event_date >=" + DBcalendar.ToSql(FirstDate.ToString("yyyy-MM-dd"), FieldType.Date) +
				" AND event_date <=" + DBcalendar.ToSql(LastDate.ToString("yyyy-MM-dd"), FieldType.Date) + 
				( filter.Length>0 ? " AND " + filter : "");
	// -------------------------
//End Calendar year_events Event BeforeBuildSelect. Action Custom Code

//Before build Select @5-7C6C0110
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("categories53",Urlcategories, "","events.category_id",Condition.Equal,false);
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @5-AF4695C3
        DataSet ds=null;
        year_eventsItem[] result = new year_eventsItem[0];
        if (ops.AllowRead) {
            try{
                ds=ExecuteSelect();
            }catch(Exception e){
                E=e;}
            finally{
//End Execute Select

//After execute Select @5-A43B0D2F
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new year_eventsItem[dr.Count];
//End After execute Select

//After execute Select tail @5-0099F036
            for(int i=0;i<dr.Count;i++)
            {
                year_eventsItem item=new year_eventsItem();
                item.MonthDateHref = "index.aspx";
                item.DayNumberHref = "day.aspx";
                item.CategoryImage.SetValue(dr[i]["category_image"],"");
                item.EventTime.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                item.EventTimeEnd.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
                item.EventDescription.SetValue(dr[i]["event_title"],"");
                item.GoWeekHref = "week.aspx";
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

