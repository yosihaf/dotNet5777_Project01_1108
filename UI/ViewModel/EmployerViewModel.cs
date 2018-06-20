using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections.ObjectModel;

namespace UI.ViewModel
{
    public class EmployerViewModel:ItemViewModel<Employer>
    {
        protected override bool isCanRemoved()
        {
            return !Bl.ValidRemuveEmployer(Item);
        }

        protected override void OnItemSet()
        {
            // set address
            var addressVM = new AddressViewModel();
            Item.Adresses = Item.Adresses ?? new Address();
            addressVM.Item = Item.Adresses;
            AddressVM = addressVM;
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

                if (!Bl.ValidAgeToEmployr(Item.EstablishmentDate))
                {
                    ValidetionMessages.Add("EstablishmentDate", "EstablishmentDate must to be one tear later");
                    flag = false;
                }

                if (!Bl.ValidPhon(Item.Phon))
                {
                    ValidetionMessages.Add("Phon", "Phon is not valid!! (xxx-xxxxxxx)!!");
                    flag = false;
                }


                // valid if employee id exsisted
                if (Bl.IsExiste(CollectionNames.Employees, Item.ID) && Mode == ViewMode.Add)
                {
                    ValidetionMessages.Add("employee-exsist", "employee already existed in DB!!");
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

            public string Phon
            {
                get
                {
                    return Item.Phon;
                }
                set
                {
                    Item.Phon = value;

                    var demo = string.Empty;
                    Set<string>(() => this.Phon, ref demo, value);
                }
            }

            public bool IsCompany
            {
                get
                {
                    return Item.IsCompany;
                }
                set
                {
                    Item.IsCompany = value;
                    bool demo = !value;
                    Name = ""; // invok the name
                    Set<bool>(() => this.IsCompany, ref demo, value);
                }
            }
        
        public DateTime EstablishmentDate
        {
            get
            {
                return Item.EstablishmentDate;
            }
            set
            {
                Item.EstablishmentDate = value;
                var demo = DateTime.Now;
                Name = ""; // invok the name
                Set<DateTime>(() => this.EstablishmentDate, ref demo, value);
            }
        }
        private AddressViewModel _addressVM;
        public AddressViewModel AddressVM
        {
            get { return _addressVM; }
            set
            {

                Set<AddressViewModel>(() => this.AddressVM, ref _addressVM, value);
            }
        }

        public string Name
                {
                    get { return Item.Name; }
                    set
                    {
                        string demo = "-";
                        Set<string>(() => this.Name, ref demo, value);
                    }
                }
        public string CompanyName
        {
            get { return Item.CompanyName; }
            set
            {
                Item.CompanyName = value;
                string demo = "-";
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
    }
}
