using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.Models
{
    /// <summary>
    /// The Applicant class represents a person applying to a university.
    /// </summary>
    [Serializable]
    public class Applicant
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public List<TestResult> TestResults { get; set; }
        public List<Speciality> Specialities { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public EducationForm EducationForm { get; set; }

        public Applicant() { }
        public Applicant(string firstName, string lastName, string middleName, DateTime birthDate,
            List<TestResult> testResults, List<Speciality> specialties, EducationLevel educationLevel, EducationForm educationForm)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            BirthDate = birthDate;
            TestResults = testResults;
            Specialities = specialties;
            EducationLevel = educationLevel;
            EducationForm = educationForm;
        }

        public override string ToString()
        {
            var testResults = string.Join("\n\t ", TestResults);
            var specialities = string.Join("\n ", Specialities);
            return $"Name: {FirstName} {MiddleName} {LastName}\n" +
                   $"Birth Date: {BirthDate.ToShortDateString()}\n" +
                   $"Education Level: {EducationLevel}\n" +
                   $"Education Form: {EducationForm}\n" +
                   $"Test Results: \n\t[{testResults}]\n" +
                   $"Specialities: [{specialities}]";
        }
    }
}
