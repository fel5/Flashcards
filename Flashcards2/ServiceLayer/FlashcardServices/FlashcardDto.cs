using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.ServiceLayer.FlashcardServices
{
    public class FlashcardDto
    {
        public int FlashcardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Stage { get; set; }
        public int SectionId { get; set; }
    }
}
