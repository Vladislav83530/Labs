using StudentApplicationSystem.ApplicantFactory.Interfaces;
using StudentApplicationSystem.Models;
using System.Xml.Serialization;

namespace StudentApplicationSystem.ApplicantFactory.Xml
{
    internal class ApplicantXmlSaver : IApplicantFileSaver
    {
        public void Save(List<Applicant> applicants, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Applicant>));
            using (var writer = new StreamWriter($"{fileName}.xml"))
            {
                serializer.Serialize(writer, applicants);
            }
        }
    }
}
