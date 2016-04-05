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

namespace calendar.admin.header{ //Namespace @1-8EA56EC0

//Forms Definition @1-5B635B51
public partial class headerPage : System.Web.UI.UserControl
{
//End Forms Definition

//Forms Objects @1-79CEC0F7
    protected HMenuDataProvider HMenuData;
    protected NameValueCollection HMenuErrors=new NameValueCollection();
    protected bool HMenuIsSubmitted = false;
    protected FormSupportedOperations HMenuOperations;
    protected System.Resources.ResourceManager rm;
    protected string headerContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-8439B41B
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            HMenuShow();
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

//Record Form HMenu Parameters @38-CBBB6221
    protected void HMenuParameters()
    {
        HMenuItem item=HMenuItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            HMenuErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form HMenu Parameters

//Record Form HMenu Show method @38-4D4A7B8A
    protected void HMenuShow()
    {
        if(HMenuOperations.None)
        {
            HMenuHolder.Visible=false;
            return;
        }
        HMenuItem item=HMenuItem.CreateFromHttpRequest();
        bool IsInsertMode=!HMenuOperations.AllowRead;
        item.homeHref = "../index.aspx";
        item.usersHref = "users.aspx";
        item.categoriesHref = "categories.aspx";
        item.configHref = "config.aspx";
        item.messagesHref = "content.aspx";
        item.permissionsHref = "permissions.aspx";
        item.email_templatesHref = "email_templates.aspx";
        item.custom_fieldsHref = "custom_fields.aspx";
        item.logoutHref = "../index.aspx";
        item.logoutHrefParameters.Add("Logout",System.Web.HttpUtility.UrlEncode((1).ToString()));
        HMenuErrors.Add(item.errors);
//End Record Form HMenu Show method

//Record Form HMenu BeforeShow tail @38-37181466
        HMenuParameters();
        HMenuData.FillItem(item,ref IsInsertMode);
        HMenuHolder.DataBind();
        HMenuhome.InnerText=Resources.strings.home_page;
        HMenuhome.HRef = item.homeHref+item.homeHrefParameters.ToString("None","", ViewState);
        HMenuusers.InnerText=Resources.strings.cal_users;
        HMenuusers.HRef = item.usersHref+item.usersHrefParameters.ToString("None","", ViewState);
        HMenucategories.InnerText=Resources.strings.cal_categories;
        HMenucategories.HRef = item.categoriesHref+item.categoriesHrefParameters.ToString("None","", ViewState);
        HMenuconfig.InnerText=Resources.strings.config;
        HMenuconfig.HRef = item.configHref+item.configHrefParameters.ToString("None","", ViewState);
        HMenumessages.InnerText=Resources.strings.cal_messages;
        HMenumessages.HRef = item.messagesHref+item.messagesHrefParameters.ToString("None","", ViewState);
        HMenupermissions.InnerText=Resources.strings.cal_permissions;
        HMenupermissions.HRef = item.permissionsHref+item.permissionsHrefParameters.ToString("None","", ViewState);
        HMenuemail_templates.InnerText=Resources.strings.email_templates;
        HMenuemail_templates.HRef = item.email_templatesHref+item.email_templatesHrefParameters.ToString("None","", ViewState);
        HMenucustom_fields.InnerText=Resources.strings.custom_fields;
        HMenucustom_fields.HRef = item.custom_fieldsHref+item.custom_fieldsHrefParameters.ToString("None","", ViewState);
        item.styleItems.SetSelection(item.style.GetFormattedValue());
        HMenustyle.Items.Add(new ListItem("-- " + Resources.strings.cal_style + " --",""));
        HMenustyle.Items[0].Selected = true;
        if(item.styleItems.GetSelectedItem() != null)
            HMenustyle.SelectedIndex = -1;
        item.styleItems.CopyTo(HMenustyle.Items);
        item.localeItems.SetSelection(item.locale.GetFormattedValue());
        HMenulocale.Items.Add(new ListItem("-- " + Resources.strings.cal_language + " --",""));
        HMenulocale.Items[0].Selected = true;
        if(item.localeItems.GetSelectedItem() != null)
            HMenulocale.SelectedIndex = -1;
        item.localeItems.CopyTo(HMenulocale.Items);
        HMenuuser_login.Text=Server.HtmlEncode(item.user_login.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        HMenulogout.InnerText=Resources.strings.CCS_LogoutBtn;
        HMenulogout.HRef = item.logoutHref+item.logoutHrefParameters.ToString("None","", ViewState);
//End Record Form HMenu BeforeShow tail

//Record HMenu Event BeforeShow. Action Custom Code @78-2A29BDB7
    // -------------------------
		string[] languages = CommonFunctions.calendar_languages.Split(new char[] { ';' });
        HMenulocale.Items.Clear();
        HMenulocale.Items.Add(new ListItem("-- " + ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_language") + " --",""));
        for (int i=0; i< languages.Length-1; i+=2)
            HMenulocale.Items.Add(new ListItem(languages[i+1], languages[i]));
		if ( System.Web.HttpContext.Current.Session["lang"] != null )
			HMenulocale.Value = (string)System.Web.HttpContext.Current.Session["lang"];

		HMenustyle.Value = Utility.GetPageStyle();
    // -------------------------
//End Record HMenu Event BeforeShow. Action Custom Code

//Record Form HMenu Show method tail @38-A59B4DAC
        if(HMenuErrors.Count>0)
            HMenuShowErrors();
    }
//End Record Form HMenu Show method tail

//Record Form HMenu LoadItemFromRequest method @38-F4231961
    protected void HMenuLoadItemFromRequest(HMenuItem item, bool EnableValidation)
    {
        item.style.IsEmpty = Request.Form[HMenustyle.UniqueID]==null;
        item.style.SetValue(HMenustyle.Value);
        item.styleItems.CopyFrom(HMenustyle.Items);
        item.locale.IsEmpty = Request.Form[HMenulocale.UniqueID]==null;
        item.locale.SetValue(HMenulocale.Value);
        item.localeItems.CopyFrom(HMenulocale.Items);
        if(EnableValidation)
            item.Validate(HMenuData);
        HMenuErrors.Add(item.errors);
    }
//End Record Form HMenu LoadItemFromRequest method

//Record Form HMenu GetRedirectUrl method @38-43027B73
    protected string GetHMenuRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form HMenu GetRedirectUrl method

//Record Form HMenu ShowErrors method @38-7401630F
    protected void HMenuShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<HMenuErrors.Count;i++)
        switch(HMenuErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=HMenuErrors[i];
                break;
        }
    }
//End Record Form HMenu ShowErrors method

//Record Form HMenu Insert Operation @38-FC9CA6B9
    protected void HMenu_Insert(object sender, System.EventArgs e)
    {
        HMenuIsSubmitted = true;
        bool ErrorFlag = false;
        HMenuItem item=new HMenuItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form HMenu Insert Operation

//Record Form HMenu BeforeInsert tail @38-FD00A2CF
    HMenuParameters();
    HMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form HMenu BeforeInsert tail

//Record Form HMenu AfterInsert tail  @38-418DB8A4
        ErrorFlag=(HMenuErrors.Count>0);
        if(ErrorFlag)
            HMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form HMenu AfterInsert tail 

//Record Form HMenu Update Operation @38-EE26601D
    protected void HMenu_Update(object sender, System.EventArgs e)
    {
        HMenuItem item=new HMenuItem();
        item.IsNew = false;
        HMenuIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form HMenu Update Operation

//Record Form HMenu Before Update tail @38-FD00A2CF
        HMenuParameters();
        HMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form HMenu Before Update tail

//Record Form HMenu Update Operation tail @38-418DB8A4
        ErrorFlag=(HMenuErrors.Count>0);
        if(ErrorFlag)
            HMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form HMenu Update Operation tail

//Record Form HMenu Delete Operation @38-75936562
    protected void HMenu_Delete(object sender,System.EventArgs e)
    {
        HMenuIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        HMenuItem item=new HMenuItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form HMenu Delete Operation

//Record Form BeforeDelete tail @38-FD00A2CF
        HMenuParameters();
        HMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @38-9C7BA282
        if(ErrorFlag)
            HMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form HMenu Cancel Operation @38-0397F3CC
    protected void HMenu_Cancel(object sender,System.EventArgs e)
    {
        HMenuItem item=new HMenuItem();
        HMenuIsSubmitted = true;
        string RedirectUrl = "";
        HMenuLoadItemFromRequest(item, true);
//End Record Form HMenu Cancel Operation

//Record Form HMenu Cancel Operation tail @38-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form HMenu Cancel Operation tail

//Record Form HMenu Search Operation @38-2D6DDB03
    protected void HMenu_Search(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        HMenuIsSubmitted = true;
        bool ErrorFlag=false;
        HMenuItem item=new HMenuItem();
        HMenuLoadItemFromRequest(item, true);
        ErrorFlag=(HMenuErrors.Count>0);
        string RedirectUrl = "";
//End Record Form HMenu Search Operation

//Button Button_Apply OnClick. @58-536E3E00
        if(((Control)sender).ID == "HMenuButton_Apply")
        {
            RedirectUrl = GetHMenuRedirectUrl("", "style;locale");
//End Button Button_Apply OnClick.

//Button Button_Apply OnClick tail. @58-FCB6E20C
        }
//End Button Button_Apply OnClick tail.

//Record Form HMenu Search Operation tail @38-350DD1C8
        if(ErrorFlag)
            HMenuShowErrors();
        else{
            string Params="";
            foreach(ListItem li in HMenustyle.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "style="+Server.UrlEncode(li.Value)+"&";
            foreach(ListItem li in HMenulocale.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "locale="+Server.UrlEncode(li.Value)+"&";
            if(!RedirectUrl.EndsWith("?"))
                RedirectUrl += "&" + Params;
            else
                RedirectUrl += Params;
            RedirectUrl = RedirectUrl.TrimEnd(new Char[]{'&'});
            Response.Redirect(RedirectUrl);
        }
    }
//End Record Form HMenu Search Operation tail

//OnInit Event @1-6E9A00B9
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        headerContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        HMenuData = new HMenuDataProvider();
        HMenuOperations = new FormSupportedOperations(false, true, true, true, true);
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

