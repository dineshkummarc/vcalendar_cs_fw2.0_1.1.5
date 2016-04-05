<!--ASPX page @1-4E27259A-->
<%@ Page language="c#" CodeFile="remind_password.aspx.cs" AutoEventWireup="false" Inherits="calendar.remind_password.remind_passwordPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.remind_password" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="verticalmenu" Src="vertical_menu.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=remind_passwordContentMeta%>">

<title><%=Resources.strings.cal_remind_password%></title>


<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/> 
<table cellspacing="5" cellpadding="0" width="100%" border="0">
  <tr>
    <td valign="top" width="10%"><calendar:verticalmenu id="verticalmenu" runat="server"/></td> 
    <td valign="top" align="left">
      
  <span id="remindHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.cal_remind_password%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="remindError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="remindErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.cal_login_or_email%>&nbsp;*</th>
 
                  <td><asp:TextBox id="remindlogin"

	runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td align="right" colspan="2">
                    <input id='remindremind' type="image" src='<%#"Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonPassRemind.gif"%>' value="<%#Resources.strings.cal_remind_password%>" border="0" OnServerClick='remind_Insert' runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  <br>
      <br>
      <br>
    </td>
  </tr>
</table>
<calendar:footer id="footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

