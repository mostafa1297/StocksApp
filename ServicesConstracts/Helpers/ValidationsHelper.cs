using System.ComponentModel.DataAnnotations;

namespace ServicesConstracts.Helpers
{
    public static class ValidationsHelper
    {
        public static void UseValidations(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            if (!isValid)
                throw new ArgumentException(validationResult.FirstOrDefault()?.ErrorMessage);
        }
    }
}
