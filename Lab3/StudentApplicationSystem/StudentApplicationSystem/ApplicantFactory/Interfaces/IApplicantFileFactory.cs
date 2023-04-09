namespace StudentApplicationSystem.ApplicantFactory.Interfaces
{
    internal interface IApplicantFileFactory
    {
        IApplicantFileSaver CreateFileSaver();
        IApplicantFileLoader CreateFileLoader();
        IApplicantFileValidator CreateFileValidator();
    }
}
