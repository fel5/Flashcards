using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public class FlashcardQueryService : IFlashcardQueryService
    {
        private readonly RunnerWriteDb<FlashcardQueryDto, Flashcard> _runner;
        public IImmutableList<ValidationResult> Errors => _runner.Errors;

        public FlashcardQueryService(
            RunnerWriteDb<FlashcardQueryDto, Flashcard>.Factory runner,
            IFlashcardQueryAction action
            )
        {
            _runner = runner(action);
        }

        public Flashcard Success(int flashcardId, bool success)
        {
            var flashcard = _runner.RunAction(new FlashcardQueryDto
            {
                FlashcardId = flashcardId,
                Success = success
            });

            return _runner.HasErrors ? null : flashcard;
        }
    }
}
