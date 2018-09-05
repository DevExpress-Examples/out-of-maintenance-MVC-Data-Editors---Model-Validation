Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI.WebControls
Imports CS.Models
Imports DevExpress.Web
Imports DevExpress.Web.Mvc

Namespace CS.Controllers
    Partial Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View("Index", New ModelValidationData())
        End Function
        <HttpPost>
        Public Function Index(ByVal validationData As ModelValidationData) As ActionResult
            If ModelState.IsValid Then
                Return View("ValidationSuccessPartial")
            End If

            Return View("Index", validationData)
        End Function
    End Class
    Public Class ExampleHelper

        Private Shared textBoxSettingsMethod_Renamed As Action(Of TextBoxSettings)

        Private Shared formLayoutItemSettingsMethod_Renamed As Action(Of MVCxFormLayoutItem)
        Public Shared ReadOnly Property TextBoxSettingsMethod() As Action(Of TextBoxSettings)
            Get
                If textBoxSettingsMethod_Renamed Is Nothing Then
                    textBoxSettingsMethod_Renamed = CreateTextBoxSettingsMethod()
                End If
                Return textBoxSettingsMethod_Renamed
            End Get
        End Property
        Public Shared ReadOnly Property FormLayoutItemSettingsMethod() As Action(Of MVCxFormLayoutItem)
            Get
                If formLayoutItemSettingsMethod_Renamed Is Nothing Then
                    formLayoutItemSettingsMethod_Renamed = CreateFormLayoutItemSettingsMethod()
                End If
                Return formLayoutItemSettingsMethod_Renamed
            End Get
        End Property
        Public Shared Function GetCaptionFromModel(ByVal propertyName As String, ByVal modelType As Type) As String
            Dim info = modelType.GetMember(propertyName)
            Dim attributes = info(0).GetCustomAttributes(GetType(DisplayAttribute), False)
            Dim caption = DirectCast(attributes(0), DisplayAttribute).Name
            Return caption
        End Function
        Private Shared Function CreateTextBoxSettingsMethod() As Action(Of TextBoxSettings)
            Return Sub(settings)
                       settings.Width = Unit.Percentage(100)
                       settings.Properties.ValidationSettings.Display = Display.Dynamic
                       settings.Properties.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Bottom
                       settings.ShowModelErrors = True
                       settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText
                   End Sub
        End Function
        Private Shared Function CreateFormLayoutItemSettingsMethod() As Action(Of MVCxFormLayoutItem)
            Return Sub(itemSettings)
                       itemSettings.Width = Unit.Percentage(100)
                       Dim editorSettings As Object = itemSettings.NestedExtensionSettings
                       editorSettings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText
                       editorSettings.Properties.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Bottom
                       editorSettings.Properties.ValidationSettings.Display = Display.Dynamic
                       editorSettings.ShowModelErrors = True
                       editorSettings.Width = Unit.Percentage(100)
                   End Sub
        End Function
    End Class
End Namespace