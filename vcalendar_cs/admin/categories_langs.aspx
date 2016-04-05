<!--ASPX page @1-28483CD7-->
<%@ Page language="c#" CodeFile="categories_langs.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.categories_langs.categories_langsPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.categories_langs" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=categories_langsContentMeta%>">
<title><%=Resources.strings.categories_translations%></title>



<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<asp:Literal id="JavaScriptLabel" runat="server"/>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



<asp:repeater id="categories_langsRepeater" OnItemCommand="categories_langsItemCommand" OnItemDataBound="categories_langsItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript">
	var categories_langsElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initcategories_langsElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.categories_translations%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="categories_langsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th><%=Resources.strings.cal_language%></th>
 
            <th><%=Resources.strings.category_translation%></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td><asp:Literal id="categories_langslanguageLabel" Text='<%# Server.HtmlEncode(((categories_langsItem)Container.DataItem).languageLabel.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
  <input id="categories_langslanguage_id"  value='<%# ((categories_langsItem)Container.DataItem).language_id.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td><asp:TextBox id="categories_langscategory_name" Text='<%# ((categories_langsItem)Container.DataItem).category_name.GetFormattedValue() %>' maxlength="50" Columns="50"

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
              <asp:ImageButton id="categories_langsButton_Submit" ImageUrl='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' Text="<%#Resources.strings.CCS_Update%>" border="0" CommandName="Submit" runat="server"/></td>
          </tr>
        </table>
        <br>
        <br>
        <a href="javascript:self.close()"><%=Resources.strings.close_window%></a> </td>
    </tr>
  </table>



  </FooterTemplate>
</asp:repeater>


</form>
</body>
</html>

<!--End ASPX page-->

