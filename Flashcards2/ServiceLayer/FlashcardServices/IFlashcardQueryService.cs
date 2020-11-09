using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System.Collections.Immutable;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public interface IFlashcardQueryService
    {
        IImmutableList<ValidationResult> Errors { get; }
        /// <summary>
        /// Changes the stage of a flashcard according to the success of a query.
        /// </summary>
        /// <param name="flashcardId">The id of the flashcard to change.</param>
        /// <param name="success">The success of the query.</param>
        /// <returns>The updated flashcard.</returns>
        Flashcard Success(int flashcardId, bool success);
    }
}