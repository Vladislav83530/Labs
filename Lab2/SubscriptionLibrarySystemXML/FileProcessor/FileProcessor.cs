using SubscriptionLibrarySystemXML.FileProcessor.Abstract;
using SubscriptionLibrarySystemXML.Models;
using SubscriptionLibrarySystemXML.XMLParser.Abstract;
using System.Xml;
using System.Xml.Serialization;

namespace SubscriptionLibrarySystemXML.FileProcessor
{
    internal class FileProcessor : IFileProcessor
    {
        private readonly IXmlParser _xmlParser;

        public FileProcessor(IXmlParser xmlParser)
        {
            _xmlParser = xmlParser;
        }

        /// <summary>
        /// Write library to XML file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="library"></param>
        public void WriteFile(string fileName, Library library)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(nameof(Library).ToLower());

                writer.WriteStartElement("readers");
                foreach (var reader in library.Readers)
                    _xmlParser.ParseToXML(writer, reader);
                writer.WriteEndElement();

                writer.WriteStartElement("books");
                foreach (var book in library.Books)
                    _xmlParser.ParseToXML(writer, book);
                writer.WriteEndElement();

                writer.WriteStartElement("subscriptions");
                foreach (var subscription in library.Subscriptions)
                    _xmlParser.ParseToXML(writer, subscription);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Read XML file user XMLDocument
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Library</returns>
        public Library ReadFile(string fileName)
        {
            Library library = new Library();
            XmlDocument doc = new XmlDocument();
            if (File.Exists(fileName) && ValidateXml(fileName, "schema"))
            {
                doc.Load(fileName);

                //get readers
                XmlNodeList readerNodes = doc.SelectNodes("//reader");
                foreach (XmlNode readerNode in readerNodes)
                {
                    Reader reader = _xmlParser.ParseFromXML<Reader>(readerNode);
                    library.Readers.Add(reader);
                }

                //get books
                XmlNodeList bookNodes = doc.SelectNodes("//book");
                foreach (XmlNode bookNode in bookNodes)
                {
                    Book book = _xmlParser.ParseFromXML<Book>(bookNode);
                    library.Books.Add(book);
                }

                //get subscriptions
                XmlNodeList subscriptionNodes = doc.SelectNodes("//subscription");
                foreach (XmlNode subscriptionNode in subscriptionNodes)
                {
                    Subscription subscription = _xmlParser.ParseFromXML<Subscription>(subscriptionNode);
                    library.Subscriptions.Add(subscription);
                }

                return library;
            }
            throw new Exception("Wrong format of file");
        }

        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Library DeserializeFile(string fileName)
        {         
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Library));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                Library? library = (Library)xmlSerializer.Deserialize(fs);
                return library;
            }
        }

        /// <summary>
        /// Validate XML
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="xsdFilePath"></param>
        /// <returns>IsValid? True/False</returns>
        private bool ValidateXml(string xmlFilePath, string xsdFilePath)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xsdFilePath);
                settings.ValidationType = ValidationType.Schema;
                using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                {
                    while (reader.Read()) { }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
