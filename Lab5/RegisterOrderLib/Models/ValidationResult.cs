namespace RegisterOrderLib.Models
{
    internal class ValidationResult
    {
        public string FormatDataMessage { get; set; } 
        public string SqlInjectionMessage { get; set; }
        public string XssMessage { get; set; }
        public bool FormatDataResult { get; set; }
        public bool SqlInjectionaResult { get; set; }
        public bool XssResult { get; set; }
    }
}
