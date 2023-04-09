using Newtonsoft.Json;
using StudentApplicationSystem.ApplicantFactory.Interfaces;
using StudentApplicationSystem.Models;

namespace StudentApplicationSystem.ApplicantFactory.Json
{
    internal class ApplicantJsonSaver : IApplicantFileSaver
    {
        public void Save(List<Applicant> applicants, string fileName)
        {
            var jsonData = JsonConvert.SerializeObject(applicants, Formatting.Indented);
            File.WriteAllText($"{fileName}.json", jsonData);
        }
    }
}
