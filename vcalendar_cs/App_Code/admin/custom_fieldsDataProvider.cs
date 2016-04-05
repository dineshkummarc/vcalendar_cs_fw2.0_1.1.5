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

namespace calendar.admin.custom_fields{ //Namespace @1-11E7D2DD

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

//Grid custom_fields Item Class @3-516BC7BB
public class custom_fieldsItem:IDataItem
{
    public TextField field_name;
    public object field_nameHref;
    public LinkParameterCollection field_nameHrefParameters;
    public TextField field_label;
    public BooleanField field_is_active;
    public TextField translations;
    public object translationsHref;
    public LinkParameterCollection translationsHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public custom_fieldsItem()
    {
        field_name = new TextField("",null);
        field_nameHrefParameters = new LinkParameterCollection();
        field_label=new TextField("", null);
        field_is_active=new BooleanField(Settings.BoolFormat, null);
        translations = new TextField("",null);
        translationsHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "field_name":
                    return this.field_name;
                case "field_label":
                    return this.field_label;
                case "field_is_active":
                    return this.field_is_active;
                case "translations":
                    return this.translations;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "field_name":
                    this.field_name = (TextField)value;
                    break;
                case "field_label":
                    this.field_label = (TextField)value;
                    break;
                case "field_is_active":
                    this.field_is_active = (BooleanField)value;
                    break;
                case "translations":
                    this.translations = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid custom_fields Item Class

//Grid custom_fields Data Provider Class Header @3-BDBA1FAE
public class custom_fieldsDataProvider:GridDataProviderBase
{
//End Grid custom_fields Data Provider Class Header

//Grid custom_fields Data Provider Class Variables @3-2BBC0E79
    public enum SortFields {Default,Sorter_field_name,Sorter_field_label,Sorter_field_is_active}
    private string[] SortFieldsNames=new string[]{"custom_fields.field_id","field_name","custom_fields_langs.field_label","field_is_active"};
    private string[] SortFieldsNamesDesc=new string[]{"custom_fields.field_id","field_name DESC","custom_fields_langs.field_label DESC","field_is_active DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=0;
    public int PageNumber=1;
    public TextParameter Seslocale;
//End Grid custom_fields Data Provider Class Variables

//Grid custom_fields Data Provider Class Constructor @3-30933565
    public custom_fieldsDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  field_name, \n" +
          "custom_fields_langs.field_label AS custom_fields_langs_field_label, field_is_active, \n" +
          "custom_fields.field_id AS custom_fields_field_id \n" +
          "FROM custom_fields_langs INNER JOIN custom_fields ON\n" +
          "custom_fields_langs.field_id = custom_fields.field_id {SQL_Where} {SQL_OrderBy}", new string[]{"locale36"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM custom_fields_langs INNER JOIN custom_fields ON\n" +
          "custom_fields_langs.field_id = custom_fields.field_id", new string[]{"locale36"},Settings.calendarDataAccessObject);
    }
//End Grid custom_fields Data Provider Class Constructor

//Grid custom_fields Data Provider Class GetResultSet Method @3-258F652F
    public custom_fieldsItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid custom_fields Data Provider Class GetResultSet Method

//Before build Select @3-9BBB0FCD
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale36",Seslocale, "","custom_fields_langs.language_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @3-4F18D974
        DataSet ds=null;
        _pagesCount=0;
        custom_fieldsItem[] result = new custom_fieldsItem[0];
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

//After execute Select @3-8575782C
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new custom_fieldsItem[dr.Count];
//End After execute Select

//After execute Select tail @3-CE8FE2B9
            for(int i=0;i<dr.Count;i++)
            {
                custom_fieldsItem item=new custom_fieldsItem();
                item.field_name.SetValue(dr[i]["field_name"],"");
                item.field_nameHref = "custom_fields.aspx";
                item.field_nameHrefParameters.Add("field_id",System.Web.HttpUtility.UrlEncode(dr[i]["custom_fields_field_id"].ToString()));
                item.field_label.SetValue(dr[i]["custom_fields_langs_field_label"],"");
                item.field_is_active.SetValue(dr[i]["field_is_active"],"1;0");
                item.translationsHref = "custom_fields_lang.aspx";
                item.translationsHrefParameters.Add("field_id",System.Web.HttpUtility.UrlEncode(dr[i]["custom_fields_field_id"].ToString()));
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @3-FCB6E20C
}
//End Grid Data Provider tail

//Record custom_fields_maint Item Class @16-5C76BB99
public class custom_fields_maintItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField field_name;
    public TextField field_label;
    public IntegerField field_is_active;
    public IntegerField field_is_activeCheckedValue;
    public IntegerField field_is_activeUncheckedValue;
    public NameValueCollection errors=new NameValueCollection();
    public custom_fields_maintItem()
    {
        field_name=new TextField("", null);
        field_label=new TextField("", null);
        field_is_active = new IntegerField("", null);
        field_is_activeCheckedValue = new IntegerField("", 1);
        field_is_activeUncheckedValue = new IntegerField("", 0);
    }

    public static custom_fields_maintItem CreateFromHttpRequest()
    {
        custom_fields_maintItem item = new custom_fields_maintItem();
        if(DBUtility.GetInitialValue("field_name") != null){
        item.field_name.SetValue(DBUtility.GetInitialValue("field_name"));
        }
        if(DBUtility.GetInitialValue("field_label") != null){
        item.field_label.SetValue(DBUtility.GetInitialValue("field_label"));
        }
        if(DBUtility.GetInitialValue("field_is_active") != null){
        if(System.Web.HttpContext.Current.Request["field_is_active"]!=null)
            item.field_is_active.Value = item.field_is_activeCheckedValue.Value;
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "field_name":
                    return this.field_name;
                case "field_label":
                    return this.field_label;
                case "field_is_active":
                    return this.field_is_active;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "field_name":
                    this.field_name = (TextField)value;
                    break;
                case "field_label":
                    this.field_label = (TextField)value;
                    break;
                case "field_is_active":
                    this.field_is_active = (IntegerField)value;
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

    public void Validate(custom_fields_maintDataProvider provider)
    {
//End Record custom_fields_maint Item Class

//Record custom_fields_maint Item Class tail @16-F5FC18C5
    }
}
//End Record custom_fields_maint Item Class tail

//Record custom_fields_maint Data Provider Class @16-DB2E7E28
public class custom_fields_maintDataProvider:RecordDataProviderBase
{
//End Record custom_fields_maint Data Provider Class

//Record custom_fields_maint Data Provider Class Variables @16-9ABCF09D
    protected custom_fields_maintItem item;
    public IntegerParameter Urlfield_id;
    public TextParameter Seslocale;
    public TextParameter Ctrlfield_label;
//End Record custom_fields_maint Data Provider Class Variables

//Record custom_fields_maint Data Provider Class Constructor @16-882FCD24
    public custom_fields_maintDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  custom_fields_langs.field_label AS custom_fields_langs_field_label, \n" +
          "field_name, \n" +
          "field_is_active \n" +
          "FROM custom_fields_langs INNER JOIN custom_fields ON\n" +
          "custom_fields_langs.field_id = custom_fields.field_id {SQL_Where} {SQL_OrderBy}", new string[]{"field_id18","And","locale45"},Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE custom_fields_langs SET field_label={field_label}", new string[]{"field_id46","And","locale47"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record custom_fields_maint Data Provider Class Constructor

//Record custom_fields_maint Data Provider Class LoadParams Method @16-B4D843B1
    protected bool LoadParams()
    {
        return Urlfield_id!=null&&Seslocale!=null;
    }
//End Record custom_fields_maint Data Provider Class LoadParams Method

//Record custom_fields_maint Data Provider Class CheckUnique Method @16-1C2091C3
    public bool CheckUnique(string ControlName,custom_fields_maintItem item)
    {
        return true;
    }
//End Record custom_fields_maint Data Provider Class CheckUnique Method

//Record custom_fields_maint Data Provider Class PrepareUpdate Method @16-2DAF059E
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = Urlfield_id!=null&&Seslocale!=null;
//End Record custom_fields_maint Data Provider Class PrepareUpdate Method

//Record custom_fields_maint Event BeforeExecuteUpdate. Action Custom Code @23-2A29BDB7
    // -------------------------
		DataAccessObject Conn =	Settings.calendarDataAccessObject;

		string SQL = "UPDATE custom_fields SET field_is_active = " + Conn.ToSql(item.field_is_active.GetFormattedValue(),FieldType.Integer);
		if ((string)System.Web.HttpContext.Current.Session["locale"] == CommonFunctions.str_calendar_config("default_language"))
			SQL = SQL + ", field_label = " + Conn.ToSql((string)item.field_label.Value,FieldType.Text);

		SQL = SQL + " WHERE field_id = " + Conn.ToSql(CommonFunctions.CCGetFromGet("field_id",""), FieldType.Integer);

		Conn.RunSql(SQL);
    // -------------------------
//End Record custom_fields_maint Event BeforeExecuteUpdate. Action Custom Code

//Record custom_fields_maint Data Provider Class PrepareUpdate Method tail @16-FCB6E20C
    }
//End Record custom_fields_maint Data Provider Class PrepareUpdate Method tail

//Record custom_fields_maint Data Provider Class Update Method @16-03967668
    public int UpdateItem(custom_fields_maintItem item)
    {
        this.item = item;
//End Record custom_fields_maint Data Provider Class Update Method

//Record custom_fields_maint BeforeBuildUpdate @16-A3DE444B
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("field_id46",Urlfield_id, "","field_id",Condition.Equal,false);
        ((TableCommand)Update).AddParameter("locale47",Seslocale, "","language_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{field_label}",Update.Dao.ToSql(item.field_label.Value==null?null:item.field_label.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record custom_fields_maint BeforeBuildUpdate

//Record custom_fields_maint AfterExecuteUpdate @16-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record custom_fields_maint AfterExecuteUpdate

//Record custom_fields_maint Data Provider Class GetResultSet Method @16-93DFBAF4
    public void FillItem(custom_fields_maintItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record custom_fields_maint Data Provider Class GetResultSet Method

//Record custom_fields_maint BeforeBuildSelect @16-8A557476
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("field_id18",Urlfield_id, "","custom_fields.field_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("locale45",Seslocale, "","custom_fields_langs.language_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record custom_fields_maint BeforeBuildSelect

//Record custom_fields_maint BeforeExecuteSelect @16-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record custom_fields_maint BeforeExecuteSelect

//Record custom_fields_maint AfterExecuteSelect @16-2D717BB9
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.field_name.SetValue(dr[i]["field_name"],"");
            item.field_label.SetValue(dr[i]["custom_fields_langs_field_label"],"");
            item.field_is_active.SetValue(dr[i]["field_is_active"],"");
        }
        else
            IsInsertMode=true;
//End Record custom_fields_maint AfterExecuteSelect

//Record custom_fields_maint AfterExecuteSelect tail @16-FCB6E20C
    }
//End Record custom_fields_maint AfterExecuteSelect tail

//Record custom_fields_maint Data Provider Class @16-FCB6E20C
}

//End Record custom_fields_maint Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

