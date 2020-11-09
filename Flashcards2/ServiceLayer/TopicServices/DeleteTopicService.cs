using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flashcards2.ServiceLayer.TopicServices
{
    public class DeleteTopicService : IDeleteTopicService
    {
        FlashcardsDbContext _dbContext;
        RunnerWriteDb<Topic, Topic> _runner;

        public DeleteTopicService(
            FlashcardsDbContext dbContext,
            RunnerWriteDb<Topic, Topic>.Factory runner,
            IDeleteTopicAction deleteTopicAction
            )
        {
            _dbContext = dbContext;
            _runner = runner(deleteTopicAction);
        }


        public TopicDto DeleteTopic(int topicId)
        {
            var topic = _dbContext.Find<Topic>(topicId);
            var topicDto = _runner.RunAction(topic).MapTopicToDto();

            return !_runner.HasErrors ? topic.MapTopicToDto() : null;
        }

    }
}
