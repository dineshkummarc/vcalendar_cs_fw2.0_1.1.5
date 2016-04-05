<!--ASPX page @1-B529670E-->
<%@ Page language="c#" CodeFile="email_templates.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.email_templates.email_templatesPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.email_templates" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=email_templatesContentMeta%>">
<title><%=Resources.strings.email_templates%></title>


<link rel="stylesheet" type="text/css" href="../Styles/<%=PageStyleName%>/Style.css">

<script language="JavaScript">
function openWin(url) {
        var w_left = Math.ceil((screen.width -700)/2);
        var openWin = window.open(url,"TranslationWin","top=10,left="+w_left+",height=550,width=700,resizable=yes,toolbar=no,location=no,status=no,scrollbars=no,menubar=no"); 
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

<asp:repeater id="email_templatesRepeater" OnItemCommand="email_templatesItemCommand" OnItemDataBound="email_templatesItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.email_templates%></th>
 
          <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
        </tr>
 
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
                        <th>
                        <CC:Sorter id="Sorter_email_template_idSorter" field="Sorter_email_template_id" OwnerState="<%# email_templatesData.SortField.ToString()%>" OwnerDir="<%# email_templatesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_email_template_idSort" runat="server"><%#Resources.strings.email_template_id%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>

                        <th>
                        <CC:Sorter id="Sorter_email_template_subjectSorter" field="Sorter_email_template_subject" OwnerState="<%# email_templatesData.SortField.ToString()%>" OwnerDir="<%# email_templatesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_email_template_subjectSort" runat="server"><%#Resources.strings.email_template_subject%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>

                        <th>
                        <CC:Sorter id="Sorter_email_template_typeSorter" field="Sorter_email_template_type" OwnerState="<%# email_templatesData.SortField.ToString()%>" OwnerDir="<%# email_templatesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_email_template_typeSort" runat="server"><%#Resources.strings.email_template_type%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>

                        <th>
                        <CC:Sorter id="Sorter_email_template_descSorter" field="Sorter_email_template_desc" OwnerState="<%# email_templatesData.SortField.ToString()%>" OwnerDir="<%# email_templatesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_email_template_descSort" runat="server"><%#Resources.strings.email_template_desc%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>

                        <th>
                        <CC:Sorter id="Sorter_email_template_fromSorter" field="Sorter_email_template_from" OwnerState="<%# email_templatesData.SortField.ToString()%>" OwnerDir="<%# email_templatesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_email_template_fromSort" runat="server"><%#Resources.strings.email_template_from%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>

                        <th>&nbsp;</th>

        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
                  <td style="TEXT-ALIGN: right"><asp:Literal id="email_templatesemail_template_id" Text='<%# Server.HtmlEncode(((email_templatesItem)Container.DataItem).email_template_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>  
                  <td><a id="email_templatesemail_template_subject" href="" runat="server"  ><%#((email_templatesItem)Container.DataItem).email_template_subject.GetFormattedValue()%></a>&nbsp;</td>                 
                  <td><asp:Literal id="email_templatesemail_template_type" Text='<%# Server.HtmlEncode(((email_templatesItem)Container.DataItem).email_template_type.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>   
                  <td><asp:Literal id="email_templatesemail_template_desc" Text='<%# ((email_templatesItem)Container.DataItem).email_template_desc.GetFormattedValue() %>' runat="server"/>&nbsp;</td>          
                  <td><asp:Literal id="email_templatesemail_template_from" Text='<%# Server.HtmlEncode(((email_templatesItem)Container.DataItem).email_template_from.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>          
                  <td><a id="email_templatestranslations" href="" runat="server"  ><%#"<img src=\"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonTranslation.gif\" border=\"0\">"%></a></td>          
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6"><%=Resources.strings.CCS_NoRecords%> </td> 
        </tr>
 
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="6">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# email_templatesData.PagesCount%>" PageNumber="<%# email_templatesData.PageNumber%>" runat="server">
 <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/First.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="FirstOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/FirstOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Prev.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/PrevOff.gif"%>' border="0"></CC:NavigatorItem>&nbsp;<%# ((Navigator)Container).PageNumber.ToString() %>
            <%#Resources.strings.CCS_Of%>&nbsp;<%# ((Navigator)Container).MaxPage.ToString() %>&nbsp; <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Next.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="NextOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/NextOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Last.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/LastOff.gif"%>' border="0"></CC:NavigatorItem></CC:Navigator></td> 
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

