using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Employee :Entity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }//תאריך לידה
        public string Phon { get; set; }
        public string Name { get {return FirstName +" "+ LastName; }}
        // transform address to seperate object.
        public Address Adresses { get; set; }
        public int SpecializationID { get; set; }
        public Degrees Degree { get; set; }
        public bool Military { get; set; }
        public BankAccount Account { get; set; }

        public string ToBaceString()
        {
            return (this.ID.ToString() + " "
                + this.LastName + " "
                + this.FirstName + " "
                + Adresses + " "
                + this.Phon + " "+
                this.SpecializationID +" "
                + this.Account?.NumberAccount+" "
                );//.Degree.ToString()
        }
        public override string ToString()
        {
            return string.Format(@"number ID: {0} 
last name: {1}
first name: {2}                                   
Addrass : {3}
phon: {4}                                   
birth day: {5}                                                                                                                      
Specializations: {6}
military: {7}
Bank Account: {8} 
Degree: {9}",
                this.ID, this.LastName,
                this.FirstName,Adresses.ToString(),
                this.Phon, this.Birthday.ToString(),
                this.SpecializationID.ToString(), this.Military.ToString(), this.Account.ToString(), this.Degree.ToString()
                ); 
        }
        }
    }

