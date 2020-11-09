using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class DeleteSectionAction : BizActionErrors, IDeleteSectionAction
    {
        FlashcardsDbContext _dbContext;
        public DeleteSectionAction(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Section Action(Section section)
        {
            _dbContext.Remove(section);

            return section;
        }
    }
}
