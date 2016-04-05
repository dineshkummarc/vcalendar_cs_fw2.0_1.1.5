<!--ASPX page @1-4A5E30E0-->
<%@ Page language="c#" CodeFile="content.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.content.contentPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.content" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<title><%=Resources.strings.contentsgrid%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript">
function open_preview() {
        var w_left = Math.ceil((screen.width-480)/2);
        var PrevWin= open("", "preview", "top=10,left="+w_left+",width=300,height=300,status=no,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes");
        PrevWin.focus();
        PrevWin.document.open();
        PrevWin.document.write("<html><head><title><%=Resources.strings.preview%></title></head><body>");
        
        var str = document.all["contents_maintcontent_value"].value;
        str = str.replace(/\n/g, "<br>");
        PrevWin.document.write(str);
        PrevWin.document.write('</body></html>');
        PrevWin.document.close();  

}

function openWin(url) {
        var openWin = window.open(url,"TranslationWin","top=30,height=500,width=600,resizable=yes,toolbar=no,location=no,status=no,scrollbars=no,menubar=no"); 
        openWin.focus();
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

<asp:repeater id="contentsRepeater" OnItemCommand="contentsItemCommand" OnItemDataBound="contentsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.contentsgrid%></th>
 
          <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
        </tr>
 
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th><%=Resources.strings.content_type%></th>
 
          <th><%=Resources.strings.content_desc%></th>
 
          <th>&nbsp;</th>
 
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="contentscontent_type" href="" runat="server"  ><%#((contentsItem)Container.DataItem).content_type.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="contentscontent_desc" Text='<%# Server.HtmlEncode(((contentsItem)Container.DataItem).content_desc.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><a id="contentstranslations" href="" runat="server"  ><%#"<img src=\"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonTranslation.gif\" border=\"0\">"%></a></td> 
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="3"><%=Resources.strings.CCS_NoRecords%></td> 
        </tr>
 
  </asp:PlaceHolder>

      </table>
 </td> 
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

  <span id="contents_maintHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.contents%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="contents_maintError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="contents_maintErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.content_type%></th>
 
            <td><asp:Literal id="contents_maintcontent_type" runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.content_desc%></th>
 
            <td><asp:TextBox id="contents_maintcontent_desc" maxlength="250" Columns="50"

	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th valign="top"><%=Resources.strings.content_value%></th>
 
            <td>
<asp:TextBox id="contents_maintcontent_value" rows="15" Columns="50" TextMode="MultiLine"

	runat="server"/>

  <input id="contents_maintcontent_id" type="hidden"  runat="server"/>
  </td> 
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='contents_maintPreview' onclick="open_preview();return false;" type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonPreview.gif"%>' value="Preview" border="0" OnServerClick='contents_maint_Preview_OnClick' runat="server"/>&nbsp; 
              <input id='contents_maintButton_Update' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' value="<%#Resources.strings.CCS_Update%>" border="0" OnServerClick='contents_maint_Update' runat="server"/>&nbsp; 
              <input id='contents_maintButton_Cancel' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonCancel.gif"%>' value="<%#Resources.strings.CCS_Cancel%>" border="0" OnServerClick='contents_maint_Cancel' runat="server"/></td> 
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

