using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.CMS.Common.Validation
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public string StartDatePropertyName { get; set; }
        public string EndDatePropertyName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessage = "";

            var date = (DateTime)value;

            if (StartDatePropertyName != null)
            {
                var startDate = validationContext.ObjectType.GetProperty(StartDatePropertyName);
                if (startDate != null && !(date >= (DateTime)startDate.GetValue(validationContext.ObjectInstance)))
                    errorMessage += $"The {validationContext.DisplayName} must be after " +
                        $"{((DisplayAttribute)startDate.GetCustomAttributes(typeof(DisplayAttribute), true)[0]).Name}. ";
            }

            if (EndDatePropertyName != null)
            {
                var endDate = validationContext.ObjectType.GetProperty(EndDatePropertyName);
                if (endDate != null && !(date <= (DateTime)endDate.GetValue(validationContext.ObjectInstance)))
                    errorMessage += $"The {validationContext.DisplayName} must be before " +
                        $"{((DisplayAttribute)endDate.GetCustomAttributes(typeof(DisplayAttribute), true)[0]).Name}. ";
            }

            if (errorMessage.Length != 0)
            {
                return new ValidationResult(errorMessage);
            }
            return null;
        }
    }
}