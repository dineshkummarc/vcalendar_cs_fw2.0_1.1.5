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

namespace calendar.header{ //Namespace @1-D4456FBF

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

//Page_Load Event BeforeIsPostBack @1-C7FCE06D
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            html_header.Text=item.html_header.GetFormattedValue();
            HMenuShow();
    }
//End Page_Load Event BeforeIsPostBack

//Label html_header Event BeforeShow. Action Custom Code @31-2A29BDB7
    // -------------------------
    html_header.Text = CommonFunctions.str_calendar_config("html_header");
    // -------------------------
//End Label html_header Event BeforeShow. Action Custom Code

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

//Record Form HMenu Parameters @65-E37A0CD0
    protected void HMenuParameters()
    {
        HMenuItem item=HMenuItem.CreateFromHttpRequest();
        try{
            HMenuData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
        }catch(Exception e){
            HMenuErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form HMenu Parameters

//Record Form HMenu Show method @65-8D502A38
    protected void HMenuShow()
    {
        if(HMenuOperations.None)
        {
            HMenuHolder.Visible=false;
            return;
        }
        HMenuItem item=HMenuItem.CreateFromHttpRequest();
        bool IsInsertMode=!HMenuOperations.AllowRead;
        item.yearHref = "year.aspx";
        item.monthHref = "index.aspx";
        item.weekHref = "week.aspx";
        item.lbl_dayHref = "day.aspx";
        item.searchHref = "search.aspx";
        item.add_eventHref = "events.aspx";
        item.RegLinkHref = "registration.aspx";
        item.loginHref = "login.aspx";
        item.profileHref = "profile.aspx";
        item.administration_linkHref = "admin/index.aspx";
        item.logoutHref = "index.aspx";
        item.logoutHrefParameters.Add("Logout",System.Web.HttpUtility.UrlEncode((1).ToString()));
        HMenuErrors.Add(item.errors);
//End Record Form HMenu Show method

//Record Form HMenu BeforeShow tail @65-3E6C21EA
        HMenuParameters();
        HMenuData.FillItem(item,ref IsInsertMode);
        HMenuHolder.DataBind();
        HMenuyear.InnerText=Resources.strings.cal_year;
        HMenuyear.HRef = item.yearHref+item.yearHrefParameters.ToString("None","", ViewState);
        HMenumonth.InnerText=Resources.strings.cal_month;
        HMenumonth.HRef = item.monthHref+item.monthHrefParameters.ToString("None","", ViewState);
        HMenuweek.InnerText=Resources.strings.cal_week;
        HMenuweek.HRef = item.weekHref+item.weekHrefParameters.ToString("None","", ViewState);
        HMenulbl_day.InnerText=Resources.strings.cal_day;
        HMenulbl_day.HRef = item.lbl_dayHref+item.lbl_dayHrefParameters.ToString("None","", ViewState);
        HMenusearch.InnerText=Resources.strings.cal_search;
        HMenusearch.HRef = item.searchHref+item.searchHrefParameters.ToString("None","", ViewState);
        HMenuadd_event.InnerText=Resources.strings.cal_add_event;
        HMenuadd_event.HRef = item.add_eventHref+item.add_eventHrefParameters.ToString("None","", ViewState);
        HMenuRegLink.InnerText=Resources.strings.cal_registration;
        HMenuRegLink.HRef = item.RegLinkHref+item.RegLinkHrefParameters.ToString("None","", ViewState);
        HMenulogin.InnerText=Resources.strings.CCS_Login;
        HMenulogin.HRef = item.loginHref+item.loginHrefParameters.ToString("GET","", ViewState);
        HMenuprofile.InnerText=Resources.strings.cal_profile;
        HMenuprofile.HRef = item.profileHref+item.profileHrefParameters.ToString("None","", ViewState);
        HMenuadministration_link.InnerText=Resources.strings.cal_administration;
        HMenuadministration_link.HRef = item.administration_linkHref+item.administration_linkHrefParameters.ToString("GET","", ViewState);
        HMenuadministration_link_spacer.Text=item.administration_link_spacer.GetFormattedValue();
        HMenulogout.InnerText=Resources.strings.CCS_LogoutBtn;
        HMenulogout.HRef = item.logoutHref+item.logoutHrefParameters.ToString("None","", ViewState);
        HMenuuser_login.Text=Server.HtmlEncode(item.user_login.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
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
        item.categoriesItems.SetSelection(item.categories.GetFormattedValue());
        HMenucategories.Items.Add(new ListItem("-- " + Resources.strings.cal_category + " --",""));
        HMenucategories.Items[0].Selected = true;
        if(item.categoriesItems.GetSelectedItem() != null)
            HMenucategories.SelectedIndex = -1;
        item.categoriesItems.CopyTo(HMenucategories.Items);
//End Record Form HMenu BeforeShow tail

//Record HMenu Event BeforeShow. Action Custom Code @85-2A29BDB7
    // -------------------------
	HMenustyle.Value = Utility.GetPageStyle();

	if ( System.Web.HttpContext.Current.Session["category"] != null )
		HMenucategories.Value = (string)System.Web.HttpContext.Current.Session["category"];

	HMenuadd_event_hide.Visible = CommonFunctions.AddAllowed();
  	
  	if (DBUtility.UserId != null) HMenuLoginPanel.Visible = false;
  	else HMenuuser_logout.Visible = false;

	if (CommonFunctions.str_calendar_config("registration_type") == "0") 
		HMenuRegLinkPanel.Visible = false;
 
 	if (CommonFunctions.str_calendar_config("change_style") == "0")
  		HMenustyle.Visible = false;

    if (CommonFunctions.str_calendar_config("change_language") == "0")
    {
        HMenulocale.Visible = false;
    }
    else
    {
        string[] languages = CommonFunctions.calendar_languages.Split(new char[] { ';' });
        HMenulocale.Items.Clear();
        HMenulocale.Items.Add(new ListItem("-- " + ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_language") + " --",""));
        for (int i=0; i< languages.Length-1; i+=2)
            HMenulocale.Items.Add(new ListItem(languages[i+1], languages[i]));
    }

	if ( System.Web.HttpContext.Current.Session["lang"] != null )
		HMenulocale.Value = (string)System.Web.HttpContext.Current.Session["lang"];

  	if (DBUtility.UserId == null || Convert.ToInt32(DBUtility.UserGroup) < 100) {
		HMenuadministration_link.Visible = false;
		HMenuadministration_link_spacer.Visible = false;
	}
    // -------------------------
//End Record HMenu Event BeforeShow. Action Custom Code

//Record Form HMenu Show method tail @65-A59B4DAC
        if(HMenuErrors.Count>0)
            HMenuShowErrors();
    }
//End Record Form HMenu Show method tail

//Record Form HMenu LoadItemFromRequest method @65-A707A715
    protected void HMenuLoadItemFromRequest(HMenuItem item, bool EnableValidation)
    {
        item.style.IsEmpty = Request.Form[HMenustyle.UniqueID]==null;
        item.style.SetValue(HMenustyle.Value);
        item.styleItems.CopyFrom(HMenustyle.Items);
        item.locale.IsEmpty = Request.Form[HMenulocale.UniqueID]==null;
        item.locale.SetValue(HMenulocale.Value);
        item.localeItems.CopyFrom(HMenulocale.Items);
        item.categories.IsEmpty = Request.Form[HMenucategories.UniqueID]==null;
        item.categories.SetValue(HMenucategories.Value);
        item.categoriesItems.CopyFrom(HMenucategories.Items);
        if(EnableValidation)
            item.Validate(HMenuData);
        HMenuErrors.Add(item.errors);
    }
//End Record Form HMenu LoadItemFromRequest method

//Record Form HMenu GetRedirectUrl method @65-43027B73
    protected string GetHMenuRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form HMenu GetRedirectUrl method

//Record Form HMenu ShowErrors method @65-7401630F
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

//Record Form HMenu Insert Operation @65-FC9CA6B9
    protected void HMenu_Insert(object sender, System.EventArgs e)
    {
        HMenuIsSubmitted = true;
        bool ErrorFlag = false;
        HMenuItem item=new HMenuItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form HMenu Insert Operation

//Record Form HMenu BeforeInsert tail @65-FD00A2CF
    HMenuParameters();
    HMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form HMenu BeforeInsert tail

//Record Form HMenu AfterInsert tail  @65-418DB8A4
        ErrorFlag=(HMenuErrors.Count>0);
        if(ErrorFlag)
            HMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form HMenu AfterInsert tail 

//Record Form HMenu Update Operation @65-EE26601D
    protected void HMenu_Update(object sender, System.EventArgs e)
    {
        HMenuItem item=new HMenuItem();
        item.IsNew = false;
        HMenuIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form HMenu Update Operation

//Record Form HMenu Before Update tail @65-FD00A2CF
        HMenuParameters();
        HMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form HMenu Before Update tail

//Record Form HMenu Update Operation tail @65-418DB8A4
        ErrorFlag=(HMenuErrors.Count>0);
        if(ErrorFlag)
            HMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form HMenu Update Operation tail

//Record Form HMenu Delete Operation @65-75936562
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

//Record Form BeforeDelete tail @65-FD00A2CF
        HMenuParameters();
        HMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @65-9C7BA282
        if(ErrorFlag)
            HMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form HMenu Cancel Operation @65-0397F3CC
    protected void HMenu_Cancel(object sender,System.EventArgs e)
    {
        HMenuItem item=new HMenuItem();
        HMenuIsSubmitted = true;
        string RedirectUrl = "";
        HMenuLoadItemFromRequest(item, true);
//End Record Form HMenu Cancel Operation

//Record Form HMenu Cancel Operation tail @65-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form HMenu Cancel Operation tail

//Record Form HMenu Search Operation @65-2D6DDB03
    protected void HMenu_Search(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        HMenuIsSubmitted = true;
        bool ErrorFlag=false;
        HMenuItem item=new HMenuItem();
        HMenuLoadItemFromRequest(item, true);
        ErrorFlag=(HMenuErrors.Count>0);
        string RedirectUrl = "";
//End Record Form HMenu Search Operation

//Button Button_Apply OnClick. @89-31E31719
        if(((Control)sender).ID == "HMenuButton_Apply")
        {
            RedirectUrl = GetHMenuRedirectUrl("", "style;locale;categories");
//End Button Button_Apply OnClick.

//Button Button_Apply Event OnClick. Action Custom Code @90-2A29BDB7
    // -------------------------
  	if (HMenucategories.Value!="" && Convert.ToInt32(HMenucategories.Value) > 0) System.Web.HttpContext.Current.Session["category"] = HMenucategories.Value;
  	else System.Web.HttpContext.Current.Session["category"] = null;
    // -------------------------
//End Button Button_Apply Event OnClick. Action Custom Code

//Button Button_Apply OnClick tail. @89-FCB6E20C
        }
//End Button Button_Apply OnClick tail.

//Record Form HMenu Search Operation tail @65-22A7DC8D
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
            foreach(ListItem li in HMenucategories.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "categories="+Server.UrlEncode(li.Value)+"&";
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

//Page header Event AfterInitialize. Action Custom Code @91-2A29BDB7
    // -------------------------
	if ((CommonFunctions.str_calendar_config("default_style")).Length > 0 && System.Web.HttpContext.Current.Session["style"] == null)  
		System.Web.HttpContext.Current.Session["style"] = CommonFunctions.str_calendar_config("default_style");

	if ((CommonFunctions.str_calendar_config("default_language")).Length > 0 && System.Web.HttpContext.Current.Session["lang"] == null)  
	{
      	//System.Web.HttpContext.Current.Session["lang_semaphore"] = "SET";
        string LangRedirect = Request.ServerVariables["SCRIPT_NAME"];
        LangRedirect = LangRedirect + "?" + CommonFunctions.CCAddParam(Request.ServerVariables["QUERY_STRING"], "locale", CommonFunctions.str_calendar_config("default_language"));
		Response.Redirect(LangRedirect);
	}

	if (
		(CommonFunctions.str_calendar_config("menu_type")).Length == 0 ||
		(CommonFunctions.str_calendar_config("menu_type")).Trim() != "Horizontal"
	   ) HMenuHolder.Visible = false;
    // -------------------------
//End Page header Event AfterInitialize. Action Custom Code

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

