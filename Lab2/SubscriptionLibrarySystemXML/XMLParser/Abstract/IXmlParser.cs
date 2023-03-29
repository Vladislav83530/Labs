using System.Xml;

namespace SubscriptionLibrarySystemXML.XMLParser.Abstract
{
    internal interface IXmlParser
    {
        T ParseFromXML<T>(object node) where T : new();
        void ParseToXML<T>(XmlWriter writer, T entity);
    }
}
