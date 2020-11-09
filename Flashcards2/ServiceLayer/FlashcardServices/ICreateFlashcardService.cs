using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System.Collections.Immutable;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public interface ICreateFlashcardService
    {
        IImmutableList<ValidationResult> Errors { get; }
        /// <summary>
        /// Creates a new flashcard.
        /// </summary>
        /// <param name="sectionId">Id of the section in which the flashcard should be created.</param>
        /// <param name="Question">The question of the flashcard.</param>
        /// <param name="Answer">The answer of the flashcard.</param>
        /// <returns>The created <see cref="Flashcard"/>.</returns>
        Flashcard CreateFlashcard(int sectionId, string Question, string Answer);
    }
}