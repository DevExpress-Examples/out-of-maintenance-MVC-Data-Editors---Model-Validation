
# MVC Data Editors - How to perform model validation

**What is "Model Validation"?**  See the following MSDN article to learn how the model validation works:  [How to: Validate Model Data Using DataAnnotations Attributes](http://msdn.microsoft.com/en-us/library/ee256141(v=vs.100).aspx).

This demo illustrates how user input can be easily validated using a model-based ASP.NET MVC validation approach. DevExpress MVC extensions can be seamlessly integrated into the ASP.NET MVC validation infrastructure.

DevExpress MVC Editors have their own container for displaying validation error messages, which can be enabled via the  **ShowModelErrors**  property. This container allows you to manipulate validation messages more flexibly, then via the standard  **Html.ValidationMessageFor**  helper. You can control how errors should be displayed within editors by using settings exposed via the editor  [ValidationSettings](https://documentation.devexpress.com/#AspNet/clsDevExpressWebValidationSettingstopic)  property, such as the  [ErrorDisplayMode](http://help.devexpress.com/#AspNet/DevExpressWebASPxEditorsValidationSettings_ErrorDisplayModetopic).

  
See Also:

-   [Online Documentation - Model Validation](http://help.devexpress.com/#AspNet/CustomDocument12058)
