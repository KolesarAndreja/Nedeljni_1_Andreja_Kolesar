using System.Globalization;
using System.Windows.Controls;

namespace Nedeljni1_Andreja_Kolesar.Validation
{
    class ValidPositionName:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;

            if (Service.Service.UsedPositionName(name))
            {
                return new ValidationResult(false, "This position name is not available");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
