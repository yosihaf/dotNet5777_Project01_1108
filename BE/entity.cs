using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Entity
    {
        public int ID;
    }
    public class ItemBaseDeatils : IEquatable<ItemBaseDeatils> {

        public int Value { get; set; }
        public string Name { get; set; }
        public bool Equals(ItemBaseDeatils other)
        {
            if (Value == other?.Value)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            return Value;
        }
    }
    public class DateRange{
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { set; get; }

    }
}
