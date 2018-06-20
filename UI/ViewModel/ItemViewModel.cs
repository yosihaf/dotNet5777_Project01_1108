using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using BE;
using BL;

namespace UI.ViewModel
{
   
    public class ItemViewModel <T>: ViewModelBase, IItemViewModel<T>
    {

        public ItemViewModel()
        {
            Bl = BL.FactoryBL.GetBL();
        }

        private ObservableDictionary<string, string> _validetionMessages = new ObservableDictionary<string, string>();
        private ViewMode _mode;
        private T _item;
        protected IBL Bl;
        public ObservableDictionary<string, string> ValidetionMessages
        {
            get
            {
                return _validetionMessages;
            }
            set
            {
                Set<ObservableDictionary<string, string>>(() => this.ValidetionMessages, ref _validetionMessages, value);
            }
        }

        public T Item
        {
            set
            {
                Set<T>(() => this.Item, ref _item, value);
                OnItemSet();
            }
            get { return _item; }
        }

        public bool IsValid
        {
            get { return ValidParams(); }
        }

        public bool CanRemoved {
            get { return isCanRemoved(); }
        }

        public ViewMode Mode
        {
            get
            {
                return _mode;
            }
            set
            {

                Set<ViewMode>(() => this.Mode, ref _mode, value);
                OnModeSet();
            }
        }

        public virtual bool ValidParams() {
            return false;
        }

        protected virtual void OnItemSet() { }

        protected virtual void OnModeSet() { }

        protected virtual bool isCanRemoved()
        {
            return true;
        }

        public IEnumerable<dynamic> EmployeesDetails
        {
            get
            {
                return Bl.GetBaseEmoloyeesDetails();
            }
        }

        public IEnumerable<dynamic> CitiesDetails
        {
            get
            {
                return Bl.EnumToValueName<Cities>();
            }
        }

        public IEnumerable<dynamic> BanksNamesDetails
        {
            get
            {
                return Bl.GetBanksDetails();
            }

        }

        public IEnumerable<dynamic> SpecializationsDetails
        {
            get
            {
                return Bl.GetBaseSpecializationsDetails();
            }
        }

        public IEnumerable<dynamic> DegreesDetails
        {
            get
            {
                return Bl.EnumToValueName<Degrees>();
            }
        }

        public IEnumerable<dynamic> EmployersDetails
        {
            get
            {
                return Bl.GetBaseEmoloyersDetails();

            }
        }

    }
}
