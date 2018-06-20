using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public interface IItemViewModel<T>
    {
        T Item { set; get; }
        bool IsValid { get; }
        bool CanRemoved { get; }
        ViewMode Mode { set; get; }
    }
}
