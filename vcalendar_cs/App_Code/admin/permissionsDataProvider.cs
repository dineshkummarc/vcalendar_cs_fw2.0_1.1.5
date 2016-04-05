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

namespace calendar.admin.permissions{ //Namespace @1-8F33A85E

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

//EditableGrid permissions Item Class @3-A864908B
public class permissionsItem
{
    public int RowId;
    private bool _deleteAllowed = false;
    private bool _isNew = false;
    public TextField permission_category;
    public TextField permission_desc;
    public TextField perms_value;
    public ItemCollection perms_valueItems;
    public IntegerField perm_type;
    public NameValueCollection errors=new NameValueCollection();
    public permissionsItem()
    {
        permission_category=new TextField("", null);
        permission_desc=new TextField("", null);
        perms_value = new TextField("", null);
        perms_valueItems = new ItemCollection();
        perm_type=new IntegerField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "permission_idField":
                    return this.permission_idField;
                case "permission_lang_idField":
                    return this.permission_lang_idField;
                case "permission_category":
                    return this.permission_category;
                case "permission_desc":
                    return this.permission_desc;
                case "perms_value":
                    return this.perms_value;
                case "perm_type":
                    return this.perm_type;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "permission_idField":
                    this.permission_idField = (IntegerField)value;
                    break;
                case "permission_lang_idField":
                    this.permission_lang_idField = (IntegerField)value;
                    break;
                case "permission_category":
                    this.permission_category = (TextField)value;
                    break;
                case "permission_desc":
                    this.permission_desc = (TextField)value;
                    break;
                case "perms_value":
                    this.perms_value = (TextField)value;
                    break;
                case "perm_type":
                    this.perm_type = (IntegerField)value;
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
            result = perms_value.Value == null && result;
            result = perm_type.Value == null && result;
            result = permission_idField.Value == null && result;
            result = permission_lang_idField.Value == null && result;
            return result;
        }
    }

    public bool IsDeleted = false;
    public bool IsUpdated = false;
    public IntegerField permission_idField=new IntegerField();
    public IntegerField permission_lang_idField=new IntegerField();
    public bool Validate(permissionsDataProvider provider)
    {
//End EditableGrid permissions Item Class

//EditableGrid permissions Item Class tail @3-2CA8EF5C
        return errors.Count == 0;
    }
}
//End EditableGrid permissions Item Class tail

//EditableGrid permissions Data Provider Class Header @3-C40B5EDB
public class permissionsDataProvider:EditableGridDataProviderBase
{
//End EditableGrid permissions Data Provider Class Header

//Grid permissions Data Provider Class Variables @3-5CEB9F12
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{"permissions.permission_category, permissions.permission_id"};
    private string[] SortFieldsNamesDesc=new string[]{"permissions.permission_category, permissions.permission_id"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=0;
    public int PageNumber=1;
    public TextParameter Seslocale;
    public IntegerParameter Ctrlperms_value;
//End Grid permissions Data Provider Class Variables

//Editable Grid permissions Data Provider Class Constructor @3-008603D2
    public permissionsDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  permissions_langs.permission_desc AS permissions_langs_pe" +
          "rmission_desc, permissions.permission_id, permission_var, \n" +
          "permissions.permission_desc AS permissions_permission_desc,\n" +
          "permission_value, permission_type, \n" +
          "permission_category, \n" +
          "permission_lang_id \n" +
          "FROM permissions_langs INNER JOIN permissions ON\n" +
          "permissions_langs.permission_id = permissions.permission_id {SQL_Where} {SQL_OrderBy}", new string[]{"locale23"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM permissions_langs INNER JOIN permissions ON\n" +
          "permissions_langs.permission_id = permissions.permission_id", new string[]{"locale23"},Settings.calendarDataAccessObject);
    }
//End Editable Grid permissions Data Provider Class Constructor

//Editable Grid permissions Data Provider Class CheckUnique Method @3-76D764D4
    public bool CheckUnique(string ControlName,permissionsItem item)
    {
        return true;
    }
//End Editable Grid permissions Data Provider Class CheckUnique Method

//EditableGrid permissions Data Provider Class Update Method @3-4F0ACE3E
    protected int UpdateItem(permissionsItem item)
    {
        bool CmdExecution = true;
        bool IsParametersPassed = true;
        IsParametersPassed = item.permission_idField!=null;
        DataCommand Update=new TableCommand("UPDATE permissions SET permission_value={permission_value}", new string[]{"permission_id25"},Settings.calendarDataAccessObject);
//End EditableGrid permissions Data Provider Class Update Method

//EditableGrid permissions BeforeBuildUpdate @3-7F9A6F4B
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("permission_id25",item.permission_idField, "","permission_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{permission_value}",Update.Dao.ToSql(item.perms_value.Value==null?null:item.perms_value.GetFormattedValue(""),FieldType.Integer));
//End EditableGrid permissions BeforeBuildUpdate

//EditableGrid permissions Execute Update  @3-D761E721
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
//End EditableGrid permissions Execute Update 

//EditableGrid permissions AfterExecuteUpdate @3-D87AB90B
            }
        }
        return (int)result;
    }
//End EditableGrid permissions AfterExecuteUpdate

//Grid permissions Data Provider Class Update Method @3-0D78DF57
    public void Update(ArrayList Items, FormSupportedOperations ops)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            EditableGridOperation op = EditableGridOperation.Insert;
            bool isProcessed = false;
            permissionsItem item = (permissionsItem)Items[i];
            if(item.IsUpdated) continue;
            if(!item.IsEmptyItem && ops.AllowUpdate && !isProcessed){
                UpdateItem(item);
                op = EditableGridOperation.Update;}
            if(item.errors.Count == 0) item.IsUpdated = true;
            OnItemUpdated(new ItemUpdatedEventArgs(op, item));
        }
    }
//End Grid permissions Data Provider Class Update Method

//Grid permissions Data Provider Class GetResultSet Method @3-21272B2F
    public permissionsItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid permissions Data Provider Class GetResultSet Method

//Before build Select @3-F2C783BC
        _pagesCount = 0;
        Exception E=null;
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale23",Seslocale, "","permissions_langs.language_id",Condition.Equal,false);
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

//After execute Select @3-DDA0A877
                if(E!=null) throw(E);
            }
            dr=ds.Tables[tableIndex].Rows;
            rowCount = dr.Count;
        }
        permissionsItem[] result=new permissionsItem[rowCount];
//End After execute Select

//ListBox perms_value AfterExecuteSelect @7-C6896C86
    ItemCollection perms_valueItems=new ItemCollection();
    
perms_valueItems.Add("0","0");
//End ListBox perms_value AfterExecuteSelect

//After execute Select tail @3-D34304DA
        for(int i=0; i<rowCount ;i++)
        {
            permissionsItem item=new permissionsItem();
            item.permission_category.SetValue(dr[i]["permission_category"],"");
            item.permission_desc.SetValue(dr[i]["permissions_langs_permission_desc"],"");
            item.perms_value.SetValue(dr[i]["permission_value"],"");
            item.perms_valueItems = (ItemCollection)perms_valueItems.Clone();
            item.perm_type.SetValue(dr[i]["permission_type"],"");
            item.permission_idField.SetValue(dr[i]["permission_id"],"");
            item.permission_lang_idField.SetValue(dr[i]["permission_lang_id"],"");
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

