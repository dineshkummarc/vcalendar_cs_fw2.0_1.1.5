<!--ASPX page @1-97CBD776-->
<%@ Page language="c#" CodeFile="profile_events.aspx.cs" AutoEventWireup="false" Inherits="calendar.profile_events.profile_eventsPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.profile_events" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="profile_menu" Src="profile_menu.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=profile_eventsContentMeta%>">

<title><%=Resources.strings.CCS_SearchFormPrefix%> <%=Resources.strings.events%> <%=Resources.strings.CCS_SearchFormSuffix%></title>


<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-098C6D15
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-D662F4B5

var events_groupsSearchDatePicker_s_date_from = new Object(); 
events_groupsSearchDatePicker_s_date_from.format           = "ShortDate";
events_groupsSearchDatePicker_s_date_from.style            = "Styles/<%=PageStyleName%>/Style.css";
events_groupsSearchDatePicker_s_date_from.relativePathPart = "";
events_groupsSearchDatePicker_s_date_from.themeVersion     = "3.0";
var events_groupsSearchDatePicker_s_date_to = new Object(); 
events_groupsSearchDatePicker_s_date_to.format           = "ShortDate";
events_groupsSearchDatePicker_s_date_to.style            = "Styles/<%=PageStyleName%>/Style.css";
events_groupsSearchDatePicker_s_date_to.relativePathPart = "";
events_groupsSearchDatePicker_s_date_to.themeVersion     = "3.0";
//End Date Picker Object Definitions

//End CCS script
function openWin(url) {
        var w_left = Math.ceil(screen.width/2-300);
        var openWin = window.open(url,"VoteWin","left="+w_left+",top=30,scrollbars=no,menubar=no,height=450,width=600,resizable=yes,toolbar=no,location=no,status=no"); 
        openWin.focus();
}
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 
<table cellspacing="5" cellpadding="0" border="0">
  <tr>
    <td valign="top"><calendar:profile_menu id="profile_menu" runat="server"/></td> 
    <td valign="top">
      
  <span id="events_groupsSearchHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.CCS_SearchFormPrefix%> <%=Resources.strings.events%>
                  <%=Resources.strings.CCS_SearchFormSuffix%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="events_groupsSearchError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="events_groupsSearchErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.event_title%></th>
 
                  <td><asp:TextBox id="events_groupsSearchs_keyword" maxlength="100" Columns="50"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.cal_category%></th>
 
                  <td>
                    <select id="events_groupsSearchs_category"  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.event_date%></th>
 
                  <td><%=Resources.strings.from%> <asp:TextBox id="events_groupsSearchs_date_from" Columns="8"

	runat="server"/>
                    <asp:PlaceHolder id="events_groupsSearchDatePicker_s_date_from" runat="server"><a href="javascript:showDatePicker('<%#events_groupsSearchDatePicker_s_date_fromName%>','forms[\''+theForm.id+'\']','<%#events_groupsSearchDatePicker_s_date_fromDateControl%>');" ><img src='<%#"Styles/" + PageStyleName + "/Images/DatePicker.gif"%>' border="0" /></a></asp:PlaceHolder>
  &nbsp;&nbsp;&nbsp;
                    <%=Resources.strings.to%> <asp:TextBox id="events_groupsSearchs_date_to" Columns="8"

	runat="server"/>
                    <asp:PlaceHolder id="events_groupsSearchDatePicker_s_date_to" runat="server"><a href="javascript:showDatePicker('<%#events_groupsSearchDatePicker_s_date_toName%>','forms[\''+theForm.id+'\']','<%#events_groupsSearchDatePicker_s_date_toDateControl%>');" ><img src='<%#"Styles/" + PageStyleName + "/Images/DatePicker.gif"%>' border="0" /></a></asp:PlaceHolder>
  </td>
                </tr>
 
                <tr class="Bottom">
                  <td align="right" colspan="2">
                    <input id='events_groupsSearchButton_DoSearch' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonSearch.gif"%>' value="<%#Resources.strings.CCS_Search%>" border="0" OnServerClick='events_groupsSearch_Search' runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  <br>
      
<asp:repeater id="events_groupsRepeater" OnItemCommand="events_groupsItemCommand" OnItemDataBound="events_groupsItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.CCS_GridFormPrefix%> <%=Resources.strings.events%>
                <%=Resources.strings.CCS_GridFormSuffix%></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Row">
                <td colspan="6"><%=Resources.strings.CCS_TotalRecords%>&nbsp;
                  <asp:Literal id="events_groupsevents_groups_TotalRecords" runat="server"/></td>
              </tr>
 
              <tr class="Caption">
                <th>&nbsp;</th>
 
                <th>
                <CC:Sorter id="Sorter_event_titleSorter" field="Sorter_event_title" OwnerState="<%# events_groupsData.SortField.ToString()%>" OwnerDir="<%# events_groupsData.SortDir%>" runat="server"><%#Resources.strings.event_title%> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="AscOff" runat="server"><asp:LinkButton id="Sorter_event_titleAsc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/AscOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOff" runat="server"><asp:LinkButton id="Sorter_event_titleDesc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/DescOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_event_dateSorter" field="Sorter_event_date" OwnerState="<%# events_groupsData.SortField.ToString()%>" OwnerDir="<%# events_groupsData.SortDir%>" runat="server"><%#Resources.strings.event_date%> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="AscOff" runat="server"><asp:LinkButton id="Sorter_event_dateAsc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/AscOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOff" runat="server"><asp:LinkButton id="Sorter_event_dateDesc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/DescOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_event_timeSorter" field="Sorter_event_time" OwnerState="<%# events_groupsData.SortField.ToString()%>" OwnerDir="<%# events_groupsData.SortDir%>" runat="server"><%#Resources.strings.event_time%> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="AscOff" runat="server"><asp:LinkButton id="Sorter_event_timeAsc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/AscOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOff" runat="server"><asp:LinkButton id="Sorter_event_timeDesc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/DescOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem></CC:Sorter></th>
 
                <th colspan="2">
                <CC:Sorter id="Sorter_categorySorter" field="Sorter_category" OwnerState="<%# events_groupsData.SortField.ToString()%>" OwnerDir="<%# events_groupsData.SortDir%>" runat="server"><%#Resources.strings.cal_category%> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="AscOff" runat="server"><asp:LinkButton id="Sorter_categoryAsc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/AscOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOff" runat="server"><asp:LinkButton id="Sorter_categoryDesc" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/DescOff.gif"%>' border="0"></asp:LinkButton></CC:SorterItem></CC:Sorter></th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><a id="events_groupsEditLink" href="" runat="server"  ><%#Resources.strings.cal_edit_event%></a>&nbsp;</td> 
                <td><a id="events_groupsevent_title" href="" runat="server"  ><%#((events_groupsItem)Container.DataItem).event_title.GetFormattedValue()%></a>&nbsp;</td> 
                <td><asp:Literal id="events_groupsevent_date" Text='<%# Server.HtmlEncode(((events_groupsItem)Container.DataItem).event_date.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="events_groupsevent_time" Text='<%# Server.HtmlEncode(((events_groupsItem)Container.DataItem).event_time.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;<asp:Literal id="events_groupsevent_time_end" Text='<%# Server.HtmlEncode(((events_groupsItem)Container.DataItem).event_time_end.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></td> 
                <td colspan="2"><asp:Literal id="events_groupscategory_name" Text='<%# Server.HtmlEncode(((events_groupsItem)Container.DataItem).category_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
              <tr class="Separator">
                <td colspan="6"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
              
  </SeparatorTemplate>
  <FooterTemplate>
	
              
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="6"><%=Resources.strings.CCS_NoRecords%></td>
              </tr>
              
  </asp:PlaceHolder>

              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# events_groupsData.PagesCount%>" PageNumber="<%# events_groupsData.PageNumber%>" runat="server">
              <tr class="Footer">
                <td colspan="6">
 <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/First.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="FirstOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/FirstOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Prev.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/PrevOff.gif"%>' border="0"></CC:NavigatorItem>&nbsp;<%# ((Navigator)Container).PageNumber.ToString() %>
                  <%#Resources.strings.CCS_Of%>&nbsp;<%# ((Navigator)Container).MaxPage.ToString() %>&nbsp; <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Next.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="NextOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/NextOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Last.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/LastOff.gif"%>' border="0"></CC:NavigatorItem></td>
              </tr>
              </CC:Navigator>
            </table>
          </td>
        </tr>
      </table>
      &nbsp;
  </FooterTemplate>
</asp:repeater>
<br>
    </td>
  </tr>
</table>
<calendar:footer id="footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

