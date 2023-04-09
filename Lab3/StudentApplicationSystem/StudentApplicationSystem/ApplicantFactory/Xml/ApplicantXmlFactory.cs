using StudentApplicationSystem.ApplicantFactory.Interfaces;

namespace StudentApplicationSystem.ApplicantFactory.Xml
{
    internal class ApplicantXmlFactory : IApplicantFileFactory
    {
        public IApplicantFileSaver CreateFileSaver()
        {
            return new ApplicantXmlSaver();
        }

        public IApplicantFileLoader CreateFileLoader()
        {
            return new ApplicantXmlLoader();
        }

        public IApplicantFileValidator CreateFileValidator()
        {
            return new ApplicantXmlValidator();
        }
    }
}
