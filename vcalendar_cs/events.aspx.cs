//Using Statements @1-9FD2A1C9
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using calendar;
using calendar.Data;
using calendar.Configuration;
using calendar.Security;
using calendar.Controls;

//End Using Statements

namespace calendar.events{ //Namespace @1-AE12C0E8

//Forms Definition @1-339050F3
public partial class eventsPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-5AD318F7
    protected events_recDataProvider events_recData;
    protected NameValueCollection events_recErrors=new NameValueCollection();
    protected bool events_recIsSubmitted = false;
    protected FormSupportedOperations events_recOperations;
    protected string events_recDatePicker_event_dateName;
    protected string events_recDatePicker_event_dateDateControl;
    protected string events_recDatePicker_event_todateName;
    protected string events_recDatePicker_event_todateDateControl;
    protected System.Resources.ResourceManager rm;
    protected string eventsContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-2BA10AA4
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            events_recShow();
    }
//End Page_Load Event BeforeIsPostBack

//Page_Load Event tail @1-FCB6E20C
}
//End Page_Load Event tail

//Page_Unload Event @1-72102C7C
private void Page_Unload(object sender, System.EventArgs e)
{
//End Page_Unload Event

//Page_Unload Event tail @1-FCB6E20C
}
//End Page_Unload Event tail

//Record Form events_rec Parameters @5-369953C3
    protected void events_recParameters()
    {
        events_recItem item=events_recItem.CreateFromHttpRequest();
        try{
            events_recData.Urlevent_id = IntegerParameter.GetParam("event_id", ParameterSourceType.URL, "", null, false);
            events_recData.Seslocale = TextParameter.GetParam("locale", ParameterSourceType.Session, "", null, false);
        }catch(Exception e){
            events_recErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form events_rec Parameters

//Record Form events_rec Show method @5-D697DF4C
    protected void events_recShow()
    {
        if(events_recOperations.None)
        {
            events_recHolder.Visible=false;
            return;
        }
        events_recItem item=events_recItem.CreateFromHttpRequest();
        bool IsInsertMode=!events_recOperations.AllowRead;
        events_recErrors.Add(item.errors);
//End Record Form events_rec Show method

//Record Form events_rec BeforeShow tail @5-39B0D46A
        events_recParameters();
        events_recData.FillItem(item,ref IsInsertMode);
        events_recHolder.DataBind();
        events_recButton_Insert.Visible=IsInsertMode&&events_recOperations.AllowInsert;
        events_recButton_Update.Visible=!IsInsertMode&&events_recOperations.AllowUpdate;
        events_recButton_Delete.Visible=!IsInsertMode&&events_recOperations.AllowDelete;
        item.category_idItems.SetSelection(item.category_id.GetFormattedValue());
        events_reccategory_id.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        events_reccategory_id.Items[0].Selected = true;
        if(item.category_idItems.GetSelectedItem() != null)
            events_reccategory_id.SelectedIndex = -1;
        item.category_idItems.CopyTo(events_reccategory_id.Items);
        events_recevent_title.Text=item.event_title.GetFormattedValue();
        events_recevent_desc.Text=item.event_desc.GetFormattedValue();
        item.event_time_hrsItems.SetSelection(item.event_time_hrs.GetFormattedValue());
        if(item.event_time_hrsItems.GetSelectedItem() != null)
            events_recevent_time_hrs.SelectedIndex = -1;
        item.event_time_hrsItems.CopyTo(events_recevent_time_hrs.Items);
        item.event_time_mnsItems.SetSelection(item.event_time_mns.GetFormattedValue());
        if(item.event_time_mnsItems.GetSelectedItem() != null)
            events_recevent_time_mns.SelectedIndex = -1;
        item.event_time_mnsItems.CopyTo(events_recevent_time_mns.Items);
        item.time_hrs_endItems.SetSelection(item.time_hrs_end.GetFormattedValue());
        if(item.time_hrs_endItems.GetSelectedItem() != null)
            events_rectime_hrs_end.SelectedIndex = -1;
        item.time_hrs_endItems.CopyTo(events_rectime_hrs_end.Items);
        item.time_mns_endItems.SetSelection(item.time_mns_end.GetFormattedValue());
        if(item.time_mns_endItems.GetSelectedItem() != null)
            events_rectime_mns_end.SelectedIndex = -1;
        item.time_mns_endItems.CopyTo(events_rectime_mns_end.Items);
        if(item.alldayCheckedValue.Value.Equals(item.allday.Value))
            events_recallday.Checked = true;
        events_recevent_date.Text=item.event_date.GetFormattedValue();
        events_recDatePicker_event_dateName = "events_recDatePicker_event_date";
        events_recDatePicker_event_dateDateControl = events_recevent_date.ClientID;
        events_recDatePicker_event_date.DataBind();
        if(item.RepeatEventCheckedValue.Value.Equals(item.RepeatEvent.Value))
            events_recRepeatEvent.Checked = true;
        events_recRepeatNum.Text=item.RepeatNum.GetFormattedValue();
        item.RepeatTypeItems.SetSelection(item.RepeatType.GetFormattedValue());
        if(item.RepeatTypeItems.GetSelectedItem() != null)
            events_recRepeatType.SelectedIndex = -1;
        item.RepeatTypeItems.CopyTo(events_recRepeatType.Items);
        events_recevent_todate.Text=item.event_todate.GetFormattedValue();
        events_recDatePicker_event_todateName = "events_recDatePicker_event_todate";
        events_recDatePicker_event_todateDateControl = events_recevent_todate.ClientID;
        events_recDatePicker_event_todate.DataBind();
        if(item.event_is_publicCheckedValue.Value.Equals(item.event_is_public.Value))
            events_recevent_is_public.Checked = true;
        events_recuser_id.Value=item.user_id.GetFormattedValue();
        events_recevent_time.Value=item.event_time.GetFormattedValue();
        events_recevent_time_end.Value=item.event_time_end.GetFormattedValue();
        events_recLabelLocation.Text=Server.HtmlEncode(item.LabelLocation.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recevent_location.Text=item.event_location.GetFormattedValue();
        events_recLabelCost.Text=Server.HtmlEncode(item.LabelCost.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recevent_cost.Text=item.event_cost.GetFormattedValue();
        events_recLabelURL.Text=Server.HtmlEncode(item.LabelURL.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recevent_URL.Text=item.event_URL.GetFormattedValue();
        events_recLabelTextBox1.Text=Server.HtmlEncode(item.LabelTextBox1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recTextBox1.Text=item.TextBox1.GetFormattedValue();
        events_recLabelTextBox2.Text=Server.HtmlEncode(item.LabelTextBox2.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recTextBox2.Text=item.TextBox2.GetFormattedValue();
        events_recLabelTextBox3.Text=Server.HtmlEncode(item.LabelTextBox3.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recTextBox3.Text=item.TextBox3.GetFormattedValue();
        events_recLabelTextArea1.Text=Server.HtmlEncode(item.LabelTextArea1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recTextArea1.Text=item.TextArea1.GetFormattedValue();
        events_recLabelTextArea2.Text=Server.HtmlEncode(item.LabelTextArea2.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recTextArea2.Text=item.TextArea2.GetFormattedValue();
        events_recLabelTextArea3.Text=Server.HtmlEncode(item.LabelTextArea3.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        events_recTextArea3.Text=item.TextArea3.GetFormattedValue();
        events_recLabelCheckBox1.Text=Server.HtmlEncode(item.LabelCheckBox1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        if(item.CheckBox1CheckedValue.Value.Equals(item.CheckBox1.Value))
            events_recCheckBox1.Checked = true;
        events_recLabelCheckBox2.Text=Server.HtmlEncode(item.LabelCheckBox2.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        if(item.CheckBox2CheckedValue.Value.Equals(item.CheckBox2.Value))
            events_recCheckBox2.Checked = true;
        events_recLabelCheckBox3.Text=Server.HtmlEncode(item.LabelCheckBox3.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        if(item.CheckBox3CheckedValue.Value.Equals(item.CheckBox3.Value))
            events_recCheckBox3.Checked = true;
        if(item.RecurrentApplyCheckedValue.Value.Equals(item.RecurrentApply.Value))
            events_recRecurrentApply.Checked = true;
        events_recevent_parent_id.Value=item.event_parent_id.GetFormattedValue();
//End Record Form events_rec BeforeShow tail

//Button Button_Delete Event BeforeShow. Action Custom Code @34-2A29BDB7
    // -------------------------
	if (!CommonFunctions.DeleteAllowed(Convert.ToInt32(CommonFunctions.CCGetFromGet("event_id","0")))) {
		events_recButton_Delete.Visible = false;
	}
    // -------------------------
//End Button Button_Delete Event BeforeShow. Action Custom Code

//Record events_rec Event BeforeShow. Action Custom Code @19-2A29BDB7
    // -------------------------
    if (CommonFunctions.str_calendar_config("time_format") == "2" || (CommonFunctions.str_calendar_config("time_format") == "1" && System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern == "HH\\:mm"))
    {
		events_rectime_hrs_end.Items.Clear();
		events_recevent_time_hrs.Items.Clear();
		for (int i = 0; i < 24; i++)
		{
			string dig = (i < 10 ? "0" : "") + i;
			events_rectime_hrs_end.Items.Add(new ListItem(dig, dig));
			events_recevent_time_hrs.Items.Add(new ListItem(dig, dig));
		}
	}

	string EventID = CommonFunctions.CCGetFromGet("event_id", "");

	string RedirectUrl = "";

	if (!events_recIsSubmitted) {
		string str = events_recevent_time.Value;

		if (str.Length > 0) {
			events_recallday.Checked = false;
			events_recevent_time_hrs.Value = str.Substring(0, 2);
			events_recevent_time_mns.Value = str.Substring(3, 2);
		} else {
			events_recallday.Checked = true;
		}

		str = events_recevent_time_end.Value;
		if (str.Length > 0) {
			events_rectime_hrs_end.Value = str.Substring(0, 2);
			events_rectime_mns_end.Value = str.Substring(3, 2);
		}

		if (EventID.Length == 0)
			events_reccategory_id.Value = (string)System.Web.HttpContext.Current.Session["category"];

		if (events_recevent_URL.Text.Length == 0)
			events_recevent_URL.Text = "http://";
	}

	CommonFunctions.processCustomFields(events_recHolder, events_recHolder.ID.Substring(0,events_recHolder.ID.Length-6));

	if (EventID.Length > 0) {
		events_recRepeatEventPanel.Visible = false;
		if (events_recevent_parent_id.Value.Length == 0) {
			EventID = CommonFunctions.CCDLookUp("count(event_id)", "events", "event_parent_id = " + EventID, Settings.calendarDataAccessObject).ToString();
			if (EventID == "0")
				events_recPanelRecurrentSubmit.Visible = false;
		}
	} else
		events_recPanelRecurrentSubmit.Visible = false;
	// -------------------------
//End Record events_rec Event BeforeShow. Action Custom Code

//Record Form events_rec Show method tail @5-555CBC04
        if(events_recErrors.Count>0)
            events_recShowErrors();
    }
//End Record Form events_rec Show method tail

//Record Form events_rec LoadItemFromRequest method @5-8EE15575
    protected void events_recLoadItemFromRequest(events_recItem item, bool EnableValidation)
    {
        try{
        item.category_id.SetValue(events_reccategory_id.Value);
        item.category_idItems.CopyFrom(events_reccategory_id.Items);
        }catch(ArgumentException){
            events_recErrors.Add("category_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.cal_category));}
        item.event_title.SetValue(events_recevent_title.Text);
        item.event_desc.SetValue(events_recevent_desc.Text);
        item.event_time_hrs.SetValue(events_recevent_time_hrs.Value);
        item.event_time_hrsItems.CopyFrom(events_recevent_time_hrs.Items);
        item.event_time_mns.SetValue(events_recevent_time_mns.Value);
        item.event_time_mnsItems.CopyFrom(events_recevent_time_mns.Items);
        item.time_hrs_end.SetValue(events_rectime_hrs_end.Value);
        item.time_hrs_endItems.CopyFrom(events_rectime_hrs_end.Items);
        item.time_mns_end.SetValue(events_rectime_mns_end.Value);
        item.time_mns_endItems.CopyFrom(events_rectime_mns_end.Items);
        item.allday.Value = events_recallday.Checked ?(item.alldayCheckedValue.Value):(item.alldayUncheckedValue.Value);
        try{
        item.event_date.SetValue(events_recevent_date.Text);
        }catch(ArgumentException){
            events_recErrors.Add("event_date",String.Format(Resources.strings.CCS_IncorrectFormat,Resources.strings.event_date,@"ShortDate"));}
        item.RepeatEvent.IsEmpty = Request.Form[events_recRepeatEvent.UniqueID]==null;
        item.RepeatEvent.Value = events_recRepeatEvent.Checked ?(item.RepeatEventCheckedValue.Value):(item.RepeatEventUncheckedValue.Value);
        item.RepeatNum.SetValue(events_recRepeatNum.Text);
        item.RepeatType.SetValue(events_recRepeatType.Value);
        item.RepeatTypeItems.CopyFrom(events_recRepeatType.Items);
        try{
        item.event_todate.SetValue(events_recevent_todate.Text);
        }catch(ArgumentException){
            events_recErrors.Add("event_todate",String.Format(Resources.strings.CCS_IncorrectFormat,Resources.strings.End_By,@"ShortDate"));}
        item.event_is_public.Value = events_recevent_is_public.Checked ?(item.event_is_publicCheckedValue.Value):(item.event_is_publicUncheckedValue.Value);
        try{
        item.user_id.SetValue(events_recuser_id.Value);
        }catch(ArgumentException){
            events_recErrors.Add("user_id",String.Format(Resources.strings.CCS_IncorrectValue,"user_id"));}
        try{
        item.event_time.SetValue(events_recevent_time.Value);
        }catch(ArgumentException){
            events_recErrors.Add("event_time",String.Format(Resources.strings.CCS_IncorrectFormat,"event_time",@"HH:nn"));}
        try{
        item.event_time_end.SetValue(events_recevent_time_end.Value);
        }catch(ArgumentException){
            events_recErrors.Add("event_time_end",String.Format(Resources.strings.CCS_IncorrectFormat,"event_time_end",@"HH:nn"));}
        item.event_location.IsEmpty = Request.Form[events_recevent_location.UniqueID]==null;
        item.event_location.SetValue(events_recevent_location.Text);
        item.event_cost.IsEmpty = Request.Form[events_recevent_cost.UniqueID]==null;
        item.event_cost.SetValue(events_recevent_cost.Text);
        item.event_URL.IsEmpty = Request.Form[events_recevent_URL.UniqueID]==null;
        item.event_URL.SetValue(events_recevent_URL.Text);
        item.TextBox1.IsEmpty = Request.Form[events_recTextBox1.UniqueID]==null;
        item.TextBox1.SetValue(events_recTextBox1.Text);
        item.TextBox2.IsEmpty = Request.Form[events_recTextBox2.UniqueID]==null;
        item.TextBox2.SetValue(events_recTextBox2.Text);
        item.TextBox3.IsEmpty = Request.Form[events_recTextBox3.UniqueID]==null;
        item.TextBox3.SetValue(events_recTextBox3.Text);
        item.TextArea1.IsEmpty = Request.Form[events_recTextArea1.UniqueID]==null;
        item.TextArea1.SetValue(events_recTextArea1.Text);
        item.TextArea2.IsEmpty = Request.Form[events_recTextArea2.UniqueID]==null;
        item.TextArea2.SetValue(events_recTextArea2.Text);
        item.TextArea3.IsEmpty = Request.Form[events_recTextArea3.UniqueID]==null;
        item.TextArea3.SetValue(events_recTextArea3.Text);
        item.CheckBox1.IsEmpty = Request.Form[events_recCheckBox1.UniqueID]==null;
        item.CheckBox1.Value = events_recCheckBox1.Checked ?(item.CheckBox1CheckedValue.Value):(item.CheckBox1UncheckedValue.Value);
        item.CheckBox2.IsEmpty = Request.Form[events_recCheckBox2.UniqueID]==null;
        item.CheckBox2.Value = events_recCheckBox2.Checked ?(item.CheckBox2CheckedValue.Value):(item.CheckBox2UncheckedValue.Value);
        item.CheckBox3.IsEmpty = Request.Form[events_recCheckBox3.UniqueID]==null;
        item.CheckBox3.Value = events_recCheckBox3.Checked ?(item.CheckBox3CheckedValue.Value):(item.CheckBox3UncheckedValue.Value);
        item.RecurrentApply.IsEmpty = Request.Form[events_recRecurrentApply.UniqueID]==null;
        item.RecurrentApply.Value = events_recRecurrentApply.Checked ?(item.RecurrentApplyCheckedValue.Value):(item.RecurrentApplyUncheckedValue.Value);
        item.event_parent_id.IsEmpty = Request.Form[events_recevent_parent_id.UniqueID]==null;
        item.event_parent_id.SetValue(events_recevent_parent_id.Value);
        if(EnableValidation)
            item.Validate(events_recData);
        events_recErrors.Add(item.errors);
    }
//End Record Form events_rec LoadItemFromRequest method

//Record Form events_rec GetRedirectUrl method @5-F6DDE1F7
    protected string Getevents_recRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "index.aspx";
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form events_rec GetRedirectUrl method

//Record Form events_rec ShowErrors method @5-4030BA1C
    protected void events_recShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<events_recErrors.Count;i++)
        switch(events_recErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=events_recErrors[i];
                break;
        }
        events_recError.Visible = true;
        events_recErrorLabel.Text = DefaultMessage;
    }
//End Record Form events_rec ShowErrors method

//Record Form events_rec Insert Operation @5-3C0C793B
    protected void events_rec_Insert(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        events_recIsSubmitted = true;
        bool ErrorFlag = false;
        events_recItem item=new events_recItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form events_rec Insert Operation

//Button Button_Insert OnClick. @6-5E24DB24
        if(((Control)sender).ID == "events_recButton_Insert")
        {
            RedirectUrl  = Getevents_recRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Insert OnClick.

//Button Button_Insert OnClick tail. @6-FCB6E20C
        }
//End Button Button_Insert OnClick tail.

//Record events_rec Event BeforeInsert. Action Custom Code @20-2A29BDB7
    // -------------------------
	if (events_recallday.Checked) {
		events_recevent_time.Value = "";
		events_recevent_time_end.Value = "";
	} else {
		events_recevent_time.Value = events_recevent_time_hrs.Value + ":" + events_recevent_time_mns.Value;
		events_recevent_time_end.Value = events_rectime_hrs_end.Value + ":" + events_rectime_mns_end.Value;
	}

	if (Convert.ToInt32(DBUtility.UserId) > 0) {
		events_recuser_id.Value = DBUtility.UserId.ToString();
	}

	if (events_recevent_URL.Text.Trim().ToLower() == "http://")
		events_recevent_URL.Text = "";
	RedirectUrl = CommonFunctions.CCGetFromGet("ret_link",RedirectUrl);
    // -------------------------
//End Record events_rec Event BeforeInsert. Action Custom Code

//Record Form events_rec BeforeInsert tail @5-A72D2FF0
    events_recParameters();
    events_recLoadItemFromRequest(item, EnableValidation);
    if(events_recOperations.AllowInsert){
    ErrorFlag=(events_recErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                events_recData.InsertItem(item);
            }
            catch (Exception ex)
            {
                events_recErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form events_rec BeforeInsert tail

//Record Form events_rec AfterInsert tail  @5-12F6D26C
        }
        ErrorFlag=(events_recErrors.Count>0);
        if(ErrorFlag)
            events_recShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form events_rec AfterInsert tail 

//Record Form events_rec Update Operation @5-059575E5
    protected void events_rec_Update(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        events_recItem item=new events_recItem();
        item.IsNew = false;
        events_recIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form events_rec Update Operation

//Button Button_Update OnClick. @7-E84597A6
        if(((Control)sender).ID == "events_recButton_Update")
        {
            RedirectUrl  = Getevents_recRedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @7-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record events_rec Event BeforeUpdate. Action Custom Code @32-2A29BDB7
    // -------------------------
	if (events_recallday.Checked) {
		events_recevent_time.Value = "";
		events_recevent_time_end.Value = "";
	} else {
		events_recevent_time.Value = events_recevent_time_hrs.Value + ":" + events_recevent_time_mns.Value;
		events_recevent_time_end.Value = events_rectime_hrs_end.Value + ":" + events_rectime_mns_end.Value;
	}

	if (events_recevent_URL.Text.Trim().ToLower() == "http://")
		events_recevent_URL.Text = "";
    // -------------------------
//End Record events_rec Event BeforeUpdate. Action Custom Code

//Record Form events_rec Before Update tail @5-AD74212A
        events_recParameters();
        events_recLoadItemFromRequest(item, EnableValidation);
        if(events_recOperations.AllowUpdate){
        ErrorFlag=(events_recErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                events_recData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                events_recErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form events_rec Before Update tail

//Record Form events_rec Update Operation tail @5-12F6D26C
        }
        ErrorFlag=(events_recErrors.Count>0);
        if(ErrorFlag)
            events_recShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form events_rec Update Operation tail

//Record Form events_rec Delete Operation @5-10CFF2EF
    protected void events_rec_Delete(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        bool ExecuteFlag = true;
        events_recIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        events_recItem item=new events_recItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form events_rec Delete Operation

//Button Button_Delete OnClick. @8-6366C42B
        if(((Control)sender).ID == "events_recButton_Delete")
        {
            RedirectUrl  = Getevents_recRedirectUrl("", "");
            EnableValidation  = false;
//End Button Button_Delete OnClick.

//Button Button_Delete OnClick tail. @8-FCB6E20C
        }
//End Button Button_Delete OnClick tail.

//Record Form BeforeDelete tail @5-45CAC07E
        events_recParameters();
        events_recLoadItemFromRequest(item, EnableValidation);
        if(events_recOperations.AllowDelete){
        ErrorFlag = (events_recErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                events_recData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                events_recErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @5-75334979
        }
        if(ErrorFlag)
            events_recShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form events_rec Cancel Operation @5-C3E7C24C
    protected void events_rec_Cancel(object sender,System.Web.UI.ImageClickEventArgs e)
    {
        events_recItem item=new events_recItem();
        events_recIsSubmitted = true;
        string RedirectUrl = "";
        events_recLoadItemFromRequest(item, false);
//End Record Form events_rec Cancel Operation

//Button Button_Cancel OnClick. @81-8D1F2B49
    if(((Control)sender).ID == "events_recButton_Cancel")
    {
        RedirectUrl  = Getevents_recRedirectUrl("", "");
//End Button Button_Cancel OnClick.

//Button Button_Cancel Event OnClick. Action Custom Code @82-2A29BDB7
    // -------------------------
		RedirectUrl = CommonFunctions.CCGetFromGet("ret_link", RedirectUrl);
    // -------------------------
//End Button Button_Cancel Event OnClick. Action Custom Code

//Button Button_Cancel OnClick tail. @81-FCB6E20C
    }
//End Button Button_Cancel OnClick tail.

//Record Form events_rec Cancel Operation tail @5-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form events_rec Cancel Operation tail

//OnInit Event @1-6057C1BA
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        eventsContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        events_recData = new events_recDataProvider();
        events_recOperations = new FormSupportedOperations(false, true, true, true, true);
//End OnInit Event

//Page events Event AfterInitialize. Action Custom Code @21-2A29BDB7
    // -------------------------
		string RedirectUrl = "";
		string event_id = CommonFunctions.CCGetFromGet("event_id", "");
		if (event_id.Length > 0) {
		//Edit mode
			if (!CommonFunctions.EditAllowed(Convert.ToInt32(event_id))) {
				RedirectUrl = CommonFunctions.CCGetFromGet("ret_link","index.aspx");
			}
		} else {
		//Add mode
			if (!CommonFunctions.AddAllowed()) {
				RedirectUrl = CommonFunctions.CCGetFromGet("ret_link","index.aspx");
			}
		}
		if (RedirectUrl != "") Response.Redirect(RedirectUrl);
    // -------------------------
//End Page events Event AfterInitialize. Action Custom Code

//OnInit Event tail @1-CF19F5CD
        PageStyleName = Server.UrlEncode(PageStyleName);
    }
//End OnInit Event tail

//InitializeComponent Event @1-722FC1EE
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
    }
    #endregion
//End InitializeComponent Event

//Page class tail @1-F5FC18C5
}
}
//End Page class tail

