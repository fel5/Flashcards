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
    /// Interaktionslogik für QueryRoundView.xaml
    /// </summary>
    public partial class QueryRoundView : UserControl
    {
        public QueryRoundView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(showAnswerButton);
        }
    }
}
