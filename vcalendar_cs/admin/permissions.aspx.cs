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

namespace calendar.admin.permissions{ //Namespace @1-8F33A85E

//Forms Definition @1-721B1E00
public partial class permissionsPage : System.Web.UI.Page
{
//End Forms Definition

	public string category = "0";

//Forms Objects @1-BD6AB807
    protected permissionsDataProvider permissionsData;
    protected int permissionsCurrentRowNumber;
    protected bool permissionsIsSubmitted = false;
    protected NameValueCollection permissionsErrors=new NameValueCollection();
    protected FormSupportedOperations permissionsOperations;
    protected System.Resources.ResourceManager rm;
    protected string permissionsContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-10C31096
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            permissionsBind();
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

//EditableGrid permissions Bind @3-F1C21B29
    protected void permissionsBind()
    {
        if(permissionsOperations.None) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"permissions",typeof(permissionsDataProvider.SortFields), 0, 100);
        }
//End EditableGrid permissions Bind

//EditableGrid Form permissions BeforeShow tail @3-BF3E1CA5
        permissionsParameters();
        permissionsData.SortField = (permissionsDataProvider.SortFields)ViewState["permissionsSortField"];
        permissionsData.SortDir = (SortDirections)ViewState["permissionsSortDir"];
        permissionsData.PageNumber = (int)ViewState["permissionsPageNumber"];
        permissionsData.RecordsPerPage = (int)ViewState["permissionsPageSize"];
        permissionsRepeater.DataSource = permissionsData.GetResultSet(out PagesCount, permissionsOperations);
        ViewState["permissionsPagesCount"] = PagesCount;
        ViewState["permissionsFormState"] = new Hashtable();
        ViewState["permissionsRowState"] = new Hashtable();
        permissionsRepeater.DataBind();
        FooterIndex = permissionsRepeater.Controls.Count - 1;
        permissionsItem item=new permissionsItem();


        permissionsRepeater.Controls[FooterIndex].FindControl("permissionsButton_Submit").Visible = permissionsOperations.Editable;
        if (!((IEnumerable)permissionsRepeater.DataSource).GetEnumerator().MoveNext())
            permissionsRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = true;
        if (permissionsErrors.Count > 0)
        {
            System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(permissionsRepeater.Controls[0].FindControl("ErrorLabel"));
            PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(permissionsRepeater.Controls[0].FindControl("permissionsError"));
            RowError.Visible = true;
            foreach(string msg in permissionsErrors)
                Error.Text += permissionsErrors[msg] + "<br/>";
        }
//End EditableGrid Form permissions BeforeShow tail

//EditableGrid permissions Bind tail @3-CA14DDEA
        permissionsShowErrors(new ArrayList((ICollection)permissionsRepeater.DataSource), permissionsRepeater.Items);
    }
//End EditableGrid permissions Bind tail

//EditableGrid permissions Table Parameters @3-1186D827
    protected void permissionsParameters()
    {
        try{
            permissionsItem item=new permissionsItem();
            permissionsData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            permissionsData.Ctrlperms_value = IntegerParameter.GetParam(item.perms_value.Value, ParameterSourceType.Control, "", null, false);
        }catch{
            ControlCollection ParentControls=permissionsRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(permissionsRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid permissions: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End EditableGrid permissions Table Parameters

//EditableGrid permissions ItemDataBound event @3-DCCD06AE
    protected void permissionsItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        permissionsItem DataItem=(permissionsItem)e.Item.DataItem;
        permissionsItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            permissionsCurrentRowNumber ++;
            DataItem.RowId = e.Item.ItemIndex;
            Hashtable formState = (Hashtable)ViewState["permissionsFormState"];
            Hashtable rowState = (Hashtable)ViewState["permissionsRowState"];
            formState.Add("permission_idField:" + e.Item.ItemIndex.ToString(),DataItem.permission_idField.Value);
            formState.Add("permission_lang_idField:" + e.Item.ItemIndex.ToString(),DataItem.permission_lang_idField.Value);
            rowState.Add(e.Item.ItemIndex.ToString(),DataItem.IsNew);
            ViewState[e.Item.FindControl("permissionspermission_category").UniqueID] = DataItem.permission_category.Value;
            ViewState[e.Item.FindControl("permissionspermission_desc").UniqueID] = DataItem.permission_desc.Value;
            System.Web.UI.WebControls.PlaceHolder permissionspermission_category_panel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("permissionspermission_category_panel"));
            System.Web.UI.WebControls.Literal permissionspermission_category = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("permissionspermission_category"));
            System.Web.UI.WebControls.Literal permissionspermission_desc = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("permissionspermission_desc"));
            System.Web.UI.HtmlControls.HtmlSelect permissionsperms_value = (System.Web.UI.HtmlControls.HtmlSelect)(e.Item.FindControl("permissionsperms_value"));
            System.Web.UI.HtmlControls.HtmlInputHidden permissionsperm_type = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("permissionsperm_type"));
            DataItem.perms_valueItems.SetSelection(DataItem.perms_value.GetFormattedValue());
            if(DataItem.perms_valueItems.GetSelectedItem() != null)
                permissionsperms_value.SelectedIndex = -1;
            DataItem.perms_valueItems.CopyTo(permissionsperms_value.Items);
        }
//End EditableGrid permissions ItemDataBound event

//permissions control Before Show @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End permissions control Before Show

//Get Control @7-E56A5E6C
            System.Web.UI.HtmlControls.HtmlSelect permissionsperms_value = (System.Web.UI.HtmlControls.HtmlSelect)(e.Item.FindControl("permissionsperms_value"));
//End Get Control

//ListBox perms_value Event BeforeShow. Action Custom Code @44-2A29BDB7
    // -------------------------
	int[] Key_array = new int[] {0,10,50,100};
	string[] Item_array = new string[] {((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_everyone"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_registered"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_owner"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_admin")};
	int[] val_array = new int[]{};

	System.Web.UI.HtmlControls.HtmlInputHidden permissionsperm_type = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("permissionsperm_type"));
	switch (permissionsperm_type.Value)
	{
		case "1": val_array = new int[]{0,1,2,3}; break;
		case "2": val_array = new int[]{1,3}; break;
		case "3": val_array = new int[]{0,1,3}; break;
	}
	
	permissionsperms_value.Items.Clear();
	for (int i=0; i<val_array.Length; i++)
		permissionsperms_value.Items.Add(new ListItem(Item_array[val_array[i]], Key_array[val_array[i]].ToString()));
	permissionsperms_value.Value = DataItem.perms_value.Value.ToString();
    // -------------------------
//End ListBox perms_value Event BeforeShow. Action Custom Code

//permissions control Before Show tail @3-FCB6E20C
        }
//End permissions control Before Show tail

//EditableGrid permissions BeforeShowRow event @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End EditableGrid permissions BeforeShowRow event

//EditableGrid permissions Event BeforeShowRow. Action Custom Code @12-2A29BDB7
    // -------------------------
	string[] conf_category = new string[] {"", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_general"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_public_events"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_private_events")};

	System.Web.UI.WebControls.PlaceHolder permissionspermission_category_panel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("permissionspermission_category_panel"));
	System.Web.UI.WebControls.Literal permissionspermission_category = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("permissionspermission_category"));
	if (category == permissionspermission_category.Text) {
		permissionspermission_category_panel.Visible = false;
	} else {
		permissionspermission_category_panel.Visible = true;
		category = permissionspermission_category.Text;
		permissionspermission_category.Text = conf_category[Convert.ToInt32(category)];
	}
    // -------------------------
//End EditableGrid permissions Event BeforeShowRow. Action Custom Code

//EditableGrid permissions BeforeShowRow event tail @3-FCB6E20C
        }
//End EditableGrid permissions BeforeShowRow event tail

//EditableGrid permissions ItemDataBound event tail @3-FCB6E20C
    }
//End EditableGrid permissions ItemDataBound event tail

//EditableGrid permissions GetRedirectUrl method @3-8FA2D50E
    protected string GetpermissionsRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }
    protected string GetpermissionsRedirectUrl(string redirectString)
    {
        return GetpermissionsRedirectUrl(redirectString ,"");
    }
//End EditableGrid permissions GetRedirectUrl method

//EditableGrid permissions ShowErrors method @3-E5DD99A9
    protected bool permissionsShowErrors(ArrayList items, RepeaterItemCollection col)
    {
        bool result = true;
        foreach(permissionsItem item in items)
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
//End EditableGrid permissions ShowErrors method

//EditableGrid permissions ItemCommand event @3-B8CCE39D
    protected void permissionsItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = permissionsRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End EditableGrid permissions ItemCommand event

//Button Button_Submit OnClick. @9-650CAF66
        if(((Control)e.CommandSource).ID == "permissionsButton_Submit")
        {
            RedirectUrl  = GetpermissionsRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Submit OnClick.

//Button Button_Submit OnClick tail. @9-FCB6E20C
        }
//End Button Button_Submit OnClick tail.

//EditableGrid Form permissions ItemCommand event tail @3-E8A2C8FD
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["permissionsSortDir"]==SortDirections.Asc&&ViewState["permissionsSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["permissionsSortDir"]=SortDirections.Desc;
                else
                    ViewState["permissionsSortDir"]=SortDirections.Asc;
            else
                ViewState["permissionsSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["permissionsSortField"]=Enum.Parse(typeof(permissionsDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["permissionsPageNumber"] = 1;
            BindAllowed = true;
        }

        if(e.CommandName=="Navigate"){
            ViewState["permissionsPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }

        if(e.CommandName=="Submit"){
            permissionsIsSubmitted = true;
            BindAllowed = true;
            RepeaterItemCollection col=permissionsRepeater.Items;
            ArrayList items=new ArrayList();
            Hashtable formState = (Hashtable)ViewState["permissionsFormState"];
            Hashtable rowState = (Hashtable)ViewState["permissionsRowState"];
            permissionsParameters();
            for(int i=0;i<col.Count;i++)
                if(col[i].ItemType == ListItemType.Item || col[i].ItemType == ListItemType.AlternatingItem){
                    System.Web.UI.WebControls.PlaceHolder permissionspermission_category_panel = (System.Web.UI.WebControls.PlaceHolder)(col[i].FindControl("permissionspermission_category_panel"));
                    System.Web.UI.WebControls.Literal permissionspermission_category = (System.Web.UI.WebControls.Literal)(col[i].FindControl("permissionspermission_category"));
                    System.Web.UI.WebControls.Literal permissionspermission_desc = (System.Web.UI.WebControls.Literal)(col[i].FindControl("permissionspermission_desc"));
                    System.Web.UI.HtmlControls.HtmlSelect permissionsperms_value = (System.Web.UI.HtmlControls.HtmlSelect)(col[i].FindControl("permissionsperms_value"));
                    System.Web.UI.HtmlControls.HtmlInputHidden permissionsperm_type = (System.Web.UI.HtmlControls.HtmlInputHidden)(col[i].FindControl("permissionsperm_type"));
                    col[i].FindControl("RowError").Visible = false;
                    permissionsItem item = new permissionsItem();
                    item.RowId = col[i].ItemIndex;
                    item.IsUpdated = !col[i].Visible;
                    item.IsNew = (bool)(rowState[col[i].ItemIndex.ToString()]);
                    item.permission_idField.Value = (System.IComparable)formState["permission_idField:" + col[i].ItemIndex.ToString()];
                    item.permission_lang_idField.Value = (System.IComparable)formState["permission_lang_idField:" + col[i].ItemIndex.ToString()];
                    item.permission_category.Value = (System.IComparable)ViewState[permissionspermission_category.UniqueID];
                    item.permission_desc.Value = (System.IComparable)ViewState[permissionspermission_desc.UniqueID];
                    item.perms_value.SetValue(permissionsperms_value.Value);
                    item.perms_valueItems.CopyFrom(permissionsperms_value.Items);
                    try{
                    item.perm_type.SetValue(permissionsperm_type.Value);
                    }catch(ArgumentException){
                    item.errors.Add("perm_type",String.Format(Resources.strings.CCS_IncorrectValue,"perm_type"));}
                    items.Add(item);
                    if(EnableValidation && !item.IsEmptyItem && !item.IsDeleted)
                        BindAllowed = item.Validate(permissionsData) && BindAllowed;
            }

//End EditableGrid Form permissions ItemCommand event tail

//EditableGrid permissions Update @3-A5EBDA2D
        if (BindAllowed)
            try
            {
                permissionsParameters();
                permissionsData.Update(items, permissionsOperations);
                if (permissionsShowErrors(items, col))
                    Response.Redirect(RedirectUrl);
                else
                    BindAllowed = false;
            }
            catch (Exception ex)
            {
                System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(permissionsRepeater.Controls[0].FindControl("ErrorLabel"));
                PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(permissionsRepeater.Controls[0].FindControl("permissionsError"));
                RowError.Visible = true;
                Error.Text = "DataProvider:" + ex.Message;
                BindAllowed=false;
            }
//End EditableGrid permissions Update

//EditableGrid permissions AfterSubmit @3-7D917DF6
        else
            permissionsShowErrors(items, col);
        }
        if (BindAllowed)
            permissionsBind();
    }
//End EditableGrid permissions AfterSubmit

//OnInit Event @1-DE0A52AA
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        permissionsContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        permissionsData = new permissionsDataProvider();
        permissionsOperations = new FormSupportedOperations(false, true, false, true, false);
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

