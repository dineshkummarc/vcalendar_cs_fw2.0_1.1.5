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

namespace calendar.install.install{ //Namespace @1-8D024801

//Forms Definition @1-6A1CD222
public partial class installPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-9FE13222
    protected sql_environmentDataProvider sql_environmentData;
    protected NameValueCollection sql_environmentErrors=new NameValueCollection();
    protected bool sql_environmentIsSubmitted = false;
    protected FormSupportedOperations sql_environmentOperations;
    protected System.Resources.ResourceManager rm;
    protected string installContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-607285D7
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.InstallLinkHref = "install.aspx";
            item.StartLinkHref = "../index.aspx";
            PageData.FillItem(item);
            CommonCheck.Text=item.CommonCheck.GetFormattedValue();
            FolderCheck.Text=Server.HtmlEncode(item.FolderCheck.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
            InstallLink.InnerText += item.InstallLink.GetFormattedValue().Replace("\r","").Replace("\n","<br>");
            InstallLink.HRef = item.InstallLinkHref+item.InstallLinkHrefParameters.ToString("GET","", ViewState);
            StartLink.InnerText=Resources.strings.start;
            StartLink.HRef = item.StartLinkHref+item.StartLinkHrefParameters.ToString("None","step", ViewState);
            sql_environmentShow();
    }
//End Page_Load Event BeforeIsPostBack

//Panel Panel1 Event BeforeShow. Action Custom Code @42-2A29BDB7
    // -------------------------
	int ErrorCount = 0;
	try {
		System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
		doc.Load(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("..\\"),"web.config"));
		doc.Save(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("..\\"),"web.config"));
		CommonCheck.Text = "<font color=\"Green\"><b>OK</b></font>";
	} catch(Exception ex) {
		CommonCheck.Text = "<font color=\"Red\"><b>ReadOnly</b></font>";
		System.Web.HttpContext.Current.Session["InstConfigReadOnly"] = "1";
	}

	FolderCheck.Text = "<font color=\"Green\"><b>OK</b></font>";
	string dirpath = System.Web.HttpContext.Current.Server.MapPath("..\\") + "\\temp";
	if (!Directory.Exists(dirpath)) {
		FolderCheck.Text = "<font color=\"Red\"><b>" + String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("inst_not_exist_folder"), "temp") + "</b></font>";
		ErrorCount = 2;
	} else {
		try
		{
			if (File.Exists(dirpath + "\\test.tmp"))
				File.Delete(dirpath + "\\test.tmp");
			File.Create(dirpath + "\\test.tmp");
		}
		catch (Exception ex)
		{
			FolderCheck.Text = "<font color=\"Red\"><b>" + String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("inst_folder_not_writable"), "temp") + "</b></font>";
			ErrorCount = 2;
		}
	}

	if (ErrorCount < 2) {
		dirpath = System.Web.HttpContext.Current.Server.MapPath("..\\") + "\\images\\categories";			
		if (!Directory.Exists(dirpath)) {
			FolderCheck.Text = "<font color=\"Red\"><b>" + String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("inst_not_exist_folder"), "images\\categories") + "</b></font>";
			ErrorCount = 1;
		} else {
			try
			{
				if (File.Exists(dirpath + "\\test.tmp"))
					File.Delete(dirpath + "\\test.tmp");
    	    	File.Create(dirpath + "\\test.tmp");
			}
			catch (Exception ex)
			{
				FolderCheck.Text = "<font color=\"Red\"><b>" + String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("inst_folder_not_writable"), "images\\categories") + "</b></font>";
				ErrorCount = 1;
			}
		}
	}

	if (ErrorCount == 0) {
		InstallLink.HRef = CommonFunctions.CCAddParam(InstallLink.HRef, "step", "2");
		InstallLink.InnerText = ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("install_start");
	} else 
		InstallLink.InnerText = ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("install_recheck");
    // -------------------------
//End Panel Panel1 Event BeforeShow. Action Custom Code

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

//Record Form sql_environment Parameters @2-1F43CFE2
    protected void sql_environmentParameters()
    {
        sql_environmentItem item=sql_environmentItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            sql_environmentErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form sql_environment Parameters

//Record Form sql_environment Show method @2-4E86F276
    protected void sql_environmentShow()
    {
        if(sql_environmentOperations.None)
        {
            sql_environmentHolder.Visible=false;
            return;
        }
        sql_environmentItem item=sql_environmentItem.CreateFromHttpRequest();
        bool IsInsertMode=!sql_environmentOperations.AllowRead;
        sql_environmentErrors.Add(item.errors);
//End Record Form sql_environment Show method

//Record Form sql_environment BeforeShow tail @2-CB77709E
        sql_environmentParameters();
        sql_environmentData.FillItem(item,ref IsInsertMode);
        sql_environmentHolder.DataBind();
        sql_environmentButton_Insert.Visible=IsInsertMode&&sql_environmentOperations.AllowInsert;
        if(item.change_webconfigCheckedValue.Value.Equals(item.change_webconfig.Value))
            sql_environmentchange_webconfig.Checked = true;
        sql_environmentis_disabled.Value=item.is_disabled.GetFormattedValue();
        sql_environmentSiteURL.Text=item.SiteURL.GetFormattedValue();
        item.DBTypeItems.SetSelection(item.DBType.GetFormattedValue());
        sql_environmentDBType.SelectedIndex = -1;
        item.DBTypeItems.CopyTo(sql_environmentDBType.Items);
        sql_environmentmdb_file.Text=item.mdb_file.GetFormattedValue();
        sql_environmenthost.Text=item.host.GetFormattedValue();
        sql_environmentsql_db_name.Text=item.sql_db_name.GetFormattedValue();
        sql_environmentsql_username.Text=item.sql_username.GetFormattedValue();
        sql_environmentsql_password.Text=item.sql_password.GetFormattedValue();
        item.recreate_tablesItems.SetSelection(item.recreate_tables.GetFormattedValue());
        sql_environmentrecreate_tables.SelectedIndex = -1;
        item.recreate_tablesItems.CopyTo(sql_environmentrecreate_tables.Items);
//End Record Form sql_environment BeforeShow tail

//Record sql_environment Event BeforeShow. Action Custom Code @48-2A29BDB7
    // -------------------------
		sql_environmentmdb_file.Text = Server.MapPath("..\\") + "DB\\VCalendar.mdb";
		if (Convert.ToString(System.Web.HttpContext.Current.Session["InstConfigReadOnly"]) == "1") {
			sql_environmentchange_webconfig.Checked = false;
			sql_environmentis_disabled.Value = "1";
		}
    // -------------------------
//End Record sql_environment Event BeforeShow. Action Custom Code

//Record Form sql_environment Show method tail @2-DF3CDB06
        if(sql_environmentErrors.Count>0)
            sql_environmentShowErrors();
    }
//End Record Form sql_environment Show method tail

//Record Form sql_environment LoadItemFromRequest method @2-5B92DF63
    protected void sql_environmentLoadItemFromRequest(sql_environmentItem item, bool EnableValidation)
    {
        item.change_webconfig.Value = sql_environmentchange_webconfig.Checked ?(item.change_webconfigCheckedValue.Value):(item.change_webconfigUncheckedValue.Value);
        item.is_disabled.SetValue(sql_environmentis_disabled.Value);
        item.SiteURL.SetValue(sql_environmentSiteURL.Text);
        try{
        if(sql_environmentDBType.SelectedItem!=null)
            item.DBType.SetValue(sql_environmentDBType.SelectedItem.Value);
        else
            item.DBType.Value=null;
        item.DBTypeItems.CopyFrom(sql_environmentDBType.Items);
        }catch(ArgumentException){
            sql_environmentErrors.Add("DBType",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.db_type));}
        item.mdb_file.SetValue(sql_environmentmdb_file.Text);
        item.host.SetValue(sql_environmenthost.Text);
        item.sql_db_name.SetValue(sql_environmentsql_db_name.Text);
        item.sql_username.SetValue(sql_environmentsql_username.Text);
        item.sql_password.SetValue(sql_environmentsql_password.Text);
        if(sql_environmentrecreate_tables.SelectedItem!=null)
            item.recreate_tables.SetValue(sql_environmentrecreate_tables.SelectedItem.Value);
        else
            item.recreate_tables.Value=null;
        item.recreate_tablesItems.CopyFrom(sql_environmentrecreate_tables.Items);
        if(EnableValidation)
            item.Validate(sql_environmentData);
        sql_environmentErrors.Add(item.errors);
    }
//End Record Form sql_environment LoadItemFromRequest method

//Record Form sql_environment GetRedirectUrl method @2-4F1BAA8F
    protected string Getsql_environmentRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "install.aspx";
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form sql_environment GetRedirectUrl method

//Record Form sql_environment ShowErrors method @2-49124DDF
    protected void sql_environmentShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<sql_environmentErrors.Count;i++)
        switch(sql_environmentErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=sql_environmentErrors[i];
                break;
        }
        sql_environmentError.Visible = true;
        sql_environmentErrorLabel.Text = DefaultMessage;
    }
//End Record Form sql_environment ShowErrors method

//Record Form sql_environment Insert Operation @2-6824D519
    protected void sql_environment_Insert(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        sql_environmentIsSubmitted = true;
        bool ErrorFlag = false;
        sql_environmentItem item=new sql_environmentItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form sql_environment Insert Operation

//Button Button_Insert OnClick. @8-63D17369
        if(((Control)sender).ID == "sql_environmentButton_Insert")
        {
            RedirectUrl  = Getsql_environmentRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Insert OnClick.

//Button Button_Insert OnClick tail. @8-FCB6E20C
        }
//End Button Button_Insert OnClick tail.

//Record Form sql_environment BeforeInsert tail @2-46858B07
    sql_environmentParameters();
    sql_environmentLoadItemFromRequest(item, EnableValidation);
//End Record Form sql_environment BeforeInsert tail

//Record Form sql_environment AfterInsert tail  @2-65B81C57
        ErrorFlag=(sql_environmentErrors.Count>0);
        if(ErrorFlag)
            sql_environmentShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form sql_environment AfterInsert tail 

//Record Form sql_environment Update Operation @2-48338BF6
    protected void sql_environment_Update(object sender, System.EventArgs e)
    {
        sql_environmentItem item=new sql_environmentItem();
        item.IsNew = false;
        sql_environmentIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form sql_environment Update Operation

//Record Form sql_environment Before Update tail @2-46858B07
        sql_environmentParameters();
        sql_environmentLoadItemFromRequest(item, EnableValidation);
//End Record Form sql_environment Before Update tail

//Record Form sql_environment Update Operation tail @2-65B81C57
        ErrorFlag=(sql_environmentErrors.Count>0);
        if(ErrorFlag)
            sql_environmentShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form sql_environment Update Operation tail

//Record Form sql_environment Delete Operation @2-617F9CF3
    protected void sql_environment_Delete(object sender,System.EventArgs e)
    {
        sql_environmentIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        sql_environmentItem item=new sql_environmentItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form sql_environment Delete Operation

//Record Form BeforeDelete tail @2-46858B07
        sql_environmentParameters();
        sql_environmentLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @2-B9341FA3
        if(ErrorFlag)
            sql_environmentShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form sql_environment Cancel Operation @2-25DCCFC1
    protected void sql_environment_Cancel(object sender,System.EventArgs e)
    {
        sql_environmentItem item=new sql_environmentItem();
        sql_environmentIsSubmitted = true;
        string RedirectUrl = "";
        sql_environmentLoadItemFromRequest(item, true);
//End Record Form sql_environment Cancel Operation

//Record Form sql_environment Cancel Operation tail @2-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form sql_environment Cancel Operation tail

//OnInit Event @1-3674E0A3
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        installContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        sql_environmentData = new sql_environmentDataProvider();
        sql_environmentOperations = new FormSupportedOperations(false, true, true, true, true);
//End OnInit Event

//Page install Event AfterInitialize. Action Custom Code @23-2A29BDB7
    // -------------------------
	string Step = CommonFunctions.CCGetFromGet("step", "1");

	Panel1.Visible = (Step=="1");
	Panel2.Visible = (Step=="2");
	Panel3.Visible = (Step=="3");
    // -------------------------
//End Page install Event AfterInitialize. Action Custom Code

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

