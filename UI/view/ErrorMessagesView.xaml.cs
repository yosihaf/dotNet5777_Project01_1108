using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ErrorMessagesView.xaml
    /// </summary>
    public partial class ErrorMessagesView : UserControl,INotifyPropertyChanging
    {
        public ErrorMessagesView()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        ObservableDictionary<string, string> _messages;

        public event PropertyChangingEventHandler PropertyChanging;


        public void Notipy(string propName) {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propName));

        }
        //public ObservableDictionary<string, string> Messages
        //{
        //    get
        //    {
        //        return _messages;
        //    }
        //    set
        //    {
        //        _messages =  value;
        //        Notipy("Messages");
        //    }
        //}

        //public ObservableDictionary<string, string> Messages
        //{
        //    get
        //    {
        //        return (ObservableDictionary<string, string>)GetValue(MessagesProperty);
        //    }
        //    set
        //    {
        //        SetValue(MessagesProperty, value);
        //        Notipy("Messages");
        //    }
        //}

        //public static readonly DependencyProperty MessagesProperty =
        //   DependencyProperty.Register(
        //       "Messages",
        //       typeof(ObservableDictionary<string, string>),
        //       typeof(ErrorMessagesView),
        //       new PropertyMetadata(false));

    }
}
