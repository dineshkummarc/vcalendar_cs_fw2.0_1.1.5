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

namespace calendar.admin.email_templates{ //Namespace @1-0951ED95

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

//Grid email_templates Item Class @2-A2877B56
public class email_templatesItem:IDataItem
{
    public IntegerField email_template_id;
    public TextField email_template_subject;
    public object email_template_subjectHref;
    public LinkParameterCollection email_template_subjectHrefParameters;
    public TextField email_template_type;
    public TextField email_template_desc;
    public TextField email_template_from;
    public TextField translations;
    public object translationsHref;
    public LinkParameterCollection translationsHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public email_templatesItem()
    {
        email_template_id=new IntegerField("", null);
        email_template_subject = new TextField("",null);
        email_template_subjectHrefParameters = new LinkParameterCollection();
        email_template_type=new TextField("", null);
        email_template_desc=new TextField("", null);
        email_template_from=new TextField("", null);
        translations = new TextField("",null);
        translationsHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "email_template_id":
                    return this.email_template_id;
                case "email_template_subject":
                    return this.email_template_subject;
                case "email_template_type":
                    return this.email_template_type;
                case "email_template_desc":
                    return this.email_template_desc;
                case "email_template_from":
                    return this.email_template_from;
                case "translations":
                    return this.translations;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "email_template_id":
                    this.email_template_id = (IntegerField)value;
                    break;
                case "email_template_subject":
                    this.email_template_subject = (TextField)value;
                    break;
                case "email_template_type":
                    this.email_template_type = (TextField)value;
                    break;
                case "email_template_desc":
                    this.email_template_desc = (TextField)value;
                    break;
                case "email_template_from":
                    this.email_template_from = (TextField)value;
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
//End Grid email_templates Item Class

//Grid email_templates Data Provider Class Header @2-74F358E2
public class email_templatesDataProvider:GridDataProviderBase
{
//End Grid email_templates Data Provider Class Header

//Grid email_templates Data Provider Class Variables @2-1D6511DD
    public enum SortFields {Default,Sorter_email_template_id,Sorter_email_template_subject,Sorter_email_template_type,Sorter_email_template_desc,Sorter_email_template_from}
    private string[] SortFieldsNames=new string[]{"","email_template_id","email_templates_lang.email_template_subject","email_template_type","email_templates_lang.email_template_desc","email_template_from"};
    private string[] SortFieldsNamesDesc=new string[]{"","email_template_id DESC","email_templates_lang.email_template_subject DESC","email_template_type DESC","email_templates_lang.email_template_desc DESC","email_template_from DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=20;
    public int PageNumber=1;
    public TextParameter Seslocale;
//End Grid email_templates Data Provider Class Variables

//Grid email_templates Data Provider Class Constructor @2-D1318112
    public email_templatesDataProvider()
    {
         Select=new TableCommand("SELECT TOP {SqlParam_endRecord}  email_templates.email_template_id AS email_templates_emai" +
          "l_template_id, email_template_type, email_template_from, \n" +
          "email_templates_lang.email_template_desc AS email_templates_lang_email_template_desc,\n" +
          "email_templates_lang.email_template_subject AS email_templates_lang_email_template_subject" +
          " \n" +
          "FROM email_templates_lang INNER JOIN email_templates ON\n" +
          "email_templates_lang.email_template_id = email_templates.email_template_id {SQL_Where} {SQ" +
          "L_OrderBy}", new string[]{"locale82"},Settings.calendarDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM email_templates_lang INNER JOIN email_templates ON\n" +
          "email_templates_lang.email_template_id = email_templates.email_template_id", new string[]{"locale82"},Settings.calendarDataAccessObject);
    }
//End Grid email_templates Data Provider Class Constructor

//Grid email_templates Data Provider Class GetResultSet Method @2-ACE13558
    public email_templatesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid email_templates Data Provider Class GetResultSet Method

//Before build Select @2-7B23B6D1
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale82",Seslocale, "","email_templates_lang.language_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Select.SqlQuery.Replace("{SqlParam_endRecord}",
            (PageNumber*RecordsPerPage).ToString(),
            0,
            Select.SqlQuery.ToString().IndexOf("{SqlParam_endRecord}")+21);
        Exception E=null;
//End Before build Select

//Execute Select @2-D606BEEA
        DataSet ds=null;
        _pagesCount=0;
        email_templatesItem[] result = new email_templatesItem[0];
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

//After execute Select @2-50D870F0
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new email_templatesItem[dr.Count];
//End After execute Select

//After execute Select tail @2-5776CA9B
            for(int i=0;i<dr.Count;i++)
            {
                email_templatesItem item=new email_templatesItem();
                item.email_template_id.SetValue(dr[i]["email_templates_email_template_id"],"");
                item.email_template_subject.SetValue(dr[i]["email_templates_lang_email_template_subject"],"");
                item.email_template_subjectHref = "email_templates_maint.aspx";
                item.email_template_subjectHrefParameters.Add("email_template_id",System.Web.HttpUtility.UrlEncode(dr[i]["email_templates_email_template_id"].ToString()));
                item.email_template_type.SetValue(dr[i]["email_template_type"],"");
                item.email_template_desc.SetValue(dr[i]["email_templates_lang_email_template_desc"],"");
                item.email_template_from.SetValue(dr[i]["email_template_from"],"");
                item.translationsHref = "email_templates_lang.aspx";
                item.translationsHrefParameters.Add("email_template_id",System.Web.HttpUtility.UrlEncode(dr[i]["email_templates_email_template_id"].ToString()));
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @2-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

