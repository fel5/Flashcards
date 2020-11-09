using Flashcards2.Commands;
using Flashcards2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Autofac;
using Flashcards2.ServiceLayer;
using System.Linq;
using Flashcards2.ServiceLayer.TopicServices;
using Flashcards2.DataLayer;

namespace Flashcards2.ViewModels
{
    public class TopicsViewModel : ViewModelBase
    {
        MainWindowViewModel _mainWindowViewModel;
        ICreateTopicService _createTopicService;
        IDeleteTopicService _deleteTopicService;
        IListTopicsService _listTopicsService;

        public ICommand CreateTopicCommand { get; set; }
        public ICommand EditTopicCommand { get; set; }
        public ICommand DeleteTopicCommand { get; set; }

        public ObservableCollection<Topic> Topics { get; set; }

        public TopicsViewModel(
            MainWindowViewModel mainWindowViewModel,
            ICreateTopicService createTopicService,
            IDeleteTopicService deleteTopicService,
            IListTopicsService listTopicsService,
            RelayCommand<string>.Factory relayCommandStr,
            RelayCommand<int>.Factory relayCommandInt
            )
        {
            _mainWindowViewModel = mainWindowViewModel;
            _createTopicService = createTopicService;
            _deleteTopicService = deleteTopicService;
            _listTopicsService = listTopicsService;

            CreateTopicCommand = relayCommandStr(CreateTopic);
            EditTopicCommand = relayCommandInt(EditTopic);
            DeleteTopicCommand = relayCommandInt(DeleteTopic);

            Topics = new ObservableCollection<Topic>(_listTopicsService.ListTopics().OrderBy(t=>t.Title));
        }
        public void DeleteTopic(int topicId)
        {
            var topicDto = _deleteTopicService.DeleteTopic(topicId);
            Topics.Remove(Topics.First(t => t.TopicId == topicDto.TopicId));
        }
        public void CreateTopic(string title)
        {
            var topic = _createTopicService.CreateTopic(title);
            if (topic != null) Topics.Insert(0, topic);
        }
        public void EditTopic(int topicId)
        {
            _mainWindowViewModel.StackNavigateTo<EditTopicViewModel, int>(topicId);
        }
    }
}
