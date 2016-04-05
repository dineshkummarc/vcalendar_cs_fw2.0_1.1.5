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

namespace calendar.admin.email_templates{ //Namespace @1-0951ED95

//Forms Definition @1-D67D787F
public partial class email_templatesPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-D5D1748A
    protected email_templatesDataProvider email_templatesData;
    protected int email_templatesCurrentRowNumber;
    protected FormSupportedOperations email_templatesOperations;
    protected System.Resources.ResourceManager rm;
    protected string email_templatesContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-257E6700
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            email_templatesBind();
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

//Grid email_templates Bind @2-4E637CE4
    protected void email_templatesBind()
    {
        if (!email_templatesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"email_templates",typeof(email_templatesDataProvider.SortFields), 20, 100);
        }
//End Grid email_templates Bind

//Grid Form email_templates BeforeShow tail @2-3256EC23
        email_templatesParameters();
        email_templatesData.SortField = (email_templatesDataProvider.SortFields)ViewState["email_templatesSortField"];
        email_templatesData.SortDir = (SortDirections)ViewState["email_templatesSortDir"];
        email_templatesData.PageNumber = (int)ViewState["email_templatesPageNumber"];
        email_templatesData.RecordsPerPage = (int)ViewState["email_templatesPageSize"];
        email_templatesRepeater.DataSource = email_templatesData.GetResultSet(out PagesCount, email_templatesOperations);
        ViewState["email_templatesPagesCount"] = PagesCount;
        email_templatesRepeater.DataBind();
        FooterIndex = email_templatesRepeater.Controls.Count - 1;
        email_templatesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;


        calendar.Controls.Navigator NavigatorNavigator = (calendar.Controls.Navigator)email_templatesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form email_templates BeforeShow tail

//Grid email_templates Bind tail @2-FCB6E20C
    }
//End Grid email_templates Bind tail

//Grid email_templates Table Parameters @2-D55267C1
    protected void email_templatesParameters()
    {
        try{
            email_templatesData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
        }catch{
            ControlCollection ParentControls=email_templatesRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(email_templatesRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid email_templates: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid email_templates Table Parameters

//Grid email_templates ItemDataBound event @2-F404C363
    protected void email_templatesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        email_templatesItem DataItem=(email_templatesItem)e.Item.DataItem;
        email_templatesItem[] FormDataSource=(email_templatesItem[])email_templatesRepeater.DataSource;
        email_templatesItem item = DataItem;
        int email_templatesDataRows = FormDataSource.Length;
        bool email_templatesIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        email_templatesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal email_templatesemail_template_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("email_templatesemail_template_id"));
            System.Web.UI.HtmlControls.HtmlAnchor email_templatesemail_template_subject = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("email_templatesemail_template_subject"));
            System.Web.UI.WebControls.Literal email_templatesemail_template_type = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("email_templatesemail_template_type"));
            System.Web.UI.WebControls.Literal email_templatesemail_template_desc = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("email_templatesemail_template_desc"));
            System.Web.UI.WebControls.Literal email_templatesemail_template_from = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("email_templatesemail_template_from"));
            System.Web.UI.HtmlControls.HtmlAnchor email_templatestranslations = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("email_templatestranslations"));
            DataItem.email_template_subjectHref = "email_templates_maint.aspx";
            email_templatesemail_template_subject.HRef = DataItem.email_template_subjectHref + DataItem.email_template_subjectHrefParameters.ToString("GET","", ViewState);
            DataItem.translationsHref = "email_templates_lang.aspx";
            email_templatestranslations.HRef = "javascript:openWin('" + DataItem.translationsHref + DataItem.translationsHrefParameters.ToString("GET","", ViewState) + "')";
        }
//End Grid email_templates ItemDataBound event

//Grid email_templates ItemDataBound event tail @2-EFBCDF44
        if(email_templatesIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(email_templatesCurrentRowNumber, ListItemType.Item);
            email_templatesRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            email_templatesItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid email_templates ItemDataBound event tail

//Grid email_templates ItemCommand event @2-0CD16AC5
    protected void email_templatesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = email_templatesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["email_templatesSortDir"]==SortDirections.Asc&&ViewState["email_templatesSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["email_templatesSortDir"]=SortDirections.Desc;
                else
                    ViewState["email_templatesSortDir"]=SortDirections.Asc;
            else
                ViewState["email_templatesSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["email_templatesSortField"]=Enum.Parse(typeof(email_templatesDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["email_templatesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["email_templatesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            email_templatesBind();
    }
//End Grid email_templates ItemCommand event

//OnInit Event @1-FE6503C2
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        email_templatesContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        email_templatesData = new email_templatesDataProvider();
        email_templatesOperations = new FormSupportedOperations(false, true, false, false, false);
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

