using System;
using System.Collections.Generic;
using System.Text;
using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System.Collections.Immutable;

namespace Flashcards2.ServiceLayer
{
    public class CreateSectionService : ICreateSectionService
    {
        FlashcardsDbContext _dbContext;
        private readonly RunnerWriteDb<SectionDto, Section> _runner;
        public IImmutableList<ValidationResult> Errors => _runner.Errors;

        IListSectionsService _listSectionsService;

        public CreateSectionService(
            FlashcardsDbContext dbContext,
            RunnerWriteDb<SectionDto, Section>.Factory runner,
            ICreateSectionAction action,
            IListSectionsService listSectionsService)
        {
            _runner = runner(action);
            _listSectionsService = listSectionsService;
        }

        public SectionDto CreateSection(string sectionTitle, int topicId)
        {
            var dto = new SectionDto
            {
                Title = sectionTitle,
                TopicId = topicId,
            };

            var section = _runner.RunAction(dto);

            return !_runner.HasErrors ? _listSectionsService.GetSection(section.SectionId) : null;
        }
    }
}
