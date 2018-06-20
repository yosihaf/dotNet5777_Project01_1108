using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        static IBL bl = null;
        /// <summary>
        /// factory
        /// </summary>
        /// <returns></returns>
        public static IBL GetBL()
        {
            if (bl == null)
            {
                bl = new IBL_IMP();
            }
            return bl;
        }
    }
}
