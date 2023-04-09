using StudentApplicationSystem.Models;
using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.InputHandler.Interfaces
{
    internal interface IInputHandler
    {
        string GetStringInput(string prompt);
        DateTime GetDateTimeInput(string prompt);
        EducationLevel GetEducationLevelInput(string prompt);
        EducationForm GetEducationFormInput(string prompt);
        List<TestResult> GetTestResultsInput(string prompt);
        List<Speciality> GetSpecialityInput(string prompt);
    }
}
