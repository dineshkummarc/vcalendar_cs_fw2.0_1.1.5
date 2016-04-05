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

namespace calendar.confirm{ //Namespace @1-6A1D0489

//Forms Definition @1-9F699349
public partial class confirmPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-2133FF35
    protected System.Resources.ResourceManager rm;
    protected string confirmContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-096F6A30
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            MessageLabel.Text=item.MessageLabel.GetFormattedValue();
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

//OnInit Event @1-A19441BE
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        confirmContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
//End OnInit Event

//Page confirm Event AfterInitialize. Action Custom Code @2-2A29BDB7
    // -------------------------
	int Flag = 0;
	string SQL = "";
	string UserLogin = "";
	DataAccessObject Conn =	Settings.calendarDataAccessObject;

	string Login   = CommonFunctions.CCGetFromGet("name","");
	string RegCode = CommonFunctions.CCGetFromGet("acc","");
	bool isRegCodeNumeric = !(new Regex(@"[^0-9]+",RegexOptions.IgnoreCase|RegexOptions.Multiline)).Match(RegCode).Success;
	if (Login.Length > 0 && RegCode.Length > 0 && isRegCodeNumeric) {
  		SQL = "SELECT user_id, user_login FROM users " +
			  " WHERE user_level=1 " +
			  " AND user_login=" + Conn.ToSql(Login, FieldType.Text) +
			  " AND user_access_code=" + Conn.ToSql(RegCode, FieldType.Integer);
		DataRowCollection dr = Conn.RunSql(SQL).Tables[0].Rows;
	    if (dr.Count > 0) {
			string UserID = (string)dr[0]["user_id"];
			UserLogin = (string)dr[0]["user_login"];
			SQL = "UPDATE users SET user_level = 10 WHERE user_id=" + Conn.ToSql(UserID, FieldType.Integer);
  			Conn.RunSql(SQL);
			Flag = 1;
		}
	}
	
	if (Flag == 1) {
  		string VerifyMessage = CommonFunctions.GetContent("verification_message");
		VerifyMessage = VerifyMessage.Replace("{user_login}", UserLogin);
		MessageLabel.Text = VerifyMessage;
	} else {
		Response.Redirect("index.aspx");
	}
    // -------------------------
//End Page confirm Event AfterInitialize. Action Custom Code

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

