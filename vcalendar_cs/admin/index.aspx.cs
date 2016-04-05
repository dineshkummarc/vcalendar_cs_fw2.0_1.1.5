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

namespace calendar.admin.index{ //Namespace @1-18CBE5C9

//Forms Definition @1-022C137C
public partial class indexPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-02B8F459
    protected usersDataProvider usersData;
    protected int usersCurrentRowNumber;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string indexContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-8D86C04A
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            usersBind();
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

//Grid users Bind @4-EF26F7EE
    protected void usersBind()
    {
        if (!usersOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"users",typeof(usersDataProvider.SortFields), 20, 100);
        }
//End Grid users Bind

//Grid users Event BeforeSelect. Action Custom Code @63-2A29BDB7
    // -------------------------
  	if (CommonFunctions.str_calendar_config("registration_type") != "8") {
  		usersRepeater.Visible = false;
  	}
    // -------------------------
//End Grid users Event BeforeSelect. Action Custom Code

//Grid Form users BeforeShow tail @4-250A3594
        usersParameters();
        usersData.SortField = (usersDataProvider.SortFields)ViewState["usersSortField"];
        usersData.SortDir = (SortDirections)ViewState["usersSortDir"];
        usersData.PageNumber = (int)ViewState["usersPageNumber"];
        usersData.RecordsPerPage = (int)ViewState["usersPageSize"];
        usersRepeater.DataSource = usersData.GetResultSet(out PagesCount, usersOperations);
        ViewState["usersPagesCount"] = PagesCount;
        usersRepeater.DataBind();
        FooterIndex = usersRepeater.Controls.Count - 1;
        usersRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        usersItem item=new usersItem();
        System.Web.UI.WebControls.Literal usersusers_TotalRecords = (System.Web.UI.WebControls.Literal)usersRepeater.Controls[0].FindControl("usersusers_TotalRecords");


        usersusers_TotalRecords.Text=Server.HtmlEncode(item.users_TotalRecords.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        calendar.Controls.Navigator NavigatorNavigator = (calendar.Controls.Navigator)usersRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form users BeforeShow tail

//Label users_TotalRecords Event BeforeShow. Action Retrieve number of records @9-15CBAC90
            usersusers_TotalRecords.Text = usersData.RecordCount.ToString();
//End Label users_TotalRecords Event BeforeShow. Action Retrieve number of records

//Grid users Bind tail @4-FCB6E20C
    }
//End Grid users Bind tail

//Grid users Table Parameters @4-D3F2FCE5
    protected void usersParameters()
    {
        try{
            usersData.Expr61 = IntegerParameter.GetParam(1, ParameterSourceType.Expression, "", null, false);
        }catch{
            ControlCollection ParentControls=usersRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(usersRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid users: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid users Table Parameters

//Grid users ItemDataBound event @4-2D91D0A1
    protected void usersItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        usersItem DataItem=(usersItem)e.Item.DataItem;
        usersItem[] FormDataSource=(usersItem[])usersRepeater.DataSource;
        usersItem item = DataItem;
        int usersDataRows = FormDataSource.Length;
        bool usersIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        usersCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal usersuser_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_id"));
            System.Web.UI.HtmlControls.HtmlAnchor usersuser_login = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("usersuser_login"));
            System.Web.UI.WebControls.Literal usersuser_first_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_first_name"));
            System.Web.UI.WebControls.Literal usersuser_last_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_last_name"));
            System.Web.UI.WebControls.Literal usersuser_email = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_email"));
            System.Web.UI.WebControls.Literal usersuser_date_add = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_date_add"));
            DataItem.user_loginHref = "users_activate.aspx";
            usersuser_login.HRef = DataItem.user_loginHref + DataItem.user_loginHrefParameters.ToString("GET","", ViewState);
        }
//End Grid users ItemDataBound event

//Grid users ItemDataBound event tail @4-0DC05CB9
        if(usersIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(usersCurrentRowNumber, ListItemType.Item);
            usersRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            usersItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid users ItemDataBound event tail

//Grid users ItemCommand event @4-A708BDAE
    protected void usersItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = usersRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["usersSortDir"]==SortDirections.Asc&&ViewState["usersSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["usersSortDir"]=SortDirections.Desc;
                else
                    ViewState["usersSortDir"]=SortDirections.Asc;
            else
                ViewState["usersSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["usersSortField"]=Enum.Parse(typeof(usersDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["usersPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["usersPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            usersBind();
    }
//End Grid users ItemCommand event

//OnInit Event @1-3BF5C7DB
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
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, true, false, false, false);
        if(!DBUtility.AuthorizeUser(new string[]{
          "100"}))
            Response.Redirect(Settings.AccessDeniedUrl+"?ret_link="+Server.UrlEncode(Request["SCRIPT_NAME"]+"?"+Request["QUERY_STRING"]));
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

