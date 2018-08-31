using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CS.Models;
using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace CS.Controllers
{
    public partial class HomeController : Controller {
        public ActionResult Index() {
            return View("Index", new ModelValidationData());
        }
        [HttpPost]
        public ActionResult Index(ModelValidationData validationData) {
            if(ModelState.IsValid) 
                return View("ValidationSuccessPartial");

            return View("Index", validationData);
        }
    }
    public class ExampleHelper {
        static Action<TextBoxSettings> textBoxSettingsMethod;
        static Action<MVCxFormLayoutItem> formLayoutItemSettingsMethod;
        public static Action<TextBoxSettings> TextBoxSettingsMethod {
            get {
                if(textBoxSettingsMethod == null)
                    textBoxSettingsMethod = CreateTextBoxSettingsMethod();
                return textBoxSettingsMethod;
            }
        }
        public static Action<MVCxFormLayoutItem> FormLayoutItemSettingsMethod {
            get {
                if(formLayoutItemSettingsMethod == null)
                    formLayoutItemSettingsMethod = CreateFormLayoutItemSettingsMethod();
                return formLayoutItemSettingsMethod;
            }
        }
        public static string GetCaptionFromModel(string propertyName, Type modelType) {
            var info = modelType.GetMember(propertyName);
            var attributes = info[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            var caption = ((DisplayAttribute)attributes[0]).Name;
            return caption;
        }
        static Action<TextBoxSettings> CreateTextBoxSettingsMethod() {
            return settings => {
                settings.Width = Unit.Percentage(100);
                settings.Properties.ValidationSettings.Display = Display.Dynamic;
                settings.Properties.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Bottom;
                settings.ShowModelErrors = true;
                settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
            };
        }
        static Action<MVCxFormLayoutItem> CreateFormLayoutItemSettingsMethod() {
            return itemSettings => {
                itemSettings.Width = Unit.Percentage(100);
                dynamic editorSettings = itemSettings.NestedExtensionSettings;
                editorSettings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                editorSettings.Properties.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Bottom;
                editorSettings.Properties.ValidationSettings.Display = Display.Dynamic;
                editorSettings.ShowModelErrors = true;
                editorSettings.Width = Unit.Percentage(100);
            };
        }
    }
}