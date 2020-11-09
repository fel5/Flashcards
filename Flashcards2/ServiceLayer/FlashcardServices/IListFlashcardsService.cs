using Flashcards2.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public interface IListFlashcardsService
    {
        /// <summary>
        /// Returns a <see cref="List{T}"/> of flashcards in random order.
        /// </summary>
        /// <param name="sectionId">The id of the section to pick the flashcards from</param>
        /// <param name="numberOfQueries">The number of flashcards to get</param>
        /// <param name="Stage">The stage from which to pick the flashcards from</param>
        /// <returns><see cref="List{T}"/> of picked flashcards.</returns>
        IList<Flashcard> ListFlashcardsRandom(int sectionId, int numberOfQueries, int Stage);
    }
}