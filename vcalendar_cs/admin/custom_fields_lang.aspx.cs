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

namespace calendar.admin.custom_fields_lang{ //Namespace @1-28292626

//Forms Definition @1-CDB37A72
public partial class custom_fields_langPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-C3F46902
    protected custom_fields_langsDataProvider custom_fields_langsData;
    protected int custom_fields_langsCurrentRowNumber;
    protected bool custom_fields_langsIsSubmitted = false;
    protected NameValueCollection custom_fields_langsErrors=new NameValueCollection();
    protected FormSupportedOperations custom_fields_langsOperations;
    protected System.Resources.ResourceManager rm;
    protected string custom_fields_langContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-0748751F
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            JavaScriptLabel.Text=item.JavaScriptLabel.GetFormattedValue();
            custom_fields_langsBind();
    }
//End Page_Load Event BeforeIsPostBack

//Page custom_fields_lang Event BeforeShow. Action Custom Code @25-2A29BDB7
    // -------------------------
		if (CommonFunctions.CCGetFromGet("field_id","") == "")
			JavaScriptLabel.Text = "<script language='JavaScript'>window.opener.location.reload();self.close()</script>";
    // -------------------------
//End Page custom_fields_lang Event BeforeShow. Action Custom Code

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

//EditableGrid custom_fields_langs Bind @5-60367AC7
    protected void custom_fields_langsBind()
    {
        if(custom_fields_langsOperations.None) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"custom_fields_langs",typeof(custom_fields_langsDataProvider.SortFields), 10, 100);
        }
//End EditableGrid custom_fields_langs Bind

//EditableGrid Form custom_fields_langs BeforeShow tail @5-CA0445B6
        custom_fields_langsParameters();
        custom_fields_langsData.SortField = (custom_fields_langsDataProvider.SortFields)ViewState["custom_fields_langsSortField"];
        custom_fields_langsData.SortDir = (SortDirections)ViewState["custom_fields_langsSortDir"];
        custom_fields_langsData.PageNumber = (int)ViewState["custom_fields_langsPageNumber"];
        custom_fields_langsData.RecordsPerPage = (int)ViewState["custom_fields_langsPageSize"];
        custom_fields_langsRepeater.DataSource = custom_fields_langsData.GetResultSet(out PagesCount, custom_fields_langsOperations);
        ViewState["custom_fields_langsPagesCount"] = PagesCount;
        ViewState["custom_fields_langsFormState"] = new Hashtable();
        ViewState["custom_fields_langsRowState"] = new Hashtable();
        custom_fields_langsRepeater.DataBind();
        FooterIndex = custom_fields_langsRepeater.Controls.Count - 1;
        custom_fields_langsItem item=new custom_fields_langsItem();


        custom_fields_langsRepeater.Controls[FooterIndex].FindControl("custom_fields_langsButton_Submit").Visible = custom_fields_langsOperations.Editable;
        if (!((IEnumerable)custom_fields_langsRepeater.DataSource).GetEnumerator().MoveNext())
            custom_fields_langsRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = true;
        if (custom_fields_langsErrors.Count > 0)
        {
            System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(custom_fields_langsRepeater.Controls[0].FindControl("ErrorLabel"));
            PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(custom_fields_langsRepeater.Controls[0].FindControl("custom_fields_langsError"));
            RowError.Visible = true;
            foreach(string msg in custom_fields_langsErrors)
                Error.Text += custom_fields_langsErrors[msg] + "<br/>";
        }
//End EditableGrid Form custom_fields_langs BeforeShow tail

//EditableGrid custom_fields_langs Bind tail @5-E60466BA
        custom_fields_langsShowErrors(new ArrayList((ICollection)custom_fields_langsRepeater.DataSource), custom_fields_langsRepeater.Items);
    }
//End EditableGrid custom_fields_langs Bind tail

//EditableGrid custom_fields_langs Table Parameters @5-A94DCE05
    protected void custom_fields_langsParameters()
    {
        try{
            custom_fields_langsItem item=new custom_fields_langsItem();
            custom_fields_langsData.Urlfield_id = IntegerParameter.GetParam("field_id", ParameterSourceType.URL, "", null, false);
        }catch{
            ControlCollection ParentControls=custom_fields_langsRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(custom_fields_langsRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid custom_fields_langs: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End EditableGrid custom_fields_langs Table Parameters

//EditableGrid custom_fields_langs ItemDataBound event @5-69866BC7
    protected void custom_fields_langsItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        custom_fields_langsItem DataItem=(custom_fields_langsItem)e.Item.DataItem;
        custom_fields_langsItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            custom_fields_langsCurrentRowNumber ++;
            DataItem.RowId = e.Item.ItemIndex;
            Hashtable formState = (Hashtable)ViewState["custom_fields_langsFormState"];
            Hashtable rowState = (Hashtable)ViewState["custom_fields_langsRowState"];
            formState.Add("field_lang_idField:" + e.Item.ItemIndex.ToString(),DataItem.field_lang_idField.Value);
            rowState.Add(e.Item.ItemIndex.ToString(),DataItem.IsNew);
            ViewState[e.Item.FindControl("custom_fields_langslanguageLabel").UniqueID] = DataItem.languageLabel.Value;
            System.Web.UI.WebControls.Literal custom_fields_langslanguageLabel = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("custom_fields_langslanguageLabel"));
            System.Web.UI.HtmlControls.HtmlInputHidden custom_fields_langslanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("custom_fields_langslanguage_id"));
            System.Web.UI.WebControls.TextBox custom_fields_langsfield_translation = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("custom_fields_langsfield_translation"));
        }
//End EditableGrid custom_fields_langs ItemDataBound event

//EditableGrid custom_fields_langs BeforeShowRow event @5-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End EditableGrid custom_fields_langs BeforeShowRow event

//EditableGrid custom_fields_langs BeforeShowRow event tail @5-FCB6E20C
        }
//End EditableGrid custom_fields_langs BeforeShowRow event tail

//EditableGrid custom_fields_langs ItemDataBound event tail @5-FCB6E20C
    }
//End EditableGrid custom_fields_langs ItemDataBound event tail

//EditableGrid custom_fields_langs GetRedirectUrl method @5-EA3FAF94
    protected string Getcustom_fields_langsRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("None","field_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }
    protected string Getcustom_fields_langsRedirectUrl(string redirectString)
    {
        return Getcustom_fields_langsRedirectUrl(redirectString ,"field_id");
    }
//End EditableGrid custom_fields_langs GetRedirectUrl method

//EditableGrid custom_fields_langs ShowErrors method @5-3BBA9FC2
    protected bool custom_fields_langsShowErrors(ArrayList items, RepeaterItemCollection col)
    {
        bool result = true;
        foreach(custom_fields_langsItem item in items)
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
//End EditableGrid custom_fields_langs ShowErrors method

//EditableGrid custom_fields_langs ItemCommand event @5-B7D23088
    protected void custom_fields_langsItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = custom_fields_langsRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End EditableGrid custom_fields_langs ItemCommand event

//Button Button_Submit OnClick. @11-41FB4F1A
        if(((Control)e.CommandSource).ID == "custom_fields_langsButton_Submit")
        {
            RedirectUrl  = Getcustom_fields_langsRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Submit OnClick.

//Button Button_Submit OnClick tail. @11-FCB6E20C
        }
//End Button Button_Submit OnClick tail.

//EditableGrid Form custom_fields_langs ItemCommand event tail @5-0163ACAA
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["custom_fields_langsSortDir"]==SortDirections.Asc&&ViewState["custom_fields_langsSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["custom_fields_langsSortDir"]=SortDirections.Desc;
                else
                    ViewState["custom_fields_langsSortDir"]=SortDirections.Asc;
            else
                ViewState["custom_fields_langsSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["custom_fields_langsSortField"]=Enum.Parse(typeof(custom_fields_langsDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["custom_fields_langsPageNumber"] = 1;
            BindAllowed = true;
        }

        if(e.CommandName=="Navigate"){
            ViewState["custom_fields_langsPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }

        if(e.CommandName=="Submit"){
            custom_fields_langsIsSubmitted = true;
            BindAllowed = true;
            RepeaterItemCollection col=custom_fields_langsRepeater.Items;
            ArrayList items=new ArrayList();
            Hashtable formState = (Hashtable)ViewState["custom_fields_langsFormState"];
            Hashtable rowState = (Hashtable)ViewState["custom_fields_langsRowState"];
            custom_fields_langsParameters();
            for(int i=0;i<col.Count;i++)
                if(col[i].ItemType == ListItemType.Item || col[i].ItemType == ListItemType.AlternatingItem){
                    System.Web.UI.WebControls.Literal custom_fields_langslanguageLabel = (System.Web.UI.WebControls.Literal)(col[i].FindControl("custom_fields_langslanguageLabel"));
                    System.Web.UI.HtmlControls.HtmlInputHidden custom_fields_langslanguage_id = (System.Web.UI.HtmlControls.HtmlInputHidden)(col[i].FindControl("custom_fields_langslanguage_id"));
                    System.Web.UI.WebControls.TextBox custom_fields_langsfield_translation = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("custom_fields_langsfield_translation"));
                    col[i].FindControl("RowError").Visible = false;
                    custom_fields_langsItem item = new custom_fields_langsItem();
                    item.RowId = col[i].ItemIndex;
                    item.IsUpdated = !col[i].Visible;
                    item.IsNew = (bool)(rowState[col[i].ItemIndex.ToString()]);
                    item.field_lang_idField.Value = (System.IComparable)formState["field_lang_idField:" + col[i].ItemIndex.ToString()];
                    item.languageLabel.Value = (System.IComparable)ViewState[custom_fields_langslanguageLabel.UniqueID];
                    item.language_id.SetValue(custom_fields_langslanguage_id.Value);
                    item.field_translation.SetValue(custom_fields_langsfield_translation.Text);
                    items.Add(item);
                    if(EnableValidation && !item.IsEmptyItem && !item.IsDeleted)
                        BindAllowed = item.Validate(custom_fields_langsData) && BindAllowed;
            }

//End EditableGrid Form custom_fields_langs ItemCommand event tail

//EditableGrid custom_fields_langs Update @5-3BA8B0D4
        if (BindAllowed)
            try
            {
                custom_fields_langsParameters();
                custom_fields_langsData.Update(items, custom_fields_langsOperations);
                if (custom_fields_langsShowErrors(items, col))
                    Response.Redirect(RedirectUrl);
                else
                    BindAllowed = false;
            }
            catch (Exception ex)
            {
                System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(custom_fields_langsRepeater.Controls[0].FindControl("ErrorLabel"));
                PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(custom_fields_langsRepeater.Controls[0].FindControl("custom_fields_langsError"));
                RowError.Visible = true;
                Error.Text = "DataProvider:" + ex.Message;
                BindAllowed=false;
            }
//End EditableGrid custom_fields_langs Update

//EditableGrid custom_fields_langs AfterSubmit @5-B2B4C1DC
        else
            custom_fields_langsShowErrors(items, col);
        }
        if (BindAllowed)
            custom_fields_langsBind();
    }
//End EditableGrid custom_fields_langs AfterSubmit

//OnInit Event @1-7B7A933F
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        custom_fields_langContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        custom_fields_langsData = new custom_fields_langsDataProvider();
        custom_fields_langsOperations = new FormSupportedOperations(false, true, false, true, false);
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

