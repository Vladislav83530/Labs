using Newtonsoft.Json;
using StudentApplicationSystem.ApplicantFactory.Interfaces;

namespace StudentApplicationSystem.ApplicantFactory.Json
{
    internal class ApplicantJsonLoader : IApplicantFileLoader
    {
        public List<T> Load<T>(string fileName)
        {
            var jsonData = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}
