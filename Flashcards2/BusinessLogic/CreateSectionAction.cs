using Flashcards2.DataLayer;
using Flashcards2.Extensions;
using Flashcards2.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public class CreateSectionAction : BizActionErrors, IAction<SectionDto, Section>, ICreateSectionAction
    {
        private readonly FlashcardsDbContext _dbContext;

        public CreateSectionAction(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Section Action(SectionDto dto)
        {
            var section = new Section
            {
                Title = dto.Title,
                TopicId = dto.TopicId,
                Position = _dbContext.Sections.Count(s => s.TopicId == dto.TopicId),
            };

            AddErrorIf(section.Title.IsNullOrWhiteSpace(), "Titel darf nicht leer sein");

            AddErrorIf(_dbContext.Sections.Any(s => s.Title == section.Title), "Abschnitt existiert bereits");

            return !HasErrors ? _dbContext.Add(section).Entity : null;
        }
    }
}
