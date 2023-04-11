using StudentApplicationSystem.ApplicantFactory.Interfaces;
using System.Xml.Serialization;

namespace StudentApplicationSystem.ApplicantFactory.Xml
{
    internal class ApplicantXmlLoader : IApplicantFileLoader
    {
        public List<T> Load<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var reader = new StreamReader(fileName))
            {
                return (List<T>)serializer.Deserialize(reader);
            }
        }
    }
}
