using System.Collections.Generic;

namespace Flashcards2.DataLayer
{
    public class Topic : BaseEntity
    {
        public int TopicId { get; private set; }
        public string Title { get; private set; }
        public List<Section> Sections { get; private set; }

        private Topic() { }

        public Topic(string title)
        {
            Title = title;
        }
        
    }
}
