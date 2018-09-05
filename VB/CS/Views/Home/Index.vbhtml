@imports CS.Controllers
@imports CS.Models
@ModelType ModelValidationData

@Code
    ViewBag.Title = "MVC Data Editors - Model Validation"
End Code

@Using Html.BeginForm("Index", "Home", FormMethod.Post, New With {.id = "validationForm", .class = "edit_form"})
    @Html.DevExpress().FormLayout(Sub(settings)
                                       settings.Name = "ModelValidationFormLayout"
                                       settings.Width = Unit.Percentage(100)
                                       settings.ControlStyle.CssClass = "formLayoutMaxWidth"
                                       settings.UseDefaultPaddings = False

                                       settings.Items.Add(Function(m) m.Name, ExampleHelper.FormLayoutItemSettingsMethod).HelpText = "Must be under 50 characters"
                                       settings.Items.Add(Function(m) m.Age, ExampleHelper.FormLayoutItemSettingsMethod).HelpText = "Must be between 18 and 100"
                                       settings.Items.Add(Function(m) m.Email, ExampleHelper.FormLayoutItemSettingsMethod).HelpText = "Must be a valid email"
                                       settings.Items.Add(Function(m) m.ArrivalDate, ExampleHelper.FormLayoutItemSettingsMethod)

                                       settings.Items.Add(Sub(itemSettings)
                                                              itemSettings.ShowCaption = DefaultBoolean.False
                                                              itemSettings.HorizontalAlign = FormLayoutHorizontalAlign.Right
                                                              itemSettings.SetNestedContent(Sub()
                                                                                                Html.DevExpress().Button(Sub(btnSettings)
                                                                                                                             btnSettings.Name = "btnUpdate"
                                                                                                                             btnSettings.Text = "Send"
                                                                                                                             btnSettings.ControlStyle.CssClass = "flButton"
                                                                                                                             btnSettings.UseSubmitBehavior = True
                                                                                                                         End Sub).Render()
                                                                                                Html.DevExpress().Button(Sub(btnSettings)
                                                                                                                             btnSettings.Name = "btnClear"
                                                                                                                             btnSettings.Text = "Clear"
                                                                                                                             btnSettings.ControlStyle.CssClass = "flButton"
                                                                                                                             btnSettings.ClientSideEvents.Click = "function(s, e){ ASPxClientEdit.ClearEditorsInContainer(); }"
                                                                                                                         End Sub).Render()
                                                                                            End Sub)
                                                          End Sub)
                                   End Sub).GetHtml()
End Using