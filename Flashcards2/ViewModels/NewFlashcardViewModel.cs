using Flashcards2.Commands;
using Flashcards2.DataLayer;
using Flashcards2.ServiceLayer;
using Flashcards2.ServiceLayer.FlashcardServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Flashcards2.ViewModels
{
    public class NewFlashcardViewModel : ViewModelBase
    {
        MainWindowViewModel _mainWindowViewModel;
        private ICreateFlashcardService _createFlashcardService;
        private readonly SectionDto _section;
        public string Question { get; set; }
        public string Answer { get; set; }
        public ICommand CreateFlashcardCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public NewFlashcardViewModel(
            MainWindowViewModel mainWindowViewModel,
            SectionDto section,
            ICreateFlashcardService createFlashcardService,
            RelayCommand.Factory relayCommand)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _createFlashcardService = createFlashcardService;
            _section = section;

            CreateFlashcardCommand = relayCommand(CreateFlashcard, CanCreateFlashcard);
            CancelCommand = relayCommand(BackToTopics);
        }

        public void CreateFlashcard()
        {
            _createFlashcardService.CreateFlashcard(_section.SectionId, Question, Answer);
            _mainWindowViewModel.NavigateTo<NewFlashcardViewModel, SectionDto>(_section);
        }

        public bool CanCreateFlashcard()
        {
            return !string.IsNullOrWhiteSpace(Question) && !string.IsNullOrWhiteSpace(Answer);
        }
        public void BackToTopics()
        {
            _mainWindowViewModel.NavigateBack();
        }
    }
}
