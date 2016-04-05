<!--ASPX page @1-4AAE1F2D-->
<%@ Page language="c#" CodeFile="index.aspx.cs" AutoEventWireup="false" Inherits="calendar.index.indexPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.index" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="infopanel" Src="infopanel.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=indexContentMeta%>">

<title><%=Resources.strings.month_events%></title>


<link rel="stylesheet" type="text/css" href="Styles/<%=PageStyleName%>/Style.css">
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
<table border="0" cellspacing="5" cellpadding="0" width="100%">
  <tr>
        <td valign="top"><calendar:infopanel id="infopanel" runat="server"/></td> 
        <td valign="top" align="left" style="vertical-align:top;text-align:left;" width="100%">
          
<CC:Calendar id="cal_month" OnItemDataBound="cal_monthItemDataBound" MonthsInRow="4" Mode="OneMonth" runat="server">

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
          <table cellspacing="0" cellpadding="0" border="0" width="100%">
                <tr>
                  <td>
                        <table cellspacing="0" cellpadding="0" border="0" class="Header">
                          <tr>
                                <td class="HeaderLeft"><img border="0" src="Styles/<%=PageStyleName%>/Images/Spacer.gif"/></td> 
                                <th><%=Resources.strings.month_events%>, <asp:Literal id="cal_monthMonthDate"  Text='<%# Server.HtmlEncode(new DateField("MMMM yyyy",Container.CurrentProcessingDate).GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></th>
                                <td class="HeaderRight"><img border="0" src="Styles/<%=PageStyleName%>/Images/Spacer.gif"/></td> 
                          </tr>
                        </table>

                        <table cellspacing="3" cellpadding="0" class="Calendar">
                          <tr valign="top">
                                
  </HeaderTemplate>
  
  <MonthHeaderTemplate>
                                <td>
                                  <table cellspacing="0" cellpadding="0" class="Grid">
                                        <tr>
                                          
  </MonthHeaderTemplate>
  
  <WeekDaysTemplate>
                                          <td width="14.29%"  '<%#Container.StyleString%>'><asp:Literal id="cal_monthDayOfWeek"  Text='<%# Server.HtmlEncode(new DateField("dddd",Container.CurrentProcessingDate).GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></td> 
  </WeekDaysTemplate>
  
  <WeekDaysFooterTemplate>
                                          <td class="CalendarWeekdayName">&nbsp;</td>
                                        </tr>
                                        
  </WeekDaysFooterTemplate>
  <WeekHeaderTemplate>
                                        <tr height="60">
                                          
  </WeekHeaderTemplate>
  
  <DayHeaderTemplate>
                                          <td  style="vertical-align:top;text-align:left;" '<%#Container.StyleString%>'>
                                                <div style="float:left;"><a id="cal_monthDayNumber" href="" runat="server"  ><%#((DateTime)Container.CurrentProcessingDate).ToString("%d")%></a></div>
                                                <div style="float:right;"><a id="cal_monthadd_event" href="" runat="server"  ><img border="0" src="images/icon-add-big.gif"/></a></div>
                                                <br>
                                                
  </DayHeaderTemplate>
  
  <EventRowTemplate>
                                                <div class="CalendarEvent" style="text-align: left;">
                                                  <asp:Image id="cal_monthcategory_image"  ImageUrl="images/categories/" hspace="3" vspace="3" runat="server"/>
                                                  <asp:Literal id="cal_monthEventTime" Text='<%# Server.HtmlEncode(((cal_monthItem)Container.DataItem).EventTime.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/><asp:Literal id="cal_monthEventTimeEnd" Text='<%# Server.HtmlEncode(((cal_monthItem)Container.DataItem).EventTimeEnd.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
                                                  <a id="cal_monthEventDescription" href="" runat="server"  ><%#((cal_monthItem)Container.DataItem).EventDescription.GetFormattedValue()%></a>
                                                </div>
                                                
  </EventRowTemplate>
  
  <DayFooterTemplate>
                                          </td>
                                          
  </DayFooterTemplate>
  
  <EmptyDayTemplate>
                                          <td  '<%#Container.StyleString%>'>&nbsp;</td></EmptyDayTemplate>
  
  <WeekFooterTemplate>
                                          <td class="CalendarWeekend"><a id="cal_monthgo_week" href="" runat="server"  ><img border="0" src="images/icon-week.gif"/></a></td>
                                        </tr>
                                        </WeekFooterTemplate>
  
  <MonthFooterTemplate>
                                  </table>
                                </td>
                                </MonthFooterTemplate>
  
  <MonthsRowSeparatorTemplate>
                          </tr>
                          <tr valign="top">
                            
  </MonthsRowSeparatorTemplate>
  
  <FooterTemplate>
                          </tr>

                          <tr>
                                <td colspan="<%#Container.Owner.MonthsInRow.ToString()%>" class="CalendarNavigator" style="text-align:left;">
                                  <table>
                                        <tr>
                                          

<CC:CalendarNavigator id="cal_monthNavigator" YearsRange="10" Order="QuartersMonthsYears" runat="server">
  <HeaderTemplate>
                                            <input type="hidden" name="ccsForm" value='<%#PageVariables.Get("CalendarName")%>'/>
                                            

  </HeaderTemplate>
  
  <Prev_YearTemplate><td><a href="<%#Container.Url%>" title="Prev Year"><img border="0" src="Styles/<%=PageStyleName%>/Images/Back.gif"/></a></td></Prev_YearTemplate>
  <PrevTemplate><td><a href="<%#Container.Url%>" title="Prev Month"><img border="0" src="Styles/<%=PageStyleName%>/Images/Prev.gif"/></a></td>
  </PrevTemplate>
  
  <MonthsHeaderTemplate><td><select name="<%#Container.CalendarName%>Month">
  </MonthsHeaderTemplate>
  
  <RegularMonthTemplate><option value="<%#Container.Date.Month.ToString()%>"><%#Container.Date.ToString("MMM")%></option>
  </RegularMonthTemplate>
  
  <CurrentMonthTemplate><option value="<%#Container.Date.Month.ToString()%>" selected><%#Container.Date.ToString("MMM")%></option>
  </CurrentMonthTemplate>
  
  <MonthsFooterTemplate></select></td>
  </MonthsFooterTemplate>
 
  <YearsHeaderTemplate><td><select name="<%#Container.CalendarName%>Year">
  </YearsHeaderTemplate>
  
  <RegularYearTemplate><option value="<%#Container.Date.Year.ToString()%>"><%#Container.Date.Year.ToString()%></option>
  </RegularYearTemplate>
  <CurrentYearTemplate><option value="<%#Container.Date.Year.ToString()%>" selected><%#Container.Date.Year.ToString()%></option></CurrentYearTemplate>
  
  <YearsFooterTemplate></select></td>
  </YearsFooterTemplate>
  
  <BodyTemplate>
 
 
 
                                                  <td><input type="image" border="0" value="Submit" src="Styles/<%=PageStyleName%>/Images/<%=Resources.strings.CCS_LanguageID%>/ButtonGo.gif"></td>
 
 
  </BodyTemplate>
  
  <NextTemplate><td><a href="<%#Container.Url%>" title="Next Month"><img border="0" src="Styles/<%=PageStyleName%>/Images/Next.gif"/></a></td>
  </NextTemplate>
  
  <Next_YearTemplate><td><a href="<%#Container.Url%>" title="Next Year"><img border="0" src="Styles/<%=PageStyleName%>/Images/Forward.gif"/></a></td>
  </Next_YearTemplate>
  
 <FooterTemplate>
                                                

                                          </FooterTemplate>
  </CC:CalendarNavigator>

                                          <asp:PlaceHolder id="cal_monthCalendarTypes" Visible="True" runat="server">
	
                                                <td align="right" width="100%">
                                                  <a id="cal_monthYearIcon" href="" runat="server"  ><img src="images/icon-year.gif" border="0"/></a>
                                                  <a id="cal_monthMonthIcon" href="" runat="server"  ><img src="images/icon-month.gif" border="0"/></a>
                                                  <a id="cal_monthWeekIcon" href="" runat="server"  ><img src="images/icon-week.gif" border="0"/></a>
                                                </td>
                                          
	</asp:PlaceHolder>
                                        </tr>
                                  </table>
                                </td>
                          </tr>
                        </table>
                  </td>
                </tr>
          </table>
          </FooterTemplate>
  </CC:Calendar>

        </td> 
  </tr>
</table>
<calendar:footer id="footer" runat="server"/>

</form>
</body>
</html>

<!--End ASPX page-->

