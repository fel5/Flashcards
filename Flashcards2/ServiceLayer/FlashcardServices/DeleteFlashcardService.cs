using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public class DeleteFlashcardService : IDeleteFlashcardService
    {
        FlashcardsDbContext _dbContext;
        RunnerWriteDb<Flashcard, Flashcard> _runner;

        public IImmutableList<ValidationResult> Errors => _runner.Errors;

        public DeleteFlashcardService(
            FlashcardsDbContext dbContext,
            RunnerWriteDb<Flashcard, Flashcard>.Factory runner,
            IDeleteFlashcardAction action
            )
        {
            _dbContext = dbContext;
            _runner = runner(action);
        }
        public bool DeleteFlashcard(int flashcardId)
        {
            var flashcard = _dbContext.Find<Flashcard>(flashcardId);
            _runner.RunAction(flashcard);

            return !_runner.HasErrors;
        }
    }
}
