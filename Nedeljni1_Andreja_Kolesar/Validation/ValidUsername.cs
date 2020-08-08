using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nedeljni1_Andreja_Kolesar.Validation
{
    class ValidUsername: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = value as string;

            //if (Service.Service.UsedUsername(username))
            //{
            //    return new ValidationResult(false, "This username is already taken");
            //}
            //else
            //{
                return new ValidationResult(true, null);
            //}
        }
    }
}
