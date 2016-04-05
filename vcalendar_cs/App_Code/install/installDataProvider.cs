//Using Statements @1-B4A43F2B
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using calendar;
using calendar.Data;
using calendar.Controls;
using calendar.Security;
using calendar.Configuration;

//End Using Statements

namespace calendar.install.install{ //Namespace @1-8D024801

//Page Data Class @1-D7318E7A
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.CommonCheck.SetValue(DBUtility.GetInitialValue("CommonCheck"));
        item.FolderCheck.SetValue(DBUtility.GetInitialValue("FolderCheck"));
        item.InstallLink.SetValue(DBUtility.GetInitialValue("InstallLink"));
        item.StartLink.SetValue(DBUtility.GetInitialValue("StartLink"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "CommonCheck":
                    return this.CommonCheck;
                case "FolderCheck":
                    return this.FolderCheck;
                case "InstallLink":
                    return this.InstallLink;
                case "StartLink":
                    return this.StartLink;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "CommonCheck":
                    this.CommonCheck = (TextField)value;
                    break;
                case "FolderCheck":
                    this.FolderCheck = (TextField)value;
                    break;
                case "InstallLink":
                    this.InstallLink = (TextField)value;
                    break;
                case "StartLink":
                    this.StartLink = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField CommonCheck;
    public TextField FolderCheck;
    public TextField InstallLink;
    public object InstallLinkHref;
    public LinkParameterCollection InstallLinkHrefParameters;
    public TextField StartLink;
    public object StartLinkHref;
    public LinkParameterCollection StartLinkHrefParameters;
    public PageItem()
    {
        CommonCheck=new TextField("", null);
        FolderCheck=new TextField("", null);
        InstallLink = new TextField("",null);
        InstallLinkHrefParameters = new LinkParameterCollection();
        StartLink = new TextField("",null);
        StartLinkHrefParameters = new LinkParameterCollection();
    }
}
//End Page Data Class

//Page Data Provider Class @1-50FE4D41
public class PageDataProvider
{
//End Page Data Provider Class

//Page Data Provider Class Constructor @1-9A44B219
    public PageDataProvider()
    {
    }
//End Page Data Provider Class Constructor

//Page Data Provider Class GetResultSet Method @1-052161C6
    public void FillItem(PageItem item)
    {
//End Page Data Provider Class GetResultSet Method

//Page Data Provider Class GetResultSet Method tail @1-FCB6E20C
    }
//End Page Data Provider Class GetResultSet Method tail

//Page Data Provider class Tail @1-FCB6E20C
}
//End Page Data Provider class Tail

//Record sql_environment Item Class @2-2ACA2803
public class sql_environmentItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public IntegerField change_webconfig;
    public IntegerField change_webconfigCheckedValue;
    public IntegerField change_webconfigUncheckedValue;
    public TextField is_disabled;
    public TextField SiteURL;
    public IntegerField DBType;
    public ItemCollection DBTypeItems;
    public TextField mdb_file;
    public TextField host;
    public TextField sql_db_name;
    public TextField sql_username;
    public TextField sql_password;
    public TextField recreate_tables;
    public ItemCollection recreate_tablesItems;
    public NameValueCollection errors=new NameValueCollection();
    public sql_environmentItem()
    {
        change_webconfig = new IntegerField("", 1);
        change_webconfigCheckedValue = new IntegerField("", 1);
        change_webconfigUncheckedValue = new IntegerField("", 0);
        is_disabled=new TextField("", null);
        SiteURL=new TextField("", "http://localhost/vcalendar_cs/");
        DBType = new IntegerField("", 1);
        DBTypeItems = new ItemCollection();
        mdb_file=new TextField("", null);
        host=new TextField("", "localhost");
        sql_db_name=new TextField("", "vcalendar");
        sql_username=new TextField("", null);
        sql_password=new TextField("", null);
        recreate_tables = new TextField("", null);
        recreate_tablesItems = new ItemCollection();
    }

    public static sql_environmentItem CreateFromHttpRequest()
    {
        sql_environmentItem item = new sql_environmentItem();
        if(DBUtility.GetInitialValue("change_webconfig") != null){
        if(System.Web.HttpContext.Current.Request["change_webconfig"]!=null)
            item.change_webconfig.Value = item.change_webconfigCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("is_disabled") != null){
        item.is_disabled.SetValue(DBUtility.GetInitialValue("is_disabled"));
        }
        if(DBUtility.GetInitialValue("SiteURL") != null){
        item.SiteURL.SetValue(DBUtility.GetInitialValue("SiteURL"));
        }
        if(DBUtility.GetInitialValue("DBType") != null){
        item.DBType.SetValue(DBUtility.GetInitialValue("DBType"));
        }
        if(DBUtility.GetInitialValue("mdb_file") != null){
        item.mdb_file.SetValue(DBUtility.GetInitialValue("mdb_file"));
        }
        if(DBUtility.GetInitialValue("host") != null){
        item.host.SetValue(DBUtility.GetInitialValue("host"));
        }
        if(DBUtility.GetInitialValue("sql_db_name") != null){
        item.sql_db_name.SetValue(DBUtility.GetInitialValue("sql_db_name"));
        }
        if(DBUtility.GetInitialValue("sql_username") != null){
        item.sql_username.SetValue(DBUtility.GetInitialValue("sql_username"));
        }
        if(DBUtility.GetInitialValue("sql_password") != null){
        item.sql_password.SetValue(DBUtility.GetInitialValue("sql_password"));
        }
        if(DBUtility.GetInitialValue("recreate_tables") != null){
        item.recreate_tables.SetValue(DBUtility.GetInitialValue("recreate_tables"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "change_webconfig":
                    return this.change_webconfig;
                case "is_disabled":
                    return this.is_disabled;
                case "SiteURL":
                    return this.SiteURL;
                case "DBType":
                    return this.DBType;
                case "mdb_file":
                    return this.mdb_file;
                case "host":
                    return this.host;
                case "sql_db_name":
                    return this.sql_db_name;
                case "sql_username":
                    return this.sql_username;
                case "sql_password":
                    return this.sql_password;
                case "recreate_tables":
                    return this.recreate_tables;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "change_webconfig":
                    this.change_webconfig = (IntegerField)value;
                    break;
                case "is_disabled":
                    this.is_disabled = (TextField)value;
                    break;
                case "SiteURL":
                    this.SiteURL = (TextField)value;
                    break;
                case "DBType":
                    this.DBType = (IntegerField)value;
                    break;
                case "mdb_file":
                    this.mdb_file = (TextField)value;
                    break;
                case "host":
                    this.host = (TextField)value;
                    break;
                case "sql_db_name":
                    this.sql_db_name = (TextField)value;
                    break;
                case "sql_username":
                    this.sql_username = (TextField)value;
                    break;
                case "sql_password":
                    this.sql_password = (TextField)value;
                    break;
                case "recreate_tables":
                    this.recreate_tables = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public bool IsNew{
        get{
            return _isNew;
        }
        set{
            _isNew = value;
        }
    }

    public bool IsDeleted{
        get{
            return _isDeleted;
        }
        set{
            _isDeleted = value;
        }
    }

    public void Validate(sql_environmentDataProvider provider)
    {
//End Record sql_environment Item Class

//SiteURL validate @41-490DB5A6
        if(SiteURL.Value!=null){
            Regex mask = new Regex(@"http://[a-zA-Z_0-9- :/]*",RegexOptions.IgnoreCase|RegexOptions.Multiline);
            if(!mask.Match(SiteURL.Value.ToString()).Success)
                errors.Add("SiteURL",String.Format(Resources.strings.CCS_MaskValidation,Resources.strings.install_site_url));
        }
//End SiteURL validate

//Record sql_environment Event OnValidate. Action Custom Code @10-2A29BDB7
    // -------------------------

		string mdbPath = mdb_file.GetFormattedValue().Trim(' ');
		string db_type = DBType.GetFormattedValue();
		string db_name = sql_db_name.GetFormattedValue().Trim(' ');
		string db_host = host.GetFormattedValue().Trim(' ');
		string db_user = sql_username.GetFormattedValue().Trim(' ');
		string db_pass = sql_password.GetFormattedValue().Trim(' ');
		string db_conf = change_webconfig.GetFormattedValue();
		string db_recr = recreate_tables.GetFormattedValue();
		string target = SiteURL.GetFormattedValue().Trim(' ');
		string connString = "";

		if (db_conf == "1" && target.Length == 0)
			errors.Add("",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("install_site_url")));

		if (db_type == "2" && db_conf == "1") {
			if (mdbPath.Length == 0)
                errors.Add("",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"), "Database name"));
	
			if (errors.Count == 0) {
				connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath + ";Persist Security Info=False;User ID=Admin;Password=";
				try
				{
					System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connString);
					conn.Open();
					conn.Close();
				}
				catch(Exception e)
				{
                	errors.Add("",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("sql_connect_error")));
				}
			}
		} else {
			if (db_conf == "1" && db_type == "1" || db_conf == "0" && db_recr == "1") {
				if (db_name.Length == 0)
					errors.Add("",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("sql_database_name")));
				if (db_host.Length == 0)
					errors.Add("",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("sql_host")));
				if (db_user.Length == 0)
					errors.Add("",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"), ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("sql_username")));
				if (errors.Count == 0) {
					connString = "Persist Security Info=False;Initial Catalog=" + db_name + ";Data Source=" + db_host + ";User ID=" + db_user + ";Password=" + db_pass;
					try
					{
						System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
						conn.Open();
						if (db_recr != "0") {
							System.IO.StreamReader sr;
							if (db_recr == "1")
								sr = System.IO.File.OpenText(System.Web.HttpContext.Current.Server.MapPath(".") + "\\VCalendar_MSSQL.sql");
							else
								sr = System.IO.File.OpenText(System.Web.HttpContext.Current.Server.MapPath(".") + "\\VCalendar_MSSQL_update.sql");
							System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(sr.ReadToEnd().Replace("\nGO",";").Replace("\ngo",";"), conn);
							Command.Connection.ChangeDatabase(db_name);
							Command.ExecuteNonQuery();
							if (sr != null) sr.Close();
						}
						conn.Close();
					}
					catch (Exception ex)
					{
						errors.Add("","Database Error: " + ex.Message);
					}
				}
			}
		}

		if (errors.Count == 0) {
			 if (db_conf == "1") {
				string location = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("..\\"), "web.config");
				System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
				doc.Load(location);
				doc.SelectSingleNode("/configuration/appSettings/add[@key='ServerUrl']/@value").InnerText = target;
				doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarString']/@value").InnerText = connString;
				switch (db_type) 
				{
					case "2":
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarType']/@value").InnerText = "OleDb";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarServer']/@value").InnerText = "MSAccess";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarBoolFormat']/@value").InnerText = "true;false";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarDateRightDelimeter']/@value").InnerText = "#";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarDateLeftDelimeter']/@value").InnerText = "#";
						break;
					case "1":
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarType']/@value").InnerText = "Sql";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarServer']/@value").InnerText = "MSSQLServer";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarBoolFormat']/@value").InnerText = "1;0";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarDateRightDelimeter']/@value").InnerText = "'";
						doc.SelectSingleNode("/configuration/appSettings/add[@key='calendarDateLeftDelimeter']/@value").InnerText = "'";
						break;
				}
				doc.Save(location);
				System.Web.HttpContext.Current.Response.Redirect("install.aspx?step=3");
			} else
				System.Web.HttpContext.Current.Response.Redirect("install.aspx?step=3");
		}

		try
		{
			if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("..\\") + "temp\\test.tmp"))
				System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("..\\") + "temp\\test.tmp");
			if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("..\\") + "images\\categories\\test.tmp"))
				System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("..\\") + "images\\categories\\test.tmp");
		}
		catch(Exception ex)
		{
		}

    // -------------------------
//End Record sql_environment Event OnValidate. Action Custom Code

//Record sql_environment Item Class tail @2-F5FC18C5
    }
}
//End Record sql_environment Item Class tail

//Record sql_environment Data Provider Class @2-44973B3C
public class sql_environmentDataProvider:RecordDataProviderBase
{
//End Record sql_environment Data Provider Class

//Record sql_environment Data Provider Class Variables @2-B8789F8D
    protected sql_environmentItem item;
//End Record sql_environment Data Provider Class Variables

//Record sql_environment Data Provider Class Constructor @2-9BF90A14
    public sql_environmentDataProvider()
    {
    }
//End Record sql_environment Data Provider Class Constructor

//Record sql_environment Data Provider Class LoadParams Method @2-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record sql_environment Data Provider Class LoadParams Method

//Record sql_environment Data Provider Class GetResultSet Method @2-AD2CC4A1
    public void FillItem(sql_environmentItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record sql_environment Data Provider Class GetResultSet Method

//Record sql_environment BeforeBuildSelect @2-921CE95D
        if(!IsInsertMode){
//End Record sql_environment BeforeBuildSelect

//Record sql_environment AfterExecuteSelect @2-54D78817
        }
            IsInsertMode=true;
//End Record sql_environment AfterExecuteSelect

//ListBox DBType AfterExecuteSelect @45-DDBA0CC9
        
item.DBTypeItems.Add("1","MS SQL");
item.DBTypeItems.Add("2","MS Access");
//End ListBox DBType AfterExecuteSelect

//ListBox recreate_tables AfterExecuteSelect @52-5E154BE1
        
item.recreate_tablesItems.Add("0",Resources.strings.db_not_change + "<br>");
item.recreate_tablesItems.Add("1",Resources.strings.inst_recr_tables + "<br>");
item.recreate_tablesItems.Add("2",Resources.strings.db_update_exist);
//End ListBox recreate_tables AfterExecuteSelect

//Record sql_environment AfterExecuteSelect tail @2-FCB6E20C
    }
//End Record sql_environment AfterExecuteSelect tail

//Record sql_environment Data Provider Class @2-FCB6E20C
}

//End Record sql_environment Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

