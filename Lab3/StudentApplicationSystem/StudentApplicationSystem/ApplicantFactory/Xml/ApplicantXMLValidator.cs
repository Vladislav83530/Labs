using StudentApplicationSystem.ApplicantFactory.Interfaces;
using System.Xml;

namespace StudentApplicationSystem.ApplicantFactory.Xml
{
    internal class ApplicantXmlValidator : IApplicantFileValidator
    {
        public bool IsValid(string fileName, string schema)
        {
            string input = File.ReadAllText(fileName);
            string schema_ = File.ReadAllText(schema);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, XmlReader.Create(new StringReader(schema_)));
            settings.ValidationType = ValidationType.Schema;

            try
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(input), settings))
                {
                    while (reader.Read()) ;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
