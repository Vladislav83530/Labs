namespace StudentApplicationSystem.ApplicantFactory.Interfaces
{
    internal interface IApplicantFileLoader
    {
        List<T> Load<T>(string fileName);
    }
}
