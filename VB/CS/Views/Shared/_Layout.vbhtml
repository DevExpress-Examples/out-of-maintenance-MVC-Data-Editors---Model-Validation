<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>@ViewBag.Title</title>
    <style type="text/css">
        .flButton {
            margin: 8px 0px 0px 8px;
            float: left;
        }

        .formLayoutMaxWidth {
            max-width: 350px;
        }
    </style>
    @Html.DevExpress().GetStyleSheets(
                   New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
                   New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
                   New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}
               )
    @Html.DevExpress().GetScripts(
                    New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
                    New Script With {.ExtensionSuite = ExtensionSuite.Editors},
                    New Script With {.ExtensionSuite = ExtensionSuite.GridView}
                )
</head>
<body>
    @RenderBody()
</body>
</html>
