using Flashcards2.Commands;
using Flashcards2.DataLayer;
using Flashcards2.ServiceLayer;
using Flashcards2.ServiceLayer.FlashcardServices;
using Flashcards2.ServiceLayer.SectionServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Flashcards2.ViewModels
{
    public class QueryRoundViewModel : ViewModelBase
    {
        MainWindowViewModel _mainWindowViewModel;
        IListFlashcardsService _listFlashcardsService;
        IFlashcardQueryService _flashcardQueryService;
        IListSectionsService _listSectionsService;
        public IList<Flashcard> Flashcards { get; set; }
        public SectionDto Section { get; set; }
        public int QueryIndex { get; set; } = 0;
        public int QueryNumber { get => QueryIndex + 1; }
        public bool AnswerVisible { get; set; }
        public Flashcard Flashcard
        {
            get => Flashcards?[QueryIndex];
            set => Flashcards[QueryIndex] = value;
        }
        public ICommand SuccessCommand { get; set; }
        public ICommand FailCommand { get; set; }

        public ICommand ShowAnswerCommand { get; set; }

        QueryRoundOptions _options;
        public QueryRoundViewModel(
            MainWindowViewModel mainWindowViewModel,
            IListFlashcardsService listFlashcardsService,
            IFlashcardQueryService flashcardQueryService,
            IListSectionsService listSectionsService,
            QueryRoundOptions options,
            RelayCommand.Factory relayCommand
            )
        {
            _mainWindowViewModel = mainWindowViewModel;
            _listFlashcardsService = listFlashcardsService;
            _flashcardQueryService = flashcardQueryService;
            _listSectionsService = listSectionsService;

            _options = options;

            AnswerVisible = false;
            Flashcards = _listFlashcardsService.ListFlashcardsRandom(_options.SectionId, _options.NumberOfQueries, _options.Stage);
            Section = _listSectionsService.GetSection(Flashcard.SectionId);
            SuccessCommand = relayCommand(() => Next(true));
            FailCommand = relayCommand(() => Next(false));
            ShowAnswerCommand = relayCommand(() => AnswerVisible = true);
        }
        public void Next(bool success)
        {
            Flashcard = _flashcardQueryService.Success(Flashcard.FlashcardId, success);
            AnswerVisible = false;
            if (QueryIndex == Flashcards.Count - 1)
            {
                _mainWindowViewModel.NavigateBack();
            }
            else QueryIndex++;
        }
    }
}
