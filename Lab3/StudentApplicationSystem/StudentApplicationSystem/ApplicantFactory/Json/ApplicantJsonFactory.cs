using StudentApplicationSystem.ApplicantFactory.Interfaces;

namespace StudentApplicationSystem.ApplicantFactory.Json
{
    internal class ApplicantJsonFactory : IApplicantFileFactory
    {
        public IApplicantFileSaver CreateFileSaver()
        {
            return new ApplicantJsonSaver();
        }

        public IApplicantFileLoader CreateFileLoader()
        {
            return new ApplicantJsonLoader();
        }

        public IApplicantFileValidator CreateFileValidator()
        {
            return new ApplicantJsonValidator();
        }
    }
}
