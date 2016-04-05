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

namespace calendar.admin.custom_fields{ //Namespace @1-11E7D2DD

//Forms Definition @1-1BCFF76A
public partial class custom_fieldsPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-0A8C5637
    protected custom_fieldsDataProvider custom_fieldsData;
    protected int custom_fieldsCurrentRowNumber;
    protected FormSupportedOperations custom_fieldsOperations;
    protected custom_fields_maintDataProvider custom_fields_maintData;
    protected NameValueCollection custom_fields_maintErrors=new NameValueCollection();
    protected bool custom_fields_maintIsSubmitted = false;
    protected FormSupportedOperations custom_fields_maintOperations;
    protected System.Resources.ResourceManager rm;
    protected string custom_fieldsContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-FF74768D
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            custom_fieldsBind();
            custom_fields_maintShow();
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

//Grid custom_fields Bind @3-8E284D59
    protected void custom_fieldsBind()
    {
        if (!custom_fieldsOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"custom_fields",typeof(custom_fieldsDataProvider.SortFields), 0, 100);
        }
//End Grid custom_fields Bind

//Grid Form custom_fields BeforeShow tail @3-399BA4FA
        custom_fieldsParameters();
        custom_fieldsData.SortField = (custom_fieldsDataProvider.SortFields)ViewState["custom_fieldsSortField"];
        custom_fieldsData.SortDir = (SortDirections)ViewState["custom_fieldsSortDir"];
        custom_fieldsData.PageNumber = (int)ViewState["custom_fieldsPageNumber"];
        custom_fieldsData.RecordsPerPage = (int)ViewState["custom_fieldsPageSize"];
        custom_fieldsRepeater.DataSource = custom_fieldsData.GetResultSet(out PagesCount, custom_fieldsOperations);
        ViewState["custom_fieldsPagesCount"] = PagesCount;
        custom_fieldsRepeater.DataBind();
        FooterIndex = custom_fieldsRepeater.Controls.Count - 1;
        custom_fieldsRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;


//End Grid Form custom_fields BeforeShow tail

//Grid custom_fields Bind tail @3-FCB6E20C
    }
//End Grid custom_fields Bind tail

//Grid custom_fields Table Parameters @3-B40264DF
    protected void custom_fieldsParameters()
    {
        try{
            custom_fieldsData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", "en", false);
        }catch{
            ControlCollection ParentControls=custom_fieldsRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(custom_fieldsRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid custom_fields: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid custom_fields Table Parameters

//Grid custom_fields ItemDataBound event @3-DE54DCE0
    protected void custom_fieldsItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        custom_fieldsItem DataItem=(custom_fieldsItem)e.Item.DataItem;
        custom_fieldsItem[] FormDataSource=(custom_fieldsItem[])custom_fieldsRepeater.DataSource;
        custom_fieldsItem item = DataItem;
        int custom_fieldsDataRows = FormDataSource.Length;
        bool custom_fieldsIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        custom_fieldsCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor custom_fieldsfield_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("custom_fieldsfield_name"));
            System.Web.UI.WebControls.Literal custom_fieldsfield_label = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("custom_fieldsfield_label"));
            System.Web.UI.WebControls.Literal custom_fieldsfield_is_active = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("custom_fieldsfield_is_active"));
            System.Web.UI.HtmlControls.HtmlAnchor custom_fieldstranslations = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("custom_fieldstranslations"));
            DataItem.field_nameHref = "custom_fields.aspx";
            custom_fieldsfield_name.HRef = DataItem.field_nameHref + DataItem.field_nameHrefParameters.ToString("GET","", ViewState);
            DataItem.translationsHref = "custom_fields_lang.aspx";
            custom_fieldstranslations.HRef = "javascript:openWin('" + DataItem.translationsHref + DataItem.translationsHrefParameters.ToString("GET","", ViewState) + "')";
        }
//End Grid custom_fields ItemDataBound event

//Grid custom_fields ItemDataBound event tail @3-DB494F0D
        if(custom_fieldsIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(custom_fieldsCurrentRowNumber, ListItemType.Item);
            custom_fieldsRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            custom_fieldsItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid custom_fields ItemDataBound event tail

//Grid custom_fields ItemCommand event @3-AB2B56B8
    protected void custom_fieldsItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = custom_fieldsRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["custom_fieldsSortDir"]==SortDirections.Asc&&ViewState["custom_fieldsSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["custom_fieldsSortDir"]=SortDirections.Desc;
                else
                    ViewState["custom_fieldsSortDir"]=SortDirections.Asc;
            else
                ViewState["custom_fieldsSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["custom_fieldsSortField"]=Enum.Parse(typeof(custom_fieldsDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["custom_fieldsPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["custom_fieldsPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            custom_fieldsBind();
    }
//End Grid custom_fields ItemCommand event

//Record Form custom_fields_maint Parameters @16-79451C6B
    protected void custom_fields_maintParameters()
    {
        custom_fields_maintItem item=custom_fields_maintItem.CreateFromHttpRequest();
        try{
            custom_fields_maintData.Urlfield_id = IntegerParameter.GetParam("field_id", ParameterSourceType.URL, "", null, false);
            custom_fields_maintData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", "en", false);
            custom_fields_maintData.Ctrlfield_label = TextParameter.GetParam(item.field_label.Value, ParameterSourceType.Control, "", null, false);
        }catch(Exception e){
            custom_fields_maintErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form custom_fields_maint Parameters

//Record Form custom_fields_maint Show method @16-9818E8F3
    protected void custom_fields_maintShow()
    {
        if(custom_fields_maintOperations.None)
        {
            custom_fields_maintHolder.Visible=false;
            return;
        }
        custom_fields_maintItem item=custom_fields_maintItem.CreateFromHttpRequest();
        bool IsInsertMode=!custom_fields_maintOperations.AllowRead;
        custom_fields_maintErrors.Add(item.errors);
//End Record Form custom_fields_maint Show method

//Record Form custom_fields_maint BeforeShow tail @16-1EDA43FE
        custom_fields_maintParameters();
        custom_fields_maintData.FillItem(item,ref IsInsertMode);
        custom_fields_maintHolder.DataBind();
        custom_fields_maintButton_Update.Visible=!IsInsertMode&&custom_fields_maintOperations.AllowUpdate;
        custom_fields_maintfield_name.Text=Server.HtmlEncode(item.field_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        custom_fields_maintfield_label.Text=item.field_label.GetFormattedValue();
        if(item.field_is_activeCheckedValue.Value.Equals(item.field_is_active.Value))
            custom_fields_maintfield_is_active.Checked = true;
//End Record Form custom_fields_maint BeforeShow tail

//Record custom_fields_maint Event BeforeShow. Action Hide-Show Component @37-CC2BB316
        TextField Urlfield_id_37_1 = new TextField("", System.Web.HttpContext.Current.Request.QueryString["field_id"]);
        TextField ExprParam2_37_2 = new TextField("", (""));
        if (Urlfield_id_37_1 == ExprParam2_37_2) {
            custom_fields_maintHolder.Visible = false;
        }
//End Record custom_fields_maint Event BeforeShow. Action Hide-Show Component

//Record Form custom_fields_maint Show method tail @16-3F453D50
        if(custom_fields_maintErrors.Count>0)
            custom_fields_maintShowErrors();
    }
//End Record Form custom_fields_maint Show method tail

//Record Form custom_fields_maint LoadItemFromRequest method @16-FA6EF397
    protected void custom_fields_maintLoadItemFromRequest(custom_fields_maintItem item, bool EnableValidation)
    {
        item.field_label.SetValue(custom_fields_maintfield_label.Text);
        item.field_is_active.Value = custom_fields_maintfield_is_active.Checked ?(item.field_is_activeCheckedValue.Value):(item.field_is_activeUncheckedValue.Value);
        if(EnableValidation)
            item.Validate(custom_fields_maintData);
        custom_fields_maintErrors.Add(item.errors);
    }
//End Record Form custom_fields_maint LoadItemFromRequest method

//Record Form custom_fields_maint GetRedirectUrl method @16-87399132
    protected string Getcustom_fields_maintRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "custom_fields.aspx";
        string p = parameters.ToString("GET","field_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form custom_fields_maint GetRedirectUrl method

//Record Form custom_fields_maint ShowErrors method @16-9CBDDEA7
    protected void custom_fields_maintShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<custom_fields_maintErrors.Count;i++)
        switch(custom_fields_maintErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=custom_fields_maintErrors[i];
                break;
        }
        custom_fields_maintError.Visible = true;
        custom_fields_maintErrorLabel.Text = DefaultMessage;
    }
//End Record Form custom_fields_maint ShowErrors method

//Record Form custom_fields_maint Insert Operation @16-7094D443
    protected void custom_fields_maint_Insert(object sender, System.EventArgs e)
    {
        custom_fields_maintIsSubmitted = true;
        bool ErrorFlag = false;
        custom_fields_maintItem item=new custom_fields_maintItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form custom_fields_maint Insert Operation

//Record Form custom_fields_maint BeforeInsert tail @16-69582E15
    custom_fields_maintParameters();
    custom_fields_maintLoadItemFromRequest(item, EnableValidation);
//End Record Form custom_fields_maint BeforeInsert tail

//Record Form custom_fields_maint AfterInsert tail  @16-A29A401C
        ErrorFlag=(custom_fields_maintErrors.Count>0);
        if(ErrorFlag)
            custom_fields_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form custom_fields_maint AfterInsert tail 

//Record Form custom_fields_maint Update Operation @16-F394226E
    protected void custom_fields_maint_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        custom_fields_maintItem item=new custom_fields_maintItem();
        item.IsNew = false;
        custom_fields_maintIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form custom_fields_maint Update Operation

//Button Button_Update OnClick. @17-51E8B052
        if(((Control)sender).ID == "custom_fields_maintButton_Update")
        {
            RedirectUrl  = Getcustom_fields_maintRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @17-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form custom_fields_maint Before Update tail @16-4DC36872
        custom_fields_maintParameters();
        custom_fields_maintLoadItemFromRequest(item, EnableValidation);
        if(custom_fields_maintOperations.AllowUpdate){
        ErrorFlag=(custom_fields_maintErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                custom_fields_maintData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                custom_fields_maintErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form custom_fields_maint Before Update tail

//Record Form custom_fields_maint Update Operation tail @16-A163ECA1
        }
        ErrorFlag=(custom_fields_maintErrors.Count>0);
        if(ErrorFlag)
            custom_fields_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form custom_fields_maint Update Operation tail

//Record Form custom_fields_maint Delete Operation @16-00C581D0
    protected void custom_fields_maint_Delete(object sender,System.EventArgs e)
    {
        custom_fields_maintIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        custom_fields_maintItem item=new custom_fields_maintItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form custom_fields_maint Delete Operation

//Record Form BeforeDelete tail @16-69582E15
        custom_fields_maintParameters();
        custom_fields_maintLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @16-531D4DF4
        if(ErrorFlag)
            custom_fields_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form custom_fields_maint Cancel Operation @16-8D475DF4
    protected void custom_fields_maint_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        custom_fields_maintItem item=new custom_fields_maintItem();
        custom_fields_maintIsSubmitted = true;
        string RedirectUrl = "";
        custom_fields_maintLoadItemFromRequest(item, false);
//End Record Form custom_fields_maint Cancel Operation

//Button Button_Cancel OnClick. @49-2793468A
    if(((Control)sender).ID == "custom_fields_maintButton_Cancel")
    {
        RedirectUrl  = Getcustom_fields_maintRedirectUrl("", "");
//End Button Button_Cancel OnClick.

//Button Button_Cancel OnClick tail. @49-FCB6E20C
    }
//End Button Button_Cancel OnClick tail.

//Record Form custom_fields_maint Cancel Operation tail @16-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form custom_fields_maint Cancel Operation tail

//OnInit Event @1-C947D769
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        custom_fieldsContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        custom_fieldsData = new custom_fieldsDataProvider();
        custom_fieldsOperations = new FormSupportedOperations(false, true, false, false, false);
        custom_fields_maintData = new custom_fields_maintDataProvider();
        custom_fields_maintOperations = new FormSupportedOperations(false, true, false, true, false);
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

