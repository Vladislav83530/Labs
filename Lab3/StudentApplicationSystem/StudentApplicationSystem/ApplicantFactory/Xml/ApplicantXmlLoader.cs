using StudentApplicationSystem.ApplicantFactory.Interfaces;
using StudentApplicationSystem.Models;
using System.Xml.Serialization;

namespace StudentApplicationSystem.ApplicantFactory.Xml
{
    internal class ApplicantXmlLoader : IApplicantFileLoader
    {
        public List<Applicant> Load(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Applicant>));
            using (var reader = new StreamReader(fileName))
            {
                return (List<Applicant>)serializer.Deserialize(reader);
            }
        }
    }
}
