using StudentApplicationSystem.ApplicantBuilder_.Interfaces;
using StudentApplicationSystem.Models.Enums;
using StudentApplicationSystem.Models;
using StudentApplicationSystem.DataValidator.Interfaces;

namespace StudentApplicationSystem.ApplicantBuilder_
{
    internal class ApplicantBuilder : IApplicantBuilder
    {
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private DateTime _birthDate;
        private List<TestResult> _testResults;
        private List<Speciality> _specialities;
        private EducationLevel _educationLevel;
        private EducationForm _educationForm;

        private readonly IApplicantValidateService _validateService;

        public ApplicantBuilder(IApplicantValidateService validateService)
        {
            _validateService = validateService;
        }

        /// <summary>
        /// Sets the first name of an applicant and validates it.
        /// </summary>
        /// <param name="firstName">The first name of the applicant.</param>
        /// <returns>The current instance of ApplicantBuilder.</returns>
        public ApplicantBuilder SetFirstName(string firstName)
        {
            bool isValid = _validateService.ValidateName(firstName);
            if (!isValid)
                throw new ArgumentException("Applicant first name isn't valid");

            _firstName = firstName;
            return this;
        }

        /// <summary>
        /// Sets the last name of an applicant and validates it.
        /// </summary>
        /// <param name="firstName">The last name of the applicant.</param>
        /// <returns>The current instance of ApplicantBuilder.</returns>
        public ApplicantBuilder SetLastName(string lastName)
        {
            bool isValid = _validateService.ValidateName(lastName);
            if (!isValid)
                throw new ArgumentException("Applicant last name isn't valid");

            _lastName = lastName;
            return this;
        }

        /// <summary>
        /// Sets the middle name of an applicant and validates it.
        /// </summary>
        /// <param name="firstName">The middle name of the applicant.</param>
        /// <returns>The current instance of ApplicantBuilder.</returns>
        public ApplicantBuilder SetMiddleName(string middleName)
        {
            bool isValid = _validateService.ValidateName(middleName);
            if (!isValid)
                throw new ArgumentException("Applicant middle name isn't valid");

            _middleName = middleName;
            return this;
        }

        /// <summary>
        /// Sets the applicante date of birth and validates it.
        /// </summary>
        /// <param name="firstName">The applicante date of birth.</param>
        /// <returns>The current instance of ApplicantBuilder.</returns>
        public ApplicantBuilder SetBirthDate(DateTime birthDate)
        {
            bool isValid = _validateService.ValidateBirthDate(birthDate);
            if (!isValid)
                throw new ArgumentOutOfRangeException("Applicant date of birth isn't valid");

            _birthDate = birthDate;
            return this;
        }

        /// <summary>
        /// Sets the test results and validates it.
        /// </summary>
        /// <param name="testResults">The applicante test results.</param>
        /// <returns>The current instance of ApplicationBuilder.</returns>
        /// <exception cref="ArgumentException"></exception>
        public ApplicantBuilder SetTestResults(List<TestResult> testResults)
        {
            string validationMessage;
            bool isValid = _validateService.ValidateTestResults(testResults, out validationMessage);
            if (!isValid)
                throw new ArgumentException(validationMessage);

            _testResults = testResults;
            return this;
        }

        /// <summary>
        /// Sets the specialities of an applicant and validates if all required subjects are present in the test results subjects.
        /// </summary>
        /// <param name="specialities">The list of specialities.</param>
        /// <returns>The current instance of ApplicantBuilder.</returns>
        public ApplicantBuilder SetSpecialities(List<Speciality> specialities)
        {
            if (_testResults == null)
                throw new ArgumentNullException("Test/ZNO results are not set");

            foreach (Speciality speciality in specialities)
            {
                bool isValid = _validateService.ValidateRequiredSubject(speciality.RequiredSubjects, _testResults);
                if (!isValid)
                    throw new ArgumentException($"For {speciality.Title} applicant have not necessary subject tests.");
            }
            _specialities = specialities;
            return this;
        }

        /// <summary>
        /// Sets the education level of an applicant.
        /// </summary>
        /// <param name="educationLevel">The education level of the applicant.</param>
        /// <returns>The current instance of ApplicantBuilder.</returns>
        public ApplicantBuilder SetEducationLevel(EducationLevel educationLevel)
        {
            _educationLevel = educationLevel;
            return this;
        }

        /// <summary>
        /// Sets the education form of an applicant.
        /// </summary>
        /// <param name="educationFrom">The education form of the applicant.</param>
        /// <returns>The current instance of ApplicantBuilder.</returns>
        public ApplicantBuilder SetEducationForm(EducationForm educationFrom)
        {
            _educationForm = educationFrom;
            return this;
        }

        /// <summary>
        /// Builds and returns a new Applicant object using the values set in the ApplicantBuilder.
        /// </summary>
        /// <returns>A new Applicant object.</returns>
        public Applicant Build()
        {
            return new Applicant(_firstName, _lastName, _middleName, _birthDate, _testResults, _specialities, _educationLevel, _educationForm);
        }
    }
}
