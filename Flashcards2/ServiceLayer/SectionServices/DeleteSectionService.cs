using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Flashcards2.ServiceLayer.SectionServices
{
    public class DeleteSectionService : IDeleteSectionService
    {
        FlashcardsDbContext _dbContext;
        RunnerWriteDb<Section, Section> _runner;

        public IImmutableList<ValidationResult> Errors => _runner.Errors;

        public DeleteSectionService(
            FlashcardsDbContext dbContext,
            RunnerWriteDb<Section, Section>.Factory runner,
            IDeleteSectionAction action
            )
        {
            _dbContext = dbContext;
            _runner = runner(action);
        }

        public bool DeleteSection(int sectionId)
        {
            var section = _dbContext.Find<Section>(sectionId);
            _runner.RunAction(section);
            
            return !_runner.HasErrors;
        }
    }
}
