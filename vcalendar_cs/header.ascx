<!--ASPX page @1-52792148-->
<%@ Control language="c#" CodeFile="header.ascx.cs" AutoEventWireup="false" Inherits="calendar.header.headerPage" %>

<%@ Import namespace="calendar.header" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>
<asp:Literal id="html_header" runat="server"/> 

  <span id="HMenuHolder" runat="server">
    
<table class="Calendar" cellspacing="0" cellpadding="0">
  






    <tr class="CalendarOtherMonthDay">
      <td style="TEXT-ALIGN: left;font-size: 100%;padding: 5px;" nowrap>
            <a id="HMenuyear" href="" runat="server"  ><%#Resources.strings.cal_year%></a> &middot; 
                <a id="HMenumonth" href="" runat="server"  ><%#Resources.strings.cal_month%></a> &middot; 
                <a id="HMenuweek" href="" runat="server"  ><%#Resources.strings.cal_week%></a> &middot; 
                <a id="HMenulbl_day" href="" runat="server"  ><%#Resources.strings.cal_day%></a> &middot; 
                <a id="HMenusearch" href="" runat="server"  ><%#Resources.strings.cal_search%></a> &middot;            
<asp:PlaceHolder id="HMenuadd_event_hide" Visible="True" runat="server">
	
<a id="HMenuadd_event" href="" runat="server"  ><%#Resources.strings.cal_add_event%></a>&nbsp;&middot; 
	</asp:PlaceHolder>
<asp:PlaceHolder id="HMenuLoginPanel" Visible="True" runat="server">
	
<asp:PlaceHolder id="HMenuRegLinkPanel" Visible="True" runat="server">
	<a id="HMenuRegLink" class="menulink" href="" runat="server"  ><%#Resources.strings.cal_registration%></a> &middot; 
	</asp:PlaceHolder><a id="HMenulogin" class="menulink" href="" runat="server"  ><%#Resources.strings.CCS_Login%></a>
	</asp:PlaceHolder>
        <asp:PlaceHolder id="HMenuuser_logout" Visible="True" runat="server">
	<a id="HMenuprofile" href="" runat="server"  ><%#Resources.strings.cal_profile%></a> &middot; 
                <a id="HMenuadministration_link" href="" runat="server"  ><%#Resources.strings.cal_administration%></a><asp:Literal id="HMenuadministration_link_spacer" runat="server"/>
                <a id="HMenulogout" href="" runat="server"  ><%#Resources.strings.CCS_LogoutBtn%></a> [<asp:Literal id="HMenuuser_login" runat="server"/>]
	</asp:PlaceHolder>&nbsp;&nbsp;</td> 
      <td style="TEXT-ALIGN: left;font-size: 100%;padding: 5px;" nowrap>
        
        <select id="HMenustyle"  runat="server"></select>
 
        
        <select id="HMenulocale"  runat="server"></select>
 
        
        <select id="HMenucategories"  runat="server"></select>
 </td>
        <td style="TEXT-ALIGN: left;font-size: 100%;padding: 5px;" nowrap>
        <input id='HMenuButton_Apply' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonApply.gif"%>' value="<%#Resources.strings.cal_btn_apply%>" border="0" OnServerClick='HMenu_Search' runat="server"/></td>
      <td style="TEXT-ALIGN: left;font-size: 100%;padding: 5px; width:100%">&nbsp;</td>
    </tr>
  

</table>

  </span>
  



<!--End ASPX page-->

