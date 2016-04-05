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

namespace calendar.admin.users{ //Namespace @1-B68E7F41

//Forms Definition @1-693F17A0
public partial class usersPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-ABBEB83F
    protected usersSearchDataProvider usersSearchData;
    protected NameValueCollection usersSearchErrors=new NameValueCollection();
    protected bool usersSearchIsSubmitted = false;
    protected FormSupportedOperations usersSearchOperations;
    protected usersDataProvider usersData;
    protected int usersCurrentRowNumber;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string usersContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-100EF472
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            usersSearchShow();
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

//Record Form usersSearch Parameters @3-5CAB9E78
    protected void usersSearchParameters()
    {
        usersSearchItem item=usersSearchItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            usersSearchErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form usersSearch Parameters

//Record Form usersSearch Show method @3-B621DAC7
    protected void usersSearchShow()
    {
        if(usersSearchOperations.None)
        {
            usersSearchHolder.Visible=false;
            return;
        }
        usersSearchItem item=usersSearchItem.CreateFromHttpRequest();
        bool IsInsertMode=!usersSearchOperations.AllowRead;
        usersSearchErrors.Add(item.errors);
//End Record Form usersSearch Show method

//Record Form usersSearch BeforeShow tail @3-BFC66496
        usersSearchParameters();
        usersSearchData.FillItem(item,ref IsInsertMode);
        usersSearchHolder.DataBind();
        usersSearchs_keyword.Text=item.s_keyword.GetFormattedValue();
        item.s_user_levelItems.SetSelection(item.s_user_level.GetFormattedValue());
        usersSearchs_user_level.Items.Add(new ListItem(Resources.strings.cal_all,""));
        usersSearchs_user_level.Items[0].Selected = true;
        if(item.s_user_levelItems.GetSelectedItem() != null)
            usersSearchs_user_level.SelectedIndex = -1;
        item.s_user_levelItems.CopyTo(usersSearchs_user_level.Items);
        item.s_user_is_approvedItems.SetSelection(item.s_user_is_approved.GetFormattedValue());
        usersSearchs_user_is_approved.Items.Add(new ListItem(Resources.strings.cal_all,""));
        usersSearchs_user_is_approved.Items[0].Selected = true;
        if(item.s_user_is_approvedItems.GetSelectedItem() != null)
            usersSearchs_user_is_approved.SelectedIndex = -1;
        item.s_user_is_approvedItems.CopyTo(usersSearchs_user_is_approved.Items);
//End Record Form usersSearch BeforeShow tail

//Record Form usersSearch Show method tail @3-5C8AD5DA
        if(usersSearchErrors.Count>0)
            usersSearchShowErrors();
    }
//End Record Form usersSearch Show method tail

//Record Form usersSearch LoadItemFromRequest method @3-1C01103F
    protected void usersSearchLoadItemFromRequest(usersSearchItem item, bool EnableValidation)
    {
        item.s_keyword.SetValue(usersSearchs_keyword.Text);
        try{
        item.s_user_level.SetValue(usersSearchs_user_level.Value);
        item.s_user_levelItems.CopyFrom(usersSearchs_user_level.Items);
        }catch(ArgumentException){
            usersSearchErrors.Add("s_user_level",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.user_level));}
        item.s_user_is_approved.SetValue(usersSearchs_user_is_approved.Value);
        item.s_user_is_approvedItems.CopyFrom(usersSearchs_user_is_approved.Items);
        if(EnableValidation)
            item.Validate(usersSearchData);
        usersSearchErrors.Add(item.errors);
    }
//End Record Form usersSearch LoadItemFromRequest method

//Record Form usersSearch GetRedirectUrl method @3-BB804803
    protected string GetusersSearchRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "users.aspx";
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form usersSearch GetRedirectUrl method

//Record Form usersSearch ShowErrors method @3-56D9F26E
    protected void usersSearchShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<usersSearchErrors.Count;i++)
        switch(usersSearchErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=usersSearchErrors[i];
                break;
        }
        usersSearchError.Visible = true;
        usersSearchErrorLabel.Text = DefaultMessage;
    }
//End Record Form usersSearch ShowErrors method

//Record Form usersSearch Insert Operation @3-AEA18A75
    protected void usersSearch_Insert(object sender, System.EventArgs e)
    {
        usersSearchIsSubmitted = true;
        bool ErrorFlag = false;
        usersSearchItem item=new usersSearchItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form usersSearch Insert Operation

//Record Form usersSearch BeforeInsert tail @3-9CF28C8C
    usersSearchParameters();
    usersSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form usersSearch BeforeInsert tail

//Record Form usersSearch AfterInsert tail  @3-89096253
        ErrorFlag=(usersSearchErrors.Count>0);
        if(ErrorFlag)
            usersSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form usersSearch AfterInsert tail 

//Record Form usersSearch Update Operation @3-598A1C4C
    protected void usersSearch_Update(object sender, System.EventArgs e)
    {
        usersSearchItem item=new usersSearchItem();
        item.IsNew = false;
        usersSearchIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form usersSearch Update Operation

//Record Form usersSearch Before Update tail @3-9CF28C8C
        usersSearchParameters();
        usersSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form usersSearch Before Update tail

//Record Form usersSearch Update Operation tail @3-89096253
        ErrorFlag=(usersSearchErrors.Count>0);
        if(ErrorFlag)
            usersSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form usersSearch Update Operation tail

//Record Form usersSearch Delete Operation @3-046EEFC8
    protected void usersSearch_Delete(object sender,System.EventArgs e)
    {
        usersSearchIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        usersSearchItem item=new usersSearchItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form usersSearch Delete Operation

//Record Form BeforeDelete tail @3-9CF28C8C
        usersSearchParameters();
        usersSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @3-16D3FCCD
        if(ErrorFlag)
            usersSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form usersSearch Cancel Operation @3-4048055B
    protected void usersSearch_Cancel(object sender,System.EventArgs e)
    {
        usersSearchItem item=new usersSearchItem();
        usersSearchIsSubmitted = true;
        string RedirectUrl = "";
        usersSearchLoadItemFromRequest(item, true);
//End Record Form usersSearch Cancel Operation

//Record Form usersSearch Cancel Operation tail @3-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form usersSearch Cancel Operation tail

//Record Form usersSearch Search Operation @3-5DBAAD75
    protected void usersSearch_Search(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        usersSearchIsSubmitted = true;
        bool ErrorFlag=false;
        usersSearchItem item=new usersSearchItem();
        usersSearchLoadItemFromRequest(item, true);
        ErrorFlag=(usersSearchErrors.Count>0);
        string RedirectUrl = "";
//End Record Form usersSearch Search Operation

//Button Button_DoSearch OnClick. @4-265A5C7C
        if(((Control)sender).ID == "usersSearchButton_DoSearch")
        {
            RedirectUrl = GetusersSearchRedirectUrl("", "s_keyword;s_user_level;s_user_is_approved");
//End Button Button_DoSearch OnClick.

//Button Button_DoSearch OnClick tail. @4-FCB6E20C
        }
//End Button Button_DoSearch OnClick tail.

//Record Form usersSearch Search Operation tail @3-1EBAF62F
        if(ErrorFlag)
            usersSearchShowErrors();
        else{
            string Params="";
            Params+=usersSearchs_keyword.Text!=""?("s_keyword="+Server.UrlEncode(usersSearchs_keyword.Text)+"&"):"";
            foreach(ListItem li in usersSearchs_user_level.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "s_user_level="+Server.UrlEncode(li.Value)+"&";
            foreach(ListItem li in usersSearchs_user_is_approved.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "s_user_is_approved="+Server.UrlEncode(li.Value)+"&";
            if(!RedirectUrl.EndsWith("?"))
                RedirectUrl += "&" + Params;
            else
                RedirectUrl += Params;
            RedirectUrl = RedirectUrl.TrimEnd(new Char[]{'&'});
            Response.Redirect(RedirectUrl);
        }
    }
//End Record Form usersSearch Search Operation tail

//Grid users Bind @2-EF26F7EE
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

//Grid Form users BeforeShow tail @2-3D2E23C6
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
        System.Web.UI.HtmlControls.HtmlAnchor usersusers_Insert = (System.Web.UI.HtmlControls.HtmlAnchor)usersRepeater.Controls[FooterIndex].FindControl("usersusers_Insert");

        item.users_InsertHref = "users_maint.aspx";

        usersusers_TotalRecords.Text=Server.HtmlEncode(item.users_TotalRecords.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        usersusers_Insert.InnerText=Resources.strings.CCS_InsertLink;
        usersusers_Insert.HRef = item.users_InsertHref+item.users_InsertHrefParameters.ToString("GET","user_id", ViewState);
        calendar.Controls.Navigator NavigatorNavigator = (calendar.Controls.Navigator)usersRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form users BeforeShow tail

//Label users_TotalRecords Event BeforeShow. Action Retrieve number of records @9-15CBAC90
            usersusers_TotalRecords.Text = usersData.RecordCount.ToString();
//End Label users_TotalRecords Event BeforeShow. Action Retrieve number of records

//Grid users Bind tail @2-FCB6E20C
    }
//End Grid users Bind tail

//Grid users Table Parameters @2-6CBD7966
    protected void usersParameters()
    {
        try{
            usersData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", null, false);
            usersData.Urls_user_level = IntegerParameter.GetParam("s_user_level", ParameterSourceType.URL, "", null, false);
            usersData.Urls_user_is_approved = IntegerParameter.GetParam("s_user_is_approved", ParameterSourceType.URL, "", null, false);
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

//Grid users ItemDataBound event @2-75E49005
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
            System.Web.UI.WebControls.Literal usersuser_level = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_level"));
            System.Web.UI.WebControls.Literal usersuser_email = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_email"));
            System.Web.UI.WebControls.Literal usersuser_date_add = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_date_add"));
            System.Web.UI.WebControls.Literal usersuser_last_login = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_last_login"));
            System.Web.UI.WebControls.Literal usersuser_is_approved = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_is_approved"));
            DataItem.user_loginHref = "users_maint.aspx";
            usersuser_login.HRef = DataItem.user_loginHref + DataItem.user_loginHrefParameters.ToString("GET","", ViewState);
        }
//End Grid users ItemDataBound event

//Grid users BeforeShowRow event @2-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid users BeforeShowRow event

//Grid users Event BeforeShowRow. Action Custom Code @69-2A29BDB7
    // -------------------------
            System.Web.UI.WebControls.Literal usersuser_level = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersuser_level"));
  			string UserLevel = "";
  			switch (usersuser_level.Text)
  			{
  				case "1": 
  					UserLevel = "non_confirmed_user";
  					break;
  				case "10": 
  					UserLevel = "user";
  					break;
  				case "100": 
  					UserLevel = "admin";
  					break;
  			}
  			usersuser_level.Text = ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString(UserLevel);
    // -------------------------
//End Grid users Event BeforeShowRow. Action Custom Code

//Grid users BeforeShowRow event tail @2-FCB6E20C
        }
//End Grid users BeforeShowRow event tail

//Grid users ItemDataBound event tail @2-0DC05CB9
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

//Grid users ItemCommand event @2-A708BDAE
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

//OnInit Event @1-0B24489D
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        usersContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        usersSearchData = new usersSearchDataProvider();
        usersSearchOperations = new FormSupportedOperations(false, true, true, true, true);
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, true, false, false, false);
        if(!DBUtility.AuthorizeUser(new string[]{
          "100"}))
            Response.Redirect("../login.aspx"+"?ret_link="+Server.UrlEncode(Request["SCRIPT_NAME"]+"?"+Request["QUERY_STRING"]));
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

