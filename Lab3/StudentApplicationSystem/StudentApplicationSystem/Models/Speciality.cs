using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.Models
{
    internal class Speciality
    {
        public SpecialityTitle Title { get; set; }  
        public string University { get; set; }
        public List<Subject> RequiredSubjects { get; set; }
    }
}
