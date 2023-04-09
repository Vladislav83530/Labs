using Newtonsoft.Json;
using StudentApplicationSystem.ApplicantFactory.Interfaces;
using StudentApplicationSystem.Models;

namespace StudentApplicationSystem.ApplicantFactory.Json
{
    internal class ApplicantJsonLoader : IApplicantFileLoader
    {
        public List<Applicant> Load(string fileName)
        {
            var jsonData = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<Applicant>>(jsonData);
        }
    }
}
