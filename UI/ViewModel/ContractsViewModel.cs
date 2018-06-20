using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using BL;
using BE;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Xml.Serialization;

namespace UI.ViewModel
{

    public class ContractsViewModel : ListViewModel<ContractViewModel, Contract>
    {
        public ContractsViewModel():base(CollectionNames.Contracts)
        {
            
        }
    }
}
