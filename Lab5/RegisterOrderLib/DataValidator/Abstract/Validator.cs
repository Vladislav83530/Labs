using RegisterOrderLib.Models;

namespace RegisterOrderLib.DataValidator.Abstract
{
    internal abstract class Validator
    {
        protected Validator NextValidator;
        public void SetNext(Validator validator)
        {
            NextValidator = validator;
        }

        public abstract ValidationResult Validate(Order data, ValidationResult validationResult);
    }
}
