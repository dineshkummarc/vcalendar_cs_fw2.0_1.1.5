<!--ASPX page @1-BB971468-->
<%@ Page language="c#" CodeFile="custom_fields.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.custom_fields.custom_fieldsPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.custom_fields" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<title><%=Resources.strings.custom_fields%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript">
function openWin(url) {
        var openWin = window.open(url,"TranslationWin","top=30,height=300,width=600,resizable=yes,toolbar=no,location=no,status=no,scrollbars=no,menubar=no"); 
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
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      
<asp:repeater id="custom_fieldsRepeater" OnItemCommand="custom_fieldsItemCommand" OnItemDataBound="custom_fieldsItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.custom_fields%></th>
 
                <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
              </tr>
 
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Caption">
                <th>
                <CC:Sorter id="Sorter_field_nameSorter" field="Sorter_field_name" OwnerState="<%# custom_fieldsData.SortField.ToString()%>" OwnerDir="<%# custom_fieldsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_field_nameSort" runat="server"><%#Resources.strings.field_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_field_labelSorter" field="Sorter_field_label" OwnerState="<%# custom_fieldsData.SortField.ToString()%>" OwnerDir="<%# custom_fieldsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_field_labelSort" runat="server"><%#Resources.strings.field_label%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_field_is_activeSorter" field="Sorter_field_is_active" OwnerState="<%# custom_fieldsData.SortField.ToString()%>" OwnerDir="<%# custom_fieldsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_field_is_activeSort" runat="server"><%#Resources.strings.field_is_active%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
                <th>&nbsp;</th>
 
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><a id="custom_fieldsfield_name" href="" runat="server"  ><%#((custom_fieldsItem)Container.DataItem).field_name.GetFormattedValue()%></a>&nbsp;</td> 
                <td><asp:Literal id="custom_fieldsfield_label" Text='<%# Server.HtmlEncode(((custom_fieldsItem)Container.DataItem).field_label.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
                <td style="TEXT-ALIGN: center"><asp:Literal id="custom_fieldsfield_is_active" Text='<%# Server.HtmlEncode(((custom_fieldsItem)Container.DataItem).field_is_active.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
                <td><a id="custom_fieldstranslations" href="" runat="server"  ><%#"<img src=\"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonTranslation.gif\" border=\"0\">"%></a></td> 
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="4"><%=Resources.strings.CCS_NoRecords%></td> 
              </tr>
 
  </asp:PlaceHolder>

            </table>
 </td> 
        </tr>
 
      </table>
 
  </FooterTemplate>
</asp:repeater>
</td> 
    <td valign="top">&nbsp;&nbsp;</td> 
    <td valign="top">
      
  <span id="custom_fields_maintHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.CCS_RecordFormPrefix%> <%=Resources.strings.custom_field%>
                  <%=Resources.strings.CCS_RecordFormSuffix%></th>
 
                  <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                </tr>
 
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="custom_fields_maintError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="custom_fields_maintErrorLabel" runat="server"/></td> 
                </tr>
 
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.field_name%></th>
 
                  <td><asp:Literal id="custom_fields_maintfield_name" runat="server"/></td> 
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.field_label%></th>
 
                  <td><asp:TextBox id="custom_fields_maintfield_label" maxlength="50" Columns="50"

	runat="server"/></td> 
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.field_is_active%></th>
 
                  <td><asp:CheckBox id="custom_fields_maintfield_is_active" runat="server"/></td> 
                </tr>
 
                <tr class="Bottom">
                  <td align="right" colspan="2">
                    <input id='custom_fields_maintButton_Update' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' value="<%#Resources.strings.CCS_Update%>" border="0" OnServerClick='custom_fields_maint_Update' runat="server"/>
                    <input id='custom_fields_maintButton_Cancel' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonCancel.gif"%>' value="<%#Resources.strings.CCS_Cancel%>" border="0" OnServerClick='custom_fields_maint_Cancel' runat="server"/></td> 
                </tr>
 
              </table>
 </td> 
          </tr>
 
        </table>
 
      

 
  </span>
  </td> 
  </tr>
</table>

</form>
</body>
</html>

<!--End ASPX page-->

