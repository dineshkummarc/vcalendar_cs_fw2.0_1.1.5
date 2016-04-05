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

namespace calendar.admin.email_templates_lang{ //Namespace @1-AB2AC7A2

//Forms Definition @1-68074790
public partial class email_templates_langPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-A7E198CD
    protected email_templates_langDataProvider email_templates_langData;
    protected int email_templates_langCurrentRowNumber;
    protected bool email_templates_langIsSubmitted = false;
    protected NameValueCollection email_templates_langErrors=new NameValueCollection();
    protected FormSupportedOperations email_templates_langOperations;
    protected System.Resources.ResourceManager rm;
    protected string email_templates_langContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-F6A18AB1
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            JavaScriptLabel.Text=item.JavaScriptLabel.GetFormattedValue();
            email_templates_langBind();
    }
//End Page_Load Event BeforeIsPostBack

//Page email_templates_lang Event BeforeShow. Action Custom Code @47-2A29BDB7
    // -------------------------
 	if (CommonFunctions.CCGetFromGet("email_template_id","").Length == 0)
		JavaScriptLabel.Text = "<script language=\"JavaScript\">window.opener.location.reload(); self.close();</script>";
    // -------------------------
//End Page email_templates_lang Event BeforeShow. Action Custom Code

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

//EditableGrid email_templates_lang Bind @29-B6A64CA6
    protected void email_templates_langBind()
    {
        if(email_templates_langOperations.None) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"email_templates_lang",typeof(email_templates_langDataProvider.SortFields), 10, 100);
        }
//End EditableGrid email_templates_lang Bind

//EditableGrid Form email_templates_lang BeforeShow tail @29-DA439670
        email_templates_langParameters();
        email_templates_langData.SortField = (email_templates_langDataProvider.SortFields)ViewState["email_templates_langSortField"];
        email_templates_langData.SortDir = (SortDirections)ViewState["email_templates_langSortDir"];
        email_templates_langData.PageNumber = (int)ViewState["email_templates_langPageNumber"];
        email_templates_langData.RecordsPerPage = (int)ViewState["email_templates_langPageSize"];
        email_templates_langRepeater.DataSource = email_templates_langData.GetResultSet(out PagesCount, email_templates_langOperations);
        ViewState["email_templates_langPagesCount"] = PagesCount;
        ViewState["email_templates_langFormState"] = new Hashtable();
        ViewState["email_templates_langRowState"] = new Hashtable();
        email_templates_langRepeater.DataBind();
        FooterIndex = email_templates_langRepeater.Controls.Count - 1;
        email_templates_langItem item=new email_templates_langItem();


        email_templates_langRepeater.Controls[FooterIndex].FindControl("email_templates_langButton_Submit").Visible = email_templates_langOperations.Editable;
        if (!((IEnumerable)email_templates_langRepeater.DataSource).GetEnumerator().MoveNext())
            email_templates_langRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = true;
        if (email_templates_langErrors.Count > 0)
        {
            System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(email_templates_langRepeater.Controls[0].FindControl("ErrorLabel"));
            PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(email_templates_langRepeater.Controls[0].FindControl("email_templates_langError"));
            RowError.Visible = true;
            foreach(string msg in email_templates_langErrors)
                Error.Text += email_templates_langErrors[msg] + "<br/>";
        }
//End EditableGrid Form email_templates_lang BeforeShow tail

//EditableGrid email_templates_lang Bind tail @29-C5B17D3C
        email_templates_langShowErrors(new ArrayList((ICollection)email_templates_langRepeater.DataSource), email_templates_langRepeater.Items);
    }
//End EditableGrid email_templates_lang Bind tail

//EditableGrid email_templates_lang Table Parameters @29-23AD6598
    protected void email_templates_langParameters()
    {
        try{
            email_templates_langItem item=new email_templates_langItem();
            email_templates_langData.Urlemail_template_id = IntegerParameter.GetParam("email_template_id", ParameterSourceType.URL, "", null, false);
        }catch{
            ControlCollection ParentControls=email_templates_langRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(email_templates_langRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid email_templates_lang: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End EditableGrid email_templates_lang Table Parameters

//EditableGrid email_templates_lang ItemDataBound event @29-2ACFFE6B
    protected void email_templates_langItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        email_templates_langItem DataItem=(email_templates_langItem)e.Item.DataItem;
        email_templates_langItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            email_templates_langCurrentRowNumber ++;
            DataItem.RowId = e.Item.ItemIndex;
            Hashtable formState = (Hashtable)ViewState["email_templates_langFormState"];
            Hashtable rowState = (Hashtable)ViewState["email_templates_langRowState"];
            formState.Add("email_template_lang_idField:" + e.Item.ItemIndex.ToString(),DataItem.email_template_lang_idField.Value);
            rowState.Add(e.Item.ItemIndex.ToString(),DataItem.IsNew);
            ViewState[e.Item.FindControl("email_templates_langlanguageLabel").UniqueID] = DataItem.languageLabel.Value;
            System.Web.UI.WebControls.Literal email_templates_langlanguageLabel = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("email_templates_langlanguageLabel"));
            System.Web.UI.HtmlControls.HtmlInputHidden email_templates_langlanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("email_templates_langlanguage_id"));
            System.Web.UI.WebControls.TextBox email_templates_langemail_template_desc = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("email_templates_langemail_template_desc"));
            System.Web.UI.WebControls.TextBox email_templates_langemail_template_subject = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("email_templates_langemail_template_subject"));
            System.Web.UI.WebControls.TextBox email_templates_langemail_template_body = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("email_templates_langemail_template_body"));
        }
//End EditableGrid email_templates_lang ItemDataBound event

//EditableGrid email_templates_lang BeforeShowRow event @29-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End EditableGrid email_templates_lang BeforeShowRow event

//EditableGrid email_templates_lang BeforeShowRow event tail @29-FCB6E20C
        }
//End EditableGrid email_templates_lang BeforeShowRow event tail

//EditableGrid email_templates_lang ItemDataBound event tail @29-FCB6E20C
    }
//End EditableGrid email_templates_lang ItemDataBound event tail

//EditableGrid email_templates_lang GetRedirectUrl method @29-88B8E202
    protected string Getemail_templates_langRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET","email_template_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }
    protected string Getemail_templates_langRedirectUrl(string redirectString)
    {
        return Getemail_templates_langRedirectUrl(redirectString ,"email_template_id");
    }
//End EditableGrid email_templates_lang GetRedirectUrl method

//EditableGrid email_templates_lang ShowErrors method @29-0A89BBEE
    protected bool email_templates_langShowErrors(ArrayList items, RepeaterItemCollection col)
    {
        bool result = true;
        foreach(email_templates_langItem item in items)
        {
            if(item.IsUpdated) col[item.RowId].Visible = false;
            if(item.errors.Count > 0){
                result = false;
                string DefaultMessage="";
                for(int j = 0; j < item.errors.Count; j ++)
                switch (item.errors.AllKeys[j])
                {
                    default:
                        if(DefaultMessage != "") DefaultMessage += "<br>";
                        DefaultMessage += item.errors[j];
                        break;
                }
                System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(col[item.RowId].FindControl("ErrorLabel"));
                col[item.RowId].FindControl("RowError").Visible = true;
                Error.Text = DefaultMessage;
            }
        }
        return result;
    }
//End EditableGrid email_templates_lang ShowErrors method

//EditableGrid email_templates_lang ItemCommand event @29-BBB51CF5
    protected void email_templates_langItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = email_templates_langRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End EditableGrid email_templates_lang ItemCommand event

//Button Button_Submit OnClick. @39-496F1374
        if(((Control)e.CommandSource).ID == "email_templates_langButton_Submit")
        {
            RedirectUrl  = Getemail_templates_langRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Submit OnClick.

//Button Button_Submit OnClick tail. @39-FCB6E20C
        }
//End Button Button_Submit OnClick tail.

//EditableGrid Form email_templates_lang ItemCommand event tail @29-C725288B
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["email_templates_langSortDir"]==SortDirections.Asc&&ViewState["email_templates_langSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["email_templates_langSortDir"]=SortDirections.Desc;
                else
                    ViewState["email_templates_langSortDir"]=SortDirections.Asc;
            else
                ViewState["email_templates_langSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["email_templates_langSortField"]=Enum.Parse(typeof(email_templates_langDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["email_templates_langPageNumber"] = 1;
            BindAllowed = true;
        }

        if(e.CommandName=="Navigate"){
            ViewState["email_templates_langPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }

        if(e.CommandName=="Submit"){
            email_templates_langIsSubmitted = true;
            BindAllowed = true;
            RepeaterItemCollection col=email_templates_langRepeater.Items;
            ArrayList items=new ArrayList();
            Hashtable formState = (Hashtable)ViewState["email_templates_langFormState"];
            Hashtable rowState = (Hashtable)ViewState["email_templates_langRowState"];
            email_templates_langParameters();
            for(int i=0;i<col.Count;i++)
                if(col[i].ItemType == ListItemType.Item || col[i].ItemType == ListItemType.AlternatingItem){
                    System.Web.UI.WebControls.Literal email_templates_langlanguageLabel = (System.Web.UI.WebControls.Literal)(col[i].FindControl("email_templates_langlanguageLabel"));
                    System.Web.UI.HtmlControls.HtmlInputHidden email_templates_langlanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(col[i].FindControl("email_templates_langlanguage_id"));
                    System.Web.UI.WebControls.TextBox email_templates_langemail_template_desc = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("email_templates_langemail_template_desc"));
                    System.Web.UI.WebControls.TextBox email_templates_langemail_template_subject = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("email_templates_langemail_template_subject"));
                    System.Web.UI.WebControls.TextBox email_templates_langemail_template_body = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("email_templates_langemail_template_body"));
                    col[i].FindControl("RowError").Visible = false;
                    email_templates_langItem item = new email_templates_langItem();
                    item.RowId = col[i].ItemIndex;
                    item.IsUpdated = !col[i].Visible;
                    item.IsNew = (bool)(rowState[col[i].ItemIndex.ToString()]);
                    item.email_template_lang_idField.Value = (System.IComparable)formState["email_template_lang_idField:" + col[i].ItemIndex.ToString()];
                    item.languageLabel.Value = (System.IComparable)ViewState[email_templates_langlanguageLabel.UniqueID];
                    item.language_id.SetValue(email_templates_langlanguage_id.Value);
                    item.email_template_desc.SetValue(email_templates_langemail_template_desc.Text);
                    item.email_template_subject.SetValue(email_templates_langemail_template_subject.Text);
                    item.email_template_body.SetValue(email_templates_langemail_template_body.Text);
                    items.Add(item);
                    if(EnableValidation && !item.IsEmptyItem && !item.IsDeleted)
                        BindAllowed = item.Validate(email_templates_langData) && BindAllowed;
            }

//End EditableGrid Form email_templates_lang ItemCommand event tail

//EditableGrid email_templates_lang Update @29-AF3AD9F5
        if (BindAllowed)
            try
            {
                email_templates_langParameters();
                email_templates_langData.Update(items, email_templates_langOperations);
                if (email_templates_langShowErrors(items, col))
                    Response.Redirect(RedirectUrl);
                else
                    BindAllowed = false;
            }
            catch (Exception ex)
            {
                System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(email_templates_langRepeater.Controls[0].FindControl("ErrorLabel"));
                PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(email_templates_langRepeater.Controls[0].FindControl("email_templates_langError"));
                RowError.Visible = true;
                Error.Text = "DataProvider:" + ex.Message;
                BindAllowed=false;
            }
//End EditableGrid email_templates_lang Update

//EditableGrid email_templates_lang AfterSubmit @29-17BF2645
        else
            email_templates_langShowErrors(items, col);
        }
        if (BindAllowed)
            email_templates_langBind();
    }
//End EditableGrid email_templates_lang AfterSubmit

//OnInit Event @1-42CC448C
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        email_templates_langContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        email_templates_langData = new email_templates_langDataProvider();
        email_templates_langOperations = new FormSupportedOperations(false, true, false, true, false);
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

