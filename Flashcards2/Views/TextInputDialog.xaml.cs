using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Runtime.CompilerServices;
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
    /// Interaktionslogik für CreateTopicDialog.xaml
    /// </summary>
    public partial class TextInputDialog : UserControl
    {

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value);  }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextInputDialog));



        public ICommand OKCommand
        {
            get { return (ICommand)GetValue(OKCommandProperty); }
            set { SetValue(OKCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OKCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OKCommandProperty =
            DependencyProperty.Register("OKCommand", typeof(ICommand), typeof(TextInputDialog));



        public object OkCommandParameter
        {
            get { return (object)GetValue(OkCommandParameterProperty); }
            set { SetValue(OkCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OkCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OkCommandParameterProperty =
            DependencyProperty.Register("OkCommandParameter", typeof(object), typeof(TextInputDialog), new PropertyMetadata((object)null));


        public TextInputDialog()
        {
            InitializeComponent();
        }
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            //TextInput.Text = " ";
        }
        private void CloseDialogEvent(object sender, RoutedEventArgs e)
        {
            (sender as FrameworkElement).BindingGroup.CommitEdit();
            CloseDialog();
            TextInput.Clear();
        }
        private void CloseDialog()
        {
            var command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand;
            command.Execute(null, this);
        }
    }
}
