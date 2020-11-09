using Flashcards2.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flashcards2.Views
{
    /// <summary>
    /// Interaktionslogik für NewFlashcardView.xaml
    /// </summary>
    public partial class NewFlashcardView : UserControl
    {
        public NewFlashcardView()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) => Keyboard.Focus(questionTextBox);
        private void UserControl_Loaded(object sender, RoutedEventArgs e) => Keyboard.Focus(questionTextBox);
    }
}
