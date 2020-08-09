using System.Globalization;
using System.Windows.Controls;

namespace Nedeljni1_Andreja_Kolesar.Validation
{
    class ValidMail:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string mail = value as string;

            if (Service.Service.UsedEmail(mail))
            {
                return new ValidationResult(false, "This mail is already taken");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
