using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;


namespace DAL
{
   public class FactoryDal
    {
        static IDAL dal = null;
        /// <summary>
        /// factory
        /// </summary>
        /// <returns></returns>
        public static IDAL GetDal()
        {
            if (dal == null)
            {
                dal = new DalImp();
            }
            return dal;
        }
    }
}
