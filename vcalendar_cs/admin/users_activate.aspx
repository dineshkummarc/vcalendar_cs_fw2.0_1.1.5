<!--ASPX page @1-C4C5B12A-->
<%@ Page language="c#" CodeFile="users_activate.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.users_activate.users_activatePage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.users_activate" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=users_activateContentMeta%>">

<title><%=Resources.strings.users_activate%></title>

<meta content="CodeCharge Studio 3.0.1.5" name="GENERATOR">

<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 

  <span id="usersHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0" width="500">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.users_activate%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="usersError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="usersErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.user_login%></th>
 
            <td><asp:Literal id="usersuser_login" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_first_name%></th>
 
            <td><asp:Literal id="usersuser_first_name" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_last_name%></th>
 
            <td><asp:Literal id="usersuser_last_name" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_email%></th>
 
            <td><asp:Literal id="usersuser_email" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_date_add%></th>
 
            <td><asp:Literal id="usersuser_date_add" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='usersButton_Update' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonActivate.gif"%>' value="<%#Resources.strings.activate%>" border="0" OnServerClick='users_Update' runat="server"/>
              <input id='usersButton_Delete' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonDelete.gif"%>' value="<%#Resources.strings.CCS_Delete%>" border="0" OnServerClick='users_Delete' runat="server"/>
              <input id='usersButton_Cancel' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonCancel.gif"%>' value="<%#Resources.strings.CCS_Cancel%>" border="0" OnServerClick='users_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

