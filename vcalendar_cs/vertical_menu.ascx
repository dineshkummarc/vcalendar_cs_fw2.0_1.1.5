<!--ASPX page @1-62634FDF-->
<%@ Control language="c#" CodeFile="vertical_menu.ascx.cs" AutoEventWireup="false" Inherits="calendar.vertical_menu.vertical_menuPage" %>

<%@ Import namespace="calendar.vertical_menu" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>



  <span id="VerticalMenuHolder" runat="server">
    
<table cellspacing="0" cellpadding="0" border="0" style="width:100%">
  <tr>
    <td>
      <table class="Header" cellspacing="0" cellpadding="0" border="0" style="width:100%">
        <tr>
          <td class="HeaderLeft">





<img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.menu%></th>
 
          <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
        </tr>
 
      </table>
 
      <table class="Calendar" cellspacing="0" cellpadding="0">
        

          <tr class="CalendarOtherMonthDay">
            <td style="TEXT-ALIGN: left;font-size: 100%;padding: 5px;"><a id="VerticalMenuyear" href="" runat="server"  ><%#Resources.strings.cal_year%></a><br>
              <a id="VerticalMenumonth" href="" runat="server"  ><%#Resources.strings.cal_month%></a><br>
              <a id="VerticalMenuweek" href="" runat="server"  ><%#Resources.strings.cal_week%></a><br>
              <a id="VerticalMenuday" href="" runat="server"  ><%#Resources.strings.cal_day%></a><br>
              <a id="VerticalMenusearch" href="" runat="server"  ><%#Resources.strings.cal_search%></a><br>
              <asp:PlaceHolder id="VerticalMenuLoginPanel" Visible="True" runat="server">
	
                                <asp:PlaceHolder id="VerticalMenuRegLinkPanel" Visible="True" runat="server">
	<a id="VerticalMenuRegLink" href="" runat="server"  ><%#Resources.strings.cal_registration%></a><br>
	</asp:PlaceHolder>
                                <a id="VerticalMenulogin" href="" runat="server"  ><%#Resources.strings.CCS_Login%></a><br>
              
	</asp:PlaceHolder>
              <asp:PlaceHolder id="VerticalMenuuser_logout" Visible="True" runat="server">
	
                                <asp:PlaceHolder id="VerticalMenuPanelAdd" Visible="True" runat="server">
	<a id="VerticalMenuadd_event" href="" runat="server"  ><%#Resources.strings.cal_add_event%></a><br>
	</asp:PlaceHolder>
                                <a id="VerticalMenuprofile" href="" runat="server"  ><%#Resources.strings.cal_profile%></a><br>
                                <asp:PlaceHolder id="VerticalMenuPanelAdmin" Visible="True" runat="server">
	<a id="VerticalMenuadministration_link" href="" runat="server"  ><%#Resources.strings.cal_administration%></a><br>
	</asp:PlaceHolder>
                                <a id="VerticalMenulogout" href="" runat="server"  ><%#Resources.strings.CCS_LogoutBtn%></a> [<asp:Literal id="VerticalMenuuser_login" runat="server"/>]<br>
              
	</asp:PlaceHolder><br>
            </td> 
          </tr>
 
          <tr class="CalendarWeekend">
            <td style="TEXT-ALIGN: left;font-size: 100%;padding: 5px;">
                          
                          <select id="VerticalMenustyle" style="margin-bottom:3px"  runat="server"></select>
                          
                          <asp:PlaceHolder id="VerticalMenuStyleSeparator" Visible="True" runat="server">
	<br>
	</asp:PlaceHolder>

                          
                          <select id="VerticalMenulocale" style="margin-bottom:3px"  runat="server"></select>
                          
                          <asp:PlaceHolder id="VerticalMenuLocaleSeparator" Visible="True" runat="server">
	<br>
	</asp:PlaceHolder>

                          
              <select id="VerticalMenucategories" style="margin-bottom:3px"  runat="server"></select>
                          <br>
              
              <input id='VerticalMenuButton_Apply' type="image" border="0" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonApply.gif"%>' value="<%#Resources.strings.cal_btn_apply%>" OnServerClick='VerticalMenu_Search' runat="server"/></td> 
          </tr>
        

 
      </table>
    </td> 
  </tr>
</table>

  </span>
  



<!--End ASPX page-->

