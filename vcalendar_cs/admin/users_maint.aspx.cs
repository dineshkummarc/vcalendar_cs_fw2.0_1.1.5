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

namespace calendar.admin.users_maint{ //Namespace @1-613859CD

//Forms Definition @1-BE1A3D98
public partial class users_maintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-469B429B
    protected users_maintDataProvider users_maintData;
    protected NameValueCollection users_maintErrors=new NameValueCollection();
    protected bool users_maintIsSubmitted = false;
    protected FormSupportedOperations users_maintOperations;
    protected System.Resources.ResourceManager rm;
    protected string users_maintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-AB27B567
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            users_maintShow();
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

//Record Form users_maint Parameters @2-99B2983A
    protected void users_maintParameters()
    {
        users_maintItem item=users_maintItem.CreateFromHttpRequest();
        try{
            users_maintData.Ctrluser_login = TextParameter.GetParam(item.user_login.Value, ParameterSourceType.Control, "", null, false);
            users_maintData.Ctrluser_date_add_h = DateParameter.GetParam(item.user_date_add_h.Value, ParameterSourceType.Control, Settings.DateFormat, null, false);
            users_maintData.Urluser_id = IntegerParameter.GetParam("user_id", ParameterSourceType.URL, "", null, false);
            users_maintData.Ctrluser_password = TextParameter.GetParam(item.user_password.Value, ParameterSourceType.Control, "", null, false);
            users_maintData.Ctrluser_level = IntegerParameter.GetParam(item.user_level.Value, ParameterSourceType.Control, "", null, false);
            users_maintData.Ctrluser_email = TextParameter.GetParam(item.user_email.Value, ParameterSourceType.Control, "", null, false);
            users_maintData.Ctrluser_first_name = TextParameter.GetParam(item.user_first_name.Value, ParameterSourceType.Control, "", null, false);
            users_maintData.Ctrluser_last_name = TextParameter.GetParam(item.user_last_name.Value, ParameterSourceType.Control, "", null, false);
            users_maintData.Ctrluser_is_approved = IntegerParameter.GetParam(item.user_is_approved.Value, ParameterSourceType.Control, "", null, false);
        }catch(Exception e){
            users_maintErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form users_maint Parameters

//Record Form users_maint Show method @2-F945430B
    protected void users_maintShow()
    {
        if(users_maintOperations.None)
        {
            users_maintHolder.Visible=false;
            return;
        }
        users_maintItem item=users_maintItem.CreateFromHttpRequest();
        bool IsInsertMode=!users_maintOperations.AllowRead;
        users_maintErrors.Add(item.errors);
//End Record Form users_maint Show method

//Record Form users_maint BeforeShow tail @2-5EF023C7
        users_maintParameters();
        users_maintData.FillItem(item,ref IsInsertMode);
        users_maintHolder.DataBind();
        users_maintButton_Insert.Visible=IsInsertMode&&users_maintOperations.AllowInsert;
        users_maintButton_Update.Visible=!IsInsertMode&&users_maintOperations.AllowUpdate;
        users_maintButton_Delete.Visible=!IsInsertMode&&users_maintOperations.AllowDelete;
        users_maintuser_login.Text=item.user_login.GetFormattedValue();
        users_maintuser_login_label.Text=Server.HtmlEncode(item.user_login_label.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        users_maintuser_password.Text=item.user_password.GetFormattedValue();
        item.user_levelItems.SetSelection(item.user_level.GetFormattedValue());
        users_maintuser_level.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        users_maintuser_level.Items[0].Selected = true;
        if(item.user_levelItems.GetSelectedItem() != null)
            users_maintuser_level.SelectedIndex = -1;
        item.user_levelItems.CopyTo(users_maintuser_level.Items);
        users_maintuser_email.Text=item.user_email.GetFormattedValue();
        users_maintuser_first_name.Text=item.user_first_name.GetFormattedValue();
        users_maintuser_last_name.Text=item.user_last_name.GetFormattedValue();
        if(item.user_is_approvedCheckedValue.Value.Equals(item.user_is_approved.Value))
            users_maintuser_is_approved.Checked = true;
        users_maintuser_date_add.Text=Server.HtmlEncode(item.user_date_add.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        users_maintuser_date_add_h.Value=item.user_date_add_h.GetFormattedValue();
//End Record Form users_maint BeforeShow tail

//Record users_maint Event BeforeShow. Action Hide-Show Component @18-45042B8A
        IntegerField Urluser_id_18_1 = new IntegerField("", System.Web.HttpContext.Current.Request.QueryString["user_id"]);
        IntegerField ExprParam2_18_2 = new IntegerField("", (0));
        if (Urluser_id_18_1 > ExprParam2_18_2) {
            users_maintuser_login.Visible = false;
        }
//End Record users_maint Event BeforeShow. Action Hide-Show Component

//Record Form users_maint Show method tail @2-4AC77A81
        if(users_maintErrors.Count>0)
            users_maintShowErrors();
    }
//End Record Form users_maint Show method tail

//Record Form users_maint LoadItemFromRequest method @2-EDBB4845
    protected void users_maintLoadItemFromRequest(users_maintItem item, bool EnableValidation)
    {
        item.user_login.IsEmpty = Request.Form[users_maintuser_login.UniqueID]==null;
        item.user_login.SetValue(users_maintuser_login.Text);
        item.user_password.SetValue(users_maintuser_password.Text);
        try{
        item.user_level.SetValue(users_maintuser_level.Value);
        item.user_levelItems.CopyFrom(users_maintuser_level.Items);
        }catch(ArgumentException){
            users_maintErrors.Add("user_level",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.user_level));}
        item.user_email.SetValue(users_maintuser_email.Text);
        item.user_first_name.SetValue(users_maintuser_first_name.Text);
        item.user_last_name.SetValue(users_maintuser_last_name.Text);
        item.user_is_approved.Value = users_maintuser_is_approved.Checked ?(item.user_is_approvedCheckedValue.Value):(item.user_is_approvedUncheckedValue.Value);
        try{
        item.user_date_add_h.SetValue(users_maintuser_date_add_h.Value);
        }catch(ArgumentException){
            users_maintErrors.Add("user_date_add_h",String.Format(Resources.strings.CCS_IncorrectFormat,"user_date_add_h",@"GeneralDate"));}
        if(EnableValidation)
            item.Validate(users_maintData);
        users_maintErrors.Add(item.errors);
    }
//End Record Form users_maint LoadItemFromRequest method

//Record Form users_maint GetRedirectUrl method @2-1A148588
    protected string Getusers_maintRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "users.aspx";
        string p = parameters.ToString("GET","user_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form users_maint GetRedirectUrl method

//Record Form users_maint ShowErrors method @2-D774709A
    protected void users_maintShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<users_maintErrors.Count;i++)
        switch(users_maintErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=users_maintErrors[i];
                break;
        }
        users_maintError.Visible = true;
        users_maintErrorLabel.Text = DefaultMessage;
    }
//End Record Form users_maint ShowErrors method

//Record Form users_maint Insert Operation @2-C4D52793
    protected void users_maint_Insert(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        users_maintIsSubmitted = true;
        bool ErrorFlag = false;
        users_maintItem item=new users_maintItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users_maint Insert Operation

//Button Button_Insert OnClick. @10-3BE088A7
        if(((Control)sender).ID == "users_maintButton_Insert")
        {
            RedirectUrl  = Getusers_maintRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Insert OnClick.

//Button Button_Insert Event OnClick. Action Custom Code @38-2A29BDB7
    // -------------------------
	    	if (users_maintuser_login.Text.Length == 0) {
                users_maintErrors.Add("user_login",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("user_login")));
	            users_maintShowErrors();
				return;
			}
    // -------------------------
//End Button Button_Insert Event OnClick. Action Custom Code

//Button Button_Insert OnClick tail. @10-FCB6E20C
        }
//End Button Button_Insert OnClick tail.

//Record Form users_maint BeforeInsert tail @2-131DD302
    users_maintParameters();
    users_maintLoadItemFromRequest(item, EnableValidation);
    if(users_maintOperations.AllowInsert){
    ErrorFlag=(users_maintErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                users_maintData.InsertItem(item);
            }
            catch (Exception ex)
            {
                users_maintErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form users_maint BeforeInsert tail

//Record Form users_maint AfterInsert tail  @2-09A37FE2
        }
        ErrorFlag=(users_maintErrors.Count>0);
        if(ErrorFlag)
            users_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users_maint AfterInsert tail 

//Record Form users_maint Update Operation @2-CFDCA6F6
    protected void users_maint_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        users_maintItem item=new users_maintItem();
        item.IsNew = false;
        users_maintIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users_maint Update Operation

//Button Button_Update OnClick. @11-38E00BE7
        if(((Control)sender).ID == "users_maintButton_Update")
        {
            RedirectUrl  = Getusers_maintRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @11-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form users_maint Before Update tail @2-40FFF275
        users_maintParameters();
        users_maintLoadItemFromRequest(item, EnableValidation);
        if(users_maintOperations.AllowUpdate){
        ErrorFlag=(users_maintErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                users_maintData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                users_maintErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form users_maint Before Update tail

//Record Form users_maint Update Operation tail @2-09A37FE2
        }
        ErrorFlag=(users_maintErrors.Count>0);
        if(ErrorFlag)
            users_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users_maint Update Operation tail

//Record Form users_maint Delete Operation @2-55266F41
    protected void users_maint_Delete(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        users_maintIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        users_maintItem item=new users_maintItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form users_maint Delete Operation

//Button Button_Delete OnClick. @12-BBA0136D
        if(((Control)sender).ID == "users_maintButton_Delete")
        {
            RedirectUrl  = Getusers_maintRedirectUrl("", "");
            EnableValidation  = false;
//End Button Button_Delete OnClick.

//Button Button_Delete OnClick tail. @12-FCB6E20C
        }
//End Button Button_Delete OnClick tail.

//Record Form BeforeDelete tail @2-E32FD722
        users_maintParameters();
        users_maintLoadItemFromRequest(item, EnableValidation);
        if(users_maintOperations.AllowDelete){
        ErrorFlag = (users_maintErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                users_maintData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                users_maintErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @2-8980B782
        }
        if(ErrorFlag)
            users_maintShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form users_maint Cancel Operation @2-5872D568
    protected void users_maint_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        users_maintItem item=new users_maintItem();
        users_maintIsSubmitted = true;
        string RedirectUrl = "";
        users_maintLoadItemFromRequest(item, false);
//End Record Form users_maint Cancel Operation

//Button Button_Cancel OnClick. @13-B040E26C
    if(((Control)sender).ID == "users_maintButton_Cancel")
    {
        RedirectUrl  = Getusers_maintRedirectUrl("", "");
//End Button Button_Cancel OnClick.

//Button Button_Cancel OnClick tail. @13-FCB6E20C
    }
//End Button Button_Cancel OnClick tail.

//Record Form users_maint Cancel Operation tail @2-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form users_maint Cancel Operation tail

//OnInit Event @1-99515F56
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        users_maintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        users_maintData = new users_maintDataProvider();
        users_maintOperations = new FormSupportedOperations(false, true, true, true, true);
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

