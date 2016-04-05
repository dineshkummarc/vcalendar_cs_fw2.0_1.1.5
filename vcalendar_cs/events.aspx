<!--ASPX page @1-6EF86B88-->
<%@ Page language="c#" CodeFile="events.aspx.cs" AutoEventWireup="false" Inherits="calendar.events.eventsPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.events" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="vertical_menu" Src="vertical_menu.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=eventsContentMeta%>">

<title><%=Resources.strings.CCS_RecordFormPrefix%> <%=Resources.strings.events%></title>

<meta content="CodeCharge Studio 3.0.1.5" name="GENERATOR">
<script language="JavaScript" type="text/javascript">
var AllDayState;
var RepeatState;

window.onload = function() {
        AllDayState = document.getElementById("events_recallday").checked;
        changestate();
        document.getElementById("events_recallday").onclick = function() {
                AllDayState = !AllDayState;
                changestate();
        }

        if (document.getElementById("events_recRepeatEvent")) {
                RepeatState = document.getElementById("events_recRepeatEvent").checked;
                HideShowRepeat();
                document.getElementById("events_recRepeatEvent").onclick = function() {
                        RepeatState = !RepeatState;
                        HideShowRepeat();
                }
        }
        CorrectEndTime("hrs");
}

function changestate() {
        if (AllDayState) {
                document.getElementById("events_recevent_time_hrs").disabled = true;
                document.getElementById("events_recevent_time_mns").disabled = true;
                document.getElementById("events_rectime_hrs_end").disabled = true;
                document.getElementById("events_rectime_mns_end").disabled = true;
        } else {
                document.getElementById("events_recevent_time_hrs").disabled = false;
                document.getElementById("events_recevent_time_mns").disabled = false;
                document.getElementById("events_rectime_hrs_end").disabled = false;
                document.getElementById("events_rectime_mns_end").disabled = false;
        }
}

function HideShowRepeat() {
        if (RepeatState) {
                document.getElementById("RepeatRow1").style.display = "";
                document.getElementById("RepeatRow2").style.display = "";
        } else {
                document.getElementById("RepeatRow1").style.display = "none";
                document.getElementById("RepeatRow2").style.display = "none";
        }
}

function CorrectListBoxVal(Type, flag) {
        var HourStartComp = document.getElementById("events_recevent_time_" + Type);
        var HourEndComp = document.getElementById("events_rectime_" + Type + "_end");

        var CurrStartTime = flag? HourStartComp.selectedIndex : 0;
        var SelEndTime = HourEndComp.selectedIndex;
        var EndTimeLength = HourEndComp.options.length;
        var StartTimeLength = HourStartComp.options.length;

        for (var i=0; i<EndTimeLength; i++)
                HourEndComp.options[0] = null;
        for (i = CurrStartTime; i<StartTimeLength; i++)
                HourEndComp.options[i-CurrStartTime] = new Option(HourStartComp.options[i].text, HourStartComp.options[i].value);

        if (SelEndTime-CurrStartTime+StartTimeLength-EndTimeLength < 0)
                HourEndComp.options[0].selected = true;
        else
                HourEndComp.options[SelEndTime-CurrStartTime+StartTimeLength-EndTimeLength].selected = true;
}

function CorrectEndTime(Type) {
        if (Type == "hrs");
                CorrectListBoxVal("hrs", true);

        var HourStartComp = document.getElementById("events_recevent_time_hrs");
        var HourEndComp = document.getElementById("events_rectime_hrs_end");

        var CurrStartHour = HourStartComp.options.length - HourStartComp.selectedIndex;
        var CurrEndHour = HourEndComp.options.length - HourEndComp.selectedIndex;

        CorrectListBoxVal("mns", CurrStartHour == CurrEndHour);
}
</script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-098C6D15
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-E6DE1018

var events_recDatePicker_event_date = new Object(); 
events_recDatePicker_event_date.format           = "ShortDate";
events_recDatePicker_event_date.style            = "Styles/<%=PageStyleName%>/Style.css";
events_recDatePicker_event_date.relativePathPart = "";
events_recDatePicker_event_date.themeVersion     = "3.0";
var events_recDatePicker_event_todate = new Object(); 
events_recDatePicker_event_todate.format           = "ShortDate";
events_recDatePicker_event_todate.style            = "Styles/<%=PageStyleName%>/Style.css";
events_recDatePicker_event_todate.relativePathPart = "";
events_recDatePicker_event_todate.themeVersion     = "3.0";
//End Date Picker Object Definitions

//End CCS script
</script>

<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 
<table cellspacing="5" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <!-- Left column -->
      <calendar:vertical_menu id="vertical_menu" runat="server"/></td> 
    <td valign="top">
      <!-- Right column -->
      
  <span id="events_recHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.CCS_RecordFormPrefix%> <%=Resources.strings.events%>
                  <%=Resources.strings.CCS_RecordFormSuffix%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                </tr>
 
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="events_recError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="events_recErrorLabel" runat="server"/></td> 
                </tr>
 
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.cal_category%></th>
 
                  <td>
                    <select id="events_reccategory_id"  runat="server"></select>
 </td> 
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.event_title%>&nbsp;*</th>
 
                  <td><asp:TextBox id="events_recevent_title" maxlength="100" Columns="50"

	runat="server"/></td> 
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.event_desc%>&nbsp;</th>
 
                  <td>
<asp:TextBox id="events_recevent_desc" rows="5" Columns="50" TextMode="MultiLine"

	runat="server"/>
</td> 
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.event_time%></th>
 
                  <td>
                    <select id="events_recevent_time_hrs" onchange="CorrectEndTime('hrs');"  runat="server"></select>
 : 
                    <select id="events_recevent_time_mns" onchange="CorrectEndTime('');"  runat="server"></select>
 </td> 
                </tr>
 
                <tr class="Controls" valign="top">
                  <th><%=Resources.strings.cal_time_end%></th>
 
                  <td>
                    <select id="events_rectime_hrs_end" onchange="CorrectEndTime('');"  runat="server"></select>
 : 
                    <select id="events_rectime_mns_end"  runat="server"></select>
 <br>
                    <span nowrap><asp:CheckBox id="events_recallday" runat="server"/><%=Resources.strings.cal_all_day%> </span></td> 
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.event_date%>&nbsp;*</th>
 
                  <td><asp:TextBox id="events_recevent_date" maxlength="10" Columns="10"

	runat="server"/>
                    <asp:PlaceHolder id="events_recDatePicker_event_date" runat="server"><a href="javascript:showDatePicker('<%#events_recDatePicker_event_dateName%>','forms[\''+theForm.id+'\']','<%#events_recDatePicker_event_dateDateControl%>');" ><img src='<%#"Styles/" + PageStyleName + "/Images/DatePicker.gif"%>' border="0" /></a></asp:PlaceHolder>
  <br>
                  </td> 
                </tr>

                                <asp:PlaceHolder id="events_recRepeatEventPanel" Visible="True" runat="server">
	
                                <tr class="Controls">
                                  <th><%=Resources.strings.Recurrence%>&nbsp;</th>
                                  <td><asp:CheckBox id="events_recRepeatEvent" runat="server"/></td> 
                                </tr>
                                
	</asp:PlaceHolder>

                                <tr id="RepeatRow1" class="Controls" style="display:none">
                  <th style="border-bottom:none;text-align:right">&nbsp;<%=Resources.strings.Every%></th>
 
                  <td style="border-bottom:none"><span nowrap><asp:TextBox id="events_recRepeatNum" Columns="5" maxlength="5"

	runat="server"/>
                    <select id="events_recRepeatType"  runat="server"></select>
                    </span> </td> 
                </tr>
                <tr id="RepeatRow2" class="Controls" style="display:none">
                  <th style="border-top:none;text-align:right">&nbsp;<%=Resources.strings.End_By%></th>
 
                  <td style="border-top:none"><span nowrap><asp:TextBox id="events_recevent_todate" maxlength="10" Columns="10"

	runat="server"/>
                    <asp:PlaceHolder id="events_recDatePicker_event_todate" runat="server"><a href="javascript:showDatePicker('<%#events_recDatePicker_event_todateName%>','forms[\''+theForm.id+'\']','<%#events_recDatePicker_event_todateDateControl%>');" ><img src='<%#"Styles/" + PageStyleName + "/Images/DatePicker.gif"%>' border="0" /></a></asp:PlaceHolder>
  </span></td> 
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.event_is_public%></th>
 
                  <td><asp:CheckBox id="events_recevent_is_public" runat="server"/><%=Resources.strings.event_is_public_desc%>
  <input id="events_recuser_id" type="hidden"  runat="server"/>
  
  <input id="events_recevent_time" type="hidden"  runat="server"/>
  
  <input id="events_recevent_time_end" type="hidden"  runat="server"/>
  </td> 
                </tr>
 
                <asp:PlaceHolder id="events_recPanelLocation" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelLocation" runat="server"/></th>
 
                  <td>
<asp:TextBox id="events_recevent_location" Columns="50" TextMode="MultiLine"

	runat="server"/>
</td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelCost" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelCost" runat="server"/></th>
 
                  <td><asp:TextBox id="events_recevent_cost"

	runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelURL" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelURL" runat="server"/></th>
 
                  <td><asp:TextBox id="events_recevent_URL" Columns="40"

	runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelTextBox1" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelTextBox1" runat="server"/></th>
 
                  <td><asp:TextBox id="events_recTextBox1" maxlength="100" Columns="50"

	runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelTextBox2" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelTextBox2" runat="server"/></th>
 
                  <td><asp:TextBox id="events_recTextBox2" maxlength="100" Columns="50"

	runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelTextBox3" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelTextBox3" runat="server"/></th>
 
                  <td><asp:TextBox id="events_recTextBox3" maxlength="100" Columns="50"

	runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelTextArea1" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelTextArea1" runat="server"/></th>
 
                  <td>
<asp:TextBox id="events_recTextArea1" Columns="50" TextMode="MultiLine"

	runat="server"/>
</td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelTextArea2" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelTextArea2" runat="server"/></th>
 
                  <td>
<asp:TextBox id="events_recTextArea2" Columns="50" TextMode="MultiLine"

	runat="server"/>
</td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelTextArea3" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelTextArea3" runat="server"/></th>
 
                  <td>
<asp:TextBox id="events_recTextArea3" Columns="50" TextMode="MultiLine"

	runat="server"/>
</td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelCheckBox1" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelCheckBox1" runat="server"/></th>
 
                  <td><asp:CheckBox id="events_recCheckBox1" runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelCheckBox2" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelCheckBox2" runat="server"/></th>
 
                  <td><asp:CheckBox id="events_recCheckBox2" runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelCheckBox3" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th><asp:Literal id="events_recLabelCheckBox3" runat="server"/></th>
 
                  <td><asp:CheckBox id="events_recCheckBox3" runat="server"/></td> 
                </tr>
 
	</asp:PlaceHolder>
                <asp:PlaceHolder id="events_recPanelRecurrentSubmit" Visible="True" runat="server">
	
                <tr class="Controls">
                  <th>&nbsp;</th>
 
                  <td><asp:CheckBox id="events_recRecurrentApply" runat="server"/><b><%=Resources.strings.cal_RecurrentApply%></b>
  <input id="events_recevent_parent_id" type="hidden"  runat="server"/>
  </td> 
                </tr>
 
	</asp:PlaceHolder>
                <tr class="Bottom">
                  <td align="right" colspan="2">
                    <input id='events_recButton_Insert' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonInsert.gif"%>' value="<%#Resources.strings.CCS_Insert%>" border="0" OnServerClick='events_rec_Insert' runat="server"/>
                    <input id='events_recButton_Update' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' value="<%#Resources.strings.CCS_Update%>" border="0" OnServerClick='events_rec_Update' runat="server"/>
                    <input id='events_recButton_Delete' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonDelete.gif"%>' value="<%#Resources.strings.CCS_Delete%>" border="0" OnServerClick='events_rec_Delete' runat="server"/>
                    <input id='events_recButton_Cancel' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonCancel.gif"%>' value="<%#Resources.strings.CCS_Cancel%>" border="0" OnServerClick='events_rec_Cancel' runat="server"/></td> 
                </tr>
 
              </table>
 </td> 
          </tr>
 
        </table>
 
      

 
  </span>
  <br>
    </td> 
  </tr>
</table>
<calendar:footer id="footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

