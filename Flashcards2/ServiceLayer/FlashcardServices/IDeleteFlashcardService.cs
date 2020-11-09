using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System.Collections.Immutable;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public interface IDeleteFlashcardService
    {
        IImmutableList<ValidationResult> Errors { get; }
        /// <summary>
        /// Removes flashcard with given id.
        /// </summary>
        /// <param name="flashcardId">Id of the flashcard to remove.</param>
        /// <returns>
        /// <see langword="true"/> if flashcard was successfully removed;
        /// otherwise <see langword="false"/>.
        /// </returns>
        bool DeleteFlashcard(int flashcardId);
    }
}