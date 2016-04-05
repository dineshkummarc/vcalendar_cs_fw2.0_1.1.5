<!--ASPX page @1-1EA0930C-->
<%@ Page language="c#" CodeFile="content_lang.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.content_lang.content_langPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.content_lang" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<title><%=Resources.strings.contents_lang%></title>


<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<asp:Literal id="JavaScriptLabel" runat="server"/>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



<asp:repeater id="contents_langRepeater" OnItemCommand="contents_langItemCommand" OnItemDataBound="contents_langItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript">
	var contents_langElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initcontents_langElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.contents_lang%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="contents_langError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="3"><asp:Label ID="ErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_language_idSorter" field="Sorter_language_id" OwnerState="<%# contents_langData.SortField.ToString()%>" OwnerDir="<%# contents_langData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_language_idSort" runat="server"><%#Resources.strings.cal_language%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th colspan="2"><%=Resources.strings.contents_lang%></th>
 
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="3"><asp:Label ID="ErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>

          <tr class="Row">
            <th rowspan="2"><asp:Literal id="contents_langlanguageLabel" Text='<%# Server.HtmlEncode(((contents_langItem)Container.DataItem).languageLabel.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
  <input id="contents_langlanguage_id"  value='<%# ((contents_langItem)Container.DataItem).language_id.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </th>
 
            <th><%=Resources.strings.content_desc%></th>
 
            <td><asp:TextBox id="contents_langcontent_desc" Text='<%# ((contents_langItem)Container.DataItem).content_desc.GetFormattedValue() %>' maxlength="250" Columns="50"

	runat="server"/></td> 
          </tr>
 
          <tr class="Row">
            <th><%=Resources.strings.content_value%></th>
 
            <td>
<asp:TextBox id="contents_langcontent_value" Text='<%# ((contents_langItem)Container.DataItem).content_value.GetFormattedValue() %>' rows="3" Columns="39" TextMode="MultiLine"

	runat="server"/>
</td> 
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="3"><%=Resources.strings.CCS_NoRecords%></td> 
          </tr>
 
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="3">
              <asp:ImageButton id="contents_langButton_Submit" ImageUrl='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' Text="<%#Resources.strings.CCS_Update%>" border="0" CommandName="Submit" runat="server"/></td> 
          </tr>
 
        </table>
 <br>
        <a href="javascript:window.opener.location.reload();self.close()"><%=Resources.strings.close_window%></a> </td> 
    </tr>
 
  </table>



  </FooterTemplate>
</asp:repeater>
<asp:Literal id="close" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

