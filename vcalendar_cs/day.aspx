<!--ASPX page @1-3E4D42D5-->
<%@ Page language="c#" CodeFile="day.aspx.cs" AutoEventWireup="false" Inherits="calendar.day.dayPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.day" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="infopanel" Src="infopanel.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=dayContentMeta%>">

<title><%=Resources.strings.day_events%></title>


<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript">
function openWin(url) {
        var w_left = Math.ceil(screen.width/2-300);
        var openWin = window.open(url,"VoteWin","left="+w_left+",top=30,scrollbars=no,menubar=no,height=450,width=600,resizable=yes,toolbar=no,location=no,status=no"); 
        openWin.focus();
}
</script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 
<table cellspacing="5" cellpadding="0" border="0">
  <tr>
    <td valign="top"><calendar:infopanel id="infopanel" runat="server"/></td> 
    <td style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" valign="top" align="left" width="100%">
      <asp:Literal id="FullViewEvents" runat="server"/>
          <asp:PlaceHolder id="ShortViewEvents" Visible="True" runat="server">
	
      <table cellspacing="0" cellpadding="0" width="65%" border="0">
        <tr>
          <td valign="top">
            
<asp:repeater id="ShortViewEventsGridRepeater" OnItemCommand="ShortViewEventsGridItemCommand" OnItemDataBound="ShortViewEventsGridItemDataBound" runat="server">
  <HeaderTemplate>
	
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.day_events%>, <asp:Literal id="ShortViewEventsGridCalendarDate" runat="server"/> 
                <asp:Literal id="ShortViewEventsGridadd_event_spacer" runat="server"/><a id="ShortViewEventsGridadd_event" href="" runat="server"  ><img src="images/icon-add-big.gif" border="0"/></a></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <th width="10%"><b>
                <asp:Literal id="ShortViewEventsGridevent_time" Text='<%# Server.HtmlEncode(((ShortViewEventsGridItem)Container.DataItem).event_time.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;<asp:Literal id="ShortViewEventsGridevent_time_end" Text='<%# Server.HtmlEncode(((ShortViewEventsGridItem)Container.DataItem).event_time_end.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></b></th>
 
                <td width="90%">
                  <asp:Image id="ShortViewEventsGridcategory_image"  hspace="3" ImageUrl="images/categories/" vspace="3" runat="server"/><a id="ShortViewEventsGridevent_title" href="" runat="server"  ><%#((ShortViewEventsGridItem)Container.DataItem).event_title.GetFormattedValue()%></a> 
                  <asp:Literal id="ShortViewEventsGridcategory_name" Text='<%# Server.HtmlEncode(((ShortViewEventsGridItem)Container.DataItem).category_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></td>
              </tr>
                                
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="2"><%=Resources.strings.no_events_day%></td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
            
  </FooterTemplate>
</asp:repeater>

            
  <span id="ShortViewEventsNavigatorHolder" runat="server">
    
            

              <table class="Calendar" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="ShortViewEventsNavigatorError" visible="False" runat="server">
  
  </asp:PlaceHolder>
  
                <tr class="CalendarNavigator" style="TEXT-ALIGN: left">
                  <td>
                    <table>
                      <tr>
                        <td><a id="ShortViewEventsNavigatorprev_day_link" href="" runat="server"  ><%#"<img src=\"Styles/" + PageStyleName + "/Images/Prev.gif\" border=\"0\"/>"%></a></td> 
                        <td>
                          <select id="ShortViewEventsNavigatordate_day"  runat="server"></select>
 </td> 
                        <td>
                          <input id='ShortViewEventsNavigatorButtonGo' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonGo.gif"%>' value="<%#Resources.strings.go%>" border="0" OnServerClick='ShortViewEventsNavigator_Cancel' runat="server"/></td> 
                        <td><a id="ShortViewEventsNavigatornext_day_link" href="" runat="server"  ><%#"<img src=\"Styles/" + PageStyleName + "/Images/Next.gif\" border=\"0\"/>"%></a></td> 
                        <td>&nbsp;&nbsp;</td> 
                        <td>
                          <select id="ShortViewEventsNavigatorweek"  runat="server"></select>
 </td> 
                        <td>
                          <input id='ShortViewEventsNavigatorButton_DoSearch' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonGo.gif"%>' value="<%#Resources.strings.go%>" border="0" OnServerClick='ShortViewEventsNavigator_Cancel' runat="server"/></td> 
                        <td align="right" width="100%"><a id="ShortViewEventsNavigatorYearIcon" href="" runat="server"  ><img src="images/icon-year.gif" border="0"/></a><a id="ShortViewEventsNavigatorMonthIcon" href="" runat="server"  ><img src="images/icon-month.gif" border="0"/></a><a id="ShortViewEventsNavigatorWeekIcon" href="" runat="server"  ><img src="images/icon-week.gif" border="0"/></a></td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            

            
  </span>
  </td>
        </tr>
      </table>
      
	</asp:PlaceHolder></td>
  </tr>
</table>
<p><calendar:footer id="footer" runat="server"/> </p>
<p>&nbsp;</p>
<p>&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

