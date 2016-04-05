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

namespace calendar.admin.content_lang{ //Namespace @1-FE60DC11

//Page Data Class @1-8EDEBA03
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.JavaScriptLabel.SetValue(DBUtility.GetInitialValue("JavaScriptLabel"));
        item.close.SetValue(DBUtility.GetInitialValue("close"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "JavaScriptLabel":
                    return this.JavaScriptLabel;
                case "close":
                    return this.close;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "JavaScriptLabel":
                    this.JavaScriptLabel = (TextField)value;
                    break;
                case "close":
                    this.close = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField JavaScriptLabel;
    public TextField close;
    public PageItem()
    {
        JavaScriptLabel=new TextField("", null);
        close=new TextField("", null);
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

//EditableGrid contents_lang Item Class @29-E0D1FF2A
public class contents_langItem
{
    public int RowId;
    private bool _deleteAllowed = false;
    private bool _isNew = false;
    public TextField languageLabel;
    public TextField language_id;
    public TextField content_desc;
    public MemoField content_value;
    public NameValueCollection errors=new NameValueCollection();
    public contents_langItem()
    {
        languageLabel=new TextField("", null);
        language_id=new TextField("", null);
        content_desc=new TextField("", null);
        content_value=new MemoField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "content_lang_idField":
                    return this.content_lang_idField;
                case "languageLabel":
                    return this.languageLabel;
                case "language_id":
                    return this.language_id;
                case "content_desc":
                    return this.content_desc;
                case "content_value":
                    return this.content_value;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "content_lang_idField":
                    this.content_lang_idField = (IntegerField)value;
                    break;
                case "languageLabel":
                    this.languageLabel = (TextField)value;
                    break;
                case "language_id":
                    this.language_id = (TextField)value;
                    break;
                case "content_desc":
                    this.content_desc = (TextField)value;
                    break;
                case "content_value":
                    this.content_value = (MemoField)value;
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
            result = content_desc.Value == null && result;
            result = content_value.Value == null && result;
            result = content_lang_idField.Value == null && result;
            return result;
        }
    }

    public bool IsDeleted = false;
    public bool IsUpdated = false;
    public IntegerField content_lang_idField=new IntegerField();
    public bool Validate(contents_langDataProvider provider)
    {
//End EditableGrid contents_lang Item Class

//EditableGrid contents_lang Item Class tail @29-2CA8EF5C
        return errors.Count == 0;
    }
}
//End EditableGrid contents_lang Item Class tail

//EditableGrid contents_lang Data Provider Class Header @29-D782B74B
public class contents_langDataProvider:EditableGridDataProviderBase
{
//End EditableGrid contents_lang Data Provider Class Header

//Grid contents_lang Data Provider Class Variables @29-A165BB9F
    public enum SortFields {Default,Sorter_language_id}
    private string[] SortFieldsNames=new string[]{"","language_id"};
    private string[] SortFieldsNamesDesc=new string[]{"","language_id DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public IntegerParameter Urlcontent_id;
//End Grid contents_lang Data Provider Class Variables

//Editable Grid contents_lang Data Provider Class Constructor @29-6A9C9522
    public contents_langDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  * \n" +
          "FROM contents_langs {SQL_Where} {SQL_OrderBy}", new string[]{"content_id47"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM contents_langs", new string[]{"content_id47"},Settings.calendarDataAccessObject);
    }
//End Editable Grid contents_lang Data Provider Class Constructor

//Editable Grid contents_lang Data Provider Class CheckUnique Method @29-130F4AFB
    public bool CheckUnique(string ControlName,contents_langItem item)
    {
        return true;
    }
//End Editable Grid contents_lang Data Provider Class CheckUnique Method

//EditableGrid contents_lang Data Provider Class Update Method @29-52FF75CD
    protected int UpdateItem(contents_langItem item)
    {
        bool CmdExecution = true;
        bool IsParametersPassed = true;
        DataCommand Update=new TableCommand("UPDATE contents_langs SET language_id={language_id}, content_desc={content_desc}, \n" +
          "content_value={content_value}", new string[]{"content_lang_id48"},Settings.calendarDataAccessObject);
//End EditableGrid contents_lang Data Provider Class Update Method

//EditableGrid contents_lang BeforeBuildUpdate @29-0D6B2A6D
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("content_id47",Urlcontent_id, "","content_id",Condition.Equal,true);
        Update.SqlQuery.Replace("{language_id}",Update.Dao.ToSql(item.language_id.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{content_desc}",Update.Dao.ToSql(item.content_desc.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{content_value}",Update.Dao.ToSql(item.content_value.GetFormattedValue(""),FieldType.Memo));
        Update.Parameters.Add("content_lang_id48","content_lang_id = " + Update.Dao.ToSql(item.content_lang_idField.GetFormattedValue(""),FieldType.Integer));
//End EditableGrid contents_lang BeforeBuildUpdate

//EditableGrid contents_lang Execute Update  @29-D761E721
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
//End EditableGrid contents_lang Execute Update 

//EditableGrid contents_lang Event AfterExecuteUpdate. Action Custom Code @40-2A29BDB7
    // -------------------------
			if ((string)item.language_id.Value == CommonFunctions.str_calendar_config("default_language")) {
				DataAccessObject Conn =	Settings.calendarDataAccessObject;

				string SQL = "UPDATE contents " +
					"SET content_desc = " + Conn.ToSql((string)item.content_desc.Value, FieldType.Text) +
					", content_value = " + Conn.ToSql((string)item.content_value.Value, FieldType.Text) +
					" WHERE content_id = " + Conn.ToSql(CommonFunctions.CCGetFromGet("content_id",""), FieldType.Integer);

				Conn.RunSql(SQL);
			}
    // -------------------------
//End EditableGrid contents_lang Event AfterExecuteUpdate. Action Custom Code

//EditableGrid contents_lang AfterExecuteUpdate @29-D87AB90B
            }
        }
        return (int)result;
    }
//End EditableGrid contents_lang AfterExecuteUpdate

//Grid contents_lang Data Provider Class Update Method @29-47A91593
    public void Update(ArrayList Items, FormSupportedOperations ops)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            EditableGridOperation op = EditableGridOperation.Insert;
            bool isProcessed = false;
            contents_langItem item = (contents_langItem)Items[i];
            if(item.IsUpdated) continue;
            if(!item.IsEmptyItem && ops.AllowUpdate && !isProcessed){
                UpdateItem(item);
                op = EditableGridOperation.Update;}
            if(item.errors.Count == 0) item.IsUpdated = true;
            OnItemUpdated(new ItemUpdatedEventArgs(op, item));
        }
    }
//End Grid contents_lang Data Provider Class Update Method

//Grid contents_lang Data Provider Class GetResultSet Method @29-45F4363A
    public contents_langItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid contents_lang Data Provider Class GetResultSet Method

//Before build Select @29-D0F39714
        _pagesCount = 0;
        Exception E=null;
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("content_id47",Urlcontent_id, "","content_id",Condition.Equal,true);
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

//After execute Select @29-3780E6CD
                if(E!=null) throw(E);
            }
            dr=ds.Tables[tableIndex].Rows;
            rowCount = dr.Count;
        }
        contents_langItem[] result=new contents_langItem[rowCount];
//End After execute Select

//After execute Select tail @29-9F13EBE8
        for(int i=0; i<rowCount ;i++)
        {
            contents_langItem item=new contents_langItem();
            item.languageLabel.SetValue(dr[i]["language_id"],"");
            item.language_id.SetValue(dr[i]["language_id"],"");
            item.content_desc.SetValue(dr[i]["content_desc"],"");
            item.content_value.SetValue(dr[i]["content_value"],"");
            item.content_lang_idField.SetValue(dr[i]["content_lang_id"],"");
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

