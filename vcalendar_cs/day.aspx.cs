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

namespace calendar.day{ //Namespace @1-E6CB5B89

//Forms Definition @1-E0F93569
public partial class dayPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-59536E17
    protected ShortViewEventsGridDataProvider ShortViewEventsGridData;
    protected int ShortViewEventsGridCurrentRowNumber;
    protected FormSupportedOperations ShortViewEventsGridOperations;
    protected ShortViewEventsNavigatorDataProvider ShortViewEventsNavigatorData;
    protected NameValueCollection ShortViewEventsNavigatorErrors=new NameValueCollection();
    protected bool ShortViewEventsNavigatorIsSubmitted = false;
    protected FormSupportedOperations ShortViewEventsNavigatorOperations;
    protected System.Resources.ResourceManager rm;
    protected string dayContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-497CE700
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            FullViewEvents.Text=item.FullViewEvents.GetFormattedValue();
            ShortViewEventsGridBind();
            ShortViewEventsNavigatorShow();
    }
//End Page_Load Event BeforeIsPostBack

//Page day Event BeforeShow. Action Custom Code @6-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Page day Event BeforeShow. Action Custom Code

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

//Grid ShortViewEventsGrid Bind @237-E82ABC6F
    protected void ShortViewEventsGridBind()
    {
        if (!ShortViewEventsGridOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"ShortViewEventsGrid",typeof(ShortViewEventsGridDataProvider.SortFields), 100, 100);
        }
//End Grid ShortViewEventsGrid Bind

//Grid Form ShortViewEventsGrid BeforeShow tail @237-9137D5B3
        ShortViewEventsGridParameters();
        ShortViewEventsGridData.SortField = (ShortViewEventsGridDataProvider.SortFields)ViewState["ShortViewEventsGridSortField"];
        ShortViewEventsGridData.SortDir = (SortDirections)ViewState["ShortViewEventsGridSortDir"];
        ShortViewEventsGridData.PageNumber = (int)ViewState["ShortViewEventsGridPageNumber"];
        ShortViewEventsGridData.RecordsPerPage = (int)ViewState["ShortViewEventsGridPageSize"];
        ShortViewEventsGridRepeater.DataSource = ShortViewEventsGridData.GetResultSet(out PagesCount, ShortViewEventsGridOperations);
        ViewState["ShortViewEventsGridPagesCount"] = PagesCount;
        ShortViewEventsGridRepeater.DataBind();
        FooterIndex = ShortViewEventsGridRepeater.Controls.Count - 1;
        ShortViewEventsGridRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        ShortViewEventsGridItem item=new ShortViewEventsGridItem();
        System.Web.UI.WebControls.Literal ShortViewEventsGridCalendarDate = (System.Web.UI.WebControls.Literal)ShortViewEventsGridRepeater.Controls[0].FindControl("ShortViewEventsGridCalendarDate");
        System.Web.UI.WebControls.Literal ShortViewEventsGridadd_event_spacer = (System.Web.UI.WebControls.Literal)ShortViewEventsGridRepeater.Controls[0].FindControl("ShortViewEventsGridadd_event_spacer");
        System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridadd_event = (System.Web.UI.HtmlControls.HtmlAnchor)ShortViewEventsGridRepeater.Controls[0].FindControl("ShortViewEventsGridadd_event");

        item.add_eventHref = "events.aspx";

        ShortViewEventsGridCalendarDate.Text=Server.HtmlEncode(item.CalendarDate.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        ShortViewEventsGridadd_event_spacer.Text=Server.HtmlEncode(item.add_event_spacer.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        ShortViewEventsGridadd_event.InnerHtml += item.add_event.GetFormattedValue();
        ShortViewEventsGridadd_event.HRef = item.add_eventHref+item.add_eventHrefParameters.ToString("None","", ViewState);
//End Grid Form ShortViewEventsGrid BeforeShow tail

//Grid ShortViewEventsGrid Event BeforeShow. Action Custom Code @244-2A29BDB7
    // -------------------------
    	DateField dayParam = new DateField("yyyy-MM-dd");
    	dayParam.SetValue(Request.QueryString["day"] != null?(object)Request.QueryString["day"]:(object)DateTime.Now, "yyyy-MM-dd");
        ShortViewEventsGridCalendarDate.Text = dayParam.GetFormattedValue(item.CalendarDate.Format);

		if (CommonFunctions.AddAllowed())
		{
			DateTime SelDay = Request.QueryString["day"]!=null?DBUtility.ParseDate(Request.QueryString["day"],""):DateTime.Now;
			ShortViewEventsGridadd_event.HRef = CommonFunctions.CCAddParam(ShortViewEventsGridadd_event.HRef, "event_date", CommonFunctions.CCFormatDate(SelDay, "d"));
			ShortViewEventsGridadd_event.HRef = CommonFunctions.CCAddParam(ShortViewEventsGridadd_event.HRef, "ret_link", GetShortViewEventsNavigatorRedirectUrl("",""));
			ShortViewEventsGridadd_event_spacer.Text = "&nbsp;&nbsp;&nbsp;";
		} else {
			ShortViewEventsGridadd_event.Visible = false;
		}

    // -------------------------
//End Grid ShortViewEventsGrid Event BeforeShow. Action Custom Code

//Grid ShortViewEventsGrid Bind tail @237-FCB6E20C
    }
//End Grid ShortViewEventsGrid Bind tail

//Grid ShortViewEventsGrid Table Parameters @237-BEA02108
    protected void ShortViewEventsGridParameters()
    {
        try{
            ShortViewEventsGridData.Urlday = DateParameter.GetParam("day", ParameterSourceType.URL, "yyyy-MM-dd", null, false);
            ShortViewEventsGridData.Sescategory = IntegerParameter.GetParam("category", ParameterSourceType.Session, "", null, false);
            ShortViewEventsGridData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            ShortViewEventsGridData.Urlevents_category_id = IntegerParameter.GetParam("events_category_id", ParameterSourceType.URL, "", null, false);
        }catch{
            ControlCollection ParentControls=ShortViewEventsGridRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(ShortViewEventsGridRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid ShortViewEventsGrid: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid ShortViewEventsGrid Table Parameters

//Grid ShortViewEventsGrid ItemDataBound event @237-3CF500BB
    protected void ShortViewEventsGridItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        ShortViewEventsGridItem DataItem=(ShortViewEventsGridItem)e.Item.DataItem;
        ShortViewEventsGridItem[] FormDataSource=(ShortViewEventsGridItem[])ShortViewEventsGridRepeater.DataSource;
        ShortViewEventsGridItem item = DataItem;
        int ShortViewEventsGridDataRows = FormDataSource.Length;
        bool ShortViewEventsGridIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        ShortViewEventsGridCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal ShortViewEventsGridevent_time = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridevent_time"));
            System.Web.UI.WebControls.Literal ShortViewEventsGridevent_time_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridevent_time_end"));
            System.Web.UI.WebControls.Image ShortViewEventsGridcategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("ShortViewEventsGridcategory_image"));
            System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridevent_title = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridevent_title"));
            System.Web.UI.WebControls.Literal ShortViewEventsGridcategory_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridcategory_name"));
            ShortViewEventsGridcategory_image.ImageUrl += DataItem.category_image.GetFormattedValue();
            DataItem.event_titleHref = "event_view.aspx";
            ShortViewEventsGridevent_title.HRef = DataItem.event_titleHref + DataItem.event_titleHrefParameters.ToString("None","", ViewState);
        }
//End Grid ShortViewEventsGrid ItemDataBound event

//ShortViewEventsGrid control Before Show @237-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End ShortViewEventsGrid control Before Show

//Get Control @238-04919A13
            System.Web.UI.WebControls.Literal ShortViewEventsGridevent_time = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridevent_time"));
//End Get Control

//Label event_time Event BeforeShow. Action Custom Code @249-2A29BDB7
    // -------------------------
	if (ShortViewEventsGridevent_time.Text.Length > 0) {
		ShortViewEventsGridevent_time.Text = ShortViewEventsGridevent_time.Text + "&nbsp;-";		
		ShortViewEventsGridevent_time.Visible = true;
	} else {
		ShortViewEventsGridevent_time.Visible = false;
	}
	// -------------------------
//End Label event_time Event BeforeShow. Action Custom Code

//Get Control @239-70A30467
            System.Web.UI.WebControls.Image ShortViewEventsGridcategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("ShortViewEventsGridcategory_image"));
//End Get Control

//Image category_image Event BeforeShow. Action Custom Code @247-2A29BDB7
    // -------------------------
	if (item.category_image.GetFormattedValue().Length > 0) {
		ShortViewEventsGridcategory_image.Visible = true;
	} else {
		ShortViewEventsGridcategory_image.Visible = false;
	}
    // -------------------------
//End Image category_image Event BeforeShow. Action Custom Code

//Get Control @240-F1DEBB7B
            System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridevent_title = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridevent_title"));
//End Get Control

//Link event_title Event BeforeShow. Action Custom Code @241-2A29BDB7
    // -------------------------
	if (CommonFunctions.str_calendar_config("popup_events") == "1") {
		string parameters = CommonFunctions.CCGetFromGet("day", "");
		parameters = CommonFunctions.CCAddParam(ShortViewEventsGridevent_title.HRef, "ret_link", Server.UrlEncode("day.aspx" + (parameters.Length > 0? "?day=" + parameters : "")));
		int idx = parameters.IndexOf('?');
		parameters = idx!=-1?parameters.Substring(idx+1,parameters.Length-idx-1):parameters;
		ShortViewEventsGridevent_title.HRef = "javascript:openWin('event_view_popup.aspx?" + parameters + "')";
	}
    // -------------------------
//End Link event_title Event BeforeShow. Action Custom Code

//Get Control @242-3B395EC7
            System.Web.UI.WebControls.Literal ShortViewEventsGridcategory_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridcategory_name"));
//End Get Control

//Label category_name Event BeforeShow. Action Custom Code @248-2A29BDB7
    // -------------------------
	if (ShortViewEventsGridcategory_name.Text.Length > 0) {
		ShortViewEventsGridcategory_name.Text = "(" + ShortViewEventsGridcategory_name.Text + ")";
		ShortViewEventsGridcategory_name.Visible = true;
	} else {
		ShortViewEventsGridcategory_name.Visible = false;
	}
    // -------------------------
//End Label category_name Event BeforeShow. Action Custom Code

//ShortViewEventsGrid control Before Show tail @237-FCB6E20C
        }
//End ShortViewEventsGrid control Before Show tail

//Grid ShortViewEventsGrid BeforeShowRow event @237-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid ShortViewEventsGrid BeforeShowRow event

//Grid ShortViewEventsGrid Event BeforeShowRow. Action Custom Code @112-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Grid ShortViewEventsGrid Event BeforeShowRow. Action Custom Code

//Grid ShortViewEventsGrid BeforeShowRow event tail @237-FCB6E20C
        }
//End Grid ShortViewEventsGrid BeforeShowRow event tail

//Grid ShortViewEventsGrid ItemDataBound event tail @237-10DF14EC
        if(ShortViewEventsGridIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(ShortViewEventsGridCurrentRowNumber, ListItemType.Item);
            ShortViewEventsGridRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            ShortViewEventsGridItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid ShortViewEventsGrid ItemDataBound event tail

//Grid ShortViewEventsGrid ItemCommand event @237-E564D1EC
    protected void ShortViewEventsGridItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = ShortViewEventsGridRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["ShortViewEventsGridSortDir"]==SortDirections.Asc&&ViewState["ShortViewEventsGridSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["ShortViewEventsGridSortDir"]=SortDirections.Desc;
                else
                    ViewState["ShortViewEventsGridSortDir"]=SortDirections.Asc;
            else
                ViewState["ShortViewEventsGridSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["ShortViewEventsGridSortField"]=Enum.Parse(typeof(ShortViewEventsGridDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["ShortViewEventsGridPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["ShortViewEventsGridPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            ShortViewEventsGridBind();
    }
//End Grid ShortViewEventsGrid ItemCommand event

//Record Form ShortViewEventsNavigator Parameters @85-AE94DFF5
    protected void ShortViewEventsNavigatorParameters()
    {
        ShortViewEventsNavigatorItem item=ShortViewEventsNavigatorItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            ShortViewEventsNavigatorErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form ShortViewEventsNavigator Parameters

//Record Form ShortViewEventsNavigator Show method @85-8F81F125
    protected void ShortViewEventsNavigatorShow()
    {
        if(ShortViewEventsNavigatorOperations.None)
        {
            ShortViewEventsNavigatorHolder.Visible=false;
            return;
        }
        ShortViewEventsNavigatorItem item=ShortViewEventsNavigatorItem.CreateFromHttpRequest();
        bool IsInsertMode=!ShortViewEventsNavigatorOperations.AllowRead;
        item.prev_day_linkHref = "day.aspx";
        item.next_day_linkHref = "day.aspx";
        item.YearIconHref = "year.aspx";
        item.MonthIconHref = "index.aspx";
        item.WeekIconHref = "week.aspx";
        ShortViewEventsNavigatorErrors.Add(item.errors);
//End Record Form ShortViewEventsNavigator Show method

//Record Form ShortViewEventsNavigator BeforeShow tail @85-65B1BEF4
        ShortViewEventsNavigatorParameters();
        ShortViewEventsNavigatorData.FillItem(item,ref IsInsertMode);
        ShortViewEventsNavigatorHolder.DataBind();
        ShortViewEventsNavigatorprev_day_link.InnerHtml += item.prev_day_link.GetFormattedValue();
        ShortViewEventsNavigatorprev_day_link.HRef = item.prev_day_linkHref+item.prev_day_linkHrefParameters.ToString("None","", ViewState);
        item.date_dayItems.SetSelection(item.date_day.GetFormattedValue());
        if(item.date_dayItems.GetSelectedItem() != null)
            ShortViewEventsNavigatordate_day.SelectedIndex = -1;
        item.date_dayItems.CopyTo(ShortViewEventsNavigatordate_day.Items);
        ShortViewEventsNavigatornext_day_link.InnerHtml += item.next_day_link.GetFormattedValue();
        ShortViewEventsNavigatornext_day_link.HRef = item.next_day_linkHref+item.next_day_linkHrefParameters.ToString("None","", ViewState);
        item.weekItems.SetSelection(item.week.GetFormattedValue());
        if(item.weekItems.GetSelectedItem() != null)
            ShortViewEventsNavigatorweek.SelectedIndex = -1;
        item.weekItems.CopyTo(ShortViewEventsNavigatorweek.Items);
        ShortViewEventsNavigatorYearIcon.InnerHtml += item.YearIcon.GetFormattedValue();
        ShortViewEventsNavigatorYearIcon.HRef = item.YearIconHref+item.YearIconHrefParameters.ToString("None","", ViewState);
        ShortViewEventsNavigatorMonthIcon.InnerHtml += item.MonthIcon.GetFormattedValue();
        ShortViewEventsNavigatorMonthIcon.HRef = item.MonthIconHref+item.MonthIconHrefParameters.ToString("None","", ViewState);
        ShortViewEventsNavigatorWeekIcon.InnerHtml += item.WeekIcon.GetFormattedValue();
        ShortViewEventsNavigatorWeekIcon.HRef = item.WeekIconHref+item.WeekIconHrefParameters.ToString("None","", ViewState);
//End Record Form ShortViewEventsNavigator BeforeShow tail

//Record ShortViewEventsNavigator Event BeforeShow. Action Custom Code @91-2A29BDB7
    // -------------------------
			DateField dayParam = new DateField("yyyy-MM-dd");
			dayParam.SetValue(Request.QueryString["day"] != null?(object)Request.QueryString["day"]:(object)DateTime.Now, "yyyy-MM-dd");

			DateTime SelectDay = (DateTime)dayParam.Value;
			ShortViewEventsNavigatorprev_day_link.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorprev_day_link.HRef, "day", CommonFunctions.CCFormatDate(SelectDay.AddDays(-1), "yyyy-MM-dd"));
			ShortViewEventsNavigatornext_day_link.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatornext_day_link.HRef, "day", CommonFunctions.CCFormatDate(SelectDay.AddDays(1), "yyyy-MM-dd"));

			int FirstWeekDay = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
			DateTime LastYearDay = new DateTime(SelectDay.Year, 12, 31);
			DateTime FirstDay = new DateTime(SelectDay.Year, 1, 1);
			FirstDay = FirstDay.AddDays((FirstWeekDay-(int)FirstDay.DayOfWeek-7) % 7);

			string[] IndexArr = new string[55];
			string[] ValArr = new string[55];
			DateTime LastDay;
			int i=0;
			do
			{
				LastDay = FirstDay.AddDays(6);
				IndexArr[i] = CommonFunctions.CCFormatDate(FirstDay, "yyyy-MM-dd");
				ValArr[i] = CommonFunctions.CCFormatDate(FirstDay, "MMM d") + " - " + CommonFunctions.CCFormatDate(LastDay, "MMM d");
				FirstDay = FirstDay.AddDays(7);
				i++;
			}
			while (!(FirstDay > LastYearDay));

			for (int j=0; j<i; j++) ShortViewEventsNavigatorweek.Items.Add(new ListItem(ValArr[j],IndexArr[j]));
			ShortViewEventsNavigatorweek.Value = CommonFunctions.CCFormatDate(SelectDay.AddDays((FirstWeekDay-7-(int)SelectDay.DayOfWeek) % 7), "yyyy-MM-dd");

			i = 0;
			FirstDay = new DateTime(SelectDay.Year, SelectDay.Month, 1);
			do 
			{
				ValArr[i] = FirstDay.Day.ToString();
				IndexArr[i] = CommonFunctions.CCFormatDate(FirstDay, "yyyy-MM-dd");
				FirstDay = FirstDay.AddDays(1);
				i = i + 1;
			}while (SelectDay.Month == FirstDay.Month);

			for (int j=0; j<i; j++) ShortViewEventsNavigatordate_day.Items.Add(new ListItem(ValArr[j],IndexArr[j]));
			ShortViewEventsNavigatordate_day.Value = CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM-dd");

			ShortViewEventsNavigatorWeekIcon.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorWeekIcon.HRef, "day", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM-dd"));
			ShortViewEventsNavigatorMonthIcon.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorMonthIcon.HRef, "cal_monthDate", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM"));
			ShortViewEventsNavigatorYearIcon.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorYearIcon.HRef, "year_eventsDate", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM"));
    // -------------------------
//End Record ShortViewEventsNavigator Event BeforeShow. Action Custom Code

//Record Form ShortViewEventsNavigator Show method tail @85-7A2A44F4
        if(ShortViewEventsNavigatorErrors.Count>0)
            ShortViewEventsNavigatorShowErrors();
    }
//End Record Form ShortViewEventsNavigator Show method tail

//Record Form ShortViewEventsNavigator LoadItemFromRequest method @85-D5ED5A28
    protected void ShortViewEventsNavigatorLoadItemFromRequest(ShortViewEventsNavigatorItem item, bool EnableValidation)
    {
        item.date_day.SetValue(ShortViewEventsNavigatordate_day.Value);
        item.date_dayItems.CopyFrom(ShortViewEventsNavigatordate_day.Items);
        item.week.SetValue(ShortViewEventsNavigatorweek.Value);
        item.weekItems.CopyFrom(ShortViewEventsNavigatorweek.Items);
        if(EnableValidation)
            item.Validate(ShortViewEventsNavigatorData);
        ShortViewEventsNavigatorErrors.Add(item.errors);
    }
//End Record Form ShortViewEventsNavigator LoadItemFromRequest method

//Record Form ShortViewEventsNavigator GetRedirectUrl method @85-B53AE254
    protected string GetShortViewEventsNavigatorRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form ShortViewEventsNavigator GetRedirectUrl method

//Record Form ShortViewEventsNavigator ShowErrors method @85-63697133
    protected void ShortViewEventsNavigatorShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<ShortViewEventsNavigatorErrors.Count;i++)
        switch(ShortViewEventsNavigatorErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=ShortViewEventsNavigatorErrors[i];
                break;
        }
        ShortViewEventsNavigatorError.Visible = true;
    }
//End Record Form ShortViewEventsNavigator ShowErrors method

//Record Form ShortViewEventsNavigator Insert Operation @85-EBAF35DF
    protected void ShortViewEventsNavigator_Insert(object sender, System.EventArgs e)
    {
        ShortViewEventsNavigatorIsSubmitted = true;
        bool ErrorFlag = false;
        ShortViewEventsNavigatorItem item=new ShortViewEventsNavigatorItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ShortViewEventsNavigator Insert Operation

//Record Form ShortViewEventsNavigator BeforeInsert tail @85-CD4F207E
    ShortViewEventsNavigatorParameters();
    ShortViewEventsNavigatorLoadItemFromRequest(item, EnableValidation);
//End Record Form ShortViewEventsNavigator BeforeInsert tail

//Record Form ShortViewEventsNavigator AfterInsert tail  @85-2E701FCF
        ErrorFlag=(ShortViewEventsNavigatorErrors.Count>0);
        if(ErrorFlag)
            ShortViewEventsNavigatorShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form ShortViewEventsNavigator AfterInsert tail 

//Record Form ShortViewEventsNavigator Update Operation @85-AD0B02AB
    protected void ShortViewEventsNavigator_Update(object sender, System.EventArgs e)
    {
        ShortViewEventsNavigatorItem item=new ShortViewEventsNavigatorItem();
        item.IsNew = false;
        ShortViewEventsNavigatorIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ShortViewEventsNavigator Update Operation

//Record Form ShortViewEventsNavigator Before Update tail @85-CD4F207E
        ShortViewEventsNavigatorParameters();
        ShortViewEventsNavigatorLoadItemFromRequest(item, EnableValidation);
//End Record Form ShortViewEventsNavigator Before Update tail

//Record Form ShortViewEventsNavigator Update Operation tail @85-2E701FCF
        ErrorFlag=(ShortViewEventsNavigatorErrors.Count>0);
        if(ErrorFlag)
            ShortViewEventsNavigatorShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form ShortViewEventsNavigator Update Operation tail

//Record Form ShortViewEventsNavigator Delete Operation @85-99E6B4A8
    protected void ShortViewEventsNavigator_Delete(object sender,System.EventArgs e)
    {
        ShortViewEventsNavigatorIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        ShortViewEventsNavigatorItem item=new ShortViewEventsNavigatorItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form ShortViewEventsNavigator Delete Operation

//Record Form BeforeDelete tail @85-CD4F207E
        ShortViewEventsNavigatorParameters();
        ShortViewEventsNavigatorLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @85-C9B4B91F
        if(ErrorFlag)
            ShortViewEventsNavigatorShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form ShortViewEventsNavigator Cancel Operation @85-3ABEE0F9
    protected void ShortViewEventsNavigator_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        ShortViewEventsNavigatorItem item=new ShortViewEventsNavigatorItem();
        ShortViewEventsNavigatorIsSubmitted = true;
        string RedirectUrl = "";
        ShortViewEventsNavigatorLoadItemFromRequest(item, true);
//End Record Form ShortViewEventsNavigator Cancel Operation

//Button ButtonGo OnClick. @88-35DF2ED3
    if(((Control)sender).ID == "ShortViewEventsNavigatorButtonGo")
    {
        RedirectUrl  = GetShortViewEventsNavigatorRedirectUrl("", "");
//End Button ButtonGo OnClick.

//Button ButtonGo Event OnClick. Action Custom Code @92-2A29BDB7
    // -------------------------
	RedirectUrl = CommonFunctions.CCAddParam(GetShortViewEventsNavigatorRedirectUrl("",""),"day", ShortViewEventsNavigatordate_day.Value);
    // -------------------------
//End Button ButtonGo Event OnClick. Action Custom Code

//Button ButtonGo OnClick tail. @88-FCB6E20C
    }
//End Button ButtonGo OnClick tail.

//Button Button_DoSearch OnClick. @104-F6C9B761
    if(((Control)sender).ID == "ShortViewEventsNavigatorButton_DoSearch")
    {
        RedirectUrl  = GetShortViewEventsNavigatorRedirectUrl("", "");
//End Button Button_DoSearch OnClick.

//Button Button_DoSearch Event OnClick. Action Custom Code @105-2A29BDB7
    // -------------------------
	RedirectUrl = "week.aspx?day=" + ShortViewEventsNavigatorweek.Value;
    // -------------------------
//End Button Button_DoSearch Event OnClick. Action Custom Code

//Button Button_DoSearch OnClick tail. @104-FCB6E20C
    }
//End Button Button_DoSearch OnClick tail.

//Record Form ShortViewEventsNavigator Cancel Operation tail @85-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form ShortViewEventsNavigator Cancel Operation tail

//OnInit Event @1-34500052
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        dayContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        ShortViewEventsGridData = new ShortViewEventsGridDataProvider();
        ShortViewEventsGridOperations = new FormSupportedOperations(false, true, false, false, false);
        ShortViewEventsNavigatorData = new ShortViewEventsNavigatorDataProvider();
        ShortViewEventsNavigatorOperations = new FormSupportedOperations(false, true, true, true, true);
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

