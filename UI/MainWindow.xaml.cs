using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// To access MetroWindow, add the following reference
using MahApps.Metro.Controls;
using BL;
using BE;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : MetroWindow
    {

        public IBL Bl;
        public MainWindow()
        {
            InitializeComponent();
            init();
        }
        public void init() {
            Bl = BL.FactoryBL.GetBL();
        }
    }
}
