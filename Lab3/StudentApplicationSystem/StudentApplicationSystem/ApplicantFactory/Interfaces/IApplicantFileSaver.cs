namespace StudentApplicationSystem.ApplicantFactory.Interfaces
{
    internal interface IApplicantFileSaver
    {
        void Save<T>(List<T> entities, string fileName);
    }
}
