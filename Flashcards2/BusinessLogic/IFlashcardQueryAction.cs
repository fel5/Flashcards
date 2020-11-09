using Flashcards2.DataLayer;
using Flashcards2.ServiceLayer.FlashcardServices;

namespace Flashcards2.BusinessLogic
{
    public interface IFlashcardQueryAction : IAction<FlashcardQueryDto, Flashcard>
    {
        Flashcard Action(FlashcardQueryDto dto);
    }
}