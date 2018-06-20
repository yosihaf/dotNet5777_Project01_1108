using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankAccount
    {

        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string NumberAccount { get; set; }
        
        public override string ToString()
        {
            return string.Format(@"    name Bank: {0} 
                                       number Bank: {1}
                                       number Branch: {2}
                                       numAccount: {3} ",
                this.BankName, this.BankNumber.ToString(),
                this.BranchNumber.ToString(),
                 this.NumberAccount.ToString());
        }
    }














}
