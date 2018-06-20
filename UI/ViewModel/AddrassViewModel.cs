using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections.ObjectModel;

namespace UI.ViewModel
{
    public class AddressViewModel : ItemViewModel<Address>
    {
        protected override void OnItemSet()
        {
            if (Item == null)
            {
                Item = new Address();
                return;
            }

        }
        public override bool ValidParams()
        {
            var flag = true;
            ValidetionMessages = new ObservableDictionary<string, string>();


            //if (!Bl.ValidID(Item.ID))
            //{
            //    ValidetionMessages.Add("id-incorrect", "id nust to be a number and contain at 8 digds");
            //    flag = false;
            //}


            ////// valid if id exsisted
            ////if ( Mode == ViewMode.Add && !Bl.IsExiste(collectionName, Item.ID) && Item.ID =)
            ////{
            ////    ValidetionMessages.Add("id-exsist", "id alrady exsited!!");
            ////    flag = false;
            ////}


            //// valid if employee id exsisted
            //if (Bl.IsExiste(CollectionNames.Employees, Item.ID) && Mode == ViewMode.Add)
            //{
            //    ValidetionMessages.Add("employee-exsist", "employee already existed in DB!!");
            //    flag = false;
            //}


            return flag;
        }

        public string City
        {
            get
            {
                return Item.City;
            }
            set
            {
                Item.City = value;
                var demo = string.Empty;
                Set<string>(() => this.City, ref demo, value);
            }
        }


        public string Street
        {
            get
            {
                return Item.Street;
            }
            set
            {
                Item.Street = value;

                var demo = string.Empty;
                Set<string>(() => this.Street, ref demo, value);
            }
        }
    }
}
