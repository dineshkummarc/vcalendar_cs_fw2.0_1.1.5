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

namespace calendar.events{ //Namespace @1-AE12C0E8

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

//Record events_rec Item Class @5-C2A6B2FE
public class events_recItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public IntegerField category_id;
    public ItemCollection category_idItems;
    public TextField event_title;
    public MemoField event_desc;
    public TextField event_time_hrs;
    public ItemCollection event_time_hrsItems;
    public TextField event_time_mns;
    public ItemCollection event_time_mnsItems;
    public TextField time_hrs_end;
    public ItemCollection time_hrs_endItems;
    public TextField time_mns_end;
    public ItemCollection time_mns_endItems;
    public IntegerField allday;
    public IntegerField alldayCheckedValue;
    public IntegerField alldayUncheckedValue;
    public DateField event_date;
    public IntegerField RepeatEvent;
    public IntegerField RepeatEventCheckedValue;
    public IntegerField RepeatEventUncheckedValue;
    public TextField RepeatNum;
    public TextField RepeatType;
    public ItemCollection RepeatTypeItems;
    public DateField event_todate;
    public IntegerField event_is_public;
    public IntegerField event_is_publicCheckedValue;
    public IntegerField event_is_publicUncheckedValue;
    public IntegerField user_id;
    public DateField event_time;
    public DateField event_time_end;
    public TextField LabelLocation;
    public TextField event_location;
    public TextField LabelCost;
    public TextField event_cost;
    public TextField LabelURL;
    public TextField event_URL;
    public TextField LabelTextBox1;
    public TextField TextBox1;
    public TextField LabelTextBox2;
    public TextField TextBox2;
    public TextField LabelTextBox3;
    public TextField TextBox3;
    public TextField LabelTextArea1;
    public TextField TextArea1;
    public TextField LabelTextArea2;
    public TextField TextArea2;
    public TextField LabelTextArea3;
    public TextField TextArea3;
    public TextField LabelCheckBox1;
    public IntegerField CheckBox1;
    public IntegerField CheckBox1CheckedValue;
    public IntegerField CheckBox1UncheckedValue;
    public TextField LabelCheckBox2;
    public IntegerField CheckBox2;
    public IntegerField CheckBox2CheckedValue;
    public IntegerField CheckBox2UncheckedValue;
    public TextField LabelCheckBox3;
    public IntegerField CheckBox3;
    public IntegerField CheckBox3CheckedValue;
    public IntegerField CheckBox3UncheckedValue;
    public IntegerField RecurrentApply;
    public IntegerField RecurrentApplyCheckedValue;
    public IntegerField RecurrentApplyUncheckedValue;
    public TextField event_parent_id;
    public NameValueCollection errors=new NameValueCollection();
    public events_recItem()
    {
        category_id = new IntegerField("", null);
        category_idItems = new ItemCollection();
        event_title=new TextField("", null);
        event_desc=new MemoField("", null);
        event_time_hrs = new TextField("", null);
        event_time_hrsItems = new ItemCollection();
        event_time_mns = new TextField("", null);
        event_time_mnsItems = new ItemCollection();
        time_hrs_end = new TextField("", null);
        time_hrs_endItems = new ItemCollection();
        time_mns_end = new TextField("", null);
        time_mns_endItems = new ItemCollection();
        allday = new IntegerField("", null);
        alldayCheckedValue = new IntegerField("", 1);
        alldayUncheckedValue = new IntegerField("", 0);
        event_date=new DateField("d", null);
        RepeatEvent = new IntegerField("", null);
        RepeatEventCheckedValue = new IntegerField("", 1);
        RepeatEventUncheckedValue = new IntegerField("", 0);
        RepeatNum=new TextField("", 1);
        RepeatType = new TextField("", null);
        RepeatTypeItems = new ItemCollection();
        event_todate=new DateField("d", null);
        event_is_public = new IntegerField("", 1);
        event_is_publicCheckedValue = new IntegerField("", 1);
        event_is_publicUncheckedValue = new IntegerField("", 0);
        user_id=new IntegerField("", null);
        event_time=new DateField("HH\\:mm", null);
        event_time_end=new DateField("HH\\:mm", null);
        LabelLocation=new TextField("", null);
        event_location=new TextField("", null);
        LabelCost=new TextField("", null);
        event_cost=new TextField("", null);
        LabelURL=new TextField("", null);
        event_URL=new TextField("", null);
        LabelTextBox1=new TextField("", null);
        TextBox1=new TextField("", null);
        LabelTextBox2=new TextField("", null);
        TextBox2=new TextField("", null);
        LabelTextBox3=new TextField("", null);
        TextBox3=new TextField("", null);
        LabelTextArea1=new TextField("", null);
        TextArea1=new TextField("", null);
        LabelTextArea2=new TextField("", null);
        TextArea2=new TextField("", null);
        LabelTextArea3=new TextField("", null);
        TextArea3=new TextField("", null);
        LabelCheckBox1=new TextField("", null);
        CheckBox1 = new IntegerField("", null);
        CheckBox1CheckedValue = new IntegerField("", 1);
        CheckBox1UncheckedValue = new IntegerField("", 0);
        LabelCheckBox2=new TextField("", null);
        CheckBox2 = new IntegerField("", null);
        CheckBox2CheckedValue = new IntegerField("", 1);
        CheckBox2UncheckedValue = new IntegerField("", 0);
        LabelCheckBox3=new TextField("", null);
        CheckBox3 = new IntegerField("", null);
        CheckBox3CheckedValue = new IntegerField("", 1);
        CheckBox3UncheckedValue = new IntegerField("", 0);
        RecurrentApply = new IntegerField("", 0);
        RecurrentApplyCheckedValue = new IntegerField("", 1);
        RecurrentApplyUncheckedValue = new IntegerField("", 0);
        event_parent_id=new TextField("", null);
    }

    public static events_recItem CreateFromHttpRequest()
    {
        events_recItem item = new events_recItem();
        if(DBUtility.GetInitialValue("category_id") != null){
        item.category_id.SetValue(DBUtility.GetInitialValue("category_id"));
        }
        if(DBUtility.GetInitialValue("event_title") != null){
        item.event_title.SetValue(DBUtility.GetInitialValue("event_title"));
        }
        if(DBUtility.GetInitialValue("event_desc") != null){
        item.event_desc.SetValue(DBUtility.GetInitialValue("event_desc"));
        }
        if(DBUtility.GetInitialValue("event_time_hrs") != null){
        item.event_time_hrs.SetValue(DBUtility.GetInitialValue("event_time_hrs"));
        }
        if(DBUtility.GetInitialValue("event_time_mns") != null){
        item.event_time_mns.SetValue(DBUtility.GetInitialValue("event_time_mns"));
        }
        if(DBUtility.GetInitialValue("time_hrs_end") != null){
        item.time_hrs_end.SetValue(DBUtility.GetInitialValue("time_hrs_end"));
        }
        if(DBUtility.GetInitialValue("time_mns_end") != null){
        item.time_mns_end.SetValue(DBUtility.GetInitialValue("time_mns_end"));
        }
        if(DBUtility.GetInitialValue("allday") != null){
        if(System.Web.HttpContext.Current.Request["allday"]!=null)
            item.allday.Value = item.alldayCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("event_date") != null){
        item.event_date.SetValue(DBUtility.GetInitialValue("event_date"));
        }
        if(DBUtility.GetInitialValue("RepeatEvent") != null){
        if(System.Web.HttpContext.Current.Request["RepeatEvent"]!=null)
            item.RepeatEvent.Value = item.RepeatEventCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("RepeatNum") != null){
        item.RepeatNum.SetValue(DBUtility.GetInitialValue("RepeatNum"));
        }
        if(DBUtility.GetInitialValue("RepeatType") != null){
        item.RepeatType.SetValue(DBUtility.GetInitialValue("RepeatType"));
        }
        if(DBUtility.GetInitialValue("event_todate") != null){
        item.event_todate.SetValue(DBUtility.GetInitialValue("event_todate"));
        }
        if(DBUtility.GetInitialValue("event_is_public") != null){
        if(System.Web.HttpContext.Current.Request["event_is_public"]!=null)
            item.event_is_public.Value = item.event_is_publicCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("user_id") != null){
        item.user_id.SetValue(DBUtility.GetInitialValue("user_id"));
        }
        if(DBUtility.GetInitialValue("event_time") != null){
        item.event_time.SetValue(DBUtility.GetInitialValue("event_time"));
        }
        if(DBUtility.GetInitialValue("event_time_end") != null){
        item.event_time_end.SetValue(DBUtility.GetInitialValue("event_time_end"));
        }
        if(DBUtility.GetInitialValue("LabelLocation") != null){
        item.LabelLocation.SetValue(DBUtility.GetInitialValue("LabelLocation"));
        }
        if(DBUtility.GetInitialValue("event_location") != null){
        item.event_location.SetValue(DBUtility.GetInitialValue("event_location"));
        }
        if(DBUtility.GetInitialValue("LabelCost") != null){
        item.LabelCost.SetValue(DBUtility.GetInitialValue("LabelCost"));
        }
        if(DBUtility.GetInitialValue("event_cost") != null){
        item.event_cost.SetValue(DBUtility.GetInitialValue("event_cost"));
        }
        if(DBUtility.GetInitialValue("LabelURL") != null){
        item.LabelURL.SetValue(DBUtility.GetInitialValue("LabelURL"));
        }
        if(DBUtility.GetInitialValue("event_URL") != null){
        item.event_URL.SetValue(DBUtility.GetInitialValue("event_URL"));
        }
        if(DBUtility.GetInitialValue("LabelTextBox1") != null){
        item.LabelTextBox1.SetValue(DBUtility.GetInitialValue("LabelTextBox1"));
        }
        if(DBUtility.GetInitialValue("TextBox1") != null){
        item.TextBox1.SetValue(DBUtility.GetInitialValue("TextBox1"));
        }
        if(DBUtility.GetInitialValue("LabelTextBox2") != null){
        item.LabelTextBox2.SetValue(DBUtility.GetInitialValue("LabelTextBox2"));
        }
        if(DBUtility.GetInitialValue("TextBox2") != null){
        item.TextBox2.SetValue(DBUtility.GetInitialValue("TextBox2"));
        }
        if(DBUtility.GetInitialValue("LabelTextBox3") != null){
        item.LabelTextBox3.SetValue(DBUtility.GetInitialValue("LabelTextBox3"));
        }
        if(DBUtility.GetInitialValue("TextBox3") != null){
        item.TextBox3.SetValue(DBUtility.GetInitialValue("TextBox3"));
        }
        if(DBUtility.GetInitialValue("LabelTextArea1") != null){
        item.LabelTextArea1.SetValue(DBUtility.GetInitialValue("LabelTextArea1"));
        }
        if(DBUtility.GetInitialValue("TextArea1") != null){
        item.TextArea1.SetValue(DBUtility.GetInitialValue("TextArea1"));
        }
        if(DBUtility.GetInitialValue("LabelTextArea2") != null){
        item.LabelTextArea2.SetValue(DBUtility.GetInitialValue("LabelTextArea2"));
        }
        if(DBUtility.GetInitialValue("TextArea2") != null){
        item.TextArea2.SetValue(DBUtility.GetInitialValue("TextArea2"));
        }
        if(DBUtility.GetInitialValue("LabelTextArea3") != null){
        item.LabelTextArea3.SetValue(DBUtility.GetInitialValue("LabelTextArea3"));
        }
        if(DBUtility.GetInitialValue("TextArea3") != null){
        item.TextArea3.SetValue(DBUtility.GetInitialValue("TextArea3"));
        }
        if(DBUtility.GetInitialValue("LabelCheckBox1") != null){
        item.LabelCheckBox1.SetValue(DBUtility.GetInitialValue("LabelCheckBox1"));
        }
        if(DBUtility.GetInitialValue("CheckBox1") != null){
        if(System.Web.HttpContext.Current.Request["CheckBox1"]!=null)
            item.CheckBox1.Value = item.CheckBox1CheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("LabelCheckBox2") != null){
        item.LabelCheckBox2.SetValue(DBUtility.GetInitialValue("LabelCheckBox2"));
        }
        if(DBUtility.GetInitialValue("CheckBox2") != null){
        if(System.Web.HttpContext.Current.Request["CheckBox2"]!=null)
            item.CheckBox2.Value = item.CheckBox2CheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("LabelCheckBox3") != null){
        item.LabelCheckBox3.SetValue(DBUtility.GetInitialValue("LabelCheckBox3"));
        }
        if(DBUtility.GetInitialValue("CheckBox3") != null){
        if(System.Web.HttpContext.Current.Request["CheckBox3"]!=null)
            item.CheckBox3.Value = item.CheckBox3CheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("RecurrentApply") != null){
        if(System.Web.HttpContext.Current.Request["RecurrentApply"]!=null)
            item.RecurrentApply.Value = item.RecurrentApplyCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("event_parent_id") != null){
        item.event_parent_id.SetValue(DBUtility.GetInitialValue("event_parent_id"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "category_id":
                    return this.category_id;
                case "event_title":
                    return this.event_title;
                case "event_desc":
                    return this.event_desc;
                case "event_time_hrs":
                    return this.event_time_hrs;
                case "event_time_mns":
                    return this.event_time_mns;
                case "time_hrs_end":
                    return this.time_hrs_end;
                case "time_mns_end":
                    return this.time_mns_end;
                case "allday":
                    return this.allday;
                case "event_date":
                    return this.event_date;
                case "RepeatEvent":
                    return this.RepeatEvent;
                case "RepeatNum":
                    return this.RepeatNum;
                case "RepeatType":
                    return this.RepeatType;
                case "event_todate":
                    return this.event_todate;
                case "event_is_public":
                    return this.event_is_public;
                case "user_id":
                    return this.user_id;
                case "event_time":
                    return this.event_time;
                case "event_time_end":
                    return this.event_time_end;
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
                case "event_URL":
                    return this.event_URL;
                case "LabelTextBox1":
                    return this.LabelTextBox1;
                case "TextBox1":
                    return this.TextBox1;
                case "LabelTextBox2":
                    return this.LabelTextBox2;
                case "TextBox2":
                    return this.TextBox2;
                case "LabelTextBox3":
                    return this.LabelTextBox3;
                case "TextBox3":
                    return this.TextBox3;
                case "LabelTextArea1":
                    return this.LabelTextArea1;
                case "TextArea1":
                    return this.TextArea1;
                case "LabelTextArea2":
                    return this.LabelTextArea2;
                case "TextArea2":
                    return this.TextArea2;
                case "LabelTextArea3":
                    return this.LabelTextArea3;
                case "TextArea3":
                    return this.TextArea3;
                case "LabelCheckBox1":
                    return this.LabelCheckBox1;
                case "CheckBox1":
                    return this.CheckBox1;
                case "LabelCheckBox2":
                    return this.LabelCheckBox2;
                case "CheckBox2":
                    return this.CheckBox2;
                case "LabelCheckBox3":
                    return this.LabelCheckBox3;
                case "CheckBox3":
                    return this.CheckBox3;
                case "RecurrentApply":
                    return this.RecurrentApply;
                case "event_parent_id":
                    return this.event_parent_id;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "category_id":
                    this.category_id = (IntegerField)value;
                    break;
                case "event_title":
                    this.event_title = (TextField)value;
                    break;
                case "event_desc":
                    this.event_desc = (MemoField)value;
                    break;
                case "event_time_hrs":
                    this.event_time_hrs = (TextField)value;
                    break;
                case "event_time_mns":
                    this.event_time_mns = (TextField)value;
                    break;
                case "time_hrs_end":
                    this.time_hrs_end = (TextField)value;
                    break;
                case "time_mns_end":
                    this.time_mns_end = (TextField)value;
                    break;
                case "allday":
                    this.allday = (IntegerField)value;
                    break;
                case "event_date":
                    this.event_date = (DateField)value;
                    break;
                case "RepeatEvent":
                    this.RepeatEvent = (IntegerField)value;
                    break;
                case "RepeatNum":
                    this.RepeatNum = (TextField)value;
                    break;
                case "RepeatType":
                    this.RepeatType = (TextField)value;
                    break;
                case "event_todate":
                    this.event_todate = (DateField)value;
                    break;
                case "event_is_public":
                    this.event_is_public = (IntegerField)value;
                    break;
                case "user_id":
                    this.user_id = (IntegerField)value;
                    break;
                case "event_time":
                    this.event_time = (DateField)value;
                    break;
                case "event_time_end":
                    this.event_time_end = (DateField)value;
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
                case "event_URL":
                    this.event_URL = (TextField)value;
                    break;
                case "LabelTextBox1":
                    this.LabelTextBox1 = (TextField)value;
                    break;
                case "TextBox1":
                    this.TextBox1 = (TextField)value;
                    break;
                case "LabelTextBox2":
                    this.LabelTextBox2 = (TextField)value;
                    break;
                case "TextBox2":
                    this.TextBox2 = (TextField)value;
                    break;
                case "LabelTextBox3":
                    this.LabelTextBox3 = (TextField)value;
                    break;
                case "TextBox3":
                    this.TextBox3 = (TextField)value;
                    break;
                case "LabelTextArea1":
                    this.LabelTextArea1 = (TextField)value;
                    break;
                case "TextArea1":
                    this.TextArea1 = (TextField)value;
                    break;
                case "LabelTextArea2":
                    this.LabelTextArea2 = (TextField)value;
                    break;
                case "TextArea2":
                    this.TextArea2 = (TextField)value;
                    break;
                case "LabelTextArea3":
                    this.LabelTextArea3 = (TextField)value;
                    break;
                case "TextArea3":
                    this.TextArea3 = (TextField)value;
                    break;
                case "LabelCheckBox1":
                    this.LabelCheckBox1 = (TextField)value;
                    break;
                case "CheckBox1":
                    this.CheckBox1 = (IntegerField)value;
                    break;
                case "LabelCheckBox2":
                    this.LabelCheckBox2 = (TextField)value;
                    break;
                case "CheckBox2":
                    this.CheckBox2 = (IntegerField)value;
                    break;
                case "LabelCheckBox3":
                    this.LabelCheckBox3 = (TextField)value;
                    break;
                case "CheckBox3":
                    this.CheckBox3 = (IntegerField)value;
                    break;
                case "RecurrentApply":
                    this.RecurrentApply = (IntegerField)value;
                    break;
                case "event_parent_id":
                    this.event_parent_id = (TextField)value;
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

    public void Validate(events_recDataProvider provider)
    {
//End Record events_rec Item Class

//event_title validate @11-5C9BBF28
        if(event_title.Value==null||event_title.Value.ToString()=="")
            errors.Add("event_title",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.event_title));
//End event_title validate

//event_date validate @13-73702FB6
        if(event_date.Value==null||event_date.Value.ToString()=="")
            errors.Add("event_date",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.event_date));
//End event_date validate

//Record events_rec Event OnValidate. Action Custom Code @93-2A29BDB7
    // -------------------------
	if (RepeatEvent.GetFormattedValue() == "1") {
		if (RepeatNum.GetFormattedValue().Length == 0)
            errors.Add("RepeatNum",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"),((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("Every")));
		if (event_todate.GetFormattedValue().Length == 0)
            errors.Add("event_todate",String.Format(((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("CCS_RequiredField"),((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("End_By")));
	}
    // -------------------------
//End Record events_rec Event OnValidate. Action Custom Code

//Record events_rec Item Class tail @5-F5FC18C5
    }
}
//End Record events_rec Item Class tail

//Record events_rec Data Provider Class @5-4D280C08
public class events_recDataProvider:RecordDataProviderBase
{
//End Record events_rec Data Provider Class

//Record events_rec Data Provider Class Variables @5-0077E8C1
    protected DataCommand category_idDataCommand;
    protected events_recItem item;
    public IntegerParameter Urlevent_id;
    public TextParameter Seslocale;
//End Record events_rec Data Provider Class Variables

//Record events_rec Data Provider Class Constructor @5-C82A344A
    public events_recDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  * \n" +
          "FROM events {SQL_Where} {SQL_OrderBy}", new string[]{"event_id9"},Settings.calendarDataAccessObject);
         Delete=new TableCommand("DELETE FROM events", new string[]{"event_id9"},Settings.calendarDataAccessObject);
         category_idDataCommand=new TableCommand("SELECT category_id, \n" +
          "category_name \n" +
          "FROM categories_langs {SQL_Where} {SQL_OrderBy}", new string[]{"locale71"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record events_rec Data Provider Class Constructor

//Record events_rec Data Provider Class LoadParams Method @5-19EAA614
    protected bool LoadParams()
    {
        return Urlevent_id!=null;
    }
//End Record events_rec Data Provider Class LoadParams Method

//Record events_rec Data Provider Class CheckUnique Method @5-BA0A8829
    public bool CheckUnique(string ControlName,events_recItem item)
    {
        return true;
    }
//End Record events_rec Data Provider Class CheckUnique Method

//Record events_rec Data Provider Class PrepareInsert Method @5-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record events_rec Data Provider Class PrepareInsert Method

//Record events_rec Data Provider Class PrepareInsert Method tail @5-FCB6E20C
    }
//End Record events_rec Data Provider Class PrepareInsert Method tail

//Record events_rec Data Provider Class Insert Method @5-4EFC1999
    public int InsertItem(events_recItem item)
    {
        this.item = item;
         Insert=new TableCommand("INSERT INTO events({Fields}) VALUES ({Values})", new string[0],Settings.calendarDataAccessObject);
//End Record events_rec Data Provider Class Insert Method

//Record events_rec Build insert @5-4D2D6A91
		string fieldsList = "";
		string valuesList = "";
		
        Insert.Parameters.Clear();
        fieldsList += "category_id,";
        valuesList += Insert.Dao.ToSql(item.category_id.GetFormattedValue(""),FieldType.Integer)+",";
        fieldsList += "event_title,";
        valuesList += Insert.Dao.ToSql(item.event_title.GetFormattedValue(""),FieldType.Text)+",";
        fieldsList += "event_desc,";
        valuesList += Insert.Dao.ToSql(item.event_desc.GetFormattedValue(""),FieldType.Memo)+",";
        fieldsList += "event_date,";
        valuesList += Insert.Dao.ToSql(item.event_date.GetFormattedValue("yyyy-MM-dd"),FieldType.Date)+",";
        fieldsList += "event_is_public,";
        valuesList += Insert.Dao.ToSql(item.event_is_public.GetFormattedValue(""),FieldType.Integer)+",";
        fieldsList += "user_id,";
        valuesList += Insert.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer)+",";
        fieldsList += "event_time,";
        valuesList += Insert.Dao.ToSql(item.event_time.GetFormattedValue("HH\\:mm\\:ss"),FieldType.Date)+",";
        fieldsList += "event_time_end,";
        valuesList += Insert.Dao.ToSql(item.event_time_end.GetFormattedValue("HH\\:mm\\:ss"),FieldType.Date)+",";
        if(!item.event_location.IsEmpty){
        fieldsList += "event_location,";
        valuesList += Insert.Dao.ToSql(item.event_location.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.event_cost.IsEmpty){
        fieldsList += "event_cost,";
        valuesList += Insert.Dao.ToSql(item.event_cost.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.event_URL.IsEmpty){
        fieldsList += "event_url,";
        valuesList += Insert.Dao.ToSql(item.event_URL.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextBox1.IsEmpty){
        fieldsList += "custom_TextBox1,";
        valuesList += Insert.Dao.ToSql(item.TextBox1.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextBox2.IsEmpty){
        fieldsList += "custom_TextBox2,";
        valuesList += Insert.Dao.ToSql(item.TextBox2.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextBox3.IsEmpty){
        fieldsList += "custom_TextBox3,";
        valuesList += Insert.Dao.ToSql(item.TextBox3.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextArea1.IsEmpty){
        fieldsList += "custom_TextArea1,";
        valuesList += Insert.Dao.ToSql(item.TextArea1.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextArea2.IsEmpty){
        fieldsList += "custom_TextArea2,";
        valuesList += Insert.Dao.ToSql(item.TextArea2.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextArea3.IsEmpty){
        fieldsList += "custom_TextArea3,";
        valuesList += Insert.Dao.ToSql(item.TextArea3.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.CheckBox1.IsEmpty){
        fieldsList += "custom_CheckBox1,";
        valuesList += Insert.Dao.ToSql(item.CheckBox1.GetFormattedValue(""),FieldType.Integer)+",";
        }
        if(!item.CheckBox2.IsEmpty){
        fieldsList += "custom_CheckBox2,";
        valuesList += Insert.Dao.ToSql(item.CheckBox2.GetFormattedValue(""),FieldType.Integer)+",";
        }
        if(!item.CheckBox3.IsEmpty){
        fieldsList += "custom_CheckBox3,";
        valuesList += Insert.Dao.ToSql(item.CheckBox3.GetFormattedValue(""),FieldType.Integer)+",";
        }
        if(!item.event_parent_id.IsEmpty){
        fieldsList += "event_parent_id,";
        valuesList += Insert.Dao.ToSql(item.event_parent_id.GetFormattedValue(""),FieldType.Text)+",";
        }
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(','));
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(','));
		
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record events_rec Build insert

//Record events_rec Event AfterExecuteInsert. Action Custom Code @92-2A29BDB7
    // -------------------------
	if (item.RepeatEvent.GetFormattedValue() == "1") {
		DataAccessObject Conn =	Settings.calendarDataAccessObject;
		string SQL = "";
		DataRowCollection dr = Conn.RunSql("SELECT MAX(event_id) as m FROM events").Tables[0].Rows;

		string EventID = dr[0]["m"].ToString();

		SQL = "SELECT * FROM events WHERE event_id = " + EventID;
		dr = Conn.RunSql(SQL).Tables[0].Rows;

		SQL = "INSERT INTO events (event_parent_id, event_date ";
		string SQL_end = ") VALUES (" + EventID + ",  {date}";

		string[] FieldsArr = new string[] {"user_id", "category_id", "event_title", "event_desc", "event_time", "event_time_end", "event_date_add", 
										  "event_user_add", "event_is_public", "event_location", "event_cost", "event_url", "custom_TextBox1", 
										  "custom_TextBox2", "custom_TextBox3", "custom_TextArea1", "custom_TextArea2", "custom_TextArea3", 
										  "custom_CheckBox1", "custom_CheckBox2", "custom_CheckBox3"};

		FieldType[] FieldsType = new FieldType[] {FieldType.Integer, FieldType.Integer, FieldType.Text, FieldType.Text, FieldType.Date, FieldType.Date, FieldType.Date, 
											FieldType.Date, FieldType.Integer, FieldType.Text, FieldType.Text, FieldType.Text, FieldType.Text, 
											FieldType.Text, FieldType.Text, FieldType.Text, FieldType.Text, FieldType.Text, 
											FieldType.Integer, FieldType.Integer, FieldType.Integer};

		for (int i=0; i<FieldsArr.Length; i++) 
			if (dr[0][FieldsArr[i]] != null && dr[0][FieldsArr[i]].ToString().Length>0) {
				SQL = SQL + ", " + FieldsArr[i];
				SQL_end = SQL_end + ", " + Conn.ToSql(dr[0][FieldsArr[i]].ToString(), FieldsType[i]);
			}
		SQL = SQL + SQL_end + ")";

		int RepeatNum = Convert.ToInt32(item.RepeatNum.GetFormattedValue());
		DateTime DateStart = (DateTime)item.event_date.Value;
		int RepeatType = Convert.ToInt32(item.RepeatType.GetFormattedValue());

		DateTime DateFinish = (DateTime)item.event_todate.Value;
		if (RepeatType == 30) {
			DateStart = DateStart.AddMonths(RepeatNum);
			while (!(DateStart > DateFinish)) {
				Conn.RunSql(SQL.Replace("{date}", Conn.ToSql(DateStart.ToString(Conn.DateFormat), FieldType.Date)));
				DateStart = DateStart.AddMonths(RepeatNum);
			}
		} else {
			switch (RepeatType) {
				case 8 : RepeatNum = RepeatNum*7; break;
				case 1 : case 2 : case 3 : case 4 : case 5 : case 6 : case 7 :
					DateStart = DateStart.AddDays(RepeatType - (int)DateStart.DayOfWeek + (RepeatType <= (int)DateStart.DayOfWeek? 7 : 0) -1 - RepeatNum*7);
					RepeatNum = RepeatNum*7; break;
			}
			DateStart = DateStart.AddDays(RepeatNum);
			while (!(DateStart > DateFinish)) {
				Conn.RunSql(SQL.Replace("{date}", Conn.ToSql(DateStart.ToString(Conn.DateFormat), FieldType.Date)));
				DateStart = DateStart.AddDays(RepeatNum);
			}
		}
	}
	System.Web.HttpContext.Current.Session["category"] = "";

	string ret_link = CommonFunctions.CCGetFromGet("ret_link", "");
	if (ret_link.Length > 0) {
		string Redirect = "";
		if (ret_link.IndexOf("index.aspx") > 0) {
			Redirect = "index.aspx?cal_monthDate=" + CommonFunctions.CCFormatDate((DateTime)item.event_date.Value, "yyyy-MM");
		} else {
			ret_link = ret_link.Substring(ret_link.IndexOf("/"), ret_link.Length);
			if (ret_link.IndexOf("?") > 0)
				ret_link = ret_link.Substring(0, ret_link.IndexOf("?"));
			Redirect = ret_link + "?day=" + CommonFunctions.CCFormatDate((DateTime)item.event_date.Value, "yyyy-MM-dd");
		}
		System.Web.HttpContext.Current.Response.Redirect(Redirect);
	}
// -------------------------
//End Record events_rec Event AfterExecuteInsert. Action Custom Code

//Record events_rec AfterExecuteInsert @5-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record events_rec AfterExecuteInsert

//Record events_rec Data Provider Class PrepareUpdate Method @5-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record events_rec Data Provider Class PrepareUpdate Method

//Record events_rec Data Provider Class PrepareUpdate Method tail @5-FCB6E20C
    }
//End Record events_rec Data Provider Class PrepareUpdate Method tail

//Record events_rec Data Provider Class Update Method @5-1FEB06A7
    public int UpdateItem(events_recItem item)
    {
        this.item = item;
         Update=new TableCommand("UPDATE events SET {Values}", new string[]{"event_id9"},Settings.calendarDataAccessObject);
//End Record events_rec Data Provider Class Update Method

//Record events_rec BeforeBuildUpdate @5-7F5D15E4
		string valuesList = "";
		
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("event_id9",Urlevent_id, "","event_id",Condition.Equal,false);
        valuesList += "category_id=" + Update.Dao.ToSql(item.category_id.GetFormattedValue(""),FieldType.Integer)+",";
        valuesList += "event_title=" + Update.Dao.ToSql(item.event_title.GetFormattedValue(""),FieldType.Text)+",";
        valuesList += "event_desc=" + Update.Dao.ToSql(item.event_desc.GetFormattedValue(""),FieldType.Memo)+",";
        valuesList += "event_date=" + Update.Dao.ToSql(item.event_date.GetFormattedValue("yyyy-MM-dd"),FieldType.Date)+",";
        valuesList += "event_is_public=" + Update.Dao.ToSql(item.event_is_public.GetFormattedValue(""),FieldType.Integer)+",";
        valuesList += "user_id=" + Update.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer)+",";
        valuesList += "event_time=" + Update.Dao.ToSql(item.event_time.GetFormattedValue("HH\\:mm\\:ss"),FieldType.Date)+",";
        valuesList += "event_time_end=" + Update.Dao.ToSql(item.event_time_end.GetFormattedValue("HH\\:mm\\:ss"),FieldType.Date)+",";
        if(!item.event_location.IsEmpty){
        valuesList += "event_location=" + Update.Dao.ToSql(item.event_location.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.event_cost.IsEmpty){
        valuesList += "event_cost=" + Update.Dao.ToSql(item.event_cost.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.event_URL.IsEmpty){
        valuesList += "event_url=" + Update.Dao.ToSql(item.event_URL.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextBox1.IsEmpty){
        valuesList += "custom_TextBox1=" + Update.Dao.ToSql(item.TextBox1.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextBox2.IsEmpty){
        valuesList += "custom_TextBox2=" + Update.Dao.ToSql(item.TextBox2.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextBox3.IsEmpty){
        valuesList += "custom_TextBox3=" + Update.Dao.ToSql(item.TextBox3.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextArea1.IsEmpty){
        valuesList += "custom_TextArea1=" + Update.Dao.ToSql(item.TextArea1.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextArea2.IsEmpty){
        valuesList += "custom_TextArea2=" + Update.Dao.ToSql(item.TextArea2.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.TextArea3.IsEmpty){
        valuesList += "custom_TextArea3=" + Update.Dao.ToSql(item.TextArea3.GetFormattedValue(""),FieldType.Text)+",";
        }
        if(!item.CheckBox1.IsEmpty){
        valuesList += "custom_CheckBox1=" + Update.Dao.ToSql(item.CheckBox1.GetFormattedValue(""),FieldType.Integer)+",";
        }
        if(!item.CheckBox2.IsEmpty){
        valuesList += "custom_CheckBox2=" + Update.Dao.ToSql(item.CheckBox2.GetFormattedValue(""),FieldType.Integer)+",";
        }
        if(!item.CheckBox3.IsEmpty){
        valuesList += "custom_CheckBox3=" + Update.Dao.ToSql(item.CheckBox3.GetFormattedValue(""),FieldType.Integer)+",";
        }
        if(!item.event_parent_id.IsEmpty){
        valuesList += "event_parent_id=" + Update.Dao.ToSql(item.event_parent_id.GetFormattedValue(""),FieldType.Text)+",";
        }
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(','));
		
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record events_rec BeforeBuildUpdate

//Record events_rec Event AfterExecuteUpdate. Action Custom Code @99-2A29BDB7
    // -------------------------
			if (item.RecurrentApply.GetFormattedValue() == "1") {
				string EventId = CommonFunctions.CCGetFromGet("event_id", "");
				string SQL = "SELECT * FROM events WHERE event_id = " + EventId;
				DataRowCollection dr = Settings.calendarDataAccessObject.RunSql(SQL).Tables[0].Rows;

				if (item.event_parent_id.GetFormattedValue().Length > 0) 
					EventId = item.event_parent_id.GetFormattedValue();

				SQL = "UPDATE events SET ";

				string[] FieldsArr = new string[] {"user_id", "category_id", "event_title", "event_desc", "event_time", "event_time_end", "event_date_add", 
													  "event_user_add", "event_is_public", "event_location", "event_cost", "event_url", "custom_TextBox1", 
													  "custom_TextBox2", "custom_TextBox3", "custom_TextArea1", "custom_TextArea2", "custom_TextArea3", 
													  "custom_CheckBox1", "custom_CheckBox2", "custom_CheckBox3"};

				FieldType[] FieldsType = new FieldType[] {FieldType.Integer, FieldType.Integer, FieldType.Text, FieldType.Text, FieldType.Date, FieldType.Date, FieldType.Date,
											FieldType.Date, FieldType.Integer, FieldType.Text, FieldType.Text, FieldType.Text, FieldType.Text,
											FieldType.Text, FieldType.Text, FieldType.Text, FieldType.Text, FieldType.Text,
											FieldType.Integer, FieldType.Integer, FieldType.Integer};

				for (int i=0; i<FieldsArr.Length; i++) 
	//				if (dr[0][FieldsArr[i]] != null && dr[0][FieldsArr[i]].ToString().Length>0) 
					{
						SQL = SQL + FieldsArr[i] + " = " + Settings.calendarDataAccessObject.ToSql(dr[0][FieldsArr[i]].ToString(), FieldsType[i]) + ", ";
					}

				SQL = SQL.Substring(0, SQL.Length - 2) + " WHERE event_id = " + EventId + " OR event_parent_id = " + EventId;
				Settings.calendarDataAccessObject.RunSql(SQL);
			}

			System.Web.HttpContext.Current.Session["category"] = "";

			string ret_link = CommonFunctions.CCGetFromGet("ret_link", "");

			if (ret_link.Length > 0) {
//				ret_link = ret_link.Substring(ret_link.IndexOf("/"), ret_link.Length);
				if (ret_link.IndexOf("?") > 0)
					ret_link = ret_link.Substring(0, ret_link.IndexOf("?"));
				string Redirect = "";

				switch (ret_link.ToLower()) {
					case "index.aspx" :	Redirect = "index.aspx?cal_monthDate=" + CommonFunctions.CCFormatDate((DateTime)item.event_date.Value, "yyyy-MM"); break;
					case "day.aspx": case "week.aspx": Redirect = ret_link + "?day=" + CommonFunctions.CCFormatDate((DateTime)item.event_date.Value, "yyyy-MM-dd"); break;
					default : Redirect = CommonFunctions.CCGetFromGet("ret_link", ""); break;
				}
				System.Web.HttpContext.Current.Response.Redirect(Redirect);
			}
    // -------------------------
//End Record events_rec Event AfterExecuteUpdate. Action Custom Code

//Record events_rec AfterExecuteUpdate @5-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record events_rec AfterExecuteUpdate

//Record events_rec Data Provider Class PrepareDelete Method @5-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record events_rec Data Provider Class PrepareDelete Method

//Record events_rec Data Provider Class PrepareDelete Method tail @5-FCB6E20C
    }
//End Record events_rec Data Provider Class PrepareDelete Method tail

//Record events_rec Data Provider Class Delete Method @5-7917A33D
    public int DeleteItem(events_recItem item)
    {
        this.item = item;
//End Record events_rec Data Provider Class Delete Method

//Record events_rec BeforeBuildDelete @5-69FBB563
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("event_id9",Urlevent_id, "","event_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{category_id}",Delete.Dao.ToSql(item.category_id.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{event_title}",Delete.Dao.ToSql(item.event_title.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{event_desc}",Delete.Dao.ToSql(item.event_desc.GetFormattedValue(""),FieldType.Memo));
        Delete.SqlQuery.Replace("{event_date}",Delete.Dao.ToSql(item.event_date.GetFormattedValue("yyyy-MM-dd"),FieldType.Date));
        Delete.SqlQuery.Replace("{event_is_public}",Delete.Dao.ToSql(item.event_is_public.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{user_id}",Delete.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{event_time}",Delete.Dao.ToSql(item.event_time.GetFormattedValue("HH\\:mm\\:ss"),FieldType.Date));
        Delete.SqlQuery.Replace("{event_time_end}",Delete.Dao.ToSql(item.event_time_end.GetFormattedValue("HH\\:mm\\:ss"),FieldType.Date));
        Delete.SqlQuery.Replace("{event_location}",Delete.Dao.ToSql(item.event_location.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{event_cost}",Delete.Dao.ToSql(item.event_cost.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{event_URL}",Delete.Dao.ToSql(item.event_URL.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{TextBox1}",Delete.Dao.ToSql(item.TextBox1.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{TextBox2}",Delete.Dao.ToSql(item.TextBox2.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{TextBox3}",Delete.Dao.ToSql(item.TextBox3.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{TextArea1}",Delete.Dao.ToSql(item.TextArea1.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{TextArea2}",Delete.Dao.ToSql(item.TextArea2.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{TextArea3}",Delete.Dao.ToSql(item.TextArea3.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{CheckBox1}",Delete.Dao.ToSql(item.CheckBox1.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{CheckBox2}",Delete.Dao.ToSql(item.CheckBox2.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{CheckBox3}",Delete.Dao.ToSql(item.CheckBox3.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{event_parent_id}",Delete.Dao.ToSql(item.event_parent_id.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record events_rec BeforeBuildDelete

//Record events_rec Event AfterExecuteDelete. Action Custom Code @100-2A29BDB7
    // -------------------------
			if (item.RecurrentApply.GetFormattedValue() == "1") 
			{
				string EventId = "";
				if (item.event_parent_id.GetFormattedValue().Length > 0)
					EventId = item.event_parent_id.GetFormattedValue();
				else
					EventId = CommonFunctions.CCGetFromGet("event_id", "");
				string SQL = "DELETE FROM events WHERE event_id = " + EventId + " OR event_parent_id = " + EventId;
				Settings.calendarDataAccessObject.RunSql(SQL);
			}

		string ret_link = CommonFunctions.CCGetFromGet("ret_link", "");
		if (ret_link.Length > 0)
			System.Web.HttpContext.Current.Response.Redirect(ret_link);
    // -------------------------
//End Record events_rec Event AfterExecuteDelete. Action Custom Code

//Record events_rec BeforeBuildDelete @5-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record events_rec BeforeBuildDelete

//Record events_rec Data Provider Class GetResultSet Method @5-77A9DB7F
    public void FillItem(events_recItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record events_rec Data Provider Class GetResultSet Method

//Record events_rec BeforeBuildSelect @5-CEE26482
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("event_id9",Urlevent_id, "","event_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record events_rec BeforeBuildSelect

//Record events_rec BeforeExecuteSelect @5-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record events_rec BeforeExecuteSelect

//Record events_rec AfterExecuteSelect @5-DDFBA619
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.category_id.SetValue(dr[i]["category_id"],"");
            item.event_title.SetValue(dr[i]["event_title"],"");
            item.event_desc.SetValue(dr[i]["event_desc"],"");
            item.event_date.SetValue(dr[i]["event_date"],"yyyy-MM-dd");
            item.event_is_public.SetValue(dr[i]["event_is_public"],"");
            item.user_id.SetValue(dr[i]["user_id"],"");
            item.event_time.SetValue(dr[i]["event_time"],"HH\\:mm\\:ss");
            item.event_time_end.SetValue(dr[i]["event_time_end"],"HH\\:mm\\:ss");
            item.event_location.SetValue(dr[i]["event_location"],"");
            item.event_cost.SetValue(dr[i]["event_cost"],"");
            item.event_URL.SetValue(dr[i]["event_url"],"");
            item.TextBox1.SetValue(dr[i]["custom_TextBox1"],"");
            item.TextBox2.SetValue(dr[i]["custom_TextBox2"],"");
            item.TextBox3.SetValue(dr[i]["custom_TextBox3"],"");
            item.TextArea1.SetValue(dr[i]["custom_TextArea1"],"");
            item.TextArea2.SetValue(dr[i]["custom_TextArea2"],"");
            item.TextArea3.SetValue(dr[i]["custom_TextArea3"],"");
            item.CheckBox1.SetValue(dr[i]["custom_CheckBox1"],"");
            item.CheckBox2.SetValue(dr[i]["custom_CheckBox2"],"");
            item.CheckBox3.SetValue(dr[i]["custom_CheckBox3"],"");
            item.event_parent_id.SetValue(dr[i]["event_parent_id"],"");
        }
        else
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record events_rec AfterExecuteSelect

//ListBox category_id Initialize Data Source @10-0B860B9C
        int category_idtableIndex = 0;
        category_idDataCommand.OrderBy = "";
        category_idDataCommand.Parameters.Clear();
        ((TableCommand)category_idDataCommand).AddParameter("locale71",Seslocale, "","language_id",Condition.Equal,false);
//End ListBox category_id Initialize Data Source

//ListBox category_id BeforeExecuteSelect @10-8E4BDFF2
        try{
            ListBoxSource=category_idDataCommand.Execute().Tables[category_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox category_id BeforeExecuteSelect

//ListBox category_id AfterExecuteSelect @10-39CCB61F
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["category_name"];
            string key = (new IntegerField("", ListBoxSource[li]["category_id"])).GetFormattedValue("");
            item.category_idItems.Add(key,val);
        }
//End ListBox category_id AfterExecuteSelect

//ListBox event_time_hrs AfterExecuteSelect @25-F49159E0
        
item.event_time_hrsItems.Add("00","12 AM");
item.event_time_hrsItems.Add("01","01 AM");
item.event_time_hrsItems.Add("02","02 AM");
item.event_time_hrsItems.Add("03","03 AM");
item.event_time_hrsItems.Add("04","04 AM");
item.event_time_hrsItems.Add("05","05 AM");
item.event_time_hrsItems.Add("06","06 AM");
item.event_time_hrsItems.Add("07","07 AM");
item.event_time_hrsItems.Add("08","08 AM");
item.event_time_hrsItems.Add("09","09 AM");
item.event_time_hrsItems.Add("10","10 AM");
item.event_time_hrsItems.Add("11","11 AM");
item.event_time_hrsItems.Add("12","12 PM");
item.event_time_hrsItems.Add("13","01 PM");
item.event_time_hrsItems.Add("14","02 PM");
item.event_time_hrsItems.Add("15","03 PM");
item.event_time_hrsItems.Add("16","04 PM");
item.event_time_hrsItems.Add("17","05 PM");
item.event_time_hrsItems.Add("18","06 PM");
item.event_time_hrsItems.Add("19","07 PM");
item.event_time_hrsItems.Add("20","08 PM");
item.event_time_hrsItems.Add("21","09 PM");
item.event_time_hrsItems.Add("22","10 PM");
item.event_time_hrsItems.Add("23","11 PM");
//End ListBox event_time_hrs AfterExecuteSelect

//ListBox event_time_mns AfterExecuteSelect @26-8DA1AAC0
        
item.event_time_mnsItems.Add("00","00");
item.event_time_mnsItems.Add("05","05");
item.event_time_mnsItems.Add("10","10");
item.event_time_mnsItems.Add("15","15");
item.event_time_mnsItems.Add("20","20");
item.event_time_mnsItems.Add("25","25");
item.event_time_mnsItems.Add("30","30");
item.event_time_mnsItems.Add("35","35");
item.event_time_mnsItems.Add("40","40");
item.event_time_mnsItems.Add("45","45");
item.event_time_mnsItems.Add("50","50");
item.event_time_mnsItems.Add("55","55");
//End ListBox event_time_mns AfterExecuteSelect

//ListBox time_hrs_end AfterExecuteSelect @27-06D57988
        
item.time_hrs_endItems.Add("00","12 AM");
item.time_hrs_endItems.Add("01","01 AM");
item.time_hrs_endItems.Add("02","02 AM");
item.time_hrs_endItems.Add("03","03 AM");
item.time_hrs_endItems.Add("04","04 AM");
item.time_hrs_endItems.Add("05","05 AM");
item.time_hrs_endItems.Add("06","06 AM");
item.time_hrs_endItems.Add("07","07 AM");
item.time_hrs_endItems.Add("08","08 AM");
item.time_hrs_endItems.Add("09","09 AM");
item.time_hrs_endItems.Add("10","10 AM");
item.time_hrs_endItems.Add("11","11 AM");
item.time_hrs_endItems.Add("12","12 PM");
item.time_hrs_endItems.Add("13","01 PM");
item.time_hrs_endItems.Add("14","02 PM");
item.time_hrs_endItems.Add("15","03 PM");
item.time_hrs_endItems.Add("16","04 PM");
item.time_hrs_endItems.Add("17","05 PM");
item.time_hrs_endItems.Add("18","06 PM");
item.time_hrs_endItems.Add("19","07 PM");
item.time_hrs_endItems.Add("20","08 PM");
item.time_hrs_endItems.Add("21","09 PM");
item.time_hrs_endItems.Add("22","10 PM");
item.time_hrs_endItems.Add("23","11 PM");
//End ListBox time_hrs_end AfterExecuteSelect

//ListBox time_mns_end AfterExecuteSelect @28-276F52A6
        
item.time_mns_endItems.Add("00","00");
item.time_mns_endItems.Add("05","05");
item.time_mns_endItems.Add("10","10");
item.time_mns_endItems.Add("15","15");
item.time_mns_endItems.Add("20","20");
item.time_mns_endItems.Add("25","25");
item.time_mns_endItems.Add("30","30");
item.time_mns_endItems.Add("35","35");
item.time_mns_endItems.Add("40","40");
item.time_mns_endItems.Add("45","45");
item.time_mns_endItems.Add("50","50");
item.time_mns_endItems.Add("55","55");
//End ListBox time_mns_end AfterExecuteSelect

//ListBox RepeatType AfterExecuteSelect @90-7A8507EB
        
item.RepeatTypeItems.Add("0","Day");
item.RepeatTypeItems.Add("8","Week");
item.RepeatTypeItems.Add("30","Month");
item.RepeatTypeItems.Add("1","Sunday");
item.RepeatTypeItems.Add("2","Monday");
item.RepeatTypeItems.Add("3","Tuesday");
item.RepeatTypeItems.Add("4","Wednesday");
item.RepeatTypeItems.Add("5","Thursday");
item.RepeatTypeItems.Add("6","Friday");
item.RepeatTypeItems.Add("7","Saturday");
//End ListBox RepeatType AfterExecuteSelect

//Record events_rec AfterExecuteSelect tail @5-FCB6E20C
    }
//End Record events_rec AfterExecuteSelect tail

//Record events_rec Data Provider Class @5-FCB6E20C
}

//End Record events_rec Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

