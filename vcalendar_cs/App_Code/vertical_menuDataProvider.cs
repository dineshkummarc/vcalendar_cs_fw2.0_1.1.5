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

namespace calendar.vertical_menu{ //Namespace @1-B4314668

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

//Record VerticalMenu Item Class @127-0535B4A6
public class VerticalMenuItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField year;
    public object yearHref;
    public LinkParameterCollection yearHrefParameters;
    public TextField month;
    public object monthHref;
    public LinkParameterCollection monthHrefParameters;
    public TextField week;
    public object weekHref;
    public LinkParameterCollection weekHrefParameters;
    public TextField day;
    public object dayHref;
    public LinkParameterCollection dayHrefParameters;
    public TextField search;
    public object searchHref;
    public LinkParameterCollection searchHrefParameters;
    public TextField RegLink;
    public object RegLinkHref;
    public LinkParameterCollection RegLinkHrefParameters;
    public TextField login;
    public object loginHref;
    public LinkParameterCollection loginHrefParameters;
    public TextField add_event;
    public object add_eventHref;
    public LinkParameterCollection add_eventHrefParameters;
    public TextField profile;
    public object profileHref;
    public LinkParameterCollection profileHrefParameters;
    public TextField administration_link;
    public object administration_linkHref;
    public LinkParameterCollection administration_linkHrefParameters;
    public TextField logout;
    public object logoutHref;
    public LinkParameterCollection logoutHrefParameters;
    public TextField user_login;
    public TextField style;
    public ItemCollection styleItems;
    public TextField locale;
    public ItemCollection localeItems;
    public TextField categories;
    public ItemCollection categoriesItems;
    public NameValueCollection errors=new NameValueCollection();
    public VerticalMenuItem()
    {
        year = new TextField("",null);
        yearHrefParameters = new LinkParameterCollection();
        month = new TextField("",null);
        monthHrefParameters = new LinkParameterCollection();
        week = new TextField("",null);
        weekHrefParameters = new LinkParameterCollection();
        day = new TextField("",null);
        dayHrefParameters = new LinkParameterCollection();
        search = new TextField("",null);
        searchHrefParameters = new LinkParameterCollection();
        RegLink = new TextField("",null);
        RegLinkHrefParameters = new LinkParameterCollection();
        login = new TextField("",null);
        loginHrefParameters = new LinkParameterCollection();
        add_event = new TextField("",null);
        add_eventHrefParameters = new LinkParameterCollection();
        profile = new TextField("",null);
        profileHrefParameters = new LinkParameterCollection();
        administration_link = new TextField("",null);
        administration_linkHrefParameters = new LinkParameterCollection();
        logout = new TextField("",null);
        logoutHrefParameters = new LinkParameterCollection();
        user_login=new TextField("", DBUtility.UserLogin);
        style = new TextField("", null);
        styleItems = new ItemCollection();
        locale = new TextField("", null);
        localeItems = new ItemCollection();
        categories = new TextField("", null);
        categoriesItems = new ItemCollection();
    }

    public static VerticalMenuItem CreateFromHttpRequest()
    {
        VerticalMenuItem item = new VerticalMenuItem();
        if(DBUtility.GetInitialValue("year") != null){
        item.year.SetValue(DBUtility.GetInitialValue("year"));
        }
        if(DBUtility.GetInitialValue("month") != null){
        item.month.SetValue(DBUtility.GetInitialValue("month"));
        }
        if(DBUtility.GetInitialValue("week") != null){
        item.week.SetValue(DBUtility.GetInitialValue("week"));
        }
        if(DBUtility.GetInitialValue("day") != null){
        item.day.SetValue(DBUtility.GetInitialValue("day"));
        }
        if(DBUtility.GetInitialValue("search") != null){
        item.search.SetValue(DBUtility.GetInitialValue("search"));
        }
        if(DBUtility.GetInitialValue("RegLink") != null){
        item.RegLink.SetValue(DBUtility.GetInitialValue("RegLink"));
        }
        if(DBUtility.GetInitialValue("login") != null){
        item.login.SetValue(DBUtility.GetInitialValue("login"));
        }
        if(DBUtility.GetInitialValue("add_event") != null){
        item.add_event.SetValue(DBUtility.GetInitialValue("add_event"));
        }
        if(DBUtility.GetInitialValue("profile") != null){
        item.profile.SetValue(DBUtility.GetInitialValue("profile"));
        }
        if(DBUtility.GetInitialValue("administration_link") != null){
        item.administration_link.SetValue(DBUtility.GetInitialValue("administration_link"));
        }
        if(DBUtility.GetInitialValue("logout") != null){
        item.logout.SetValue(DBUtility.GetInitialValue("logout"));
        }
        if(DBUtility.GetInitialValue("user_login") != null){
        item.user_login.SetValue(DBUtility.GetInitialValue("user_login"));
        }
        if(DBUtility.GetInitialValue("style") != null){
        item.style.SetValue(DBUtility.GetInitialValue("style"));
        }
        if(DBUtility.GetInitialValue("locale") != null){
        item.locale.SetValue(DBUtility.GetInitialValue("locale"));
        }
        if(DBUtility.GetInitialValue("categories") != null){
        item.categories.SetValue(DBUtility.GetInitialValue("categories"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "year":
                    return this.year;
                case "month":
                    return this.month;
                case "week":
                    return this.week;
                case "day":
                    return this.day;
                case "search":
                    return this.search;
                case "RegLink":
                    return this.RegLink;
                case "login":
                    return this.login;
                case "add_event":
                    return this.add_event;
                case "profile":
                    return this.profile;
                case "administration_link":
                    return this.administration_link;
                case "logout":
                    return this.logout;
                case "user_login":
                    return this.user_login;
                case "style":
                    return this.style;
                case "locale":
                    return this.locale;
                case "categories":
                    return this.categories;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "year":
                    this.year = (TextField)value;
                    break;
                case "month":
                    this.month = (TextField)value;
                    break;
                case "week":
                    this.week = (TextField)value;
                    break;
                case "day":
                    this.day = (TextField)value;
                    break;
                case "search":
                    this.search = (TextField)value;
                    break;
                case "RegLink":
                    this.RegLink = (TextField)value;
                    break;
                case "login":
                    this.login = (TextField)value;
                    break;
                case "add_event":
                    this.add_event = (TextField)value;
                    break;
                case "profile":
                    this.profile = (TextField)value;
                    break;
                case "administration_link":
                    this.administration_link = (TextField)value;
                    break;
                case "logout":
                    this.logout = (TextField)value;
                    break;
                case "user_login":
                    this.user_login = (TextField)value;
                    break;
                case "style":
                    this.style = (TextField)value;
                    break;
                case "locale":
                    this.locale = (TextField)value;
                    break;
                case "categories":
                    this.categories = (TextField)value;
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

    public void Validate(VerticalMenuDataProvider provider)
    {
//End Record VerticalMenu Item Class

//Record VerticalMenu Event OnValidate. Action Custom Code @168-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Record VerticalMenu Event OnValidate. Action Custom Code

//Record VerticalMenu Item Class tail @127-F5FC18C5
    }
}
//End Record VerticalMenu Item Class tail

//Record VerticalMenu Data Provider Class @127-82421EF0
public class VerticalMenuDataProvider:RecordDataProviderBase
{
//End Record VerticalMenu Data Provider Class

//Record VerticalMenu Data Provider Class Variables @127-386E9E7E
    protected DataCommand categoriesDataCommand;
    protected VerticalMenuItem item;
    public TextParameter Seslocale;
//End Record VerticalMenu Data Provider Class Variables

//Record VerticalMenu Data Provider Class Constructor @127-8CAE00B8
    public VerticalMenuDataProvider()
    {
         categoriesDataCommand=new TableCommand("SELECT category_name, \n" +
          "category_id \n" +
          "FROM categories_langs {SQL_Where} {SQL_OrderBy}", new string[]{"locale149"},Settings.calendarDataAccessObject);
    }
//End Record VerticalMenu Data Provider Class Constructor

//Record VerticalMenu Data Provider Class LoadParams Method @127-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record VerticalMenu Data Provider Class LoadParams Method

//Record VerticalMenu Data Provider Class GetResultSet Method @127-149D4B26
    public void FillItem(VerticalMenuItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record VerticalMenu Data Provider Class GetResultSet Method

//Record VerticalMenu BeforeBuildSelect @127-921CE95D
        if(!IsInsertMode){
//End Record VerticalMenu BeforeBuildSelect

//Record VerticalMenu AfterExecuteSelect @127-C5999683
        }
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record VerticalMenu AfterExecuteSelect

//ListBox style AfterExecuteSelect @140-B8A2FB49
        
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

//ListBox locale AfterExecuteSelect @141-82D5757C
        
item.localeItems.Add("en",Resources.strings.cal_english);
item.localeItems.Add("ru",Resources.strings.cal_russian);
//End ListBox locale AfterExecuteSelect

//ListBox categories Initialize Data Source @142-F91975AF
        int categoriestableIndex = 0;
        categoriesDataCommand.OrderBy = "category_name";
        categoriesDataCommand.Parameters.Clear();
        ((TableCommand)categoriesDataCommand).AddParameter("locale149",Seslocale, "","language_id",Condition.Equal,false);
//End ListBox categories Initialize Data Source

//ListBox categories BeforeExecuteSelect @142-DABDA59F
        try{
            ListBoxSource=categoriesDataCommand.Execute().Tables[categoriestableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox categories BeforeExecuteSelect

//ListBox categories AfterExecuteSelect @142-E2D0317E
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["category_name"];
            string key = (new TextField("", ListBoxSource[li]["category_id"])).GetFormattedValue("");
            item.categoriesItems.Add(key,val);
        }
//End ListBox categories AfterExecuteSelect

//Record VerticalMenu AfterExecuteSelect tail @127-FCB6E20C
    }
//End Record VerticalMenu AfterExecuteSelect tail

//Record VerticalMenu Data Provider Class @127-FCB6E20C
}

//End Record VerticalMenu Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

