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
    public class ContractViewModel: ItemViewModel<Contract>
    {
        protected override bool isCanRemoved()
        {
            return true; // !Bl.ValidContract(Item);
        }

        public bool RemoveMessageIfExsist(string key)
        {
            foreach (var pair in ValidetionMessages)
            {
                if (pair.Value == key)
                {
                    ValidetionMessages.Remove(pair.Key);
                    return true;
                }
            }
            return false;
        }

        public override bool ValidParams()
        {
            var flag = true;
            ValidetionMessages = new ObservableDictionary<string, string>();
            if (!Bl.ValidID(Item.EmployeeID) || !Bl.ValidID(Item.EmployerID))
            {
                ValidetionMessages.Add("id-incorrect", "id nust to be a number and contain at 8 digds");
                flag = false;
            }


            //// valid if id exsisted
            //if ( Mode == ViewMode.Add && !Bl.IsExiste(collectionName, Item.ID) && Item.ID =)
            //{
            //    ValidetionMessages.Add("id-exsist", "id alrady exsited!!");
            //    flag = false;
            //}


            // valid if employee id exsisted
            if (!Bl.IsExiste(CollectionNames.Employees, Item.EmployeeID))
            {
                ValidetionMessages.Add("employee-not-exsist", "employee not existed in DB!!");
                flag = false;
            }

            // valid if employee id exsisted
            if (!Bl.IsExiste(CollectionNames.Employers, Item.EmployerID))
            {
                ValidetionMessages.Add("employer-not-exsist", "employer not existed in DB!!");
                flag = false;
            }
            
            if (Item.Regine != null && Bl.ValidSallary(Item)) {
                var max = Item.Regine.MaxHourSalary;
                var min = Item.Regine.MinHourSalary;

                ValidetionMessages.Add("salary-invalid", "Salary need to be between "+ min + " to: " + max + "!!");
                flag = false;

            }

            if (Item.Regine == null)
            {
                var emp = Bl.GetEmployee(EmployeeID);
                if (emp != null)
                {
                    Item.Regine = Bl.GetSpecialization(emp.SpecializationID);
                    EmployeeName = emp.Name;
                }
                if (Item.Regine == null)
                {
                    ValidetionMessages.Add("employee-specialization", "not specipey specialization for this employee!!");
                    flag = false;
                }

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

        public int EmployeeID
        {
            get
            {
                return Item.EmployeeID;
            }
            set
            {
                Item.EmployeeID = value;
                var emp = Bl.GetEmployee(value);
                if (emp != null) {
                    Item.Regine = Bl.GetSpecialization(emp.SpecializationID);
                    EmployeeName = emp.Name;
                }
                var demo = 0;
                Set<int>(() => this.EmployeeID, ref demo, value);
            }
        }

        public string EmployeeName
        {
            get { return Item.EmployeeName; }
            set
            {
                Item.EmployeeName = value;
                string demo = "";
                Set<string>(() => this.EmployeeName, ref demo, value);
            }
        }

        public int EmployerID
        {
            get { return Item.EmployerID; }
            set
            {
                Item.EmployerID = value;
                var emp = Bl.GetEmployer(value);
                if (emp != null)
                    EmployerName = emp.Name;
                var demo = 0;
                Set<int>(() => this.EmployerID, ref demo, value);
            }
        }

        public string EmployerName
        {
            get { return Item.EmployerName; }
            set
            {
                var demo = Item.EmployerName;
                Item.EmployerName = value;
                Set<string>(() => this.EmployerName, ref demo, value);
            }
        }

        public DateTime FromDate
        {
            get { return Item.FromDate; }
            set
        {
                var demo = Item.FromDate;
                Item.FromDate = value;
                Set<DateTime>(() => this.FromDate, ref demo, value);
            }
        }

        public DateTime ToDate
        {
            get { return Item.ToDate; }
            set
            {
                var demo = Item.ToDate;
                Item.ToDate = value;
                Set<DateTime>(() => this.ToDate, ref demo, value);
            }
        }

        public bool Signature
        {
            get { return Item.Signature; }
            set
            {
                var demo = Item.Signature;
                Item.Signature = value;
                Set<bool>(() => this.Signature, ref demo, value);
            }
        }

        public bool Interview
        {
            get { return Item.Interview; }
            set
            {
                var demo = Item.Interview;
                Item.Interview = value;
                Set<bool>(() => this.Interview, ref demo, value);
            }
        }

        public float SallaryBruto
        {
            get
            {
                return Item.SallaryBruto;
            }
            set
            {
                var demo = Item.SallaryBruto;
                Item.SallaryBruto = value;
                if (EmployeeID > 0 && EmployerID > 0)
                    SallaryNeto = Bl.CalculationNeto(value, EmployeeID, EmployerID);
                Set<float>(() => this.SallaryBruto, ref demo, value);
            }
        }

        public float SallaryNeto
        {
            get { return Item.SallaryNeto; }
            set
            {
                Item.SallaryNeto = value;
                var demo = 0F;
                Set<float>(() => this.SallaryNeto, ref demo, value);
            }
        }
    }
}
