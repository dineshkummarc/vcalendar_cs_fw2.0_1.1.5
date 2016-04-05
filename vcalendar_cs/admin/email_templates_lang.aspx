<!--ASPX page @1-F0D8B921-->
<%@ Page language="c#" CodeFile="email_templates_lang.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.email_templates_lang.email_templates_langPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.email_templates_lang" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=email_templates_langContentMeta%>">
<title><%=Resources.strings.email_templates_lang%></title>



<link rel="stylesheet" type="text/css" href="../Styles/<%=PageStyleName%>/Style.css">
<asp:Literal id="JavaScriptLabel" runat="server"/>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



<asp:repeater id="email_templates_langRepeater" OnItemCommand="email_templates_langItemCommand" OnItemDataBound="email_templates_langItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript">
	var email_templates_langElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initemail_templates_langElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
            <th><%=Resources.strings.email_templates_lang%></th>
            <td class="HeaderRight"><img border="0" src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
          </tr>
        </table>
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="email_templates_langError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="3"><asp:Label ID="ErrorLabel" runat="server"/></td> 
          </tr>
                        
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_language_idSorter" field="Sorter_language_id" OwnerState="<%# email_templates_langData.SortField.ToString()%>" OwnerDir="<%# email_templates_langData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_language_idSort" runat="server"><%#Resources.strings.cal_language%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img border="0" src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>'></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img border="0" src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>'></CC:SorterItem></CC:Sorter></th>
 
            <th colspan="2"><%=Resources.strings.email_template_translation%></th>
 
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="3"><asp:Label ID="ErrorLabel" runat="server"/></td> 
          </tr>
                        
  </asp:PlaceHolder>

          <tr class="Row">
            <th rowspan="3"><asp:Literal id="email_templates_langlanguageLabel" Text='<%# Server.HtmlEncode(((email_templates_langItem)Container.DataItem).languageLabel.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
  <input id="email_templates_langlanguage_id"  value='<%# ((email_templates_langItem)Container.DataItem).language_id.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </th> 
            <th><%=Resources.strings.email_template_desc%></th>
                        <td><asp:TextBox id="email_templates_langemail_template_desc" Text='<%# ((email_templates_langItem)Container.DataItem).email_template_desc.GetFormattedValue() %>' maxlength="250" Columns="70"

	runat="server"/></td>
                  </tr>
          <tr class="Row">
                    <th nowrap><%=Resources.strings.email_template_subject%>&nbsp;*</th>
                        <td><asp:TextBox id="email_templates_langemail_template_subject" Text='<%# ((email_templates_langItem)Container.DataItem).email_template_subject.GetFormattedValue() %>' maxlength="250" Columns="70"

	runat="server"/></td>
                  </tr>
          <tr class="Row">
                    <th><%=Resources.strings.email_template_body%></th>
                        <td>
<asp:TextBox id="email_templates_langemail_template_body" Text='<%# ((email_templates_langItem)Container.DataItem).email_template_body.GetFormattedValue() %>' Columns="60" rows="6" TextMode="MultiLine"

	runat="server"/>
</td> 
          </tr>

<tr class="Row">
  <th colspan="3"><hr></th>
</tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="3"><%=Resources.strings.CCS_NoRecords%></td> 
          </tr>
 
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="text-align:right;" colspan="3">
              <asp:ImageButton id="email_templates_langButton_Submit" border="0" ImageUrl='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' Text="<%#Resources.strings.CCS_Update%>" CommandName="Submit" runat="server"/></td> 
          </tr>
        </table>
<br>
<a href="javascript:window.opener.location.reload();self.close()"><%=Resources.strings.close_window%></a>
 </td> 
    </tr>
  </table>



  </FooterTemplate>
</asp:repeater>


</form>
</body>
</html>

<!--End ASPX page-->

