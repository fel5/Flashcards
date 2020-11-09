using Autofac.Features.OwnedInstances;
using Flashcards2.DataLayer;
using Flashcards2.ServiceLayer.FlashcardServices;
using Flashcards2.ServiceLayer.SectionServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Flashcards2.ServiceLayer
{
    public class ListSectionsService : IListSectionsService
    {
        FlashcardsDbContext _dbContext;

        public ListSectionsService(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<SectionDto> ListSections(int topicId)
        {
            return _dbContext.Sections
                .AsNoTracking()
                .Include(s => s.Flashcards)
                .OrderBy(s => s.Position)
                .MapSectionToDto()
                .Where(s => s.TopicId == topicId)
                .ToList();
        }

        public SectionDto GetSection(int sectionId)
        {
            return _dbContext.Sections
                .AsNoTracking()
                .Include(s => s.Flashcards)
                .MapSectionToDto()
                .Single(s => s.SectionId == sectionId);
        }
    }
}
