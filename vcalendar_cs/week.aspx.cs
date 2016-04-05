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

namespace calendar.week{ //Namespace @1-768B85A6

//Forms Definition @1-6963EFFF
public partial class weekPage : System.Web.UI.Page
{
//End Forms Definition

	protected DateTime PrevDate = DateTime.MinValue;
	protected string ShortViewEventsGridNoEventsLastDayText = "";

//Forms Objects @1-074875CA
    protected ShortViewEventsGridDataProvider ShortViewEventsGridData;
    protected int ShortViewEventsGridCurrentRowNumber;
    protected FormSupportedOperations ShortViewEventsGridOperations;
    protected ShortViewEventsNavigatorDataProvider ShortViewEventsNavigatorData;
    protected NameValueCollection ShortViewEventsNavigatorErrors=new NameValueCollection();
    protected bool ShortViewEventsNavigatorIsSubmitted = false;
    protected FormSupportedOperations ShortViewEventsNavigatorOperations;
    protected System.Resources.ResourceManager rm;
    protected string weekContentMeta;
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

//Grid ShortViewEventsGrid Bind @144-4F8A28A8
    protected void ShortViewEventsGridBind()
    {
        if (!ShortViewEventsGridOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"ShortViewEventsGrid",typeof(ShortViewEventsGridDataProvider.SortFields), 0, -1);
        }
//End Grid ShortViewEventsGrid Bind

//Grid Form ShortViewEventsGrid BeforeShow tail @144-24B296C7
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
        System.Web.UI.WebControls.Literal ShortViewEventsGridweek_date_begin = (System.Web.UI.WebControls.Literal)ShortViewEventsGridRepeater.Controls[0].FindControl("ShortViewEventsGridweek_date_begin");
        System.Web.UI.WebControls.Literal ShortViewEventsGridweek_date_end = (System.Web.UI.WebControls.Literal)ShortViewEventsGridRepeater.Controls[0].FindControl("ShortViewEventsGridweek_date_end");
        System.Web.UI.WebControls.Literal ShortViewEventsGridNoEventsLastDay = (System.Web.UI.WebControls.Literal)ShortViewEventsGridRepeater.Controls[FooterIndex].FindControl("ShortViewEventsGridNoEventsLastDay");


        ShortViewEventsGridweek_date_begin.Text=Server.HtmlEncode(item.week_date_begin.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        ShortViewEventsGridweek_date_end.Text=Server.HtmlEncode(item.week_date_end.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        ShortViewEventsGridNoEventsLastDay.Text=item.NoEventsLastDay.GetFormattedValue();
//End Grid Form ShortViewEventsGrid BeforeShow tail

//Label NoEventsLastDay Event BeforeShow. Action Custom Code @200-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Label NoEventsLastDay Event BeforeShow. Action Custom Code

//Grid ShortViewEventsGrid Event BeforeShow. Action Custom Code @177-2A29BDB7
    // -------------------------
		DateTime SelDay = CommonFunctions.CCParseDate(CommonFunctions.CCGetFromGet("day",CommonFunctions.CCFormatDate(DateTime.Now, "")), "");
		int FirstWeekDay = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
		DateTime FirstDay = SelDay.AddDays((FirstWeekDay-7-(int)SelDay.DayOfWeek) % 7);
		DateTime LastDay = FirstDay.AddDays(6);

		item.week_date_begin.SetValue(FirstDay);
		item.week_date_end.SetValue(LastDay);
		ShortViewEventsGridweek_date_begin.Text = item.week_date_begin.GetFormattedValue();
		ShortViewEventsGridweek_date_end.Text = item.week_date_end.GetFormattedValue();

		if (FooterIndex == 1) 
		{
			ShortViewEventsGridNoEventsLastDay.Text = GetFormatLink(FirstDay, LastDay.AddDays(1), CommonFunctions.AddAllowed());
		} 
		else 
		{
			ShortViewEventsGridNoEventsLastDay.Text = ShortViewEventsGridNoEventsLastDayText;
		}
    // -------------------------
//End Grid ShortViewEventsGrid Event BeforeShow. Action Custom Code

//Grid ShortViewEventsGrid Bind tail @144-FCB6E20C
    }
//End Grid ShortViewEventsGrid Bind tail

//Grid ShortViewEventsGrid Table Parameters @144-FFD3060D
    protected void ShortViewEventsGridParameters()
    {
        try{
            ShortViewEventsGridData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            ShortViewEventsGridData.Urlevents_category_id = IntegerParameter.GetParam("events_category_id", ParameterSourceType.URL, "", null, false);
            ShortViewEventsGridData.Sescategory = IntegerParameter.GetParam("category", ParameterSourceType.Session, "", null, false);
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

	protected string GetFormatLink(DateTime FirstDay, DateTime LastDay, bool AddAllowed)
	{
		string str = "";
		while (FirstDay < LastDay)
		{
			str +=  "<tr class=\"GroupCaption\"><th colspan=\"2\"><a href=\"day.aspx?day="+
				CommonFunctions.CCFormatDate(FirstDay, "yyyy-MM-dd") + "\">"+
				CommonFunctions.CCFormatDate(FirstDay, "d") + "</a>";
			if (CommonFunctions.AddAllowed()) 
			{
				str += " &nbsp;&nbsp;&nbsp;&nbsp;<a href=\"events.aspx?event_date=" +
					Server.UrlEncode(CommonFunctions.CCFormatDate(FirstDay, "d"))+
					"&ret_link=" + Server.UrlEncode(GetShortViewEventsNavigatorRedirectUrl("", "")) +
					"\"><img border=\"0\" src=\"images/icon-add-big.gif\"></a>";
			}
			str += "</th></tr><tr class=\"Row\"><td width=\"10%\">&nbsp;</td><td>&nbsp;</td></tr>";
			FirstDay = FirstDay.AddDays(1);
		}
		return str;
	}

//Grid ShortViewEventsGrid ItemDataBound event @144-E5A9EF86
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
            System.Web.UI.WebControls.PlaceHolder ShortViewEventsGridEventDayPanel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("ShortViewEventsGridEventDayPanel"));
            System.Web.UI.WebControls.Literal ShortViewEventsGridNoEventsDay = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridNoEventsDay"));
            System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridevent_date = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridevent_date"));
            System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridadd_event = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridadd_event"));
            System.Web.UI.WebControls.Literal ShortViewEventsGridevent_time = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridevent_time"));
            System.Web.UI.WebControls.Literal ShortViewEventsGridevent_time_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridevent_time_end"));
            System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridevent_title = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridevent_title"));
            System.Web.UI.WebControls.Image ShortViewEventsGridcategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("ShortViewEventsGridcategory_image"));
            System.Web.UI.WebControls.Literal ShortViewEventsGridcategory_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridcategory_name"));
            DataItem.event_dateHref = "day.aspx";
            ShortViewEventsGridevent_date.HRef = DataItem.event_dateHref + DataItem.event_dateHrefParameters.ToString("GET","", ViewState);
            DataItem.add_eventHref = "events.aspx";
            ShortViewEventsGridadd_event.HRef = DataItem.add_eventHref + DataItem.add_eventHrefParameters.ToString("None","", ViewState);
            DataItem.event_titleHref = "event_view.aspx";
            ShortViewEventsGridevent_title.HRef = DataItem.event_titleHref + DataItem.event_titleHrefParameters.ToString("None","", ViewState);
            ShortViewEventsGridcategory_image.ImageUrl += DataItem.category_image.GetFormattedValue();
        }
//End Grid ShortViewEventsGrid ItemDataBound event

//ShortViewEventsGrid control Before Show @144-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End ShortViewEventsGrid control Before Show

//Get Control @167-F573FEA1
            System.Web.UI.WebControls.Literal ShortViewEventsGridevent_time_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridevent_time_end"));
//End Get Control

//Label event_time_end Event BeforeShow. Action Custom Code @199-2A29BDB7
    // -------------------------
	if (ShortViewEventsGridevent_time_end.Text.Length > 0) {
		ShortViewEventsGridevent_time_end.Text = "-  " + ShortViewEventsGridevent_time_end.Text;
		ShortViewEventsGridevent_time_end.Visible = true;
	} else
		ShortViewEventsGridevent_time_end.Visible = false;
    // -------------------------
//End Label event_time_end Event BeforeShow. Action Custom Code

//Get Control @164-F1DEBB7B
            System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridevent_title = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridevent_title"));
//End Get Control

//Link event_title Event BeforeShow. Action Custom Code @196-2A29BDB7
    // -------------------------
			if (CommonFunctions.str_calendar_config("popup_events") == "1")  {
				string parameters = CommonFunctions.CCGetFromGet("day", "");
				parameters = CommonFunctions.CCAddParam(ShortViewEventsGridevent_title.HRef, "ret_link", Server.UrlEncode("week.aspx" + (parameters.Length > 0? "?day=" + parameters : "")));
				int idx = parameters.IndexOf('?');
				parameters = idx!=-1?parameters.Substring(idx+1,parameters.Length-idx-1):parameters;
				ShortViewEventsGridevent_title.HRef = "javascript:openWin('event_view_popup.aspx?" + parameters + "')";
			}
    // -------------------------
//End Link event_title Event BeforeShow. Action Custom Code

//Get Control @162-70A30467
            System.Web.UI.WebControls.Image ShortViewEventsGridcategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("ShortViewEventsGridcategory_image"));
//End Get Control

//Image category_image Event BeforeShow. Action Custom Code @197-2A29BDB7
    // -------------------------
				if (item.category_image.GetFormattedValue().Length > 0) {
					ShortViewEventsGridcategory_image.Visible = true;
				} else {
					ShortViewEventsGridcategory_image.Visible = false;
		            System.Web.UI.WebControls.Literal ShortViewEventsGridcategory_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridcategory_name"));
					if (ShortViewEventsGridcategory_name.Text.Length > 0) {
						ShortViewEventsGridcategory_name.Text = "(" + ShortViewEventsGridcategory_name.Text + ")";
						ShortViewEventsGridcategory_name.Visible = true;
					} else {
						ShortViewEventsGridcategory_name.Visible = false;
					}
				}
    // -------------------------
//End Image category_image Event BeforeShow. Action Custom Code

//ShortViewEventsGrid control Before Show tail @144-FCB6E20C
        }
//End ShortViewEventsGrid control Before Show tail

//Grid ShortViewEventsGrid BeforeShowRow event @144-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid ShortViewEventsGrid BeforeShowRow event

//Grid ShortViewEventsGrid Event BeforeShowRow. Action Custom Code @178-2A29BDB7
    // -------------------------
			DateTime FirstDay, LastDay;

			System.Web.UI.WebControls.Literal ShortViewEventsGridNoEventsDay = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("ShortViewEventsGridNoEventsDay"));
			//System.Web.UI.WebControls.Literal ShortViewEventsGridNoEventsLastDay = (System.Web.UI.WebControls.Literal)ShortViewEventsGridRepeater.Controls[ShortViewEventsGridRepeater.Controls.Count - 1].FindControl("ShortViewEventsGridNoEventsLastDay");
			System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridevent_date = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridevent_date"));
			System.Web.UI.HtmlControls.HtmlAnchor ShortViewEventsGridadd_event = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("ShortViewEventsGridadd_event"));
			System.Web.UI.WebControls.PlaceHolder ShortViewEventsGridEventDayPanel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("ShortViewEventsGridEventDayPanel"));
			if (PrevDate != DateTime.MinValue && PrevDate == (DateTime)item.event_date.Value) 
			{
				ShortViewEventsGridEventDayPanel.Visible = false;
			} 
			else 
			{
				DataItem.event_dateHrefParameters["day"] = DataItem.event_date.GetFormattedValue("yyyy-MM-dd");
				ShortViewEventsGridevent_date.HRef = DataItem.event_dateHref + DataItem.event_dateHrefParameters.ToString("GET","", ViewState);

				int FirstWeekDay = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
				if (PrevDate == DateTime.MinValue) 
				{
					PrevDate = (DateTime)item.event_date.Value;
					FirstDay = PrevDate.AddDays((FirstWeekDay-7-(int)PrevDate.DayOfWeek) % 7);
					LastDay = FirstDay.AddDays(7);
				} 
				else 
				{
					LastDay = PrevDate.AddDays(((FirstWeekDay-7-(int)PrevDate.DayOfWeek) % 7)+7);
					FirstDay = PrevDate.AddDays(1);
					PrevDate = (DateTime)item.event_date.Value;
				}

				bool add_all = CommonFunctions.AddAllowed();
				if (add_all) 
				{
					ShortViewEventsGridadd_event.Visible = true;
					ShortViewEventsGridadd_event.HRef = CommonFunctions.CCAddParam(ShortViewEventsGridadd_event.HRef, "event_date", CommonFunctions.CCFormatDate(PrevDate, "d"));
					ShortViewEventsGridadd_event.HRef = CommonFunctions.CCAddParam(ShortViewEventsGridadd_event.HRef, "ret_link", GetShortViewEventsNavigatorRedirectUrl("", ""));
				} 
				else 
				{
					ShortViewEventsGridadd_event.Visible = false;
				}

				ShortViewEventsGridNoEventsDay.Text = GetFormatLink(FirstDay, PrevDate, add_all);
				ShortViewEventsGridNoEventsLastDayText = GetFormatLink(PrevDate.AddDays(1), LastDay, add_all);

				ShortViewEventsGridEventDayPanel.Visible = true;
			}
    // -------------------------
//End Grid ShortViewEventsGrid Event BeforeShowRow. Action Custom Code

//Grid ShortViewEventsGrid BeforeShowRow event tail @144-FCB6E20C
        }
//End Grid ShortViewEventsGrid BeforeShowRow event tail

//Grid ShortViewEventsGrid ItemDataBound event tail @144-10DF14EC
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

//Grid ShortViewEventsGrid ItemCommand event @144-E564D1EC
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

//Record Form ShortViewEventsNavigator Parameters @102-AE94DFF5
    protected void ShortViewEventsNavigatorParameters()
    {
        ShortViewEventsNavigatorItem item=ShortViewEventsNavigatorItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            ShortViewEventsNavigatorErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form ShortViewEventsNavigator Parameters

//Record Form ShortViewEventsNavigator Show method @102-23AF8ABB
    protected void ShortViewEventsNavigatorShow()
    {
        if(ShortViewEventsNavigatorOperations.None)
        {
            ShortViewEventsNavigatorHolder.Visible=false;
            return;
        }
        ShortViewEventsNavigatorItem item=ShortViewEventsNavigatorItem.CreateFromHttpRequest();
        bool IsInsertMode=!ShortViewEventsNavigatorOperations.AllowRead;
        item.prev_week_linkHref = "week.aspx";
        item.next_week_linkHref = "week.aspx";
        item.YearIconHref = "year.aspx";
        item.MonthIconHref = "index.aspx";
        item.WeekIconHref = "week.aspx";
        ShortViewEventsNavigatorErrors.Add(item.errors);
//End Record Form ShortViewEventsNavigator Show method

//Record Form ShortViewEventsNavigator BeforeShow tail @102-445248B5
        ShortViewEventsNavigatorParameters();
        ShortViewEventsNavigatorData.FillItem(item,ref IsInsertMode);
        ShortViewEventsNavigatorHolder.DataBind();
        ShortViewEventsNavigatorprev_week_link.InnerHtml += item.prev_week_link.GetFormattedValue();
        ShortViewEventsNavigatorprev_week_link.HRef = item.prev_week_linkHref+item.prev_week_linkHrefParameters.ToString("None","", ViewState);
        item.weekItems.SetSelection(item.week.GetFormattedValue());
        if(item.weekItems.GetSelectedItem() != null)
            ShortViewEventsNavigatorweek.SelectedIndex = -1;
        item.weekItems.CopyTo(ShortViewEventsNavigatorweek.Items);
        ShortViewEventsNavigatornext_week_link.InnerHtml += item.next_week_link.GetFormattedValue();
        ShortViewEventsNavigatornext_week_link.HRef = item.next_week_linkHref+item.next_week_linkHrefParameters.ToString("None","", ViewState);
        item.monthItems.SetSelection(item.month.GetFormattedValue());
        if(item.monthItems.GetSelectedItem() != null)
            ShortViewEventsNavigatormonth.SelectedIndex = -1;
        item.monthItems.CopyTo(ShortViewEventsNavigatormonth.Items);
        ShortViewEventsNavigatorYearIcon.InnerHtml += item.YearIcon.GetFormattedValue();
        ShortViewEventsNavigatorYearIcon.HRef = item.YearIconHref+item.YearIconHrefParameters.ToString("None","", ViewState);
        ShortViewEventsNavigatorMonthIcon.InnerHtml += item.MonthIcon.GetFormattedValue();
        ShortViewEventsNavigatorMonthIcon.HRef = item.MonthIconHref+item.MonthIconHrefParameters.ToString("None","", ViewState);
        ShortViewEventsNavigatorWeekIcon.InnerHtml += item.WeekIcon.GetFormattedValue();
        ShortViewEventsNavigatorWeekIcon.HRef = item.WeekIconHref+item.WeekIconHrefParameters.ToString("GET","", ViewState);
//End Record Form ShortViewEventsNavigator BeforeShow tail

//Record ShortViewEventsNavigator Event BeforeShow. Action Custom Code @105-2A29BDB7
    // -------------------------
		DateField dayParam = new DateField("yyyy-MM-dd");
		dayParam.SetValue(Request.QueryString["day"] != null?(object)Request.QueryString["day"]:(object)DateTime.Now, "yyyy-MM-dd");

		DateTime SelectDay = (DateTime)dayParam.Value;
		ShortViewEventsNavigatorprev_week_link.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorprev_week_link.HRef, "day", CommonFunctions.CCFormatDate(SelectDay.AddDays(-7), "yyyy-MM-dd"));
		ShortViewEventsNavigatornext_week_link.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatornext_week_link.HRef, "day", CommonFunctions.CCFormatDate(SelectDay.AddDays(7), "yyyy-MM-dd"));

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

		for (i=0;i<12;i++) 
		{
			IndexArr[i] = SelectDay.Year.ToString() + "-" + (i+1).ToString().PadLeft(2,'0');
		}
		for (int j=0; j<i; j++) ShortViewEventsNavigatormonth.Items.Add(new ListItem(CommonFunctions.CCFormatDate(new DateTime(SelectDay.Year,j+1,1),"MMMM"),IndexArr[j]));
		ShortViewEventsNavigatormonth.Value = SelectDay.Year.ToString() + "-" + SelectDay.Month.ToString().PadLeft(2,'0');

		ShortViewEventsNavigatorWeekIcon.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorWeekIcon.HRef, "day", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM-dd"));
		ShortViewEventsNavigatorMonthIcon.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorMonthIcon.HRef, "cal_monthDate", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM"));
		ShortViewEventsNavigatorYearIcon.HRef = CommonFunctions.CCAddParam(ShortViewEventsNavigatorYearIcon.HRef, "year_eventsDate", CommonFunctions.CCFormatDate(SelectDay, "yyyy-MM"));
    // -------------------------
//End Record ShortViewEventsNavigator Event BeforeShow. Action Custom Code

//Record Form ShortViewEventsNavigator Show method tail @102-7A2A44F4
        if(ShortViewEventsNavigatorErrors.Count>0)
            ShortViewEventsNavigatorShowErrors();
    }
//End Record Form ShortViewEventsNavigator Show method tail

//Record Form ShortViewEventsNavigator LoadItemFromRequest method @102-9C4A2FFA
    protected void ShortViewEventsNavigatorLoadItemFromRequest(ShortViewEventsNavigatorItem item, bool EnableValidation)
    {
        item.week.SetValue(ShortViewEventsNavigatorweek.Value);
        item.weekItems.CopyFrom(ShortViewEventsNavigatorweek.Items);
        item.month.SetValue(ShortViewEventsNavigatormonth.Value);
        item.monthItems.CopyFrom(ShortViewEventsNavigatormonth.Items);
        if(EnableValidation)
            item.Validate(ShortViewEventsNavigatorData);
        ShortViewEventsNavigatorErrors.Add(item.errors);
    }
//End Record Form ShortViewEventsNavigator LoadItemFromRequest method

//Record Form ShortViewEventsNavigator GetRedirectUrl method @102-B53AE254
    protected string GetShortViewEventsNavigatorRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form ShortViewEventsNavigator GetRedirectUrl method

//Record Form ShortViewEventsNavigator ShowErrors method @102-3ED36F17
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
        ShortViewEventsNavigatorErrorLabel.Text = DefaultMessage;
    }
//End Record Form ShortViewEventsNavigator ShowErrors method

//Record Form ShortViewEventsNavigator Insert Operation @102-EBAF35DF
    protected void ShortViewEventsNavigator_Insert(object sender, System.EventArgs e)
    {
        ShortViewEventsNavigatorIsSubmitted = true;
        bool ErrorFlag = false;
        ShortViewEventsNavigatorItem item=new ShortViewEventsNavigatorItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ShortViewEventsNavigator Insert Operation

//Record Form ShortViewEventsNavigator BeforeInsert tail @102-CD4F207E
    ShortViewEventsNavigatorParameters();
    ShortViewEventsNavigatorLoadItemFromRequest(item, EnableValidation);
//End Record Form ShortViewEventsNavigator BeforeInsert tail

//Record Form ShortViewEventsNavigator AfterInsert tail  @102-2E701FCF
        ErrorFlag=(ShortViewEventsNavigatorErrors.Count>0);
        if(ErrorFlag)
            ShortViewEventsNavigatorShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form ShortViewEventsNavigator AfterInsert tail 

//Record Form ShortViewEventsNavigator Update Operation @102-AD0B02AB
    protected void ShortViewEventsNavigator_Update(object sender, System.EventArgs e)
    {
        ShortViewEventsNavigatorItem item=new ShortViewEventsNavigatorItem();
        item.IsNew = false;
        ShortViewEventsNavigatorIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ShortViewEventsNavigator Update Operation

//Record Form ShortViewEventsNavigator Before Update tail @102-CD4F207E
        ShortViewEventsNavigatorParameters();
        ShortViewEventsNavigatorLoadItemFromRequest(item, EnableValidation);
//End Record Form ShortViewEventsNavigator Before Update tail

//Record Form ShortViewEventsNavigator Update Operation tail @102-2E701FCF
        ErrorFlag=(ShortViewEventsNavigatorErrors.Count>0);
        if(ErrorFlag)
            ShortViewEventsNavigatorShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form ShortViewEventsNavigator Update Operation tail

//Record Form ShortViewEventsNavigator Delete Operation @102-99E6B4A8
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

//Record Form BeforeDelete tail @102-CD4F207E
        ShortViewEventsNavigatorParameters();
        ShortViewEventsNavigatorLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @102-C9B4B91F
        if(ErrorFlag)
            ShortViewEventsNavigatorShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form ShortViewEventsNavigator Cancel Operation @102-3ABEE0F9
    protected void ShortViewEventsNavigator_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        ShortViewEventsNavigatorItem item=new ShortViewEventsNavigatorItem();
        ShortViewEventsNavigatorIsSubmitted = true;
        string RedirectUrl = "";
        ShortViewEventsNavigatorLoadItemFromRequest(item, true);
//End Record Form ShortViewEventsNavigator Cancel Operation

//Button GoWeek OnClick. @104-BACBF551
    if(((Control)sender).ID == "ShortViewEventsNavigatorGoWeek")
    {
        RedirectUrl  = GetShortViewEventsNavigatorRedirectUrl("", "");
//End Button GoWeek OnClick.

//Button GoWeek Event OnClick. Action Custom Code @192-2A29BDB7
    // -------------------------
	RedirectUrl = "week.aspx?day=" + ShortViewEventsNavigatorweek.Value;
    // -------------------------
//End Button GoWeek Event OnClick. Action Custom Code

//Button GoWeek OnClick tail. @104-FCB6E20C
    }
//End Button GoWeek OnClick tail.

//Button GoMonth OnClick. @190-FE308ECF
    if(((Control)sender).ID == "ShortViewEventsNavigatorGoMonth")
    {
        RedirectUrl  = GetShortViewEventsNavigatorRedirectUrl("", "");
//End Button GoMonth OnClick.

//Button GoMonth Event OnClick. Action Custom Code @191-2A29BDB7
    // -------------------------
	RedirectUrl = "index.aspx?cal_monthDate=" + ShortViewEventsNavigatormonth.Value;
    // -------------------------
//End Button GoMonth Event OnClick. Action Custom Code

//Button GoMonth OnClick tail. @190-FCB6E20C
    }
//End Button GoMonth OnClick tail.

//Record Form ShortViewEventsNavigator Cancel Operation tail @102-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form ShortViewEventsNavigator Cancel Operation tail

//OnInit Event @1-B5B5C433
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        weekContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
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

//Page week Event AfterInitialize. Action Custom Code @72-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Page week Event AfterInitialize. Action Custom Code

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

