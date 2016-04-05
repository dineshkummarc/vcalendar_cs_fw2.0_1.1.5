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

namespace calendar.event_view_popup{ //Namespace @1-097EBF1E

//Forms Definition @1-0951E19B
public partial class event_view_popupPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-CE4C65CA
    protected eventGridDataProvider eventGridData;
    protected int eventGridCurrentRowNumber;
    protected FormSupportedOperations eventGridOperations;
    protected System.Resources.ResourceManager rm;
    protected string event_view_popupContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-F3462F18
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.close_linkHref = "javascript:self.close()";
            item.print_linkHref = "javascript:window.print()";
            PageData.FillItem(item);
            event_name.Text=Server.HtmlEncode(item.event_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
            close_link.InnerText=Resources.strings.close_window;
            close_link.HRef = item.close_linkHref+item.close_linkHrefParameters.ToString("None","", ViewState);
            print_link.InnerText=Resources.strings.print;
            print_link.HRef = item.print_linkHref+item.print_linkHrefParameters.ToString("None","", ViewState);
            eventGridBind();
    }
//End Page_Load Event BeforeIsPostBack

//Label event_name Event BeforeShow. Action Custom Code @208-2A29BDB7
    // -------------------------
	event_name.Text = (string)CommonFunctions.CCDLookUp("event_title", "events", "event_id = " + Settings.calendarDataAccessObject.ToSql(CommonFunctions.CCGetFromGet("event_id", "0"), FieldType.Integer), Settings.calendarDataAccessObject);
    // -------------------------
//End Label event_name Event BeforeShow. Action Custom Code

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

//Grid eventGrid Bind @5-885A3EEE
    protected void eventGridBind()
    {
        if (!eventGridOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"eventGrid",typeof(eventGridDataProvider.SortFields), 1, 100);
        }
//End Grid eventGrid Bind

//Grid Form eventGrid BeforeShow tail @5-5EFAA682
        eventGridParameters();
        eventGridData.SortField = (eventGridDataProvider.SortFields)ViewState["eventGridSortField"];
        eventGridData.SortDir = (SortDirections)ViewState["eventGridSortDir"];
        eventGridData.PageNumber = (int)ViewState["eventGridPageNumber"];
        eventGridData.RecordsPerPage = (int)ViewState["eventGridPageSize"];
        eventGridRepeater.DataSource = eventGridData.GetResultSet(out PagesCount, eventGridOperations);
        ViewState["eventGridPagesCount"] = PagesCount;
        eventGridRepeater.DataBind();
        FooterIndex = eventGridRepeater.Controls.Count - 1;
        eventGridRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        eventGridItem item=new eventGridItem();
        System.Web.UI.WebControls.PlaceHolder eventGridedit = (System.Web.UI.WebControls.PlaceHolder)eventGridRepeater.Controls[FooterIndex].FindControl("eventGridedit");
        System.Web.UI.HtmlControls.HtmlAnchor eventGridedit_event = (System.Web.UI.HtmlControls.HtmlAnchor)eventGridRepeater.Controls[FooterIndex].FindControl("eventGridedit_event");

        item.edit_eventHref = "events.aspx";

        eventGridedit_event.InnerText=Resources.strings.cal_edit_event;
        eventGridedit_event.HRef = "javascript:parent_redirect('" + item.edit_eventHref+item.edit_eventHrefParameters.ToString("GET","", ViewState) + "');";
//End Grid Form eventGrid BeforeShow tail

//Panel edit Event BeforeShow. Action Custom Code @43-2A29BDB7
    // -------------------------
	if (!CommonFunctions.EditAllowed(Convert.ToInt32(Request.QueryString["event_id"])))
		eventGridedit.Visible = false;
    // -------------------------
//End Panel edit Event BeforeShow. Action Custom Code


//Grid eventGrid Bind tail @5-FCB6E20C
    }
//End Grid eventGrid Bind tail

//Grid eventGrid Table Parameters @5-9D890E2C
    protected void eventGridParameters()
    {
        try{
            eventGridData.Urlevent_id = IntegerParameter.GetParam("event_id", ParameterSourceType.URL, "", null, false);
            eventGridData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            eventGridData.Urlevents_category_id = IntegerParameter.GetParam("events_category_id", ParameterSourceType.URL, "", null, false);
        }catch{
            ControlCollection ParentControls=eventGridRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(eventGridRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid eventGrid: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid eventGrid Table Parameters

//Grid eventGrid ItemDataBound event @5-C66C4088
    protected void eventGridItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        eventGridItem DataItem=(eventGridItem)e.Item.DataItem;
        eventGridItem[] FormDataSource=(eventGridItem[])eventGridRepeater.DataSource;
        eventGridItem item = DataItem;
        int eventGridDataRows = FormDataSource.Length;
        bool eventGridIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        eventGridCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal eventGridevent_title = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_title"));
            System.Web.UI.WebControls.Literal eventGridevent_date = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_date"));
            System.Web.UI.WebControls.Literal eventGridevent_time = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_time"));
            System.Web.UI.WebControls.Literal eventGridevent_time_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_time_end"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelCategory = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelCategory"));
            System.Web.UI.WebControls.Literal eventGridgroup_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridgroup_id"));
            System.Web.UI.WebControls.Literal eventGriduser_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGriduser_id"));
            System.Web.UI.WebControls.Literal eventGridevent_desc = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_desc"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelLocation = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelLocation"));
            System.Web.UI.WebControls.Literal eventGridLabelLocation = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelLocation"));
            System.Web.UI.WebControls.Literal eventGridevent_location = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_location"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelCost = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelCost"));
            System.Web.UI.WebControls.Literal eventGridLabelCost = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelCost"));
            System.Web.UI.WebControls.Literal eventGridevent_cost = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_cost"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelURL = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelURL"));
            System.Web.UI.WebControls.Literal eventGridLabelURL = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelURL"));
            System.Web.UI.HtmlControls.HtmlAnchor eventGridevent_url = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("eventGridevent_url"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelTextBox1 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelTextBox1"));
            System.Web.UI.WebControls.Literal eventGridLabelTextBox1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelTextBox1"));
            System.Web.UI.WebControls.Literal eventGridcustom_TextBox1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_TextBox1"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelTextBox2 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelTextBox2"));
            System.Web.UI.WebControls.Literal eventGridLabelTextBox2 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelTextBox2"));
            System.Web.UI.WebControls.Literal eventGridcustom_TextBox2 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_TextBox2"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelTextBox3 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelTextBox3"));
            System.Web.UI.WebControls.Literal eventGridLabelTextBox3 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelTextBox3"));
            System.Web.UI.WebControls.Literal eventGridcustom_TextBox3 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_TextBox3"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelTextArea1 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelTextArea1"));
            System.Web.UI.WebControls.Literal eventGridLabelTextArea1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelTextArea1"));
            System.Web.UI.WebControls.Literal eventGridcustom_TextArea1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_TextArea1"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelTextArea2 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelTextArea2"));
            System.Web.UI.WebControls.Literal eventGridLabelTextArea2 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelTextArea2"));
            System.Web.UI.WebControls.Literal eventGridcustom_TextArea2 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_TextArea2"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelTextArea3 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelTextArea3"));
            System.Web.UI.WebControls.Literal eventGridLabelTextArea3 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelTextArea3"));
            System.Web.UI.WebControls.Literal eventGridcustom_TextArea3 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_TextArea3"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelCheckBox1 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelCheckBox1"));
            System.Web.UI.WebControls.Literal eventGridLabelCheckBox1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelCheckBox1"));
            System.Web.UI.WebControls.Literal eventGridcustom_CheckBox1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_CheckBox1"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelCheckBox2 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelCheckBox2"));
            System.Web.UI.WebControls.Literal eventGridLabelCheckBox2 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelCheckBox2"));
            System.Web.UI.WebControls.Literal eventGridcustom_CheckBox2 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_CheckBox2"));
            System.Web.UI.WebControls.PlaceHolder eventGridPanelCheckBox3 = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelCheckBox3"));
            System.Web.UI.WebControls.Literal eventGridLabelCheckBox3 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridLabelCheckBox3"));
            System.Web.UI.WebControls.Literal eventGridcustom_CheckBox3 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridcustom_CheckBox3"));
            eventGridevent_url.HRef = DataItem.event_urlHref + DataItem.event_urlHrefParameters.ToString("None","", ViewState);
        }
//End Grid eventGrid ItemDataBound event

//eventGrid control Before Show @5-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End eventGrid control Before Show

//Get Control @48-269EB21C
            System.Web.UI.WebControls.Literal eventGridevent_location = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_location"));
//End Get Control

//Label event_location Event BeforeShow. Action Custom Code @211-2A29BDB7
    // -------------------------
    if (item.event_location.GetFormattedValue().Length == 0) {
            System.Web.UI.WebControls.PlaceHolder eventGridPanelLocation = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelLocation"));
			eventGridPanelLocation.Visible = false;
	}
    // -------------------------
//End Label event_location Event BeforeShow. Action Custom Code

//Get Control @49-1EF60DA4
            System.Web.UI.WebControls.Literal eventGridevent_cost = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_cost"));
//End Get Control

//Label event_cost Event BeforeShow. Action Custom Code @212-2A29BDB7
    // -------------------------
    if (item.event_cost.GetFormattedValue().Length == 0) {
            System.Web.UI.WebControls.PlaceHolder eventGridPanelCost = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelCost"));
			eventGridPanelCost.Visible = false;
	}
    // -------------------------
//End Label event_cost Event BeforeShow. Action Custom Code

//Get Control @52-FABDE88F
            System.Web.UI.HtmlControls.HtmlAnchor eventGridevent_url = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("eventGridevent_url"));
//End Get Control

//Link event_url Event BeforeShow. Action Custom Code @210-2A29BDB7
    // -------------------------
    if (item.event_url.GetFormattedValue().Length == 0) {
            System.Web.UI.WebControls.PlaceHolder eventGridPanelURL = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelURL"));
			eventGridPanelURL.Visible = false;
	}
    // -------------------------
//End Link event_url Event BeforeShow. Action Custom Code

//eventGrid control Before Show tail @5-FCB6E20C
        }
//End eventGrid control Before Show tail

//Grid eventGrid BeforeShowRow event @5-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid eventGrid BeforeShowRow event

//Grid eventGrid Event BeforeShowRow. Action Custom Code @39-2A29BDB7
    // -------------------------
	System.Web.UI.WebControls.Literal eventGridevent_time = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_time"));
	System.Web.UI.WebControls.Literal eventGridevent_time_end = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("eventGridevent_time_end"));

	if (eventGridevent_time.Text.Length == 0) {
		eventGridevent_time_end.Visible = false;
	} else {
		eventGridevent_time_end.Text = " - " + eventGridevent_time_end.Text;
		eventGridevent_time_end.Visible = true;
	}

	if (item.group_id.GetFormattedValue().Length == 0) {
		((System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("eventGridPanelCategory"))).Visible = false;
	}

	foreach(Control ctrl in eventGridRepeater.Controls)
		CommonFunctions.processCustomFields(ctrl, "eventGrid");
    // -------------------------
//End Grid eventGrid Event BeforeShowRow. Action Custom Code

//Grid eventGrid BeforeShowRow event tail @5-FCB6E20C
        }
//End Grid eventGrid BeforeShowRow event tail

//Grid eventGrid ItemDataBound event tail @5-5F4CB3C9
        if(eventGridIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(eventGridCurrentRowNumber, ListItemType.Item);
            eventGridRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            eventGridItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid eventGrid ItemDataBound event tail

//Grid eventGrid ItemCommand event @5-6B26667D
    protected void eventGridItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = eventGridRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["eventGridSortDir"]==SortDirections.Asc&&ViewState["eventGridSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["eventGridSortDir"]=SortDirections.Desc;
                else
                    ViewState["eventGridSortDir"]=SortDirections.Asc;
            else
                ViewState["eventGridSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["eventGridSortField"]=Enum.Parse(typeof(eventGridDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["eventGridPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["eventGridPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            eventGridBind();
    }
//End Grid eventGrid ItemCommand event

//OnInit Event @1-A9D4BDFB
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        event_view_popupContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        eventGridData = new eventGridDataProvider();
        eventGridOperations = new FormSupportedOperations(false, true, false, false, false);
//End OnInit Event

//Page event_view_popup Event AfterInitialize. Action Custom Code @179-2A29BDB7
    // -------------------------
			if (!CommonFunctions.ReadAllowed(Convert.ToInt32(CommonFunctions.CCGetFromGet("event_id","0")))) 
			{
				System.Web.HttpContext.Current.Response.Write("<script language=\"javascript\">self.close()</script>");
				Response.Redirect("index.aspx");
			}
    // -------------------------
//End Page event_view_popup Event AfterInitialize. Action Custom Code

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

