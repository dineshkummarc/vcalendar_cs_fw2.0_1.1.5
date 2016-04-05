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

namespace calendar.admin.config{ //Namespace @1-3BCF5976

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

//EditableGrid config Item Class @3-4B60E71B
public class configItem
{
    public int RowId;
    private bool _deleteAllowed = false;
    private bool _isNew = false;
    public TextField config_category;
    public TextField config_desc;
    public IntegerField Check_value;
    public IntegerField Check_valueCheckedValue;
    public IntegerField Check_valueUncheckedValue;
    public TextField Box_value;
    public MemoField Area_value;
    public TextField ListBox_value;
    public ItemCollection ListBox_valueItems;
    public TextField value_type;
    public TextField ListBox_Values;
    public NameValueCollection errors=new NameValueCollection();
    public configItem()
    {
        config_category=new TextField("", null);
        config_desc=new TextField("", null);
        Check_value = new IntegerField("", null);
        Check_valueCheckedValue = new IntegerField("", 1);
        Check_valueUncheckedValue = new IntegerField("", 0);
        Box_value=new TextField("", null);
        Area_value=new MemoField("", null);
        ListBox_value = new TextField("", null);
        ListBox_valueItems = new ItemCollection();
        value_type=new TextField("", null);
        ListBox_Values=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "config_idField":
                    return this.config_idField;
                case "config_category":
                    return this.config_category;
                case "config_desc":
                    return this.config_desc;
                case "Check_value":
                    return this.Check_value;
                case "Box_value":
                    return this.Box_value;
                case "Area_value":
                    return this.Area_value;
                case "ListBox_value":
                    return this.ListBox_value;
                case "value_type":
                    return this.value_type;
                case "ListBox_Values":
                    return this.ListBox_Values;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "config_idField":
                    this.config_idField = (IntegerField)value;
                    break;
                case "config_category":
                    this.config_category = (TextField)value;
                    break;
                case "config_desc":
                    this.config_desc = (TextField)value;
                    break;
                case "Check_value":
                    this.Check_value = (IntegerField)value;
                    break;
                case "Box_value":
                    this.Box_value = (TextField)value;
                    break;
                case "Area_value":
                    this.Area_value = (MemoField)value;
                    break;
                case "ListBox_value":
                    this.ListBox_value = (TextField)value;
                    break;
                case "value_type":
                    this.value_type = (TextField)value;
                    break;
                case "ListBox_Values":
                    this.ListBox_Values = (TextField)value;
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
            result = Check_value.Value == null && result;
            result = Box_value.Value == null && result;
            result = Area_value.Value == null && result;
            result = ListBox_value.Value == null && result;
            result = value_type.Value == null && result;
            result = ListBox_Values.Value == null && result;
            result = config_idField.Value == null && result;
            return result;
        }
    }

    public bool IsDeleted = false;
    public bool IsUpdated = false;
    public IntegerField config_idField=new IntegerField();
    public bool Validate(configDataProvider provider)
    {
//End EditableGrid config Item Class

//EditableGrid config Item Class tail @3-2CA8EF5C
        return errors.Count == 0;
    }
}
//End EditableGrid config Item Class tail

//EditableGrid config Data Provider Class Header @3-C2474060
public class configDataProvider:EditableGridDataProviderBase
{
//End EditableGrid config Data Provider Class Header

//Grid config Data Provider Class Variables @3-6AFA151D
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{"config_category, config.config_id"};
    private string[] SortFieldsNamesDesc=new string[]{"config_category, config.config_id"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=50;
    public int PageNumber=1;
    public TextParameter Seslocale;
    public MemoParameter CtrlArea_value;
//End Grid config Data Provider Class Variables

//Editable Grid config Data Provider Class Constructor @3-2ED23217
    public configDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  config.config_id AS config_id, \n" +
          "config.config_value, config_type, config_langs.config_desc AS config_langs_config_desc, \n" +
          "config_category,\n" +
          "config_langs.config_listbox AS config_langs_config_listbox \n" +
          "FROM config_langs INNER JOIN config ON\n" +
          "config_langs.config_id = config.config_id {SQL_Where} {SQL_OrderBy}", new string[]{"locale22"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM config_langs INNER JOIN config ON\n" +
          "config_langs.config_id = config.config_id", new string[]{"locale22"},Settings.calendarDataAccessObject);
    }
//End Editable Grid config Data Provider Class Constructor

//Editable Grid config Data Provider Class CheckUnique Method @3-FFB11A03
    public bool CheckUnique(string ControlName,configItem item)
    {
        return true;
    }
//End Editable Grid config Data Provider Class CheckUnique Method

//EditableGrid config Data Provider Class Update Method @3-94DADCAB
    protected int UpdateItem(configItem item)
    {
        bool CmdExecution = true;
        bool IsParametersPassed = true;
        IsParametersPassed = item.config_idField!=null;
        DataCommand Update=new TableCommand("UPDATE config SET config_value={config_value}", new string[]{"config_id24"},Settings.calendarDataAccessObject);
//End EditableGrid config Data Provider Class Update Method

//EditableGrid config Event BeforeBuildUpdate. Action Custom Code @16-2A29BDB7
    // -------------------------
	CommonFunctions.calendar_configResetCache();

	switch ((string)item.value_type.Value)
	{
		case "1":	
			item.Area_value.Value = item.Check_value.Value;
			break;
		case "2":	
			item.Area_value.Value = item.Box_value.Value;
			break;
		case "4":	
			item.Area_value.Value = item.ListBox_value.Value;
			break;
	}
    // -------------------------
//End EditableGrid config Event BeforeBuildUpdate. Action Custom Code

//EditableGrid config BeforeBuildUpdate @3-5D1E1F8B
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("config_id24",item.config_idField, "","config_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{config_value}",Update.Dao.ToSql(item.Area_value.Value==null?null:item.Area_value.GetFormattedValue(""),FieldType.Memo));
//End EditableGrid config BeforeBuildUpdate

//EditableGrid config Execute Update  @3-D761E721
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
//End EditableGrid config Execute Update 

//EditableGrid config AfterExecuteUpdate @3-D87AB90B
            }
        }
        return (int)result;
    }
//End EditableGrid config AfterExecuteUpdate

//Grid config Data Provider Class Update Method @3-228B3DFE
    public void Update(ArrayList Items, FormSupportedOperations ops)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            EditableGridOperation op = EditableGridOperation.Insert;
            bool isProcessed = false;
            configItem item = (configItem)Items[i];
            if(item.IsUpdated) continue;
            if(!item.IsEmptyItem && ops.AllowUpdate && !isProcessed){
                UpdateItem(item);
                op = EditableGridOperation.Update;}
            if(item.errors.Count == 0) item.IsUpdated = true;
            OnItemUpdated(new ItemUpdatedEventArgs(op, item));
        }
    }
//End Grid config Data Provider Class Update Method

//Grid config Data Provider Class GetResultSet Method @3-9379BB08
    public configItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid config Data Provider Class GetResultSet Method

//Before build Select @3-EA9B4ABB
        _pagesCount = 0;
        Exception E=null;
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale22",Seslocale, "","config_langs.language_id",Condition.Equal,false);
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

//After execute Select @3-C01A11D6
                if(E!=null) throw(E);
            }
            dr=ds.Tables[tableIndex].Rows;
            rowCount = dr.Count;
        }
        configItem[] result=new configItem[rowCount];
//End After execute Select

//ListBox ListBox_value AfterExecuteSelect @17-AF5D5179
    ItemCollection ListBox_valueItems=new ItemCollection();
    
ListBox_valueItems.Add("0","0");
//End ListBox ListBox_value AfterExecuteSelect

//After execute Select tail @3-18BCFB48
        for(int i=0; i<rowCount ;i++)
        {
            configItem item=new configItem();
            item.config_category.SetValue(dr[i]["config_category"],"");
            item.config_desc.SetValue(dr[i]["config_langs_config_desc"],"");
            item.Area_value.SetValue(dr[i]["config_value"],"");
            item.ListBox_valueItems = (ItemCollection)ListBox_valueItems.Clone();
            item.value_type.SetValue(dr[i]["config_type"],"");
            item.ListBox_Values.SetValue(dr[i]["config_langs_config_listbox"],"");
            item.config_idField.SetValue(dr[i]["config_id"],"");
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

