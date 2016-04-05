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

namespace calendar.profile_menu{ //Namespace @1-58C1A5DF

//Page Data Class @1-FA9DB7F9
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.profile_main.SetValue(DBUtility.GetInitialValue("profile_main"));
        item.profile_chpass.SetValue(DBUtility.GetInitialValue("profile_chpass"));
        item.my_events.SetValue(DBUtility.GetInitialValue("my_events"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "profile_main":
                    return this.profile_main;
                case "profile_chpass":
                    return this.profile_chpass;
                case "my_events":
                    return this.my_events;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "profile_main":
                    this.profile_main = (TextField)value;
                    break;
                case "profile_chpass":
                    this.profile_chpass = (TextField)value;
                    break;
                case "my_events":
                    this.my_events = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField profile_main;
    public object profile_mainHref;
    public LinkParameterCollection profile_mainHrefParameters;
    public TextField profile_chpass;
    public object profile_chpassHref;
    public LinkParameterCollection profile_chpassHrefParameters;
    public TextField my_events;
    public object my_eventsHref;
    public LinkParameterCollection my_eventsHrefParameters;
    public PageItem()
    {
        profile_main = new TextField("",null);
        profile_mainHrefParameters = new LinkParameterCollection();
        profile_chpass = new TextField("",null);
        profile_chpassHrefParameters = new LinkParameterCollection();
        my_events = new TextField("",null);
        my_eventsHrefParameters = new LinkParameterCollection();
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

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

