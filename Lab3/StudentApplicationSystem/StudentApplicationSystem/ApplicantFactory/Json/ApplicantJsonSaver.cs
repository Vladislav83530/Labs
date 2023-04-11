using Newtonsoft.Json;
using StudentApplicationSystem.ApplicantFactory.Interfaces;

namespace StudentApplicationSystem.ApplicantFactory.Json
{
    internal class ApplicantJsonSaver : IApplicantFileSaver
    {
        public void Save<T>(List<T> entities, string fileName)
        {
            var jsonData = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText($"{fileName}.json", jsonData);
        }
    }
}
