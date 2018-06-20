using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public  class GeneralViewModel:ViewModelBase
    {
        BL.IBL Bl = BL.FactoryBL.GetBL();
        public int EmployeesCount
        {
            get
            {
                return Bl.GetAllEmployee().Count();
            }
        }
        public int EmployersCount
        {
            get
            {
                return Bl.GetAllEmployer().Count();
            }
        }
        public int ContractsCount
        {
            get
            {
                return Bl.GetAllContract().Count();
            }
        }
        public int SpeciailizationCount
        {
            get
            {
                return Bl.GetAllSpecialization().Count();
            }
        }
        public List<dynamic> LastYearBenefits {

            get
            {
                var r = Bl.GetLastYearBenefits();
                return r;

            }
        }

    }
}
