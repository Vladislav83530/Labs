using SubscriptionLibrarySystemXML.FileProcessor.Abstract;
using SubscriptionLibrarySystemXML.Models;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace SubscriptionLibrarySystemXML.FileProcessor
{
    internal class FileProcessor : IFileProcessor
    {
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
                    WriteToXML(writer, reader);
                writer.WriteEndElement();

                writer.WriteStartElement("books");
                foreach (var book in library.Books)
                    WriteToXML(writer, book);
                writer.WriteEndElement();

                writer.WriteStartElement("subscriptions");
                foreach (var subscription in library.Subscriptions)
                    WriteToXML(writer, subscription);
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
            if (File.Exists(fileName))
            {
                doc.Load(fileName);

                //get readers
                XmlNodeList readerNodes = doc.SelectNodes("//reader");
                foreach (XmlNode readerNode in readerNodes)
                {
                    Reader reader = ReadFromXML<Reader>(readerNode);
                    library.Readers.Add(reader);
                }

                //get books
                XmlNodeList bookNodes = doc.SelectNodes("//book");
                foreach (XmlNode bookNode in bookNodes)
                {
                    Book book = ReadFromXML<Book>(bookNode);
                    library.Books.Add(book);
                }

                //get subscriptions
                XmlNodeList subscriptionNodes = doc.SelectNodes("//subscription");
                foreach (XmlNode subscriptionNode in subscriptionNodes)
                {
                    Subscription subscription = ReadFromXML<Subscription>(subscriptionNode);
                    library.Subscriptions.Add(subscription);
                }

                return library;
            }
            return null;
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
        /// Write entitny to XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer"></param>
        /// <param name="entity"></param>
        private void WriteToXML<T>(XmlWriter writer, T entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();

            writer.WriteStartElement(entity.GetType().Name.ToLower());

            foreach (PropertyInfo property in properties)
            {
                var propName = property.Name.ToLower();
                writer.WriteStartAttribute(propName);
                var propValue = property.GetValue(entity)?.ToString();
                writer.WriteString(propValue);
                writer.WriteEndAttribute();
            }

            writer.WriteEndElement();
        }

        /// <summary>
        /// Read entity from XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private T ReadFromXML<T>(XmlNode node) where T : new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            T result = new T();

            foreach (PropertyInfo property in properties)
            {
                XmlAttribute attribute = node.Attributes[property.Name.ToLower()];
                if (attribute != null && !string.IsNullOrEmpty(attribute.Value))
                {
                    object value;
                    Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                    if (propertyType.IsEnum)
                        value = Enum.Parse(propertyType, attribute.Value);
                    else
                        value = Convert.ChangeType(attribute.Value, propertyType);

                    property.SetValue(result, value);
                }
            }

            return result;
        }
    }
}
