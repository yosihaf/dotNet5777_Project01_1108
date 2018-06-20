using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Text.RegularExpressions;

namespace BL
{
    public delegate int returnNum(Func<Contract, bool> del);
    public delegate List<Contract> returnList(Func<Contract, bool> del);
    class IBL_IMP : IBL
    {
        public const int MIN_EMPL_AGE = 18;
        public const double DATS_PER_YEAR = 365.25;
        public const int MIN_COMPANY_AGE = 1;
        public const int CONST_FEE = 10;

        DAL.IDAL dal = DAL.FactoryDal.GetDal();
        #region generic general function
        public T GetItem<T>(int id, CollectionNames collectionName) where T : Entity
        {
            return dal.GetItem<T>(id, collectionName);
        }

        public bool RemoveItem<T>(int id, CollectionNames collectionName) {

            return dal.RemoveItem<T>(id, collectionName);
        }

        public IEnumerable<T> getListByCollectionName<T>(CollectionNames collectionName) where T : Entity
        {
            return dal.getListByCollectionName<T>(collectionName);
        }

        public IEnumerable<T> GetCollection<T>(CollectionNames collectionName) where T : Entity
        {

            return dal.GetCollection<T>(collectionName);
        }

        public IEnumerable<T> SearchItem<T>(string query, CollectionNames collectionName) where T : Entity
        {
            return dal.SearchItem<T>(query, collectionName);

        }

        public void AddItem<T>(T value, CollectionNames collectionName) where T : Entity
        {
            dal.AddItem<T>(value, collectionName);
        }

        public void UpdateItem<T>(T value, CollectionNames collectionName) where T : Entity
        {
            dal.UpdateItem<T>(value, collectionName);
        }

        public T CopyItem<T>(T value, CollectionNames collectionName) where T : Entity
        {
            return dal.CopyItem<T>(value, collectionName);
        }
        #endregion

        public void addEmployerIfNotExist(Employer newEmployer)
        {
            dal.addEmployerIfNotExist(newEmployer);
        }

        public void addEmployeeIfNotExist(Employee newEmployee)
        {
            dal.addEmployeeIfNotExist(newEmployee);
        }

        public List<dynamic> GetLastYearBenefits()
        {
            var b = new List<DateRange>();

            var nowDate = DateTime.Now;
            var date = new DateTime(nowDate.Year -1, nowDate.Month , 1, 0, 0, 0);

            for (var i = 0; i < 12; i++) {
                var month = date.Month;
                var year = date.Year;
                var from = new DateTime(year, month, 1, 0, 0, 0);
                if (month > 11) {
                    year++;
                    month = 1;
                }
                else
                    month++;
                var to = new DateTime(year, month, 1, 0, 0, 0);
                var name = from.Year + "/" + from.Month;
                b.Add(new DateRange{ Name= name, From = from , To = to});
                date = to;
            }
            //timespan.Day
            var dResutl = new List<dynamic>();
            var result = LastYearBenefits(b).Reverse();
            foreach (var item in result) {
                dResutl.Add(new { Name = item.Key, Benefit = item.Sum() });
            }
            return dResutl;
        }
        public IEnumerable<dynamic> GetBanksDetails() {
            return dal.GetBanksDetails();
        }

        public List<Contract> GetContracts()
        {
            return dal.GetAllContracts().ToList();

        }
        public IEnumerable<dynamic> GetBaseEmoloyeesDetails()
        {

            return dal.GetBaseEmoloyeesDetailes();

        }
        public IEnumerable<dynamic> GetBaseEmoloyersDetails()
        {
            return dal.GetBaseEmoloyersDetailes();

        }
        public IEnumerable<dynamic> GetBaseSpecializationsDetails()
        {
            return dal.GetBaseSpecializationsDetailes();
        }
        public IEnumerable<dynamic> EnumToValueName<T>() where T : IConvertible {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var values = Enum.GetValues(typeof(T));
            var result = new List<dynamic>();

            foreach (var item in values)
                result.Add(new { Value = (int)item, Name = item.ToString() });

            return result;
        }

        public bool IsExiste(CollectionNames collectionNmae, int id)
        {
            return dal.IsExiste(collectionNmae, id);
        }
     
     
        #region add
        public void AddContract(Contract newContract)
        {
            var emloyeeID = newContract.EmployeeID;
            var emloyerID = newContract.EmployerID;

            int emloyeeContractsCount = (from item in dal.GetAllContracts()
                                         where item.EmployeeID == emloyeeID
                                         select item).Count();
            int emloyerContractsCount = (from item in dal.GetAllContracts()
                                         where item.EmployerID == emloyerID
                                         select item).Count();
            dal.addContract(newContract);
        }
        public void addEmployee(Employee newEmployee)
        {
            dal.addEmployee(newEmployee);
        }
        public void addEmployer(Employer newEmployer)
        {
            DateTime from = newEmployer.EstablishmentDate;
            dal.addEmployer(newEmployer);
        }
        public void addSpecialization(Specialization newSpecialization)
        {
            dal.addSpecialization(newSpecialization);
        }
        #endregion
     
        #region remove
        public bool removeContract(int id)
        {
            return dal.removeContract(id);
        }

        public bool removeEmployee(int id)
        {
            return dal.removeEmployee(id);
        }

        public bool removeEmployer(int id)
        {
            return dal.removeEmployer(id);
        }

        public bool removeSpecialization(int id)
        {
            return dal.removeSpecialization(id);
        }
        #endregion

        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null)
        {
            return dal.GetAllContracts(predicate);
        }


        public IEnumerable<Employee> GetAllEmployee(Func<Employee, bool> predicate = null)
        {
            return dal.GetAllEmployees(predicate);
        }

        public IEnumerable<Employer> GetAllEmployer(Func<Employer, bool> predicate = null)
        {
            return dal.GetAllEmployers(predicate);
        }

        public IEnumerable<Specialization> GetAllSpecialization(Func<Specialization, bool> predicate = null)
        {
            return dal.GetAllSpecializations(predicate).AsEnumerable();
        }


        public void updatinContract(Contract newContract)
        {
            dal.updatinContract(newContract);
        }


        public void updatinEmployee(Employee newEmployee)
        {
            dal.updatinEmployee(newEmployee);
        }

        public void updatinEmployer(Employer newEmployer)
        {
            dal.updatinEmployer(newEmployer);
        }

        public void updatinSpecialization(Specialization newSpecialization)
        {
            dal.updatinSpecialization(newSpecialization);
        }

        private bool contractIsLigal(Contract nContract)
        {
            DateTime tmp = nContract.FromDate;
            tmp.AddYears(1);
            if (dal.GetAllContracts().ToList().Find(x => x.EmployeeID == nContract.EmployeeID) == null)
                return false;
            if (dal.GetAllContracts().ToList().Find(x => x.EmployeeID == nContract.EmployeeID) == null)
                return false;
            if (tmp.CompareTo(DateTime.Today) < 0)
                return false;
            else
                return true;
        }

        private double GetAge(DateTime birthDay)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - birthDay;
            return interval.TotalDays / DATS_PER_YEAR;
        }


        public int CalculationDiscount(int sumContracts)
        {
            if (sumContracts >= 10)
                return 3;
            if (sumContracts >= 5)
                return 2;
            if (sumContracts >= 3)
                return 1;
            return 0;
        }

        public IEnumerable<Contract> sinun(Func<Contract, bool> func)
        {

            var allContract = dal.GetAllContracts();

            var newContract = from item in allContract
                              where func(item)
                              select item;
            return newContract;
        }

        public int numberSinun(Func<Contract, bool> number)
        {
            var newContracts = sinun(number);
            return newContracts.ToList<Contract>().Count;
        }

        public Specialization GetSpecialization(int id)
        {
            return (dal.GetAllSpecializations().ToList().FirstOrDefault(s => s.ID == id));
        }

        public Contract GetContract(int id)
        {
            return (dal.GetAllContracts().ToList().FirstOrDefault(s => s.ID == id));
        }

        public Employer GetEmployer(int id)
        {
            return (dal.GetAllEmployers().ToList().FirstOrDefault(s => s.ID == id));
        }

        public Employee GetEmployee(int id)
        {
            return (dal.GetAllEmployees().ToList().FirstOrDefault(s => s.ID == id));
        }

        public float CalculateNeto(float broto, int discount)
        {
            var fee = (CONST_FEE - discount);
            float neto = broto /= 100;
            neto *= fee;
            return neto;
        }


        

       
        public bool ValidBankBranch(int BankNumber, int BranchNumber) {
            return dal.GetBankBranch(BankNumber, BranchNumber) != null;

        }

        public float CalculationNeto(float Bruto, int LocalEmployeeID, int LocalEmployerID)
        {
            int emloyeeContractsCount = (from item in dal.GetAllContracts()
                                         where item.EmployeeID == LocalEmployeeID
                                         select item).Count();
            int emloyerContractsCount = (from item in dal.GetAllContracts()
                                         where item.EmployerID == LocalEmployerID
                                         select item).Count();

            int sumContracts = emloyerContractsCount + emloyeeContractsCount;

            // Calculation discount
            var discount = CalculationDiscount(sumContracts);
            var pre = 100 - CONST_FEE + discount;
            var neto = Bruto * ((float)pre / 100);
            return neto;
        }

        public IEnumerable<IGrouping<string, int>> LastYearBenefits(List<DateRange> dr)
        {
            return from item in dr
                   group Spacing(item.From, item.To) by item.Name;

        }

        public int Spacing(DateTime From, DateTime To)
        {
            var list = dal.GetAllContracts();
            DateTime F;
            DateTime T;
            TimeSpan Temp, Temp1;
            float sum = 0;
            foreach (var item in list)
            {
                F = item.FromDate;
                T = item.ToDate;
                Temp = From - F;
                Temp1 = To - T;
                if (Temp.Days >= 0 && Temp1.Days <= 0)
                    sum += Chishuv(item);
            }
            return (int)sum;
        }
        
        private float Chishuv(Contract LocalContract)
        {
            var bru = LocalContract.SallaryBruto;
            var net = LocalContract.SallaryNeto;
            return (bru - net);
        }
        
        #region searches

        public List<Employer> searchEmployers(string key)
        {
            return dal.searchEmployers(key);
        }

        public List<Employee> searchEmployees(string key)
        {
            return dal.searchEmployees(key);
        }

        public List<Contract> searchContracts(string key)
        {
            return dal.searchContracts(key);
        }

        public List<Specialization> searchSpecializations(string key)
        {
            return dal.searchSpecializations(key);
        }
        #endregion
        #region Valid
        public bool ValidAgeToEmployr(DateTime birthday)
        {
            var age = GetAge(birthday);
            if (age < MIN_COMPANY_AGE)
                return false;
            return true;
        }
        public bool ValidAgeToEmployy(DateTime birthday)
        {
            var age = GetAge(birthday);
            if (age > MIN_EMPL_AGE)
                return true;
            return false;
        }
        public bool ValidPhon(string phon)
        {
            var phonPantern = "^[0-9]{3}-[0-9]{7}$";
            if (phon == null)
                return false;
            return Regex.IsMatch(phon, phonPantern);
        }

        public bool ValidID(int id)
        {
            if (id >= 10000000 && id < 100000000)
                return true;
            return false;
        }
        public bool ValidContract(Contract localContract)
        {
            return dal.ValidContract(localContract);
        }
        public bool ValidRemuveEmployee(Employee LocalEmployee)
        {
            var list = dal.GetAllContracts();
            return !(list.FirstOrDefault(i => i.EmployeeID == LocalEmployee.ID) == null);
        }
        public bool ValidRemuveEmployer(Employer LocalEmployer)
        {
            var list = dal.GetAllContracts();
            return !(list.FirstOrDefault(i => i.EmployerID == LocalEmployer.ID) == null);
        }
        public bool ValidRemuveSpecialization(Specialization LocalSpecialization)
        {
            var listEmployee = dal.GetAllEmployees();

            return !(listEmployee.FirstOrDefault(i => i.SpecializationID == LocalSpecialization.ID) == null);
        }
        //Valid Sallary
        public bool ValidSallary(Contract LocalContract)
        {
            var Bruto = LocalContract.SallaryBruto;
            var LocalSpecialization = LocalContract.Regine;
            var Maximum = LocalSpecialization.MaxHourSalary;
            var Minimum = LocalSpecialization.MinHourSalary;
            var boolen = (Bruto > Maximum || Bruto < Minimum);
            return boolen;
        }
        #endregion
    }
}
