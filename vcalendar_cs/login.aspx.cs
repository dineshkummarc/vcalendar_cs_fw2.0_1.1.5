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

namespace calendar.login{ //Namespace @1-978FDA69

//Forms Definition @1-C81588FD
public partial class loginPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-2F253F49
    protected LoginDataProvider LoginData;
    protected NameValueCollection LoginErrors=new NameValueCollection();
    protected bool LoginIsSubmitted = false;
    protected FormSupportedOperations LoginOperations;
    protected System.Resources.ResourceManager rm;
    protected string loginContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-70878C18
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.registerHref = "registration.aspx";
            item.remindHref = "remind_password.aspx";
            PageData.FillItem(item);
            register.InnerText=Resources.strings.registration;
            register.HRef = item.registerHref+item.registerHrefParameters.ToString("None","", ViewState);
            remind.InnerText=Resources.strings.cal_remind_password;
            remind.HRef = item.remindHref+item.remindHrefParameters.ToString("None","", ViewState);
            LoginShow();
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

//Record Form Login Parameters @5-A11E2702
    protected void LoginParameters()
    {
        LoginItem item=LoginItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            LoginErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form Login Parameters

//Record Form Login Show method @5-E37F353E
    protected void LoginShow()
    {
        if(LoginOperations.None)
        {
            LoginHolder.Visible=false;
            return;
        }
        LoginItem item=LoginItem.CreateFromHttpRequest();
        bool IsInsertMode=!LoginOperations.AllowRead;
        LoginErrors.Add(item.errors);
//End Record Form Login Show method

//Record Form Login BeforeShow tail @5-A3B6E6E0
        LoginParameters();
        LoginData.FillItem(item,ref IsInsertMode);
        LoginHolder.DataBind();
        Loginlogin.Text=item.login.GetFormattedValue();
        Loginpassword.Text=item.password.GetFormattedValue();
//End Record Form Login BeforeShow tail

//Record Form Login Show method tail @5-BE5E2744
        if(LoginErrors.Count>0)
            LoginShowErrors();
    }
//End Record Form Login Show method tail

//Record Form Login LoadItemFromRequest method @5-3457193E
    protected void LoginLoadItemFromRequest(LoginItem item, bool EnableValidation)
    {
        item.login.SetValue(Loginlogin.Text);
        item.password.SetValue(Loginpassword.Text);
        if(EnableValidation)
            item.Validate(LoginData);
        LoginErrors.Add(item.errors);
    }
//End Record Form Login LoadItemFromRequest method

//Record Form Login GetRedirectUrl method @5-5223A54E
    protected string GetLoginRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "index.aspx";
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form Login GetRedirectUrl method

//Record Form Login ShowErrors method @5-2C2FA8B0
    protected void LoginShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<LoginErrors.Count;i++)
        switch(LoginErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=LoginErrors[i];
                break;
        }
        LoginError.Visible = true;
        LoginErrorLabel.Text = DefaultMessage;
    }
//End Record Form Login ShowErrors method

//Record Form Login Insert Operation @5-F4ECCAB2
    protected void Login_Insert(object sender, System.EventArgs e)
    {
        LoginIsSubmitted = true;
        bool ErrorFlag = false;
        LoginItem item=new LoginItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form Login Insert Operation

//Record Form Login BeforeInsert tail @5-C431FE86
    LoginParameters();
    LoginLoadItemFromRequest(item, EnableValidation);
//End Record Form Login BeforeInsert tail

//Record Form Login AfterInsert tail  @5-64493628
        ErrorFlag=(LoginErrors.Count>0);
        if(ErrorFlag)
            LoginShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form Login AfterInsert tail 

//Record Form Login Update Operation @5-AD01C242
    protected void Login_Update(object sender, System.EventArgs e)
    {
        LoginItem item=new LoginItem();
        item.IsNew = false;
        LoginIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form Login Update Operation

//Record Form Login Before Update tail @5-C431FE86
        LoginParameters();
        LoginLoadItemFromRequest(item, EnableValidation);
//End Record Form Login Before Update tail

//Record Form Login Update Operation tail @5-64493628
        ErrorFlag=(LoginErrors.Count>0);
        if(ErrorFlag)
            LoginShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form Login Update Operation tail

//Record Form Login Delete Operation @5-3D922716
    protected void Login_Delete(object sender,System.EventArgs e)
    {
        LoginIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        LoginItem item=new LoginItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form Login Delete Operation

//Record Form BeforeDelete tail @5-C431FE86
        LoginParameters();
        LoginLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @5-F7A13490
        if(ErrorFlag)
            LoginShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form Login Cancel Operation @5-28FC1EB7
    protected void Login_Cancel(object sender,System.EventArgs e)
    {
        LoginItem item=new LoginItem();
        LoginIsSubmitted = true;
        string RedirectUrl = "";
        LoginLoadItemFromRequest(item, true);
//End Record Form Login Cancel Operation

//Record Form Login Cancel Operation tail @5-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form Login Cancel Operation tail

//Button Button_DoLogin OnClick Handler @6-8A58A1D2
    protected void Login_Button_DoLogin_OnClick(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        string RedirectUrl = GetLoginRedirectUrl("", "");
        LoginItem item = new LoginItem();
        LoginLoadItemFromRequest(item, true);
        bool ErrorFlag=(LoginErrors.Count>0);
//End Button Button_DoLogin OnClick Handler

//Button Button_DoLogin Event OnClick. Action Custom Code @13-2A29BDB7
    // -------------------------
		DataAccessObject Conn =	Settings.calendarDataAccessObject;
  		string SQL = "SELECT user_is_approved FROM users WHERE user_login=" + Conn.ToSql(Loginlogin.Text, FieldType.Text);
		DataRowCollection dr = Conn.RunSql(SQL).Tables[0].Rows;
		if (dr.Count > 0) 
		{
			if (Convert.ToString(dr[0]["user_is_approved"]) == "0") 
			{
				LoginErrors.Add("",((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_LoginInactive"));
				Loginpassword.Text = "";
				LoginShowErrors();
				return;
			} 
			else 
			{
				string str = "UPDATE users SET user_last_login=" + Conn.ToSql(DateTime.Now.ToString(Conn.DateFormat), FieldType.Date) + " WHERE user_login=" + Conn.ToSql(Loginlogin.Text, FieldType.Text);
				Conn.RunSql(str);
			}
		}
    // -------------------------
//End Button Button_DoLogin Event OnClick. Action Custom Code

//Button Button_DoLogin Event OnClick. Action Login @14-5299DA25
        if ( Membership.ValidateUser(Loginlogin.Text,Loginpassword.Text)) {
            FormsAuthentication.SetAuthCookie(Loginlogin.Text, false);
            if(HttpContext.Current.Request["ret_link"]!=null&&HttpContext.Current.Request["ret_link"]!="")
                Response.Redirect(HttpContext.Current.Request["ret_link"]);
        }else{
            ErrorFlag=true;
            LoginErrors.Add("",Resources.strings.CCS_LoginError);
        }
//End Button Button_DoLogin Event OnClick. Action Login

//Button Button_DoLogin OnClick Handler tail @6-F7A13490
        if(ErrorFlag)
            LoginShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Button Button_DoLogin OnClick Handler tail

//OnInit Event @1-324C9E17
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        loginContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        LoginData = new LoginDataProvider();
        LoginOperations = new FormSupportedOperations(false, true, true, true, true);
//End OnInit Event

//Page login Event AfterInitialize. Action Custom Code @15-2A29BDB7
    // -------------------------
		if (CommonFunctions.str_calendar_config("registration_type") == "0")
			RegPanel.Visible = false;
    // -------------------------
//End Page login Event AfterInitialize. Action Custom Code

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

