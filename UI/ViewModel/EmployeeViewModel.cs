using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections.ObjectModel;

namespace UI.ViewModel
{
    public class EmployeeViewModel:ItemViewModel<Employee>
    {
        private BankAccountViewModel _bankAccountVM;
        private AddressViewModel _addressVM;

        protected override bool isCanRemoved()
        {
            return !Bl.ValidRemuveEmployee(Item);
        }

        protected override void OnModeSet()
        {
            AddressVM.Mode = Mode;
            BankAccountVM.Mode = Mode;

        }
        protected override void OnItemSet()
        {
            if (Item == null) {
                Item = new Employee();
                return;
            }

            // set address
            var addressVM= new AddressViewModel();
            Item.Adresses = Item.Adresses ?? new Address();
            addressVM.Item = Item.Adresses;
            AddressVM = addressVM;

            // set bank account
            var bankAccount = new BankAccountViewModel();
            Item.Account = Item.Account ?? new BankAccount();
            bankAccount.Item = Item.Account;
            BankAccountVM = bankAccount;

        }
        public override bool ValidParams()
        {
            var flag = true;
            ValidetionMessages = new ObservableDictionary<string, string>();
            if (!Bl.ValidID(Item.ID))
            {
                ValidetionMessages.Add("id-incorrect", "id nust to be a number and contain at 8 digds");
                flag = false;
            }

            if (!Bl.ValidAgeToEmployy(Item.Birthday))
            {
                ValidetionMessages.Add("age", "age invalid (bigger then 100 or smaller then 17)");
                flag = false;
            }

            // valid if employee id exsisted
            if (Bl.IsExiste(CollectionNames.Employees, Item.ID) && Mode == ViewMode.Add)
            {
                ValidetionMessages.Add("employee-exsist", "employee already existed in DB!!");
                flag = false;
            }
            if (Item.SpecializationID == 0)
            {
                ValidetionMessages.Add("employee-specialization", "not specipey specialization for this employee!!");
                flag = false;
            }
            if (!BankAccountVM.IsValid) {
                flag = false;
            }
            if (!Bl.ValidPhon(Item.Phon))
            {
                ValidetionMessages.Add("Phon", "Phon is not valid!! (xxx-xxxxxxx)!!");
                flag = false;
            }

            return flag;
        }

        public int ID
        {
            get { return Item.ID; }
            set
            {
                Set<int>(() => this.ID, ref Item.ID, value);
            }
        }

        public int SpecializationID
        {
            get
            {
                return Item.SpecializationID;
            }
            set
            {
                Item.SpecializationID = value;
                
                var demo = 0;
                Set<int>(() => this.SpecializationID, ref demo, value);
            }
        }

        public string SpecializationName
        {
            get
            {
               var spe = Bl.GetSpecialization(Item.SpecializationID);
                return spe?.Name;
            }
          
        }

        public string Phon
        {
            get
            {
                return Item.Phon;
            }
            set
            {
                Item.Phon = value;

                var demo = string.Empty ;
                Set<string>(() => this.Phon, ref demo, value);
            }
        }

        public string Name
        {
            get { return Item.Name; }
            set
            {
                string demo = "";
                Set<string>(() => this.Name, ref demo, value);
            }
        }

        public string FirstName
        {
            get { return Item.FirstName; }
            set
            {
                Item.FirstName = value;
                string demo = "";
                Set<string>(() => this.FirstName, ref demo, value);
            }
        }
        public string LastName
        {
            get { return Item.LastName; }
            set
            {
                Item.LastName = value;
                string demo = "";
                Set<string>(() => this.LastName, ref demo, value);
            }
        }

        public DateTime Birthday
        {
            get { return Item.Birthday; }
            set
            {
                Item.Birthday = value;
                DateTime demo = DateTime.Now;
                Set<DateTime>(() => this.Birthday, ref demo, value);
            }
        }

        public BankAccountViewModel BankAccountVM
        {
            get { return _bankAccountVM; }
            set
            {

                Set<BankAccountViewModel>(() => this.BankAccountVM, ref _bankAccountVM, value);
            }
        }

        public string DegreeName
        {
            get { return Item.Degree.ToString(); }
         
        }
        public int Degree
        {
            get
            {
                return (int)Item.Degree;
            }
            set
            {
                Item.Degree = (Degrees)value;

                var demo = -1;
                Set<int>(() => this.Degree, ref demo, value);
            }
        }

        public AddressViewModel AddressVM
        {
            get { return _addressVM; }
            set
            {

                Set<AddressViewModel>(() => this.AddressVM, ref _addressVM, value);
            }
        }


    }
}
