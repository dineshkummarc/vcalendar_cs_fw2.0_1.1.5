<!--ASPX page @1-059091A3-->
<%@ Page language="c#" CodeFile="email_templates_maint.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.email_templates_maint.email_templates_maintPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.email_templates_maint" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=email_templates_maintContentMeta%>">
<title><%=Resources.strings.CCS_RecordFormPrefix%> <%=Resources.strings.email_template%> <%=Resources.strings.CCS_RecordFormSuffix%></title>



<link rel="stylesheet" type="text/css" href="../Styles/<%=PageStyleName%>/Style.css">
<script language="JavaScript">
function open_preview() {
        var w_left = Math.ceil((screen.width-480)/2);
        var PrevWin=open("", "preview", "top=10,left="+w_left+",width=440,height=350,status=no,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes");
        PrevWin.focus();
        PrevWin.document.open();
        PrevWin.document.write("<html><head><title><%=Resources.strings.preview%></title></head><body>");

        var str = document.all["email_templatesemail_template_body"].value;
        str = str.replace(/\n/g, "<br>");
        PrevWin.document.write(str);
        PrevWin.document.write('</body></html>');
        PrevWin.document.close();  
}
</script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<calendar:header id="header" runat="server"/>

  <span id="email_templatesHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.CCS_RecordFormPrefix%> <%=Resources.strings.email_template%> <%=Resources.strings.CCS_RecordFormSuffix%> </th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="email_templatesError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="email_templatesErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.email_template_type%></th>
 
            <td><asp:Literal id="email_templatesemail_template_type" runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.email_template_desc%></th>
 
            <td><asp:TextBox id="email_templatesemail_template_desc" maxlength="250" Columns="50"

	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.email_template_from%></th>
 
            <td><asp:TextBox id="email_templatesemail_template_from" maxlength="50" Columns="50"

	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.email_template_subject%>&nbsp;*</th>
 
            <td><asp:TextBox id="email_templatesemail_template_subject" maxlength="250" Columns="50"

	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.email_template_body%></th>
 
            <td>
<asp:TextBox id="email_templatesemail_template_body" rows="15" Columns="50" TextMode="MultiLine"

	runat="server"/>
</td> 
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
                          <input id='email_templatesButton_Preview' type="image" value="<%#Resources.strings.preview%>" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonPreview.gif"%>' onclick="open_preview(); return false;" OnServerClick='email_templates_Button_Preview_OnClick' runat="server"/>
              <input id='email_templatesButton_Update' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' value="<%#Resources.strings.CCS_Update%>" border="0" OnServerClick='email_templates_Update' runat="server"/>
              <input id='email_templatesButton_Cancel' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonCancel.gif"%>' value="<%#Resources.strings.CCS_Cancel%>" border="0" OnServerClick='email_templates_Cancel' runat="server"/></td> 
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

