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

namespace Flashcards2.Controls
{
    public partial class SectionListItemControl : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(UserControl));

        public int NumberOfFlashcards
        {
            get { return (int)GetValue(NumberOfFlashcardsProperty); }
            set { SetValue(NumberOfFlashcardsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NumberofFlashcards.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberOfFlashcardsProperty =
            DependencyProperty.Register("NumberOfFlashcards", typeof(int), typeof(UserControl), new PropertyMetadata(0));

        public float Progress
        {
            get { return (float)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Progress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(float), typeof(UserControl));



        public ICollection<int> StageCount
        {
            get { return (ICollection<int>)GetValue(StageCountProperty); }
            set { SetValue(StageCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StageCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StageCountProperty =
            DependencyProperty.Register("StageCount", typeof(ICollection<int>), typeof(UserControl));

        

        public SectionListItemControl()
        {
            
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
    }
}
