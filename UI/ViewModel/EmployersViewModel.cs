using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace UI.ViewModel
{
    public class EmployersViewModel:ListViewModel<EmployerViewModel,Employer>
    {
        public EmployersViewModel():base(CollectionNames.Employers)
        {

        }
    }
}
