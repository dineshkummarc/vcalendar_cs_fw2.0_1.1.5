<!--ASPX page @1-55E6266B-->
<%@ Control language="c#" CodeFile="infopanel.ascx.cs" AutoEventWireup="false" Inherits="calendar.infopanel.infopanelPage" %>

<%@ Import namespace="calendar.infopanel" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="vertical_menu" Src="vertical_menu.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

<script language="JavaScript" type="text/javascript">
<asp:PlaceHolder id="InfoJavaScriptPanel" Visible="True" runat="server">
	
function show(divID) {
  document.getElementById('div'+divID).style.visibility = "visible";
}

function hide(divID) {
  document.getElementById('div'+divID).style.visibility = "hidden";
}

	</asp:PlaceHolder>
</script>

<CC:Calendar id="InfoCalendar" OnItemDataBound="InfoCalendarItemDataBound" ShowOtherMonthsDays="True" MonthsInRow="4" Mode="OneMonth" runat="server">

<WeekdayNameStyle class="CalendarWeekdayName"/>
<WeekendNameStyle class="CalendarWeekendName"/>
<DayStyle class="CalendarDay"/>
<WeekendStyle class="CalendarWeekend"/>
<TodayStyle class="CalendarToday"/>
<WeekendTodayStyle class="CalendarWeekendToday"/>
<OtherMonthDayStyle class="CalendarOtherMonthDay"/>
<OtherMonthTodayStyle class="CalendarOtherMonthToday"/>
<OtherMonthWeekendStyle class="CalendarOtherMonthWeekend"/>
<OtherMonthWeekendTodayStyle class="CalendarOtherMonthWeekendToday"/>
<HeaderTemplate>
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td>
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft">





<img src="Styles/<%=PageStyleName%>/Images/Spacer.gif" border="0"/></td> 
          <th><asp:Literal id="InfoCalendarMonthDate"  Text='<%# Server.HtmlEncode(new DateField("MMMM, yyyy",Container.CurrentProcessingDate).GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></th>
          <td class="HeaderRight"><img src="Styles/<%=PageStyleName%>/Images/Spacer.gif" border="0"/></td> 
        </tr>
      </table>
 
      <table class="Calendar" cellspacing="3" cellpadding="0">
        <tr valign="top">
          
  </HeaderTemplate>
  
  <MonthHeaderTemplate>
          <td>
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr>
                
  </MonthHeaderTemplate>
  
  <WeekDaysTemplate><td width="14.29%"  '<%#Container.StyleString%>'><asp:Literal id="InfoCalendarDayOfWeek"  Text='<%# Server.HtmlEncode(new DateField("wi",Container.CurrentProcessingDate).GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></td>
  </WeekDaysTemplate>
  
  <WeekDaysFooterTemplate>
                                <asp:PlaceHolder id="InfoCalendarGoWeekHeader" Visible="True" runat="server">
	<td class="CalendarWeekdayName">&nbsp;</td>
	</asp:PlaceHolder>
                
  </WeekDaysFooterTemplate>
  <WeekHeaderTemplate>
              </tr>
 
              <tr>
                
  </WeekHeaderTemplate>
  
  <DayHeaderTemplate>
                <td valign="top"  <asp:Literal id="InfoCalendarStyleControl" runat="server"/>><a id="InfoCalendarDayNumber" href="" runat="server"  ><%#((DateTime)Container.CurrentProcessingDate).ToString("%d")%></a> <asp:Literal id="InfoCalendardiv_begin" runat="server"/> 
                  
  </DayHeaderTemplate>
  
  <EventRowTemplate>
                  <div class="CalendarEvent" nowrap>
                    <nobr><b>
                    <asp:Image id="InfoCalendarcategory_image"  ImageUrl="images/categories/" hspace="3" vspace="3" runat="server"/>
                    <asp:Literal id="InfoCalendarEventTime" Text='<%# Server.HtmlEncode(((InfoCalendarItem)Container.DataItem).EventTime.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/><asp:Literal id="InfoCalendarEventTimeEnd" Text='<%# Server.HtmlEncode(((InfoCalendarItem)Container.DataItem).EventTimeEnd.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
                                        <asp:Literal id="InfoCalendarEventDescription" Text='<%# Server.HtmlEncode(((InfoCalendarItem)Container.DataItem).EventDescription.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
                                        </b></nobr>
                  </div>
                                  
  </EventRowTemplate>
  
  <DayFooterTemplate><asp:Literal id="InfoCalendardiv_end" runat="server"/>
                                </td>
                                
  </DayFooterTemplate>
  
  <EmptyDayTemplate>
                                  <td class="CalendarOtherMonthDay">&nbsp;</td>
                                </EmptyDayTemplate>
  
  <WeekFooterTemplate>
                                
<asp:PlaceHolder id="InfoCalendarGoWeekPanel" Visible="True" runat="server">
	
<td class="CalendarWeekend">
  <a id="InfoCalendarGoWeek" href="" runat="server"  ><img border="0" src="images/week.gif"/></a></td>
	</asp:PlaceHolder>              </tr>
                                </WeekFooterTemplate>
  
  <MonthFooterTemplate>
                          </table>
                        </td></MonthFooterTemplate>
  
  <MonthsRowSeparatorTemplate>
        </tr>
        <tr valign="top">
          
  </MonthsRowSeparatorTemplate>
  
  <FooterTemplate>
        </tr>

                <asp:PlaceHolder id="InfoCalendarInfoNavigator" Visible="True" runat="server">
	
                <tr>
                  <td colspan="<%#Container.Owner.MonthsInRow.ToString()%>" class="CalendarNavigator">
                        <table width="100%">
                          <tr>
                                <td width="50%" align="left"><a id="InfoCalendarPrevMonth" href="" title="<%#Resources.strings.CCS_PrevMonthHint%>" runat="server"  ><%#"<img border=\"0\" src=\"Styles/" + PageStyleName + "/Images/Prev.gif\"/>"%></a></td>
                                <td width="50%" align="right"><a id="InfoCalendarNextMonth" href="" title="<%#Resources.strings.CCS_NextMonthHint%>" runat="server"  ><%#"<img border=\"0\" src=\"Styles/" + PageStyleName + "/Images/Next.gif\"/>"%></a></td>
                          </tr>
                        </table>
                  </td>
                </tr>
                
	</asp:PlaceHolder>
      </table>
    </td> 
  </tr>
</table>
<br>
</FooterTemplate>
  </CC:Calendar>

<calendar:vertical_menu id="vertical_menu" runat="server"/>



<!--End ASPX page-->

