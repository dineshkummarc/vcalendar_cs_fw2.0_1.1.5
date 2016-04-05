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

namespace calendar.admin.content{ //Namespace @1-74370073

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

//Grid contents Item Class @5-FC68A1C5
public class contentsItem:IDataItem
{
    public TextField content_type;
    public object content_typeHref;
    public LinkParameterCollection content_typeHrefParameters;
    public TextField content_desc;
    public TextField translations;
    public object translationsHref;
    public LinkParameterCollection translationsHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public contentsItem()
    {
        content_type = new TextField("",null);
        content_typeHrefParameters = new LinkParameterCollection();
        content_desc=new TextField("", null);
        translations = new TextField("",null);
        translationsHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "content_type":
                    return this.content_type;
                case "content_desc":
                    return this.content_desc;
                case "translations":
                    return this.translations;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "content_type":
                    this.content_type = (TextField)value;
                    break;
                case "content_desc":
                    this.content_desc = (TextField)value;
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
//End Grid contents Item Class

//Grid contents Data Provider Class Header @5-27E8D55E
public class contentsDataProvider:GridDataProviderBase
{
//End Grid contents Data Provider Class Header

//Grid contents Data Provider Class Variables @5-243F42DC
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=50;
    public int PageNumber=1;
    public TextParameter Seslocale;
//End Grid contents Data Provider Class Variables

//Grid contents Data Provider Class Constructor @5-BF1777E4
    public contentsDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  contents.content_id AS contents_content_id, \n" +
          "content_type, contents_langs.content_desc AS contents_langs_content_desc, \n" +
          "content_lang_id \n" +
          "FROM contents LEFT JOIN contents_langs ON\n" +
          "contents.content_id = contents_langs.content_id {SQL_Where} {SQL_OrderBy}", new string[]{"locale36"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM contents LEFT JOIN contents_langs ON\n" +
          "contents.content_id = contents_langs.content_id", new string[]{"locale36"},Settings.calendarDataAccessObject);
    }
//End Grid contents Data Provider Class Constructor

//Grid contents Data Provider Class GetResultSet Method @5-51096D86
    public contentsItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid contents Data Provider Class GetResultSet Method

//Before build Select @5-B47771D8
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale36",Seslocale, "","contents_langs.language_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @5-B1088923
        DataSet ds=null;
        _pagesCount=0;
        contentsItem[] result = new contentsItem[0];
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

//After execute Select @5-DDBA194B
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new contentsItem[dr.Count];
//End After execute Select

//After execute Select tail @5-1B9F2936
            for(int i=0;i<dr.Count;i++)
            {
                contentsItem item=new contentsItem();
                item.content_type.SetValue(dr[i]["content_type"],"");
                item.content_typeHref = "content.aspx";
                item.content_typeHrefParameters.Add("content_id",System.Web.HttpUtility.UrlEncode(dr[i]["content_lang_id"].ToString()));
                item.content_desc.SetValue(dr[i]["contents_langs_content_desc"],"");
                item.translationsHref = "content_lang.aspx";
                item.translationsHrefParameters.Add("content_id",System.Web.HttpUtility.UrlEncode(dr[i]["contents_content_id"].ToString()));
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

//Record contents_maint Item Class @13-E967627F
public class contents_maintItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField content_type;
    public TextField content_desc;
    public MemoField content_value;
    public TextField content_id;
    public NameValueCollection errors=new NameValueCollection();
    public contents_maintItem()
    {
        content_type=new TextField("", null);
        content_desc=new TextField("", null);
        content_value=new MemoField("", null);
        content_id=new TextField("", null);
    }

    public static contents_maintItem CreateFromHttpRequest()
    {
        contents_maintItem item = new contents_maintItem();
        if(DBUtility.GetInitialValue("content_type") != null){
        item.content_type.SetValue(DBUtility.GetInitialValue("content_type"));
        }
        if(DBUtility.GetInitialValue("content_desc") != null){
        item.content_desc.SetValue(DBUtility.GetInitialValue("content_desc"));
        }
        if(DBUtility.GetInitialValue("content_value") != null){
        item.content_value.SetValue(DBUtility.GetInitialValue("content_value"));
        }
        if(DBUtility.GetInitialValue("content_id") != null){
        item.content_id.SetValue(DBUtility.GetInitialValue("content_id"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "content_type":
                    return this.content_type;
                case "content_desc":
                    return this.content_desc;
                case "content_value":
                    return this.content_value;
                case "content_id":
                    return this.content_id;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "content_type":
                    this.content_type = (TextField)value;
                    break;
                case "content_desc":
                    this.content_desc = (TextField)value;
                    break;
                case "content_value":
                    this.content_value = (MemoField)value;
                    break;
                case "content_id":
                    this.content_id = (TextField)value;
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

    public void Validate(contents_maintDataProvider provider)
    {
//End Record contents_maint Item Class

//content_desc validate @17-45366CB2
        if(content_desc.Value==null||content_desc.Value.ToString()=="")
            errors.Add("content_desc",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.content_desc));
//End content_desc validate

//Record contents_maint Item Class tail @13-F5FC18C5
    }
}
//End Record contents_maint Item Class tail

//Record contents_maint Data Provider Class @13-96D83CEA
public class contents_maintDataProvider:RecordDataProviderBase
{
//End Record contents_maint Data Provider Class

//Record contents_maint Data Provider Class Variables @13-D9243D73
    protected contents_maintItem item;
    public IntegerParameter Urlcontent_id;
    public MemoParameter Ctrlcontent_value;
    public TextParameter Ctrlcontent_desc;
//End Record contents_maint Data Provider Class Variables

//Record contents_maint Data Provider Class Constructor @13-DF945F74
    public contents_maintDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  contents_langs.content_desc AS contents_langs_content_desc, \n" +
          "contents_langs.content_value AS contents_langs_content_value, \n" +
          "content_type,\n" +
          "contents_langs.content_id AS contents_langs_content_id \n" +
          "FROM contents_langs INNER JOIN contents ON\n" +
          "contents_langs.content_id = contents.content_id {SQL_Where} {SQL_OrderBy}", new string[]{"content_id54"},Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE contents_langs SET content_value={content_value}, \n" +
          "content_desc={content_desc}", new string[]{"content_id28"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record contents_maint Data Provider Class Constructor

//Record contents_maint Data Provider Class LoadParams Method @13-4484689D
    protected bool LoadParams()
    {
        return Urlcontent_id!=null;
    }
//End Record contents_maint Data Provider Class LoadParams Method

//Record contents_maint Data Provider Class CheckUnique Method @13-710B81F3
    public bool CheckUnique(string ControlName,contents_maintItem item)
    {
        return true;
    }
//End Record contents_maint Data Provider Class CheckUnique Method

//Record contents_maint Data Provider Class PrepareUpdate Method @13-A0234095
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = Urlcontent_id!=null;
//End Record contents_maint Data Provider Class PrepareUpdate Method

//Record contents_maint Data Provider Class PrepareUpdate Method tail @13-FCB6E20C
    }
//End Record contents_maint Data Provider Class PrepareUpdate Method tail

//Record contents_maint Data Provider Class Update Method @13-E21CD521
    public int UpdateItem(contents_maintItem item)
    {
        this.item = item;
//End Record contents_maint Data Provider Class Update Method

//Record contents_maint BeforeBuildUpdate @13-2FA8C868
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("content_id28",Urlcontent_id, "","content_lang_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{content_value}",Update.Dao.ToSql(item.content_value.Value==null?null:item.content_value.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{content_desc}",Update.Dao.ToSql(item.content_desc.Value==null?null:item.content_desc.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record contents_maint BeforeBuildUpdate

//Record contents_maint AfterExecuteUpdate @13-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record contents_maint AfterExecuteUpdate

//Record contents_maint Data Provider Class GetResultSet Method @13-15D67791
    public void FillItem(contents_maintItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record contents_maint Data Provider Class GetResultSet Method

//Record contents_maint BeforeBuildSelect @13-B9A71A6C
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("content_id54",Urlcontent_id, "","contents_langs.content_lang_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record contents_maint BeforeBuildSelect

//Record contents_maint BeforeExecuteSelect @13-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record contents_maint BeforeExecuteSelect

//Record contents_maint AfterExecuteSelect @13-F6F8F5B3
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.content_type.SetValue(dr[i]["content_type"],"");
            item.content_desc.SetValue(dr[i]["contents_langs_content_desc"],"");
            item.content_value.SetValue(dr[i]["contents_langs_content_value"],"");
            item.content_id.SetValue(dr[i]["contents_langs_content_id"],"");
        }
        else
            IsInsertMode=true;
//End Record contents_maint AfterExecuteSelect

//Record contents_maint AfterExecuteSelect tail @13-FCB6E20C
    }
//End Record contents_maint AfterExecuteSelect tail

//Record contents_maint Data Provider Class @13-FCB6E20C
}

//End Record contents_maint Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

