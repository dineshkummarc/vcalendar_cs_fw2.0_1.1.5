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

namespace calendar.event_view{ //Namespace @1-CDDF298C

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

//Grid eventGrid Item Class @5-B314BAE7
public class eventGridItem:IDataItem
{
    public TextField event_title;
    public DateField event_date;
    public DateField event_time;
    public DateField event_time_end;
    public TextField group_id;
    public TextField user_id;
    public MemoField event_desc;
    public TextField LabelLocation;
    public TextField event_location;
    public TextField LabelCost;
    public TextField event_cost;
    public TextField LabelURL;
    public TextField event_url;
    public object event_urlHref;
    public LinkParameterCollection event_urlHrefParameters;
    public TextField LabelTextBox1;
    public TextField custom_TextBox1;
    public TextField LabelTextBox2;
    public TextField custom_TextBox2;
    public TextField LabelTextBox3;
    public TextField custom_TextBox3;
    public TextField LabelTextArea1;
    public TextField custom_TextArea1;
    public TextField LabelTextArea2;
    public TextField custom_TextArea2;
    public TextField LabelTextArea3;
    public TextField custom_TextArea3;
    public TextField LabelCheckBox1;
    public BooleanField custom_CheckBox1;
    public TextField LabelCheckBox2;
    public BooleanField custom_CheckBox2;
    public TextField LabelCheckBox3;
    public BooleanField custom_CheckBox3;
    public TextField edit_event;
    public object edit_eventHref;
    public LinkParameterCollection edit_eventHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public eventGridItem()
    {
        event_title=new TextField("", null);
        event_date=new DateField("D", null);
        event_time=new DateField("t", null);
        event_time_end=new DateField("t", null);
        group_id=new TextField("", null);
        user_id=new TextField("", null);
        event_desc=new MemoField("", null);
        LabelLocation=new TextField("", null);
        event_location=new TextField("", null);
        LabelCost=new TextField("", null);
        event_cost=new TextField("", null);
        LabelURL=new TextField("", null);
        event_url = new TextField("",null);
        event_urlHrefParameters = new LinkParameterCollection();
        LabelTextBox1=new TextField("", null);
        custom_TextBox1=new TextField("", null);
        LabelTextBox2=new TextField("", null);
        custom_TextBox2=new TextField("", null);
        LabelTextBox3=new TextField("", null);
        custom_TextBox3=new TextField("", null);
        LabelTextArea1=new TextField("", null);
        custom_TextArea1=new TextField("", null);
        LabelTextArea2=new TextField("", null);
        custom_TextArea2=new TextField("", null);
        LabelTextArea3=new TextField("", null);
        custom_TextArea3=new TextField("", null);
        LabelCheckBox1=new TextField("", null);
        custom_CheckBox1=new BooleanField(Settings.BoolFormat, null);
        LabelCheckBox2=new TextField("", null);
        custom_CheckBox2=new BooleanField(Settings.BoolFormat, null);
        LabelCheckBox3=new TextField("", null);
        custom_CheckBox3=new BooleanField(Settings.BoolFormat, null);
        edit_event = new TextField("",null);
        edit_eventHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "event_title":
                    return this.event_title;
                case "event_date":
                    return this.event_date;
                case "event_time":
                    return this.event_time;
                case "event_time_end":
                    return this.event_time_end;
                case "group_id":
                    return this.group_id;
                case "user_id":
                    return this.user_id;
                case "event_desc":
                    return this.event_desc;
                case "LabelLocation":
                    return this.LabelLocation;
                case "event_location":
                    return this.event_location;
                case "LabelCost":
                    return this.LabelCost;
                case "event_cost":
                    return this.event_cost;
                case "LabelURL":
                    return this.LabelURL;
                case "event_url":
                    return this.event_url;
                case "LabelTextBox1":
                    return this.LabelTextBox1;
                case "custom_TextBox1":
                    return this.custom_TextBox1;
                case "LabelTextBox2":
                    return this.LabelTextBox2;
                case "custom_TextBox2":
                    return this.custom_TextBox2;
                case "LabelTextBox3":
                    return this.LabelTextBox3;
                case "custom_TextBox3":
                    return this.custom_TextBox3;
                case "LabelTextArea1":
                    return this.LabelTextArea1;
                case "custom_TextArea1":
                    return this.custom_TextArea1;
                case "LabelTextArea2":
                    return this.LabelTextArea2;
                case "custom_TextArea2":
                    return this.custom_TextArea2;
                case "LabelTextArea3":
                    return this.LabelTextArea3;
                case "custom_TextArea3":
                    return this.custom_TextArea3;
                case "LabelCheckBox1":
                    return this.LabelCheckBox1;
                case "custom_CheckBox1":
                    return this.custom_CheckBox1;
                case "LabelCheckBox2":
                    return this.LabelCheckBox2;
                case "custom_CheckBox2":
                    return this.custom_CheckBox2;
                case "LabelCheckBox3":
                    return this.LabelCheckBox3;
                case "custom_CheckBox3":
                    return this.custom_CheckBox3;
                case "edit_event":
                    return this.edit_event;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "event_title":
                    this.event_title = (TextField)value;
                    break;
                case "event_date":
                    this.event_date = (DateField)value;
                    break;
                case "event_time":
                    this.event_time = (DateField)value;
                    break;
                case "event_time_end":
                    this.event_time_end = (DateField)value;
                    break;
                case "group_id":
                    this.group_id = (TextField)value;
                    break;
                case "user_id":
                    this.user_id = (TextField)value;
                    break;
                case "event_desc":
                    this.event_desc = (MemoField)value;
                    break;
                case "LabelLocation":
                    this.LabelLocation = (TextField)value;
                    break;
                case "event_location":
                    this.event_location = (TextField)value;
                    break;
                case "LabelCost":
                    this.LabelCost = (TextField)value;
                    break;
                case "event_cost":
                    this.event_cost = (TextField)value;
                    break;
                case "LabelURL":
                    this.LabelURL = (TextField)value;
                    break;
                case "event_url":
                    this.event_url = (TextField)value;
                    break;
                case "LabelTextBox1":
                    this.LabelTextBox1 = (TextField)value;
                    break;
                case "custom_TextBox1":
                    this.custom_TextBox1 = (TextField)value;
                    break;
                case "LabelTextBox2":
                    this.LabelTextBox2 = (TextField)value;
                    break;
                case "custom_TextBox2":
                    this.custom_TextBox2 = (TextField)value;
                    break;
                case "LabelTextBox3":
                    this.LabelTextBox3 = (TextField)value;
                    break;
                case "custom_TextBox3":
                    this.custom_TextBox3 = (TextField)value;
                    break;
                case "LabelTextArea1":
                    this.LabelTextArea1 = (TextField)value;
                    break;
                case "custom_TextArea1":
                    this.custom_TextArea1 = (TextField)value;
                    break;
                case "LabelTextArea2":
                    this.LabelTextArea2 = (TextField)value;
                    break;
                case "custom_TextArea2":
                    this.custom_TextArea2 = (TextField)value;
                    break;
                case "LabelTextArea3":
                    this.LabelTextArea3 = (TextField)value;
                    break;
                case "custom_TextArea3":
                    this.custom_TextArea3 = (TextField)value;
                    break;
                case "LabelCheckBox1":
                    this.LabelCheckBox1 = (TextField)value;
                    break;
                case "custom_CheckBox1":
                    this.custom_CheckBox1 = (BooleanField)value;
                    break;
                case "LabelCheckBox2":
                    this.LabelCheckBox2 = (TextField)value;
                    break;
                case "custom_CheckBox2":
                    this.custom_CheckBox2 = (BooleanField)value;
                    break;
                case "LabelCheckBox3":
                    this.LabelCheckBox3 = (TextField)value;
                    break;
                case "custom_CheckBox3":
                    this.custom_CheckBox3 = (BooleanField)value;
                    break;
                case "edit_event":
                    this.edit_event = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid eventGrid Item Class

//Grid eventGrid Data Provider Class Header @5-95D6CA3D
public class eventGridDataProvider:GridDataProviderBase
{
//End Grid eventGrid Data Provider Class Header

//Grid eventGrid Data Provider Class Variables @5-6D661BE8
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=1;
    public int PageNumber=1;
    public IntegerParameter Urlevent_id;
    public TextParameter Seslocale;
    public IntegerParameter Urlevents_category_id;
//End Grid eventGrid Data Provider Class Variables

//Grid eventGrid Data Provider Class Constructor @5-07DC3588
    public eventGridDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  events.*, user_login, user_last_name, \n" +
          "user_first_name, \n" +
          "category_name \n" +
          "FROM (events LEFT JOIN users ON\n" +
          "events.user_id = users.user_id) LEFT JOIN categories_langs ON\n" +
          "events.category_id = categories_langs.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"event_id29","And","(","locale203","Or","events_category_id204",")"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM (events LEFT JOIN users ON\n" +
          "events.user_id = users.user_id) LEFT JOIN categories_langs ON\n" +
          "events.category_id = categories_langs.category_id", new string[]{"event_id29","And","(","locale203","Or","events_category_id204",")"},Settings.calendarDataAccessObject);
    }
//End Grid eventGrid Data Provider Class Constructor

//Grid eventGrid Data Provider Class GetResultSet Method @5-77D8CD42
    public eventGridItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid eventGrid Data Provider Class GetResultSet Method

//Before build Select @5-BD643BBA
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("event_id29",Urlevent_id, "","events.event_id",Condition.Equal,true);
        ((TableCommand)Select).AddParameter("locale203",Seslocale, "","categories_langs.language_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("events_category_id204",Urlevents_category_id, "","events.category_id",Condition.IsNull,true);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @5-E5E76DF6
        DataSet ds=null;
        _pagesCount=0;
        eventGridItem[] result = new eventGridItem[0];
        if (ops.AllowRead) {
            try{
                if(RecordsPerPage>0)
                {
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage);
                    _pagesCount = ExecuteCount();
                    mRecordCount = _pagesCount;
                    _pagesCount = _pagesCount%RecordsPerPage>0?(int)(_pagesCount/RecordsPerPage)+1:(int)(_pagesCount/RecordsPerPage);
                }
                else
                {
                ds=ExecuteSelect();
                if(ds.Tables[tableIndex].Rows.Count!=0){
                    _pagesCount=1;mRecordCount = ds.Tables[tableIndex].Rows.Count;}
                }
            }catch(Exception e){
                E=e;}
            finally{
//End Execute Select

//After execute Select @5-48F2A5CE
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new eventGridItem[dr.Count];
//End After execute Select

//After execute Select tail @5-7BFF8F4C
            for(int i=0;i<dr.Count;i++)
            {
                eventGridItem item=new eventGridItem();
                item.event_title.SetValue(dr[i]["event_title"],"");
                item.event_date.SetValue(dr[i]["event_date"],"yyyy-MM-dd");
                item.event_time.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
                item.event_time_end.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
                item.group_id.SetValue(dr[i]["category_name"],"");
                item.user_id.SetValue(dr[i]["user_login"],"");
                item.event_desc.SetValue(dr[i]["event_desc"],"");
                item.event_location.SetValue(dr[i]["event_location"],"");
                item.event_cost.SetValue(dr[i]["event_cost"],"");
                item.event_url.SetValue(dr[i]["event_url"],"");
                item.event_urlHref = dr[i]["event_url"];
                item.custom_TextBox1.SetValue(dr[i]["custom_TextBox1"],"");
                item.custom_TextBox2.SetValue(dr[i]["custom_TextBox2"],"");
                item.custom_TextBox3.SetValue(dr[i]["custom_TextBox3"],"");
                item.custom_TextArea1.SetValue(dr[i]["custom_TextArea1"],"");
                item.custom_TextArea2.SetValue(dr[i]["custom_TextArea2"],"");
                item.custom_TextArea3.SetValue(dr[i]["custom_TextArea3"],"");
                item.custom_CheckBox1.SetValue(dr[i]["custom_CheckBox1"],Select.BoolFormat);
                item.custom_CheckBox2.SetValue(dr[i]["custom_CheckBox2"],Select.BoolFormat);
                item.custom_CheckBox3.SetValue(dr[i]["custom_CheckBox3"],Select.BoolFormat);
                item.edit_eventHref = "events.aspx";
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @5-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

