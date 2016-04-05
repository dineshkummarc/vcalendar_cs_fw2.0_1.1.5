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

namespace calendar.admin.custom_fields_lang{ //Namespace @1-28292626

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

//EditableGrid custom_fields_langs Item Class @5-65963A4B
public class custom_fields_langsItem
{
    public int RowId;
    private bool _deleteAllowed = false;
    private bool _isNew = false;
    public TextField languageLabel;
    public TextField language_id;
    public TextField field_translation;
    public NameValueCollection errors=new NameValueCollection();
    public custom_fields_langsItem()
    {
        languageLabel=new TextField("", null);
        language_id=new TextField("", null);
        field_translation=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "field_lang_idField":
                    return this.field_lang_idField;
                case "languageLabel":
                    return this.languageLabel;
                case "language_id":
                    return this.language_id;
                case "field_translation":
                    return this.field_translation;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "field_lang_idField":
                    this.field_lang_idField = (IntegerField)value;
                    break;
                case "languageLabel":
                    this.languageLabel = (TextField)value;
                    break;
                case "language_id":
                    this.language_id = (TextField)value;
                    break;
                case "field_translation":
                    this.field_translation = (TextField)value;
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
            result = field_translation.Value == null && result;
            result = field_lang_idField.Value == null && result;
            return result;
        }
    }

    public bool IsDeleted = false;
    public bool IsUpdated = false;
    public IntegerField field_lang_idField=new IntegerField();
    public bool Validate(custom_fields_langsDataProvider provider)
    {
//End EditableGrid custom_fields_langs Item Class

//EditableGrid custom_fields_langs Item Class tail @5-2CA8EF5C
        return errors.Count == 0;
    }
}
//End EditableGrid custom_fields_langs Item Class tail

//EditableGrid custom_fields_langs Data Provider Class Header @5-830D7D5E
public class custom_fields_langsDataProvider:EditableGridDataProviderBase
{
//End EditableGrid custom_fields_langs Data Provider Class Header

//Grid custom_fields_langs Data Provider Class Variables @5-5122EE28
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public IntegerParameter Urlfield_id;
//End Grid custom_fields_langs Data Provider Class Variables

//Editable Grid custom_fields_langs Data Provider Class Constructor @5-0F5E70CD
    public custom_fields_langsDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  *, \n" +
          "field_lang_id \n" +
          "FROM custom_fields_langs {SQL_Where} {SQL_OrderBy}", new string[]{"field_id8"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM custom_fields_langs", new string[]{"field_id8"},Settings.calendarDataAccessObject);
    }
//End Editable Grid custom_fields_langs Data Provider Class Constructor

//Editable Grid custom_fields_langs Data Provider Class CheckUnique Method @5-996DB71D
    public bool CheckUnique(string ControlName,custom_fields_langsItem item)
    {
        return true;
    }
//End Editable Grid custom_fields_langs Data Provider Class CheckUnique Method

//EditableGrid custom_fields_langs Data Provider Class Update Method @5-7160F329
    protected int UpdateItem(custom_fields_langsItem item)
    {
        bool CmdExecution = true;
        bool IsParametersPassed = true;
        DataCommand Update=new TableCommand("UPDATE custom_fields_langs SET language_id={language_id}, \n" +
          "field_label={field_translation}", new string[]{"field_lang_id17"},Settings.calendarDataAccessObject);
//End EditableGrid custom_fields_langs Data Provider Class Update Method

//EditableGrid custom_fields_langs BeforeBuildUpdate @5-75A6C8ED
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("field_id8",Urlfield_id, "","field_id",Condition.Equal,true);
        Update.SqlQuery.Replace("{language_id}",Update.Dao.ToSql(item.language_id.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{field_translation}",Update.Dao.ToSql(item.field_translation.GetFormattedValue(""),FieldType.Text));
        Update.Parameters.Add("field_lang_id17","field_lang_id = " + Update.Dao.ToSql(item.field_lang_idField.GetFormattedValue(""),FieldType.Integer));
//End EditableGrid custom_fields_langs BeforeBuildUpdate

//EditableGrid custom_fields_langs Execute Update  @5-D761E721
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
//End EditableGrid custom_fields_langs Execute Update 

//EditableGrid custom_fields_langs Event AfterExecuteUpdate. Action Custom Code @14-2A29BDB7
    // -------------------------
				if ((string)item.language_id.Value == CommonFunctions.str_calendar_config("default_language"))
				{
					DataAccessObject Conn =	Settings.calendarDataAccessObject;

					string SQL = "UPDATE custom_fields " +
						"SET field_label = " + Conn.ToSql((string)item.field_translation.Value, FieldType.Text) +
						" WHERE field_id = " + Conn.ToSql(CommonFunctions.CCGetFromGet("field_id",""), FieldType.Integer);

					Conn.RunSql(SQL);
				}
    // -------------------------
//End EditableGrid custom_fields_langs Event AfterExecuteUpdate. Action Custom Code

//EditableGrid custom_fields_langs AfterExecuteUpdate @5-D87AB90B
            }
        }
        return (int)result;
    }
//End EditableGrid custom_fields_langs AfterExecuteUpdate

//Grid custom_fields_langs Data Provider Class Update Method @5-77126DDD
    public void Update(ArrayList Items, FormSupportedOperations ops)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            EditableGridOperation op = EditableGridOperation.Insert;
            bool isProcessed = false;
            custom_fields_langsItem item = (custom_fields_langsItem)Items[i];
            if(item.IsUpdated) continue;
            if(!item.IsEmptyItem && ops.AllowUpdate && !isProcessed){
                UpdateItem(item);
                op = EditableGridOperation.Update;}
            if(item.errors.Count == 0) item.IsUpdated = true;
            OnItemUpdated(new ItemUpdatedEventArgs(op, item));
        }
    }
//End Grid custom_fields_langs Data Provider Class Update Method

//Grid custom_fields_langs Data Provider Class GetResultSet Method @5-88DF9630
    public custom_fields_langsItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid custom_fields_langs Data Provider Class GetResultSet Method

//Before build Select @5-2B37E373
        _pagesCount = 0;
        Exception E=null;
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("field_id8",Urlfield_id, "","field_id",Condition.Equal,true);
        Count.Parameters = Select.Parameters;
        Select.OrderBy=(SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
//End Before build Select

//Execute Select @5-8A32B9CE
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

//After execute Select @5-316A0D79
                if(E!=null) throw(E);
            }
            dr=ds.Tables[tableIndex].Rows;
            rowCount = dr.Count;
        }
        custom_fields_langsItem[] result=new custom_fields_langsItem[rowCount];
//End After execute Select

//After execute Select tail @5-07BD370F
        for(int i=0; i<rowCount ;i++)
        {
            custom_fields_langsItem item=new custom_fields_langsItem();
            item.languageLabel.SetValue(dr[i]["language_id"],"");
            item.language_id.SetValue(dr[i]["language_id"],"");
            item.field_translation.SetValue(dr[i]["field_label"],"");
            item.field_lang_idField.SetValue(dr[i]["field_lang_id"],"");
            result[i]=item;
        }
        this.mPagesCount=_pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @5-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

