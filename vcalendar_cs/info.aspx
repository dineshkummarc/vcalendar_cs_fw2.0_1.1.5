<!--ASPX page @1-6CADBECD-->
<%@ Page language="c#" CodeFile="info.aspx.cs" AutoEventWireup="false" Inherits="calendar.info.infoPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.info" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="calendar" TagName="footer" Src="footer.ascx"%>
<%@Register TagPrefix="calendar" TagName="infopanel" Src="infopanel.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=infoContentMeta%>">
<meta name="GENERATOR" content="CodeCharge Studio 3.0.0.34">

<title><%=Resources.strings.cal_information%></title>


<link rel="stylesheet" type="text/css" href="Styles/<%=PageStyleName%>/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/>
<table border="0" cellspacing="5" cellpadding="0">
  <tr>
   <td valign="top"><calendar:infopanel id="infopanel" runat="server"/></td>
    <td valign="top" align="center">
          <table class="Record" cellspacing="0" cellpadding="0" border="0">
            <tr class="Bottom">
                  <td style="text-align: left"><asp:Literal id="ContentLabel" runat="server"/></td>
        </tr>
      </table>
          <br><br>

        </td> 
  </tr>
</table>

<calendar:footer id="footer" runat="server"/>

</form>
</body>
</html>

<!--End ASPX page-->

