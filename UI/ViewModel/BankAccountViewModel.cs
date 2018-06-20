using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections.ObjectModel;

namespace UI.ViewModel
{
    public class BankAccountViewModel : ItemViewModel<BankAccount>
    {

       
        protected override void OnItemSet()
        {
            if (Item == null)
            {
                Item = new BankAccount();
                return;
            }
        }
        public override bool ValidParams()
        {
            var flag = true;
            ValidetionMessages = new ObservableDictionary<string, string>();
            if (!Bl.ValidBankBranch(Item.BankNumber , Item.BranchNumber))
            {
                ValidetionMessages.Add("Bank-Branch", "Bank branch is not exist!!");
                flag = false;
            }

           


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

      
        public int BankNumber
        {
            get
            {
                return Item.BankNumber;
            }
            set
            {
                Item.BankNumber = value;
                Item.BankName = Bl.GetBanksDetails().ToList().FirstOrDefault(x=>x.Value == value).Name;

                var demo = 0;
                Set<int>(() => this.BankNumber, ref demo, value);
            }
        }
        public string BankName
        {
            get
            {
                return Item.BankName;
            }
          
        }
        public int BranchNumber
        {
            get
            {
                return Item.BranchNumber;
            }
            set
            {
                Item.BranchNumber = value;

                var demo = -1;
                Set<int>(() => this.BranchNumber, ref demo, value);
            }
        }

        public string NumberAccount
        {
            get { return Item.NumberAccount; }
            set
            {
                Item.NumberAccount = value;
                string demo = "";
                Set<string>(() => this.NumberAccount, ref demo, value);
            }
        }

    }
}
