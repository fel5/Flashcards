using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class DeleteFlashcardAction : BizActionErrors, IDeleteFlashcardAction
    {
        FlashcardsDbContext _dbContext;

        public DeleteFlashcardAction(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Flashcard Action(Flashcard flashcard)
        {
            _dbContext.Remove(flashcard);

            return flashcard;
        }
    }
}
