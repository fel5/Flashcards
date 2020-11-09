using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public class CreateFlashcardService : ICreateFlashcardService
    {
        private readonly RunnerWriteDb<FlashcardDto, Flashcard> _runner;
        public IImmutableList<ValidationResult> Errors => _runner.Errors;

        public CreateFlashcardService(
            RunnerWriteDb<FlashcardDto, Flashcard>.Factory runner,
            ICreateFlashcardAction action)
        {
            _runner = runner(action);
        }
        public Flashcard CreateFlashcard(int sectionId, string question, string answer)
        {
            var dto = new FlashcardDto
            {
                SectionId = sectionId,
                Question = question,
                Answer = answer
            };

            var flashcard = _runner.RunAction(dto);

            if (!_runner.HasErrors) return flashcard;
            else return null;
        }
    }
}
