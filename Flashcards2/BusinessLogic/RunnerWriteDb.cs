using Autofac;
using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class RunnerWriteDb<TIn, TOut>
    {
        public delegate RunnerWriteDb<TIn, TOut> Factory(IAction<TIn, TOut> actionClass);

        private readonly IAction<TIn, TOut> _actionClass;
        private readonly FlashcardsDbContext _context;

        ILifetimeScope _scope;

        public IImmutableList<ValidationResult> Errors => _actionClass.Errors;
        public bool HasErrors => _actionClass.HasErrors;

        public RunnerWriteDb(
            IAction<TIn, TOut> actionClass,
            FlashcardsDbContext context,
            ILifetimeScope scope
            )
        {
            _context = context;
            _actionClass = actionClass;
            _scope = scope;
        }

        public TOut RunAction(TIn dataIn)
        {
            using var scope = _scope.BeginLifetimeScope();
            var context = scope.Resolve<FlashcardsDbContext>();
            var actionClass = scope.Resolve<IAction<TIn, TOut>>();

            var result = actionClass.Action(dataIn);
            if (!HasErrors)
                context.SaveChanges();

            return result;
        }
    }
}
