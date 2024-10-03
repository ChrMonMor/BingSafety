using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Exceptions {
    public class ValidationException : Exception {
        private FluentValidation.Results.ValidationResult validatorResult;

        public List<string> ValidationErrors { get; set; }
        public ValidationException(FluentValidation.Results.ValidationResult validationResult) {
            ValidationErrors = new List<string>();
            foreach (var item in ValidationErrors)
            {
                ValidationErrors.Add(validationResult.ToString());
            }
        }

    }
}
