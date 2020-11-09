using Flashcards2.DataLayer;
using Flashcards2.Extensions;
using MaterialDesignColors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public class ListFlashcardsService : IListFlashcardsService
    {
        public readonly FlashcardsDbContext _dbContext;

        public ListFlashcardsService(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Flashcard> ListFlashcardsRandom(
            int sectionId,
            int numberOfQueries,
            int stage
            )
        {
            var flashcards = _dbContext.Flashcards
                .Where(f => f.SectionId == sectionId && f.Stage == stage);

            var count = flashcards.Count();
            var result = new List<Flashcard>();
            var indices = Enumerable.Range(0, count).ToList();

            indices = Enumerable.Range(0, count)
                .ToList()
                .Shuffle()
                .Take(numberOfQueries)
                .ToList();

            foreach (var i in indices)
                result.Add(flashcards.Skip(i).First());
            
            return result;
        }
    }
}
