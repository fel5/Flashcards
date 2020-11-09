using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core.Lifetime;
using Flashcards2.Commands;

namespace Flashcards2.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        

        public ViewModelBase()
        {
            
        }
        
        public virtual void OnNavigatedTo()
        {

        }
    }
}
