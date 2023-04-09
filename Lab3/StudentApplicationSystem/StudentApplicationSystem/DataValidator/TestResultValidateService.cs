using StudentApplicationSystem.DataValidator.Interfaces;
using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.DataValidator
{
    internal class TestResultValidateService : ITestResultValidateService
    {
        /// <summary>
        /// Validates a test result by checking if it falls within a valid range.
        /// </summary>
        /// <param name="testResult">The test result to validate.</param>
        /// <param name="subject"></param>
        /// <returns>True if the test result is valid, false otherwise.</returns>
        public bool ValidateTestResult(float testResult, Subject subject)
        {
            float maxZNOTestResult = 200;
            float minZNOTestResult = 100;
            float maxUniversityTestResult = 100;
            float minUniversityTestResult = 100;

            if (subject == Subject.UniversityTest && (testResult > maxUniversityTestResult || testResult < minUniversityTestResult))
                return false;
            else if (subject != Subject.UniversityTest && (testResult < minZNOTestResult || testResult > maxZNOTestResult))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Validates a date of passing test by checking if it falls within a valid range.
        /// </summary>
        /// <param name="dateOfPassing">The date of passing test to validate.</param>
        /// <param name="subject"></param>
        /// <returns>True if the date of passing test is valid, false otherwise.</returns>
        public bool ValidateDateOfPassingTest(DateTime dateOfPassing, Subject subject)
        {
            DateTime minDatePassingZNO = DateTime.Today.AddYears(-3);
            DateTime maxDateOfBirth = DateTime.UtcNow;

            if (subject != Subject.UniversityTest && (dateOfPassing < minDatePassingZNO || dateOfPassing > maxDateOfBirth))
                return false;
            else
                return true;
        }
    }
}
