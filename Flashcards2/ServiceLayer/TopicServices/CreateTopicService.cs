using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Flashcards2.DataLayer;
using Flashcards2.BusinessLogic;
using System.Collections.Immutable;

namespace Flashcards2.ServiceLayer
{
    public class CreateTopicService : ICreateTopicService
    {
        private readonly RunnerWriteDb<string, Topic> _runner;

        public IImmutableList<ValidationResult> Errors => _runner.Errors;

        public CreateTopicService(
            RunnerWriteDb<string, Topic>.Factory runner,
            ICreateTopicAction action)
        {
            _runner = runner(action);
        }

        public Topic CreateTopic(string title)
        {
            return _runner.RunAction(title);
        }
    }
}
