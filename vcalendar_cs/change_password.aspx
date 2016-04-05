<!--ASPX page @1-4345C518-->
<%@ Page language="c#" CodeFile="change_password.aspx.cs" AutoEventWireup="false" Inherits="calendar.change_password.change_passwordPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.change_password" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="profile_menu" Src="profile_menu.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=change_passwordContentMeta%>">
<title><%=Resources.strings.cal_profile_chpass%></title>



<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 
<table cellspacing="5" cellpadding="0" border="0">
<tr>
  <td valign="top"><calendar:profile_menu id="profile_menu" runat="server"/></td> 
  <td valign="top">
      
  <span id="ChangePasswordHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.cal_profile_chpass%></th>
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="ChangePasswordError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="ChangePasswordErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.cal_current_password%></th>
                  <td><asp:TextBox id="ChangePasswordcurrent_password" TextMode="Password"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.cal_new_password%></th>
                  <td><asp:TextBox id="ChangePasswordnew_password" TextMode="Password"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.cal_new_password_confirm%></th>
                  <td><asp:TextBox id="ChangePasswordnew_password_confirm" TextMode="Password"

	runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td align="right" colspan="2">
                                   <input id='ChangePasswordButton_Update' type="image" border="0" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' value="<%#Resources.strings.CCS_Update%>" OnServerClick='ChangePassword_Update' runat="server"/></td> 
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  </td>
  </tr>
</table>
<calendar:footer id="footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

