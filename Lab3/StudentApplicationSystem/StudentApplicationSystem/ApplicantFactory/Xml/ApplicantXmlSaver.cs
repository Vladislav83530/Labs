using StudentApplicationSystem.ApplicantFactory.Interfaces;
using System.Xml.Serialization;

namespace StudentApplicationSystem.ApplicantFactory.Xml
{
    internal class ApplicantXmlSaver : IApplicantFileSaver
    {
        public void Save<T>(List<T> entities, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var writer = new StreamWriter($"{fileName}.xml"))
            {
                serializer.Serialize(writer, entities);
            }
        }
    }
}
