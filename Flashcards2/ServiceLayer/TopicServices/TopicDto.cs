using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.ServiceLayer
{
    public class TopicDto
    {
        public int TopicId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
