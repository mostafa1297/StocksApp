using System.ComponentModel.DataAnnotations;

namespace ServicesConstracts.CustomValidators
{
    public class MinimumOrderDateAttribute : ValidationAttribute
    {
        public string MinimumDateTime { get; set; }
        public string DefaultErrorMessage { get; set; } = "DateTime should be older than {0}";
        public MinimumOrderDateAttribute(string minimumDateTime)
        {
            MinimumDateTime = minimumDateTime;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return null;

            var date = (DateTime)value;
            var minDate = DateTime.Parse(MinimumDateTime);

            if (date >= minDate)
                return ValidationResult.Success;

            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDateTime));

            
        }
    }
}
