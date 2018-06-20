using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace UI.ViewModel
{
    public class SpecializationsViewModel:ListViewModel<SpecializationViewModel,Specialization>
    {
        public SpecializationsViewModel():base(CollectionNames.Specializations){}
    }
}
