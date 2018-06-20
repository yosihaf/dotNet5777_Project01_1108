using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Address 
    {
        public string City { get; set; }
        public string Street { get; set; }
        public override string ToString()
        {
            return string.Format("city is:{0}\nStreet is:{1}", City, Street);
        }
    }
}
