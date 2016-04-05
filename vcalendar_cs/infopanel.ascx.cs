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

namespace calendar.infopanel{ //Namespace @1-E3DA569F

//Forms Definition @1-BE8E1B1D
public partial class infopanelPage : System.Web.UI.UserControl
{
//End Forms Definition

    protected bool InfoCalendarInfoNavigatorVisible = true;
	protected int CurrentDayEventsCount = 0, divID = 0;

//Forms Objects @1-320631AE
    protected InfoCalendarDataProvider InfoCalendarData;
    protected FormSupportedOperations InfoCalendarOperations;
    protected System.Resources.ResourceManager rm;
    protected string infopanelContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-49CC9DF8
    if(Request.Form["InfoCalendarNavigatorSubmit"]!=null || Request.Form["InfoCalendarNavigatorSubmit.x"]!=null)
    {
        LinkParameterCollection p = new LinkParameterCollection();
        if(Request.Form["InfoCalendarYear"]!=null) p.Add("InfoCalendarYear", Request.Form["InfoCalendarYear"]);
        if(Request.Form["InfoCalendarMonth"]!=null) p.Add("InfoCalendarMonth", Request.Form["InfoCalendarMonth"]);
        Response.Redirect(Request.Path + p.ToString("GET", "InfoCalendarMonth;InfoCalendarYear;InfoCalendarDate", ViewState));
    }
    InfoCalendarBind();
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

//Calendar InfoCalendar Bind @108-E253C819
    protected void InfoCalendarBind()
    {
        if (!InfoCalendarOperations.AllowRead) return;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"InfoCalendar",typeof(InfoCalendarDataProvider.SortFields), 0, -1);
        }
//End Calendar InfoCalendar Bind

//Calendar InfoCalendar Event BeforeSelect. Action Custom Code @184-2A29BDB7
    // -------------------------
  		System.Web.HttpContext.Current.Session["CurrentIDate"] = Convert.ToString(InfoCalendar.Year) + "-" + ("0" + Convert.ToString(InfoCalendar.Month)).Substring(Convert.ToString(InfoCalendar.Month).Length-1,2);
    // -------------------------
//End Calendar InfoCalendar Event BeforeSelect. Action Custom Code

//Calendar Form InfoCalendar BeforeShow tail @108-C32221BF
        InfoCalendarParameters();
        InfoCalendar.DataSource = InfoCalendarData.GetResultSet(InfoCalendarOperations);
        InfoCalendar.DataBind();
//End Calendar Form InfoCalendar BeforeShow tail

//Calendar InfoCalendar Bind tail @108-FCB6E20C
    }
//End Calendar InfoCalendar Bind tail

//Calendar InfoCalendar Table Parameters @108-19862855
    protected void InfoCalendarParameters()
    {
        try{
            InfoCalendarData.Sescategory = IntegerParameter.GetParam(Session.Contents["category"]);
        }catch{
            ControlCollection ParentControls=InfoCalendar.Parent.Controls;
            int Index = ParentControls.IndexOf(InfoCalendar);
            ParentControls.RemoveAt(Index);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Calendar InfoCalendar: Invalid parameter";
            ParentControls.AddAt(Index,ErrorMessage);
        }
	}
	
//End Calendar InfoCalendar Table Parameters

//Calendar InfoCalendar ItemDataBound event @108-8F6AA75F
    protected void InfoCalendarItemDataBound(Object Sender, CCCalendarItemEventArgs e)
    {
        InfoCalendarItem DataItem = (InfoCalendarItem)e.Item.DataItem;
        if(DataItem == null) DataItem = new InfoCalendarItem();
        InfoCalendarItem item = DataItem;
        System.Web.UI.WebControls.Literal InfoCalendarMonthDate = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendarMonthDate"));
        System.Web.UI.WebControls.Literal InfoCalendarDayOfWeek = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendarDayOfWeek"));
        System.Web.UI.WebControls.PlaceHolder InfoCalendarGoWeekHeader = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("InfoCalendarGoWeekHeader"));
        System.Web.UI.HtmlControls.HtmlAnchor InfoCalendarDayNumber = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("InfoCalendarDayNumber"));
        System.Web.UI.WebControls.Literal InfoCalendardiv_begin = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendardiv_begin"));
        System.Web.UI.WebControls.Image InfoCalendarcategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("InfoCalendarcategory_image"));
        System.Web.UI.WebControls.Literal InfoCalendarEventTime = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendarEventTime"));
        System.Web.UI.WebControls.Literal InfoCalendarEventTimeEnd = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendarEventTimeEnd"));
        System.Web.UI.WebControls.Literal InfoCalendarEventDescription = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendarEventDescription"));
        System.Web.UI.WebControls.Literal InfoCalendardiv_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendardiv_end"));
        System.Web.UI.WebControls.PlaceHolder InfoCalendarGoWeekPanel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("InfoCalendarGoWeekPanel"));
        System.Web.UI.WebControls.PlaceHolder InfoCalendarInfoNavigator = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("InfoCalendarInfoNavigator"));
        System.Web.UI.WebControls.Literal InfoCalendarStyleControl = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("InfoCalendarStyleControl"));
        System.Web.UI.HtmlControls.HtmlAnchor InfoCalendarGoWeek = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("InfoCalendarGoWeek"));
        System.Web.UI.HtmlControls.HtmlAnchor InfoCalendarPrevMonth = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("InfoCalendarPrevMonth"));
        System.Web.UI.HtmlControls.HtmlAnchor InfoCalendarNextMonth = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("InfoCalendarNextMonth"));
        if (e.Item.ItemType == CCCalendarItemType.Header) {
        }
        if (e.Item.ItemType == CCCalendarItemType.Footer) {
            InfoCalendarPrevMonth.InnerHtml += item.PrevMonth.GetFormattedValue();
            InfoCalendarPrevMonth.HRef = item.PrevMonthHref+item.PrevMonthHrefParameters.ToString("GET","InfoCalendarDate", ViewState);
            InfoCalendarNextMonth.InnerHtml += item.NextMonth.GetFormattedValue();
            InfoCalendarNextMonth.HRef = item.NextMonthHref+item.NextMonthHrefParameters.ToString("GET","InfoCalendarDate", ViewState);
            DataItem.PrevMonthHref = "";
            InfoCalendarPrevMonth.HRef = DataItem.PrevMonthHref + DataItem.PrevMonthHrefParameters.ToString("GET","InfoCalendarDate", ViewState);
            DataItem.NextMonthHref = "";
            InfoCalendarNextMonth.HRef = DataItem.NextMonthHref + DataItem.NextMonthHrefParameters.ToString("GET","InfoCalendarDate", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekFooter) {
            InfoCalendarGoWeek.InnerHtml += item.GoWeek.GetFormattedValue();
            InfoCalendarGoWeek.HRef = item.GoWeekHref+item.GoWeekHrefParameters.ToString("None","", ViewState);
            DataItem.GoWeekHref = "week.aspx";
            DataItem.GoWeekHrefParameters.Add("day",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("yyyy-MM-dd")));
            InfoCalendarGoWeek.HRef = DataItem.GoWeekHref + DataItem.GoWeekHrefParameters.ToString("None","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekDays) {
        }
        if (e.Item.ItemType == CCCalendarItemType.DayHeader) {
            InfoCalendardiv_begin.Text=item.div_begin.GetFormattedValue();
            InfoCalendarStyleControl.Text=item.StyleControl.GetFormattedValue();
            DataItem.DayNumberHref = "day.aspx";
            DataItem.DayNumberHrefParameters.Add("day",System.Web.HttpUtility.UrlEncode(e.Item.CurrentProcessingDate.ToString("yyyy-MM-dd")));
            InfoCalendarDayNumber.HRef = DataItem.DayNumberHref + DataItem.DayNumberHrefParameters.ToString("None","", ViewState);
        }
        if (e.Item.ItemType == CCCalendarItemType.DayFooter) {
            InfoCalendardiv_end.Text=item.div_end.GetFormattedValue();
        }
        if (e.Item.ItemType == CCCalendarItemType.EventRow) {
            InfoCalendarcategory_image.ImageUrl += DataItem.category_image.GetFormattedValue();
        }
        if (e.Item.ItemType == CCCalendarItemType.WeekDaysFooter) {
        }
//End Calendar InfoCalendar ItemDataBound event

//InfoCalendar control Before Show @108-9C999291
        if (e.Item.ItemType == CCCalendarItemType.Footer) {
//End InfoCalendar control Before Show

//Panel InfoNavigator Event BeforeShow. Action Custom Code @181-2A29BDB7
    // -------------------------
		InfoCalendarInfoNavigator.Visible = InfoCalendarInfoNavigatorVisible;
		DateTime CurrDate = InfoCalendar.CurrentDate;
		InfoCalendarPrevMonth.HRef = CommonFunctions.CCAddParam(InfoCalendarPrevMonth.HRef, "InfoCalendar", CommonFunctions.CCFormatDate(CurrDate.AddMonths(-1), "yyyy-MM"));
		InfoCalendarNextMonth.HRef = CommonFunctions.CCAddParam(InfoCalendarNextMonth.HRef, "InfoCalendar", CommonFunctions.CCFormatDate(CurrDate.AddMonths( 1), "yyyy-MM"));
    // -------------------------
//End Panel InfoNavigator Event BeforeShow. Action Custom Code

//InfoCalendar control Before Show tail @108-FCB6E20C
        }
//End InfoCalendar control Before Show tail

//InfoCalendar control Before Show @108-60E1554A
        if (e.Item.ItemType == CCCalendarItemType.WeekFooter) {
//End InfoCalendar control Before Show

//Link GoWeek Event BeforeShow. Action Custom Code @57-2A29BDB7
    // -------------------------
				if (CommonFunctions.str_calendar_config("info_week_icon") == "1") 
				{
					InfoCalendarGoWeekPanel.Visible = true;
				} 
				else 
				{
					InfoCalendarGoWeekPanel.Visible = false;
				}
    // -------------------------
//End Link GoWeek Event BeforeShow. Action Custom Code

//InfoCalendar control Before Show tail @108-FCB6E20C
        }
//End InfoCalendar control Before Show tail

//InfoCalendar control Before Show @108-C32A7B8A
        if (e.Item.ItemType == CCCalendarItemType.DayHeader) {
//End InfoCalendar control Before Show

//Label StyleControl Event BeforeShow. Action Retrieve Value for Control @182-2AE08470
            InfoCalendarStyleControl.Text = (new TextField("", (e.Item.StyleString))).GetFormattedValue();
//End Label StyleControl Event BeforeShow. Action Retrieve Value for Control

//Calendar InfoCalendar Event BeforeShowDay. Action Custom Code @114-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Calendar InfoCalendar Event BeforeShowDay. Action Custom Code

//InfoCalendar control Before Show tail @108-FCB6E20C
        }
//End InfoCalendar control Before Show tail

			if (e.Item.ItemType == CCCalendarItemType.EventRow) CurrentDayEventsCount++;
			if (e.Item.ItemType == CCCalendarItemType.DayFooter) 
			{
				int idx = ((WebControl)Sender).Controls.IndexOf(e.Item) - 1;
				System.Web.UI.WebControls.Literal InfoCalendardiv_begin2 = null;
				while (idx>0 && (InfoCalendardiv_begin2 = (System.Web.UI.WebControls.Literal)(((WebControl)Sender).Controls[idx].FindControl("InfoCalendardiv_begin")))==null) idx--;
		        System.Web.UI.WebControls.Literal InfoCalendarStyleControl2 = (System.Web.UI.WebControls.Literal)(((WebControl)Sender).Controls[idx].FindControl("InfoCalendarStyleControl"));
				
				string LinkStyle = "";
				string LinkOnMouseOver = "";
				string LinkOnMouseOut = "";
				DateTime CurrentDay = e.Item.CurrentProcessingDate;

				string[] Paths = Request.Path.Split('/');
				string FileName = Paths[Paths.Length-1].ToLower();

				System.Web.UI.HtmlControls.HtmlAnchor InfoCalendarDayNumber2 = (System.Web.UI.HtmlControls.HtmlAnchor)(((WebControl)Sender).Controls[idx].FindControl("InfoCalendarDayNumber"));
				InfoCalendarDayNumber2.Attributes.Remove("style");
				InfoCalendarDayNumber2.Attributes.Remove("onmouseover");
				InfoCalendarDayNumber2.Attributes.Remove("onmouseout");
				if (CurrentDayEventsCount > 0) 
				{
					divID++;
					InfoCalendardiv_begin2.Text = "<div style=\"position: absolute; visibility: hidden; padding: 6px; border: 1px solid black; text-align: left; background: #ffffff\" name=\"float\" id=\"div" + divID + "\">";
					InfoCalendardiv_end.Text = "</div>";
					LinkStyle = CommonFunctions.str_calendar_config("event_day_style");
					LinkOnMouseOver = "javascript:show('" + divID + "')";
					LinkOnMouseOut = "javascript:hide('" + divID + "')";
					CurrentDayEventsCount = 0;
				}
				else 
				{
					InfoCalendardiv_begin2.Text = "";
					InfoCalendardiv_end.Text = "";
				}

				if (CurrentDay == DateTime.Today)
					if ((int)CurrentDay.DayOfWeek > 5)
						InfoCalendarStyleControl2.Text = "class=\"CalendarWeekendToday\"";
					else
						InfoCalendarStyleControl2.Text = "class=\"CalendarToday\"";
				else
					if 	(CurrentDay == InfoCalendar.CurrentDate)
						if ((int)CurrentDay.DayOfWeek > 5)
							InfoCalendarStyleControl2.Text = "class=\"CalendarWeekend\"";
						else
							InfoCalendarStyleControl2.Text = "class=\"CalendarDay\"";

				if (FileName == "day.aspx" || FileName == "week.aspx") {
					DateTime LastDay;
					DateTime SelectDay = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("day", CommonFunctions.CCFormatDate(DateTime.Now, "yyyy-MM-dd")), "yyyy-MM-dd");
					int FirstWeekDay = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
					if (FileName == "week.aspx") {
						SelectDay = SelectDay.AddDays((FirstWeekDay-(int)SelectDay.DayOfWeek-7) % 7);
						LastDay = SelectDay.AddDays(6);
					} else
						LastDay = SelectDay;

					if (!(SelectDay > CurrentDay) && !(CurrentDay > LastDay)) {
						InfoCalendarStyleControl2.Text = " class=\"CalendarSelectedDay\" ";
						if (LinkStyle.Length == 0) {
							LinkStyle = "font-weight: normal";
							InfoCalendarDayNumber2.Attributes.Add("style","font-weight: normal");
						}
					} 
				}  

				if (LinkStyle.Length>0)
					InfoCalendarDayNumber2.Attributes.Add("style",LinkStyle);
				if (LinkOnMouseOver.Length>0) {
					InfoCalendarDayNumber2.Attributes.Add("onmouseover",LinkOnMouseOver);
					InfoCalendarDayNumber2.Attributes.Add("onmouseout",LinkOnMouseOut);
				}
			}

//InfoCalendar control Before Show @108-D3186B72
        if (e.Item.ItemType == CCCalendarItemType.EmptyDay) {
//End InfoCalendar control Before Show

//Calendar InfoCalendar Event BeforeShowDay. Action Custom Code @114-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Calendar InfoCalendar Event BeforeShowDay. Action Custom Code

//InfoCalendar control Before Show tail @108-FCB6E20C
        }
//End InfoCalendar control Before Show tail

//InfoCalendar control Before Show @108-B30760D4
        if (e.Item.ItemType == CCCalendarItemType.EventRow) {
//End InfoCalendar control Before Show

//Image category_image Event BeforeShow. Action Custom Code @36-2A29BDB7
    // -------------------------
				if (item.category_image.GetFormattedValue().Length == 0) 
				{
					InfoCalendarcategory_image.Visible = false;
				} 
				else 
				{
					InfoCalendarcategory_image.Visible = true;
				}
    // -------------------------
//End Image category_image Event BeforeShow. Action Custom Code

//Label EventTime Event BeforeShow. Action Custom Code @25-2A29BDB7
    // -------------------------
				if (InfoCalendarEventTime.Text.Length > 0) 
				{
					InfoCalendarEventTime.Visible = true;
					InfoCalendarEventTime.Text = InfoCalendarEventTime.Text + " - ";
				} 
				else 
				{
					InfoCalendarEventTime.Visible = false;
				}
    // -------------------------
//End Label EventTime Event BeforeShow. Action Custom Code

//InfoCalendar control Before Show tail @108-FCB6E20C
        }
//End InfoCalendar control Before Show tail

//InfoCalendar control Before Show @108-B76C6B5F
        if (e.Item.ItemType == CCCalendarItemType.WeekDaysFooter) {
//End InfoCalendar control Before Show

//Panel GoWeekHeader Event BeforeShow. Action Custom Code @58-2A29BDB7
    // -------------------------
				if (CommonFunctions.str_calendar_config("info_week_icon") == "1") 
				{
					InfoCalendarGoWeekHeader.Visible = true;
				} 
				else 
				{
					InfoCalendarGoWeekHeader.Visible = false;
				}
    // -------------------------
//End Panel GoWeekHeader Event BeforeShow. Action Custom Code

//InfoCalendar control Before Show tail @108-FCB6E20C
        }
//End InfoCalendar control Before Show tail

//Calendar InfoCalendar ItemDataBound event tail @108-FCB6E20C
    }
//End Calendar InfoCalendar ItemDataBound event tail

//OnInit Event @1-E55A8264
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        infopanelContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        InfoCalendarData = new InfoCalendarDataProvider();
        InfoCalendarOperations = new FormSupportedOperations(false, true, false, false, false);
//End OnInit Event

//Page infopanel Event AfterInitialize. Action Custom Code @20-2A29BDB7
    // -------------------------
		string[] Paths = Request.Path.Split('/');
		string FileName = Paths[Paths.Length-1].ToLower();
		InfoCalendar.CurrentDate = DateTime.Now;
		if (FileName == "mini_calendar.aspx")
		{
			vertical_menu.Visible = false;
			InfoJavaScriptPanel.Visible = false;
			InfoCalendar.Visible = true;
			InfoCalendarInfoNavigatorVisible = true;
			if (Convert.ToString(CommonFunctions.CCGetFromGet("InfoCalendar", "")).Length > 0)
				InfoCalendar.CurrentDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("InfoCalendar", ""), "yyyy-MM");
		}
		else
		{
			switch (CommonFunctions.str_calendar_config("info_calendar")) {
				case "None":
					InfoCalendar.Visible = false;
					break;
				case "Selected":
					switch (FileName) {
						case "index.aspx":
							if (CommonFunctions.str_calendar_config("info_in_views") == "2") {
								LinkParameterCollection p = new LinkParameterCollection();
								string QueryString = p.ToString("GET", "", ViewState);
								int InfPos = QueryString.IndexOf("InfoCalendar=");
								if (CommonFunctions.CCGetFromGet("cal_monthDate", "").Length > 0 && (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length == 0 || QueryString.IndexOf("cal_monthDate") > InfPos))
									InfoCalendar.CurrentDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("cal_monthDate", ""), "yyyy-MM");
								else
									if (CommonFunctions.CCGetFromGet("cal_monthMonth", "").Length > 0 && CommonFunctions.CCGetFromGet("cal_monthYear", "").Length > 0 && (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length == 0 || QueryString.IndexOf("cal_monthYear") > InfPos || QueryString.IndexOf("cal_monthMonth") > InfPos))
										InfoCalendar.CurrentDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("cal_monthYear", "") + "-" + CommonFunctions.CCGetFromGet("cal_monthMonth", ""), "yyyy-MM");
									else {
										if (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length > 0)
											InfoCalendar.CurrentDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("InfoCalendar", ""), "yyyy-MM");
									}
							} else 
								InfoCalendar.Visible = false;
							break;

						case "day.aspx":
						case "week.aspx":
				            if (CommonFunctions.CCGetFromGet("day", "").Length > 0 && CommonFunctions.CCGetFromGet("InfoCalendar", "").Length == 0)
								InfoCalendar.CurrentDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("day", ""), "yyyy-MM-dd");
							else
								if (CommonFunctions.CCGetFromGet("InfoCalendar", "").Length > 0)
									InfoCalendar.CurrentDate = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("InfoCalendar", ""), "yyyy-MM");
							break;

						default:
							InfoCalendar.Visible = false;
							break;
					}
					if (CommonFunctions.str_calendar_config("info_navigator") == "1")
						InfoCalendarInfoNavigatorVisible = true;
					else 
						InfoCalendarInfoNavigatorVisible = false;
					break;

				default:
					switch (FileName) {
						case "index.aspx":
							if (CommonFunctions.str_calendar_config("info_in_views") != "2") 
								InfoCalendar.Visible = false;
							break;
						case "day.aspx":
						case "week.aspx":
							break;
						default:
							InfoCalendar.Visible = false;
							break;
					}
					InfoCalendarInfoNavigatorVisible = false;
					break;
			}
		}
		System.Web.HttpContext.Current.Session["CurrentIDate"] = InfoCalendar.CurrentDate.ToString("yyyy-MM");
    // -------------------------
//End Page infopanel Event AfterInitialize. Action Custom Code

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

