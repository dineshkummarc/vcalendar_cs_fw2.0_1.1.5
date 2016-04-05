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

namespace calendar.admin.email_templates_maint{ //Namespace @1-F3646366

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

//Record email_templates Item Class @2-52074FF9
public class email_templatesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField email_template_type;
    public TextField email_template_desc;
    public TextField email_template_from;
    public TextField email_template_subject;
    public MemoField email_template_body;
    public NameValueCollection errors=new NameValueCollection();
    public email_templatesItem()
    {
        email_template_type=new TextField("", null);
        email_template_desc=new TextField("", null);
        email_template_from=new TextField("", null);
        email_template_subject=new TextField("", null);
        email_template_body=new MemoField("", null);
    }

    public static email_templatesItem CreateFromHttpRequest()
    {
        email_templatesItem item = new email_templatesItem();
        if(DBUtility.GetInitialValue("email_template_type") != null){
        item.email_template_type.SetValue(DBUtility.GetInitialValue("email_template_type"));
        }
        if(DBUtility.GetInitialValue("email_template_desc") != null){
        item.email_template_desc.SetValue(DBUtility.GetInitialValue("email_template_desc"));
        }
        if(DBUtility.GetInitialValue("email_template_from") != null){
        item.email_template_from.SetValue(DBUtility.GetInitialValue("email_template_from"));
        }
        if(DBUtility.GetInitialValue("email_template_subject") != null){
        item.email_template_subject.SetValue(DBUtility.GetInitialValue("email_template_subject"));
        }
        if(DBUtility.GetInitialValue("email_template_body") != null){
        item.email_template_body.SetValue(DBUtility.GetInitialValue("email_template_body"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "email_template_type":
                    return this.email_template_type;
                case "email_template_desc":
                    return this.email_template_desc;
                case "email_template_from":
                    return this.email_template_from;
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
                case "email_template_type":
                    this.email_template_type = (TextField)value;
                    break;
                case "email_template_desc":
                    this.email_template_desc = (TextField)value;
                    break;
                case "email_template_from":
                    this.email_template_from = (TextField)value;
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

    public void Validate(email_templatesDataProvider provider)
    {
//End Record email_templates Item Class

//email_template_subject validate @6-3CA2C938
        if(email_template_subject.Value==null||email_template_subject.Value.ToString()=="")
            errors.Add("email_template_subject",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.email_template_subject));
//End email_template_subject validate

//Record email_templates Item Class tail @2-F5FC18C5
    }
}
//End Record email_templates Item Class tail

//Record email_templates Data Provider Class @2-795A8E19
public class email_templatesDataProvider:RecordDataProviderBase
{
//End Record email_templates Data Provider Class

//Record email_templates Data Provider Class Variables @2-A7AA6BA3
    protected email_templatesItem item;
    public TextParameter Seslocale;
    public IntegerParameter Urlemail_template_id;
    public TextParameter Ctrlemail_template_from;
//End Record email_templates Data Provider Class Variables

//Record email_templates Data Provider Class Constructor @2-D6CEADEA
    public email_templatesDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  email_templates_lang.email_template_body AS email_templates_lang_email_templ" +
          "ate_body, \n" +
          "email_templates_lang.email_template_subject AS email_templates_lang_email_template_subject" +
          ",\n" +
          "email_templates_lang.email_template_desc AS email_templates_lang_email_template_desc, emai" +
          "l_template_type, email_template_from \n" +
          "FROM email_templates_lang INNER JOIN email_templates ON\n" +
          "email_templates_lang.email_template_id = email_templates.email_template_id {SQL_Where} {SQ" +
          "L_OrderBy}", new string[]{"email_template_id12","And","locale21"},Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE email_templates SET email_template_from={email_template_from}", new string[]{"email_template_id34"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record email_templates Data Provider Class Constructor

//Record email_templates Data Provider Class LoadParams Method @2-B238C5FE
    protected bool LoadParams()
    {
        return Urlemail_template_id!=null&&Seslocale!=null;
    }
//End Record email_templates Data Provider Class LoadParams Method

//Record email_templates Data Provider Class CheckUnique Method @2-6A90740F
    public bool CheckUnique(string ControlName,email_templatesItem item)
    {
        return true;
    }
//End Record email_templates Data Provider Class CheckUnique Method

//Record email_templates Data Provider Class PrepareUpdate Method @2-771F32A3
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = Urlemail_template_id!=null;
//End Record email_templates Data Provider Class PrepareUpdate Method

//Record email_templates Data Provider Class PrepareUpdate Method tail @2-FCB6E20C
    }
//End Record email_templates Data Provider Class PrepareUpdate Method tail

//Record email_templates Data Provider Class Update Method @2-0E935B29
    public int UpdateItem(email_templatesItem item)
    {
        this.item = item;
//End Record email_templates Data Provider Class Update Method

//Record email_templates BeforeBuildUpdate @2-20445152
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("email_template_id34",Urlemail_template_id, "","email_templates.email_template_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{email_template_from}",Update.Dao.ToSql(item.email_template_from.Value==null?null:item.email_template_from.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record email_templates BeforeBuildUpdate

//Record email_templates AfterExecuteUpdate @2-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record email_templates AfterExecuteUpdate

//Record email_templates Data Provider Class GetResultSet Method @2-C5D9A184
    public void FillItem(email_templatesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record email_templates Data Provider Class GetResultSet Method

//Record email_templates BeforeBuildSelect @2-4F0FE4B3
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("email_template_id12",Urlemail_template_id, "","email_templates.email_template_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("locale21",Seslocale, "","email_templates_lang.language_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record email_templates BeforeBuildSelect

//Record email_templates BeforeExecuteSelect @2-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record email_templates BeforeExecuteSelect

//Record email_templates AfterExecuteSelect @2-59C96855
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.email_template_type.SetValue(dr[i]["email_template_type"],"");
            item.email_template_desc.SetValue(dr[i]["email_templates_lang_email_template_desc"],"");
            item.email_template_from.SetValue(dr[i]["email_template_from"],"");
            item.email_template_subject.SetValue(dr[i]["email_templates_lang_email_template_subject"],"");
            item.email_template_body.SetValue(dr[i]["email_templates_lang_email_template_body"],"");
        }
        else
            IsInsertMode=true;
//End Record email_templates AfterExecuteSelect

//Record email_templates AfterExecuteSelect tail @2-FCB6E20C
    }
//End Record email_templates AfterExecuteSelect tail

//Record email_templates Data Provider Class @2-FCB6E20C
}

//End Record email_templates Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

