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

namespace calendar.change_password{ //Namespace @1-5319C972

//Forms Definition @1-7CA14938
public partial class change_passwordPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-40609BE9
    protected ChangePasswordDataProvider ChangePasswordData;
    protected NameValueCollection ChangePasswordErrors=new NameValueCollection();
    protected bool ChangePasswordIsSubmitted = false;
    protected FormSupportedOperations ChangePasswordOperations;
    protected System.Resources.ResourceManager rm;
    protected string change_passwordContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-A7F44991
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            ChangePasswordShow();
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

//Record Form ChangePassword Parameters @5-20FBD308
    protected void ChangePasswordParameters()
    {
        ChangePasswordItem item=ChangePasswordItem.CreateFromHttpRequest();
        try{
            ChangePasswordData.Expr18 = IntegerParameter.GetParam(DBUtility.UserId, ParameterSourceType.Expression, "", null, false);
        }catch(Exception e){
            ChangePasswordErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form ChangePassword Parameters

//Record Form ChangePassword Show method @5-CFD00186
    protected void ChangePasswordShow()
    {
        if(ChangePasswordOperations.None)
        {
            ChangePasswordHolder.Visible=false;
            return;
        }
        ChangePasswordItem item=ChangePasswordItem.CreateFromHttpRequest();
        bool IsInsertMode=!ChangePasswordOperations.AllowRead;
        ChangePasswordErrors.Add(item.errors);
//End Record Form ChangePassword Show method

//Record Form ChangePassword BeforeShow tail @5-948901C8
        ChangePasswordParameters();
        ChangePasswordData.FillItem(item,ref IsInsertMode);
        ChangePasswordHolder.DataBind();
        ChangePasswordButton_Update.Visible=!IsInsertMode&&ChangePasswordOperations.AllowUpdate;
        ChangePasswordcurrent_password.Text=item.current_password.GetFormattedValue();
        ChangePasswordnew_password.Text=item.new_password.GetFormattedValue();
        ChangePasswordnew_password_confirm.Text=item.new_password_confirm.GetFormattedValue();
//End Record Form ChangePassword BeforeShow tail

//Record ChangePassword Event BeforeShow. Action Custom Code @14-2A29BDB7
    // -------------------------
	ChangePasswordcurrent_password.Text = "";
	ChangePasswordnew_password.Text = "";
	ChangePasswordnew_password_confirm.Text = "";
    // -------------------------
//End Record ChangePassword Event BeforeShow. Action Custom Code

//Record Form ChangePassword Show method tail @5-0F3B8B62
        if(ChangePasswordErrors.Count>0)
            ChangePasswordShowErrors();
    }
//End Record Form ChangePassword Show method tail

//Record Form ChangePassword LoadItemFromRequest method @5-E23AA0B4
    protected void ChangePasswordLoadItemFromRequest(ChangePasswordItem item, bool EnableValidation)
    {
        item.current_password.SetValue(ChangePasswordcurrent_password.Text);
        item.new_password.SetValue(ChangePasswordnew_password.Text);
        item.new_password_confirm.SetValue(ChangePasswordnew_password_confirm.Text);
        if(EnableValidation)
            item.Validate(ChangePasswordData);
        ChangePasswordErrors.Add(item.errors);
    }
//End Record Form ChangePassword LoadItemFromRequest method

//Record Form ChangePassword GetRedirectUrl method @5-DB21AF29
    protected string GetChangePasswordRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form ChangePassword GetRedirectUrl method

//Record Form ChangePassword ShowErrors method @5-E3FA2188
    protected void ChangePasswordShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<ChangePasswordErrors.Count;i++)
        switch(ChangePasswordErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=ChangePasswordErrors[i];
                break;
        }
        ChangePasswordError.Visible = true;
        ChangePasswordErrorLabel.Text = DefaultMessage;
    }
//End Record Form ChangePassword ShowErrors method

//Record Form ChangePassword Insert Operation @5-306B8FBA
    protected void ChangePassword_Insert(object sender, System.EventArgs e)
    {
        ChangePasswordIsSubmitted = true;
        bool ErrorFlag = false;
        ChangePasswordItem item=new ChangePasswordItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ChangePassword Insert Operation

//Record Form ChangePassword BeforeInsert tail @5-CB0C7619
    ChangePasswordParameters();
    ChangePasswordLoadItemFromRequest(item, EnableValidation);
//End Record Form ChangePassword BeforeInsert tail

//Record Form ChangePassword AfterInsert tail  @5-CDF0A64F
        ErrorFlag=(ChangePasswordErrors.Count>0);
        if(ErrorFlag)
            ChangePasswordShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form ChangePassword AfterInsert tail 

//Record Form ChangePassword Update Operation @5-F6CE939C
    protected void ChangePassword_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ChangePasswordItem item=new ChangePasswordItem();
        item.IsNew = false;
        ChangePasswordIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ChangePassword Update Operation

//Button Button_Update OnClick. @9-0ADC68A6
        if(((Control)sender).ID == "ChangePasswordButton_Update")
        {
            RedirectUrl  = GetChangePasswordRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @9-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form ChangePassword Before Update tail @5-5C42B111
        ChangePasswordParameters();
        ChangePasswordLoadItemFromRequest(item, EnableValidation);
        if(ChangePasswordOperations.AllowUpdate){
        ErrorFlag=(ChangePasswordErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                ChangePasswordData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                ChangePasswordErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form ChangePassword Before Update tail

//Record ChangePassword Event AfterUpdate. Action Custom Code @15-2A29BDB7
    // -------------------------
	Hashtable Parameters = new Hashtable();
	Parameters.Add("{user_login}",DBUtility.UserLogin);
	Parameters.Add("{profile_url}","profile.aspx");

	Session["content_param"] = Parameters;
	Session["content_type"]  = "password_changed";
	RedirectUrl = "info.aspx";
    // -------------------------
//End Record ChangePassword Event AfterUpdate. Action Custom Code

//Record Form ChangePassword Update Operation tail @5-B9BA0D58
        }
        ErrorFlag=(ChangePasswordErrors.Count>0);
        if(ErrorFlag)
            ChangePasswordShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form ChangePassword Update Operation tail

//Record Form ChangePassword Delete Operation @5-9E3C652D
    protected void ChangePassword_Delete(object sender,System.EventArgs e)
    {
        ChangePasswordIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        ChangePasswordItem item=new ChangePasswordItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form ChangePassword Delete Operation

//Record Form BeforeDelete tail @5-CB0C7619
        ChangePasswordParameters();
        ChangePasswordLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @5-F5152552
        if(ErrorFlag)
            ChangePasswordShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form ChangePassword Cancel Operation @5-C2B1A0F1
    protected void ChangePassword_Cancel(object sender,System.EventArgs e)
    {
        ChangePasswordItem item=new ChangePasswordItem();
        ChangePasswordIsSubmitted = true;
        string RedirectUrl = "";
        ChangePasswordLoadItemFromRequest(item, true);
//End Record Form ChangePassword Cancel Operation

//Record Form ChangePassword Cancel Operation tail @5-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form ChangePassword Cancel Operation tail

//OnInit Event @1-BB0ECEB6
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        change_passwordContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        ChangePasswordData = new ChangePasswordDataProvider();
        ChangePasswordOperations = new FormSupportedOperations(false, true, false, true, false);
        if(!DBUtility.AuthorizeUser(new string[]{
          "10",
          "100"}))
            Response.Redirect("login.aspx"+"?ret_link="+Server.UrlEncode(Request["SCRIPT_NAME"]+"?"+Request["QUERY_STRING"]));
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

