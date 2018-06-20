using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.ViewModel
{
    class HeaderListViewModel:ViewModelBase
    {
        private ICommand _addCommand;
        private ICommand _searchCommand;
        private string _query;

        public ICommand AddCommand
        {
            set
            {
                Set<ICommand>(() => this.AddCommand, ref _addCommand, value);
            }
            get
            {
                return _addCommand;
            }
        }
        public ICommand SearchCommand
        {
            set
            {
                Set<ICommand>(() => this.SearchCommand, ref _searchCommand, value);
            }
            get
            {
                return _searchCommand;
            }
        }

        public HeaderListViewModel()
        {
        }

        public string Query
        {
            set
            {
                Set<string>(() => this.Query, ref _query, value);
            }
            get
            {
                return _query;
            }
        }
    }
}
