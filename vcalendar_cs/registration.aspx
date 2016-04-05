<!--ASPX page @1-66B33FB0-->
<%@ Page language="c#" CodeFile="registration.aspx.cs" AutoEventWireup="false" Inherits="calendar.registration.registrationPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.registration" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="infopanel" Src="infopanel.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=registrationContentMeta%>">

<title><%=Resources.strings.registration%></title>


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
    <td valign="top"><calendar:infopanel id="infopanel" runat="server"/></td> 
    <td align="middle">
      
  <span id="usersHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.registration%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="usersError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="usersErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.user_login%>&nbsp;*</th>
 
                  <td><asp:TextBox id="usersuser_login" maxlength="16" Columns="16"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.user_password%>&nbsp;* </th>
 
                  <td><asp:TextBox id="usersuser_password" TextMode="Password" maxlength="16" Columns="16"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.user_confirm_password%>&nbsp;*&nbsp; </th>
 
                  <td><asp:TextBox id="usersConfirmPassword" TextMode="Password" Columns="16"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.user_first_name%>&nbsp;*</th>
 
                  <td><asp:TextBox id="usersuser_first_name" maxlength="30" Columns="30"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.user_last_name%>&nbsp;*</th>
 
                  <td><asp:TextBox id="usersuser_last_name" maxlength="30" Columns="30"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.user_email%>&nbsp;*</th>
 
                  <td><asp:TextBox id="usersuser_email" maxlength="100" Columns="50"

	runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td align="right" colspan="2">
                    <input id='usersButton_Insert' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonRegister.gif"%>' value="<%#Resources.strings.cal_register%>" border="0" OnServerClick='users_Insert' runat="server"/></td>
                </tr>
              </table>
              
  <input id="usersuser_is_approved" type="hidden"  runat="server"/>
  
  <input id="usersuser_level" type="hidden"  runat="server"/>
  
  <input id="usersuser_access_code" type="hidden"  runat="server"/>
  &nbsp; </td>
          </tr>
        </table>
      

      <br>
      <br>
      <br>
      
  </span>
  </td>
  </tr>
</table>
<calendar:footer id="footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

