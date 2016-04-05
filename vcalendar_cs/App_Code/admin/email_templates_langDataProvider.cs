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

namespace calendar.admin.email_templates_lang{ //Namespace @1-AB2AC7A2

//Page Data Class @1-08CF7C9A
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.JavaScriptLabel.SetValue(DBUtility.GetInitialValue("JavaScriptLabel"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "JavaScriptLabel":
                    return this.JavaScriptLabel;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "JavaScriptLabel":
                    this.JavaScriptLabel = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField JavaScriptLabel;
    public PageItem()
    {
        JavaScriptLabel=new TextField("", null);
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

//EditableGrid email_templates_lang Item Class @29-CB385F47
public class email_templates_langItem
{
    public int RowId;
    private bool _deleteAllowed = false;
    private bool _isNew = false;
    public TextField languageLabel;
    public TextField language_id;
    public TextField email_template_desc;
    public TextField email_template_subject;
    public MemoField email_template_body;
    public NameValueCollection errors=new NameValueCollection();
    public email_templates_langItem()
    {
        languageLabel=new TextField("", null);
        language_id=new TextField("", null);
        email_template_desc=new TextField("", null);
        email_template_subject=new TextField("", null);
        email_template_body=new MemoField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "email_template_lang_idField":
                    return this.email_template_lang_idField;
                case "languageLabel":
                    return this.languageLabel;
                case "language_id":
                    return this.language_id;
                case "email_template_desc":
                    return this.email_template_desc;
                case "email_template_subject":
                    return this.email_template_subject;
                case "email_template_body":
                    return this.email_template_body;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "email_template_lang_idField":
                    this.email_template_lang_idField = (IntegerField)value;
                    break;
                case "languageLabel":
                    this.languageLabel = (TextField)value;
                    break;
                case "language_id":
                    this.language_id = (TextField)value;
                    break;
                case "email_template_desc":
                    this.email_template_desc = (TextField)value;
                    break;
                case "email_template_subject":
                    this.email_template_subject = (TextField)value;
                    break;
                case "email_template_body":
                    this.email_template_body = (MemoField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public bool IsDeleteAllowed{
        get{
            return !IsEmptyItem && _deleteAllowed;
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

    public bool IsEmptyItem{
        get{
            bool result = true;
            result = language_id.Value == null && result;
            result = email_template_desc.Value == null && result;
            result = email_template_subject.Value == null && result;
            result = email_template_body.Value == null && result;
            result = email_template_lang_idField.Value == null && result;
            return result;
        }
    }

    public bool IsDeleted = false;
    public bool IsUpdated = false;
    public IntegerField email_template_lang_idField=new IntegerField();
    public bool Validate(email_templates_langDataProvider provider)
    {
//End EditableGrid email_templates_lang Item Class

//email_template_subject validate @36-3CA2C938
        if(email_template_subject.Value==null||email_template_subject.Value.ToString()=="")
            errors.Add("email_template_subject",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.email_template_subject));
//End email_template_subject validate

//EditableGrid email_templates_lang Item Class tail @29-2CA8EF5C
        return errors.Count == 0;
    }
}
//End EditableGrid email_templates_lang Item Class tail

//EditableGrid email_templates_lang Data Provider Class Header @29-CBB7D642
public class email_templates_langDataProvider:EditableGridDataProviderBase
{
//End EditableGrid email_templates_lang Data Provider Class Header

//Grid email_templates_lang Data Provider Class Variables @29-2D28D3B6
    public enum SortFields {Default,Sorter_language_id}
    private string[] SortFieldsNames=new string[]{"","language_id"};
    private string[] SortFieldsNamesDesc=new string[]{"","language_id DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public IntegerParameter Urlemail_template_id;
//End Grid email_templates_lang Data Provider Class Variables

//Editable Grid email_templates_lang Data Provider Class Constructor @29-BC318590
    public email_templates_langDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  * \n" +
          "FROM email_templates_lang {SQL_Where} {SQL_OrderBy}", new string[]{"email_template_id43"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM email_templates_lang", new string[]{"email_template_id43"},Settings.calendarDataAccessObject);
    }
//End Editable Grid email_templates_lang Data Provider Class Constructor

//Editable Grid email_templates_lang Data Provider Class CheckUnique Method @29-53B6A508
    public bool CheckUnique(string ControlName,email_templates_langItem item)
    {
        return true;
    }
//End Editable Grid email_templates_lang Data Provider Class CheckUnique Method

//EditableGrid email_templates_lang Data Provider Class Update Method @29-FD745EA7
    protected int UpdateItem(email_templates_langItem item)
    {
        bool CmdExecution = true;
        bool IsParametersPassed = true;
        DataCommand Update=new TableCommand("UPDATE email_templates_lang SET language_id={language_id}, \n" +
          "email_template_desc={email_template_desc}, email_template_subject={email_template_subject}" +
          ", \n" +
          "email_template_body={email_template_body}", new string[]{"email_template_lang_id30"},Settings.calendarDataAccessObject);
//End EditableGrid email_templates_lang Data Provider Class Update Method

//EditableGrid email_templates_lang BeforeBuildUpdate @29-B9D40643
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("email_template_id43",Urlemail_template_id, "","email_template_id",Condition.Equal,true);
        Update.SqlQuery.Replace("{language_id}",Update.Dao.ToSql(item.language_id.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{email_template_desc}",Update.Dao.ToSql(item.email_template_desc.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{email_template_subject}",Update.Dao.ToSql(item.email_template_subject.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{email_template_body}",Update.Dao.ToSql(item.email_template_body.GetFormattedValue(""),FieldType.Memo));
        Update.Parameters.Add("email_template_lang_id30","email_template_lang_id = " + Update.Dao.ToSql(item.email_template_lang_idField.GetFormattedValue(""),FieldType.Integer));
//End EditableGrid email_templates_lang BeforeBuildUpdate

//EditableGrid email_templates_lang Execute Update  @29-D761E721
        object result=0;
        if (CmdExecution)
        {
            if(!IsParametersPassed){
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters);
                return 0;
            }
            try{
                result=Update.ExecuteNonQuery();
            }catch(Exception e){
                item.errors.Add("DataProvider",e.Source + ":" + e.Message);
                }
            finally{
//End EditableGrid email_templates_lang Execute Update 

//EditableGrid email_templates_lang Event AfterExecuteUpdate. Action Custom Code @40-2A29BDB7
    // -------------------------
				if ((string)item.language_id.Value == CommonFunctions.str_calendar_config("default_language"))
				{
					DataAccessObject Conn =	Settings.calendarDataAccessObject;

					string SQL = "UPDATE email_templates " +
						"SET email_template_desc = " + Conn.ToSql((string)item.email_template_desc.Value, FieldType.Memo) +
						", email_template_subject = " + Conn.ToSql((string)item.email_template_subject.Value, FieldType.Text) +
						", email_template_body = " + Conn.ToSql((string)item.email_template_body.Value, FieldType.Text) +
						"WHERE email_template_id = " + Conn.ToSql(CommonFunctions.CCGetFromGet("email_template_id",""),FieldType.Integer);

					Conn.RunSql(SQL);
				}
    // -------------------------
//End EditableGrid email_templates_lang Event AfterExecuteUpdate. Action Custom Code

//EditableGrid email_templates_lang AfterExecuteUpdate @29-D87AB90B
            }
        }
        return (int)result;
    }
//End EditableGrid email_templates_lang AfterExecuteUpdate

//Grid email_templates_lang Data Provider Class Update Method @29-2B7267D4
    public void Update(ArrayList Items, FormSupportedOperations ops)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            EditableGridOperation op = EditableGridOperation.Insert;
            bool isProcessed = false;
            email_templates_langItem item = (email_templates_langItem)Items[i];
            if(item.IsUpdated) continue;
            if(!item.IsEmptyItem && ops.AllowUpdate && !isProcessed){
                UpdateItem(item);
                op = EditableGridOperation.Update;}
            if(item.errors.Count == 0) item.IsUpdated = true;
            OnItemUpdated(new ItemUpdatedEventArgs(op, item));
        }
    }
//End Grid email_templates_lang Data Provider Class Update Method

//Grid email_templates_lang Data Provider Class GetResultSet Method @29-7B6BCEA7
    public email_templates_langItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid email_templates_lang Data Provider Class GetResultSet Method

//Before build Select @29-685A940B
        _pagesCount = 0;
        Exception E=null;
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("email_template_id43",Urlemail_template_id, "","email_template_id",Condition.Equal,true);
        Count.Parameters = Select.Parameters;
        Select.OrderBy=(SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
//End Before build Select

//Execute Select @29-8A32B9CE
        DataRowCollection dr = null;
        DataSet ds = null;
        int rowCount = 0;
        if(ops.AllowRead){
            _pagesCount=0;
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

//After execute Select @29-5D2FD531
                if(E!=null) throw(E);
            }
            dr=ds.Tables[tableIndex].Rows;
            rowCount = dr.Count;
        }
        email_templates_langItem[] result=new email_templates_langItem[rowCount];
//End After execute Select

//After execute Select tail @29-D7C2B49E
        for(int i=0; i<rowCount ;i++)
        {
            email_templates_langItem item=new email_templates_langItem();
            item.languageLabel.SetValue(dr[i]["language_id"],"");
            item.language_id.SetValue(dr[i]["language_id"],"");
            item.email_template_desc.SetValue(dr[i]["email_template_desc"],"");
            item.email_template_subject.SetValue(dr[i]["email_template_subject"],"");
            item.email_template_body.SetValue(dr[i]["email_template_body"],"");
            item.email_template_lang_idField.SetValue(dr[i]["email_template_lang_id"],"");
            result[i]=item;
        }
        this.mPagesCount=_pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @29-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

