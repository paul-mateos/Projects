using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace AutomationTestAssistantDesktopApp
{   
    public class MemberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = value as BindingGroup;
            if (bindingGroup.Items.Count == 1)
            {
                object item = bindingGroup.Items[0];
                MemberViewModel viewModel = item as MemberViewModel;
                if (!viewModel.AreRequiredFieldsFilled())
                    return new ValidationResult(false, "Some of the required fields are not set!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
