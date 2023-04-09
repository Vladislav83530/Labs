using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using StudentApplicationSystem.ApplicantFactory.Interfaces;


namespace StudentApplicationSystem.ApplicantFactory.Json
{
    internal class ApplicantJsonValidator : IApplicantFileValidator
    {
        public bool IsValid(string fileName, string schema)
        {
            try
            {
                string input = File.ReadAllText(fileName);

                if (string.IsNullOrEmpty(input))
                    return false;

                string schema_ = File.ReadAllText(schema);

                JSchema jSchema = JSchema.Parse(schema_);
                JToken jToken = JToken.Parse(input);
                return jToken.IsValid(jSchema);
            }
            catch 
            {
                return false;
            }
        }
    }
}
