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

namespace calendar.admin.categories_langs{ //Namespace @1-756311E1

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

//EditableGrid categories_langs Item Class @3-2E3D334A
public class categories_langsItem
{
    public int RowId;
    private bool _deleteAllowed = false;
    private bool _isNew = false;
    public TextField languageLabel;
    public TextField language_id;
    public TextField category_name;
    public NameValueCollection errors=new NameValueCollection();
    public categories_langsItem()
    {
        languageLabel=new TextField("", null);
        language_id=new TextField("", null);
        category_name=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "category_lang_idField":
                    return this.category_lang_idField;
                case "languageLabel":
                    return this.languageLabel;
                case "language_id":
                    return this.language_id;
                case "category_name":
                    return this.category_name;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "category_lang_idField":
                    this.category_lang_idField = (IntegerField)value;
                    break;
                case "languageLabel":
                    this.languageLabel = (TextField)value;
                    break;
                case "language_id":
                    this.language_id = (TextField)value;
                    break;
                case "category_name":
                    this.category_name = (TextField)value;
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
            result = category_name.Value == null && result;
            result = category_lang_idField.Value == null && result;
            return result;
        }
    }

    public bool IsDeleted = false;
    public bool IsUpdated = false;
    public IntegerField category_lang_idField=new IntegerField();
    public bool Validate(categories_langsDataProvider provider)
    {
//End EditableGrid categories_langs Item Class

//category_name validate @6-05E8E249
        if(category_name.Value==null||category_name.Value.ToString()=="")
            errors.Add("category_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.category_translation));
//End category_name validate

//EditableGrid categories_langs Item Class tail @3-2CA8EF5C
        return errors.Count == 0;
    }
}
//End EditableGrid categories_langs Item Class tail

//EditableGrid categories_langs Data Provider Class Header @3-057C8124
public class categories_langsDataProvider:EditableGridDataProviderBase
{
//End EditableGrid categories_langs Data Provider Class Header

//Grid categories_langs Data Provider Class Variables @3-BB84C4E0
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=50;
    public int PageNumber=1;
    public IntegerParameter Urlcategory_id;
//End Grid categories_langs Data Provider Class Variables

//Editable Grid categories_langs Data Provider Class Constructor @3-0386C045
    public categories_langsDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  *, \n" +
          "category_lang_id \n" +
          "FROM categories_langs {SQL_Where} {SQL_OrderBy}", new string[]{"category_id11"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM categories_langs", new string[]{"category_id11"},Settings.calendarDataAccessObject);
    }
//End Editable Grid categories_langs Data Provider Class Constructor

//Editable Grid categories_langs Data Provider Class CheckUnique Method @3-580D6C2C
    public bool CheckUnique(string ControlName,categories_langsItem item)
    {
        return true;
    }
//End Editable Grid categories_langs Data Provider Class CheckUnique Method

//EditableGrid categories_langs Data Provider Class Update Method @3-2A510CB5
    protected int UpdateItem(categories_langsItem item)
    {
        bool CmdExecution = true;
        bool IsParametersPassed = true;
        DataCommand Update=new TableCommand("UPDATE categories_langs SET language_id={language_id}, \n" +
          "category_name={category_name}", new string[]{"category_lang_id19"},Settings.calendarDataAccessObject);
//End EditableGrid categories_langs Data Provider Class Update Method

//EditableGrid categories_langs BeforeBuildUpdate @3-53385987
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("category_id11",Urlcategory_id, "","category_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{language_id}",Update.Dao.ToSql(item.language_id.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{category_name}",Update.Dao.ToSql(item.category_name.GetFormattedValue(""),FieldType.Text));
        Update.Parameters.Add("category_lang_id19","category_lang_id = " + Update.Dao.ToSql(item.category_lang_idField.GetFormattedValue(""),FieldType.Integer));
//End EditableGrid categories_langs BeforeBuildUpdate

//EditableGrid categories_langs Execute Update  @3-D761E721
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
//End EditableGrid categories_langs Execute Update 

//EditableGrid categories_langs Event AfterExecuteUpdate. Action Custom Code @9-2A29BDB7
    // -------------------------
				if ((string)item.language_id.Value == CommonFunctions.str_calendar_config("default_language")) {
					DataAccessObject Conn =	Settings.calendarDataAccessObject;
					string SQL = "UPDATE categories " +
					 	" SET category_name= " + Conn.ToSql((string)item.category_name.Value, FieldType.Text) +
						 " WHERE category_id=" + Conn.ToSql(CommonFunctions.CCGetFromGet("category_id",""), FieldType.Integer);
					Conn.RunSql(SQL);
				}
    // -------------------------
//End EditableGrid categories_langs Event AfterExecuteUpdate. Action Custom Code

//EditableGrid categories_langs AfterExecuteUpdate @3-D87AB90B
            }
        }
        return (int)result;
    }
//End EditableGrid categories_langs AfterExecuteUpdate

//Grid categories_langs Data Provider Class Update Method @3-94340F0E
    public void Update(ArrayList Items, FormSupportedOperations ops)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            EditableGridOperation op = EditableGridOperation.Insert;
            bool isProcessed = false;
            categories_langsItem item = (categories_langsItem)Items[i];
            if(item.IsUpdated) continue;
            if(!item.IsEmptyItem && ops.AllowUpdate && !isProcessed){
                UpdateItem(item);
                op = EditableGridOperation.Update;}
            if(item.errors.Count == 0) item.IsUpdated = true;
            OnItemUpdated(new ItemUpdatedEventArgs(op, item));
        }
    }
//End Grid categories_langs Data Provider Class Update Method

//Grid categories_langs Data Provider Class GetResultSet Method @3-A668183B
    public categories_langsItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid categories_langs Data Provider Class GetResultSet Method

//Before build Select @3-BD28CCE2
        _pagesCount = 0;
        Exception E=null;
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("category_id11",Urlcategory_id, "","category_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy=(SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
//End Before build Select

//Execute Select @3-8A32B9CE
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

//After execute Select @3-347CEE5B
                if(E!=null) throw(E);
            }
            dr=ds.Tables[tableIndex].Rows;
            rowCount = dr.Count;
        }
        categories_langsItem[] result=new categories_langsItem[rowCount];
//End After execute Select

//After execute Select tail @3-DBD89E23
        for(int i=0; i<rowCount ;i++)
        {
            categories_langsItem item=new categories_langsItem();
            item.languageLabel.SetValue(dr[i]["language_id"],"");
            item.language_id.SetValue(dr[i]["language_id"],"");
            item.category_name.SetValue(dr[i]["category_name"],"");
            item.category_lang_idField.SetValue(dr[i]["category_lang_id"],"");
            result[i]=item;
        }
        this.mPagesCount=_pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @3-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

