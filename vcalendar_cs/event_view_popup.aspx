<!--ASPX page @1-7B4E7D65-->
<%@ Page language="c#" CodeFile="event_view_popup.aspx.cs" AutoEventWireup="false" Inherits="calendar.event_view_popup.event_view_popupPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.event_view_popup" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<title><asp:Literal id="event_name" runat="server"/></title>


<link media="screen" href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<link media="print" href="ccsprint.css" type="text/css" rel="stylesheet">

<script language="JavaScript">
function parent_redirect(url) {
        window.opener.location.href = unescape(url);
        self.close();
}
</script>

<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



            
<asp:repeater id="eventGridRepeater" OnItemCommand="eventGridItemCommand" OnItemDataBound="eventGridItemDataBound" runat="server">
  <HeaderTemplate>
	
            
  </HeaderTemplate>
  <ItemTemplate>
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><asp:Literal id="eventGridevent_title" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).event_title.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Row">
                <td><b><asp:Literal id="eventGridevent_date" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).event_date.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/> <asp:Literal id="eventGridevent_time" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).event_time.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/> 
                  <asp:Literal id="eventGridevent_time_end" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).event_time_end.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/> </b><br>
                                  <asp:PlaceHolder id="eventGridPanelCategory" Visible="True" runat="server">
	<%=Resources.strings.cal_category%>: <asp:Literal id="eventGridgroup_id" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).group_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>. <br>
	</asp:PlaceHolder>
                                  <%=Resources.strings.cal_addedby%>: <asp:Literal id="eventGriduser_id" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).user_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/><br>
                  <br>
                  <asp:Literal id="eventGridevent_desc" Text='<%# ((eventGridItem)Container.DataItem).event_desc.GetFormattedValue() %>' runat="server"/> 
                  <asp:PlaceHolder id="eventGridPanelLocation" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelLocation" runat="server"/>:</b> <asp:Literal id="eventGridevent_location" Text='<%# ((eventGridItem)Container.DataItem).event_location.GetFormattedValue() %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelCost" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelCost" runat="server"/>:</b> <asp:Literal id="eventGridevent_cost" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).event_cost.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelURL" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelURL" runat="server"/>:</b> <a id="eventGridevent_url" href="" runat="server"  ><%#((eventGridItem)Container.DataItem).event_url.GetFormattedValue()%></a>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelTextBox1" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelTextBox1" runat="server"/>:</b> <asp:Literal id="eventGridcustom_TextBox1" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).custom_TextBox1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelTextBox2" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelTextBox2" runat="server"/>:</b> <asp:Literal id="eventGridcustom_TextBox2" Text='<%# ((eventGridItem)Container.DataItem).custom_TextBox2.GetFormattedValue() %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelTextBox3" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelTextBox3" runat="server"/>:</b> <asp:Literal id="eventGridcustom_TextBox3" Text='<%# ((eventGridItem)Container.DataItem).custom_TextBox3.GetFormattedValue() %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelTextArea1" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelTextArea1" runat="server"/></b> <asp:Literal id="eventGridcustom_TextArea1" Text='<%# ((eventGridItem)Container.DataItem).custom_TextArea1.GetFormattedValue() %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelTextArea2" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelTextArea2" runat="server"/>:</b> <asp:Literal id="eventGridcustom_TextArea2" Text='<%# ((eventGridItem)Container.DataItem).custom_TextArea2.GetFormattedValue() %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelTextArea3" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelTextArea3" runat="server"/>:</b> <asp:Literal id="eventGridcustom_TextArea3" Text='<%# ((eventGridItem)Container.DataItem).custom_TextArea3.GetFormattedValue() %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelCheckBox1" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelCheckBox1" runat="server"/>:</b> <asp:Literal id="eventGridcustom_CheckBox1" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).custom_CheckBox1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelCheckBox2" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelCheckBox2" runat="server"/>:</b> <asp:Literal id="eventGridcustom_CheckBox2" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).custom_CheckBox2.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
	</asp:PlaceHolder>
                  <asp:PlaceHolder id="eventGridPanelCheckBox3" Visible="True" runat="server">
	<br>
                  <br>
                  <b><asp:Literal id="eventGridLabelCheckBox3" runat="server"/>:</b> <asp:Literal id="eventGridcustom_CheckBox3" Text='<%# Server.HtmlEncode(((eventGridItem)Container.DataItem).custom_CheckBox3.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>
	</asp:PlaceHolder></td>
              </tr>
              
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              <asp:PlaceHolder id="eventGridedit" Visible="True" runat="server">
	
              <tr class="Row">
                <td align="right"><a id="eventGridedit_event" href="" runat="server"  ><%#Resources.strings.cal_edit_event%></a></td>
              </tr>
              
	</asp:PlaceHolder>
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td><%=Resources.strings.CCS_NoRecords%></td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
            
  </FooterTemplate>
</asp:repeater>

<br>
<div class="noprint" align="left">
  <a id="close_link" href="" runat="server"  ><%#Resources.strings.close_window%></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a id="print_link" href="" runat="server"  ><%#Resources.strings.print%></a>
</div>

</form>
</body>
</html>

<!--End ASPX page-->

