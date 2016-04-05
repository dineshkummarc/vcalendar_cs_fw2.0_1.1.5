<!--ASPX page @1-33550A25-->
<%@ Control language="c#" CodeFile="header.ascx.cs" AutoEventWireup="false" Inherits="calendar.admin.header.headerPage" %>

<%@ Import namespace="calendar.admin.header" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

<h1>VCalendar:Administration</h1>

  <span id="HMenuHolder" runat="server">
    
<table class="Calendar" cellspacing="0" cellpadding="0">
  






    <tr class="CalendarOtherMonthDay">
      <td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-SIZE: 100%; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; TEXT-ALIGN: left" nowrap>
          <a id="HMenuhome" href="" runat="server"  ><%#Resources.strings.home_page%></a> &middot; 
          <a id="HMenuusers" href="" runat="server"  ><%#Resources.strings.cal_users%></a> &middot; 
          <a id="HMenucategories" href="" runat="server"  ><%#Resources.strings.cal_categories%></a> &middot; 
          <a id="HMenuconfig" href="" runat="server"  ><%#Resources.strings.config%></a> &middot; 
          <a id="HMenumessages" href="" runat="server"  ><%#Resources.strings.cal_messages%></a> &middot; 
          <a id="HMenupermissions" href="" runat="server"  ><%#Resources.strings.cal_permissions%></a> &middot; 
          <a id="HMenuemail_templates" href="" runat="server"  ><%#Resources.strings.email_templates%></a> &middot; 
          <a id="HMenucustom_fields" href="" runat="server"  ><%#Resources.strings.custom_fields%></a> &middot; 
          <a id="HMenulogout" class="menulink" href="" runat="server"  ><%#Resources.strings.CCS_LogoutBtn%></a> [<asp:Literal id="HMenuuser_login" runat="server"/>]
        &nbsp;&nbsp; </td> 
      <td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-SIZE: 100%; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; TEXT-ALIGN: left" nowrap>
        
        <select id="HMenustyle"  runat="server"></select>
 
        
        <select id="HMenulocale"  runat="server"></select>
 </td> 
      <td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-SIZE: 100%; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; TEXT-ALIGN: left" nowrap="nowrap">
        <input id='HMenuButton_Apply' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonApply.gif"%>' value="<%#Resources.strings.cal_btn_apply%>" border="0" OnServerClick='HMenu_Search' runat="server"/></td> 
      <td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-SIZE: 100%; PADDING-BOTTOM: 5px; WIDTH: 100%; PADDING-TOP: 5px; TEXT-ALIGN: left">&nbsp;</td> 
    </tr>
 
  

</table>

  </span>
  <br>




<!--End ASPX page-->

