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

namespace calendar.registration{ //Namespace @1-8EBE6325

//Forms Definition @1-7876C029
public partial class registrationPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-D4A3C67B
    protected usersDataProvider usersData;
    protected NameValueCollection usersErrors=new NameValueCollection();
    protected bool usersIsSubmitted = false;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string registrationContentMeta;
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

//Record Form users Parameters @5-CEF27B38
    protected void usersParameters()
    {
        usersItem item=usersItem.CreateFromHttpRequest();
        try{
            usersData.Urluser_id = IntegerParameter.GetParam("user_id", ParameterSourceType.URL, "", null, false);
            usersData.Ctrluser_login = TextParameter.GetParam(item.user_login.Value, ParameterSourceType.Control, "", null, false);
            usersData.Ctrluser_password = TextParameter.GetParam(item.user_password.Value, ParameterSourceType.Control, "", null, false);
            usersData.Ctrluser_first_name = TextParameter.GetParam(item.user_first_name.Value, ParameterSourceType.Control, "", null, false);
            usersData.Ctrluser_last_name = TextParameter.GetParam(item.user_last_name.Value, ParameterSourceType.Control, "", null, false);
            usersData.Ctrluser_email = TextParameter.GetParam(item.user_email.Value, ParameterSourceType.Control, "", null, false);
            usersData.Ctrluser_is_approved = IntegerParameter.GetParam(item.user_is_approved.Value, ParameterSourceType.Control, "", null, false);
            usersData.Ctrluser_level = IntegerParameter.GetParam(item.user_level.Value, ParameterSourceType.Control, "", null, false);
            usersData.Ctrluser_access_code = IntegerParameter.GetParam(item.user_access_code.Value, ParameterSourceType.Control, "", null, false);
            usersData.Expr34 = DateParameter.GetParam(DateTime.Now, ParameterSourceType.Expression, Settings.DateFormat, null, false);
        }catch(Exception e){
            usersErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form users Parameters

//Record Form users Show method @5-954118C6
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

//Record Form users BeforeShow tail @5-2D5417A8
        usersParameters();
        usersData.FillItem(item,ref IsInsertMode);
        usersHolder.DataBind();
        usersButton_Insert.Visible=IsInsertMode&&usersOperations.AllowInsert;
        usersuser_login.Text=item.user_login.GetFormattedValue();
        usersuser_password.Text=item.user_password.GetFormattedValue();
        usersConfirmPassword.Text=item.ConfirmPassword.GetFormattedValue();
        usersuser_first_name.Text=item.user_first_name.GetFormattedValue();
        usersuser_last_name.Text=item.user_last_name.GetFormattedValue();
        usersuser_email.Text=item.user_email.GetFormattedValue();
        usersuser_is_approved.Value=item.user_is_approved.GetFormattedValue();
        usersuser_level.Value=item.user_level.GetFormattedValue();
        usersuser_access_code.Value=item.user_access_code.GetFormattedValue();
//End Record Form users BeforeShow tail

//Record Form users Show method tail @5-00ECC24D
        if(usersErrors.Count>0)
            usersShowErrors();
    }
//End Record Form users Show method tail

//Record Form users LoadItemFromRequest method @5-7655D8EC
    protected void usersLoadItemFromRequest(usersItem item, bool EnableValidation)
    {
        item.user_login.SetValue(usersuser_login.Text);
        item.user_password.SetValue(usersuser_password.Text);
        item.ConfirmPassword.SetValue(usersConfirmPassword.Text);
        item.user_first_name.SetValue(usersuser_first_name.Text);
        item.user_last_name.SetValue(usersuser_last_name.Text);
        item.user_email.SetValue(usersuser_email.Text);
        try{
        item.user_is_approved.SetValue(usersuser_is_approved.Value);
        }catch(ArgumentException){
            usersErrors.Add("user_is_approved",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.user_is_approved));}
        try{
        item.user_level.SetValue(usersuser_level.Value);
        }catch(ArgumentException){
            usersErrors.Add("user_level",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.user_level));}
        try{
        item.user_access_code.SetValue(usersuser_access_code.Value);
        }catch(ArgumentException){
            usersErrors.Add("user_access_code",String.Format(Resources.strings.CCS_IncorrectValue,"user_access_code"));}
        if(EnableValidation)
            item.Validate(usersData);
        usersErrors.Add(item.errors);
    }
//End Record Form users LoadItemFromRequest method

//Record Form users GetRedirectUrl method @5-1322910B
    protected string GetusersRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "info.aspx";
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form users GetRedirectUrl method

//Record Form users ShowErrors method @5-10DEF0D1
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

//Record Form users Insert Operation @5-EE5933DD
    protected void users_Insert(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        usersItem item=new usersItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Insert Operation

//Button Button_Insert OnClick. @6-88F732F5
        if(((Control)sender).ID == "usersButton_Insert")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Insert OnClick.

//Button Button_Insert OnClick tail. @6-FCB6E20C
        }
//End Button Button_Insert OnClick tail.

//Record users Event BeforeInsert. Action Custom Code @21-2A29BDB7
    // -------------------------
		switch (CommonFunctions.int_calendar_config("registration_type"))
		{
			case 1:	
				usersuser_is_approved.Value = "1";
				usersuser_level.Value = "10";
				break;
			case 4:
				Random Rnd = new Random();
				usersuser_access_code.Value = Convert.ToInt32(Rnd.Next(8887) + 1111).ToString() + Convert.ToInt32(Rnd.Next(8887) + 1111).ToString();
				usersuser_is_approved.Value = "0";
				usersuser_level.Value = "1";
				break;
			case 8:
				usersuser_is_approved.Value = "0";
				usersuser_level.Value = "1";
				break;
		}
    // -------------------------
//End Record users Event BeforeInsert. Action Custom Code

//Record Form users BeforeInsert tail @5-491CA3DB
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

//Record users Event AfterInsert. Action Custom Code @22-2A29BDB7
    // -------------------------
		Hashtable Parameters = new Hashtable();
		Parameters.Add("{user_name}",  usersuser_first_name.Text);
		Parameters.Add("{user_login}",  usersuser_login.Text);
		Parameters.Add("{user_email}", usersuser_email.Text);
		Parameters.Add("{date_time}",  DateTime.Now.ToString("yyyy-mm-dd HH:nn:ss"));
		Parameters.Add("{activate_url}", Settings.ServerURL + "confirm.aspx?name="  +  usersuser_login.Text + "&acc=" + usersuser_access_code.Value);
		Parameters.Add("{subject}", "[VCalendar] Confirm your registration.");

		Session["content_param"] = Parameters;
		switch (CommonFunctions.int_calendar_config("registration_type"))
		{
			case 1:	
				Session["content_type"]  = "registration_message";
				break;
			case 4:
				Session["content_type"]  = "registration_need_confirm";
				CommonFunctions.SendEmailMessage("confirm_registration", usersuser_email.Text, Parameters);
				break;
			case 8:
				Session["content_type"]  = "registration_need_approve";
				break;
		}
    // -------------------------
//End Record users Event AfterInsert. Action Custom Code

//Record Form users AfterInsert tail  @5-5E366B58
        }
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users AfterInsert tail 

//Record Form users Update Operation @5-BCEC6559
    protected void users_Update(object sender, System.EventArgs e)
    {
        usersItem item=new usersItem();
        item.IsNew = false;
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Update Operation

//Record Form users Before Update tail @5-53B6D1FB
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
//End Record Form users Before Update tail

//Record Form users Update Operation tail @5-A7671D59
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users Update Operation tail

//Record Form users Delete Operation @5-F49BCB30
    protected void users_Delete(object sender,System.EventArgs e)
    {
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        usersItem item=new usersItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form users Delete Operation

//Record Form BeforeDelete tail @5-53B6D1FB
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @5-BC445D80
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form users Cancel Operation @5-61ADD70F
    protected void users_Cancel(object sender,System.EventArgs e)
    {
        usersItem item=new usersItem();
        usersIsSubmitted = true;
        string RedirectUrl = "";
        usersLoadItemFromRequest(item, true);
//End Record Form users Cancel Operation

//Record Form users Cancel Operation tail @5-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form users Cancel Operation tail

//OnInit Event @1-A0EAEB11
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        registrationContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, false, true, false, false);
//End OnInit Event

//Page registration Event AfterInitialize. Action Custom Code @35-2A29BDB7
    // -------------------------
	if (CommonFunctions.str_calendar_config("registration_type") == "0") 
		Response.Redirect("index.aspx");
    // -------------------------
//End Page registration Event AfterInitialize. Action Custom Code

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

