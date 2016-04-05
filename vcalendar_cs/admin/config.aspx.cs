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

namespace calendar.admin.config{ //Namespace @1-3BCF5976

//Forms Definition @1-AD6A991D
public partial class configPage : System.Web.UI.Page
{
//End Forms Definition

	protected int PrevCat = 0;

//Forms Objects @1-77EC851D
    protected configDataProvider configData;
    protected int configCurrentRowNumber;
    protected bool configIsSubmitted = false;
    protected NameValueCollection configErrors=new NameValueCollection();
    protected FormSupportedOperations configOperations;
    protected System.Resources.ResourceManager rm;
    protected string configContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-11B64F6B
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            configBind();
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

//EditableGrid config Bind @3-3ADFA2BA
    protected void configBind()
    {
        if(configOperations.None) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"config",typeof(configDataProvider.SortFields), 50, 100);
        }
//End EditableGrid config Bind

//EditableGrid Form config BeforeShow tail @3-F5913B8D
        configParameters();
        configData.SortField = (configDataProvider.SortFields)ViewState["configSortField"];
        configData.SortDir = (SortDirections)ViewState["configSortDir"];
        configData.PageNumber = (int)ViewState["configPageNumber"];
        configData.RecordsPerPage = (int)ViewState["configPageSize"];
        configRepeater.DataSource = configData.GetResultSet(out PagesCount, configOperations);
        ViewState["configPagesCount"] = PagesCount;
        ViewState["configFormState"] = new Hashtable();
        ViewState["configRowState"] = new Hashtable();
        configRepeater.DataBind();
        FooterIndex = configRepeater.Controls.Count - 1;
        configItem item=new configItem();


        configRepeater.Controls[FooterIndex].FindControl("configButtonSubmit").Visible = configOperations.Editable;
        if (!((IEnumerable)configRepeater.DataSource).GetEnumerator().MoveNext())
            configRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = true;
        if (configErrors.Count > 0)
        {
            System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(configRepeater.Controls[0].FindControl("ErrorLabel"));
            PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(configRepeater.Controls[0].FindControl("configError"));
            RowError.Visible = true;
            foreach(string msg in configErrors)
                Error.Text += configErrors[msg] + "<br/>";
        }
//End EditableGrid Form config BeforeShow tail

//EditableGrid config Bind tail @3-E25D3761
        configShowErrors(new ArrayList((ICollection)configRepeater.DataSource), configRepeater.Items);
    }
//End EditableGrid config Bind tail

//EditableGrid config Table Parameters @3-6DE67D38
    protected void configParameters()
    {
        try{
            configItem item=new configItem();
            configData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            configData.CtrlArea_value = MemoParameter.GetParam(item.Area_value.Value, ParameterSourceType.Control, "", null, false);
        }catch{
            ControlCollection ParentControls=configRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(configRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid config: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End EditableGrid config Table Parameters

//EditableGrid config ItemDataBound event @3-6EC2096E
    protected void configItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        configItem DataItem=(configItem)e.Item.DataItem;
        configItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            configCurrentRowNumber ++;
            DataItem.RowId = e.Item.ItemIndex;
            Hashtable formState = (Hashtable)ViewState["configFormState"];
            Hashtable rowState = (Hashtable)ViewState["configRowState"];
            formState.Add("config_idField:" + e.Item.ItemIndex.ToString(),DataItem.config_idField.Value);
            rowState.Add(e.Item.ItemIndex.ToString(),DataItem.IsNew);
            ViewState[e.Item.FindControl("configconfig_category").UniqueID] = DataItem.config_category.Value;
            ViewState[e.Item.FindControl("configconfig_desc").UniqueID] = DataItem.config_desc.Value;
            System.Web.UI.WebControls.PlaceHolder configconfig_categoryPanel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("configconfig_categoryPanel"));
            System.Web.UI.WebControls.Literal configconfig_category = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("configconfig_category"));
            System.Web.UI.WebControls.Literal configconfig_desc = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("configconfig_desc"));
            System.Web.UI.WebControls.CheckBox configCheck_value = (System.Web.UI.WebControls.CheckBox)(e.Item.FindControl("configCheck_value"));
            System.Web.UI.WebControls.TextBox configBox_value = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("configBox_value"));
            System.Web.UI.WebControls.TextBox configArea_value = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("configArea_value"));
            System.Web.UI.HtmlControls.HtmlSelect configListBox_value = (System.Web.UI.HtmlControls.HtmlSelect)(e.Item.FindControl("configListBox_value"));
            System.Web.UI.HtmlControls.HtmlInputHidden configvalue_type = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("configvalue_type"));
            System.Web.UI.HtmlControls.HtmlInputHidden configListBox_Values = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("configListBox_Values"));
            if(DataItem.Check_valueCheckedValue.Value.Equals(DataItem.Check_value.Value))
                configCheck_value.Checked = true;
            DataItem.ListBox_valueItems.SetSelection(DataItem.ListBox_value.GetFormattedValue());
            if(DataItem.ListBox_valueItems.GetSelectedItem() != null)
                configListBox_value.SelectedIndex = -1;
            DataItem.ListBox_valueItems.CopyTo(configListBox_value.Items);
        }
//End EditableGrid config ItemDataBound event

//config control Before Show @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End config control Before Show

//Get Control @17-07D68AEB
            System.Web.UI.HtmlControls.HtmlSelect configListBox_value = (System.Web.UI.HtmlControls.HtmlSelect)(e.Item.FindControl("configListBox_value"));
//End Get Control

//ListBox ListBox_value Event BeforeShow. Action Custom Code @40-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End ListBox ListBox_value Event BeforeShow. Action Custom Code

//config control Before Show tail @3-FCB6E20C
        }
//End config control Before Show tail

//EditableGrid config BeforeShowRow event @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End EditableGrid config BeforeShowRow event

//EditableGrid config Event BeforeShowRow. Action Custom Code @15-2A29BDB7
    // -------------------------
            System.Web.UI.HtmlControls.HtmlInputHidden configListBox_Values = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("configListBox_Values"));
            System.Web.UI.HtmlControls.HtmlSelect configListBox_value = (System.Web.UI.HtmlControls.HtmlSelect)(e.Item.FindControl("configListBox_value"));
			System.Web.UI.HtmlControls.HtmlInputHidden configvalue_type = (System.Web.UI.HtmlControls.HtmlInputHidden)(e.Item.FindControl("configvalue_type"));
            System.Web.UI.WebControls.CheckBox configCheck_value = (System.Web.UI.WebControls.CheckBox)(e.Item.FindControl("configCheck_value"));
            System.Web.UI.WebControls.TextBox configBox_value = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("configBox_value"));
            System.Web.UI.WebControls.TextBox configArea_value = (System.Web.UI.WebControls.TextBox)(e.Item.FindControl("configArea_value"));
            System.Web.UI.WebControls.Literal configconfig_category = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("configconfig_category"));
            System.Web.UI.WebControls.PlaceHolder configconfig_categoryPanel = (System.Web.UI.WebControls.PlaceHolder)(e.Item.FindControl("configconfig_categoryPanel"));

			string[] ConfCat = new string[]{"", "info_calendar", "calendars_options", "users_options", "email_options", "site_options"};
			if (PrevCat.ToString() == configconfig_category.Text) {
				configconfig_categoryPanel.Visible = false;
			} else {
				configconfig_categoryPanel.Visible = true;
				PrevCat = Convert.ToInt32(configconfig_category.Text);
				configconfig_category.Text = rm.GetString(ConfCat[PrevCat]);
			}

			int type_f = Convert.ToInt32(configvalue_type.Value);
			configArea_value.Visible = false;
			configBox_value.Visible = false;
			configCheck_value.Visible = false;
			configListBox_value.Visible = false;

			switch (type_f)
			{
				case 1:	
					configCheck_value.Visible = true;
					configCheck_value.Checked = configArea_value.Text == "1";
					break;
				case 2: 
					configBox_value.Visible = true;
					configBox_value.Text = configArea_value.Text;
					break;
				case 3:	
					configArea_value.Visible = true;
					break;
				case 4:	
					configListBox_value.Visible = true;
					string [] listboxval = configListBox_Values.Value.Split(new Char[]{';'});
					configListBox_value.Items.Clear();
					for (int i = 0; i<listboxval.Length/2; i++)
						configListBox_value.Items.Add(new ListItem(listboxval[i*2+1], listboxval[i*2]));
					configListBox_value.Value = configArea_value.Text;
					break;
			}
    // -------------------------
//End EditableGrid config Event BeforeShowRow. Action Custom Code

//EditableGrid config BeforeShowRow event tail @3-FCB6E20C
        }
//End EditableGrid config BeforeShowRow event tail

//EditableGrid config ItemDataBound event tail @3-FCB6E20C
    }
//End EditableGrid config ItemDataBound event tail

//EditableGrid config GetRedirectUrl method @3-26168EF8
    protected string GetconfigRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "index.aspx";
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }
    protected string GetconfigRedirectUrl(string redirectString)
    {
        return GetconfigRedirectUrl(redirectString ,"");
    }
//End EditableGrid config GetRedirectUrl method

//EditableGrid config ShowErrors method @3-BCA9563C
    protected bool configShowErrors(ArrayList items, RepeaterItemCollection col)
    {
        bool result = true;
        foreach(configItem item in items)
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
//End EditableGrid config ShowErrors method

//EditableGrid config ItemCommand event @3-AB4638C5
    protected void configItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = configRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End EditableGrid config ItemCommand event

//Button ButtonSubmit OnClick. @33-3E3AB25A
        if(((Control)e.CommandSource).ID == "configButtonSubmit")
        {
            RedirectUrl  = GetconfigRedirectUrl("", "");
            EnableValidation  = true;
//End Button ButtonSubmit OnClick.

//Button ButtonSubmit OnClick tail. @33-FCB6E20C
        }
//End Button ButtonSubmit OnClick tail.

//EditableGrid Form config ItemCommand event tail @3-B0CA3668
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["configSortDir"]==SortDirections.Asc&&ViewState["configSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["configSortDir"]=SortDirections.Desc;
                else
                    ViewState["configSortDir"]=SortDirections.Asc;
            else
                ViewState["configSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["configSortField"]=Enum.Parse(typeof(configDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["configPageNumber"] = 1;
            BindAllowed = true;
        }

        if(e.CommandName=="Navigate"){
            ViewState["configPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }

        if(e.CommandName=="Submit"){
            configIsSubmitted = true;
            BindAllowed = true;
            RepeaterItemCollection col=configRepeater.Items;
            ArrayList items=new ArrayList();
            Hashtable formState = (Hashtable)ViewState["configFormState"];
            Hashtable rowState = (Hashtable)ViewState["configRowState"];
            configParameters();
            for(int i=0;i<col.Count;i++)
                if(col[i].ItemType == ListItemType.Item || col[i].ItemType == ListItemType.AlternatingItem){
                    System.Web.UI.WebControls.PlaceHolder configconfig_categoryPanel = (System.Web.UI.WebControls.PlaceHolder)(col[i].FindControl("configconfig_categoryPanel"));
                    System.Web.UI.WebControls.Literal configconfig_category = (System.Web.UI.WebControls.Literal)(col[i].FindControl("configconfig_category"));
                    System.Web.UI.WebControls.Literal configconfig_desc = (System.Web.UI.WebControls.Literal)(col[i].FindControl("configconfig_desc"));
                    System.Web.UI.WebControls.CheckBox configCheck_value = (System.Web.UI.WebControls.CheckBox)(col[i].FindControl("configCheck_value"));
                    System.Web.UI.WebControls.TextBox configBox_value = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("configBox_value"));
                    System.Web.UI.WebControls.TextBox configArea_value = (System.Web.UI.WebControls.TextBox)(col[i].FindControl("configArea_value"));
                    System.Web.UI.HtmlControls.HtmlSelect configListBox_value = (System.Web.UI.HtmlControls.HtmlSelect)(col[i].FindControl("configListBox_value"));
                    System.Web.UI.HtmlControls.HtmlInputHidden configvalue_type = (System.Web.UI.HtmlControls.HtmlInputHidden)(col[i].FindControl("configvalue_type"));
                    System.Web.UI.HtmlControls.HtmlInputHidden configListBox_Values = (System.Web.UI.HtmlControls.HtmlInputHidden)(col[i].FindControl("configListBox_Values"));
                    col[i].FindControl("RowError").Visible = false;
                    configItem item = new configItem();
                    item.RowId = col[i].ItemIndex;
                    item.IsUpdated = !col[i].Visible;
                    item.IsNew = (bool)(rowState[col[i].ItemIndex.ToString()]);
                    item.config_idField.Value = (System.IComparable)formState["config_idField:" + col[i].ItemIndex.ToString()];
                    item.config_category.Value = (System.IComparable)ViewState[configconfig_category.UniqueID];
                    item.config_desc.Value = (System.IComparable)ViewState[configconfig_desc.UniqueID];
                    try{
                    item.Check_value.IsEmpty = Request.Form[configCheck_value.UniqueID]==null;
                    item.Check_value.Value = configCheck_value.Checked ?(item.Check_valueCheckedValue.Value):(item.Check_valueUncheckedValue.Value);
                    }catch(ArgumentException){
                    item.errors.Add("Check_value",String.Format(Resources.strings.CCS_IncorrectValue,"Check_value"));}
                    item.Box_value.IsEmpty = Request.Form[configBox_value.UniqueID]==null;
                    item.Box_value.SetValue(configBox_value.Text);
                    item.Area_value.IsEmpty = Request.Form[configArea_value.UniqueID]==null;
                    item.Area_value.SetValue(configArea_value.Text);
                    item.ListBox_value.IsEmpty = Request.Form[configListBox_value.UniqueID]==null;
                    item.ListBox_value.SetValue(configListBox_value.Value);
                    item.ListBox_valueItems.CopyFrom(configListBox_value.Items);
                    item.value_type.SetValue(configvalue_type.Value);
                    item.ListBox_Values.SetValue(configListBox_Values.Value);
                    items.Add(item);
                    if(EnableValidation && !item.IsEmptyItem && !item.IsDeleted)
                        BindAllowed = item.Validate(configData) && BindAllowed;
            }

//End EditableGrid Form config ItemCommand event tail

//EditableGrid config Update @3-5248A7AD
        if (BindAllowed)
            try
            {
                configParameters();
                configData.Update(items, configOperations);
                if (configShowErrors(items, col))
                    Response.Redirect(RedirectUrl);
                else
                    BindAllowed = false;
            }
            catch (Exception ex)
            {
                System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)(configRepeater.Controls[0].FindControl("ErrorLabel"));
                PlaceHolder RowError = (System.Web.UI.WebControls.PlaceHolder)(configRepeater.Controls[0].FindControl("configError"));
                RowError.Visible = true;
                Error.Text = "DataProvider:" + ex.Message;
                BindAllowed=false;
            }
//End EditableGrid config Update

//EditableGrid config AfterSubmit @3-07B9DD5C
        else
            configShowErrors(items, col);
        }
        if (BindAllowed)
            configBind();
    }
//End EditableGrid config AfterSubmit

//OnInit Event @1-FC08B643
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        configContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        configData = new configDataProvider();
        configOperations = new FormSupportedOperations(false, true, false, true, false);
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

