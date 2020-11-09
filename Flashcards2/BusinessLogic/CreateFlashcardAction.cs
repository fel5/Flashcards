using Flashcards2.DataLayer;
using Flashcards2.Extensions;
using Flashcards2.ServiceLayer.FlashcardServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class CreateFlashcardAction : BizActionErrors, IAction<FlashcardDto, Flashcard>, ICreateFlashcardAction
    {
        private readonly FlashcardsDbContext _dbContext;
        public CreateFlashcardAction(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Flashcard Action(FlashcardDto dto)
        {
            AddErrorIf(dto.Question.IsNullOrWhiteSpace(), "Frage darf nicht leer sein");
            AddErrorIf(dto.Answer.IsNullOrWhiteSpace(), "Antwort darf nicht leer sein");

            var flashcard = new Flashcard
            {
                SectionId = dto.SectionId,
                Question = dto.Question,
                Answer = dto.Answer,
                Stage = 1
            };

            return !HasErrors ? _dbContext.Add(flashcard).Entity : null;
        }
    }
}
