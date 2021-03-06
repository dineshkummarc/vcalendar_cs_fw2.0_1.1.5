<!--ASPX page @1-00908A86-->
<%@ Page language="c#" CodeFile="users.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.users.usersPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.users" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=usersContentMeta%>">

<title><%=Resources.strings.users%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 

  <span id="usersSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.CCS_SearchFormPrefix%> <%=Resources.strings.users_search%>
            <%=Resources.strings.CCS_SearchFormSuffix%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="usersSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="6"><asp:Label ID="usersSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.CCS_Filter%>&nbsp;</th>
 
            <td><asp:TextBox id="usersSearchs_keyword" maxlength="25" Columns="25"

	runat="server"/></td> 
            <th><%=Resources.strings.user_level%>&nbsp;</th>
 
            <td>
              <select id="usersSearchs_user_level"  runat="server"></select>&nbsp;
                        </td> 
            <th><%=Resources.strings.user_is_approved%>&nbsp;</th>
 
            <td>
              <select id="usersSearchs_user_is_approved"  runat="server"></select>&nbsp;
                        </td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="6">
              <input id='usersSearchButton_DoSearch' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonSearch.gif"%>' value="<%#Resources.strings.CCS_Search%>" border="0" OnServerClick='usersSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="usersRepeater" OnItemCommand="usersItemCommand" OnItemDataBound="usersItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.users%></th>
 
          <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="9"><%=Resources.strings.CCS_TotalRecords%>&nbsp; <asp:Literal id="usersusers_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_user_idSorter" field="Sorter_user_id" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_idSort" runat="server"><%#Resources.strings.user_id%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_user_loginSorter" field="Sorter_user_login" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_loginSort" runat="server"><%#Resources.strings.user_login%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_user_first_nameSorter" field="Sorter_user_first_name" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_first_nameSort" runat="server"><%#Resources.strings.user_first_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_user_last_nameSorter" field="Sorter_user_last_name" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_last_nameSort" runat="server"><%#Resources.strings.user_last_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_user_levelSorter" field="Sorter_user_level" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_levelSort" runat="server"><%#Resources.strings.user_level%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_user_emailSorter" field="Sorter_user_email" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_emailSort" runat="server"><%#Resources.strings.user_email%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_user_date_addSorter" field="Sorter_user_date_add" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_date_addSort" runat="server"><%#Resources.strings.user_date_add%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
                  <th>
                  <CC:Sorter id="Sorter_user_last_loginSorter" field="Sorter_user_last_login" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_last_loginSort" runat="server"><%#Resources.strings.user_last_login%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>

                  <th>
          <CC:Sorter id="Sorter_user_is_approvedSorter" field="Sorter_user_is_approved" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_is_approvedSort" runat="server"><%#Resources.strings.user_is_approved%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>

        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><asp:Literal id="usersuser_id" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><a id="usersuser_login" href="" runat="server"  ><%#((usersItem)Container.DataItem).user_login.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="usersuser_first_name" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_first_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="usersuser_last_name" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_last_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="usersuser_level" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_level.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="usersuser_email" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_email.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="usersuser_date_add" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_date_add.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
                  <td><asp:Literal id="usersuser_last_login" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_last_login.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
          <td style="TEXT-ALIGN: center"><asp:Literal id="usersuser_is_approved" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).user_is_approved.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="9"><%=Resources.strings.CCS_NoRecords%></td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="9">
            <div style="FLOAT: left">
              <a id="usersusers_Insert" href="" runat="server"  ><%#Resources.strings.CCS_InsertLink%></a> 
            </div>
 
            <div>
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# usersData.PagesCount%>" PageNumber="<%# usersData.PageNumber%>" runat="server">
 <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/First.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="FirstOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/FirstOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Prev.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/PrevOff.gif"%>' border="0"></CC:NavigatorItem>&nbsp; 
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
 <PageOnTemplate><asp:LinkButton runat="server"><%# ((PagerItem)Container).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
 <PageOffTemplate><%# ((PagerItem)Container).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager><%#Resources.strings.CCS_Of%>&nbsp;<%# ((Navigator)Container).MaxPage.ToString() %>&nbsp; <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Next.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="NextOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/NextOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Last.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/LastOff.gif"%>' border="0"></CC:NavigatorItem></CC:Navigator>
            </div>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>


</form>
</body>
</html>

<!--End ASPX page-->

