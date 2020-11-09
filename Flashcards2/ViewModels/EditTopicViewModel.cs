using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Text;
using Flashcards2.Commands;
using Flashcards2.BusinessLogic;
using Flashcards2.ServiceLayer;
using Flashcards2.DataLayer;
using System.Linq;
using System.Collections.ObjectModel;
using Flashcards2.ServiceLayer.FlashcardServices;
using Flashcards2.ServiceLayer.SectionServices;

namespace Flashcards2.ViewModels
{
    public class EditTopicViewModel : ViewModelBase, INotifyPropertyChanged
    {
        MainWindowViewModel _mainWindowViewModel;

        IListSectionsService _listSectionsService;
        ICreateSectionService _createSectionService;
        IDeleteSectionService _deleteSectionService;

        IDeleteFlashcardService _deleteFlashcardService;

        IQueryable<SectionDto> _sectionsQuery;

        int _topicId;

        public ObservableCollection<SectionDto> Sections { get; set; }
        public QueryRoundOptions QueryRoundOptions { get; set; }
        public SectionDto Section { get; set; }

        public int SelectedSectionIndex { get; set; }


        public ICommand BackToTopicsCommand { get; set; }
        public ICommand CreateSectionCommand { get; set; }
        public ICommand DeleteSectionCommand { get; set; }
        public ICommand DeleteFlashcardCommand { get; set; }
        public ICommand NewFlashcardCommand { get; set; }
        public ICommand StartQueryRoundCommand { get; set; }

        public EditTopicViewModel(
            MainWindowViewModel mainWindowViewModel,
            int topicId,
            RelayCommand.Factory relayCommand,
            RelayCommand<string>.Factory relayCommandString,
            RelayCommand<int?>.Factory relayCommandInt,
            RelayCommand<SectionDto>.Factory relayCommandSectionDto,
            RelayCommand<Flashcard>.Factory relayCommandFlashcard,
            RelayCommand<QueryRoundOptions>.Factory relayCommandQueryRoundOptions,
            ICreateSectionService createSectionService,
            IDeleteSectionService deleteSectionService,
            IDeleteFlashcardService deleteFlashcardService,
            IListSectionsService listSectionsService
            )
        {
            _mainWindowViewModel = mainWindowViewModel;
            _topicId = topicId;
            _createSectionService = createSectionService;
            _deleteSectionService = deleteSectionService;
            _deleteFlashcardService = deleteFlashcardService;
            _listSectionsService = listSectionsService;

            BackToTopicsCommand = relayCommand(BackToTopics);
            CreateSectionCommand = relayCommandString(CreateSection);
            DeleteSectionCommand = relayCommandSectionDto(DeleteSection);
            DeleteFlashcardCommand = relayCommandFlashcard(DeleteFlashcard);
            NewFlashcardCommand = relayCommandInt(NewFlashcard, CanCreateFlashcard);
            StartQueryRoundCommand = relayCommandQueryRoundOptions(StartQueryRound,  CanStartQueryRound);

            var topicList = _listSectionsService.ListSections(_topicId);
            Sections = new ObservableCollection<SectionDto>(topicList);

            QueryRoundOptions = new QueryRoundOptions
            {
                NumberOfQueries = 10,
                Stage = 1,
            };
            
        }

        public override void OnNavigatedTo()
        {
            var query = _listSectionsService.ListSections(_topicId);
            Sections = new ObservableCollection<SectionDto>(query);
       }

        public void BackToTopics() => _mainWindowViewModel.NavigateBack();
        

        public void StartQueryRound(QueryRoundOptions options)
        {
            options.SectionId = Section.SectionId;
            _mainWindowViewModel.StackNavigateTo<QueryRoundViewModel, QueryRoundOptions>(options);
        }

        public bool CanStartQueryRound(QueryRoundOptions options)
        {
            return Section?.Flashcards.Any(f => f.Stage == options?.Stage) ?? false;
        }

        public void DeleteFlashcard(Flashcard flashcard)
        {
            if (_deleteFlashcardService.DeleteFlashcard(flashcard.FlashcardId))
            {
                var section = Sections.First(s => s.Flashcards.Contains(flashcard));
                var index = Sections.IndexOf(section);

                //Sections.Remove(section);
                //Sections.Insert(index, _listSectionsService.GetSection(flashcard.SectionId));
                Sections[index] = _listSectionsService.GetSection(flashcard.SectionId);
                SelectedSectionIndex = index;
            }
        }

        public void DeleteSection(SectionDto section)
        {
            var deleted = _deleteSectionService.DeleteSection(section.SectionId);
            if (deleted) Sections.Remove(section);
        }

        public void CreateSection(string sectionTitle)
        {
            var section = _createSectionService.CreateSection(sectionTitle, _topicId);

            if (section != null) Sections.Add(section);
        }

        public void NewFlashcard(int? sectionId)
        {
            _mainWindowViewModel.StackNavigateTo<NewFlashcardViewModel, SectionDto>(Sections.Where(s => s.SectionId == sectionId).Single());
        }

        public bool CanCreateFlashcard(int? sectionId) => Section != null ? true : false;
    }
}
