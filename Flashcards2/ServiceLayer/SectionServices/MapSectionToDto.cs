using Flashcards2.DataLayer;
using MaterialDesignColors.Recommended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flashcards2.ServiceLayer.SectionServices
{
    public static partial class Extensions
    {
        public static IQueryable<SectionDto> MapSectionToDto(this IQueryable<Section> sections)
        {

            var section = sections.Select(s => new SectionDto
            {
                SectionId = s.SectionId,
                Title = s.Title,
                Position = s.Position,
                TopicId = s.TopicId,
                Flashcards = s.Flashcards,
                
                StageCount = new List<int>()
                {
                    s.Flashcards.Count(f => f.Stage == 1),
                    s.Flashcards.Count(f => f.Stage == 2),
                    s.Flashcards.Count(f => f.Stage == 3),
                    s.Flashcards.Count(f => f.Stage == 4),
                    s.Flashcards.Count(f => f.Stage == 5) 
                }
            }
            );
            

            return section;
        
        }
    }
}
