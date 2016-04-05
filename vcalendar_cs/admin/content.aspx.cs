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

namespace calendar.admin.content{ //Namespace @1-74370073

//Forms Definition @1-20E6C1A1
public partial class contentPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-75289A00
    protected contentsDataProvider contentsData;
    protected int contentsCurrentRowNumber;
    protected FormSupportedOperations contentsOperations;
    protected contents_maintDataProvider contents_maintData;
    protected NameValueCollection contents_maintErrors=new NameValueCollection();
    protected bool contents_maintIsSubmitted = false;
    protected FormSupportedOperations contents_maintOperations;
    protected System.Resources.ResourceManager rm;
    protected string contentContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-7C8B8D88
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            contentsBind();
            contents_maintShow();
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

//Grid contents Bind @5-73BAB256
    protected void contentsBind()
    {
        if (!contentsOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"contents",typeof(contentsDataProvider.SortFields), 50, 100);
        }
//End Grid contents Bind

//Grid Form contents BeforeShow tail @5-0A73E704
        contentsParameters();
        contentsData.SortField = (contentsDataProvider.SortFields)ViewState["contentsSortField"];
        contentsData.SortDir = (SortDirections)ViewState["contentsSortDir"];
        contentsData.PageNumber = (int)ViewState["contentsPageNumber"];
        contentsData.RecordsPerPage = (int)ViewState["contentsPageSize"];
        contentsRepeater.DataSource = contentsData.GetResultSet(out PagesCount, contentsOperations);
        ViewState["contentsPagesCount"] = PagesCount;
        contentsRepeater.DataBind();
        FooterIndex = contentsRepeater.Controls.Count - 1;
        contentsRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;


//End Grid Form contents BeforeShow tail

//Grid contents Bind tail @5-FCB6E20C
    }
//End Grid contents Bind tail

//Grid contents Table Parameters @5-945A943C
    protected void contentsParameters()
    {
        try{
            contentsData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", "en", false);
        }catch{
            ControlCollection ParentControls=contentsRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(contentsRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid contents: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid contents Table Parameters

//Grid contents ItemDataBound event @5-B9D2E105
    protected void contentsItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        contentsItem DataItem=(contentsItem)e.Item.DataItem;
        contentsItem[] FormDataSource=(contentsItem[])contentsRepeater.DataSource;
        contentsItem item = DataItem;
        int contentsDataRows = FormDataSource.Length;
        bool contentsIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        contentsCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor contentscontent_type = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("contentscontent_type"));
            System.Web.UI.WebControls.Literal contentscontent_desc = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("contentscontent_desc"));
            System.Web.UI.HtmlControls.HtmlAnchor contentstranslations = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("contentstranslations"));
            DataItem.content_typeHref = "content.aspx";
            contentscontent_type.HRef = DataItem.content_typeHref + DataItem.content_typeHrefParameters.ToString("GET","", ViewState);
            DataItem.translationsHref = "content_lang.aspx";
            contentstranslations.HRef = "javascript:openWin('" + DataItem.translationsHref + DataItem.translationsHrefParameters.ToString("GET","", ViewState) + "')";
        }
//End Grid contents ItemDataBound event

//Grid contents ItemDataBound event tail @5-FEFF971C
        if(contentsIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(contentsCurrentRowNumber, ListItemType.Item);
            contentsRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            contentsItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid contents ItemDataBound event tail

//Grid contents ItemCommand event @5-9EC152CF
    protected void contentsItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = contentsRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["contentsSortDir"]==SortDirections.Asc&&ViewState["contentsSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["contentsSortDir"]=SortDirections.Desc;
                else
                    ViewState["contentsSortDir"]=SortDirections.Asc;
            else
                ViewState["contentsSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["contentsSortField"]=Enum.Parse(typeof(contentsDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["contentsPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["contentsPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            contentsBind();
    }
//End Grid contents ItemCommand event

//Record Form contents_maint Parameters @13-99DB9029
    protected void contents_maintParameters()
    {
        contents_maintItem item=contents_maintItem.CreateFromHttpRequest();
        try{
            contents_maintData.Urlcontent_id = IntegerParameter.GetParam("content_id", ParameterSourceType.URL, "", null, false);
            contents_maintData.Ctrlcontent_value = MemoParameter.GetParam(item.content_value.Value, ParameterSourceType.Control, "", null, false);
            contents_maintData.Ctrlcontent_desc = TextParameter.GetParam(item.content_desc.Value, ParameterSourceType.Control, "", null, false);
        }catch(Exception e){
            contents_maintErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form contents_maint Parameters

//Record Form contents_maint Show method @13-3FDC5959
    protected void contents_maintShow()
    {
        if(contents_maintOperations.None)
        {
            contents_maintHolder.Visible=false;
            return;
        }
        contents_maintItem item=contents_maintItem.CreateFromHttpRequest();
        bool IsInsertMode=!contents_maintOperations.AllowRead;
        contents_maintErrors.Add(item.errors);
//End Record Form contents_maint Show method

//Record Form contents_maint BeforeShow tail @13-70414579
        contents_maintParameters();
        contents_maintData.FillItem(item,ref IsInsertMode);
        contents_maintHolder.DataBind();
        contents_maintButton_Update.Visible=!IsInsertMode&&contents_maintOperations.AllowUpdate;
        contents_maintcontent_type.Text=Server.HtmlEncode(item.content_type.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        contents_maintcontent_desc.Text=item.content_desc.GetFormattedValue();
        contents_maintcontent_value.Text=item.content_value.GetFormattedValue();
        contents_maintcontent_id.Value=item.content_id.GetFormattedValue();
//End Record Form contents_maint BeforeShow tail

//Record contents_maint Event BeforeShow. Action Hide-Show Component @37-9C4D090A
        IntegerField Urlcontent_id_37_1 = new IntegerField("", System.Web.HttpContext.Current.Request.QueryString["content_id"]);
        IntegerField ExprParam2_37_2 = new IntegerField("", (1));
        if (Urlcontent_id_37_1 < ExprParam2_37_2) {
            contents_maintHolder.Visible = false;
        }
//End Record contents_maint Event BeforeShow. Action Hide-Show Component

//Record Form contents_maint Show method tail @13-3DAC2CA6
        if(contents_maintErrors.Count>0)
            contents_maintShowErrors();
    }
//End Record Form contents_maint Show method tail

//Record Form contents_maint LoadItemFromRequest method @13-1972D55B
    protected void contents_maintLoadItemFromRequest(contents_maintItem item, bool EnableValidation)
    {
        item.content_desc.SetValue(contents_maintcontent_desc.Text);
        item.content_value.SetValue(contents_maintcontent_value.Text);
        item.content_id.SetValue(contents_maintcontent_id.Value);
        if(EnableValidation)
            item.Validate(contents_maintData);
        contents_maintErrors.Add(item.errors);
    }
//End Record Form contents_maint LoadItemFromRequest method

//Record Form contents_maint GetRedirectUrl method @13-8043CAAE
    protected string Getcontents_maintRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "content.aspx";
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form contents_maint GetRedirectUrl method

//Record Form contents_maint ShowErrors method @13-93903FB1
    protected void contents_maintShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<contents_maintErrors.Count;i++)
        switch(contents_maintErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=contents_maintErrors[i];
                break;
        }
        contents_maintError.Visible = true;
        contents_maintErrorLabel.Text = DefaultMessage;
    }
//End Record Form contents_maint ShowErrors method

//Record Form contents_maint Insert Operation @13-526FF316
    protected void contents_maint_Insert(object sender, System.EventArgs e)
    {
        contents_maintIsSubmitted = true;
        bool ErrorFlag = false;
        contents_maintItem item=new contents_maintItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form contents_maint Insert Operation

//Record Form contents_maint BeforeInsert tail @13-3608C64B
    contents_maintParameters();
    contents_maintLoadItemFromRequest(item, EnableValidation);
//End Record Form contents_maint BeforeInsert tail

//Record Form contents_maint AfterInsert tail  @13-0B51B3E7
        ErrorFlag=(contents_maintErrors.Count>0);
        if(ErrorFlag)
            contents_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form contents_maint AfterInsert tail 

//Record Form contents_maint Update Operation @13-AC33DFD7
    protected void contents_maint_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        contents_maintItem item=new contents_maintItem();
        item.IsNew = false;
        contents_maintIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form contents_maint Update Operation

//Button Button_Update OnClick. @14-3CE90ECA
        if(((Control)sender).ID == "contents_maintButton_Update")
        {
            RedirectUrl  = Getcontents_maintRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @14-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form contents_maint Before Update tail @13-49CE4B3A
        contents_maintParameters();
        contents_maintLoadItemFromRequest(item, EnableValidation);
        if(contents_maintOperations.AllowUpdate){
        ErrorFlag=(contents_maintErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                contents_maintData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                contents_maintErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form contents_maint Before Update tail

//Record contents_maint Event AfterUpdate. Action Custom Code @55-2A29BDB7
    // -------------------------
		string Language_id = (string)Session["locale"];
		if (Language_id == CommonFunctions.str_calendar_config("default_language")) {
			DataAccessObject Conn =	Settings.calendarDataAccessObject;
			string SQL = "UPDATE contents " +
				"SET content_desc = " + Conn.ToSql(contents_maintcontent_desc.Text, FieldType.Text) +
				", content_value = " + Conn.ToSql(contents_maintcontent_value.Text, FieldType.Text) +
				" WHERE content_id = " + Conn.ToSql(contents_maintcontent_id.Value, FieldType.Integer);
  			Conn.RunSql(SQL);
		}
    // -------------------------
//End Record contents_maint Event AfterUpdate. Action Custom Code

//Record Form contents_maint Update Operation tail @13-7F1B18F0
        }
        ErrorFlag=(contents_maintErrors.Count>0);
        if(ErrorFlag)
            contents_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form contents_maint Update Operation tail

//Record Form contents_maint Delete Operation @13-988660A7
    protected void contents_maint_Delete(object sender,System.EventArgs e)
    {
        contents_maintIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        contents_maintItem item=new contents_maintItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form contents_maint Delete Operation

//Record Form BeforeDelete tail @13-3608C64B
        contents_maintParameters();
        contents_maintLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @13-A47EEC3A
        if(ErrorFlag)
            contents_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form contents_maint Cancel Operation @13-172E1985
    protected void contents_maint_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        contents_maintItem item=new contents_maintItem();
        contents_maintIsSubmitted = true;
        string RedirectUrl = "";
        contents_maintLoadItemFromRequest(item, false);
//End Record Form contents_maint Cancel Operation

//Button Button_Cancel OnClick. @38-777140DC
    if(((Control)sender).ID == "contents_maintButton_Cancel")
    {
        RedirectUrl  = Getcontents_maintRedirectUrl("", "");
//End Button Button_Cancel OnClick.

//Button Button_Cancel OnClick tail. @38-FCB6E20C
    }
//End Button Button_Cancel OnClick tail.

//Record Form contents_maint Cancel Operation tail @13-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form contents_maint Cancel Operation tail

//Button Preview OnClick Handler @64-4B358B03
    protected void contents_maint_Preview_OnClick(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        string RedirectUrl = Getcontents_maintRedirectUrl("", "");
        contents_maintItem item = new contents_maintItem();
        contents_maintLoadItemFromRequest(item, true);
        bool ErrorFlag=(contents_maintErrors.Count>0);
//End Button Preview OnClick Handler

//Button Preview OnClick Handler tail @64-A47EEC3A
        if(ErrorFlag)
            contents_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Button Preview OnClick Handler tail

//OnInit Event @1-FACE7711
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        contentContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        contentsData = new contentsDataProvider();
        contentsOperations = new FormSupportedOperations(false, true, false, false, false);
        contents_maintData = new contents_maintDataProvider();
        contents_maintOperations = new FormSupportedOperations(false, true, false, true, false);
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

