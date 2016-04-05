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

namespace calendar.profile_menu{ //Namespace @1-58C1A5DF

//Forms Definition @1-507FD7B9
public partial class profile_menuPage : System.Web.UI.UserControl
{
//End Forms Definition

//Forms Objects @1-2C248E01
    protected System.Resources.ResourceManager rm;
    protected string profile_menuContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-082DC1D9
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.profile_mainHref = "profile.aspx";
            item.profile_chpassHref = "change_password.aspx";
            item.my_eventsHref = "profile_events.aspx";
            PageData.FillItem(item);
            profile_main.InnerText=Resources.strings.cal_edit_profile;
            profile_main.HRef = item.profile_mainHref+item.profile_mainHrefParameters.ToString("None","", ViewState);
            profile_chpass.InnerText=Resources.strings.cal_profile_chpass;
            profile_chpass.HRef = item.profile_chpassHref+item.profile_chpassHrefParameters.ToString("None","", ViewState);
            my_events.InnerText=Resources.strings.cal_my_events;
            my_events.HRef = item.my_eventsHref+item.my_eventsHrefParameters.ToString("None","", ViewState);
    }
//End Page_Load Event BeforeIsPostBack

//Link my_events Event BeforeShow. Action Custom Code @11-2A29BDB7
    // -------------------------
	if (!CommonFunctions.AddAllowed()) my_events.Visible = false;
    // -------------------------
//End Link my_events Event BeforeShow. Action Custom Code

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

//OnInit Event @1-E7587BC8
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        profile_menuContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        if(!DBUtility.AuthorizeUser(new string[]{
          "10"}))
            this.Visible = false;
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

