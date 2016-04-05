<!--ASPX page @1-D4C2AA38-->
<%@ Page language="c#" CodeFile="config.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.config.configPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.config" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=configContentMeta%>">

<title><%=Resources.strings.config%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="expires" content="0">
<meta http-equiv="cache-control" content="no-cache">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 

<asp:repeater id="configRepeater" OnItemCommand="configItemCommand" OnItemDataBound="configItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript">
	var configElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initconfigElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.config%></th>
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="configError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th><%=Resources.strings.config_desc%></th>
 
            <th><%=Resources.strings.config_value%></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

<asp:PlaceHolder id="configconfig_categoryPanel" Visible="True" runat="server">
	
                <tr class="GroupCaption">
                  <th colspan="2">
                        <asp:Literal id="configconfig_category" Text='<%# Server.HtmlEncode(((configItem)Container.DataItem).config_category.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></th>
                </tr>
 
	</asp:PlaceHolder>
                  
          <tr class="Row">
            <td><asp:Literal id="configconfig_desc" Text='<%# ((configItem)Container.DataItem).config_desc.GetFormattedValue() %>' runat="server"/></td> 
            <td>
              <asp:CheckBox id="configCheck_value" runat="server"/>
              <asp:TextBox id="configBox_value" Text='<%# ((configItem)Container.DataItem).Box_value.GetFormattedValue() %>' Columns="50"

	runat="server"/>
              
<asp:TextBox id="configArea_value" Text='<%# ((configItem)Container.DataItem).Area_value.GetFormattedValue() %>' rows="5" Columns="50" TextMode="MultiLine"

	runat="server"/>

              <select id="configListBox_value"  runat="server"></select>
                          
  <input id="configvalue_type"  value='<%# ((configItem)Container.DataItem).value_type.GetFormattedValue() %>' type="hidden"  runat="server"/>
  
                          
  <input id="configListBox_Values"  value='<%# ((configItem)Container.DataItem).ListBox_Values.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td>
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
                          <asp:ImageButton id="configButtonSubmit" ImageUrl='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' Text="<%#Resources.strings.CCS_Update%>" border="0" CommandName="Submit" runat="server"/>
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

