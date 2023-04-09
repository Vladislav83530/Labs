using StudentApplicationSystem.Models;

namespace StudentApplicationSystem.ApplicantFactory.Interfaces
{
    internal interface IApplicantFileLoader
    {
        List<Applicant> Load(string fileName);
    }
}
