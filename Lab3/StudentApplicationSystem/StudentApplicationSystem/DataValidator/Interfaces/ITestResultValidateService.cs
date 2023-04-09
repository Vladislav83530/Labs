using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.DataValidator.Interfaces
{
    internal interface ITestResultValidateService
    {
        bool ValidateTestResult(float testResult, Subject subject);
        bool ValidateDateOfPassingTest(DateTime dateOfPassing, Subject subject);
    }
}
