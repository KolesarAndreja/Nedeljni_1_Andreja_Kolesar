using System.Globalization;
using System.Windows.Controls;

namespace Nedeljni1_Andreja_Kolesar.Validation
{
    class ValidBackupPassword : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string backup = value as string;

            if (backup.Length<5)
            {
                return new ValidationResult(false, "must be at least 5 characters");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
