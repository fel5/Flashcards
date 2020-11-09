using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public class QueryRoundOptions
    {
        public int SectionId { get; set; }
        public int NumberOfQueries { get; set; }
        public int Stage { get; set; }
        public bool RandomOrder { get; set; }
    }
}
