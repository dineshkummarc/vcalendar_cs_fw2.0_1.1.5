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

namespace calendar.search{ //Namespace @1-704E29A1

//Forms Definition @1-21FE0092
public partial class searchPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-C8901195
    protected events_groupsSearchDataProvider events_groupsSearchData;
    protected NameValueCollection events_groupsSearchErrors=new NameValueCollection();
    protected bool events_groupsSearchIsSubmitted = false;
    protected FormSupportedOperations events_groupsSearchOperations;
    protected string events_groupsSearchDatePicker_s_event_date_fromName;
    protected string events_groupsSearchDatePicker_s_event_date_fromDateControl;
    protected string events_groupsSearchDatePicker_s_event_date_toName;
    protected string events_groupsSearchDatePicker_s_event_date_toDateControl;
    protected events_groupsDataProvider events_groupsData;
    protected int events_groupsCurrentRowNumber;
    protected FormSupportedOperations events_groupsOperations;
    protected System.Resources.ResourceManager rm;
    protected string searchContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-41713855
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            events_groupsSearchShow();
            events_groupsBind();
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

//Record Form events_groupsSearch Parameters @9-72DFC0B6
    protected void events_groupsSearchParameters()
    {
        events_groupsSearchItem item=events_groupsSearchItem.CreateFromHttpRequest();
        try{
            events_groupsSearchData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
        }catch(Exception e){
            events_groupsSearchErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form events_groupsSearch Parameters

//Record Form events_groupsSearch Show method @9-6693CFA0
    protected void events_groupsSearchShow()
    {
        if(events_groupsSearchOperations.None)
        {
            events_groupsSearchHolder.Visible=false;
            return;
        }
        events_groupsSearchItem item=events_groupsSearchItem.CreateFromHttpRequest();
        bool IsInsertMode=!events_groupsSearchOperations.AllowRead;
        events_groupsSearchErrors.Add(item.errors);
//End Record Form events_groupsSearch Show method

//Record Form events_groupsSearch BeforeShow tail @9-EF538901
        events_groupsSearchParameters();
        events_groupsSearchData.FillItem(item,ref IsInsertMode);
        events_groupsSearchHolder.DataBind();
        events_groupsSearchs_keyword.Text=item.s_keyword.GetFormattedValue();
        item.s_categoryItems.SetSelection(item.s_category.GetFormattedValue());
        events_groupsSearchs_category.Items.Add(new ListItem(Resources.strings.cal_all_categories,""));
        events_groupsSearchs_category.Items[0].Selected = true;
        if(item.s_categoryItems.GetSelectedItem() != null)
            events_groupsSearchs_category.SelectedIndex = -1;
        item.s_categoryItems.CopyTo(events_groupsSearchs_category.Items);
        events_groupsSearchs_event_date_from.Text=item.s_event_date_from.GetFormattedValue();
        events_groupsSearchDatePicker_s_event_date_fromName = "events_groupsSearchDatePicker_s_event_date_from";
        events_groupsSearchDatePicker_s_event_date_fromDateControl = events_groupsSearchs_event_date_from.ClientID;
        events_groupsSearchDatePicker_s_event_date_from.DataBind();
        events_groupsSearchs_event_date_to.Text=item.s_event_date_to.GetFormattedValue();
        events_groupsSearchDatePicker_s_event_date_toName = "events_groupsSearchDatePicker_s_event_date_to";
        events_groupsSearchDatePicker_s_event_date_toDateControl = events_groupsSearchs_event_date_to.ClientID;
        events_groupsSearchDatePicker_s_event_date_to.DataBind();
//End Record Form events_groupsSearch BeforeShow tail

//ListBox s_category Event BeforeShow. Action Custom Code @58-2A29BDB7
    // -------------------------
		if (CommonFunctions.CCGetFromGet("s_category", "-1") == "-1") 
			events_groupsSearchs_category.Value = (string)Session["category"];
    // -------------------------
//End ListBox s_category Event BeforeShow. Action Custom Code

//Record Form events_groupsSearch Show method tail @9-4C40553D
        if(events_groupsSearchErrors.Count>0)
            events_groupsSearchShowErrors();
    }
//End Record Form events_groupsSearch Show method tail

//Record Form events_groupsSearch LoadItemFromRequest method @9-F3E48E41
    protected void events_groupsSearchLoadItemFromRequest(events_groupsSearchItem item, bool EnableValidation)
    {
        item.s_keyword.SetValue(events_groupsSearchs_keyword.Text);
        item.s_category.SetValue(events_groupsSearchs_category.Value);
        item.s_categoryItems.CopyFrom(events_groupsSearchs_category.Items);
        try{
        item.s_event_date_from.SetValue(events_groupsSearchs_event_date_from.Text);
        }catch(ArgumentException){
            events_groupsSearchErrors.Add("s_event_date_from",String.Format(Resources.strings.CCS_IncorrectFormat,Resources.strings.event_date + " " + Resources.strings.from,@"ShortDate"));}
        try{
        item.s_event_date_to.SetValue(events_groupsSearchs_event_date_to.Text);
        }catch(ArgumentException){
            events_groupsSearchErrors.Add("s_event_date_to",String.Format(Resources.strings.CCS_IncorrectFormat,Resources.strings.event_date + " " + Resources.strings.to,@"ShortDate"));}
        if(EnableValidation)
            item.Validate(events_groupsSearchData);
        events_groupsSearchErrors.Add(item.errors);
    }
//End Record Form events_groupsSearch LoadItemFromRequest method

//Record Form events_groupsSearch GetRedirectUrl method @9-EED9DA62
    protected string Getevents_groupsSearchRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "search.aspx";
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form events_groupsSearch GetRedirectUrl method

//Record Form events_groupsSearch ShowErrors method @9-26F0FCE0
    protected void events_groupsSearchShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<events_groupsSearchErrors.Count;i++)
        switch(events_groupsSearchErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=events_groupsSearchErrors[i];
                break;
        }
        events_groupsSearchError.Visible = true;
        events_groupsSearchErrorLabel.Text = DefaultMessage;
    }
//End Record Form events_groupsSearch ShowErrors method

//Record Form events_groupsSearch Insert Operation @9-464C5EDF
    protected void events_groupsSearch_Insert(object sender, System.EventArgs e)
    {
        events_groupsSearchIsSubmitted = true;
        bool ErrorFlag = false;
        events_groupsSearchItem item=new events_groupsSearchItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form events_groupsSearch Insert Operation

//Record Form events_groupsSearch BeforeInsert tail @9-29CEDC15
    events_groupsSearchParameters();
    events_groupsSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form events_groupsSearch BeforeInsert tail

//Record Form events_groupsSearch AfterInsert tail  @9-5C5E417C
        ErrorFlag=(events_groupsSearchErrors.Count>0);
        if(ErrorFlag)
            events_groupsSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form events_groupsSearch AfterInsert tail 

//Record Form events_groupsSearch Update Operation @9-3FCB4859
    protected void events_groupsSearch_Update(object sender, System.EventArgs e)
    {
        events_groupsSearchItem item=new events_groupsSearchItem();
        item.IsNew = false;
        events_groupsSearchIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form events_groupsSearch Update Operation

//Record Form events_groupsSearch Before Update tail @9-29CEDC15
        events_groupsSearchParameters();
        events_groupsSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form events_groupsSearch Before Update tail

//Record Form events_groupsSearch Update Operation tail @9-5C5E417C
        ErrorFlag=(events_groupsSearchErrors.Count>0);
        if(ErrorFlag)
            events_groupsSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form events_groupsSearch Update Operation tail

//Record Form events_groupsSearch Delete Operation @9-C8418802
    protected void events_groupsSearch_Delete(object sender,System.EventArgs e)
    {
        events_groupsSearchIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        events_groupsSearchItem item=new events_groupsSearchItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form events_groupsSearch Delete Operation

//Record Form BeforeDelete tail @9-29CEDC15
        events_groupsSearchParameters();
        events_groupsSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @9-5D1E70B0
        if(ErrorFlag)
            events_groupsSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form events_groupsSearch Cancel Operation @9-BEE80823
    protected void events_groupsSearch_Cancel(object sender,System.EventArgs e)
    {
        events_groupsSearchItem item=new events_groupsSearchItem();
        events_groupsSearchIsSubmitted = true;
        string RedirectUrl = "";
        events_groupsSearchLoadItemFromRequest(item, true);
//End Record Form events_groupsSearch Cancel Operation

//Record Form events_groupsSearch Cancel Operation tail @9-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form events_groupsSearch Cancel Operation tail

//Record Form events_groupsSearch Search Operation @9-B128EB3E
    protected void events_groupsSearch_Search(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        events_groupsSearchIsSubmitted = true;
        bool ErrorFlag=false;
        events_groupsSearchItem item=new events_groupsSearchItem();
        events_groupsSearchLoadItemFromRequest(item, true);
        ErrorFlag=(events_groupsSearchErrors.Count>0);
        string RedirectUrl = "";
//End Record Form events_groupsSearch Search Operation

//Button Button_DoSearch OnClick. @10-33F6012A
        if(((Control)sender).ID == "events_groupsSearchButton_DoSearch")
        {
            RedirectUrl = Getevents_groupsSearchRedirectUrl("", "s_keyword;s_category;s_event_date_from;s_event_date_to");
//End Button Button_DoSearch OnClick.

//Button Button_DoSearch OnClick tail. @10-FCB6E20C
        }
//End Button Button_DoSearch OnClick tail.

//Record Form events_groupsSearch Search Operation tail @9-0EEBE0C0
        if(ErrorFlag)
            events_groupsSearchShowErrors();
        else{
            string Params="";
            Params+=events_groupsSearchs_keyword.Text!=""?("s_keyword="+Server.UrlEncode(events_groupsSearchs_keyword.Text)+"&"):"";
            foreach(ListItem li in events_groupsSearchs_category.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "s_category="+Server.UrlEncode(li.Value)+"&";
            Params+=events_groupsSearchs_event_date_from.Text!=""?("s_event_date_from="+Server.UrlEncode(events_groupsSearchs_event_date_from.Text)+"&"):"";
            Params+=events_groupsSearchs_event_date_to.Text!=""?("s_event_date_to="+Server.UrlEncode(events_groupsSearchs_event_date_to.Text)+"&"):"";
            if(!RedirectUrl.EndsWith("?"))
                RedirectUrl += "&" + Params;
            else
                RedirectUrl += Params;
            RedirectUrl = RedirectUrl.TrimEnd(new Char[]{'&'});
            Response.Redirect(RedirectUrl);
        }
    }
//End Record Form events_groupsSearch Search Operation tail

//Grid events_groups Bind @69-B6965AFD
    protected void events_groupsBind()
    {
        if (!events_groupsOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"events_groups",typeof(events_groupsDataProvider.SortFields), 10, 100);
        }
//End Grid events_groups Bind

//Grid Form events_groups BeforeShow tail @69-112DB78C
        events_groupsParameters();
        events_groupsData.SortField = (events_groupsDataProvider.SortFields)ViewState["events_groupsSortField"];
        events_groupsData.SortDir = (SortDirections)ViewState["events_groupsSortDir"];
        events_groupsData.PageNumber = (int)ViewState["events_groupsPageNumber"];
        events_groupsData.RecordsPerPage = (int)ViewState["events_groupsPageSize"];
        events_groupsRepeater.DataSource = events_groupsData.GetResultSet(out PagesCount, events_groupsOperations);
        ViewState["events_groupsPagesCount"] = PagesCount;
        events_groupsRepeater.DataBind();
        FooterIndex = events_groupsRepeater.Controls.Count - 1;
        events_groupsRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        events_groupsItem item=new events_groupsItem();
        System.Web.UI.WebControls.Literal events_groupsevents_groups_TotalRecords = (System.Web.UI.WebControls.Literal)events_groupsRepeater.Controls[0].FindControl("events_groupsevents_groups_TotalRecords");


        events_groupsevents_groups_TotalRecords.Text=Server.HtmlEncode(item.events_groups_TotalRecords.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        calendar.Controls.Navigator NavigatorNavigator = (calendar.Controls.Navigator)events_groupsRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form events_groups BeforeShow tail

//Label events_groups_TotalRecords Event BeforeShow. Action Retrieve number of records @71-2DD3F696
            events_groupsevents_groups_TotalRecords.Text = events_groupsData.RecordCount.ToString();
//End Label events_groups_TotalRecords Event BeforeShow. Action Retrieve number of records

//Grid events_groups Event BeforeShow. Action Custom Code @78-2A29BDB7
    // -------------------------
	  	if (CommonFunctions.CCGetFromGet("s_keyword","") == "" &&
	  		CommonFunctions.CCGetFromGet("s_category","") == "" &&
	  		CommonFunctions.CCGetFromGet("s_event_date_from","") == "" &&
	  		CommonFunctions.CCGetFromGet("s_event_date_to","") == "")
	  			events_groupsRepeater.Visible = false;
  
	  	if (PagesCount < 2) NavigatorNavigator.Visible = false;
    // -------------------------
//End Grid events_groups Event BeforeShow. Action Custom Code

//Grid events_groups Bind tail @69-FCB6E20C
    }
//End Grid events_groups Bind tail

//Grid events_groups Table Parameters @69-1EF64B6B
    protected void events_groupsParameters()
    {
        try{
            events_groupsData.Urls_category = IntegerParameter.GetParam("s_category", ParameterSourceType.URL, "", null, false);
            events_groupsData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            events_groupsData.Urlcategories_langs_category_id = IntegerParameter.GetParam("categories_langs_category_id", ParameterSourceType.URL, "", null, false);
            events_groupsData.Urls_event_date_to = DateParameter.GetParam("s_event_date_to", ParameterSourceType.URL, Settings.DateFormat, null, false);
            events_groupsData.Urls_event_date_from = DateParameter.GetParam("s_event_date_from", ParameterSourceType.URL, Settings.DateFormat, null, false);
        }catch{
            ControlCollection ParentControls=events_groupsRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(events_groupsRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid events_groups: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid events_groups Table Parameters

//Grid events_groups ItemDataBound event @69-FB274015
    protected void events_groupsItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        events_groupsItem DataItem=(events_groupsItem)e.Item.DataItem;
        events_groupsItem[] FormDataSource=(events_groupsItem[])events_groupsRepeater.DataSource;
        events_groupsItem item = DataItem;
        int events_groupsDataRows = FormDataSource.Length;
        bool events_groupsIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        events_groupsCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal events_groupsevent_date = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("events_groupsevent_date"));
            System.Web.UI.WebControls.Literal events_groupsevent_time = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("events_groupsevent_time"));
            System.Web.UI.WebControls.Literal events_groupsevent_time_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("events_groupsevent_time_end"));
            System.Web.UI.WebControls.Literal events_groupscategory_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("events_groupscategory_name"));
            System.Web.UI.HtmlControls.HtmlAnchor events_groupsevent_title = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("events_groupsevent_title"));
            DataItem.event_titleHref = "event_view.aspx";
            events_groupsevent_title.HRef = DataItem.event_titleHref + DataItem.event_titleHrefParameters.ToString("None","", ViewState);
        }
//End Grid events_groups ItemDataBound event

//events_groups control Before Show @69-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End events_groups control Before Show

//Get Control @59-868E98A5
            System.Web.UI.WebControls.Literal events_groupsevent_time_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("events_groupsevent_time_end"));
//End Get Control

//Label event_time_end Event BeforeShow. Action Custom Code @60-2A29BDB7
    // -------------------------
			if (item.event_time_end.GetFormattedValue().Length > 0)
				events_groupsevent_time_end.Text = "-&nbsp;" + item.event_time_end.GetFormattedValue();
    // -------------------------
//End Label event_time_end Event BeforeShow. Action Custom Code

//Get Control @89-43CE4087
            System.Web.UI.HtmlControls.HtmlAnchor events_groupsevent_title = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("events_groupsevent_title"));
//End Get Control

//Link event_title Event BeforeShow. Action Custom Code @90-2A29BDB7
    // -------------------------
			if (CommonFunctions.str_calendar_config("popup_events") == "1") 
			{
				LinkParameterCollection p = new LinkParameterCollection();
				string parameters = CommonFunctions.CCAddParam(events_groupsevent_title.HRef, "ret_link", Server.UrlEncode(Request.Path + p.ToString("GET", "", ViewState)));
				int idx = parameters.IndexOf('?');
				parameters = idx!=-1?parameters.Substring(idx+1,parameters.Length-idx-1):parameters;
				events_groupsevent_title.HRef = "javascript:openWin('event_view_popup.aspx?" + parameters + "')";
			}
    // -------------------------
//End Link event_title Event BeforeShow. Action Custom Code

//events_groups control Before Show tail @69-FCB6E20C
        }
//End events_groups control Before Show tail

//Grid events_groups ItemDataBound event tail @69-F4064105
        if(events_groupsIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(events_groupsCurrentRowNumber, ListItemType.Item);
            events_groupsRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            events_groupsItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid events_groups ItemDataBound event tail

//Grid events_groups ItemCommand event @69-5088BB1B
    protected void events_groupsItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = events_groupsRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["events_groupsSortDir"]==SortDirections.Asc&&ViewState["events_groupsSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["events_groupsSortDir"]=SortDirections.Desc;
                else
                    ViewState["events_groupsSortDir"]=SortDirections.Asc;
            else
                ViewState["events_groupsSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["events_groupsSortField"]=Enum.Parse(typeof(events_groupsDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["events_groupsPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["events_groupsPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            events_groupsBind();
    }
//End Grid events_groups ItemCommand event

//OnInit Event @1-0C3F2D02
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        searchContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        events_groupsSearchData = new events_groupsSearchDataProvider();
        events_groupsSearchOperations = new FormSupportedOperations(false, true, true, true, true);
        events_groupsData = new events_groupsDataProvider();
        events_groupsOperations = new FormSupportedOperations(false, true, false, false, false);
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

