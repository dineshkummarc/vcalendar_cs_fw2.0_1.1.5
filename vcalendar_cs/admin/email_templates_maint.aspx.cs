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

namespace calendar.admin.email_templates_maint{ //Namespace @1-F3646366

//Forms Definition @1-B90F5A65
public partial class email_templates_maintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-4427AC14
    protected email_templatesDataProvider email_templatesData;
    protected NameValueCollection email_templatesErrors=new NameValueCollection();
    protected bool email_templatesIsSubmitted = false;
    protected FormSupportedOperations email_templatesOperations;
    protected System.Resources.ResourceManager rm;
    protected string email_templates_maintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-DF0463F6
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            email_templatesShow();
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

//Record Form email_templates Parameters @2-4FB4C083
    protected void email_templatesParameters()
    {
        email_templatesItem item=email_templatesItem.CreateFromHttpRequest();
        try{
            email_templatesData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
            email_templatesData.Urlemail_template_id = IntegerParameter.GetParam("email_template_id", ParameterSourceType.URL, "", null, false);
            email_templatesData.Ctrlemail_template_from = TextParameter.GetParam(item.email_template_from.Value, ParameterSourceType.Control, "", null, false);
        }catch(Exception e){
            email_templatesErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form email_templates Parameters

//Record Form email_templates Show method @2-BD14F0CC
    protected void email_templatesShow()
    {
        if(email_templatesOperations.None)
        {
            email_templatesHolder.Visible=false;
            return;
        }
        email_templatesItem item=email_templatesItem.CreateFromHttpRequest();
        bool IsInsertMode=!email_templatesOperations.AllowRead;
        email_templatesErrors.Add(item.errors);
//End Record Form email_templates Show method

//Record Form email_templates BeforeShow tail @2-3E3AF07E
        email_templatesParameters();
        email_templatesData.FillItem(item,ref IsInsertMode);
        email_templatesHolder.DataBind();
        email_templatesButton_Update.Visible=!IsInsertMode&&email_templatesOperations.AllowUpdate;
        email_templatesemail_template_type.Text=Server.HtmlEncode(item.email_template_type.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        email_templatesemail_template_desc.Text=item.email_template_desc.GetFormattedValue();
        email_templatesemail_template_from.Text=item.email_template_from.GetFormattedValue();
        email_templatesemail_template_subject.Text=item.email_template_subject.GetFormattedValue();
        email_templatesemail_template_body.Text=item.email_template_body.GetFormattedValue();
//End Record Form email_templates BeforeShow tail

//Record Form email_templates Show method tail @2-1B1C68DC
        if(email_templatesErrors.Count>0)
            email_templatesShowErrors();
    }
//End Record Form email_templates Show method tail

//Record Form email_templates LoadItemFromRequest method @2-EB4B85F8
    protected void email_templatesLoadItemFromRequest(email_templatesItem item, bool EnableValidation)
    {
        item.email_template_desc.SetValue(email_templatesemail_template_desc.Text);
        item.email_template_from.SetValue(email_templatesemail_template_from.Text);
        item.email_template_subject.SetValue(email_templatesemail_template_subject.Text);
        item.email_template_body.SetValue(email_templatesemail_template_body.Text);
        if(EnableValidation)
            item.Validate(email_templatesData);
        email_templatesErrors.Add(item.errors);
    }
//End Record Form email_templates LoadItemFromRequest method

//Record Form email_templates GetRedirectUrl method @2-078BDC14
    protected string Getemail_templatesRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "email_templates.aspx";
        string p = parameters.ToString("GET","email_template_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form email_templates GetRedirectUrl method

//Record Form email_templates ShowErrors method @2-72E4DEE0
    protected void email_templatesShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<email_templatesErrors.Count;i++)
        switch(email_templatesErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=email_templatesErrors[i];
                break;
        }
        email_templatesError.Visible = true;
        email_templatesErrorLabel.Text = DefaultMessage;
    }
//End Record Form email_templates ShowErrors method

//Record Form email_templates Insert Operation @2-6FE697D6
    protected void email_templates_Insert(object sender, System.EventArgs e)
    {
        email_templatesIsSubmitted = true;
        bool ErrorFlag = false;
        email_templatesItem item=new email_templatesItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form email_templates Insert Operation

//Record Form email_templates BeforeInsert tail @2-18F2E1D4
    email_templatesParameters();
    email_templatesLoadItemFromRequest(item, EnableValidation);
//End Record Form email_templates BeforeInsert tail

//Record Form email_templates AfterInsert tail  @2-DD1E8265
        ErrorFlag=(email_templatesErrors.Count>0);
        if(ErrorFlag)
            email_templatesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form email_templates AfterInsert tail 

//Record Form email_templates Update Operation @2-939DEFB7
    protected void email_templates_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        email_templatesItem item=new email_templatesItem();
        item.IsNew = false;
        email_templatesIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form email_templates Update Operation

//Button Button_Update OnClick. @9-28108D45
        if(((Control)sender).ID == "email_templatesButton_Update")
        {
            RedirectUrl  = Getemail_templatesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @9-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form email_templates Before Update tail @2-AB20BDC8
        email_templatesParameters();
        email_templatesLoadItemFromRequest(item, EnableValidation);
        if(email_templatesOperations.AllowUpdate){
        ErrorFlag=(email_templatesErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                email_templatesData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                email_templatesErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form email_templates Before Update tail

//Record email_templates Event AfterUpdate. Action Custom Code @16-2A29BDB7
    // -------------------------
			DataAccessObject Conn =	Settings.calendarDataAccessObject;

			string LanguageID = (string)Session["locale"];
			string EmailTemplateID = CommonFunctions.CCGetFromGet("email_template_id","");
			string SQL = "";

			if (LanguageID == CommonFunctions.str_calendar_config("default_language")) {
				SQL = "UPDATE email_templates " +
					"SET email_template_desc = " + Conn.ToSql(email_templatesemail_template_desc.Text, FieldType.Text) +
					", email_template_subject = " + Conn.ToSql(email_templatesemail_template_subject.Text, FieldType.Text) +				
					", email_template_body = " + Conn.ToSql(email_templatesemail_template_body.Text, FieldType.Text) +
					"WHERE email_template_id = " + Conn.ToSql(EmailTemplateID, FieldType.Integer);
				Conn.RunSql(SQL);
			}

			SQL = "UPDATE email_templates_lang " +
				"SET email_template_desc = " + Conn.ToSql(email_templatesemail_template_desc.Text, FieldType.Text) +
				", email_template_subject = " + Conn.ToSql(email_templatesemail_template_subject.Text, FieldType.Text) +
				", email_template_body = " + Conn.ToSql(email_templatesemail_template_body.Text, FieldType.Text) +
				"WHERE email_templates_lang.language_id = " + Conn.ToSql(LanguageID, FieldType.Text) +
				" AND email_templates_lang.email_template_id = " + Conn.ToSql(EmailTemplateID, FieldType.Integer);

			Conn.RunSql(SQL);
    // -------------------------
//End Record email_templates Event AfterUpdate. Action Custom Code

//Record Form email_templates Update Operation tail @2-999908D9
        }
        ErrorFlag=(email_templatesErrors.Count>0);
        if(ErrorFlag)
            email_templatesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form email_templates Update Operation tail

//Record Form email_templates Delete Operation @2-71C0DDF9
    protected void email_templates_Delete(object sender,System.EventArgs e)
    {
        email_templatesIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        email_templatesItem item=new email_templatesItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form email_templates Delete Operation

//Record Form BeforeDelete tail @2-18F2E1D4
        email_templatesParameters();
        email_templatesLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @2-0C18A14E
        if(ErrorFlag)
            email_templatesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form email_templates Cancel Operation @2-C064F0B0
    protected void email_templates_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        email_templatesItem item=new email_templatesItem();
        email_templatesIsSubmitted = true;
        string RedirectUrl = "";
        email_templatesLoadItemFromRequest(item, false);
//End Record Form email_templates Cancel Operation

//Button Button_Cancel OnClick. @11-DA0A7C86
    if(((Control)sender).ID == "email_templatesButton_Cancel")
    {
        RedirectUrl  = Getemail_templatesRedirectUrl("", "");
//End Button Button_Cancel OnClick.

//Button Button_Cancel OnClick tail. @11-FCB6E20C
    }
//End Button Button_Cancel OnClick tail.

//Record Form email_templates Cancel Operation tail @2-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form email_templates Cancel Operation tail

//Button Button_Preview OnClick Handler @40-E0C2946E
    protected void email_templates_Button_Preview_OnClick(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        string RedirectUrl = Getemail_templatesRedirectUrl("", "");
        email_templatesItem item = new email_templatesItem();
        email_templatesLoadItemFromRequest(item, true);
        bool ErrorFlag=(email_templatesErrors.Count>0);
//End Button Button_Preview OnClick Handler

//Button Button_Preview OnClick Handler tail @40-0C18A14E
        if(ErrorFlag)
            email_templatesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Button Button_Preview OnClick Handler tail

//OnInit Event @1-539659C3
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        email_templates_maintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        email_templatesData = new email_templatesDataProvider();
        email_templatesOperations = new FormSupportedOperations(false, true, false, true, false);
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

