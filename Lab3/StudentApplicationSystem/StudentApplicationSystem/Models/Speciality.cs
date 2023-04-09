using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.Models
{
    [Serializable]
    public class Speciality
    {
        public SpecialityTitle Title { get; set; }  
        public string University { get; set; }
        public List<Subject> RequiredSubjects { get; set; }
        public Speciality() { }
        public override string ToString()
        {
            var requiredSubjects = string.Join("\n\t ", RequiredSubjects);
            return $"Title: {Title}, University: {University}, Required Subjects: \n\t[{requiredSubjects}]";
        }
    }
}
