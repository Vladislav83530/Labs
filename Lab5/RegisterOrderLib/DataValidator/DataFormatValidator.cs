using RegisterOrderLib.DataValidator.Abstract;
using RegisterOrderLib.Models;
using System.Text.RegularExpressions;

namespace RegisterOrderLib.DataValidator
{
    internal class DataFormatValidator : Validator
    {
        private readonly string _phoneNumberRegexPattern;
        private readonly string _emailRegexPattern;

        public DataFormatValidator(string phoneNumberRegexPattern, string emailRegexPattern)
        {
            _phoneNumberRegexPattern = phoneNumberRegexPattern;
            _emailRegexPattern = emailRegexPattern;
        }

        public override ValidationResult Validate(Order data, ValidationResult validationResult)
        {
            validationResult.FormatDataMessage = "Success";
            validationResult.FormatDataResult = true;

            bool isValidName = !string.IsNullOrEmpty(data.FirstName) && !string.IsNullOrEmpty(data.LastName);
            bool isValidPhoneNumber = Regex.IsMatch(data.PhoneNumber, _phoneNumberRegexPattern);
            bool isValidEmail = Regex.IsMatch(data.Email, _emailRegexPattern);
            bool isValidAddress = !string.IsNullOrEmpty(data.Address);
            bool isValidDeliveryType = data.DeliveryType != null;
            bool isValidPostOfficeNumber = data.PostOfficeNumber > 0;


            if (!isValidName)
            {
                validationResult.FormatDataResult = false;
                validationResult.FormatDataMessage = "First and last name can not be null or empty";
                return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
            }
            if (!isValidPhoneNumber)
            {
                validationResult.FormatDataResult = false;
                validationResult.FormatDataMessage = "Invalid format of phone number";
                return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
            }
            if (!isValidEmail)
            {
                validationResult.FormatDataResult = false;
                validationResult.FormatDataMessage = "Invalid format of email";
                return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
            }
            if (!isValidAddress)
            {
                validationResult.FormatDataResult = false;
                validationResult.FormatDataMessage = "Address is required";
                return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
            }
            if (!isValidDeliveryType)
            {
                validationResult.FormatDataResult = false;
                validationResult.FormatDataMessage = "Delivery type is required";
                return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
            }
            if (!isValidPostOfficeNumber)
            {
                validationResult.FormatDataResult = false;
                validationResult.FormatDataMessage = "Post office number can not be less than 0";
                return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
            }

            return NextValidator != null ? NextValidator.Validate(data, validationResult) : validationResult;
        }
    }
}
