using StudentApplicationSystem.Models;

namespace StudentApplicationSystem.ApplicantFactory.Interfaces
{
    internal interface IApplicantFileSaver
    {
        void Save(List<Applicant> applicants, string fileName);
    }
}
