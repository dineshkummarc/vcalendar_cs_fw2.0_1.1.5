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

namespace calendar.admin.content_lang{ //Namespace @1-FE60DC11

//Forms Definition @1-8D189692
public partial class content_langPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-230DA4DE
    protected contents_langDataProvider contents_langData;
    protected int contents_langCurrentRowNumber;
    protected bool contents_langIsSubmitted = false;
    protected NameValueCollection contents_langErrors=new NameValueCollection();
    protected FormSupportedOperations contents_langOperations;
    protected System.Resources.ResourceManager rm;
    protected string content_langContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-41134A35
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            JavaScriptLabel.Text=item.JavaScriptLabel.GetFormattedValue();
            close.Text=item.close.GetFormattedValue();
            contents_langBind();
    }
//End Page_Load Event BeforeIsPostBack

//Page content_lang Event BeforeShow. Action Custom Code @51-2A29BDB7
    // -------------------------
 	if (CommonFunctions.CCGetFromGet("content_id","").Length == 0)
		JavaScriptLabel.Text = "<script language=\"JavaScript\">window.opener.location.reload(); self.close();</script>";
    // -------------------------
//End Page content_lang Event BeforeShow. Action Custom Code

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

//EditableGrid contents_lang Bind @29-3936A9EB
    protected void contents_langBind()
    {
        if(contents_langOperations.None) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"contents_lang",typeof(contents_langDataProvider.SortFields), 10, 100);
        }
//End EditableGrid contents_lang Bind

//EditableGrid Form contents_lang BeforeShow tail @29-6DDED036
        contents_langParameters();
        contents_langData.SortField = (contents_langDataProvider.SortFields)ViewState["contents_langSortField"];
        contents_langData.SortDir = (SortDirections)ViewState["contents_langSortDir"];
        contents_langData.PageNumber = (int)ViewState["contents_langPageNumber"];
        contents_langData.RecordsPerPage = (int)ViewState["contents_langPageSize"];
        contents_langRepeater.DataSource = contents_langData.GetResultSet(out PagesCount, contents_langOperations);
        ViewState["contents_langPagesCount"] = PagesCount;
        ViewState["contents_langFormState"] = new Hashtable();
        ViewState["contents_langRowState"] = new Hashtable();
        contents_langRepeater.DataBind();
        FooterIndex = contents_langRepeater.Controls.Count - 1;
        contents_langItem item=new contents_langItem();


        contents_langRepeater.Controls[FooterIndex].FindControl("contents_langButton_Submit").Visible = contents_langOperations.Editable;
        if (!((IEnumerable)contents_langRepeater.DataSource).GetEnumerator().MoveNext())
            contents_langRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = true;
        if (contents_langErrors.Count > 0)
        {
            System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(contents_langRepeater.Controls[0].FindControl("ErrorLabel"));
            PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(contents_langRepeater.Controls[0].FindControl("contents_langError"));
            RowError.Visible = true;
            foreach(string msg in contents_langErrors)
                Error.Text += contents_langErrors[msg] + "<br/>";
        }
//End EditableGrid Form contents_lang BeforeShow tail

//EditableGrid contents_lang Bind tail @29-FB0F324D
        contents_langShowErrors(new ArrayList((ICollection)contents_langRepeater.DataSource), contents_langRepeater.Items);
    }
//End EditableGrid contents_lang Bind tail

//EditableGrid contents_lang Table Parameters @29-D9DE810D
    protected void contents_langParameters()
    {
        try{
            contents_langItem item=new contents_langItem();
            contents_langData.Urlcontent_id = IntegerParameter.GetParam("content_id", ParameterSourceType.URL, "", null, false);
        }catch{
            ControlCollection ParentControls=contents_langRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(contents_langRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid contents_lang: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End EditableGrid contents_lang Table Parameters

//EditableGrid contents_lang ItemDataBound event @29-10D3562A
    protected void contents_langItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        contents_langItem DataItem=(contents_langItem)e.Item.DataItem;
        contents_langItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            contents_langCurrentRowNumber ++;
            DataItem.RowId = e.Item.ItemIndex;
            Hashtable formState = (Hashtable)ViewState["contents_langFormState"];
            Hashtable rowState = (Hashtable)ViewState["contents_langRowState"];
            formState.Add("content_lang_idField:" + e.Item.ItemIndex.ToString(),DataItem.content_lang_idField.Value);
            rowState.Add(e.Item.ItemIndex.ToString(),DataItem.IsNew);
            ViewState[e.Item.FindControl("contents_langlanguageLabel").UniqueID] = DataItem.languageLabel.Value;
            System.Web.UI.WebControls.Literal contents_langlanguageLabel = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("contents_langlanguageLabel"));
            System.Web.UI.HtmlControls.HtmlInputHidden contents_langlanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("contents_langlanguage_id"));
            System.Web.UI.WebControls.TextBox contents_langcontent_desc = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("contents_langcontent_desc"));
            System.Web.UI.WebControls.TextBox contents_langcontent_value = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("contents_langcontent_value"));
        }
//End EditableGrid contents_lang ItemDataBound event

//EditableGrid contents_lang BeforeShowRow event @29-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End EditableGrid contents_lang BeforeShowRow event

//EditableGrid contents_lang BeforeShowRow event tail @29-FCB6E20C
        }
//End EditableGrid contents_lang BeforeShowRow event tail

//EditableGrid contents_lang ItemDataBound event tail @29-FCB6E20C
    }
//End EditableGrid contents_lang ItemDataBound event tail

//EditableGrid contents_lang GetRedirectUrl method @29-3D1C6565
    protected string Getcontents_langRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET","content_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }
    protected string Getcontents_langRedirectUrl(string redirectString)
    {
        return Getcontents_langRedirectUrl(redirectString ,"content_id");
    }
//End EditableGrid contents_lang GetRedirectUrl method

//EditableGrid contents_lang ShowErrors method @29-2FD160FC
    protected bool contents_langShowErrors(ArrayList items, RepeaterItemCollection col)
    {
        bool result = true;
        foreach(contents_langItem item in items)
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
//End EditableGrid contents_lang ShowErrors method

//EditableGrid contents_lang ItemCommand event @29-1636DB72
    protected void contents_langItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = contents_langRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End EditableGrid contents_lang ItemCommand event

//Button Button_Submit OnClick. @39-61075F37
        if(((Control)e.CommandSource).ID == "contents_langButton_Submit")
        {
            RedirectUrl  = Getcontents_langRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Submit OnClick.

//Button Button_Submit OnClick tail. @39-FCB6E20C
        }
//End Button Button_Submit OnClick tail.

//EditableGrid Form contents_lang ItemCommand event tail @29-A89F3667
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["contents_langSortDir"]==SortDirections.Asc&&ViewState["contents_langSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["contents_langSortDir"]=SortDirections.Desc;
                else
                    ViewState["contents_langSortDir"]=SortDirections.Asc;
            else
                ViewState["contents_langSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["contents_langSortField"]=Enum.Parse(typeof(contents_langDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["contents_langPageNumber"] = 1;
            BindAllowed = true;
        }

        if(e.CommandName=="Navigate"){
            ViewState["contents_langPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }

        if(e.CommandName=="Submit"){
            contents_langIsSubmitted = true;
            BindAllowed = true;
            RepeaterItemCollection col=contents_langRepeater.Items;
            ArrayList items=new ArrayList();
            Hashtable formState = (Hashtable)ViewState["contents_langFormState"];
            Hashtable rowState = (Hashtable)ViewState["contents_langRowState"];
            contents_langParameters();
            for(int i=0;i<col.Count;i++)
                if(col[i].ItemType == ListItemType.Item || col[i].ItemType == ListItemType.AlternatingItem){
                    System.Web.UI.WebControls.Literal contents_langlanguageLabel = (System.Web.UI.WebControls.Literal)(col[i].FindControl("contents_langlanguageLabel"));
                    System.Web.UI.HtmlControls.HtmlInputHidden contents_langlanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(col[i].FindControl("contents_langlanguage_id"));
                    System.Web.UI.WebControls.TextBox contents_langcontent_desc = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("contents_langcontent_desc"));
                    System.Web.UI.WebControls.TextBox contents_langcontent_value = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("contents_langcontent_value"));
                    col[i].FindControl("RowError").Visible = false;
                    contents_langItem item = new contents_langItem();
                    item.RowId = col[i].ItemIndex;
                    item.IsUpdated = !col[i].Visible;
                    item.IsNew = (bool)(rowState[col[i].ItemIndex.ToString()]);
                    item.content_lang_idField.Value = (System.IComparable)formState["content_lang_idField:" + col[i].ItemIndex.ToString()];
                    item.languageLabel.Value = (System.IComparable)ViewState[contents_langlanguageLabel.UniqueID];
                    item.language_id.SetValue(contents_langlanguage_id.Value);
                    item.content_desc.SetValue(contents_langcontent_desc.Text);
                    item.content_value.SetValue(contents_langcontent_value.Text);
                    items.Add(item);
                    if(EnableValidation && !item.IsEmptyItem && !item.IsDeleted)
                        BindAllowed = item.Validate(contents_langData) && BindAllowed;
            }

//End EditableGrid Form contents_lang ItemCommand event tail

//EditableGrid contents_lang Update @29-EFEC6EC1
        if (BindAllowed)
            try
            {
                contents_langParameters();
                contents_langData.Update(items, contents_langOperations);
                if (contents_langShowErrors(items, col))
                    Response.Redirect(RedirectUrl);
                else
                    BindAllowed = false;
            }
            catch (Exception ex)
            {
                System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(contents_langRepeater.Controls[0].FindControl("ErrorLabel"));
                PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(contents_langRepeater.Controls[0].FindControl("contents_langError"));
                RowError.Visible = true;
                Error.Text = "DataProvider:" + ex.Message;
                BindAllowed=false;
            }
//End EditableGrid contents_lang Update

//EditableGrid contents_lang AfterSubmit @29-D8339937
        else
            contents_langShowErrors(items, col);
        }
        if (BindAllowed)
            contents_langBind();
    }
//End EditableGrid contents_lang AfterSubmit

//OnInit Event @1-6020C7FD
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        content_langContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        contents_langData = new contents_langDataProvider();
        contents_langOperations = new FormSupportedOperations(false, true, false, true, false);
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

