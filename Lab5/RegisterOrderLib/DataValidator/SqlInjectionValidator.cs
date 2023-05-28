using RegisterOrderLib.DataValidator.Abstract;
using RegisterOrderLib.Models;

namespace RegisterOrderLib.DataValidator
{
    internal class SqlInjectionValidator : Validator
    {
        private static readonly string[] _sqlKeywords = { "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "ALTER" };

        public override ValidationResult Validate(Order data, ValidationResult validationResult)
        {
            if (ContainsSqlInjectionKeywords(data))
            {
                validationResult.SqlInjectionaResult = false;
                validationResult.SqlInjectionMessage = "SQL injection detected.";
            }
            else
            {
                validationResult.SqlInjectionaResult = true;
                validationResult.SqlInjectionMessage = "Success";
            }

            return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
        }

        private bool ContainsSqlInjectionKeywords(Order data)
        {
            foreach (var property in typeof(Order).GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(data);
                    if (ContainsSqlKeywords(value))
                        return true;
                }
            }

            return false;
        }

        private bool ContainsSqlKeywords(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                foreach (string keyword in _sqlKeywords)
                {
                    if (input.ToUpper().Contains(keyword))
                        return true;
                }
            }

            return false;
        }
    }
}
