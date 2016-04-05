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

namespace calendar.lost_password{ //Namespace @1-B31E3934

//Forms Definition @1-1FF95F84
public partial class lost_passwordPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-B4B842DD
    protected ChangePasswordDataProvider ChangePasswordData;
    protected NameValueCollection ChangePasswordErrors=new NameValueCollection();
    protected bool ChangePasswordIsSubmitted = false;
    protected FormSupportedOperations ChangePasswordOperations;
    protected System.Resources.ResourceManager rm;
    protected string lost_passwordContentMeta;
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

//Record Form ChangePassword Parameters @5-B12F2A57
    protected void ChangePasswordParameters()
    {
        ChangePasswordItem item=ChangePasswordItem.CreateFromHttpRequest();
        try{
            ChangePasswordData.SesUserID = IntegerParameter.GetParam("UserID", ParameterSourceType.Session, "", null, false);
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

//Record Form ChangePassword BeforeShow tail @5-2E651509
        ChangePasswordParameters();
        ChangePasswordData.FillItem(item,ref IsInsertMode);
        ChangePasswordHolder.DataBind();
        ChangePasswordButton_Update.Visible=IsInsertMode&&ChangePasswordOperations.AllowInsert;
        ChangePasswordContentLabel.Text=item.ContentLabel.GetFormattedValue();
        ChangePasswordnew_password.Text=item.new_password.GetFormattedValue();
        ChangePasswordnew_password_confirm.Text=item.new_password_confirm.GetFormattedValue();
//End Record Form ChangePassword BeforeShow tail

//Label ContentLabel Event BeforeShow. Action Custom Code @23-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Label ContentLabel Event BeforeShow. Action Custom Code

//Record ChangePassword Event BeforeShow. Action Custom Code @14-2A29BDB7
    // -------------------------
	ChangePasswordnew_password.Text = "";
	ChangePasswordnew_password_confirm.Text = "";
    // -------------------------
//End Record ChangePassword Event BeforeShow. Action Custom Code

//Record Form ChangePassword Show method tail @5-0F3B8B62
        if(ChangePasswordErrors.Count>0)
            ChangePasswordShowErrors();
    }
//End Record Form ChangePassword Show method tail

//Record Form ChangePassword LoadItemFromRequest method @5-55F2BF36
    protected void ChangePasswordLoadItemFromRequest(ChangePasswordItem item, bool EnableValidation)
    {
        item.new_password.SetValue(ChangePasswordnew_password.Text);
        item.new_password_confirm.SetValue(ChangePasswordnew_password_confirm.Text);
        if(EnableValidation)
            item.Validate(ChangePasswordData);
        ChangePasswordErrors.Add(item.errors);
    }
//End Record Form ChangePassword LoadItemFromRequest method

//Record Form ChangePassword GetRedirectUrl method @5-F383CD6F
    protected string GetChangePasswordRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "info.aspx";
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

//Record Form ChangePassword Insert Operation @5-F61B628F
    protected void ChangePassword_Insert(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ChangePasswordIsSubmitted = true;
        bool ErrorFlag = false;
        ChangePasswordItem item=new ChangePasswordItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ChangePassword Insert Operation

//Button Button_Update OnClick. @9-0ADC68A6
        if(((Control)sender).ID == "ChangePasswordButton_Update")
        {
            RedirectUrl  = GetChangePasswordRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @9-FCB6E20C
        }
//End Button Button_Update OnClick tail.

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

//Record Form ChangePassword Update Operation @5-12C2017C
    protected void ChangePassword_Update(object sender, System.EventArgs e)
    {
        ChangePasswordItem item=new ChangePasswordItem();
        item.IsNew = false;
        ChangePasswordIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form ChangePassword Update Operation

//Record Form ChangePassword Before Update tail @5-CB0C7619
        ChangePasswordParameters();
        ChangePasswordLoadItemFromRequest(item, EnableValidation);
//End Record Form ChangePassword Before Update tail

//Record Form ChangePassword Update Operation tail @5-CDF0A64F
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

//OnInit Event @1-00791636
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        lost_passwordContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        ChangePasswordData = new ChangePasswordDataProvider();
        ChangePasswordOperations = new FormSupportedOperations(false, true, true, true, true);
//End OnInit Event

//Page lost_password Event AfterInitialize. Action Custom Code @19-2A29BDB7
    // -------------------------
		string PasswordHash = CommonFunctions.CCGetFromGet("pwd", "");
    
		//If user is logged in - back to index
		if (Convert.ToInt32(DBUtility.UserId) > 0)
			Response.Redirect("index.aspx");

		//If PasswordHash parameter is empty - back to index
		if (PasswordHash == "")
			Response.Redirect("index.aspx");

		string SQL = "SELECT user_id, user_login, user_level FROM users " +
			  " WHERE user_hash =" + Settings.calendarDataAccessObject.ToSql(PasswordHash, FieldType.Text);
		DataRowCollection RecordSet = Settings.calendarDataAccessObject.RunSql(SQL).Tables[0].Rows;
    	if (RecordSet.Count > 0)
		{
			string UserID    = Convert.ToString(RecordSet[0]["user_id"]);
			string UserLogin = Convert.ToString(RecordSet[0]["user_login"]);
			string UserLevel = Convert.ToString(RecordSet[0]["user_level"]);

			System.Web.HttpContext.Current.Session["user_login"] = UserLogin;
			string Content = CommonFunctions.GetContent("lost_password");
			if (Content==null) Content = " ";
			ChangePasswordContentLabel.Text = Content.Replace("{user_login}", UserLogin);
		}
		else	//If user is not found to index
		{
			Response.Redirect("index.aspx");
		}
    // -------------------------
//End Page lost_password Event AfterInitialize. Action Custom Code

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

