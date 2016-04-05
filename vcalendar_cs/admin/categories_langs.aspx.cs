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

namespace calendar.admin.categories_langs{ //Namespace @1-756311E1

//Forms Definition @1-C2A7FF7D
public partial class categories_langsPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-32774637
    protected categories_langsDataProvider categories_langsData;
    protected int categories_langsCurrentRowNumber;
    protected bool categories_langsIsSubmitted = false;
    protected NameValueCollection categories_langsErrors=new NameValueCollection();
    protected FormSupportedOperations categories_langsOperations;
    protected System.Resources.ResourceManager rm;
    protected string categories_langsContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-4230528A
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            JavaScriptLabel.Text=item.JavaScriptLabel.GetFormattedValue();
            categories_langsBind();
    }
//End Page_Load Event BeforeIsPostBack

//Page categories_langs Event BeforeShow. Action Custom Code @26-2A29BDB7
    // -------------------------
	if (CommonFunctions.CCGetFromGet("category_id","").Length == 0)
		JavaScriptLabel.Text = "<script language=\"JavaScript\">window.opener.location.reload(); self.close();</script>";
    // -------------------------
//End Page categories_langs Event BeforeShow. Action Custom Code

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

//EditableGrid categories_langs Bind @3-73A140E5
    protected void categories_langsBind()
    {
        if(categories_langsOperations.None) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"categories_langs",typeof(categories_langsDataProvider.SortFields), 50, 100);
        }
//End EditableGrid categories_langs Bind

//EditableGrid Form categories_langs BeforeShow tail @3-F4F81909
        categories_langsParameters();
        categories_langsData.SortField = (categories_langsDataProvider.SortFields)ViewState["categories_langsSortField"];
        categories_langsData.SortDir = (SortDirections)ViewState["categories_langsSortDir"];
        categories_langsData.PageNumber = (int)ViewState["categories_langsPageNumber"];
        categories_langsData.RecordsPerPage = (int)ViewState["categories_langsPageSize"];
        categories_langsRepeater.DataSource = categories_langsData.GetResultSet(out PagesCount, categories_langsOperations);
        ViewState["categories_langsPagesCount"] = PagesCount;
        ViewState["categories_langsFormState"] = new Hashtable();
        ViewState["categories_langsRowState"] = new Hashtable();
        categories_langsRepeater.DataBind();
        FooterIndex = categories_langsRepeater.Controls.Count - 1;
        categories_langsItem item=new categories_langsItem();


        categories_langsRepeater.Controls[FooterIndex].FindControl("categories_langsButton_Submit").Visible = categories_langsOperations.Editable;
        if (!((IEnumerable)categories_langsRepeater.DataSource).GetEnumerator().MoveNext())
            categories_langsRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = true;
        if (categories_langsErrors.Count > 0)
        {
            System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(categories_langsRepeater.Controls[0].FindControl("ErrorLabel"));
            PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(categories_langsRepeater.Controls[0].FindControl("categories_langsError"));
            RowError.Visible = true;
            foreach(string msg in categories_langsErrors)
                Error.Text += categories_langsErrors[msg] + "<br/>";
        }
//End EditableGrid Form categories_langs BeforeShow tail

//EditableGrid categories_langs Bind tail @3-9B41828B
        categories_langsShowErrors(new ArrayList((ICollection)categories_langsRepeater.DataSource), categories_langsRepeater.Items);
    }
//End EditableGrid categories_langs Bind tail

//EditableGrid categories_langs Table Parameters @3-33625B65
    protected void categories_langsParameters()
    {
        try{
            categories_langsItem item=new categories_langsItem();
            categories_langsData.Urlcategory_id = IntegerParameter.GetParam("category_id", ParameterSourceType.URL, "", null, false);
        }catch{
            ControlCollection ParentControls=categories_langsRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(categories_langsRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid categories_langs: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End EditableGrid categories_langs Table Parameters

//EditableGrid categories_langs ItemDataBound event @3-922430C5
    protected void categories_langsItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        categories_langsItem DataItem=(categories_langsItem)e.Item.DataItem;
        categories_langsItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            categories_langsCurrentRowNumber ++;
            DataItem.RowId = e.Item.ItemIndex;
            Hashtable formState = (Hashtable)ViewState["categories_langsFormState"];
            Hashtable rowState = (Hashtable)ViewState["categories_langsRowState"];
            formState.Add("category_lang_idField:" + e.Item.ItemIndex.ToString(),DataItem.category_lang_idField.Value);
            rowState.Add(e.Item.ItemIndex.ToString(),DataItem.IsNew);
            ViewState[e.Item.FindControl("categories_langslanguageLabel").UniqueID] = DataItem.languageLabel.Value;
            System.Web.UI.WebControls.Literal categories_langslanguageLabel = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("categories_langslanguageLabel"));
            System.Web.UI.HtmlControls.HtmlInputHidden categories_langslanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("categories_langslanguage_id"));
            System.Web.UI.WebControls.TextBox categories_langscategory_name = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("categories_langscategory_name"));
        }
//End EditableGrid categories_langs ItemDataBound event

//EditableGrid categories_langs BeforeShowRow event @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End EditableGrid categories_langs BeforeShowRow event

//EditableGrid categories_langs BeforeShowRow event tail @3-FCB6E20C
        }
//End EditableGrid categories_langs BeforeShowRow event tail

//EditableGrid categories_langs ItemDataBound event tail @3-FCB6E20C
    }
//End EditableGrid categories_langs ItemDataBound event tail

//EditableGrid categories_langs GetRedirectUrl method @3-50ABDC88
    protected string Getcategories_langsRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "categories_langs.aspx";
        string p = parameters.ToString("GET","category_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }
    protected string Getcategories_langsRedirectUrl(string redirectString)
    {
        return Getcategories_langsRedirectUrl(redirectString ,"category_id");
    }
//End EditableGrid categories_langs GetRedirectUrl method

//EditableGrid categories_langs ShowErrors method @3-F27FD55A
    protected bool categories_langsShowErrors(ArrayList items, RepeaterItemCollection col)
    {
        bool result = true;
        foreach(categories_langsItem item in items)
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
//End EditableGrid categories_langs ShowErrors method

//EditableGrid categories_langs ItemCommand event @3-EC166C2E
    protected void categories_langsItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = categories_langsRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End EditableGrid categories_langs ItemCommand event

//Button Button_Submit OnClick. @7-0AD0678B
        if(((Control)e.CommandSource).ID == "categories_langsButton_Submit")
        {
            RedirectUrl  = Getcategories_langsRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Submit OnClick.

//Button Button_Submit OnClick tail. @7-FCB6E20C
        }
//End Button Button_Submit OnClick tail.

//EditableGrid Form categories_langs ItemCommand event tail @3-0DB6B091
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["categories_langsSortDir"]==SortDirections.Asc&&ViewState["categories_langsSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["categories_langsSortDir"]=SortDirections.Desc;
                else
                    ViewState["categories_langsSortDir"]=SortDirections.Asc;
            else
                ViewState["categories_langsSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["categories_langsSortField"]=Enum.Parse(typeof(categories_langsDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["categories_langsPageNumber"] = 1;
            BindAllowed = true;
        }

        if(e.CommandName=="Navigate"){
            ViewState["categories_langsPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }

        if(e.CommandName=="Submit"){
            categories_langsIsSubmitted = true;
            BindAllowed = true;
            RepeaterItemCollection col=categories_langsRepeater.Items;
            ArrayList items=new ArrayList();
            Hashtable formState = (Hashtable)ViewState["categories_langsFormState"];
            Hashtable rowState = (Hashtable)ViewState["categories_langsRowState"];
            categories_langsParameters();
            for(int i=0;i<col.Count;i++)
                if(col[i].ItemType == ListItemType.Item || col[i].ItemType == ListItemType.AlternatingItem){
                    System.Web.UI.WebControls.Literal categories_langslanguageLabel = (System.Web.UI.WebControls.Literal)(col[i].FindControl("categories_langslanguageLabel"));
                    System.Web.UI.HtmlControls.HtmlInputHidden categories_langslanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(col[i].FindControl("categories_langslanguage_id"));
                    System.Web.UI.WebControls.TextBox categories_langscategory_name = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("categories_langscategory_name"));
                    col[i].FindControl("RowError").Visible = false;
                    categories_langsItem item = new categories_langsItem();
                    item.RowId = col[i].ItemIndex;
                    item.IsUpdated = !col[i].Visible;
                    item.IsNew = (bool)(rowState[col[i].ItemIndex.ToString()]);
                    item.category_lang_idField.Value = (System.IComparable)formState["category_lang_idField:" + col[i].ItemIndex.ToString()];
                    item.languageLabel.Value = (System.IComparable)ViewState[categories_langslanguageLabel.UniqueID];
                    item.language_id.SetValue(categories_langslanguage_id.Value);
                    item.category_name.SetValue(categories_langscategory_name.Text);
                    items.Add(item);
                    if(EnableValidation && !item.IsEmptyItem && !item.IsDeleted)
                        BindAllowed = item.Validate(categories_langsData) && BindAllowed;
            }

//End EditableGrid Form categories_langs ItemCommand event tail

//EditableGrid categories_langs Update @3-D2110BBC
        if (BindAllowed)
            try
            {
                categories_langsParameters();
                categories_langsData.Update(items, categories_langsOperations);
                if (categories_langsShowErrors(items, col))
                    Response.Redirect(RedirectUrl);
                else
                    BindAllowed = false;
            }
            catch (Exception ex)
            {
                System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(categories_langsRepeater.Controls[0].FindControl("ErrorLabel"));
                PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(categories_langsRepeater.Controls[0].FindControl("categories_langsError"));
                RowError.Visible = true;
                Error.Text = "DataProvider:" + ex.Message;
                BindAllowed=false;
            }
//End EditableGrid categories_langs Update

//EditableGrid categories_langs AfterSubmit @3-D3424016
        else
            categories_langsShowErrors(items, col);
        }
        if (BindAllowed)
            categories_langsBind();
    }
//End EditableGrid categories_langs AfterSubmit

//OnInit Event @1-61B03387
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        categories_langsContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        categories_langsData = new categories_langsDataProvider();
        categories_langsOperations = new FormSupportedOperations(false, true, false, true, false);
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

