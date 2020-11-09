using Flashcards2.DataLayer;
using Flashcards2.ServiceLayer.FlashcardServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class FlashcardQueryAction : BizActionErrors, IAction<FlashcardQueryDto, Flashcard>, IFlashcardQueryAction
    {
        private readonly FlashcardsDbContext _dbContext;

        public FlashcardQueryAction(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Flashcard Action(FlashcardQueryDto dto)
        {
            var flashcard = _dbContext.Find<Flashcard>(dto.FlashcardId);

            if (flashcard == null)
            {
                AddError("Flashcard entity not found");
                return null;
            }

            if (flashcard.Stage == 0) flashcard.Stage = 1;

            if (dto.Success && flashcard.Stage < 5)
                flashcard.Stage++;
            else if (!dto.Success && flashcard.Stage > 1)
                flashcard.Stage--;

            return flashcard;
        }
    }
}
