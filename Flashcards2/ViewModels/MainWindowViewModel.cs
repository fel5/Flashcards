using Autofac;
using Flashcards2.BusinessLogic;
using Flashcards2.Commands;
using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;


namespace Flashcards2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ILifetimeScope _scope;
        ILifetimeScope _viewModelScope;
        List<ILifetimeScope> _navigationStack;
        public ViewModelBase ViewModel { get; set; }
        
        

        public MainWindowViewModel(
            ILifetimeScope lifetimeScope,
            RelayCommand<ViewModelBase>.Factory navigateCommand
            )
        {
            _navigationStack = new List<ILifetimeScope>();
            _scope = lifetimeScope.BeginLifetimeScope();            
            StackNavigateTo<TopicsViewModel>();
            
        }

        public void StackNavigateTo<T>() where T : ViewModelBase
        {
            //_viewModelScope?.Dispose();
            var scope = _scope.BeginLifetimeScope(typeof(T));
            _navigationStack.Add(scope);
            ViewModel = scope.Resolve<T>(new NamedParameter("mainWindowViewModel", this));
        }

        public void StackNavigateTo<T, P>(P parameters) where T : ViewModelBase
        {
            var scope = _scope.BeginLifetimeScope(typeof(T));
            _navigationStack.Add(scope);
            ViewModel = scope.Resolve<T>(new NamedParameter("mainWindowViewModel", this),
                                          new TypedParameter(typeof(P), parameters));
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            _navigationStack.Last().Dispose();
            _navigationStack.RemoveAt(_navigationStack.Count - 1);
            StackNavigateTo<T>();
        }

        public void NavigateTo<T, P>(P parameters) where T : ViewModelBase
        {
            _navigationStack.Last().Dispose();
            _navigationStack.RemoveAt(_navigationStack.Count - 1);
            StackNavigateTo<T, P>(parameters);
        }

        public void NavigateBack()
        {
            _navigationStack.Last().Dispose();
            _navigationStack.RemoveAt(_navigationStack.Count - 1);
            Type t = (Type)_navigationStack.Last().Tag;
            ViewModel = (ViewModelBase)_navigationStack.Last().Resolve(t);
            ViewModel.OnNavigatedTo();
        }
    }
}
