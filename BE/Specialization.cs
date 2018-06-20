using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{ 
    public class Specialization:Entity
    {
       public Regiens Regien { get; set; }
       public string Name { get; set; }

        public float MaxHourSalary { get; set; }
        public float MinHourSalary { get; set; }

        public string ToBaceString() {

            return Name + Enum.GetName(Regien.GetType(), Regien) + " " + ID;
        }
        public override string ToString()
        {
            return string.Format(@"Name: {0}
                                   ID: {1}
                                   Regienss: {2}
                                   Max Hour Salary: {3}
                                   Min Hour Salary: {4}",
                                   this.Name, this.ID, this.Regien, this.MaxHourSalary, this.MinHourSalary);
        }

       
    }
}
