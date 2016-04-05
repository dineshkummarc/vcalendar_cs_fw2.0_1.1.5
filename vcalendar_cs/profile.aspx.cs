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

namespace calendar.profile{ //Namespace @1-8B1D1898

//Forms Definition @1-68EF8BE7
public partial class profilePage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-ECF678D1
    protected usersDataProvider usersData;
    protected NameValueCollection usersErrors=new NameValueCollection();
    protected bool usersIsSubmitted = false;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string profileContentMeta;
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

//Record Form users Parameters @16-3DF1DA54
    protected void usersParameters()
    {
        usersItem item=usersItem.CreateFromHttpRequest();
        try{
            usersData.Expr22 = IntegerParameter.GetParam(DBUtility.UserId, ParameterSourceType.Expression, "", null, false);
        }catch(Exception e){
            usersErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form users Parameters

//Record Form users Show method @16-954118C6
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

//Record Form users BeforeShow tail @16-6CC72A2A
        usersParameters();
        usersData.FillItem(item,ref IsInsertMode);
        usersHolder.DataBind();
        usersButton_Update.Visible=!IsInsertMode&&usersOperations.AllowUpdate;
        usersuser_login.Text=Server.HtmlEncode(item.user_login.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        usersuser_email.Text=item.user_email.GetFormattedValue();
        usersuser_first_name.Text=item.user_first_name.GetFormattedValue();
        usersuser_last_name.Text=item.user_last_name.GetFormattedValue();
//End Record Form users BeforeShow tail

//Record Form users Show method tail @16-00ECC24D
        if(usersErrors.Count>0)
            usersShowErrors();
    }
//End Record Form users Show method tail

//Record Form users LoadItemFromRequest method @16-8709ACC0
    protected void usersLoadItemFromRequest(usersItem item, bool EnableValidation)
    {
        item.user_email.SetValue(usersuser_email.Text);
        item.user_first_name.SetValue(usersuser_first_name.Text);
        item.user_last_name.SetValue(usersuser_last_name.Text);
        if(EnableValidation)
            item.Validate(usersData);
        usersErrors.Add(item.errors);
    }
//End Record Form users LoadItemFromRequest method

//Record Form users GetRedirectUrl method @16-913804DE
    protected string GetusersRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "profile.aspx";
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form users GetRedirectUrl method

//Record Form users ShowErrors method @16-10DEF0D1
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

//Record Form users Insert Operation @16-EC1310A6
    protected void users_Insert(object sender, System.EventArgs e)
    {
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        usersItem item=new usersItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Insert Operation

//Record Form users BeforeInsert tail @16-53B6D1FB
    usersParameters();
    usersLoadItemFromRequest(item, EnableValidation);
//End Record Form users BeforeInsert tail

//Record Form users AfterInsert tail  @16-A7671D59
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users AfterInsert tail 

//Record Form users Update Operation @16-DEC8ED4E
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

//Button Button_Update OnClick. @21-67E8FE71
        if(((Control)sender).ID == "usersButton_Update")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @21-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form users Before Update tail @16-26DEC238
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

//Record Form users Update Operation tail @16-5E366B58
        }
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users Update Operation tail

//Record Form users Delete Operation @16-F49BCB30
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

//Record Form BeforeDelete tail @16-53B6D1FB
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @16-BC445D80
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form users Cancel Operation @16-61ADD70F
    protected void users_Cancel(object sender,System.EventArgs e)
    {
        usersItem item=new usersItem();
        usersIsSubmitted = true;
        string RedirectUrl = "";
        usersLoadItemFromRequest(item, true);
//End Record Form users Cancel Operation

//Record Form users Cancel Operation tail @16-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form users Cancel Operation tail

//OnInit Event @1-E0BAF64F
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        profileContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, true, false, true, false);
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

