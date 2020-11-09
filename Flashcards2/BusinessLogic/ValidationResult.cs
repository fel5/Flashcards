using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class ValidationResult
    {
        public string ErrorMessage { get; set; }
        public string[] PropertyNames { get; set; }

        public ValidationResult(string errorMessage, string[] propertyNames)
        {
            ErrorMessage = errorMessage;
            PropertyNames = propertyNames;
        }
    }
}
