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

namespace calendar.admin.categories{ //Namespace @1-223740FB

//Forms Definition @1-74266FF2
public partial class categoriesPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-65611B88
    protected categoriesDataProvider categoriesData;
    protected int categoriesCurrentRowNumber;
    protected FormSupportedOperations categoriesOperations;
    protected categories_maintDataProvider categories_maintData;
    protected NameValueCollection categories_maintErrors=new NameValueCollection();
    protected bool categories_maintIsSubmitted = false;
    protected FormSupportedOperations categories_maintOperations;
    protected System.Resources.ResourceManager rm;
    protected string categoriesContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-02EF1F5C
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            categoriesBind();
            categories_maintShow();
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

//Grid categories Bind @33-097EA6C8
    protected void categoriesBind()
    {
        if (!categoriesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"categories",typeof(categoriesDataProvider.SortFields), 10, 100);
        }
//End Grid categories Bind

//Grid Form categories BeforeShow tail @33-EA7B2685
        categoriesParameters();
        categoriesData.SortField = (categoriesDataProvider.SortFields)ViewState["categoriesSortField"];
        categoriesData.SortDir = (SortDirections)ViewState["categoriesSortDir"];
        categoriesData.PageNumber = (int)ViewState["categoriesPageNumber"];
        categoriesData.RecordsPerPage = (int)ViewState["categoriesPageSize"];
        categoriesRepeater.DataSource = categoriesData.GetResultSet(out PagesCount, categoriesOperations);
        ViewState["categoriesPagesCount"] = PagesCount;
        categoriesRepeater.DataBind();
        FooterIndex = categoriesRepeater.Controls.Count - 1;
        categoriesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        categoriesItem item=new categoriesItem();
        System.Web.UI.HtmlControls.HtmlAnchor categoriescategories_Insert = (System.Web.UI.HtmlControls.HtmlAnchor)categoriesRepeater.Controls[FooterIndex].FindControl("categoriescategories_Insert");

        item.categories_InsertHref = "categories.aspx";

        categoriescategories_Insert.InnerText=Resources.strings.CCS_InsertLink;
        categoriescategories_Insert.HRef = item.categories_InsertHref+item.categories_InsertHrefParameters.ToString("GET","category_id", ViewState);
        calendar.Controls.Navigator NavigatorNavigator = (calendar.Controls.Navigator)categoriesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form categories BeforeShow tail

//Grid categories Bind tail @33-FCB6E20C
    }
//End Grid categories Bind tail

//Grid categories Table Parameters @33-CBE7E277
    protected void categoriesParameters()
    {
        try{
            categoriesData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
        }catch{
            ControlCollection ParentControls=categoriesRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(categoriesRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid categories: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid categories Table Parameters

//Grid categories ItemDataBound event @33-CDE7B874
    protected void categoriesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        categoriesItem DataItem=(categoriesItem)e.Item.DataItem;
        categoriesItem[] FormDataSource=(categoriesItem[])categoriesRepeater.DataSource;
        categoriesItem item = DataItem;
        int categoriesDataRows = FormDataSource.Length;
        bool categoriesIsForceIteration = false;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        categoriesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor categoriescategory_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("categoriescategory_name"));
            System.Web.UI.WebControls.Image categoriescategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("categoriescategory_image"));
            System.Web.UI.HtmlControls.HtmlAnchor categoriestranslations = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("categoriestranslations"));
            DataItem.category_nameHref = "categories.aspx";
            categoriescategory_name.HRef = DataItem.category_nameHref + DataItem.category_nameHrefParameters.ToString("GET","", ViewState);
            categoriescategory_image.ImageUrl += DataItem.category_image.GetFormattedValue();
            DataItem.translationsHref = "categories_langs.aspx";
            categoriestranslations.HRef = "javascript:openWin('" + DataItem.translationsHref + DataItem.translationsHrefParameters.ToString("GET","", ViewState) + "')";
        }
//End Grid categories ItemDataBound event

//Grid categories BeforeShowRow event @33-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid categories BeforeShowRow event

//Grid categories Event BeforeShowRow. Action Custom Code @56-2A29BDB7
    // -------------------------
        System.Web.UI.WebControls.Image categoriescategory_image = (System.Web.UI.WebControls.Image)(e.Item.FindControl("categoriescategory_image"));
		if (item.category_image.GetFormattedValue().Length > 0)
			categoriescategory_image.Visible = true;
		else
			categoriescategory_image.Visible = false;
   // -------------------------
//End Grid categories Event BeforeShowRow. Action Custom Code

//Grid categories BeforeShowRow event tail @33-FCB6E20C
        }
//End Grid categories BeforeShowRow event tail

//Grid categories ItemDataBound event tail @33-F5D10A4D
        if(categoriesIsForceIteration)
        {
            RepeaterItem ri = null;
            ri= new RepeaterItem(categoriesCurrentRowNumber, ListItemType.Item);
            categoriesRepeater.ItemTemplate.InstantiateIn(ri);
            ri.DataItem = DataItem;
            ri.DataBind();
            e.Item.FindControl("IterationContainer").Controls.Add(ri);
            categoriesItemDataBound(Sender, new RepeaterItemEventArgs(ri));
            ri.DataItem = null;
        }
    }
//End Grid categories ItemDataBound event tail

//Grid categories ItemCommand event @33-CF4E242D
    protected void categoriesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = categoriesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["categoriesSortDir"]==SortDirections.Asc&&ViewState["categoriesSortField"].ToString()==((calendar.Controls.Sorter)e.CommandSource).Field)
                    ViewState["categoriesSortDir"]=SortDirections.Desc;
                else
                    ViewState["categoriesSortDir"]=SortDirections.Asc;
            else
                ViewState["categoriesSortDir"]=(int)(((calendar.Controls.Sorter)e.CommandSource).State);
            ViewState["categoriesSortField"]=Enum.Parse(typeof(categoriesDataProvider.SortFields),((calendar.Controls.Sorter)e.CommandSource).Field);
            ViewState["categoriesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["categoriesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            categoriesBind();
    }
//End Grid categories ItemCommand event

//Record Form categories_maint Parameters @45-75CB2807
    protected void categories_maintParameters()
    {
        categories_maintItem item=categories_maintItem.CreateFromHttpRequest();
        try{
            categories_maintData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            categories_maintData.Ctrlcategory_name = TextParameter.GetParam(item.category_name.Value, ParameterSourceType.Control, "", null, false);
            categories_maintData.Ctrlcategory_image = TextParameter.GetParam(item.category_image.Value, ParameterSourceType.Control, "", null, false);
            categories_maintData.Urlcategory_id = IntegerParameter.GetParam("category_id", ParameterSourceType.URL, "", null, false);
        }catch(Exception e){
            categories_maintErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form categories_maint Parameters

//Record Form categories_maint Show method @45-E03BF1C4
    protected void categories_maintShow()
    {
        if(categories_maintOperations.None)
        {
            categories_maintHolder.Visible=false;
            return;
        }
        categories_maintItem item=categories_maintItem.CreateFromHttpRequest();
        bool IsInsertMode=!categories_maintOperations.AllowRead;
        categories_maintErrors.Add(item.errors);
//End Record Form categories_maint Show method

//Record Form categories_maint BeforeShow tail @45-6679B624
        categories_maintParameters();
        categories_maintData.FillItem(item,ref IsInsertMode);
        categories_maintHolder.DataBind();
        categories_maintButton_Insert.Visible=IsInsertMode&&categories_maintOperations.AllowInsert;
        categories_maintButton_Update.Visible=!IsInsertMode&&categories_maintOperations.AllowUpdate;
        categories_maintButton_Delete.Visible=!IsInsertMode&&categories_maintOperations.AllowDelete;
        categories_maintcategory_name.Text=item.category_name.GetFormattedValue();
        try{
            categories_maintcategory_image.FileFolder = @"../images/categories";
        }catch(System.IO.DirectoryNotFoundException){
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_FilesFolderNotFound,"{res:cal_category_image}"));
        }catch(System.Security.SecurityException){
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_InsufficientPermissions,"{res:cal_category_image}"));
        }
        try{
            categories_maintcategory_image.TemporaryFolder = @"../temp";
        }catch(System.IO.DirectoryNotFoundException){
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_TempFolderNotFound,"{res:cal_category_image}"));
        }catch(System.Security.SecurityException){
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_TempInsufficientPermissions,"{res:cal_category_image}"));
        }
        categories_maintcategory_image.AllowedFileMasks = @"*.jpg;*.png;*.gif";
        categories_maintcategory_image.FileSizeLimit = 100000;
        try{
            categories_maintcategory_image.Text = item.category_image.GetFormattedValue();
        }catch(System.IO.FileNotFoundException){
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_FileNotFound,item.category_image.GetFormattedValue(),"{res:cal_category_image}"));
        }
//End Record Form categories_maint BeforeShow tail

//DEL      // -------------------------
//DEL      categories_maintcategory_image.DeleteCaption = rm.GetString("CCS_Delete");
//DEL      // -------------------------


//Record Form categories_maint Show method tail @45-C403CF8A
        if(categories_maintErrors.Count>0)
            categories_maintShowErrors();
    }
//End Record Form categories_maint Show method tail

//Record Form categories_maint LoadItemFromRequest method @45-93D5107A
    protected void categories_maintLoadItemFromRequest(categories_maintItem item, bool EnableValidation)
    {
        item.category_name.SetValue(categories_maintcategory_name.Text);
        try{
            categories_maintcategory_image.ValidateFile();
            item.category_image.SetValue(categories_maintcategory_image.Text);
        }catch(InvalidOperationException ex){
            if(ex.Message == "The file type is not allowed.")
                categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_WrongType,"{res:cal_category_image}"));
            if(ex.Message == "The file is too large.")
                categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_LargeFile,"{res:cal_category_image}"));
        }
        if(EnableValidation)
            item.Validate(categories_maintData);
        categories_maintErrors.Add(item.errors);
    }
//End Record Form categories_maint LoadItemFromRequest method

//Record Form categories_maint GetRedirectUrl method @45-DA79909B
    protected string Getcategories_maintRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "categories.aspx";
        string p = parameters.ToString("GET","category_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form categories_maint GetRedirectUrl method

//Record Form categories_maint ShowErrors method @45-9CEC50AA
    protected void categories_maintShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<categories_maintErrors.Count;i++)
        switch(categories_maintErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=categories_maintErrors[i];
                break;
        }
        categories_maintError.Visible = true;
        categories_maintErrorLabel.Text = DefaultMessage;
    }
//End Record Form categories_maint ShowErrors method

//Record Form categories_maint Insert Operation @45-A1D2CDC4
    protected void categories_maint_Insert(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        categories_maintIsSubmitted = true;
        bool ErrorFlag = false;
        categories_maintItem item=new categories_maintItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form categories_maint Insert Operation

//Button Button_Insert OnClick. @48-C25DAB92
        if(((Control)sender).ID == "categories_maintButton_Insert")
        {
            RedirectUrl  = Getcategories_maintRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Insert OnClick.

//Button Button_Insert OnClick tail. @48-FCB6E20C
        }
//End Button Button_Insert OnClick tail.

//Record Form categories_maint BeforeInsert tail @45-9ABB96A7
    categories_maintParameters();
    categories_maintLoadItemFromRequest(item, EnableValidation);
    if(categories_maintOperations.AllowInsert){
    ErrorFlag=(categories_maintErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                categories_maintData.InsertItem(item);
            }
            catch (Exception ex)
            {
                categories_maintErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form categories_maint BeforeInsert tail

//Record Form categories_maint AfterInsert tail  @45-952CCE2B
            if(!ErrorFlag)
                categories_maintcategory_image.SaveFile();
        }
        ErrorFlag=(categories_maintErrors.Count>0);
        if(ErrorFlag)
            categories_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form categories_maint AfterInsert tail 

//Record Form categories_maint Update Operation @45-693F79A9
    protected void categories_maint_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        categories_maintItem item=new categories_maintItem();
        item.IsNew = false;
        categories_maintIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form categories_maint Update Operation

//Button Button_Update OnClick. @49-4E6FB9CD
        if(((Control)sender).ID == "categories_maintButton_Update")
        {
            RedirectUrl  = Getcategories_maintRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @49-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form categories_maint Before Update tail @45-B754BE14
        categories_maintParameters();
        categories_maintLoadItemFromRequest(item, EnableValidation);
        if(categories_maintOperations.AllowUpdate){
        ErrorFlag=(categories_maintErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                categories_maintData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                categories_maintErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form categories_maint Before Update tail

//Record categories_maint Event AfterUpdate. Action Custom Code @52-2A29BDB7
    // -------------------------
			//Delete the related records 
			DataAccessObject Conn =	Settings.calendarDataAccessObject;
			string SQL = "";
			string LanguageID = (string)System.Web.HttpContext.Current.Session["locale"];
			string CategoryID = CommonFunctions.CCGetFromGet("category_id","");

			if (LanguageID == CommonFunctions.str_calendar_config("default_language")) {
				SQL = "UPDATE categories " +
						" SET category_name= " + Conn.ToSql(categories_maintcategory_name.Text,FieldType.Text) +
					 	" WHERE category_id=" + Conn.ToSql(CategoryID,FieldType.Integer);
				Conn.RunSql(SQL);
			}

			SQL = "UPDATE categories_langs " +
					" SET category_name= " + Conn.ToSql(categories_maintcategory_name.Text, FieldType.Text) +
					" WHERE language_id= " + Conn.ToSql(LanguageID, FieldType.Text) +
					" AND category_id=" + Conn.ToSql(CategoryID, FieldType.Integer);
			Conn.RunSql(SQL);
	// -------------------------
//End Record categories_maint Event AfterUpdate. Action Custom Code

//Record Form categories_maint Update Operation tail @45-952CCE2B
            if(!ErrorFlag)
                categories_maintcategory_image.SaveFile();
        }
        ErrorFlag=(categories_maintErrors.Count>0);
        if(ErrorFlag)
            categories_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form categories_maint Update Operation tail

//Record Form categories_maint Delete Operation @45-618232D2
    protected void categories_maint_Delete(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        categories_maintIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        categories_maintItem item=new categories_maintItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form categories_maint Delete Operation

//Button Button_Delete OnClick. @50-699C182A
        if(((Control)sender).ID == "categories_maintButton_Delete")
        {
            RedirectUrl  = Getcategories_maintRedirectUrl("", "");
            EnableValidation  = false;
//End Button Button_Delete OnClick.

//Button Button_Delete OnClick tail. @50-FCB6E20C
        }
//End Button Button_Delete OnClick tail.

//Record Form BeforeDelete tail @45-C40048E4
        categories_maintParameters();
        categories_maintLoadItemFromRequest(item, EnableValidation);
        if(categories_maintOperations.AllowDelete){
        ErrorFlag = (categories_maintErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                categories_maintData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                categories_maintErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @45-FF126864
            if(!ErrorFlag)
                categories_maintcategory_image.DeleteFile();
        }
        if(ErrorFlag)
            categories_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form categories_maint Cancel Operation @45-20763259
    protected void categories_maint_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        categories_maintItem item=new categories_maintItem();
        categories_maintIsSubmitted = true;
        string RedirectUrl = "";
        categories_maintLoadItemFromRequest(item, false);
//End Record Form categories_maint Cancel Operation

//Button Button_Cancel OnClick. @51-58C11143
    if(((Control)sender).ID == "categories_maintButton_Cancel")
    {
        RedirectUrl  = Getcategories_maintRedirectUrl("", "");
//End Button Button_Cancel OnClick.

//Button Button_Cancel OnClick tail. @51-FCB6E20C
    }
//End Button Button_Cancel OnClick tail.

//Record Form categories_maint Cancel Operation tail @45-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form categories_maint Cancel Operation tail

//OnInit Event @1-D6922B9B
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        categoriesContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        categoriesData = new categoriesDataProvider();
        categoriesOperations = new FormSupportedOperations(false, true, false, false, false);
        categories_maintData = new categories_maintDataProvider();
        categories_maintOperations = new FormSupportedOperations(false, true, true, true, true);
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

