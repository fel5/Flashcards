using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class DeleteTopicAction : BizActionErrors, IAction<Topic, Topic>, IDeleteTopicAction
    {
        FlashcardsDbContext _dbContext;

        public DeleteTopicAction(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Topic Action(Topic topic)
        {
            _dbContext.Remove(topic);

            return topic;
        }
    }
}
