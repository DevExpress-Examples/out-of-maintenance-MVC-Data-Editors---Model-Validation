Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web

Namespace CS.Models
    Public Class ModelValidationData
        <Display(Name := "Name:"), Required(ErrorMessage := "Name is required"), StringLength(50, ErrorMessage := "Must be under 50 characters")> _
        Public Property Name() As String

        <Display(Name := "Age:"), Range(18, 100, ErrorMessage := "Must be between 18 and 100")> _
        Public Property Age() As Integer?

        <Display(Name := "Email:"), Required(ErrorMessage := "Email is required"), RegularExpression("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage := "Email is invalid")> _
        Public Property Email() As String

        <Display(Name := "Arrival Date:"), Required(ErrorMessage := "Arrival date is required")> _
        Public Property ArrivalDate() As Date?
    End Class
End Namespace