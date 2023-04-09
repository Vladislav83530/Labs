using StudentApplicationSystem.InputHandler.Interfaces;
using StudentApplicationSystem.Models;
using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.InputHandler
{
    internal class InputHandler : IInputHandler
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public InputHandler(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        /// <summary>
        /// Prompts the user to enter a string and returns the entered value.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>The entered string value.</returns>
        public string GetStringInput(string prompt)
        {
            _consoleWrapper.Write($"{prompt} ");
            return _consoleWrapper.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Prompts the user to enter a date and returns the entered value.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>The entered date value.</returns>
        public DateTime GetDateTimeInput(string prompt)
        {
            while (true)
            {
                _consoleWrapper.Write($"{prompt} ");
                var input = _consoleWrapper.ReadLine();
                if (DateTime.TryParse(input, out var date))
                {
                    return date;
                }

                _consoleWrapper.WriteLine("Invalid date format. Please try again.");
            }
        }

        /// <summary>
        /// Prompts the user to enter an education level and returns the entered value.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>The entered EducationLevel value.</returns>
        public EducationLevel GetEducationLevelInput(string prompt)
        {
            while (true)
            {
                _consoleWrapper.Write($"{prompt} ");
                var input = _consoleWrapper.ReadLine()?.ToUpperInvariant();

                if (Enum.TryParse<EducationLevel>(input, out var educationLevel))
                {
                    return educationLevel;
                }

                _consoleWrapper.WriteLine("Invalid input. Please enter 'Bachelor - 0 ', 'Master - 1', or 'PhD - 2'.");
            }
        }

        /// <summary>
        /// Prompts the user to enter an education form and returns the entered value.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>The entered EducationForm value.</returns>
        public EducationForm GetEducationFormInput(string prompt)
        {
            while (true)
            {
                _consoleWrapper.Write($"{prompt} ");
                var input = _consoleWrapper.ReadLine()?.ToUpperInvariant();

                if (Enum.TryParse<EducationForm>(input, out var educationForm))
                {
                    return educationForm;
                }

                _consoleWrapper.WriteLine("Invalid input. Please enter 'Budget - 0' or 'Contract - 1'.");
            }
        }

        /// <summary>
        /// Prompts the user to enter test results and returns a list of TestResult objects.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>A list of TestResult objects.</returns>
        public List<TestResult> GetTestResultsInput(string prompt)
        {
            var testResults = new List<TestResult>();

            while (true)
            {
                _consoleWrapper.WriteLine(prompt);
                _consoleWrapper.WriteLine("Enter subject (or 'Q' to quit): ");
                Subject[] values = (Subject[])Enum.GetValues(typeof(Subject));
                for (int i = 0; i < values.Length; i++)
                {
                    _consoleWrapper.WriteLine($"{values[i]} - {i}");
                }
                var subjectInput = _consoleWrapper.ReadLine()?.ToUpperInvariant();

                if (subjectInput == "Q")
                {
                    if (testResults.Count == 0)
                    {
                        _consoleWrapper.WriteLine("You must enter test results. Please try again.");
                        continue;
                    }
                    else
                     break;
                }

                if (!Enum.TryParse<Subject>(subjectInput, out var subject))
                {
                    _consoleWrapper.WriteLine("Invalid subject. Please try again.");
                    continue;
                }

                _consoleWrapper.Write("Enter result: ");
                var resultInput = _consoleWrapper.ReadLine();

                if (!float.TryParse(resultInput, out var result))
                {
                    _consoleWrapper.WriteLine("Invalid result. Please try again.");
                    continue;
                }

                _consoleWrapper.Write("Enter date of passing (yyyy-mm-dd): ");
                var dateInput = _consoleWrapper.ReadLine();

                if (!DateTime.TryParse(dateInput, out var dateOfPassing))
                {
                    _consoleWrapper.WriteLine("Invalid date. Please try again.");
                    continue;
                }

                testResults.Add(new TestResult { Subject = subject, Result = result, DateOfPassing = dateOfPassing });
            }

            return testResults;
        }

        /// <summary>
        /// Prompts the user to enter speciality information and returns a list of Speciality objects.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>A list of Speciality objects.</returns>
        public List<Speciality> GetSpecialityInput(string prompt)
        {
            var specialities = new List<Speciality>();

            while (true)
            {
                _consoleWrapper.WriteLine(prompt);
                _consoleWrapper.Write("Enter speciality title (or 'Q' to quit): ");
                SpecialityTitle[] values = (SpecialityTitle[])Enum.GetValues(typeof(SpecialityTitle));
                for (int i = 0; i < values.Length; i++)
                {
                    _consoleWrapper.WriteLine($"{values[i]} - {i}");
                }
                var titleInput = _consoleWrapper.ReadLine()?.ToUpperInvariant();

                if (titleInput == "Q")
                {
                    if (specialities.Count == 0)
                    {
                        _consoleWrapper.WriteLine("You must enter specialities. Please try again.");
                        continue;
                    }
                    else
                        break;
                }

                if (!Enum.TryParse<SpecialityTitle>(titleInput, out var title))
                {
                    _consoleWrapper.WriteLine("Invalid title. Please try again.");
                    continue;
                }

                _consoleWrapper.Write("Enter university: ");
                var university = _consoleWrapper.ReadLine();

                var requiredSubjects = new List<Subject>();
                while (true)
                {
                    _consoleWrapper.Write("Enter required subject (or 'Q' to quit): ");
                    var subjectInput = _consoleWrapper.ReadLine()?.ToUpperInvariant();

                    if (subjectInput == "Q")
                    {
                        if (requiredSubjects.Count == 0)
                        {
                            _consoleWrapper.WriteLine("You must enter required subjects. Please try again.");
                            continue;
                        }
                        else
                            break;
                    }

                    if (!Enum.TryParse<Subject>(subjectInput, out var subject))
                    {
                        _consoleWrapper.WriteLine("Invalid subject. Please try again.");
                        continue;
                    }

                    requiredSubjects.Add(subject);
                }

                specialities.Add(new Speciality { Title = title, University = university, RequiredSubjects = requiredSubjects });
            }

            return specialities;
        }
    }
}
