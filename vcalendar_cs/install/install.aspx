<!--ASPX page @1-11064DA1-->
<%@ Page language="c#" CodeFile="install.aspx.cs" AutoEventWireup="false" Inherits="calendar.install.install.installPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="calendar.install.install" %>
<%@ Import namespace="calendar.Configuration" %>
<%@ Import namespace="calendar.Data" %>

<%@Register TagPrefix="CC" Namespace="calendar.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=installContentMeta%>">

<title><%=Resources.strings.install%></title>

<link href="../Styles/Pine/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
function HideShowComponents() {
        if (document.getElementById("sql_environmentDBType_0")) {
                if (document.getElementById("sql_environmentDBType_0").checked) {
                        document.getElementById("sql_param1").style.display = "";
                        document.getElementById("sql_param2").style.display = "";
                        document.getElementById("sql_param3").style.display = "";
                        document.getElementById("sql_param4").style.display = "";
                        document.getElementById("sql_param5").style.display = "";
                        document.getElementById("mdb_param").style.display = "none";
                } else {
                        document.getElementById("sql_param1").style.display = "none";
                        document.getElementById("sql_param2").style.display = "none";
                        document.getElementById("sql_param3").style.display = "none";
                        document.getElementById("sql_param4").style.display = "none";
                        document.getElementById("sql_param5").style.display = "none";
                        document.getElementById("mdb_param").style.display = "";
                }
        }
}

function DisabledComponents() {
        if (document.getElementById("sql_environmentchange_webconfig")) {
                if (document.getElementById("sql_environmentchange_webconfig").checked) {
                        document.getElementById("sql_environmentSiteURL").disabled = false;
                        document.getElementById("sql_environmentDBType_1").disabled = false;
                } else {
                        document.getElementById("sql_environmentSiteURL").disabled = true;
                        document.getElementById("sql_environmentDBType_0").checked = true;
                        document.getElementById("sql_environmentDBType_1").disabled = true;
                        HideShowComponents();
                }
        }
}

window.onload = function() {
        HideShowComponents();
        DisabledComponents();
        if (document.getElementById("sql_environmentis_disabled"))
                if (document.getElementById("sql_environmentis_disabled").value == "1")
                        document.getElementById("sql_environmentchange_webconfig").disabled = true;
}
</script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<center>
<br>
<asp:PlaceHolder id="Panel1" Visible="True" runat="server">
	
<table cellspacing="0" cellpadding="0" width="600" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="../Styles/Pine/Images/Spacer.gif" border="0"></td> 
          <th><%=Resources.strings.welcom_install%></th>
 
          <td class="HeaderRight"><img src="../Styles/Pine/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>

      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>VCalendar</th>
        </tr>
 
        <tr class="Row">
          <td><%=Resources.strings.install_introduce%><br>
            <br>

                <table border="0" width="100%">
                  <tr>
                        <th style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><%=Resources.strings.system_requirements%></b></th>
                        <th style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><%=Resources.strings.status%></b></th>
                  </tr>

                  <tr>
                        <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.vb_version%></td> 
                        <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><font color="green"><b>OK</b></font></td> 
                  </tr>

                  <tr>
                        <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.writable_common%></td> 
                        <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><asp:Literal id="CommonCheck" runat="server"/></b></td> 
                  </tr>

                  <tr>
                        <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.writable_folder%></td> 
                        <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><asp:Literal id="FolderCheck" runat="server"/></b></td> 
                  </tr>

                </table>
                        <br><%=Resources.strings.inst_vcalendar_file_note%><br>
            <br>
            <br>
          </td>
        </tr>
 
        <tr class="Row">
          <td align="right"><a id="InstallLink" href="" runat="server"  ></a> </td>
        </tr>
      </table>
    </td>
  </tr>
</table>

	</asp:PlaceHolder>
<asp:PlaceHolder id="Panel2" Visible="True" runat="server">
	

  <span id="sql_environmentHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="650" border="0">
        <tr>
          <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                  <tr>
                        <td class="HeaderLeft"><img src="../Styles/Pine/Images/Spacer.gif" border="0"></td> 
                        <th><%=Resources.strings.install_step2%></th>
                        <td class="HeaderRight"><img src="../Styles/Pine/Images/Spacer.gif" border="0"></td>
                  </tr>
                </table>

                <table class="Record" cellspacing="0" cellpadding="0">
                  <tr class="Controls">
                        <td colspan="2"><%=Resources.strings.install_introduce2%><br>
                          <br>
                          <br>
                        </td>
                  </tr>

                  <tr class="Footer">
                        <td colspan="2"><b><%=Resources.strings.database_environment%></b></td>
                  </tr>
                  
  <asp:PlaceHolder id="sql_environmentError" visible="False" runat="server">
  
                  <tr class="Error">
                        <td colspan="2"><asp:Label ID="sql_environmentErrorLabel" runat="server"/></td>
                  </tr>
                 
  </asp:PlaceHolder>
  
                  <tr class="Controls">
                        <td colspan="2"><asp:CheckBox id="sql_environmentchange_webconfig" onclick="DisabledComponents();" runat="server"/>&nbsp;&nbsp;<b><%=Resources.strings.inst_web_config_change%></b>
  <input id="sql_environmentis_disabled" type="hidden"  runat="server"/>
  </td> 
                  </tr>

                  <tr id="site_url" class="Controls">
                        <th width="250"><%=Resources.strings.install_site_url%> *</th>
                        <td><asp:TextBox id="sql_environmentSiteURL" Columns="40" maxlength="250"

	runat="server"/></td> 
                  </tr>

                  <tr id="db_type" class="Controls">
                        <th><%=Resources.strings.db_type%></th>
                        <td><asp:RadioButtonList id="sql_environmentDBType"  onclick="HideShowComponents()" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                  </tr>

                  <tr id="mdb_param" class="Controls">
                        <th><%=Resources.strings.instal_mdb_file_path%> *</th>
                        <td><asp:TextBox id="sql_environmentmdb_file" maxlength="200" Columns="40"

	runat="server"/></td> 
                  </tr>

                  <tr id="sql_param1" class="Controls" style="display:none">
                        <th><%=Resources.strings.sql_host%> *</th>
                        <td><asp:TextBox id="sql_environmenthost"

	runat="server"/></td>
                  </tr>

                  <tr id="sql_param2" class="Controls" style="display:none">
                        <th><%=Resources.strings.sql_database_name%> *</th>
                        <td><asp:TextBox id="sql_environmentsql_db_name"

	runat="server"/></td>
                  </tr>

                  <tr id="sql_param4" class="Controls" style="display:none">
                        <th><%=Resources.strings.sql_username%> *</th>
                        <td><asp:TextBox id="sql_environmentsql_username"

	runat="server"/></td>
                  </tr>

                  <tr id="sql_param5" class="Controls" style="display:none">
                        <th><%=Resources.strings.sql_password%></th>
                        <td><asp:TextBox id="sql_environmentsql_password" TextMode="Password"

	runat="server"/></td>
                  </tr>

                  <tr id="sql_param3" class="Controls">
                        <td colspan="2"><b><asp:RadioButtonList id="sql_environmentrecreate_tables"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></b></td> 
                  </tr>

                  <tr class="Bottom">
                        <td align="right" colspan="2">
                          <input id='sql_environmentButton_Insert' type="image" src='<%#"../Styles/Pine/Images/" + Resources.strings.CCS_LanguageID + "/ButtonApply.gif"%>' value="Insert" border="0" OnServerClick='sql_environment_Insert' runat="server"/></td>
                  </tr>
                </table>
          </td>
        </tr>
  </table>



  </span>
  

	</asp:PlaceHolder>
<asp:PlaceHolder id="Panel3" Visible="True" runat="server">
	
<table cellspacing="0" cellpadding="0" width="550" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="../Styles/Pine/Images/Spacer.gif" border="0"></td> 
          <th><%=Resources.strings.install_finish%></th>
          <td class="HeaderRight"><img src="../Styles/Pine/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Record" cellspacing="0" cellpadding="0">
        <tr class="Controls">
          <td colspan="2"><%=Resources.strings.install_finish2%></td>
        </tr>
 
        <tr class="Row">
          <td align="center" colspan="2"><%=Resources.strings.install_finish_desc%><br>
            <br>
            <br>
            <br>
            <br>
          </td>
        </tr>
 
        <tr class="Row">
          <td align="right"><a id="StartLink" href="" runat="server"  ><%#Resources.strings.start%></a></td>
        </tr>
      </table>
    </td>
  </tr>
</table>

	</asp:PlaceHolder>
</center>

</form>
</body>
</html>

<!--End ASPX page-->

