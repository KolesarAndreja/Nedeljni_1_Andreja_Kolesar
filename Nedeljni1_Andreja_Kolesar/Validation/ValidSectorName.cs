using System.Globalization;
using System.Windows.Controls;

namespace Nedeljni1_Andreja_Kolesar.Validation
{
    class ValidSectorName:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;

            if (Service.Service.UsedSectorName(name))
            {
                return new ValidationResult(false, "This sector name is not available");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
