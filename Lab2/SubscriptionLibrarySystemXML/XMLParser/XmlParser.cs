using SubscriptionLibrarySystemXML.XMLParser.Abstract;
using System.Reflection;
using System.Xml.Linq;
using System.Xml;

namespace SubscriptionLibrarySystemXML.XMLParser
{
    internal class XmlParser : IXmlParser
    {
        /// <summary>
        /// Parse XML to entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <returns>Entity T</returns>
        public T ParseFromXML<T>(object node) where T : new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            T result = new T();

            foreach (PropertyInfo property in properties)
            {
                object attributeValue = null;
                if (node is XElement element)
                    attributeValue = ParseXElementAttribute(property, element);
                else if (node is XmlNode xmlNode)
                    attributeValue = ParseXmlNodeAttribute(property, xmlNode);

                if (attributeValue != null)
                {
                    object value;
                    Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                    if (propertyType.IsEnum)
                        value = Enum.Parse(propertyType, attributeValue.ToString());
                    else
                        value = Convert.ChangeType(attributeValue, propertyType);

                    property.SetValue(result, value);
                }
            }

            return result;
        }

        /// <summary>
        /// Parse entity to XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer"></param>
        /// <param name="entity"></param>
        public void ParseToXML<T>(XmlWriter writer, T entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();

            writer.WriteStartElement(entity.GetType().Name.ToLower());

            foreach (PropertyInfo property in properties)
            {
                var propName = property.Name.ToLower();
                if (propName == "issueddatestring" || propName == "expectedreturndatestring")
                    continue;

                writer.WriteStartAttribute(propName);
                var propValue = property.GetValue(entity)?.ToString();
                writer.WriteString(propValue);
                writer.WriteEndAttribute();
            }

            writer.WriteEndElement();
        }

        private object ParseXElementAttribute(PropertyInfo property, XElement element)
        {
            XAttribute attribute = element.Attribute(property.Name.ToLower());
            if (attribute != null && !string.IsNullOrEmpty(attribute.Value))
            {
               return attribute.Value;
            }

            return null;
        }

        private object ParseXmlNodeAttribute(PropertyInfo property, XmlNode xmlNode)
        {
            XmlAttribute attribute = xmlNode.Attributes[property.Name.ToLower()];
            if (attribute != null && !string.IsNullOrEmpty(attribute.Value))
            {
                return attribute.InnerText;
            }

            return null;
        }
    }
}
