using System.Collections.Generic;

namespace Flashcards2.DataLayer
{
    public class Section : BaseEntity
    {
        public int SectionId { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public List<Flashcard> Flashcards { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
