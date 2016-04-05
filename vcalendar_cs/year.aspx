<!--ASPX page @1-0E6C047E-->
<%@ Page language="c#" CodeFile="year.aspx.cs" AutoEventWireup="false" Inherits="calendar.year.yearPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.year" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="infopanel" Src="infopanel.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=yearContentMeta%>">

<title><%=Resources.strings.yearevents%></title>


<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
function show(divID) {
  document.getElementById('div'+divID).style.visibility = "visible";
}

function hide(divID) {
  document.getElementById('div'+divID).style.visibility = "hidden";
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
    <td valign="top" width="100%">
      
<CC:Calendar id="year_events" OnItemDataBound="year_eventsItemDataBound" MonthsInRow="4" Mode="Full" runat="server">

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
                <td class="HeaderLeft"><img src="Styles/<%=PageStyleName%>/Images/Spacer.gif" border="0"/></td> 
                <th><%=Resources.strings.yearevents%>, <asp:Literal id="year_eventsCurYearLabel" runat="server"/></th>
 
                <td class="HeaderRight"><img src="Styles/<%=PageStyleName%>/Images/Spacer.gif" border="0"/></td>
              </tr>
            </table>
 
            <table class="Calendar" cellspacing="3" cellpadding="0">
              <tr valign="top">
                
  </HeaderTemplate>
  
  <MonthHeaderTemplate>
                <td>
                  <table class="Grid" cellspacing="0" cellpadding="0">
                    <tr class="Caption">
                      <th colspan="8"><a id="year_eventsMonthDate" href="" runat="server"  ><%#((DateTime)Container.CurrentProcessingDate).ToString("MMMM")%></a></th>
                    </tr>
 
                    <tr>
                      
  </MonthHeaderTemplate>
  
  <WeekDaysTemplate>
                      <td width="14.29%"  '<%#Container.StyleString%>'><asp:Literal id="year_eventsDayOfWeek"  Text='<%# Server.HtmlEncode(new DateField("ddd",Container.CurrentProcessingDate).GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></td>
  </WeekDaysTemplate>
  
  <WeekDaysFooterTemplate>
<asp:PlaceHolder id="year_eventsGoWeekHeader" Visible="True" runat="server">
	
<td class="CalendarWeekdayName">&nbsp;</td>
	</asp:PlaceHolder>
                      
  </WeekDaysFooterTemplate>
  <WeekHeaderTemplate>
                    </tr>
 
                    <tr>
                      
  </WeekHeaderTemplate>
  
  <DayHeaderTemplate>
                      <td  '<%#Container.StyleString%>'><a id="year_eventsDayNumber" href="" runat="server"  ><%#((DateTime)Container.CurrentProcessingDate).ToString("%d")%></a> <asp:Literal id="year_eventsdiv_begin" runat="server"/> 
                        
  </DayHeaderTemplate>
  
  <EventRowTemplate>
                        <div class="CalendarEvent">
                          <nobr>
                          <asp:Image id="year_eventsCategoryImage"  hspace="3" ImageUrl="images/categories/" vspace="3" runat="server"/><asp:Literal id="year_eventsEventTime" Text='<%# Server.HtmlEncode(((year_eventsItem)Container.DataItem).EventTime.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/><asp:Literal id="year_eventsEventTimeEnd" Text='<%# Server.HtmlEncode(((year_eventsItem)Container.DataItem).EventTimeEnd.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/> <asp:Literal id="year_eventsEventDescription" Text='<%# Server.HtmlEncode(((year_eventsItem)Container.DataItem).EventDescription.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></nobr> 
                        </div>
                        
  </EventRowTemplate>
  
  <DayFooterTemplate><asp:Literal id="year_eventsdiv_end" runat="server"/></td>
  </DayFooterTemplate>
  
  <EmptyDayTemplate>
                      <td class="CalendarOtherMonthDay">&nbsp;</td></EmptyDayTemplate>
  
  <WeekFooterTemplate>
                                          <asp:PlaceHolder id="year_eventsGoWeekPanel" Visible="True" runat="server">
	
                                                <td class="CalendarWeekend">
                                          <a id="year_eventsGoWeek" href="" runat="server"  ><img border="0" src="images/week.gif"/></a></td>
	</asp:PlaceHolder>
                    </tr>
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
 
              <tr>
                <td class="CalendarNavigator" colspan="<%#Container.Owner.MonthsInRow.ToString()%>" style="text-align:left;">
                  

<CC:CalendarNavigator id="year_eventsNavigator" YearsRange="10" Order="MonthsQuartersYears" runat="server">
  <HeaderTemplate>
                  

                    <input type="hidden" value='<%#PageVariables.Get("CalendarName")%>' name="ccsForm"/>
                    <table>
                      <tr>
 
  </HeaderTemplate>
  
  <Prev_YearTemplate>
                        <td><a title="Prev Year" href="<%#Container.Url%>"><img src="Styles/<%=PageStyleName%>/Images/Back.gif" border="0"/></a></td></Prev_YearTemplate>
  <YearsHeaderTemplate>
                        <td>
                          <select name="<%#Container.CalendarName%>Year">
  </YearsHeaderTemplate>
  
  <RegularYearTemplate>
                            <option value="<%#Container.Date.Year.ToString()%>"><%#Container.Date.Year.ToString()%></option>
 
  </RegularYearTemplate>
  <CurrentYearTemplate>
                            <option value="<%#Container.Date.Year.ToString()%>" selected><%#Container.Date.Year.ToString()%></option>
                            </CurrentYearTemplate>
  
  <YearsFooterTemplate></select>
                        </td>
  </YearsFooterTemplate>
  
  <BodyTemplate>
 
                        <td><input type="image" src="Styles/<%=PageStyleName%>/Images/<%=Resources.strings.CCS_LanguageID%>/ButtonGo.gif" value="Submit" border="0"></td>
 
  </BodyTemplate>
  
  <Next_YearTemplate>
                        <td><a title="Next Year" href="<%#Container.Url%>"><img src="Styles/<%=PageStyleName%>/Images/Forward.gif" border="0"/></a></td>
  </Next_YearTemplate>
  
 <FooterTemplate>
                      </tr>
                    </table>
                  

                  </FooterTemplate>
  </CC:CalendarNavigator>
</td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
      </FooterTemplate>
  </CC:Calendar>
<br>
    </td>
  </tr>
</table>
<calendar:footer id="footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

