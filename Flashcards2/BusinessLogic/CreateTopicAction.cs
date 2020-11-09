using System;
using System.Collections.Generic;
using System.Text;
using Flashcards2.DataLayer;
using System.Linq;
using Flashcards2.Extensions;

namespace Flashcards2.BusinessLogic
{
    public class CreateTopicAction : BizActionErrors, IAction<string, Topic>, ICreateTopicAction
    {
        private readonly FlashcardsDbContext _dbContext;

        public CreateTopicAction(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Topic Action(string title)
        {
            if (title.IsNullOrWhiteSpace())
                AddError("Titel darf nicht leer sein");
            else
            {
                AddErrorIf(title.Length > 40, "Titel muss aus 40 oder weniger Zeichen bestehen");
                AddErrorIf(_dbContext.Topics.Any(Topic => Topic.Title == title), "Thema mit diesem Titel existiert bereits");
            }

            return !HasErrors ? _dbContext.Add(new Topic(title)).Entity : null;
        }
    }
}
