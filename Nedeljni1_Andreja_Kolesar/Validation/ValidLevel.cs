using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nedeljni1_Andreja_Kolesar.Validation
{
    class ValidLevel:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string level = value as string;

            if (level=="1" || level=="2" || level=="3")
            {
                return new ValidationResult(true, null);
                
            }
            else
            {
                return new ValidationResult(false, "1,2 or 3 are are acceptable");
            }
        }
    }
}
