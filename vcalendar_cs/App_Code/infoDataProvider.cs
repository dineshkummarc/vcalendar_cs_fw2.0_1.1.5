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

namespace calendar.info{ //Namespace @1-18705019

//Page Data Class @1-1484FF89
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.ContentLabel.SetValue(DBUtility.GetInitialValue("ContentLabel"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "ContentLabel":
                    return this.ContentLabel;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "ContentLabel":
                    this.ContentLabel = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField ContentLabel;
    public PageItem()
    {
        ContentLabel=new TextField("", null);
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

