using SubscriptionLibrarySystemXML.FileProcessor.Abstract;
using SubscriptionLibrarySystemXML.Models;
using System.Reflection;
using System.Xml;

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
    }
}
