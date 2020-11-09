using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public abstract class BizActionErrors
    {
        private readonly List<ValidationResult> _errors = new List<ValidationResult>();

        public IImmutableList<ValidationResult> Errors => _errors.ToImmutableList();

        public bool HasErrors => _errors.Any();

        protected void AddError(string errorMessage, params string[] propertyNames)
        {
            _errors.Add(new ValidationResult(errorMessage, propertyNames));
        }

        protected void AddErrorIf(bool condition, string errorMessage, params string[] propertyNames)
        {
            if (condition) AddError(errorMessage, propertyNames);
        }
    }
}
