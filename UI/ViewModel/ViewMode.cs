using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UI.ViewModel
{
    public enum ViewMode
    {
        [XmlEnum("Edit")]
        Edit,
        [XmlEnum("View")]
        View,
        [XmlEnum("Add")]
        Add,
        [XmlEnum("EditOrAdd")]
        EditOrAdd
    }
}
