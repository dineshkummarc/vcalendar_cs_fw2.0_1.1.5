<!--ASPX page @1-F7E175CF-->
<%@ Control language="c#" CodeFile="profile_menu.ascx.cs" AutoEventWireup="false" Inherits="calendar.profile_menu.profile_menuPage" %>

<%@ Import namespace="calendar.profile_menu" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="vertical_menu" Src="vertical_menu.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

<table cellspacing="0" cellpadding="0" border="0" style="width:200">
  <tr>
        <td>
          <table class="Header" cellspacing="0" cellpadding="0" border="0" style="width:100%">
                <tr>
                  <td class="HeaderLeft">





<img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.cal_profile%></th>
                  <td class="HeaderRight"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                </tr>
          </table>

          <table class="Calendar" cellspacing="0" cellpadding="0" style="width:100%">
                <tr class="CalendarOtherMonthDay">
                  <td style="TEXT-ALIGN: left;font-size: 100%;padding: 5px;">
                        <a id="profile_main" href="" runat="server"  ><%#Resources.strings.cal_edit_profile%></a><br>
                        <a id="profile_chpass" href="" runat="server"  ><%#Resources.strings.cal_profile_chpass%></a><br>
                        <a id="my_events" href="" runat="server"  ><%#Resources.strings.cal_my_events%></a><br>
                  </td>
                </tr>
          </table>
        </td> 
  </tr>
</table>
<br>
<calendar:vertical_menu id="vertical_menu" runat="server"/>



<!--End ASPX page-->

