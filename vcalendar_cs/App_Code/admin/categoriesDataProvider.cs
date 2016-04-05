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

namespace calendar.admin.categories{ //Namespace @1-223740FB

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

//Grid categories Item Class @33-0464BC29
public class categoriesItem:IDataItem
{
    public TextField category_name;
    public object category_nameHref;
    public LinkParameterCollection category_nameHrefParameters;
    public TextField category_image;
    public TextField translations;
    public object translationsHref;
    public LinkParameterCollection translationsHrefParameters;
    public TextField categories_Insert;
    public object categories_InsertHref;
    public LinkParameterCollection categories_InsertHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public categoriesItem()
    {
        category_name = new TextField("",null);
        category_nameHrefParameters = new LinkParameterCollection();
        category_image=new TextField("", null);
        translations = new TextField("",null);
        translationsHrefParameters = new LinkParameterCollection();
        categories_Insert = new TextField("",null);
        categories_InsertHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "category_name":
                    return this.category_name;
                case "category_image":
                    return this.category_image;
                case "translations":
                    return this.translations;
                case "categories_Insert":
                    return this.categories_Insert;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "category_name":
                    this.category_name = (TextField)value;
                    break;
                case "category_image":
                    this.category_image = (TextField)value;
                    break;
                case "translations":
                    this.translations = (TextField)value;
                    break;
                case "categories_Insert":
                    this.categories_Insert = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid categories Item Class

//Grid categories Data Provider Class Header @33-088D4B05
public class categoriesDataProvider:GridDataProviderBase
{
//End Grid categories Data Provider Class Header

//Grid categories Data Provider Class Variables @33-A47954F1
    public enum SortFields {Default,Sorter_category_name,Sorter_category_image}
    private string[] SortFieldsNames=new string[]{"","categories_langs.category_name","category_image"};
    private string[] SortFieldsNamesDesc=new string[]{"","categories_langs.category_name DESC","category_image DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public TextParameter Seslocale;
//End Grid categories Data Provider Class Variables

//Grid categories Data Provider Class Constructor @33-BB6A5AD1
    public categoriesDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  category_image, \n" +
          "categories_langs.category_name AS categories_langs_category_name, \n" +
          "categories.category_id AS categories_category_id,\n" +
          "category_lang_id \n" +
          "FROM categories_langs INNER JOIN categories ON\n" +
          "categories_langs.category_id = categories.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"locale65"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM categories_langs INNER JOIN categories ON\n" +
          "categories_langs.category_id = categories.category_id", new string[]{"locale65"},Settings.calendarDataAccessObject);
    }
//End Grid categories Data Provider Class Constructor

//Grid categories Data Provider Class GetResultSet Method @33-2463101C
    public categoriesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid categories Data Provider Class GetResultSet Method

//Before build Select @33-A6F3B70E
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale65",Seslocale, "","categories_langs.language_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @33-1326DD34
        DataSet ds=null;
        _pagesCount=0;
        categoriesItem[] result = new categoriesItem[0];
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

//After execute Select @33-B7892FB5
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new categoriesItem[dr.Count];
//End After execute Select

//After execute Select tail @33-8CE37C02
            for(int i=0;i<dr.Count;i++)
            {
                categoriesItem item=new categoriesItem();
                item.category_name.SetValue(dr[i]["categories_langs_category_name"],"");
                item.category_nameHref = "categories.aspx";
                item.category_nameHrefParameters.Add("category_id",System.Web.HttpUtility.UrlEncode(dr[i]["categories_category_id"].ToString()));
                item.category_image.SetValue(dr[i]["category_image"],"");
                item.translationsHref = "categories_langs.aspx";
                item.translationsHrefParameters.Add("category_id",System.Web.HttpUtility.UrlEncode(dr[i]["categories_category_id"].ToString()));
                item.categories_InsertHref = "categories.aspx";
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @33-FCB6E20C
}
//End Grid Data Provider tail

//Record categories_maint Item Class @45-458CA167
public class categories_maintItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField category_name;
    public TextField category_image;
    public NameValueCollection errors=new NameValueCollection();
    public categories_maintItem()
    {
        category_name=new TextField("", null);
        category_image=new TextField("", null);
    }

    public static categories_maintItem CreateFromHttpRequest()
    {
        categories_maintItem item = new categories_maintItem();
        if(DBUtility.GetInitialValue("category_name") != null){
        item.category_name.SetValue(DBUtility.GetInitialValue("category_name"));
        }
        if(DBUtility.GetInitialValue("category_image") != null){
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "category_name":
                    return this.category_name;
                case "category_image":
                    return this.category_image;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "category_name":
                    this.category_name = (TextField)value;
                    break;
                case "category_image":
                    this.category_image = (TextField)value;
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

    public void Validate(categories_maintDataProvider provider)
    {
//End Record categories_maint Item Class

//category_name validate @46-F9924C9E
        if(category_name.Value==null||category_name.Value.ToString()=="")
            errors.Add("category_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.cal_category_name));
//End category_name validate

//Record categories_maint Item Class tail @45-F5FC18C5
    }
}
//End Record categories_maint Item Class tail

//Record categories_maint Data Provider Class @45-3ACBF827
public class categories_maintDataProvider:RecordDataProviderBase
{
//End Record categories_maint Data Provider Class

//Record categories_maint Data Provider Class Variables @45-79EB3944
    protected categories_maintItem item;
    public TextParameter Seslocale;
    public TextParameter Ctrlcategory_name;
    public TextParameter Ctrlcategory_image;
    public IntegerParameter Urlcategory_id;
//End Record categories_maint Data Provider Class Variables

//Record categories_maint Data Provider Class Constructor @45-C21E734B
    public categories_maintDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  category_image, \n" +
          "categories_langs.category_name AS categories_langs_category_name \n" +
          "FROM categories_langs INNER JOIN categories ON\n" +
          "categories_langs.category_id = categories.category_id {SQL_Where} {SQL_OrderBy}", new string[]{"category_id53","And","locale91"},Settings.calendarDataAccessObject);
         Insert=new TableCommand("INSERT INTO categories(category_name, category_image) VALUES ({category_name}, \n" +
          "{category_image})", new string[0],Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE categories SET category_image={category_image}", new string[]{"category_id87"},Settings.calendarDataAccessObject);
         Delete=new TableCommand("DELETE FROM categories", new string[]{"category_id90"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record categories_maint Data Provider Class Constructor

//Record categories_maint Data Provider Class LoadParams Method @45-4663F2C2
    protected bool LoadParams()
    {
        return Urlcategory_id!=null&&Seslocale!=null;
    }
//End Record categories_maint Data Provider Class LoadParams Method

//Record categories_maint Data Provider Class CheckUnique Method @45-DD404AF2
    public bool CheckUnique(string ControlName,categories_maintItem item)
    {
        return true;
    }
//End Record categories_maint Data Provider Class CheckUnique Method

//Record categories_maint Data Provider Class PrepareInsert Method @45-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record categories_maint Data Provider Class PrepareInsert Method

//Record categories_maint Data Provider Class PrepareInsert Method tail @45-FCB6E20C
    }
//End Record categories_maint Data Provider Class PrepareInsert Method tail

//Record categories_maint Data Provider Class Insert Method @45-018D1EAB
    public int InsertItem(categories_maintItem item)
    {
        this.item = item;
//End Record categories_maint Data Provider Class Insert Method

//Record categories_maint Build insert @45-BB6D4CB2
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{category_name}",Insert.Dao.ToSql(item.category_name.Value==null?null:item.category_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{category_image}",Insert.Dao.ToSql(item.category_image.Value==null?null:item.category_image.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record categories_maint Build insert

//Record categories_maint Event AfterExecuteInsert. Action Custom Code @93-2A29BDB7
    // -------------------------
			DataAccessObject Conn = Settings.calendarDataAccessObject;
			string LastCategoryID = (string)CommonFunctions.CCDLookUp("MAX(category_id)", "categories", "", Conn);

			//Get the languages
			Hashtable LanguageArray = (Hashtable)System.Web.HttpContext.Current.Application["_locales"];
			foreach (object LangKey in LanguageArray.Keys)
			{
				//Insert new record to the categories_langs
				string SQL = "INSERT INTO categories_langs ( " +
					"language_id, " +
					"category_name," +
					"category_id " +
					") VALUES ( " +
					Conn.ToSql((string)LangKey, FieldType.Text) + "," +
					Conn.ToSql((string)item.category_name.Value, FieldType.Text) + "," +
					Conn.ToSql(LastCategoryID, FieldType.Integer) +
					")";
				Conn.RunSql(SQL);
			}
    // -------------------------
//End Record categories_maint Event AfterExecuteInsert. Action Custom Code

//Record categories_maint AfterExecuteInsert @45-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record categories_maint AfterExecuteInsert

//Record categories_maint Data Provider Class PrepareUpdate Method @45-E069A7AA
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = Urlcategory_id!=null;
//End Record categories_maint Data Provider Class PrepareUpdate Method

//Record categories_maint Data Provider Class PrepareUpdate Method tail @45-FCB6E20C
    }
//End Record categories_maint Data Provider Class PrepareUpdate Method tail

//Record categories_maint Data Provider Class Update Method @45-1DC1F711
    public int UpdateItem(categories_maintItem item)
    {
        this.item = item;
//End Record categories_maint Data Provider Class Update Method

//Record categories_maint BeforeBuildUpdate @45-0CCE2398
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("category_id87",Urlcategory_id, "","categories.category_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{category_image}",Update.Dao.ToSql(item.category_image.Value==null?null:item.category_image.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record categories_maint BeforeBuildUpdate

//Record categories_maint AfterExecuteUpdate @45-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record categories_maint AfterExecuteUpdate

//Record categories_maint Data Provider Class PrepareDelete Method @45-A9BACE4A
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = Urlcategory_id!=null;
//End Record categories_maint Data Provider Class PrepareDelete Method

//Record categories_maint Data Provider Class PrepareDelete Method tail @45-FCB6E20C
    }
//End Record categories_maint Data Provider Class PrepareDelete Method tail

//Record categories_maint Data Provider Class Delete Method @45-B5F988AE
    public int DeleteItem(categories_maintItem item)
    {
        this.item = item;
//End Record categories_maint Data Provider Class Delete Method

//Record categories_maint BeforeBuildDelete @45-7D5C774A
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("category_id90",Urlcategory_id, "","categories.category_id",Condition.Equal,false);
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record categories_maint BeforeBuildDelete

//Record categories_maint Event AfterExecuteDelete. Action Custom Code @92-2A29BDB7
    // -------------------------
		//Delete the related records 
		string SQL = "DELETE FROM categories_langs WHERE category_id=" + 
					Settings.calendarDataAccessObject.ToSql(Urlcategory_id.ToString(), FieldType.Integer);
		Settings.calendarDataAccessObject.RunSql(SQL);

		SQL = "UPDATE events SET category_id=NULL WHERE category_id=" + 
					Settings.calendarDataAccessObject.ToSql(Urlcategory_id.ToString(), FieldType.Integer);
		Settings.calendarDataAccessObject.RunSql(SQL);
    // -------------------------
//End Record categories_maint Event AfterExecuteDelete. Action Custom Code

//Record categories_maint BeforeBuildDelete @45-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record categories_maint BeforeBuildDelete

//Record categories_maint Data Provider Class GetResultSet Method @45-385D6831
    public void FillItem(categories_maintItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record categories_maint Data Provider Class GetResultSet Method

//Record categories_maint BeforeBuildSelect @45-02C644AF
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("category_id53",Urlcategory_id, "","categories.category_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("locale91",Seslocale, "","categories_langs.language_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record categories_maint BeforeBuildSelect

//Record categories_maint BeforeExecuteSelect @45-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record categories_maint BeforeExecuteSelect

//Record categories_maint AfterExecuteSelect @45-0A21F65E
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.category_name.SetValue(dr[i]["categories_langs_category_name"],"");
            item.category_image.SetValue(dr[i]["category_image"],"");
        }
        else
            IsInsertMode=true;
//End Record categories_maint AfterExecuteSelect

//Record categories_maint AfterExecuteSelect tail @45-FCB6E20C
    }
//End Record categories_maint AfterExecuteSelect tail

//Record categories_maint Data Provider Class @45-FCB6E20C
}

//End Record categories_maint Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

