using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for headerList.xaml
    /// </summary>
    public partial class HeaderListView : UserControl, INotifyPropertyChanging
    {
       

        public HeaderListView()
        {
            //DataContext = this;// new ViewModel.HeaderListViewModel();
            InitializeComponent();

        }
        private string _query = string.Empty;
        public string Query
        {
            set
            {
                _query = value;
                RaisePropertyChanged("Query");
            }
            get
            {
                return _query;
            }
        }
        public ICommand SearchCommand
        {
            set
            {
                SetValue(SearchCommandProperty, value);
                RaisePropertyChanged("SearchCommand");
                //if (DataContext is ViewModel.HeaderListViewModel)
                //{
                //    ((ViewModel.HeaderListViewModel)DataContext).SearchCommand = value;
                //}
            }
            get
            {
                return (ICommand)GetValue(SearchCommandProperty);
            }
        }
        public ICommand AddCommand
        {
            set
            {
                SetValue(AddCommandProperty, value);
                RaisePropertyChanged("AddCommand");
                //if (DataContext is ViewModel.HeaderListViewModel)
                //{
                //    ((ViewModel.HeaderListViewModel)DataContext).AddCommand = value;
                //}
            }
            get
            {
                return (ICommand)GetValue(AddCommandProperty);
            }
        }
        //public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public event PropertyChangingEventHandler PropertyChanging;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            //var handlers = PropertyChanged;

                //handlers(this, new PropertyChangedEventArgs(propertyName));
        }

        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(HeaderListView), new UIPropertyMetadata(null));
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(HeaderListView), new UIPropertyMetadata(null));

    }

}
