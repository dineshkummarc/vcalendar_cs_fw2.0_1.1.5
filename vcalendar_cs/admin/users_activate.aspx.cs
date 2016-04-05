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

namespace calendar.admin.users_activate{ //Namespace @1-5391A87D

//Forms Definition @1-F61B40C8
public partial class users_activatePage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-70DE14B2
    protected usersDataProvider usersData;
    protected NameValueCollection usersErrors=new NameValueCollection();
    protected bool usersIsSubmitted = false;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string users_activateContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-77FCC4BC
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            usersShow();
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

//Record Form users Parameters @3-2CD9C15B
    protected void usersParameters()
    {
        usersItem item=usersItem.CreateFromHttpRequest();
        try{
            usersData.Expr26 = IntegerParameter.GetParam(0, ParameterSourceType.Expression, "", null, false);
            usersData.Expr27 = IntegerParameter.GetParam(1, ParameterSourceType.Expression, "", null, false);
            usersData.Expr20 = IntegerParameter.GetParam(1, ParameterSourceType.Expression, "", null, false);
            usersData.Expr22 = IntegerParameter.GetParam(10, ParameterSourceType.Expression, "", null, false);
            usersData.Urluser_id = IntegerParameter.GetParam("user_id", ParameterSourceType.URL, "", null, false);
        }catch(Exception e){
            usersErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form users Parameters

//Record Form users Show method @3-954118C6
    protected void usersShow()
    {
        if(usersOperations.None)
        {
            usersHolder.Visible=false;
            return;
        }
        usersItem item=usersItem.CreateFromHttpRequest();
        bool IsInsertMode=!usersOperations.AllowRead;
        usersErrors.Add(item.errors);
//End Record Form users Show method

//Record Form users BeforeShow tail @3-6E7A94FA
        usersParameters();
        usersData.FillItem(item,ref IsInsertMode);
        usersHolder.DataBind();
        usersButton_Update.Visible=!IsInsertMode&&usersOperations.AllowUpdate;
        usersButton_Delete.Visible=!IsInsertMode&&usersOperations.AllowDelete;
        usersuser_login.Text=Server.HtmlEncode(item.user_login.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        usersuser_email.Text=Server.HtmlEncode(item.user_email.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        usersuser_first_name.Text=Server.HtmlEncode(item.user_first_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        usersuser_last_name.Text=Server.HtmlEncode(item.user_last_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        usersuser_date_add.Text=Server.HtmlEncode(item.user_date_add.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
//End Record Form users BeforeShow tail

//Record Form users Show method tail @3-00ECC24D
        if(usersErrors.Count>0)
            usersShowErrors();
    }
//End Record Form users Show method tail

//Record Form users LoadItemFromRequest method @3-78A27791
    protected void usersLoadItemFromRequest(usersItem item, bool EnableValidation)
    {
        if(EnableValidation)
            item.Validate(usersData);
        usersErrors.Add(item.errors);
    }
//End Record Form users LoadItemFromRequest method

//Record Form users GetRedirectUrl method @3-B7D8B08B
    protected string GetusersRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "index.aspx";
        string p = parameters.ToString("GET","user_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form users GetRedirectUrl method

//Record Form users ShowErrors method @3-10DEF0D1
    protected void usersShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<usersErrors.Count;i++)
        switch(usersErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=usersErrors[i];
                break;
        }
        usersError.Visible = true;
        usersErrorLabel.Text = DefaultMessage;
    }
//End Record Form users ShowErrors method

//Record Form users Insert Operation @3-D59EDEA8
    protected void users_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        usersItem item=new usersItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Insert Operation

//Record Form users BeforeInsert tail @3-491CA3DB
    usersParameters();
    usersLoadItemFromRequest(item, EnableValidation);
    if(usersOperations.AllowInsert){
    ErrorFlag=(usersErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                usersData.InsertItem(item);
            }
            catch (Exception ex)
            {
                usersErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form users BeforeInsert tail

//Record Form users AfterInsert tail  @3-5E366B58
        }
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users AfterInsert tail 

//Record Form users Update Operation @3-DEC8ED4E
    protected void users_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        usersItem item=new usersItem();
        item.IsNew = false;
        usersIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Update Operation

//Button Button_Update OnClick. @5-67E8FE71
        if(((Control)sender).ID == "usersButton_Update")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @5-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form users Before Update tail @3-26DEC238
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
        if(usersOperations.AllowUpdate){
        ErrorFlag=(usersErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                usersData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                usersErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form users Before Update tail

//Record users Event AfterUpdate. Action Custom Code @34-2A29BDB7
    // -------------------------
		Hashtable Parameters = new Hashtable();
		Parameters.Add("{user_login}", usersuser_login.Text);
		Parameters.Add("{site_url}", Settings.ServerURL);

		CommonFunctions.SendEmailMessage("approval_message", usersuser_email.Text, Parameters);
    // -------------------------
//End Record users Event AfterUpdate. Action Custom Code

//Record Form users Update Operation tail @3-5E366B58
        }
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users Update Operation tail

//Record Form users Delete Operation @3-63A651FE
    protected void users_Delete(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        usersItem item=new usersItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form users Delete Operation

//Button Button_Delete OnClick. @6-08DC884D
        if(((Control)sender).ID == "usersButton_Delete")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = false;
//End Button Button_Delete OnClick.

//Button Button_Delete OnClick tail. @6-FCB6E20C
        }
//End Button Button_Delete OnClick tail.

//Record Form BeforeDelete tail @3-D76FA851
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
        if(usersOperations.AllowDelete){
        ErrorFlag = (usersErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                usersData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                usersErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @3-CCCD5F10
        }
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form users Cancel Operation @3-A86318F5
    protected void users_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        usersItem item=new usersItem();
        usersIsSubmitted = true;
        string RedirectUrl = "";
        usersLoadItemFromRequest(item, false);
//End Record Form users Cancel Operation

//Button Button_Cancel OnClick. @7-D3EE78DF
    if(((Control)sender).ID == "usersButton_Cancel")
    {
        RedirectUrl  = GetusersRedirectUrl("", "");
//End Button Button_Cancel OnClick.

//Button Button_Cancel OnClick tail. @7-FCB6E20C
    }
//End Button Button_Cancel OnClick tail.

//Record Form users Cancel Operation tail @3-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form users Cancel Operation tail

//OnInit Event @1-CC6088DF
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        users_activateContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, true, true, true, true);
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

