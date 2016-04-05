<!--ASPX page @1-218471E3-->
<%@ Page language="c#" CodeFile="custom_fields_lang.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.custom_fields_lang.custom_fields_langPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.custom_fields_lang" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<title><%=Resources.strings.custom_fields_translations%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<asp:Literal id="JavaScriptLabel" runat="server"/>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



<asp:repeater id="custom_fields_langsRepeater" OnItemCommand="custom_fields_langsItemCommand" OnItemDataBound="custom_fields_langsItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript">
	var custom_fields_langsElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initcustom_fields_langsElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.custom_fields_translations%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="custom_fields_langsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th><%=Resources.strings.cal_language%></th>
 
            <th><%=Resources.strings.field_translation%></th>
 
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>

          <tr class="Row">
            <td><asp:Literal id="custom_fields_langslanguageLabel" Text='<%# Server.HtmlEncode(((custom_fields_langsItem)Container.DataItem).languageLabel.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/> 
  <input id="custom_fields_langslanguage_id"  value='<%# ((custom_fields_langsItem)Container.DataItem).language_id.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td><asp:TextBox id="custom_fields_langsfield_translation" Text='<%# ((custom_fields_langsItem)Container.DataItem).field_translation.GetFormattedValue() %>' maxlength="50" Columns="50"

	runat="server"/></td> 
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="2"><%=Resources.strings.CCS_NoRecords%></td> 
          </tr>
 
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="2">
              <asp:ImageButton id="custom_fields_langsButton_Submit" ImageUrl='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' Text="<%#Resources.strings.CCS_Update%>" border="0" CommandName="Submit" runat="server"/></td> 
          </tr>
 
        </table>
 </td> 
    </tr>
 
  </table>



  </FooterTemplate>
</asp:repeater>
<br>
<a href="javascript:self.close()"><%=Resources.strings.close_window%></a> </td>

</form>
</body>
</html>

<!--End ASPX page-->

