using StudentApplicationSystem.ApplicantBuilder_;
using StudentApplicationSystem.DataValidator.Interfaces;
using StudentApplicationSystem.InputHandler.Interfaces;
using StudentApplicationSystem.Models;

namespace StudentApplicationSystem
{
    internal class InputManager
    {
        private readonly IInputHandler _inputHandler;
        private readonly IApplicantValidateService _applicantValidateService;

        public InputManager(IInputHandler inputHandler, IApplicantValidateService applicantValidateService)
        {
            _inputHandler = inputHandler;
            _applicantValidateService = applicantValidateService;
        }

        /// <summary>
        /// Reads applicant data from the console and returns a new Applicant object.
        /// </summary>
        /// <returns>A new Applicant object.</returns>
        public Applicant ReadApplicant()
        {
            var builder = new ApplicantBuilder(_applicantValidateService);
            ReadField("First name:", _inputHandler.GetStringInput, builder.SetFirstName);
            ReadField("Last name:", _inputHandler.GetStringInput, builder.SetLastName);
            ReadField("Middle name:", _inputHandler.GetStringInput, builder.SetMiddleName);
            ReadField("Date of birth (YYYY-MM-DD):", _inputHandler.GetDateTimeInput, builder.SetBirthDate);
            ReadField("Test results:", _inputHandler.GetTestResultsInput, builder.SetTestResults);
            ReadField("Specialities:", _inputHandler.GetSpecialityInput, builder.SetSpecialities);
            ReadField("Education level:", _inputHandler.GetEducationLevelInput, builder.SetEducationLevel);
            ReadField("Education Forms:", _inputHandler.GetEducationFormInput, builder.SetEducationForm);
            return builder.Build();
        }

        /// <summary>
        /// Reads the value of a field from the console and passes it to the corresponding Set method in the ApplicantBuilder object.
        /// </summary>
        /// <typeparam name="T">The type of the value to be read.</typeparam>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <param name="inputHandler">A function to convert the entered string to a value of type T.</param>
        /// <param name="setter">A function to set the value in the ApplicantBuilder object.</param>
        public void ReadField<T>(string prompt, Func<string, T> inputHandler, Func<T, ApplicantBuilder> setter)
        {
            while (true)
            {
                try
                {
                    T value = inputHandler(prompt);
                    setter(value);
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    continue;
                }
            }
        }
    }
}
