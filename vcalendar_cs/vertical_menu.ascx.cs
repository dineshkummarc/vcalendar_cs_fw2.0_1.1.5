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

namespace calendar.vertical_menu{ //Namespace @1-B4314668

//Forms Definition @1-5CB1DA42
public partial class vertical_menuPage : System.Web.UI.UserControl
{
//End Forms Definition

//Forms Objects @1-6B728223
    protected VerticalMenuDataProvider VerticalMenuData;
    protected NameValueCollection VerticalMenuErrors=new NameValueCollection();
    protected bool VerticalMenuIsSubmitted = false;
    protected FormSupportedOperations VerticalMenuOperations;
    protected System.Resources.ResourceManager rm;
    protected string vertical_menuContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-3A2C5C40
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            VerticalMenuShow();
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

//Record Form VerticalMenu Parameters @127-7787F714
    protected void VerticalMenuParameters()
    {
        VerticalMenuItem item=VerticalMenuItem.CreateFromHttpRequest();
        try{
            VerticalMenuData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
        }catch(Exception e){
            VerticalMenuErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form VerticalMenu Parameters

//Record Form VerticalMenu Show method @127-D17FDD38
    protected void VerticalMenuShow()
    {
        if(VerticalMenuOperations.None)
        {
            VerticalMenuHolder.Visible=false;
            return;
        }
        VerticalMenuItem item=VerticalMenuItem.CreateFromHttpRequest();
        bool IsInsertMode=!VerticalMenuOperations.AllowRead;
        item.yearHref = "year.aspx";
        item.monthHref = "index.aspx";
        item.weekHref = "week.aspx";
        item.dayHref = "day.aspx";
        item.searchHref = "search.aspx";
        item.RegLinkHref = "registration.aspx";
        item.loginHref = "login.aspx";
        item.add_eventHref = "events.aspx";
        item.profileHref = "profile.aspx";
        item.administration_linkHref = "admin/index.aspx";
        item.logoutHref = "index.aspx";
        item.logoutHrefParameters.Add("Logout",System.Web.HttpUtility.UrlEncode((1).ToString()));
        VerticalMenuErrors.Add(item.errors);
//End Record Form VerticalMenu Show method

//Record Form VerticalMenu BeforeShow tail @127-8AAFCB96
        VerticalMenuParameters();
        VerticalMenuData.FillItem(item,ref IsInsertMode);
        VerticalMenuHolder.DataBind();
        VerticalMenuyear.InnerText=Resources.strings.cal_year;
        VerticalMenuyear.HRef = item.yearHref+item.yearHrefParameters.ToString("None","", ViewState);
        VerticalMenumonth.InnerText=Resources.strings.cal_month;
        VerticalMenumonth.HRef = item.monthHref+item.monthHrefParameters.ToString("None","", ViewState);
        VerticalMenuweek.InnerText=Resources.strings.cal_week;
        VerticalMenuweek.HRef = item.weekHref+item.weekHrefParameters.ToString("None","", ViewState);
        VerticalMenuday.InnerText=Resources.strings.cal_day;
        VerticalMenuday.HRef = item.dayHref+item.dayHrefParameters.ToString("None","", ViewState);
        VerticalMenusearch.InnerText=Resources.strings.cal_search;
        VerticalMenusearch.HRef = item.searchHref+item.searchHrefParameters.ToString("None","", ViewState);
        VerticalMenuRegLink.InnerText=Resources.strings.cal_registration;
        VerticalMenuRegLink.HRef = item.RegLinkHref+item.RegLinkHrefParameters.ToString("GET","", ViewState);
        VerticalMenulogin.InnerText=Resources.strings.CCS_Login;
        VerticalMenulogin.HRef = item.loginHref+item.loginHrefParameters.ToString("GET","", ViewState);
        VerticalMenuadd_event.InnerText=Resources.strings.cal_add_event;
        VerticalMenuadd_event.HRef = item.add_eventHref+item.add_eventHrefParameters.ToString("None","", ViewState);
        VerticalMenuprofile.InnerText=Resources.strings.cal_profile;
        VerticalMenuprofile.HRef = item.profileHref+item.profileHrefParameters.ToString("None","", ViewState);
        VerticalMenuadministration_link.InnerText=Resources.strings.cal_administration;
        VerticalMenuadministration_link.HRef = item.administration_linkHref+item.administration_linkHrefParameters.ToString("GET","", ViewState);
        VerticalMenulogout.InnerText=Resources.strings.CCS_LogoutBtn;
        VerticalMenulogout.HRef = item.logoutHref+item.logoutHrefParameters.ToString("None","", ViewState);
        VerticalMenuuser_login.Text=Server.HtmlEncode(item.user_login.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        item.styleItems.SetSelection(item.style.GetFormattedValue());
        VerticalMenustyle.Items.Add(new ListItem("-- " + Resources.strings.cal_style + " --",""));
        VerticalMenustyle.Items[0].Selected = true;
        if(item.styleItems.GetSelectedItem() != null)
            VerticalMenustyle.SelectedIndex = -1;
        item.styleItems.CopyTo(VerticalMenustyle.Items);
        item.localeItems.SetSelection(item.locale.GetFormattedValue());
        VerticalMenulocale.Items.Add(new ListItem("-- " + Resources.strings.cal_language + " --",""));
        VerticalMenulocale.Items[0].Selected = true;
        if(item.localeItems.GetSelectedItem() != null)
            VerticalMenulocale.SelectedIndex = -1;
        item.localeItems.CopyTo(VerticalMenulocale.Items);
        item.categoriesItems.SetSelection(item.categories.GetFormattedValue());
        VerticalMenucategories.Items.Add(new ListItem("-- " + Resources.strings.cal_category + " --",""));
        VerticalMenucategories.Items[0].Selected = true;
        if(item.categoriesItems.GetSelectedItem() != null)
            VerticalMenucategories.SelectedIndex = -1;
        item.categoriesItems.CopyTo(VerticalMenucategories.Items);
//End Record Form VerticalMenu BeforeShow tail

//Record VerticalMenu Event BeforeShow. Action Custom Code @145-2A29BDB7
    // -------------------------
			if (CommonFunctions.str_calendar_config("menu_type") == "Vertical") 
			{
				VerticalMenuHolder.Visible = true;
				VerticalMenustyle.Value = Utility.GetPageStyle();

				if (Session["category"] != null) 
					VerticalMenucategories.Value = (string)Session["category"];

				if (CommonFunctions.str_calendar_config("registration_type") == "0") 
					VerticalMenuRegLinkPanel.Visible = false;

				if (CommonFunctions.AddAllowed() == false) 
					VerticalMenuPanelAdd.Visible = false;

				if (Convert.ToInt32(DBUtility.UserId) > 0) 
					VerticalMenuLoginPanel.Visible = false;
				else 
					VerticalMenuuser_logout.Visible = false;

				if (CommonFunctions.str_calendar_config("change_style") == "0")
				{
					VerticalMenustyle.Visible = false;
					VerticalMenuStyleSeparator.Visible = false;
				}

				if (CommonFunctions.str_calendar_config("change_language") == "0") 
				{
					VerticalMenulocale.Visible = false;
					VerticalMenuLocaleSeparator.Visible = false;
				} 
				else 
				{
			        string[] languages = CommonFunctions.calendar_languages.Split(new char[] { ';' });
			        VerticalMenulocale.Items.Clear();
			        VerticalMenulocale.Items.Add(new ListItem("-- " + ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_language") + " --",""));
        			for (int i=0; i< languages.Length-1; i+=2)
			            VerticalMenulocale.Items.Add(new ListItem(languages[i+1], languages[i]));
				}

				if (System.Web.HttpContext.Current.Session["lang"] != null)
					VerticalMenulocale.Value = (string)System.Web.HttpContext.Current.Session["lang"];

				if (DBUtility.UserLogin == "" || Convert.ToInt32(DBUtility.UserGroup) < 100) 
					VerticalMenuPanelAdmin.Visible = false;
			} 
			else 
			{
				VerticalMenuHolder.Visible = false;
			}
    // -------------------------
//End Record VerticalMenu Event BeforeShow. Action Custom Code

//Record Form VerticalMenu Show method tail @127-2BFBDACD
        if(VerticalMenuErrors.Count>0)
            VerticalMenuShowErrors();
    }
//End Record Form VerticalMenu Show method tail

//Record Form VerticalMenu LoadItemFromRequest method @127-3396D4C6
    protected void VerticalMenuLoadItemFromRequest(VerticalMenuItem item, bool EnableValidation)
    {
        item.style.IsEmpty = Request.Form[VerticalMenustyle.UniqueID]==null;
        item.style.SetValue(VerticalMenustyle.Value);
        item.styleItems.CopyFrom(VerticalMenustyle.Items);
        item.locale.IsEmpty = Request.Form[VerticalMenulocale.UniqueID]==null;
        item.locale.SetValue(VerticalMenulocale.Value);
        item.localeItems.CopyFrom(VerticalMenulocale.Items);
        item.categories.IsEmpty = Request.Form[VerticalMenucategories.UniqueID]==null;
        item.categories.SetValue(VerticalMenucategories.Value);
        item.categoriesItems.CopyFrom(VerticalMenucategories.Items);
        if(EnableValidation)
            item.Validate(VerticalMenuData);
        VerticalMenuErrors.Add(item.errors);
    }
//End Record Form VerticalMenu LoadItemFromRequest method

//Record Form VerticalMenu GetRedirectUrl method @127-49F97D75
    protected string GetVerticalMenuRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = Request.Url.AbsolutePath;
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form VerticalMenu GetRedirectUrl method

//Record Form VerticalMenu ShowErrors method @127-DEF0474C
    protected void VerticalMenuShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<VerticalMenuErrors.Count;i++)
        switch(VerticalMenuErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=VerticalMenuErrors[i];
                break;
        }
    }
//End Record Form VerticalMenu ShowErrors method

//Record Form VerticalMenu Insert Operation @127-B6B86CD2
    protected void VerticalMenu_Insert(object sender, System.EventArgs e)
    {
        VerticalMenuIsSubmitted = true;
        bool ErrorFlag = false;
        VerticalMenuItem item=new VerticalMenuItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form VerticalMenu Insert Operation

//Record Form VerticalMenu BeforeInsert tail @127-15B79975
    VerticalMenuParameters();
    VerticalMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form VerticalMenu BeforeInsert tail

//Record Form VerticalMenu AfterInsert tail  @127-97CD8012
        ErrorFlag=(VerticalMenuErrors.Count>0);
        if(ErrorFlag)
            VerticalMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form VerticalMenu AfterInsert tail 

//Record Form VerticalMenu Update Operation @127-F62294EE
    protected void VerticalMenu_Update(object sender, System.EventArgs e)
    {
        VerticalMenuItem item=new VerticalMenuItem();
        item.IsNew = false;
        VerticalMenuIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form VerticalMenu Update Operation

//Record Form VerticalMenu Before Update tail @127-15B79975
        VerticalMenuParameters();
        VerticalMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form VerticalMenu Before Update tail

//Record Form VerticalMenu Update Operation tail @127-97CD8012
        ErrorFlag=(VerticalMenuErrors.Count>0);
        if(ErrorFlag)
            VerticalMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form VerticalMenu Update Operation tail

//Record Form VerticalMenu Delete Operation @127-550B8265
    protected void VerticalMenu_Delete(object sender,System.EventArgs e)
    {
        VerticalMenuIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        VerticalMenuItem item=new VerticalMenuItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form VerticalMenu Delete Operation

//Record Form BeforeDelete tail @127-15B79975
        VerticalMenuParameters();
        VerticalMenuLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @127-38E942C2
        if(ErrorFlag)
            VerticalMenuShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form VerticalMenu Cancel Operation @127-2281D68A
    protected void VerticalMenu_Cancel(object sender,System.EventArgs e)
    {
        VerticalMenuItem item=new VerticalMenuItem();
        VerticalMenuIsSubmitted = true;
        string RedirectUrl = "";
        VerticalMenuLoadItemFromRequest(item, true);
//End Record Form VerticalMenu Cancel Operation

//Record Form VerticalMenu Cancel Operation tail @127-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form VerticalMenu Cancel Operation tail

//Record Form VerticalMenu Search Operation @127-C2AF18ED
    protected void VerticalMenu_Search(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        VerticalMenuIsSubmitted = true;
        bool ErrorFlag=false;
        VerticalMenuItem item=new VerticalMenuItem();
        VerticalMenuLoadItemFromRequest(item, true);
        ErrorFlag=(VerticalMenuErrors.Count>0);
        string RedirectUrl = "";
//End Record Form VerticalMenu Search Operation

//Button Button_Apply OnClick. @143-1AA2B57B
        if(((Control)sender).ID == "VerticalMenuButton_Apply")
        {
            RedirectUrl = GetVerticalMenuRedirectUrl("", "style;locale;categories");
//End Button Button_Apply OnClick.

//Button Button_Apply Event OnClick. Action Custom Code @169-2A29BDB7
    // -------------------------
		  	if (VerticalMenucategories.Value!="" && Convert.ToInt32(VerticalMenucategories.Value) > 0) System.Web.HttpContext.Current.Session["category"] = VerticalMenucategories.Value;
		  	else System.Web.HttpContext.Current.Session["category"] = null;
    // -------------------------
//End Button Button_Apply Event OnClick. Action Custom Code

//Button Button_Apply OnClick tail. @143-FCB6E20C
        }
//End Button Button_Apply OnClick tail.

//Record Form VerticalMenu Search Operation tail @127-C0C7E6C0
        if(ErrorFlag)
            VerticalMenuShowErrors();
        else{
            string Params="";
            foreach(ListItem li in VerticalMenustyle.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "style="+Server.UrlEncode(li.Value)+"&";
            foreach(ListItem li in VerticalMenulocale.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "locale="+Server.UrlEncode(li.Value)+"&";
            foreach(ListItem li in VerticalMenucategories.Items)
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
//End Record Form VerticalMenu Search Operation tail


//OnInit Event @1-1F7C4A8D
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        vertical_menuContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        VerticalMenuData = new VerticalMenuDataProvider();
        VerticalMenuOperations = new FormSupportedOperations(false, true, true, true, true);
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

