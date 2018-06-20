using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

//יא.	ToString.

    public class Employer :Entity
    {
        public Address Adresses { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CompanyName { get; set; }//אם אדם פרטי יכול להיות ריק
        public string Phon { get; set; }
        public string Name
        {
            get {
                if (IsCompany)
                    return CompanyName;
                else
                    return FirstName + " " +LastName;
            }
        }
        public DateTime EstablishmentDate { get; set; }//תאריך הקמת העסק
        public bool IsCompany { get; set; }
       
      
        public string ToBaceString()
        {
            return (this.ID.ToString()+" "
                + this.LastName+" "
                +this.FirstName+" "
                + Adresses.ToString()+" "
                + this.Phon+" ");
               
        }

         public override string ToString()
          {
            if(!IsCompany)
              return string.Format(@"number ID: {0} 
  last name: {1}
  first name: {2}  
  naem company{3}                                 
  Addrass : {4}
  phon: {5}                                   
  starting a business: {6}                                                                                                                      
  this is business privet",
                  this.ID, this.LastName,
                  this.FirstName,Adresses.ToString(),
                  this.Phon, this.EstablishmentDate.ToString()
                 
                  );
           else return string.Format(@"number ID: {0} 
  last name for boss: {1}
  first name for boss: {2}                                   
  Addrass for company: {3}
  phon: {4}                                   
  starting a business: {5}                                                                                                                      
  this is  company",
                 this.ID, this.LastName, this.CompanyName,
                 this.FirstName, Adresses.ToString(),
                 this.Phon, this.EstablishmentDate.ToString()
                 );
            
          }
    }
}
