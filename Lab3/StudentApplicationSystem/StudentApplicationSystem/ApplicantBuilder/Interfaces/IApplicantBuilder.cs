using StudentApplicationSystem.Models;
using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.ApplicantBuilder_.Interfaces
{
    internal interface IApplicantBuilder
    {
        ApplicantBuilder SetFirstName(string firstName);
        ApplicantBuilder SetLastName(string lastName);
        ApplicantBuilder SetMiddleName(string middleName);
        ApplicantBuilder SetBirthDate(DateTime birthDate);
        ApplicantBuilder SetTestResults(List<TestResult> testResults);
        ApplicantBuilder SetSpecialities(List<Speciality> specialities);
        ApplicantBuilder SetEducationLevel(EducationLevel educationLevel);
        ApplicantBuilder SetEducationForm(EducationForm educationFrom);
        Applicant Build();
    }
}
