using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Flashcards2.DataLayer
{
    public class Flashcard : BaseEntity, INotifyPropertyChanged
    {
        public int FlashcardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Stage { get; set; }
        public List<Query> Queries { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
