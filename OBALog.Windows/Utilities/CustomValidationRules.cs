using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Text.RegularExpressions;

namespace OBALog.Windows
{

    internal class CustomPasswordValidationRule : ValidationRule
    {
        public CustomPasswordValidationRule()
        {
            CaseSensitive = false;
            ErrorText = "Password constraints not met / password is blank.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
        }

        public override bool Validate(Control control, object value)
        {
            var password = value.ToString();
            Match m = Regex.Match(password, "^(?=.*\\d).{6,20}$", RegexOptions.IgnoreCase);
            return (password.Trim().IsNotEmpty() && m.Success);
        }
    }
    internal class EmailValidation : ValidationRule
    {
        public EmailValidation()
        {
            CaseSensitive = false;
            ErrorText = "Invalid email address.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
        }

        public override bool Validate(Control control, object value)
        {
            if (value != null && value.ToString().IsNotEmpty())
            {
                var email = value.ToString();
                Match m = Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);
                return (email.Trim().IsNotEmpty() && m.Success);
            }
            else
            {
                return true;
            }
        }
    }
    internal class PhoneValidation : ValidationRule
    {
        public PhoneValidation()
        {
            CaseSensitive = false;
            ErrorText = "Invalid phone number.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
        }

        public override bool Validate(Control control, object value)
        {
            if (value != null && value.ToString().IsNotEmpty())
            {
                var tel = value.ToString();
                Match m = Regex.Match(tel, "^[0-9|+]{10,12}$", RegexOptions.IgnoreCase);
                return (tel.Trim().IsNotEmpty() && m.Success);
            }
            else
            {
                return true;
            }
        }
    }
    internal class DateValidation : ValidationRule
    {
        public DateValidation()
        {
            CaseSensitive = false;
            ErrorText = "Invalid year. Enter year between 1900 and 2200.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
        }

        public override bool Validate(Control control, object value)
        {
            var year = Convert.ToInt32(value.ToString());
            return (year.ToString().Length == 4 && year < 2200 && year > 1900);
        }
    }
    internal class ReceiptAmountValidation : ValidationRule
    {
        public ReceiptAmountValidation()
        {
            CaseSensitive = false;
            ErrorText = "This field is required. Enter a valid receipt amount.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
        }

        public override bool Validate(Control control, object value)
        {
            if (value != null && Array.Exists(Configurations.ReceiptAmount, element => element == Decimal.ToInt32(Convert.ToDecimal(value))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    internal class TelephoneControlValidation : ValidationRule
    {
        public TelephoneControlValidation()
        {
            CaseSensitive = false;
            ErrorText = "This field is required. Enter a valid phone number.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
        }

        public override bool Validate(Control control, object value)
        {
            if (Configurations.TelephoneValidation)
            {
                if (value != null)
                {
                    var tel = value.ToString();
                    Match m = Regex.Match(tel, "^[0-9|+]{10,12}$", RegexOptions.IgnoreCase);
                    return (tel.Trim().IsNotEmpty() && m.Success);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    internal class MobileControlValidation : ValidationRule
    {
        public MobileControlValidation()
        {
            CaseSensitive = false;
            ErrorText = "This field is required. Enter a valid phone number.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;

        }

        public override bool Validate(Control control, object value)
        {
            if (Configurations.MobileValidation)
            {
                if (value != null)
                {
                    var tel = value.ToString();
                    Match m = Regex.Match(tel, "^[0-9|+]{10,12}$", RegexOptions.IgnoreCase);
                    return (tel.Trim().IsNotEmpty() && m.Success);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    internal class EmailControlValidation : ValidationRule
    {
        public EmailControlValidation()
        {
            CaseSensitive = false;
            ErrorText = "This field is required. Enter a valid email address.";
            ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
        }

        public override bool Validate(Control control, object value)
        {
            if (Configurations.EmailValidation)
            {
                if (value != null)
                {
                    var email = value.ToString();
                    Match m = Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);

                    return (email.Trim().IsNotEmpty() && m.Success);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
