using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDAL
    {
        bool ValidContract(Contract localContract);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSpecialization"></param>
        void addSpecialization(Specialization newSpecialization);
        bool removeSpecialization(int id);
        void updatinSpecialization(Specialization newSpecialization);
        object GetobjectById(object obj);
        IEnumerable<Specialization> GetAllSpecializations(Func<Specialization, bool> predicate = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newEmployee"></param>
        void addEmployee(Employee newEmployee);
        bool removeEmployee(int id);
        void updatinEmployee(Employee newEmployee);
        IEnumerable<Employee> GetAllEmployees(Func<Employee, bool> predicate = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newEmployer"></param>
        void addEmployer(Employer newEmployer);
        bool removeEmployer(int id);
        void updatinEmployer(Employer newEmployer);
        IEnumerable<Employer> GetAllEmployers(Func<Employer, bool> predicate = null);

        IEnumerable<dynamic> GetBaseSpecializationsDetailes();
        IEnumerable<dynamic> GetBaseEmoloyersDetailes();
        IEnumerable<dynamic> GetBaseEmoloyeesDetailes();

        bool RemoveItem<T>(int id, CollectionNames collectionName);

        T GetItem<T>(int id, CollectionNames collectionName) where T : Entity;
       
         IEnumerable<T> getListByCollectionName<T>(CollectionNames collectionName) where T : Entity;
        
         IEnumerable<T> GetCollection<T>(CollectionNames collectionName) where T : Entity;
       

         IEnumerable<T> SearchItem<T>(string query, CollectionNames collectionName) where T : Entity;
         IEnumerable<dynamic> GetBanksDetails();
         BankBranch GetBankBranch(int BankNumber, int BranchNumber);
         void AddItem<T>(T value, CollectionNames collectionName) where T : Entity;


        void UpdateItem<T>(T value, CollectionNames collectionName) where T : Entity;


        T CopyItem<T>(T value, CollectionNames collectionName) where T : Entity;
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newContract"></param>
        void addContract(Contract newContract);
        bool removeContract(int id);
        void updatinContract(Contract newContract);
        IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicate = null);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        void addEmployerIfNotExist(Employer newEmployer);
        void addEmployeeIfNotExist(Employee newEmployee);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsExiste(CollectionNames collectionName, int id);
        Contract GetContractById(int id);
        Employee GetEmployeeById(int id);
        Employer GetEmployerById(int id);
        Specialization GetSpecializationById(int id);


        List<Employer> searchEmployers(string key);
        List<Employee> searchEmployees(string key);
        List<Contract> searchContracts(string key);
        List<Specialization> searchSpecializations(string key);
    }


    

}



