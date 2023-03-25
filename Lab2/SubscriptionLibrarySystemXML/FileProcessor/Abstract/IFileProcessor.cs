using SubscriptionLibrarySystemXML.Models;

namespace SubscriptionLibrarySystemXML.FileProcessor.Abstract
{
    internal interface IFileProcessor
    {
        void WriteFile(string fileName, Library library);
        //TODO:
        //void ReadFile(string fileName);
       // void DeserializeFile(string fileName);
    }
}
