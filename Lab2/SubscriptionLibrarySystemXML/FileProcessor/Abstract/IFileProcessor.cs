using SubscriptionLibrarySystemXML.Models;

namespace SubscriptionLibrarySystemXML.FileProcessor.Abstract
{
    internal interface IFileProcessor
    {
        void WriteFile(string fileName, Library library);
        Library ReadFile(string fileName);
        Library DeserializeFile(string fileName);
    }
}
