using RegisterOrderLib.DataValidator.Abstract;
using RegisterOrderLib.Models;

namespace RegisterOrderLib.DataValidator
{
    internal class XssValidator : Validator
    {
        public override ValidationResult Validate(Order data, ValidationResult validationResult)
        {
            if (ContainsXssPayload(data))
            {
                validationResult.XssResult = false;
                validationResult.XssMessage = "XSS attack detected.";
            }
            else
            {
                validationResult.XssResult = true;
                validationResult.XssMessage = "Success";
            }

            return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
        }

        private bool ContainsXssPayload(Order data)
        {
            foreach (var property in typeof(Order).GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(data);
                    if (HasPotentialXssPayload(value))
                        return true;
                }
            }

            return false;
        }

        private bool HasPotentialXssPayload(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Contains("<script>") || input.Contains("javascript:"))
                    return true;
            }

            return false;
        }
    }
}
