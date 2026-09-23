using Microsoft.AspNetCore.Mvc;
using EduCore.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace EduCore.Models.CustomAttributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        public new string ErrorMessage { get; set; } = "";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var context = (APPDbContext?)validationContext.GetService(typeof(APPDbContext));
            if (value is null) 
                return null;

            string? NewName = value.ToString();

            var course = context?.courses.FirstOrDefault(c => c.Name == NewName);

            if (course == null)
                return ValidationResult.Success;
            else 
                return new ValidationResult(ErrorMessage);
         
        }

    }
}
