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

namespace calendar.infopanel{ //Namespace @1-E3DA569F

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

//Calendar InfoCalendar Item Class @108-11791F2E
public class InfoCalendarItem:ICalendarDataItem
{
    public DateField MonthDate;
    public DateField DayOfWeek;
    public DateField DayNumber;
    public object DayNumberHref;
    public LinkParameterCollection DayNumberHrefParameters;
    public TextField div_begin;
    public TextField category_image;
    public DateField EventTime;
    public DateField EventTimeEnd;
    public TextField EventDescription;
    public TextField div_end;
    public TextField GoWeek;
    public object GoWeekHref;
    public LinkParameterCollection GoWeekHrefParameters;
    public TextField PrevMonth;
    public object PrevMonthHref;
    public LinkParameterCollection PrevMonthHrefParameters;
    public TextField NextMonth;
    public object NextMonthHref;
    public LinkParameterCollection NextMonthHrefParameters;
    public TextField StyleControl;
    public NameValueCollection errors=new NameValueCollection();
    public InfoCalendarItem()
    {
        MonthDate=new DateField("MMMM, yyyy", null);
        DayOfWeek=new DateField("wi", null);
        DayNumber = new DateField("%d",null);
        DayNumberHrefParameters = new LinkParameterCollection();
        div_begin=new TextField("", null);
        category_image=new TextField("", null);
        EventTime=new DateField("t", null);
        EventTimeEnd=new DateField("t", null);
        EventDescription=new TextField("", null);
        div_end=new TextField("", null);
        GoWeek = new TextField("",null);
        GoWeekHrefParameters = new LinkParameterCollection();
        PrevMonth = new TextField("",null);
        PrevMonthHrefParameters = new LinkParameterCollection();
        NextMonth = new TextField("",null);
        NextMonthHrefParameters = new LinkParameterCollection();
        StyleControl=new TextField("", null);
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
                case "div_begin":
                    return this.div_begin;
                case "category_image":
                    return this.category_image;
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
                case "PrevMonth":
                    return this.PrevMonth;
                case "NextMonth":
                    return this.NextMonth;
                case "StyleControl":
                    return this.StyleControl;
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
                case "div_begin":
                    this.div_begin = (TextField)value;
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
                case "div_end":
                    this.div_end = (TextField)value;
                    break;
                case "GoWeek":
                    this.GoWeek = (TextField)value;
                    break;
                case "PrevMonth":
                    this.PrevMonth = (TextField)value;
                    break;
                case "NextMonth":
                    this.NextMonth = (TextField)value;
                    break;
                case "StyleControl":
                    this.StyleControl = (TextField)value;
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
//End Calendar InfoCalendar Item Class

//Calendar InfoCalendar Data Provider Class Header @108-16507216
public class InfoCalendarDataProvider:GridDataProviderBase
{
//End Calendar InfoCalendar Data Provider Class Header

//Calendar InfoCalendar Data Provider Class Variables @108-06C223CE
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public IntegerParameter Sescategory;
//End Calendar InfoCalendar Data Provider Class Variables

//Calendar InfoCalendar Data Provider Class Constructor @108-21F795A8
    public InfoCalendarDataProvider()
    {
         Select=new TableCommand("SELECT category_image, event_date, event_time, event_time_end, event_title, \n" +
          "event_is_public \n" +
          "FROM events LEFT JOIN categories ON\n" +
          "events.category_id = categories.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"category165"},Settings.calendarDataAccessObject);
    }
//End Calendar InfoCalendar Data Provider Class Constructor

//Calendar InfoCalendar Data Provider Class GetResultSet Method @108-6EB91FEF
    public InfoCalendarItem[] GetResultSet(FormSupportedOperations ops)
    {
//End Calendar InfoCalendar Data Provider Class GetResultSet Method

//Calendar InfoCalendar Event BeforeBuildSelect. Action Custom Code @115-2A29BDB7
    // -------------------------
		string[] Paths = System.Web.HttpContext.Current.Request.Path.Split('/');
		string FileName = Paths[Paths.Length-1].ToLower();
		DateTime FirstDate = CommonFunctions.CCParseDate(DateTime.Now.ToString("yyyy-MM")+"-01", "yyyy-MM-dd");
		if ((string)CommonFunctions.calendar_config["info_calendar"] == "Selected")
			switch (FileName) {
				case "index.aspx":
					if ((string)CommonFunctions.calendar_config["info_in_views"] == "2") {
						LinkParameterCollection p = new LinkParameterCollection();
						string QueryString = p.ToString("GET", "");
						int InfPos = QueryString.IndexOf("InfoCalendar=");
						if (CommonFunctions.CCGetFromGet("cal_monthDate", "").Length > 0 && (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length == 0 || QueryString.IndexOf("cal_monthDate") > InfPos))
							FirstDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("cal_monthDate", "")+"-01", "yyyy-MM-dd");
						else
							if (CommonFunctions.CCGetFromGet("cal_monthMonth", "").Length > 0 && CommonFunctions.CCGetFromGet("cal_monthYear", "").Length > 0 && (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length == 0 || QueryString.IndexOf("cal_monthYear") > InfPos || QueryString.IndexOf("cal_monthMonth") > InfPos))
								FirstDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("cal_monthYear", "") + "-" + CommonFunctions.CCGetFromGet("cal_monthMonth", "") + "-01", "yyyy-MM-dd");
							else {
								if (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length > 0)
									FirstDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("InfoCalendar", "") + "-01", "yyyy-MM-dd");
							}
					} 
					break;
				case "day.aspx":
				case "week.aspx":
		            if (CommonFunctions.CCGetFromGet("day", "").Length > 0 && CommonFunctions.CCGetFromGet("InfoCalendar", "").Length == 0)
						FirstDate = CommonFunctions.CCParseDate(CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("day", ""), "yyyy-MM-dd").ToString("yyyy-MM")+"-01", "yyyy-MM-dd");
					else
						if (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length > 0)
							FirstDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("InfoCalendar", "")+"-01", "yyyy-MM-dd");
					break;
			}
		DateTime LastDate = FirstDate.AddMonths(1);

		int FirstWeekDay = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
		int Days = (-(int)FirstDate.DayOfWeek + FirstWeekDay - 6) % 7;
	    FirstDate = FirstDate.AddDays(Days-1);
		Days = (FirstWeekDay - (int)LastDate.DayOfWeek + 6) % 7;
		LastDate = LastDate.AddDays(Days);

		((TableCommand)Select).Operation = "And";
		DataAccessObject DBcalendar = Settings.calendarDataAccessObject;
		string filter = CommonFunctions.AddReadFilter("");
		((TableCommand)Select).Where = "event_date >=" + DBcalendar.ToSql(FirstDate.ToString("yyyy-MM-dd"), FieldType.Date) +
				" AND event_date <=" + DBcalendar.ToSql(LastDate.ToString("yyyy-MM-dd"), FieldType.Date) + 
				( filter.Length>0 ? " AND " + filter : "");
    // -------------------------
//End Calendar InfoCalendar Event BeforeBuildSelect. Action Custom Code

//Before build Select @108-772C4679
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("category165",Sescategory, "","events.category_id",Condition.Equal,false);
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @108-2B265A55
        DataSet ds=null;
        InfoCalendarItem[] result = new InfoCalendarItem[0];
        if (ops.AllowRead) {
            try{
                ds=ExecuteSelect();
            }catch(Exception e){
                E=e;}
            finally{
//End Execute Select

//After execute Select @108-35357AF7
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new InfoCalendarItem[dr.Count];
//End After execute Select

//After execute Select tail @108-95E46361
            for(int i=0;i<dr.Count;i++)
            {
                InfoCalendarItem item=new InfoCalendarItem();
                item.DayNumberHref = "day.aspx";
                item.category_image.SetValue(dr[i]["category_image"],"");
                item.EventTime.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                item.EventTimeEnd.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
                item.EventDescription.SetValue(dr[i]["event_title"],"");
                item.GoWeekHref = "week.aspx";
                item.PrevMonthHref = "";
                item.NextMonthHref = "";
                item.EventDateCalendarField.SetValue(dr[i]["event_date"],"yyyy-MM-dd");
                item.EventTimeCalendarField.SetValue(dr[i]["event_time"],Select.DateFormat);
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        return result; 
    }
//End After execute Select tail

//Calendar Data Provider tail @108-FCB6E20C
}
//End Calendar Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

