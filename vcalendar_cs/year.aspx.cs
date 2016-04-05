//Using Statements @1-9FD2A1C9
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using calendar;
using calendar.Data;
using calendar.Configuration;
using calendar.Security;
using calendar.Controls;

//End Using Statements

namespace calendar.year{ //Namespace @1-55B23A03

//Forms Definition @1-9A73BB50
public partial class yearPage : System.Web.UI.Page
{
//End Forms Definition

	protected int CurrentDayEventsCount = 0, divID = 0;

//Forms Objects @1-D3C285AE
    protected year_eventsDataProvider year_eventsData;
    protected FormSupportedOperations year_eventsOperations;
    protected System.Resources.ResourceManager rm;
    protected string yearContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-A924B486
    if(Request.Form["year_eventsNavigatorSubmit"]!=null || Request.Form["year_eventsNavigatorSubmit.x"]!=null)
    {
        LinkParameterCollection p = new LinkParameterCollection();
        if(Request.Form["year_eventsYear"]!=null) p.Add("year_eventsYear", Request.Form["year_eventsYear"]);
        if(Request.Form["year_eventsMonth"]!=null) p.Add("year_eventsMonth", Request.Form["year_eventsMonth"]);
        Response.Redirect(Request.Path + p.ToString("GET", "year_eventsMonth;year_eventsYear;year_eventsDate", ViewState));
    }
    year_eventsBind();
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
    }
//End Page_Load Event BeforeIsPostBack

//Page_Load Event tail @1-FCB6E20C
}
//End Page_Load Event tail

//Page_Unload Event @1-72102C7C
private void Page_Unload(object sender, System.EventArgs e)
{
//End Page_Unload Event

//Page_Unload Event tail @1-FCB6E20C
}
//End Page_Unload Event tail

//Calendar year_events Bind @5-93A83095
    protected void year_eventsBind()
    {
        if (!year_eventsOperations.AllowRead) return;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"year_events",typeof(year_eventsDataProvider.SortFields), 0, -1);
        }
//End Calendar year_events Bind

//Calendar year_events Event BeforeSelect. Action Custom Code @176-2A29BDB7
    // -------------------------
		System.Web.HttpContext.Current.Session["CurrentDate"] = Convert.ToString(year_events.Year);
    // -------------------------
//End Calendar year_events Event BeforeSelect. Action Custom Code

//Calendar Form year_events BeforeShow tail @5-0A4B1C1E
        year_eventsParameters();
        year_events.DataSource = year_eventsData.GetResultSet(year_eventsOperations);
        year_events.DataBind();
//End Calendar Form year_events BeforeShow tail

//Calendar year_events Event BeforeShow. Action Custom Code @51-2A29BDB7
    // -------------------------
    System.Web.UI.WebControls.Literal year_eventsCurYearLabel = (System.Web.UI.WebControls.Literal)(year_events.Controls[0].FindControl("year_eventsCurYearLabel"));
	year_eventsCurYearLabel.Text = year_events.Year.ToString();
    // -------------------------
//End Calendar year_events Event BeforeShow. Action Custom Code

//Calendar year_events Bind tail @5-FCB6E20C
    }
//End Calendar year_events Bind tail

//Calendar year_events Table Parameters @5-57B1C0EF
    protected void year_eventsParameters()
    {
        try{
            year_eventsData.Urlcategories = IntegerParameter.GetParam(Request.QueryString["categories"]);
        }catch{
            ControlCollection ParentControls=year_events.Parent.Controls;
            int Index = ParentControls.IndexOf(year_events);
            ParentControls.RemoveAt(Index);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Calendar year_events: Invalid parameter";
            ParentControls.AddAt(Index,ErrorMessage);
        }
	}
	
//End Calendar year_events Table Parameters

//Calendar year_events ItemDataBound event @5-B1B1E1DF
    protected void year_eventsItemDataBound(Object Sender, CCCalendarItemEventArgs e)
    {
        year_eventsItem DataItem = (year_eventsItem)e.Item.DataItem;
        if(DataItem == null) DataItem = new year_eventsItem();
        year_eventsItem item = DataItem;
        System.Web.UI.WebControls.Literal year_eventsCurYearLabel = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("year_eventsCurYearLabel"));
        System.Web.UI.HtmlControls.HtmlAnchor year_eventsMonthDate = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("year_eventsMonthDate"));
        System.Web.UI.WebControls.Literal year_eventsDayOfWeek = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("year_eventsDayOfWeek"));
        System.Web.UI.WebControls.PlaceHolder year_eventsGoWeekHeader = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("year_eventsGoWeekHeader"));
        System.Web.UI.HtmlControls.HtmlAnchor year_eventsDayNumber = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("year_eventsDayNumber"));
        System.Web.UI.WebControls.Literal year_eventsdiv_begin = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("year_eventsdiv_begin"));
        System.Web.UI.WebControls.Image year_eventsCategoryImage = (System.Web.UI.WebControls.Image)(e.Item.FindControl("year_eventsCategoryImage"));
        System.Web.UI.WebControls.Literal year_eventsEventTime = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("year_eventsEventTime"));
        System.Web.UI.WebControls.Literal year_eventsEventTimeEnd = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("year_eventsEventTimeEnd"));
        System.Web.UI.WebControls.Literal year_eventsEventDescription = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("year_eventsEventDescription"));
        System.Web.UI.WebControls.Literal year_eventsdiv_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("year_eventsdiv_end"));
        System.Web.UI.WebControls.PlaceHolder year_eventsGoWeekPanel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("year_eventsGoWeekPanel"));
        CalendarNavigator year_eventsNavigator = (CalendarNavigator)(e.Item.FindControl("year_eventsNavigator"));
        System.Web.UI.HtmlControls.HtmlAnchor year_eventsGoWeek = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("year_eventsGoWeek"));
        if (e.Item.ItemType == CCCalendarItemType.Header) {
            year_eventsCurYearLabel.Text=Server.HtmlEncode(item.CurYearLabel.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        }
        if (e.Item.ItemType == CCCalendarItemType.Footer) {
        }
        if (e.Item.ItemType == CCCalendarItemType.MonthHeader) {
            DataItem.MonthDateHref = "index.aspx";
            DataItem.MonthDateHrefParameters.Add("cal_monthDate",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("yyyy-MM")));
            year_eventsMonthDate.HRef = DataItem.MonthDateHref + DataItem.MonthDateHrefParameters.ToString("GET","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekFooter) {
            year_eventsGoWeek.InnerHtml += item.GoWeek.GetFormattedValue();
            year_eventsGoWeek.HRef = item.GoWeekHref+item.GoWeekHrefParameters.ToString("None","", ViewState);
            DataItem.GoWeekHref = "week.aspx";
            DataItem.GoWeekHrefParameters.Add("day",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("yyyy-MM-dd")));
            year_eventsGoWeek.HRef = DataItem.GoWeekHref + DataItem.GoWeekHrefParameters.ToString("None","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekDays) {
        }
        if (e.Item.ItemType == CCCalendarItemType.DayHeader) {
            year_eventsdiv_begin.Text=item.div_begin.GetFormattedValue();
            DataItem.DayNumberHref = "day.aspx";
            DataItem.DayNumberHrefParameters.Add("day",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("yyyy-MM-dd")));
            year_eventsDayNumber.HRef = DataItem.DayNumberHref + DataItem.DayNumberHrefParameters.ToString("None","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.DayFooter) {
            year_eventsdiv_end.Text=item.div_end.GetFormattedValue();
        }
        if (e.Item.ItemType == CCCalendarItemType.EventRow) {
            year_eventsCategoryImage.ImageUrl += DataItem.CategoryImage.GetFormattedValue();
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekDaysFooter) {
        }
//End Calendar year_events ItemDataBound event

//year_events control Before Show @5-60E1554A
        if (e.Item.ItemType == CCCalendarItemType.WeekFooter) {
//End year_events control Before Show

//Link GoWeek Event BeforeShow. Action Custom Code @57-2A29BDB7
    // -------------------------
	if (CommonFunctions.str_calendar_config("year_week_icon") == "1") {
		year_eventsGoWeekPanel.Visible = true;
	} else {
		year_eventsGoWeekPanel.Visible = false;
	}
    // -------------------------
//End Link GoWeek Event BeforeShow. Action Custom Code

//year_events control Before Show tail @5-FCB6E20C
        }
//End year_events control Before Show tail

//year_events control Before Show @5-C32A7B8A
        if (e.Item.ItemType == CCCalendarItemType.DayHeader) {
//End year_events control Before Show

//Calendar year_events Event BeforeShowDay. Action Custom Code @26-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Calendar year_events Event BeforeShowDay. Action Custom Code

//year_events control Before Show tail @5-FCB6E20C
        }
//End year_events control Before Show tail

        if (e.Item.ItemType == CCCalendarItemType.EventRow) CurrentDayEventsCount++;
        if (e.Item.ItemType == CCCalendarItemType.DayFooter) {
			int idx = ((WebControl)Sender).Controls.IndexOf(e.Item) - 1;
			System.Web.UI.WebControls.Literal year_eventsdiv_begin2 = null;
			while (idx>0 && (year_eventsdiv_begin2 = (System.Web.UI.WebControls.Literal)(((WebControl)Sender).Controls[idx].FindControl("year_eventsdiv_begin")))==null) idx--;
 		    System.Web.UI.HtmlControls.HtmlAnchor year_eventsDayNumber2 = (System.Web.UI.HtmlControls.HtmlAnchor)(((WebControl)Sender).Controls[idx].FindControl("year_eventsDayNumber"));

			if (CurrentDayEventsCount > 0) 
			{
				divID++;
				year_eventsdiv_begin2.Text = "<div style=\"position: absolute; visibility: hidden; padding: 6px; border: 1px solid black; text-align: left; background: #ffffff\" name=\"float\" id=\"div" + divID.ToString() + "\">";
				year_eventsdiv_end.Text   = "</div>";
				year_eventsDayNumber2.Attributes["style"] = CommonFunctions.str_calendar_config("event_day_style");
				year_eventsDayNumber2.Attributes["onmouseover"] = "javascript:show('" + divID.ToString() + "')";
				year_eventsDayNumber2.Attributes["onmouseout"] = "javascript:hide('" + divID.ToString() + "')";
				//PageVariables.Add("@event", "style=\"font-weight: bold\" onmouseover=\"javascript:show('" + divID.ToString() + "')\" onmouseout=\"javascript:hide('" + divID.ToString() + "')\"");
				CurrentDayEventsCount = 0;
			}  else {
				year_eventsDayNumber2.Attributes.Remove("style");
				year_eventsDayNumber2.Attributes.Remove("onmouseover");
				year_eventsDayNumber2.Attributes.Remove("onmouseout");
				year_eventsdiv_begin2.Text = "";
				year_eventsdiv_end.Text   = "";
				//PageVariables.Add("@event", "");
			}
		}

//year_events control Before Show @5-D3186B72
        if (e.Item.ItemType == CCCalendarItemType.EmptyDay) {
//End year_events control Before Show

//Calendar year_events Event BeforeShowDay. Action Custom Code @26-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Calendar year_events Event BeforeShowDay. Action Custom Code

//year_events control Before Show tail @5-FCB6E20C
        }
//End year_events control Before Show tail

//year_events control Before Show @5-B30760D4
        if (e.Item.ItemType == CCCalendarItemType.EventRow) {
//End year_events control Before Show

//Image CategoryImage Event BeforeShow. Action Custom Code @36-2A29BDB7
    // -------------------------
	if (item.CategoryImage.GetFormattedValue().Length == 0) {
		year_eventsCategoryImage.Visible = false;
	} else {
		year_eventsCategoryImage.Visible = true;
	}
    // -------------------------
//End Image CategoryImage Event BeforeShow. Action Custom Code

//Label EventTime Event BeforeShow. Action Custom Code @25-2A29BDB7
    // -------------------------
	if (year_eventsEventTime.Text.Length == 0) {
		year_eventsEventTime.Visible = false;
	} else {
		year_eventsEventTime.Text = year_eventsEventTime.Text + " - ";
		year_eventsEventTime.Visible = true;
	}
    // -------------------------
//End Label EventTime Event BeforeShow. Action Custom Code

//year_events control Before Show tail @5-FCB6E20C
        }
//End year_events control Before Show tail

//year_events control Before Show @5-B76C6B5F
        if (e.Item.ItemType == CCCalendarItemType.WeekDaysFooter) {
//End year_events control Before Show

//Panel GoWeekHeader Event BeforeShow. Action Custom Code @58-2A29BDB7
    // -------------------------
	/*
	if (CommonFunctions.str_calendar_config("year_week_icon") == "1") {
		year_eventsGoWeekHeader.Visible = true;
	} else {
		year_eventsGoWeekHeader.Visible = false;
	}
	*/
    // -------------------------
//End Panel GoWeekHeader Event BeforeShow. Action Custom Code

//year_events control Before Show tail @5-FCB6E20C
        }
//End year_events control Before Show tail

//Calendar year_events ItemDataBound event tail @5-FCB6E20C
    }
//End Calendar year_events ItemDataBound event tail

//OnInit Event @1-D26DF991
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        yearContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        year_eventsData = new year_eventsDataProvider();
        year_eventsOperations = new FormSupportedOperations(false, true, false, false, false);
//End OnInit Event

//OnInit Event tail @1-CF19F5CD
        PageStyleName = Server.UrlEncode(PageStyleName);
    }
//End OnInit Event tail

//InitializeComponent Event @1-722FC1EE
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
    }
    #endregion
//End InitializeComponent Event

//Page class tail @1-F5FC18C5
}
}
//End Page class tail

