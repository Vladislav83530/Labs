namespace StudentApplicationSystem.ApplicantFactory.Interfaces
{
    internal interface IApplicantFileValidator
    {
        bool IsValid(string fileName, string schema);
    }
}
