<!--ASPX page @1-71D65281-->
<%@ Page language="c#" CodeFile="permissions.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.permissions.permissionsPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.permissions" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=permissionsContentMeta%>">

<title><%=Resources.strings.permissions%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 

<asp:repeater id="permissionsRepeater" OnItemCommand="permissionsItemCommand" OnItemDataBound="permissionsItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript">
	var permissionsElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initpermissionsElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.permissions%></th>
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="permissionsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th><%=Resources.strings.permission_desc%></th>
            <th><%=Resources.strings.permission_value%></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

                <asp:PlaceHolder id="permissionspermission_category_panel" Visible="True" runat="server">
	
                <tr class="AltRow">
                  <td colspan="2"><b><asp:Literal id="permissionspermission_category" Text='<%# Server.HtmlEncode(((permissionsItem)Container.DataItem).permission_category.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></b></td> 
                </tr>
                
	</asp:PlaceHolder>
          <tr class="Row">
            <td><asp:Literal id="permissionspermission_desc" Text='<%# Server.HtmlEncode(((permissionsItem)Container.DataItem).permission_desc.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></td> 
            <td>
              
                          <select id="permissionsperms_value"  runat="server"></select>
              
                        
  <input id="permissionsperm_type"  value='<%# ((permissionsItem)Container.DataItem).perm_type.GetFormattedValue() %>' type="hidden"  runat="server"/>
  
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
              <asp:ImageButton id="permissionsButton_Submit" ImageUrl='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' Text="<%#Resources.strings.CCS_Update%>" border="0" CommandName="Submit" runat="server"/></td>
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

