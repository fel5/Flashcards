using Flashcards2.DataLayer;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Flashcards2.ServiceLayer
{
    public class SectionDto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int SectionId { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public int TopicId { get; set; }
        public List<Flashcard> Flashcards { get; set; }
        public int NumberOfFlashcards { get => Flashcards.Count; }
        public List<int> StageCount { get; set; }

        public float Progress => NumberOfFlashcards == 0 ? 0 : (float) StageCount.Zip(new List<int>() { 0,1,2,3,4 }, (a, b) => a * b).Sum() / (NumberOfFlashcards * 4);

        
    }
}
