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

namespace calendar.header{ //Namespace @1-D4456FBF

//Page Data Class @1-32DE1C57
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.html_header.SetValue(DBUtility.GetInitialValue("html_header"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "html_header":
                    return this.html_header;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "html_header":
                    this.html_header = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField html_header;
    public PageItem()
    {
        html_header=new TextField("", null);
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

//Record HMenu Item Class @65-BF592E19
public class HMenuItem
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
    public TextField lbl_day;
    public object lbl_dayHref;
    public LinkParameterCollection lbl_dayHrefParameters;
    public TextField search;
    public object searchHref;
    public LinkParameterCollection searchHrefParameters;
    public TextField add_event;
    public object add_eventHref;
    public LinkParameterCollection add_eventHrefParameters;
    public TextField RegLink;
    public object RegLinkHref;
    public LinkParameterCollection RegLinkHrefParameters;
    public TextField login;
    public object loginHref;
    public LinkParameterCollection loginHrefParameters;
    public TextField profile;
    public object profileHref;
    public LinkParameterCollection profileHrefParameters;
    public TextField administration_link;
    public object administration_linkHref;
    public LinkParameterCollection administration_linkHrefParameters;
    public TextField administration_link_spacer;
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
    public HMenuItem()
    {
        year = new TextField("",null);
        yearHrefParameters = new LinkParameterCollection();
        month = new TextField("",null);
        monthHrefParameters = new LinkParameterCollection();
        week = new TextField("",null);
        weekHrefParameters = new LinkParameterCollection();
        lbl_day = new TextField("",null);
        lbl_dayHrefParameters = new LinkParameterCollection();
        search = new TextField("",null);
        searchHrefParameters = new LinkParameterCollection();
        add_event = new TextField("",null);
        add_eventHrefParameters = new LinkParameterCollection();
        RegLink = new TextField("",null);
        RegLinkHrefParameters = new LinkParameterCollection();
        login = new TextField("",null);
        loginHrefParameters = new LinkParameterCollection();
        profile = new TextField("",null);
        profileHrefParameters = new LinkParameterCollection();
        administration_link = new TextField("",null);
        administration_linkHrefParameters = new LinkParameterCollection();
        administration_link_spacer=new TextField("", "  &middot;  ");
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

    public static HMenuItem CreateFromHttpRequest()
    {
        HMenuItem item = new HMenuItem();
        if(DBUtility.GetInitialValue("year") != null){
        item.year.SetValue(DBUtility.GetInitialValue("year"));
        }
        if(DBUtility.GetInitialValue("month") != null){
        item.month.SetValue(DBUtility.GetInitialValue("month"));
        }
        if(DBUtility.GetInitialValue("week") != null){
        item.week.SetValue(DBUtility.GetInitialValue("week"));
        }
        if(DBUtility.GetInitialValue("lbl_day") != null){
        item.lbl_day.SetValue(DBUtility.GetInitialValue("lbl_day"));
        }
        if(DBUtility.GetInitialValue("search") != null){
        item.search.SetValue(DBUtility.GetInitialValue("search"));
        }
        if(DBUtility.GetInitialValue("add_event") != null){
        item.add_event.SetValue(DBUtility.GetInitialValue("add_event"));
        }
        if(DBUtility.GetInitialValue("RegLink") != null){
        item.RegLink.SetValue(DBUtility.GetInitialValue("RegLink"));
        }
        if(DBUtility.GetInitialValue("login") != null){
        item.login.SetValue(DBUtility.GetInitialValue("login"));
        }
        if(DBUtility.GetInitialValue("profile") != null){
        item.profile.SetValue(DBUtility.GetInitialValue("profile"));
        }
        if(DBUtility.GetInitialValue("administration_link") != null){
        item.administration_link.SetValue(DBUtility.GetInitialValue("administration_link"));
        }
        if(DBUtility.GetInitialValue("administration_link_spacer") != null){
        item.administration_link_spacer.SetValue(DBUtility.GetInitialValue("administration_link_spacer"));
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
                case "lbl_day":
                    return this.lbl_day;
                case "search":
                    return this.search;
                case "add_event":
                    return this.add_event;
                case "RegLink":
                    return this.RegLink;
                case "login":
                    return this.login;
                case "profile":
                    return this.profile;
                case "administration_link":
                    return this.administration_link;
                case "administration_link_spacer":
                    return this.administration_link_spacer;
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
                case "lbl_day":
                    this.lbl_day = (TextField)value;
                    break;
                case "search":
                    this.search = (TextField)value;
                    break;
                case "add_event":
                    this.add_event = (TextField)value;
                    break;
                case "RegLink":
                    this.RegLink = (TextField)value;
                    break;
                case "login":
                    this.login = (TextField)value;
                    break;
                case "profile":
                    this.profile = (TextField)value;
                    break;
                case "administration_link":
                    this.administration_link = (TextField)value;
                    break;
                case "administration_link_spacer":
                    this.administration_link_spacer = (TextField)value;
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

    public void Validate(HMenuDataProvider provider)
    {
//End Record HMenu Item Class

//Record HMenu Item Class tail @65-F5FC18C5
    }
}
//End Record HMenu Item Class tail

//Record HMenu Data Provider Class @65-DCB0C969
public class HMenuDataProvider:RecordDataProviderBase
{
//End Record HMenu Data Provider Class

//Record HMenu Data Provider Class Variables @65-51DE16BC
    protected DataCommand categoriesDataCommand;
    protected HMenuItem item;
    public TextParameter Seslocale;
//End Record HMenu Data Provider Class Variables

//Record HMenu Data Provider Class Constructor @65-20D67DD4
    public HMenuDataProvider()
    {
         categoriesDataCommand=new TableCommand("SELECT categories_langs.category_name AS categories_langs_category_name, \n" +
          "category_id \n" +
          "FROM categories_langs {SQL_Where} {SQL_OrderBy}", new string[]{"locale98"},Settings.calendarDataAccessObject);
    }
//End Record HMenu Data Provider Class Constructor

//Record HMenu Data Provider Class LoadParams Method @65-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record HMenu Data Provider Class LoadParams Method

//Record HMenu Data Provider Class GetResultSet Method @65-B293DC46
    public void FillItem(HMenuItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record HMenu Data Provider Class GetResultSet Method

//Record HMenu BeforeBuildSelect @65-921CE95D
        if(!IsInsertMode){
//End Record HMenu BeforeBuildSelect

//Record HMenu AfterExecuteSelect @65-C5999683
        }
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record HMenu AfterExecuteSelect

//ListBox style AfterExecuteSelect @86-B8A2FB49
        
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

//ListBox locale AfterExecuteSelect @87-82D5757C
        
item.localeItems.Add("en",Resources.strings.cal_english);
item.localeItems.Add("ru",Resources.strings.cal_russian);
//End ListBox locale AfterExecuteSelect

//ListBox categories Initialize Data Source @88-F74B0BA2
        int categoriestableIndex = 0;
        categoriesDataCommand.OrderBy = "category_name";
        categoriesDataCommand.Parameters.Clear();
        ((TableCommand)categoriesDataCommand).AddParameter("locale98",Seslocale, "","language_id",Condition.Equal,false);
//End ListBox categories Initialize Data Source

//ListBox categories BeforeExecuteSelect @88-DABDA59F
        try{
            ListBoxSource=categoriesDataCommand.Execute().Tables[categoriestableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox categories BeforeExecuteSelect

//ListBox categories AfterExecuteSelect @88-47506EC2
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["categories_langs_category_name"];
            string key = (new TextField("", ListBoxSource[li]["category_id"])).GetFormattedValue("");
            item.categoriesItems.Add(key,val);
        }
//End ListBox categories AfterExecuteSelect

//Record HMenu AfterExecuteSelect tail @65-FCB6E20C
    }
//End Record HMenu AfterExecuteSelect tail

//Record HMenu Data Provider Class @65-FCB6E20C
}

//End Record HMenu Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

