using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //יב.	ToStritg
    public class Contract : Entity
    {
        public Contract()
        {
            EmployeeName = string.Empty;
            EmployerName = string.Empty;

        }
        public Specialization Regine { set; get; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int EmployeeID { get; set; }
        public int EmployerID { get; set; }
        public string EmployerName { get; set; }
        public string EmployeeName { get; set; }
        public bool Interview { get; set; }//ראיון
        public bool Signature { get; set; }//חתימה
        public float SallaryBruto { get; set; }
        public string Details {
            get
            { 
                return this.ToString(); 
            }
        }
        public string ToBaceString()
        {
            return this.ID + " " + this.EmployeeID.ToString() + " " + this.EmployerID.ToString() + " "
            + EmployerName + " " + EmployeeName;
        }
        public float SallaryNeto { get; set; }
        public int NumeHour { get; set; }
        public override string ToString()
        {
            
            return string.Format(@"number ID: {0} 
Employee ID: {1}
Employer ID: {2}                                   
Interview? {3}
signature? {4}                                   
sallary Bruto: {5}                                                                                                                      
sallary Neto: {6}
Date Of Start: {7}
Date Of Stop: {8} 
number hour: {9}",
                 this.ID, this.EmployeeID.ToString(),
                 this.EmployerID.ToString(), this.Interview.ToString(),
                 this.Signature.ToString(), this.SallaryBruto.ToString(),
                 this.SallaryNeto.ToString(), this.FromDate.ToString(), this.ToDate.ToString(),
                 this.NumeHour.ToString());
        }

       
    }
}



