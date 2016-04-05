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

namespace calendar.remind_password{ //Namespace @1-ECF96655

//Forms Definition @1-AFDB28EB
public partial class remind_passwordPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-F82745E0
    protected remindDataProvider remindData;
    protected NameValueCollection remindErrors=new NameValueCollection();
    protected bool remindIsSubmitted = false;
    protected FormSupportedOperations remindOperations;
    protected System.Resources.ResourceManager rm;
    protected string remind_passwordContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-1519F12B
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            remindShow();
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

//Record Form remind Parameters @4-1F40BA11
    protected void remindParameters()
    {
        remindItem item=remindItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            remindErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form remind Parameters

//Record Form remind Show method @4-7CC08295
    protected void remindShow()
    {
        if(remindOperations.None)
        {
            remindHolder.Visible=false;
            return;
        }
        remindItem item=remindItem.CreateFromHttpRequest();
        bool IsInsertMode=!remindOperations.AllowRead;
        remindErrors.Add(item.errors);
//End Record Form remind Show method

//Record Form remind BeforeShow tail @4-4A473BD0
        remindParameters();
        remindData.FillItem(item,ref IsInsertMode);
        remindHolder.DataBind();
        remindremind.Visible=IsInsertMode&&remindOperations.AllowInsert;
        remindlogin.Text=item.login.GetFormattedValue();
//End Record Form remind BeforeShow tail

//Record Form remind Show method tail @4-0EC57D51
        if(remindErrors.Count>0)
            remindShowErrors();
    }
//End Record Form remind Show method tail

//Record Form remind LoadItemFromRequest method @4-9F777C29
    protected void remindLoadItemFromRequest(remindItem item, bool EnableValidation)
    {
        item.login.SetValue(remindlogin.Text);
        if(EnableValidation)
            item.Validate(remindData);
        remindErrors.Add(item.errors);
    }
//End Record Form remind LoadItemFromRequest method

//Record Form remind GetRedirectUrl method @4-7AC16184
    protected string GetremindRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form remind GetRedirectUrl method

//Record Form remind ShowErrors method @4-2B0013D3
    protected void remindShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<remindErrors.Count;i++)
        switch(remindErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=remindErrors[i];
                break;
        }
        remindError.Visible = true;
        remindErrorLabel.Text = DefaultMessage;
    }
//End Record Form remind ShowErrors method

//Record Form remind Insert Operation @4-B4EF138A
    protected void remind_Insert(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        remindIsSubmitted = true;
        bool ErrorFlag = false;
        remindItem item=new remindItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form remind Insert Operation

//Button remind OnClick. @6-2DF7AB2B
        if(((Control)sender).ID == "remindremind")
        {
            RedirectUrl  = GetremindRedirectUrl("", "");
            EnableValidation  = true;
//End Button remind OnClick.

//Button remind OnClick tail. @6-FCB6E20C
        }
//End Button remind OnClick tail.

//Record Form remind BeforeInsert tail @4-D47A6135
    remindParameters();
    remindLoadItemFromRequest(item, EnableValidation);
//End Record Form remind BeforeInsert tail

//Record Form remind AfterInsert tail  @4-D00B14AE
        ErrorFlag=(remindErrors.Count>0);
        if(ErrorFlag)
            remindShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form remind AfterInsert tail 

//Record Form remind Update Operation @4-99A9D5E3
    protected void remind_Update(object sender, System.EventArgs e)
    {
        remindItem item=new remindItem();
        item.IsNew = false;
        remindIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form remind Update Operation

//Record Form remind Before Update tail @4-D47A6135
        remindParameters();
        remindLoadItemFromRequest(item, EnableValidation);
//End Record Form remind Before Update tail

//Record Form remind Update Operation tail @4-D00B14AE
        ErrorFlag=(remindErrors.Count>0);
        if(ErrorFlag)
            remindShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form remind Update Operation tail

//Record Form remind Delete Operation @4-83E414ED
    protected void remind_Delete(object sender,System.EventArgs e)
    {
        remindIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        remindItem item=new remindItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form remind Delete Operation

//Record Form BeforeDelete tail @4-D47A6135
        remindParameters();
        remindLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @4-7763BE96
        if(ErrorFlag)
            remindShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form remind Cancel Operation @4-76B744F3
    protected void remind_Cancel(object sender,System.EventArgs e)
    {
        remindItem item=new remindItem();
        remindIsSubmitted = true;
        string RedirectUrl = "";
        remindLoadItemFromRequest(item, true);
//End Record Form remind Cancel Operation

//Record Form remind Cancel Operation tail @4-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form remind Cancel Operation tail

//OnInit Event @1-D28D45D6
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        remind_passwordContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        remindData = new remindDataProvider();
        remindOperations = new FormSupportedOperations(false, true, true, true, true);
//End OnInit Event

//Page remind_password Event AfterInitialize. Action Custom Code @7-2A29BDB7
    // -------------------------
	if (DBUtility.UserId !=null) Response.Redirect ("index.aspx");
    // -------------------------
//End Page remind_password Event AfterInitialize. Action Custom Code

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

