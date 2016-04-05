'Using Statements @1-6DC6A839
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Web
Imports System.IO
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports calendarVB
Imports calendarVB.Data
Imports calendarVB.Security
Imports calendarVB.Configuration
Imports calendarVB.Controls
'End Using Statements

Namespace calendarVB.admin.categories 'Namespace @1-A7663F8D

'Forms Definition @1-7F4D3469
Public Class [categoriesPage]
Inherits System.Web.UI.Page
'End Forms Definition

'Forms Objects @1-62796436
    Protected categoriesData As categoriesDataProvider
    Protected categoriesOperations As FormSupportedOperations
    Protected categoriesCurrentRowNumber As Integer
    Protected categories_maintData As categories_maintDataProvider
    Protected categories_maintErrors As NameValueCollection = New NameValueCollection()
    Protected categories_maintOperations As FormSupportedOperations
    Protected categories_maintIsSubmitted As Boolean = False
    Protected PageStyleName As String
    Protected categoriesContentMeta As String
    Protected PageVariables As New NameValueCollection()
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-95328552
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            categoriesBind
            categories_maintShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid categories Bind @33-4976F378

    Protected Sub categoriesBind()
        If Not categoriesOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"categories",GetType(categoriesDataProvider.SortFields), 10, 100)
        End If
'End Grid categories Bind

'Grid Form categories BeforeShow tail @33-FAE033EB
        categoriesParameters()
        categoriesData.SortField = CType(ViewState("categoriesSortField"),categoriesDataProvider.SortFields)
        categoriesData.SortDir = CType(ViewState("categoriesSortDir"),SortDirections)
        categoriesData.PageNumber = CInt(ViewState("categoriesPageNumber"))
        categoriesData.RecordsPerPage = CInt(ViewState("categoriesPageSize"))
        categoriesRepeater.DataSource = categoriesData.GetResultSet(PagesCount, categoriesOperations)
        ViewState("categoriesPagesCount") = PagesCount
        categoriesRepeater.DataBind
        FooterIndex = categoriesRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            categoriesRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim item As categoriesItem = New categoriesItem()
        Dim categoriescategories_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(categoriesRepeater.Controls(FooterIndex).FindControl("categoriescategories_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.categories_InsertHref = "categories.aspx"

        categoriescategories_Insert.InnerText=Resources.strings.CCS_InsertLink
        categoriescategories_Insert.HRef = item.categories_InsertHref+item.categories_InsertHrefParameters.ToString("GET","category_id", ViewState)
        Dim NavigatorNavigator As Controls.Navigator = CType(categoriesRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),Controls.Navigator)
'End Grid Form categories BeforeShow tail

'Grid categories Bind tail @33-E31F8E2A
    End Sub
'End Grid categories Bind tail

'Grid categories Table Parameters @33-14FD3E89

    Protected Sub categoriesParameters()
        Try
            categoriesData.Seslocale = TextParameter.GetParam(Session.Contents("locale"))

        Catch
            Dim ParentControls As ControlCollection=categoriesRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(categoriesRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid categories: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid categories Table Parameters

'Grid categories ItemDataBound event @33-A6D9317E

    Protected Sub categoriesItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as categoriesItem = CType(e.Item.DataItem,categoriesItem)
        Dim Item as categoriesItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            categoriesCurrentRowNumber += 1
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim categoriescategory_name As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("categoriescategory_name"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim categoriescategory_image As System.Web.UI.WebControls.Image = DirectCast(e.Item.FindControl("categoriescategory_image"),System.Web.UI.WebControls.Image)
            Dim categoriestranslations As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("categoriestranslations"),System.Web.UI.HtmlControls.HtmlAnchor)
            DataItem.category_nameHref = "categories.aspx"
            categoriescategory_name.HRef = DataItem.category_nameHref & DataItem.category_nameHrefParameters.ToString("GET","", ViewState)
            categoriescategory_image.ImageUrl += DataItem.category_image.GetFormattedValue()
            DataItem.translationsHref = "categories_langs.aspx"
            categoriestranslations.HRef = "javascript:openWin('" + DataItem.translationsHref & DataItem.translationsHrefParameters.ToString("GET","", ViewState) + "')"
        End If
'End Grid categories ItemDataBound event

'Grid categories BeforeShowRow event @33-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid categories BeforeShowRow event

'Grid categories Event BeforeShowRow. Action Custom Code @56-73254650
    ' -------------------------
	Dim categoriescategory_image As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("categoriescategory_image"), System.Web.UI.WebControls.Image)
	If DataItem.category_image.GetFormattedValue().Length > 0 Then
		categoriescategory_image.Visible = True
	Else
		categoriescategory_image.Visible = False
	End If
    ' -------------------------
'End Grid categories Event BeforeShowRow. Action Custom Code

'Grid categories BeforeShowRow event tail @33-477CF3C9
        End If
'End Grid categories BeforeShowRow event tail

'Grid categories ItemDataBound event tail @33-E31F8E2A
    End Sub
'End Grid categories ItemDataBound event tail

'Grid categories ItemCommand event @33-EAC95BFC

    Protected Sub categoriesItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= categoriesRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("categoriesSortDir"),SortDirections) = SortDirections._Asc And ViewState("categoriesSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("categoriesSortDir")=SortDirections._Desc
                Else
                    ViewState("categoriesSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("categoriesSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As categoriesDataProvider.SortFields = 0
            ViewState("categoriesSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("categoriesPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("categoriesPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            categoriesBind
        End If
    End Sub
'End Grid categories ItemCommand event

'Record Form categories_maint Parameters @45-5B496256

    Protected Sub categories_maintParameters()
        Dim item As new categories_maintItem
        Try
            categories_maintData.Seslocale = TextParameter.GetParam(Session.Contents("locale"))
            categories_maintData.Ctrlcategory_name = TextParameter.GetParam(item.category_name.Value)
            categories_maintData.Ctrlcategory_image = TextParameter.GetParam(item.category_image.Value)
            categories_maintData.Urlcategory_id = IntegerParameter.GetParam(Request.QueryString("category_id"))
        Catch e As Exception
            categories_maintErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form categories_maint Parameters

'Record Form categories_maint Show method @45-7DD360C6
    Protected Sub categories_maintShow()
        If categories_maintOperations.None Then
            categories_maintHolder.Visible = False
            Return
        End If
        Dim item As categories_maintItem = categories_maintItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not categories_maintOperations.AllowRead
        categories_maintErrors.Add(item.errors)
        If categories_maintErrors.Count > 0 Then
            categories_maintShowErrors()
            Return
        End If
'End Record Form categories_maint Show method

'Record Form categories_maint BeforeShow tail @45-19F8DA21
        categories_maintParameters()
        categories_maintData.FillItem(item, IsInsertMode)
        categories_maintHolder.DataBind()
        categories_maintButton_Insert.Visible=IsInsertMode AndAlso categories_maintOperations.AllowInsert
        categories_maintButton_Update.Visible=Not (IsInsertMode) AndAlso categories_maintOperations.AllowUpdate
        categories_maintButton_Delete.Visible=Not (IsInsertMode) AndAlso categories_maintOperations.AllowDelete
        categories_maintcategory_name.Text=item.category_name.GetFormattedValue()
        Try
            categories_maintcategory_image.FileFolder = "../images/categories"
        Catch ex As System.IO.DirectoryNotFoundException
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_FilesFolderNotFound,"{res:cal_category_image}"))
        Catch ex As System.Security.SecurityException
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_InsufficientPermissions,"{res:cal_category_image}"))
        End Try
        Try
            categories_maintcategory_image.TemporaryFolder = "../temp"
        Catch ex As System.IO.DirectoryNotFoundException
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_TempFolderNotFound,"{res:cal_category_image}"))
        Catch ex As System.Security.SecurityException
            categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_TempInsufficientPermissions,"{res:cal_category_image}"))
        End Try
        categories_maintcategory_image.AllowedFileMasks = "*.jpg;*.png;*.gif"
        categories_maintcategory_image.FileSizeLimit = 100000
        Try
            categories_maintcategory_image.Text=item.category_image.GetFormattedValue()
        Catch ex As System.IO.FileNotFoundException
            Dim FileName As String = item.category_image.GetFormattedValue()
            item.errors.Add("category_image",String.Format(Resources.strings.CCS_FileNotFound,Item.category_image.GetFormattedValue(),"{res:cal_category_image}"))
        End Try
'End Record Form categories_maint BeforeShow tail

'Record Form categories_maint Show method tail @45-2708412B
        If categories_maintErrors.Count > 0 Then
            categories_maintShowErrors()
        End If
    End Sub
'End Record Form categories_maint Show method tail

'Record Form categories_maint LoadItemFromRequest method @45-4A0FA4AE

    Protected Sub categories_maintLoadItemFromRequest(item As categories_maintItem, ByVal EnableValidation As Boolean)
        item.category_name.SetValue(categories_maintcategory_name.Text)
        Try
            categories_maintcategory_image.ValidateFile()
            item.category_image.SetValue(categories_maintcategory_image.Text)
        Catch ex As InvalidOperationException 
            If ex.Message = "The file type is not allowed." Then
                categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_WrongType,"{res:cal_category_image}"))
            End If
            If ex.Message = "The file is too large." Then
                categories_maintErrors.Add("category_image",String.Format(Resources.strings.CCS_LargeFile,"{res:cal_category_image}"))
            End If
        End Try
        If EnableValidation Then
            item.Validate(categories_maintData)
        End If
        categories_maintErrors.Add(item.errors)
    End Sub
'End Record Form categories_maint LoadItemFromRequest method

'Record Form categories_maint GetRedirectUrl method @45-9D61B4A0

    Protected Function Getcategories_maintRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "categories.aspx"
        Dim p As String = parameters.ToString("GET","category_id;" + removeList,ViewState)
        If p = "" Then p = "?"
        Return redirect + p
    End Function
'End Record Form categories_maint GetRedirectUrl method

'Record Form categories_maint ShowErrors method @45-1E3FDBC1

    Protected Sub categories_maintShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To categories_maintErrors.Count - 1
        Select Case categories_maintErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & categories_maintErrors(i)
        End Select
        Next i
        categories_maintError.Visible = True
        categories_maintErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form categories_maint ShowErrors method

'Record Form categories_maint Insert Operation @45-3B9A3015

    Protected Sub categories_maint_Insert(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim item As categories_maintItem = New categories_maintItem()
        Dim ExecuteFlag As Boolean = True
        categories_maintIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form categories_maint Insert Operation

'Button Button_Insert OnClick. @48-0C285371
        If CType(sender,Control).ID = "categories_maintButton_Insert" Then
            RedirectUrl = Getcategories_maintRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @48-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form categories_maint BeforeInsert tail @45-E83154CE
    categories_maintParameters()
    categories_maintLoadItemFromRequest(item, EnableValidation)
    If categories_maintOperations.AllowInsert Then
        ErrorFlag=(categories_maintErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                categories_maintData.InsertItem(item)
            Catch ex As Exception
                categories_maintErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form categories_maint BeforeInsert tail

'Record Form categories_maint AfterInsert tail  @45-E8F928BD
            If Not(ErrorFlag) Then
                categories_maintcategory_image.SaveFile()
            End If
        End If
        ErrorFlag=(categories_maintErrors.Count > 0)
        If ErrorFlag Then
            categories_maintShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form categories_maint AfterInsert tail 

'Record Form categories_maint Update Operation @45-93161B5B

    Protected Sub categories_maint_Update(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim item As categories_maintItem = New categories_maintItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        categories_maintIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form categories_maint Update Operation

'Button Button_Update OnClick. @49-801A412E
        If CType(sender,Control).ID = "categories_maintButton_Update" Then
            RedirectUrl = Getcategories_maintRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @49-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form categories_maint Before Update tail @45-DDE932B5
        categories_maintParameters()
        categories_maintLoadItemFromRequest(item, EnableValidation)
        If categories_maintOperations.AllowUpdate Then
        ErrorFlag = (categories_maintErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                categories_maintData.UpdateItem(item)
            Catch ex As Exception
                categories_maintErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form categories_maint Before Update tail

'Record categories_maint Event AfterUpdate. Action Custom Code @52-73254650
    ' -------------------------
            'Delete the related records 
            Dim Conn As DataAccessObject = Settings.calendarDataAccessObject
            Dim SQL As String = ""
            Dim LanguageID As String = CStr(System.Web.HttpContext.Current.Session("locale"))
            Dim CategoryID As String = CommonFunctions.CCGetFromGet("category_id", "")

            If LanguageID = CommonFunctions.str_calendar_config("default_language") Then
                SQL = "UPDATE categories " & _
                    " SET category_name= " & _
                    Conn.ToSql(categories_maintcategory_name.Text, FieldType._Text) & _
                    " WHERE category_id=" + Conn.ToSql(CategoryID, FieldType._Integer)
                Conn.RunSql(SQL)
            End If

            SQL = "UPDATE categories_langs " & _
                " SET category_name= " & Conn.ToSql(categories_maintcategory_name.Text, FieldType._Text) & _
                " WHERE language_id= " & Conn.ToSql(LanguageID, FieldType._Text) & _
                " AND category_id=" & Conn.ToSql(CategoryID, FieldType._Integer)
            Conn.RunSql(SQL)
    ' -------------------------
'End Record categories_maint Event AfterUpdate. Action Custom Code

'Record Form categories_maint Update Operation tail @45-E8F928BD
            If Not(ErrorFlag) Then
                categories_maintcategory_image.SaveFile()
            End If
        End If
        ErrorFlag=(categories_maintErrors.Count > 0)
        If ErrorFlag Then
            categories_maintShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form categories_maint Update Operation tail

'Record Form categories_maint Delete Operation @45-84D08726
    Protected Sub categories_maint_Delete(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        categories_maintIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As categories_maintItem = New categories_maintItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form categories_maint Delete Operation

'Button Button_Delete OnClick. @50-F3BD4A97
        If CType(sender,Control).ID = "categories_maintButton_Delete" Then
            RedirectUrl = Getcategories_maintRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @50-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'DEL      ' -------------------------
'DEL              'Delete the related records 
'DEL              Dim Conn As DataAccessObject = Settings.calendarDataAccessObject
'DEL              Dim SQL As String = "DELETE FROM categories_langs WHERE category_id=" & _
'DEL                  Conn.ToSql(CommonFunctions.CCGetFromGet("category_id", ""), FieldType._Integer)
'DEL              Conn.RunSql(SQL)
'DEL      ' -------------------------


'Record Form BeforeDelete tail @45-132E431E
        categories_maintParameters()
        categories_maintLoadItemFromRequest(item, EnableValidation)
        If categories_maintOperations.AllowDelete Then
        ErrorFlag = (categories_maintErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                categories_maintData.DeleteItem(item)
            Catch ex As Exception
                categories_maintErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @45-2ED0F9F9
            If Not(ErrorFlag) Then
                categories_maintcategory_image.DeleteFile()
            End If
        End If
        If ErrorFlag Then
            categories_maintShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form categories_maint Cancel Operation @45-408C2B55

    Protected Sub categories_maint_Cancel(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim item As categories_maintItem = New categories_maintItem()
        categories_maintIsSubmitted = True
        Dim RedirectUrl As String = ""
        categories_maintLoadItemFromRequest(item, False)
'End Record Form categories_maint Cancel Operation

'Button Button_Cancel OnClick. @51-42D73E27
    If CType(sender,Control).ID = "categories_maintButton_Cancel" Then
        RedirectUrl = Getcategories_maintRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @51-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form categories_maint Cancel Operation tail @45-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form categories_maint Cancel Operation tail

'OnInit Event @1-6F9A483E
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Response.ContentEncoding = System.Text.Encoding.GetEncoding((CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo)).Encoding)
        categoriesContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        categoriesData = New categoriesDataProvider()
        categoriesOperations = New FormSupportedOperations(False, True, False, False, False)
        categories_maintData = New categories_maintDataProvider()
        categories_maintOperations = New FormSupportedOperations(False, True, True, True, True)
        If Not(DBUtility.AuthorizeUser(New String(){"100"})) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
'End OnInit Event

'OnInit Event tail @1-BB95D25C
    PageStyleName = Server.UrlEncode(PageStyleName)
    End Sub
'End OnInit Event tail

'InitializeComponent Event @1-EA5E2628
    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
    End Sub
    #End Region
'End InitializeComponent Event

'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

