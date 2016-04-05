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

namespace calendar.admin.header{ //Namespace @1-8EA56EC0

//Page Data Class @1-3FCDCDA8
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public PageItem()
    {
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

//Record HMenu Item Class @38-9680E6A3
public class HMenuItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField home;
    public object homeHref;
    public LinkParameterCollection homeHrefParameters;
    public TextField users;
    public object usersHref;
    public LinkParameterCollection usersHrefParameters;
    public TextField categories;
    public object categoriesHref;
    public LinkParameterCollection categoriesHrefParameters;
    public TextField config;
    public object configHref;
    public LinkParameterCollection configHrefParameters;
    public TextField messages;
    public object messagesHref;
    public LinkParameterCollection messagesHrefParameters;
    public TextField permissions;
    public object permissionsHref;
    public LinkParameterCollection permissionsHrefParameters;
    public TextField email_templates;
    public object email_templatesHref;
    public LinkParameterCollection email_templatesHrefParameters;
    public TextField custom_fields;
    public object custom_fieldsHref;
    public LinkParameterCollection custom_fieldsHrefParameters;
    public TextField style;
    public ItemCollection styleItems;
    public TextField locale;
    public ItemCollection localeItems;
    public TextField user_login;
    public TextField logout;
    public object logoutHref;
    public LinkParameterCollection logoutHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public HMenuItem()
    {
        home = new TextField("",null);
        homeHrefParameters = new LinkParameterCollection();
        users = new TextField("",null);
        usersHrefParameters = new LinkParameterCollection();
        categories = new TextField("",null);
        categoriesHrefParameters = new LinkParameterCollection();
        config = new TextField("",null);
        configHrefParameters = new LinkParameterCollection();
        messages = new TextField("",null);
        messagesHrefParameters = new LinkParameterCollection();
        permissions = new TextField("",null);
        permissionsHrefParameters = new LinkParameterCollection();
        email_templates = new TextField("",null);
        email_templatesHrefParameters = new LinkParameterCollection();
        custom_fields = new TextField("",null);
        custom_fieldsHrefParameters = new LinkParameterCollection();
        style = new TextField("", null);
        styleItems = new ItemCollection();
        locale = new TextField("", null);
        localeItems = new ItemCollection();
        user_login=new TextField("", DBUtility.UserLogin);
        logout = new TextField("",null);
        logoutHrefParameters = new LinkParameterCollection();
    }

    public static HMenuItem CreateFromHttpRequest()
    {
        HMenuItem item = new HMenuItem();
        if(DBUtility.GetInitialValue("home") != null){
        item.home.SetValue(DBUtility.GetInitialValue("home"));
        }
        if(DBUtility.GetInitialValue("users") != null){
        item.users.SetValue(DBUtility.GetInitialValue("users"));
        }
        if(DBUtility.GetInitialValue("categories") != null){
        item.categories.SetValue(DBUtility.GetInitialValue("categories"));
        }
        if(DBUtility.GetInitialValue("config") != null){
        item.config.SetValue(DBUtility.GetInitialValue("config"));
        }
        if(DBUtility.GetInitialValue("messages") != null){
        item.messages.SetValue(DBUtility.GetInitialValue("messages"));
        }
        if(DBUtility.GetInitialValue("permissions") != null){
        item.permissions.SetValue(DBUtility.GetInitialValue("permissions"));
        }
        if(DBUtility.GetInitialValue("email_templates") != null){
        item.email_templates.SetValue(DBUtility.GetInitialValue("email_templates"));
        }
        if(DBUtility.GetInitialValue("custom_fields") != null){
        item.custom_fields.SetValue(DBUtility.GetInitialValue("custom_fields"));
        }
        if(DBUtility.GetInitialValue("style") != null){
        item.style.SetValue(DBUtility.GetInitialValue("style"));
        }
        if(DBUtility.GetInitialValue("locale") != null){
        item.locale.SetValue(DBUtility.GetInitialValue("locale"));
        }
        if(DBUtility.GetInitialValue("user_login") != null){
        item.user_login.SetValue(DBUtility.GetInitialValue("user_login"));
        }
        if(DBUtility.GetInitialValue("logout") != null){
        item.logout.SetValue(DBUtility.GetInitialValue("logout"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "home":
                    return this.home;
                case "users":
                    return this.users;
                case "categories":
                    return this.categories;
                case "config":
                    return this.config;
                case "messages":
                    return this.messages;
                case "permissions":
                    return this.permissions;
                case "email_templates":
                    return this.email_templates;
                case "custom_fields":
                    return this.custom_fields;
                case "style":
                    return this.style;
                case "locale":
                    return this.locale;
                case "user_login":
                    return this.user_login;
                case "logout":
                    return this.logout;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "home":
                    this.home = (TextField)value;
                    break;
                case "users":
                    this.users = (TextField)value;
                    break;
                case "categories":
                    this.categories = (TextField)value;
                    break;
                case "config":
                    this.config = (TextField)value;
                    break;
                case "messages":
                    this.messages = (TextField)value;
                    break;
                case "permissions":
                    this.permissions = (TextField)value;
                    break;
                case "email_templates":
                    this.email_templates = (TextField)value;
                    break;
                case "custom_fields":
                    this.custom_fields = (TextField)value;
                    break;
                case "style":
                    this.style = (TextField)value;
                    break;
                case "locale":
                    this.locale = (TextField)value;
                    break;
                case "user_login":
                    this.user_login = (TextField)value;
                    break;
                case "logout":
                    this.logout = (TextField)value;
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

    public void Validate(HMenuDataProvider provider)
    {
//End Record HMenu Item Class

//Record HMenu Item Class tail @38-F5FC18C5
    }
}
//End Record HMenu Item Class tail

//Record HMenu Data Provider Class @38-DCB0C969
public class HMenuDataProvider:RecordDataProviderBase
{
//End Record HMenu Data Provider Class

//Record HMenu Data Provider Class Variables @38-99B33BF0
    protected HMenuItem item;
//End Record HMenu Data Provider Class Variables

//Record HMenu Data Provider Class Constructor @38-C3A7A663
    public HMenuDataProvider()
    {
    }
//End Record HMenu Data Provider Class Constructor

//Record HMenu Data Provider Class LoadParams Method @38-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record HMenu Data Provider Class LoadParams Method

//Record HMenu Data Provider Class GetResultSet Method @38-B293DC46
    public void FillItem(HMenuItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record HMenu Data Provider Class GetResultSet Method

//Record HMenu BeforeBuildSelect @38-921CE95D
        if(!IsInsertMode){
//End Record HMenu BeforeBuildSelect

//Record HMenu AfterExecuteSelect @38-54D78817
        }
            IsInsertMode=true;
//End Record HMenu AfterExecuteSelect

//ListBox style AfterExecuteSelect @68-B8A2FB49
        
item.styleItems.Add("Basic","Basic");
item.styleItems.Add("Blueprint","Blueprint");
item.styleItems.Add("CoffeeBreak","CoffeeBreak");
item.styleItems.Add("Compact","Compact");
item.styleItems.Add("GreenApple","GreenApple");
item.styleItems.Add("Innovation","Innovation");
item.styleItems.Add("Pine","Pine");
item.styleItems.Add("SandBeach","SandBeach");
item.styleItems.Add("School","School");
//End ListBox style AfterExecuteSelect

//ListBox locale AfterExecuteSelect @69-82D5757C
        
item.localeItems.Add("en",Resources.strings.cal_english);
item.localeItems.Add("ru",Resources.strings.cal_russian);
//End ListBox locale AfterExecuteSelect

//Record HMenu AfterExecuteSelect tail @38-FCB6E20C
    }
//End Record HMenu AfterExecuteSelect tail

//Record HMenu Data Provider Class @38-FCB6E20C
}

//End Record HMenu Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

