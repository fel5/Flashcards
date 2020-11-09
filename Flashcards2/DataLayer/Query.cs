namespace Flashcards2.DataLayer
{
    public class Query : BaseEntity
    {
        public int QueryId { get; set; }
        public bool Success { get; set; }
        public int FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
    }
}
