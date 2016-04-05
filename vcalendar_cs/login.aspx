<!--ASPX page @1-F9E48018-->
<%@ Page language="c#" CodeFile="login.aspx.cs" AutoEventWireup="false" Inherits="calendar.login.loginPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.login" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=loginContentMeta%>">

<title><%=Resources.strings.CCS_Login%></title>


<link rel="stylesheet" type="text/css" href="Styles/<%=PageStyleName%>/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include JSFunctions @1-FBB2332B
  </script>
  <script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
  <script language="JavaScript" type="text/javascript">
  
//End Include JSFunctions

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @10-0B0729C0
    if (theForm.Loginlogin) theForm.Loginlogin.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//bind_events @1-B716D3FC
function bind_events() {
    page_OnLoad();
    forms_onload();
}
//End bind_events

window.onload = bind_events; //Assign bind_events @1-19F7B649

//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/>
<table border="0" cellspacing="5" cellpadding="0" width="100%">
  <tr>
    <td align="center">
        <br/><br/><br/>


  <span id="LoginHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
            <th><%=Resources.strings.CCS_Login%></th>
            <td class="HeaderRight"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
          </tr>
        </table>
        <table cellspacing="0" cellpadding="0" class="Record">
          
  <asp:PlaceHolder id="LoginError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="LoginErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.CCS_Login%></th>
 
            <td><asp:TextBox id="Loginlogin" maxlength="100" Columns="20"

	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.CCS_Password%></th>
 
            <td><asp:TextBox id="Loginpassword" TextMode="Password" maxlength="100" Columns="20"

	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='LoginButton_DoLogin' type="image" border="0" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonLogin.gif"%>' value="<%#Resources.strings.CCS_LoginBtn%>" OnServerClick='Login_Button_DoLogin_OnClick' runat="server"/></td> 
          </tr>
        </table>
 </td> 
    </tr>
  </table>



  </span>
  
<br/>
<asp:PlaceHolder id="RegPanel" Visible="True" runat="server">
	<a id="register" href="" runat="server"  ><%#Resources.strings.registration%></a> &middot; 
	</asp:PlaceHolder><a id="remind" href="" runat="server"  ><%#Resources.strings.cal_remind_password%></a><br/>
<b>Admin:</b> admin/admin<br><b>User:</b> user/user<br/><br/>
        </td> 
  </tr>
</table>

<calendar:footer id="footer" runat="server"/>

</form>
</body>
</html>

<!--End ASPX page-->

