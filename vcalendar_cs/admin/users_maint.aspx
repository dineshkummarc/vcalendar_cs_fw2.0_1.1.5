<!--ASPX page @1-0243546C-->
<%@ Page language="c#" CodeFile="users_maint.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.users_maint.users_maintPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.users_maint" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<title><%=Resources.strings.user%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 

  <span id="users_maintHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.CCS_RecordFormPrefix%> <%=Resources.strings.user%> <%=Resources.strings.CCS_RecordFormSuffix%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="users_maintError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="users_maintErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.user_login%>&nbsp;*</th>
 
            <td>
              <asp:TextBox id="users_maintuser_login" maxlength="25" Columns="25"

	runat="server"/><asp:Literal id="users_maintuser_login_label" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_password%>&nbsp;*</th>
 
            <td><asp:TextBox id="users_maintuser_password" TextMode="Password" maxlength="25" Columns="25"

	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_level%>&nbsp;*</th>
 
            <td>
              <select id="users_maintuser_level"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_email%>&nbsp;*</th>
 
            <td><asp:TextBox id="users_maintuser_email" maxlength="100" Columns="50"

	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_first_name%>&nbsp;*</th>
 
            <td><asp:TextBox id="users_maintuser_first_name" maxlength="30" Columns="30"

	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_last_name%>&nbsp;*</th>
 
            <td><asp:TextBox id="users_maintuser_last_name" maxlength="30" Columns="30"

	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_is_approved%></th>
 
            <td><asp:CheckBox id="users_maintuser_is_approved" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.user_date_add%> </th>
 
            <td><asp:Literal id="users_maintuser_date_add" runat="server"/>&nbsp;
  <input id="users_maintuser_date_add_h" type="hidden"  runat="server"/>
  </td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='users_maintButton_Insert' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonInsert.gif"%>' value="<%#Resources.strings.CCS_Insert%>" border="0" OnServerClick='users_maint_Insert' runat="server"/>
              <input id='users_maintButton_Update' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' value="<%#Resources.strings.CCS_Update%>" border="0" OnServerClick='users_maint_Update' runat="server"/>
              <input id='users_maintButton_Delete' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonDelete.gif"%>' value="<%#Resources.strings.CCS_Delete%>" border="0" OnServerClick='users_maint_Delete' runat="server"/>
              <input id='users_maintButton_Cancel' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonCancel.gif"%>' value="<%#Resources.strings.CCS_Cancel%>" border="0" OnServerClick='users_maint_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  

</form>
</body>
</html>

<!--End ASPX page-->

