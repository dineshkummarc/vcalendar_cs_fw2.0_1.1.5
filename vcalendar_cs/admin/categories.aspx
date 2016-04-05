<!--ASPX page @1-B3151E7B-->
<%@ Page language="c#" CodeFile="categories.aspx.cs" AutoEventWireup="false" Inherits="calendar.admin.categories.categoriesPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.admin.categories" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="calendar" TagName="header" Src="header.ascx"%>
<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<title><%=Resources.strings.cal_categories%></title>

<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="expires" content="0">

<link href="../Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript">
function openWin(url) {
        var openWin = window.open(url,"TranslationWin","top=30,height=300,width=600,resizable=yes,toolbar=no,location=no,status=no,scrollbars=no,menubar=no"); 
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

<asp:repeater id="categoriesRepeater" OnItemCommand="categoriesItemCommand" OnItemDataBound="categoriesItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.cal_categories%></th>
 
          <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
        </tr>
 
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_category_nameSorter" field="Sorter_category_name" OwnerState="<%# categoriesData.SortField.ToString()%>" OwnerDir="<%# categoriesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_category_nameSort" runat="server"><%#Resources.strings.cal_category_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_category_imageSorter" field="Sorter_category_image" OwnerState="<%# categoriesData.SortField.ToString()%>" OwnerDir="<%# categoriesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_category_imageSort" runat="server"><%#Resources.strings.cal_category_image%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>&nbsp;</th>
 
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="categoriescategory_name" href="" runat="server"  ><%#((categoriesItem)Container.DataItem).category_name.GetFormattedValue()%></a>&nbsp;</td> 
          <td>
            <asp:Image id="categoriescategory_image"  ImageUrl="../images/categories/" runat="server"/>&nbsp;</td> 
          <td><a id="categoriestranslations" href="" runat="server"  ><%#"<img src=\"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonTranslation.gif\" align=\"absmiddle\" border=\"0\">"%></a></td> 
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="3"><%=Resources.strings.CCS_NoRecords%></td> 
        </tr>
 
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="3"><a id="categoriescategories_Insert" href="" runat="server"  ><%#Resources.strings.CCS_InsertLink%></a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# categoriesData.PagesCount%>" PageNumber="<%# categoriesData.PageNumber%>" runat="server">
 <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/First.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="FirstOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/FirstOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Prev.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/PrevOff.gif"%>' border="0"></CC:NavigatorItem>&nbsp;<%# ((Navigator)Container).PageNumber.ToString() %>
            <%#Resources.strings.CCS_Of%>&nbsp;<%# ((Navigator)Container).MaxPage.ToString() %>&nbsp; <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Next.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="NextOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/NextOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/Last.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOff" runat="server"><img src='<%#"../Styles/" + PageStyleName + "/Images/LastOff.gif"%>' border="0"></CC:NavigatorItem></CC:Navigator></td> 
        </tr>
 
      </table>
 </td> 
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

  <span id="categories_maintHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.CCS_RecordFormPrefix%> <%=Resources.strings.cal_category%>
            <%=Resources.strings.CCS_RecordFormSuffix%></th>
 
            <td class="HeaderRight"><img src='<%#"../Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="categories_maintError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="categories_maintErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.cal_category_name%>&nbsp;*</th>
 
            <td><asp:TextBox id="categories_maintcategory_name" maxlength="50" Columns="50"

	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.cal_category_image%></th>
 
            <td>
              
  <CC:FileUploadControl id="categories_maintcategory_image" DeleteCaption=' ' runat="server"/>
  </td> 
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='categories_maintButton_Insert' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonInsert.gif"%>' value="<%#Resources.strings.CCS_Insert%>" border="0" OnServerClick='categories_maint_Insert' runat="server"/>
              <input id='categories_maintButton_Update' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonUpdate.gif"%>' value="<%#Resources.strings.CCS_Update%>" border="0" OnServerClick='categories_maint_Update' runat="server"/>
              <input id='categories_maintButton_Delete' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonDelete.gif"%>' value="<%#Resources.strings.CCS_Delete%>" border="0" OnServerClick='categories_maint_Delete' runat="server"/>
              <input id='categories_maintButton_Cancel' type="image" src='<%#"../Styles/" + PageStyleName + "/Images/" + Resources.strings.CCS_LanguageID + "/ButtonCancel.gif"%>' value="<%#Resources.strings.CCS_Cancel%>" border="0" OnServerClick='categories_maint_Cancel' runat="server"/></td> 
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

