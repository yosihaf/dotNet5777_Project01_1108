using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class SpecializationViewModel:ItemViewModel<Specialization>
    {
        protected override bool isCanRemoved()
        {
            // todo:remove
            /// return Bl....
            return !Bl.ValidRemuveSpecialization(Item);
        }

        public override bool ValidParams()
        {
            var flag = true;
            ValidetionMessages = new ObservableDictionary<string, string>();

            if (string.IsNullOrEmpty(Item.Name)) {

                ValidetionMessages.Add("Specializations-name", "Specialization name is empty!!");
                flag = false;
            }

            if (Item.MaxHourSalary < 26 || Item.MinHourSalary < 26)
            {

                ValidetionMessages.Add("Specializations-slary", "max or min can't smmaller from 26!!");
                flag = false;
            }
            if (Item.MaxHourSalary < Item.MinHourSalary )
            {

                ValidetionMessages.Add("Specializations-slary", "min salary can't be bigger or same to the max salary!!");
                flag = false;
            }

            // valid if employee id exsisted
            if (Bl.IsExiste(CollectionNames.Specializations, Item.ID) && Mode == ViewMode.Add)
            {
                ValidetionMessages.Add("Spcializations-exsist", "Specialization already existed in DB!!");
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

        public string Name
        {
            get
            {
                return Item.Name;
            }
            set
            {
                Item.Name = value;

                var demo = string.Empty;
                Set<string>(() => this.Name, ref demo, value);
            }
        }

        public int RegienNum
        {
            get
            {
               return (int)Item.Regien;
            }
            set
            {
                Item.Regien = (Regiens)value;
                int demo = -1;
                Set<int>(()=>this.RegienNum, ref demo,value);
            }

        }
        public IEnumerable<dynamic> RegiensDetailes
        {
            get
            {
                var a = Bl.EnumToValueName<Regiens>();
                return a;
            }
           
        }

        public Regiens Regien {
            get
            {
                return Item.Regien;
            }
        }

        public float MinHourSalary
        {
            get { return Item.MinHourSalary; }
            set
            {
                Item.MinHourSalary = value;
                float demo = 0.01F;
                Set<float>(() => this.MinHourSalary, ref demo, value);
            }
        }

        public float MaxHourSalary
        {
            get { return Item.MaxHourSalary; }
            set
            {
                Item.MaxHourSalary = value;
                float demo = 0.01F;
                Set<float>(() => this.MaxHourSalary, ref demo, value);
            }
        }
    }
}
