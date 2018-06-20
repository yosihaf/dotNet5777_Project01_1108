using GalaSoft.MvvmLight;

namespace UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See  
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
            this.GeneralVM = new GeneralViewModel();
            this.ContractsVM = new ContractsViewModel();
            this.EmployeesVM = new EmployeesViewModel();
            this.EmployersVM = new EmployersViewModel();
            this.SpecializationsVM = new SpecializationsViewModel();
        }

        #region Properties
        private ContractsViewModel _contractsVM;

        public ContractsViewModel ContractsVM
        {
            get
            {
                return _contractsVM;
            }
            set
            {
                Set<ContractsViewModel>(() => this.ContractsVM, ref _contractsVM, value);
            }
        }

        private GeneralViewModel _generalVM;

        public GeneralViewModel GeneralVM
        {
            get
            {
                return _generalVM;
            }
            set
            {
                Set<GeneralViewModel>(() => this.GeneralVM, ref _generalVM, value);
            }
        }
        private SpecializationsViewModel _specializationsVM;

        public SpecializationsViewModel SpecializationsVM
        {
            get
            {
                return _specializationsVM;
            }
            set
            {
                Set<SpecializationsViewModel>(() => this.SpecializationsVM, ref _specializationsVM, value);
            }
        }
        private EmployeesViewModel _employeesVM;

        public EmployeesViewModel EmployeesVM
        {
            get
            {
                return _employeesVM;
            }
            set
            {
                Set<EmployeesViewModel>(() => this.EmployeesVM, ref _employeesVM, value);
            }
        }
        private EmployersViewModel _employersVM;

        public EmployersViewModel EmployersVM
        {
            get
            {
                return _employersVM;
            }
            set
            {
                Set<EmployersViewModel>(() => this.EmployersVM, ref _employersVM, value);
            }
        }
        #endregion
    }
}