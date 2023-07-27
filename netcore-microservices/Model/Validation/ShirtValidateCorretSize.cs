using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netcore_microservices.Model;

namespace netcore_microservices.Model.Validation
{
    public class ShirtValidateCorretSize : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;

            if( shirt != null)
            {
                if( shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8 )
                {
                    return new ValidationResult("For men, the size has to greater ou equal then 8");
                }
                else if( shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6 )  
                {
                    return new ValidationResult("For women, the size has to greater ou equal then 6");
                }
            }

            return ValidationResult.Success;
        }
    }
}