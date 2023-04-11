using StudentApplicationSystem.DataValidator.Interfaces;
using StudentApplicationSystem.Models;
using StudentApplicationSystem.Models.Enums;
using System.Text.RegularExpressions;

namespace StudentApplicationSystem.DataValidator
{
    internal class ApplicantValidateService : IApplicantValidateService
    {
        private readonly ITestResultValidateService _testResultValidator;

        public ApplicantValidateService(ITestResultValidateService testResultValidator)
        {
            _testResultValidator = testResultValidator;
        }

         /// <summary>
        /// Validates a name using a regular expression.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>True if the name is valid, false otherwise.</returns>
        public bool ValidateName(string name)
        {
            Regex regex = new Regex("^[a-zA-Z-]+$");
            if (regex.IsMatch(name))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Validates a birth date by checking if it falls within a valid range.
        /// </summary>
        /// <param name="birthDate">The birth date to validate.</param>
        /// <returns>True if the birth date is valid, false otherwise.</returns>
        public bool ValidateBirthDate(DateTime birthDate)
        {
            DateTime minDateOfBirth = new DateTime(1900, 1, 1);
            DateTime maxDateOfBirth = DateTime.UtcNow;

            if (birthDate > minDateOfBirth && birthDate < maxDateOfBirth)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Validates a test results.
        /// </summary>
        /// <param name="testResults">The test results to validate.</param>
        /// <returns>True if the test results is valid, false otherwise.</returns>
        public bool ValidateTestResults(List<TestResult> testResults, out string validateMessage)
        {
            validateMessage = string.Empty;
            foreach (TestResult testResult in testResults)
            {
                if (testResult != null)
                {
                    bool isValidTestResult = _testResultValidator.ValidateTestResult(testResult.Result, testResult.Subject);
                    bool isValidDateOfPassingTest = _testResultValidator.ValidateDateOfPassingTest(testResult.DateOfPassing, testResult.Subject);

                    if (!isValidTestResult || !isValidDateOfPassingTest)
                        validateMessage += $"{testResult.Subject} with result {testResult.Result} is invalid. May be invalid passing date. Try again";
                }
            }

            return string.IsNullOrEmpty(validateMessage) ? true : false;
        }

        /// <summary>
        /// Validates if all required subjects are present in the test results subjects.
        /// </summary>
        /// <param name="requiredSubjects">The list of required subjects.</param>
        /// <param name="testResult">The list of test results.</param>
        /// <returns>True if all required subjects are present, false otherwise.</returns>
        public bool ValidateRequiredSubject(List<Subject> requiredSubjects, List<TestResult> testResult)
        {
            var subjectsInTestResult = testResult.Select(tr => tr.Subject);
            return requiredSubjects.All(rs => subjectsInTestResult.Contains(rs));         
        }
    }
}
