using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Data;
using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.Models.CustomAttributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        private readonly APPDbContext context;
        public new string ErrorMessage { get; set; } = "";
        public UniqueAttribute (){
           context = new APPDbContext ();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) 
                return null;

            string NewName = value.ToString();

            var student = context.courses.FirstOrDefault(c => c.Name == NewName);

            if (student == null)
                return ValidationResult.Success;
            else 
                return new ValidationResult(ErrorMessage);
         
        }

    }
}
