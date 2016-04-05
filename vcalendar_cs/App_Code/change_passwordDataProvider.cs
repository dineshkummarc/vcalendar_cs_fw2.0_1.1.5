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

namespace calendar.change_password{ //Namespace @1-5319C972

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

//Record ChangePassword Item Class @5-B5F62554
public class ChangePasswordItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField current_password;
    public TextField new_password;
    public TextField new_password_confirm;
    public NameValueCollection errors=new NameValueCollection();
    public ChangePasswordItem()
    {
        current_password=new TextField("", null);
        new_password=new TextField("", null);
        new_password_confirm=new TextField("", null);
    }

    public static ChangePasswordItem CreateFromHttpRequest()
    {
        ChangePasswordItem item = new ChangePasswordItem();
        if(DBUtility.GetInitialValue("current_password") != null){
        item.current_password.SetValue(DBUtility.GetInitialValue("current_password"));
        }
        if(DBUtility.GetInitialValue("new_password") != null){
        item.new_password.SetValue(DBUtility.GetInitialValue("new_password"));
        }
        if(DBUtility.GetInitialValue("new_password_confirm") != null){
        item.new_password_confirm.SetValue(DBUtility.GetInitialValue("new_password_confirm"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "current_password":
                    return this.current_password;
                case "new_password":
                    return this.new_password;
                case "new_password_confirm":
                    return this.new_password_confirm;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "current_password":
                    this.current_password = (TextField)value;
                    break;
                case "new_password":
                    this.new_password = (TextField)value;
                    break;
                case "new_password_confirm":
                    this.new_password_confirm = (TextField)value;
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

    public void Validate(ChangePasswordDataProvider provider)
    {
//End Record ChangePassword Item Class

//current_password validate @6-6A0CBD21
        if(current_password.Value==null||current_password.Value.ToString()=="")
            errors.Add("current_password",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.cal_current_password));
//End current_password validate

//new_password validate @7-367A106C
        if(new_password.Value==null||new_password.Value.ToString()=="")
            errors.Add("new_password",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.cal_new_password));
//End new_password validate

//Record ChangePassword Event OnValidate. Action Custom Code @13-2A29BDB7
    // -------------------------
	int Flag = 0;
	DataAccessObject DBcalendar = Settings.calendarDataAccessObject;

	if (current_password.Value != null && current_password.Value.ToString().Length > 0) {
		object UserID = DBcalendar.ExecuteScalar("SELECT user_id FROM users WHERE user_id=" + DBcalendar.ToSql(DBUtility.UserId.ToString(),FieldType.Integer) + 
				" AND user_password=" + DBcalendar.ToSql(current_password.Value.ToString(),FieldType.Text));
		if (UserID == null || (int)UserID != (int)DBUtility.UserId)
			errors.Add("current_password", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_wrong_pass"));
	}

	if (new_password.Value != null && new_password.Value.ToString().Length > 0) {
		if ((string)new_password.Value != (string)new_password_confirm.Value) {
			errors.Add("new_password_confirm", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_difpass"));
			Flag = 1;
		}

		bool passCheck = !(new Regex(@"[a-zA-Z0-9-\\_]{3,16}$",RegexOptions.IgnoreCase|RegexOptions.Multiline)).Match(new_password.Value.ToString()).Success;
		if (Flag == 0 && passCheck) {
			errors.Add("new_password", ((System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"]).GetString("cal_error_pass"));
		}
	}
   // -------------------------
//End Record ChangePassword Event OnValidate. Action Custom Code

//Record ChangePassword Item Class tail @5-F5FC18C5
    }
}
//End Record ChangePassword Item Class tail

//Record ChangePassword Data Provider Class @5-07E221E5
public class ChangePasswordDataProvider:RecordDataProviderBase
{
//End Record ChangePassword Data Provider Class

//Record ChangePassword Data Provider Class Variables @5-75E923CD
    protected ChangePasswordItem item;
    public IntegerParameter Expr18;
//End Record ChangePassword Data Provider Class Variables

//Record ChangePassword Data Provider Class Constructor @5-6A95CF58
    public ChangePasswordDataProvider()
    {
         Select=new TableCommand("SELECT TOP 1  * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"expr18"},Settings.calendarDataAccessObject);
         Update=new TableCommand("UPDATE users SET user_password={new_password}", new string[]{"expr18"},Settings.calendarDataAccessObject);
        Select.OrderBy="";
    }
//End Record ChangePassword Data Provider Class Constructor

//Record ChangePassword Data Provider Class LoadParams Method @5-C0E26390
    protected bool LoadParams()
    {
        return Expr18!=null;
    }
//End Record ChangePassword Data Provider Class LoadParams Method

//Record ChangePassword Data Provider Class CheckUnique Method @5-99F52213
    public bool CheckUnique(string ControlName,ChangePasswordItem item)
    {
        return true;
    }
//End Record ChangePassword Data Provider Class CheckUnique Method

//Record ChangePassword Data Provider Class PrepareUpdate Method @5-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record ChangePassword Data Provider Class PrepareUpdate Method

//Record ChangePassword Data Provider Class PrepareUpdate Method tail @5-FCB6E20C
    }
//End Record ChangePassword Data Provider Class PrepareUpdate Method tail

//Record ChangePassword Data Provider Class Update Method @5-94D13558
    public int UpdateItem(ChangePasswordItem item)
    {
        this.item = item;
//End Record ChangePassword Data Provider Class Update Method

//Record ChangePassword BeforeBuildUpdate @5-AA55153C
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("expr18",Expr18, "","user_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{new_password}",Update.Dao.ToSql(item.new_password.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record ChangePassword BeforeBuildUpdate

//Record ChangePassword AfterExecuteUpdate @5-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record ChangePassword AfterExecuteUpdate

//Record ChangePassword Data Provider Class GetResultSet Method @5-5149A9EA
    public void FillItem(ChangePasswordItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record ChangePassword Data Provider Class GetResultSet Method

//Record ChangePassword BeforeBuildSelect @5-598BB48F
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("expr18",Expr18, "","user_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record ChangePassword BeforeBuildSelect

//Record ChangePassword BeforeExecuteSelect @5-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record ChangePassword BeforeExecuteSelect

//Record ChangePassword AfterExecuteSelect @5-AE4D2486
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.new_password.SetValue(dr[i]["user_password"],"");
        }
        else
            IsInsertMode=true;
//End Record ChangePassword AfterExecuteSelect

//Record ChangePassword AfterExecuteSelect tail @5-FCB6E20C
    }
//End Record ChangePassword AfterExecuteSelect tail

//Record ChangePassword Data Provider Class @5-FCB6E20C
}

//End Record ChangePassword Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

