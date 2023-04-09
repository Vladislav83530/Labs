using StudentApplicationSystem.Models.Enums;

namespace StudentApplicationSystem.Models
{
    [Serializable]
    public class TestResult
    {
        public Subject Subject { get; set; }
        public float Result { get; set; }
        public DateTime DateOfPassing { get; set; }
        public TestResult() { }

        public override string ToString()
        {
            return $"Subject: {Subject}, Result: {Result}, Date of Passing: {DateOfPassing.ToShortDateString()}";
        }
    }
}
