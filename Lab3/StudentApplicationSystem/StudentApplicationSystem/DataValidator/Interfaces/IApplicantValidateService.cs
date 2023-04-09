using StudentApplicationSystem.Models;
using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.DataValidator.Interfaces
{
    internal interface IApplicantValidateService
    {
        bool ValidateName(string name);
        bool ValidateBirthDate(DateTime birthDate);
        bool ValidateTestResults(List<TestResult> testResults, out string validateMessage);
        bool ValidateRequiredSubject(List<Subject> requiredSubjects, List<TestResult> testResult);
    }
}
