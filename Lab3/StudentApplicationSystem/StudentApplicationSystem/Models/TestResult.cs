using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.Models
{
    internal class TestResult
    {
        public Subject Subject { get; set; }
        public float Result { get; set; }
        public DateTime DateOfPassing { get; set; }
    }
}
