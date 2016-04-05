//Setting Class @0-FC6BFAAD
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Collections.Specialized;
using calendar.Data;
namespace calendar.Configuration
{
public sealed class Settings
{
    private static string _serverUrl = ConfigurationManager.AppSettings["ServerUrl"];
    private static string _securedUrl = ConfigurationManager.AppSettings["SecuredUrl"];
    private static string _cultureId = ConfigurationManager.AppSettings["CultureId"];
    private static string _siteLanguage = ConfigurationManager.AppSettings["SiteLanguage"];
    private static string _AccesDeniedUrl = ServerURL + ConfigurationManager.AppSettings["AccessDeniedUrl"];
    private static string _DateFormat = ConfigurationManager.AppSettings["DefaultDateFormat"];
    private static string _BoolFormat = ConfigurationManager.AppSettings["DefaultBooleanFormat"];
    private Settings()
    {}

    public static string CultureId
    {
        get
        {
            if(_cultureId == null || _cultureId == "")
                return CultureInfo.CurrentCulture.Name;
            else
                return _cultureId;
        }
        set
        {
            _cultureId=value;
        }
    }

    public static string SiteLanguage
    {
        get
        {
            return _siteLanguage;
        }
        set
        {
            _siteLanguage = value;
        }
    }

    public static string DateFormat
    {
        get
        {
            return _DateFormat;
        }
        set
        {
            _DateFormat=value;
        }
    }

    public static string BoolFormat
    {
        get
        {
            return _BoolFormat;
        }
        set
        {
            _BoolFormat=value;
        }
    }

    public static string AccessDeniedUrl
    {
        get
        {
            return _AccesDeniedUrl;
        }
        set
        {
            _AccesDeniedUrl=value;
        }
    }

    public static string ServerURL
    {
        get
        {
            return _serverUrl;
        }
        set
        {
            _serverUrl=value;
        }
    }

    public static string SecuredURL
    {
        get
        {
            return _securedUrl;
        }
        set
        {
            _securedUrl=value;
        }
    }
    public static DataAccessObject GetConnection(string name)
    {
        switch (name)
        {
            case "calendar":
                return calendarDataAccessObject;
        }
        return null;
    }

    public static ConnectionString calendarConnection
    {
        get
        {
            ConnectionString cs=new ConnectionString();
            cs.Connection=ConfigurationManager.AppSettings["calendarString"];
            cs.Server=ConfigurationManager.AppSettings["calendarServer"];
            cs.Optimized=bool.Parse(ConfigurationManager.AppSettings["calendarOptimized"]);
            cs.ConnectionCommands.Add((NameValueCollection) ConfigurationSettings.GetConfig("connectionCommands/_calendarCommands"));
            cs.DateFormat=ConfigurationManager.AppSettings["calendarDateFormat"];
            cs.BoolFormat=ConfigurationManager.AppSettings["calendarBoolFormat"];
            cs.DateRightDelim=ConfigurationManager.AppSettings["calendarDateRightDelimeter"];
            cs.DateLeftDelim=ConfigurationManager.AppSettings["calendarDateLeftDelimeter"];
            switch(ConfigurationManager.AppSettings["calendarType"].ToUpper(CultureInfo.CurrentCulture))
            {
            case "OLEDB":
                cs.Type=ConnectionStringType.OleDb;
                break;
            case "ODBC":
                cs.Type=ConnectionStringType.Odbc;
                break;
            case "ORACLE":
                cs.Type=ConnectionStringType.Oracle;
                break;
#if ODP_INSTALLED
	
            case "ODP":
                cs.Type=ConnectionStringType.ODP;
                break;
#endif
#if DB2_INSTALLED
	
            case "DB2":
                cs.Type=ConnectionStringType.DB2;
                break;
#endif
	
            case "SQL":
                cs.Type=ConnectionStringType.Sql;
                break;
            }
            return cs;
        }
    }

    public static DataAccessObject calendarDataAccessObject
    {
        get
        {
            ConnectionString Connection=calendarConnection;
            switch(Connection.Type)
            {
            case ConnectionStringType.OleDb:
                return new OleDbDao(Connection);
            case ConnectionStringType.Odbc:
                return new OdbcDao(Connection);
            case ConnectionStringType.Oracle:
                return new OracleDao(Connection);
#if ODP_INSTALLED
	
            case ConnectionStringType.ODP:
                return new ODPDao(Connection);
#endif
#if DB2_INSTALLED
	
            case ConnectionStringType.DB2:
                return new DB2Dao(Connection);
#endif
	
            case ConnectionStringType.Sql:
                return new SqlDao(Connection);
            }
            return null;
        }
    }

}
}
//End Setting Class

