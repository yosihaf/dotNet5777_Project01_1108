using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using BL;
using BE;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace UI.ViewModel
{

    public class ListViewModel<T, R> : ViewModelBase where T : class, IItemViewModel<R>, new() where R : Entity, new()
    {
        #region Properties
        #region Private
        private IBL Bl;
        private bool _isShowItem = false;
        private ViewMode _mode;
        private T _itemVM;
        private ObservableCollection<T> _collection;
        #endregion
        public CollectionNames collectionName { set; get; }
        private string _message;
        public string Message
        {
            set
            {
                Set<string>(()=>this.Message,ref _message, value);
            }
            get
            {
                return _message;
            }
        }
        public bool IsShowItem
        {
            get { return _isShowItem; }
            set { Set<bool>(() => this.IsShowItem, ref _isShowItem, value); }

        }
        public ViewMode Mode
        {
            get
            {
                if (SelectedItemVM == null)
                    return _mode;
                return SelectedItemVM.Mode;
                ;
            }
            set
            {

                Set<ViewMode>(() => this.Mode, ref _mode, value);

                if (SelectedItemVM != null)
                {

                    _mode = SelectedItemVM.Mode;
                    this.SelectedItemVM.Mode = value;
                    Set<ViewMode>(() => this.Mode, ref _mode, value);
                }

            }
        }
        public T SelectedItemVM
        {
            get
            {
                return _itemVM;
            }
            set
            {
                Set<T>(() => this.SelectedItemVM, ref _itemVM, value);
            }
        }
        public ObservableCollection<T> Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                Set<ObservableCollection<T>>(() => this.Collection, ref _collection, value);
            }
        }

        public ICommand RemoveCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }

        #endregion

        #region Constractors
        public ListViewModel(CollectionNames collectionName)
        {
            Bl = BL.FactoryBL.GetBL();
            RemoveCommand = new RelayCommand<int>(Remove);
            EditCommand = new RelayCommand<int>(Edit);
            ViewCommand = new RelayCommand<int>(View);
            AddCommand = new RelayCommand(Add);
            SearchCommand = new RelayCommand<string>(Search);
            CloseCommand = new RelayCommand(Close);
            SaveCommand = new RelayCommand(Save);
            UpdateCommand = new RelayCommand(Update);
            this.collectionName = collectionName;

            Mode = ViewMode.Edit;
            GetCollection();
        }
        #endregion

        #region Methods



        public void GetCollection(IEnumerable<R> localCollection = null)
        {
            if(localCollection == null)
            localCollection = Bl.GetCollection<R>(collectionName);
            List<T> local = new List<T>();
            foreach (var item in localCollection)
            {
                var itemVM = new T();
                itemVM.Item = item;
                local.Add(itemVM);
            }
            Collection = new ObservableCollection<T>(local);

        }

        public T getItem(int id) {

            foreach (var item in Collection) {
                if (item.Item.ID == id)
                    return item;
            }
            return null;
        }

        public void Remove(int ID)
        {
            var item = getItem(ID);
            if (item == null) {
                return;
            }
            if (!item.CanRemoved) {
                this.Message = "cant remove item id: " + ID;
                return;
            }
            Bl.RemoveItem<R>(ID ,collectionName);
            GetCollection();
        }

        private void Edit(int id)
        {
            IsShowItem = true;
            var item = Bl.GetItem<R>(id, collectionName);
            var itemVM = new T();
            itemVM.Item = item;
            SelectedItemVM = itemVM;
            Mode = ViewMode.Edit;
        }

        private void Close()
        {
            IsShowItem = false;
            Mode = ViewMode.View;
            SelectedItemVM.Mode = ViewMode.View;
        }

        private void Add()
        {
            IsShowItem = true;
            var item = new R();
            var itemVM = new T();
            itemVM.Item = item;
            SelectedItemVM = itemVM;

            Mode = ViewMode.Add;
        }

        private void Save()
        {
            if (!SelectedItemVM.IsValid)
                return;
            IsShowItem = false;
            Mode = ViewMode.View;
            var item = SelectedItemVM.Item;
            Bl.AddItem<R>(item, collectionName);
            GetCollection();
        }

        private void Update()
        {
            if (!SelectedItemVM.IsValid)
                return;
            IsShowItem = false;
            Mode = ViewMode.View;
            var contract = SelectedItemVM.Item;
            Bl.UpdateItem<R>(contract, collectionName);
            GetCollection();
        }

        private void View(int id)
        {
            IsShowItem = true;
            var item = Bl.GetItem<R>(id, collectionName);
            var itemVM = new T();
            itemVM.Item = item;
            SelectedItemVM = itemVM;
            Mode = ViewMode.View;

        }

        private void Search(string query)
        {
            var coll =  Bl.SearchItem<R>(query, collectionName);
            GetCollection(coll);
        }
        #endregion

    }
    }
