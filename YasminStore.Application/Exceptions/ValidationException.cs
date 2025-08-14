using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Application.Exceptions
{
    public class ValidationException : Exception
    {

        // Need To Instaul FluentValidation Library



        /*public List<string> ValidatioErrors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ValidatioErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValidatioErrors.Add(validationError.ErrorMessage);
            }

        }*/
    }
}
