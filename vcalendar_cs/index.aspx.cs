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

namespace calendar.index{ //Namespace @1-FD158137

//Forms Definition @1-022C137C
public partial class indexPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-41EC0B48
    protected cal_monthDataProvider cal_monthData;
    protected FormSupportedOperations cal_monthOperations;
    protected System.Resources.ResourceManager rm;
    protected string indexContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-D1A6C22C
    if(Request.Form["cal_monthNavigatorSubmit"]!=null || Request.Form["cal_monthNavigatorSubmit.x"]!=null)
    {
        LinkParameterCollection p = new LinkParameterCollection();
        if(Request.Form["cal_monthYear"]!=null) p.Add("cal_monthYear", Request.Form["cal_monthYear"]);
        if(Request.Form["cal_monthMonth"]!=null) p.Add("cal_monthMonth", Request.Form["cal_monthMonth"]);
        Response.Redirect(Request.Path + p.ToString("GET", "cal_monthMonth;cal_monthYear;cal_monthDate", ViewState));
    }
    cal_monthBind();
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

//Calendar cal_month Bind @5-3616E167
    protected void cal_monthBind()
    {
        if (!cal_monthOperations.AllowRead) return;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"cal_month",typeof(cal_monthDataProvider.SortFields), 0, -1);
        }
//End Calendar cal_month Bind

//Calendar cal_month Event BeforeSelect. Action Custom Code @203-2A29BDB7
    // -------------------------
  		System.Web.HttpContext.Current.Session["CurrentDate"] = Convert.ToString(cal_month.Year) + "-" + ("0" + Convert.ToString(cal_month.Month)).Substring(Convert.ToString(cal_month.Month).Length-1,2);
    // -------------------------
//End Calendar cal_month Event BeforeSelect. Action Custom Code

//Calendar Form cal_month BeforeShow tail @5-3FA7E7ED
        cal_monthParameters();
        cal_month.DataSource = cal_monthData.GetResultSet(cal_monthOperations);
        cal_month.DataBind();
//End Calendar Form cal_month BeforeShow tail

//Calendar cal_month Bind tail @5-FCB6E20C
    }
//End Calendar cal_month Bind tail

//Calendar cal_month Table Parameters @5-ACD641D1
    protected void cal_monthParameters()
    {
        try{
            cal_monthData.Sescategory = IntegerParameter.GetParam(Session.Contents["category"]);
        }catch{
            ControlCollection ParentControls=cal_month.Parent.Controls;
            int Index = ParentControls.IndexOf(cal_month);
            ParentControls.RemoveAt(Index);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Calendar cal_month: Invalid parameter";
            ParentControls.AddAt(Index,ErrorMessage);
        }
	}
	
//End Calendar cal_month Table Parameters

//Calendar cal_month ItemDataBound event @5-1D7DB1E9
    protected void cal_monthItemDataBound(Object Sender, CCCalendarItemEventArgs e)
    {
        cal_monthItem DataItem = (cal_monthItem)e.Item.DataItem;
        if(DataItem == null) DataItem = new cal_monthItem();
        cal_monthItem item = DataItem;
        System.Web.UI.WebControls.Literal cal_monthMonthDate = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("cal_monthMonthDate"));
        System.Web.UI.WebControls.Literal cal_monthDayOfWeek = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("cal_monthDayOfWeek"));
        System.Web.UI.HtmlControls.HtmlAnchor cal_monthDayNumber = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("cal_monthDayNumber"));
        System.Web.UI.HtmlControls.HtmlAnchor cal_monthadd_event = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("cal_monthadd_event"));
        System.Web.UI.WebControls.Image cal_monthcategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("cal_monthcategory_image"));
        System.Web.UI.WebControls.Literal cal_monthEventTime = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("cal_monthEventTime"));
        System.Web.UI.WebControls.Literal cal_monthEventTimeEnd = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("cal_monthEventTimeEnd"));
        System.Web.UI.HtmlControls.HtmlAnchor cal_monthEventDescription = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("cal_monthEventDescription"));
        System.Web.UI.HtmlControls.HtmlAnchor cal_monthgo_week = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("cal_monthgo_week"));
        CalendarNavigator cal_monthNavigator = (CalendarNavigator)(e.Item.FindControl("cal_monthNavigator"));
        System.Web.UI.WebControls.PlaceHolder cal_monthCalendarTypes = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("cal_monthCalendarTypes"));
        System.Web.UI.HtmlControls.HtmlAnchor cal_monthYearIcon = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("cal_monthYearIcon"));
        System.Web.UI.HtmlControls.HtmlAnchor cal_monthMonthIcon = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("cal_monthMonthIcon"));
        System.Web.UI.HtmlControls.HtmlAnchor cal_monthWeekIcon = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("cal_monthWeekIcon"));
        if (e.Item.ItemType == CCCalendarItemType.Header) {
        }
        if (e.Item.ItemType == CCCalendarItemType.Footer) {
            cal_monthYearIcon.InnerHtml += item.YearIcon.GetFormattedValue();
            cal_monthYearIcon.HRef = item.YearIconHref+item.YearIconHrefParameters.ToString("None","", ViewState);
            cal_monthMonthIcon.InnerHtml += item.MonthIcon.GetFormattedValue();
            cal_monthMonthIcon.HRef = item.MonthIconHref+item.MonthIconHrefParameters.ToString("GET","", ViewState);
            cal_monthWeekIcon.InnerHtml += item.WeekIcon.GetFormattedValue();
            cal_monthWeekIcon.HRef = item.WeekIconHref+item.WeekIconHrefParameters.ToString("None","", ViewState);
            DataItem.YearIconHref = "year.aspx";
            cal_monthYearIcon.HRef = DataItem.YearIconHref + DataItem.YearIconHrefParameters.ToString("None","", ViewState);
            DataItem.MonthIconHref = "index.aspx";
            cal_monthMonthIcon.HRef = DataItem.MonthIconHref + DataItem.MonthIconHrefParameters.ToString("GET","", ViewState);
            DataItem.WeekIconHref = "week.aspx";
            cal_monthWeekIcon.HRef = DataItem.WeekIconHref + DataItem.WeekIconHrefParameters.ToString("None","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekFooter) {
            cal_monthgo_week.InnerHtml += item.go_week.GetFormattedValue();
            cal_monthgo_week.HRef = item.go_weekHref+item.go_weekHrefParameters.ToString("None","", ViewState);
            DataItem.go_weekHref = "week.aspx";
            DataItem.go_weekHrefParameters.Add("day",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("yyyy-MM-dd")));
            cal_monthgo_week.HRef = DataItem.go_weekHref + DataItem.go_weekHrefParameters.ToString("None","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekDays) {
        }
        if (e.Item.ItemType == CCCalendarItemType.DayHeader) {
            cal_monthadd_event.InnerHtml += item.add_event.GetFormattedValue();
            cal_monthadd_event.HRef = item.add_eventHref+item.add_eventHrefParameters.ToString("None","", ViewState);
            DataItem.DayNumberHref = "day.aspx";
            DataItem.DayNumberHrefParameters.Add("day",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("yyyy-MM-dd")));
            cal_monthDayNumber.HRef = DataItem.DayNumberHref + DataItem.DayNumberHrefParameters.ToString("None","", ViewState);
            DataItem.add_eventHref = "events.aspx";
            DataItem.add_eventHrefParameters.Add("event_date",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("d")));
            cal_monthadd_event.HRef = DataItem.add_eventHref + DataItem.add_eventHrefParameters.ToString("None","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.EventRow) {
            cal_monthcategory_image.ImageUrl += DataItem.category_image.GetFormattedValue();
            DataItem.EventDescriptionHref = "event_view.aspx";
            cal_monthEventDescription.HRef = DataItem.EventDescriptionHref + DataItem.EventDescriptionHrefParameters.ToString("None","", ViewState);
        }
//End Calendar cal_month ItemDataBound event

//cal_month control Before Show @5-9C999291
        if (e.Item.ItemType == CCCalendarItemType.Footer) {
//End cal_month control Before Show

//Panel CalendarTypes Event BeforeShow. Action Custom Code @199-2A29BDB7
    // -------------------------
	DateTime SelectDay = cal_month.Date;
	cal_monthWeekIcon.HRef = CommonFunctions.CCAddParam(cal_monthWeekIcon.HRef, "day", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM-dd"));
	cal_monthYearIcon.HRef = CommonFunctions.CCAddParam(cal_monthYearIcon.HRef, "year_eventsDate", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM"));
    // -------------------------
//End Panel CalendarTypes Event BeforeShow. Action Custom Code

//cal_month control Before Show tail @5-FCB6E20C
        }
//End cal_month control Before Show tail

//cal_month control Before Show @5-C32A7B8A
        if (e.Item.ItemType == CCCalendarItemType.DayHeader) {
//End cal_month control Before Show

//Link add_event Event BeforeShow. Action Custom Code @53-2A29BDB7
    // -------------------------
				if (CommonFunctions.AddAllowed()) 
				{
					cal_monthadd_event.Visible = true;
					LinkParameterCollection p = new LinkParameterCollection();
					cal_monthadd_event.HRef = CommonFunctions.CCAddParam(cal_monthadd_event.HRef, "ret_link", Request.Path + p.ToString("GET", "", ViewState));
				} 
				else 
				{
					cal_monthadd_event.Visible = false;
				}
    // -------------------------
//End Link add_event Event BeforeShow. Action Custom Code

//cal_month control Before Show tail @5-FCB6E20C
        }
//End cal_month control Before Show tail

//cal_month control Before Show @5-B30760D4
        if (e.Item.ItemType == CCCalendarItemType.EventRow) {
//End cal_month control Before Show

//Image category_image Event BeforeShow. Action Custom Code @51-2A29BDB7
    // -------------------------
			if (item.category_image.GetFormattedValue().Length > 0) {
				cal_monthcategory_image.Visible = true;
			} else {
				cal_monthcategory_image.Visible = false;
			}
    // -------------------------
//End Image category_image Event BeforeShow. Action Custom Code

//Label EventTime Event BeforeShow. Action Custom Code @52-2A29BDB7
    // -------------------------
			if (cal_monthEventTime.Text.Length > 0) {
				cal_monthEventTime.Text = cal_monthEventTime.Text + " - ";
				cal_monthEventTime.Visible = true;
			} else {
				cal_monthEventTime.Visible = false;
			}
    // -------------------------
//End Label EventTime Event BeforeShow. Action Custom Code

//Link EventDescription Event BeforeShow. Action Custom Code @57-2A29BDB7
    // -------------------------
			if (CommonFunctions.str_calendar_config("popup_events") == "1") 
			{
				LinkParameterCollection p = new LinkParameterCollection();
				string parameters = CommonFunctions.CCAddParam(cal_monthEventDescription.HRef, "ret_link", Server.UrlEncode("index.aspx" + p.ToString("GET", "", ViewState)));
				int idx = parameters.IndexOf('?');
				parameters = idx!=-1?parameters.Substring(idx+1,parameters.Length-idx-1):parameters;
				cal_monthEventDescription.HRef = "javascript:openWin('event_view_popup.aspx?" + parameters + "')";
			}
    // -------------------------
//End Link EventDescription Event BeforeShow. Action Custom Code

//cal_month control Before Show tail @5-FCB6E20C
        }
//End cal_month control Before Show tail

//Calendar cal_month ItemDataBound event tail @5-FCB6E20C
    }
//End Calendar cal_month ItemDataBound event tail

//OnInit Event @1-A878FF13
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        indexContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        cal_monthData = new cal_monthDataProvider();
        cal_monthOperations = new FormSupportedOperations(false, true, false, false, false);
//End OnInit Event

//Page index Event AfterInitialize. Action Logout @29-C62C6A1C
        if (HttpContext.Current.Request["Logout"] != null) {
            HttpContext.Current.Session.Remove("UserID");
            HttpContext.Current.Session.Remove("GroupID");
            HttpContext.Current.Session.Remove("UserLogin");
            FormsAuthentication.SignOut();
        }
//End Page index Event AfterInitialize. Action Logout

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

