using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public interface IBL
    {
       

        void addSpecialization(Specialization newSpecialization);
        bool removeSpecialization(int id);
        void updatinSpecialization(Specialization newSpecialization);
        Specialization GetSpecialization(int id);
        IEnumerable<Specialization> GetAllSpecialization(Func<Specialization, bool> predicate = null);

      
        void addEmployee(Employee newEmployee);
        bool removeEmployee(int id);
        void updatinEmployee(Employee newEmployee);
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployee(Func<Employee, bool> predicate = null);

       

        void updatinEmployer(Employer newEmployer);
        bool removeEmployer(int id);
        void addEmployer(Employer newEmployer);
        IEnumerable<Employer> GetAllEmployer(Func<Employer, bool> predicate = null);
        List<dynamic> GetLastYearBenefits();
        Employer GetEmployer(int id);


        void AddContract(Contract newContract);
        bool removeContract(int id);
        bool ValidAgeToEmployr(DateTime birthday);
        bool ValidAgeToEmployy(DateTime birthday);
        void updatinContract(Contract newContract);
        Contract GetContract(int id);
        List<Contract> GetContracts();
        IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null);


        IEnumerable<dynamic> GetBaseSpecializationsDetails();
        IEnumerable<dynamic> GetBaseEmoloyersDetails();
        IEnumerable<dynamic> GetBaseEmoloyeesDetails();
        IEnumerable<dynamic> GetBanksDetails();

      
        float CalculationNeto(float Bruto, int LOcalEmployeeID, int LocalEmployerID);
      

        List<Employer> searchEmployers(string key);
        List<Employee> searchEmployees(string key);
        List<Contract> searchContracts(string key);
        List<Specialization> searchSpecializations(string key);

        void addEmployerIfNotExist(Employer newEmployer);
        void addEmployeeIfNotExist(Employee newEmployee);

        IEnumerable<dynamic> EnumToValueName<T>()where T: IConvertible;

        #region genric function
        bool RemoveItem<T>(int id, CollectionNames collectionName);
        T GetItem<T>(int id, CollectionNames collectionName) where T : Entity;
        IEnumerable<T> getListByCollectionName<T>(CollectionNames collectionName) where T : Entity;
        IEnumerable<T> GetCollection<T>(CollectionNames collectionName) where T : Entity;
        IEnumerable<T> SearchItem<T>(string query, CollectionNames collectionName) where T : Entity;
        void AddItem<T>(T value, CollectionNames collectionName) where T : Entity;
        void UpdateItem<T>(T value, CollectionNames collectionName) where T : Entity;
        T CopyItem<T>(T value, CollectionNames collectionName) where T : Entity;
        #endregion

        IEnumerable<Contract> sinun(Func<Contract, bool> func);
        int numberSinun(Func<Contract, bool> func);
  
        #region Valids
        bool IsExiste(CollectionNames collectionNmae, int id);
        bool ValidID(int iD);
        bool ValidBankBranch(int BankNumber, int BranchNumber);
        bool ValidPhon(string phon);
        bool ValidSallary(Contract LocalContract);
        bool ValidRemuveEmployee(Employee LocalEmployee);
        bool ValidRemuveSpecialization(Specialization LocalSpecialization);
        bool ValidRemuveEmployer(Employer LocalEmployer);
        bool ValidContract(Contract localContract);
        #endregion
    }
}