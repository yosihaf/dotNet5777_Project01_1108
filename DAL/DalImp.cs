using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DS;


namespace DAL
{

    public class DalImp : IDAL
    {
        Random r = new Random();
        public DalImp()
        {
            var g = new DataSource();
        }

        #region search
        public List<Employer> searchEmployers(string key)
        {
            if (key == null)
                return null;
            key = key.ToLower();
            var list = DataSource.Employers;

            return (from emp in list
                    where emp.ToBaceString().ToLower().Contains(key)
                    select emp).ToList();
        }
        public List<Employee> searchEmployees(string key)
        {
            if (key == null)
                return null;
            key = key.ToLower();
            var list = DataSource.Employees;

            return (from emp in list
                    where emp.ToBaceString().ToLower().Contains(key)
                    select emp).ToList();
        }
        public List<Contract> searchContracts(string key)
        {
            if (key == null)
                return null;
            key = key.ToLower();
            var list = DataSource.Contracts;
            return (from emp in list
                    where emp.ToBaceString().ToLower().Contains(key)
                    select emp).ToList();
        }
        public List<Specialization> searchSpecializations(string key)
        {
            if (key == null)
                return null;
            key = key.ToLower();
            var list = DataSource.Specializations;
            return (from emp in list
                    where emp.ToBaceString().ToLower().Contains(key)
                    select emp).ToList();
        }
        #endregion

        #region add items
        public void addContract(Contract newContract)
        {
            Contract Localcontact = CopyContract(newContract);
            ExceptionsOfContract(Localcontact);
            CollectionNames collectionName = CollectionNames.Contracts;
            var list = DataSource.Contracts;
            Localcontact.ID = getID(collectionName);
            list.Add(Localcontact);
            DataSource.SaveData(collectionName);
        }

        public void addSpecialization(Specialization newSpecialization)
        {
            Specialization LocalSpecialization = CopySpecialization(newSpecialization);
            ExceptionsOfSpecialization(LocalSpecialization);
            CollectionNames collectionName = CollectionNames.Specializations;
            var list = DataSource.Specializations;
            //Inventor number that does not exist in
            LocalSpecialization.ID = getID(collectionName);
            list.Add(LocalSpecialization);
            DataSource.SaveData(collectionName);
        }

        public void addEmployee(Employee newEmployee)
        {
            Employee LocalEmployee = CopyEmployee(newEmployee);
            ExceptionsOfEmployee(LocalEmployee);
            DataSource.Employees.Add(LocalEmployee);
            CollectionNames collectionName = CollectionNames.Employees;
            DataSource.SaveData(collectionName);
        }

        public void addEmployer(Employer newEmployer)
        {
            Employer LocalEmployer = CopyEmployer(newEmployer);
            ExceptionsOfEmployer(LocalEmployer);
            DataSource.Employers.Add(newEmployer);
            CollectionNames collectionName = CollectionNames.Employers;
            DataSource.SaveData(collectionName);
        }
        #endregion

        #region remove items

        public bool removeContract(int id)
        {
            var localContract = DataSource.Contracts.FirstOrDefault(s => s.ID == id);
            if (localContract == null)
                throw new Exception("Contract with the same id not found...");

            return DataSource.Contracts.Remove(localContract);
        }

        public bool removeEmployee(int id)
        {
            Employee Employee = DataSource.Employees.FirstOrDefault(s => s.ID == id);
            if (Employee == null)
                throw new Exception("Employee with the same id already exists...");
            return DataSource.Employees.Remove(Employee);
        }

        public bool removeEmployer(int id)
        {
            Employer employer = DataSource.Employers.FirstOrDefault(s => s.ID == id);

            if (employer == null)
                throw new Exception("Student with the same id already exists...");

            DataSource.Contracts.RemoveAll(sc => sc.EmployerID == id);

            return DataSource.Employers.Remove(employer);
        }

        public bool removeSpecialization(int Id)
        {
            Specialization specialization = DataSource.Specializations.FirstOrDefault(s => s.ID == Id);

            if (specialization == null)
                throw new Exception("Student with the same id already exists...");

            return DataSource.Specializations.Remove(specialization);
        }
        #endregion

        #region get data
        public IEnumerable<Specialization> GetAllSpecializations(Func<Specialization, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.Specializations.AsEnumerable();

            return DataSource.Specializations.Where(predicate);
        }

        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.Contracts.AsEnumerable();

            return DataSource.Contracts.Where(predicate);
        }

        public IEnumerable<Employee> GetAllEmployees(Func<Employee, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.Employees.AsEnumerable();

            return DataSource.Employees.Where(predicate);
        }

        public IEnumerable<Employer> GetAllEmployers(Func<Employer, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.Employers.AsEnumerable();

            return DataSource.Employers.Where(predicate);
        }
        #endregion

        #region updatins

        public void updatinContract(Contract newContract)
        {
            Contract Localcontact = CopyContract(newContract);

            int index = DataSource.Contracts.FindIndex(s => s.ID == Localcontact.ID);
            if (index == -1)
                throw new Exception("Contract with the same id not found");
            DataSource.Contracts[index] = Localcontact;
            DataSource.SaveData(CollectionNames.Contracts);
        }

        public void updatinEmployee(Employee newEmployee)
        {

            Employee LocalEmployee = CopyEmployee(newEmployee);
            int index = DataSource.Employees.FindIndex(s => s.ID == LocalEmployee.ID);
            if (index == -1)
                throw new Exception("Employee with the same id not found...");
            DataSource.Employees[index] = LocalEmployee;
            DataSource.SaveData(CollectionNames.Employees);
        }

        public void updatinEmployer(Employer newEmployer)
        {
            Employer LocalEmployer = CopyEmployer(newEmployer);
            int index = DataSource.Employers.FindIndex(s => s.ID == LocalEmployer.ID);
            if (index == -1)
                throw new Exception("Employer with the same id not found...");
            DataSource.Employers[index] = LocalEmployer;
            DataSource.SaveData(CollectionNames.Employers);
        }

        public void updatinSpecialization(Specialization newSpecialization)
        {
            Specialization LocalSpecialization = CopySpecialization(newSpecialization);
            int index = DataSource.Specializations.FindIndex(s => s.ID == newSpecialization.ID);
            if (index == -1)
                throw new Exception("Specialization with the same id not found...");
            DataSource.Specializations[index] = newSpecialization;
            DataSource.SaveData(CollectionNames.Specializations);
        }
        #endregion
        #region genric function
        public T GetItem<T>(int id, CollectionNames collectionName) where T : Entity
        {
            var list = getListByCollectionName(collectionName);
            var item = (T)list.FirstOrDefault(X => X.ID == id);
            if (item != null)
                return CopyItem<T>(item, collectionName);
            return item;
        }

        public bool RemoveItem<T>(int id, CollectionNames collectionName)
        {

            switch (collectionName)
            {
                case CollectionNames.Employees:
                    return removeEmployee(id);
                case CollectionNames.Employers:
                    return removeEmployer(id);
                case CollectionNames.Contracts:
                    return removeContract(id);
                case CollectionNames.Specializations:
                    return removeSpecialization(id);
                default:
                    throw new Exception();
            }
        }

        public IEnumerable<T> getListByCollectionName<T>(CollectionNames collectionName) where T : Entity
        {
            switch (collectionName)
            {
                case CollectionNames.Employees:
                    return GetAllEmployees().Cast<T>();
                case CollectionNames.Employers:
                    return GetAllEmployers().Cast<T>();
                case CollectionNames.Contracts:
                    return GetAllContracts().Cast<T>();
                case CollectionNames.Specializations:
                    return GetAllSpecializations().Cast<T>();
                default:
                    throw new Exception();
            }
        }

        public IEnumerable<T> GetCollection<T>(CollectionNames collectionName) where T : Entity {

            return getListByCollectionName<T>(collectionName);
        }

        public IEnumerable<T> SearchItem<T>(string query, CollectionNames collectionName) where T : Entity {
            switch (collectionName)
            {
                case CollectionNames.Employees:
                    return searchEmployees(query).Cast<T>();
                case CollectionNames.Employers:
                    return searchEmployers(query).Cast<T>();
                case CollectionNames.Contracts:
                    return searchContracts(query).Cast<T>();
                case CollectionNames.Specializations:
                    return searchSpecializations(query).Cast<T>();
                default:
                    throw new Exception();
            }

        }

        public void AddItem<T>(T value, CollectionNames collectionName) where T : Entity
        {
            switch (collectionName)
            {
                case CollectionNames.Employees:
                    addEmployee(value as Employee);
                    break;
                case CollectionNames.Employers:
                    addEmployer(value as Employer);
                    break;
                case CollectionNames.Contracts:
                    addContract(value as Contract);
                    break;
                case CollectionNames.Specializations:
                    addSpecialization(value as Specialization);
                    break;

                default:
                    throw new Exception();
            }
        }

        public void UpdateItem<T>(T value, CollectionNames collectionName) where T : Entity
        {
            switch (collectionName)
            {
                case CollectionNames.Employees:
                    updatinEmployee(value as Employee);
                    break;
                case CollectionNames.Employers:
                    updatinEmployer(value as Employer);
                    break;
                case CollectionNames.Contracts:
                    updatinContract(value as Contract);
                    break;
                case CollectionNames.Specializations:
                    updatinSpecialization(value as Specialization);
                    break;

                default:
                    throw new Exception();
            }
        }

        public T CopyItem<T>(T value, CollectionNames collectionName) where T : Entity {
            switch (collectionName)
            {
                case CollectionNames.Employees:
                    return CopyEmployee(value as Employee) as T;
                case CollectionNames.Employers:
                    return CopyEmployer(value as Employer) as T;
                case CollectionNames.Contracts:
                    return CopyContract(value as Contract) as T;
                case CollectionNames.Specializations:
                    return CopySpecialization(value as Specialization) as T;
                default:
                    throw new Exception();
            }

        }

        public IEnumerable<dynamic> GetBanksDetails() {
            return DataSource.BankData.GetBanksDetails();
        }
        #endregion
        public BankBranch GetBankBranch(int BankNumber, int BranchNumber) {
            var bankBranch = DataSource.BankData.GetBankBranch(BankNumber, BranchNumber);
            return bankBranch;
        }
        public void addEmployerIfNotExist(Employer newEmployer)
        {
            CollectionNames collectionName = CollectionNames.Employers;
            var list = DataSource.Employers;
            int id = newEmployer.ID;
            if (id == 0)
            {
                newEmployer.ID = getID(collectionName);
            }
            else if (IsExiste(collectionName, id))
            {
                throw new Exception("this employer already exist");
            }

            list.Add(newEmployer);
        }

        public void addEmployeeIfNotExist(Employee newEmployee)
        {
            CollectionNames collectionName = CollectionNames.Employees;
            var list = DataSource.Employees;
            int id = newEmployee.ID;
            if (id == 0)
            {
                newEmployee.ID = getID(collectionName);
            }
            else if (IsExiste(collectionName, id))
            {
                throw new Exception("this employee already exist");
            }

            list.Add(newEmployee);
        }

        public IEnumerable<dynamic> GetBaseEmoloyeesDetailes() {

            var t = from emp in DataSource.Employees
                    select new { ID = emp.ID, Name = emp.Name };
            return t;

        }
        public IEnumerable<dynamic> GetBaseEmoloyersDetailes()
        {

            var t = from emp in DataSource.Employers
                    select new { ID = emp.ID, Name = emp.Name };
            return t;

        }
        public IEnumerable<dynamic> GetBaseSpecializationsDetailes()
        {

            var t = from spe in DataSource.Specializations
                    select new { ID = spe.ID, Name = spe.Name };
            return t;

        }

        public int getID(CollectionNames collectionName = CollectionNames.Null)
        {
            DataSource.Code++;
            DataSource.SaveCode();
            return DataSource.Code;
            /* int id;
             var list = getListByCollectionName(collectionName);
             do
             {
                 id =  r.Next(10000000, 99999999);
             } while (list != null && IsExiste(collectionName, id));
             return id;*/
        }

        public bool IsExiste(CollectionNames collectionNmae, int id)
        {
            var list = getListByCollectionName(collectionNmae);
            return !(list.FirstOrDefault(
                x =>
                x.ID == id
                ) == null);
        }

        public List<Entity> getListByCollectionName(CollectionNames collectionNmaes)
        {
            List<Entity> list = null;
            switch (collectionNmaes)
            {
                case CollectionNames.Employees:
                    list = DataSource.Employees.ToList<Entity>();
                    break;
                case CollectionNames.Employers:
                    list = DataSource.Employers.ToList<Entity>();
                    break;
                case CollectionNames.Contracts:
                    list = DataSource.Contracts.ToList<Entity>();
                    break;
                case CollectionNames.Specializations:
                    list = DataSource.Specializations.ToList<Entity>();
                    break;
                case CollectionNames.Null:
                    list = null;
                    break;
            }
            return list;
        }

        #region get by id 
        public Entity GetEntityById(int id, CollectionNames collectionName)
        {
            var collection = getListByCollectionName(collectionName);
            return collection.Find(X => X.ID == id);
        }
        public Contract GetContractById(int id)
        {
            var name = CollectionNames.Contracts;
            var entety = GetEntityById(id, name);
            if (entety != null)
                return ((Contract)entety);
            return null;
        }

        public Employee GetEmployeeById(int id)
        {
            var name = CollectionNames.Employees;
            var entety = GetEntityById(id, name);
            if (entety != null)
                return ((Employee)entety);
            return null;

        }
        public Employer GetEmployerById(int id)
        {

            var name = CollectionNames.Employers;
            var entety = GetEntityById(id, name);
            if (entety != null)
                return ((Employer)entety);
            return null;
        }
        public Specialization GetSpecializationById(int id)
        {
            var name = CollectionNames.Specializations;
            var entety = GetEntityById(id, name);
            if (entety != null)
                return ((Specialization)entety);
            return null;


        }
        public object GetobjectById(object obj)
        {
            if (obj is Specialization)
            {
                Specialization specialization = (Specialization)obj;
                return (object)(DataSource.Specializations.FirstOrDefault(s => s.ID == specialization.ID));
            }
            else if (obj is Contract)
            {
                Contract contract = (Contract)obj;
                return (object)(DataSource.Contracts.FirstOrDefault(s => s.ID == contract.ID));
            }
            else if (obj is Employee)
            {
                Employee employee = (Employee)obj;
                return (object)(DataSource.Employees.FirstOrDefault(s => s.ID == employee.ID));
            }
            if (obj is Employer)
            {
                Employer employer = (Employer)obj;
                return (object)(DataSource.Employers.FirstOrDefault(s => s.ID == employer.ID));
            }
            return null;
        }
        #endregion

        #region Copyes
        private Contract CopyContract(Contract newContract)
        {
            Contract Localcontact = new Contract
            {
                EmployeeID = newContract.EmployeeID,
                EmployerID = newContract.EmployerID,
                ID = newContract.ID,
                EmployeeName = newContract.EmployeeName,
                SallaryBruto = newContract.SallaryBruto,
                Regine = newContract.Regine,
                FromDate = newContract.FromDate,
                ToDate = newContract.ToDate,
                EmployerName = newContract.EmployerName,
                Interview = newContract.Interview,
                Signature = newContract.Signature,
                SallaryNeto = newContract.SallaryNeto,
                NumeHour = newContract.NumeHour
            };
            return Localcontact;
        }
        private Specialization CopySpecialization(Specialization newSpecialization)
        {
            Specialization LocalSpecialization = new Specialization
            {
                Name = newSpecialization.Name,
                ID = newSpecialization.ID,
                Regien = newSpecialization.Regien,
                MaxHourSalary = newSpecialization.MaxHourSalary,
                MinHourSalary = newSpecialization.MinHourSalary
            };
            return LocalSpecialization;
        }
        private Employee CopyEmployee(Employee newEmployee)
        {
            Employee LocalEmployee = new Employee
            {
                ID = newEmployee.ID,
                LastName = newEmployee.LastName,
                FirstName = newEmployee.FirstName,
                Adresses = newEmployee.Adresses,
                Phon = newEmployee.Phon,
                Birthday = newEmployee.Birthday,
                SpecializationID = newEmployee.SpecializationID,
                Military = newEmployee.Military,
                Account = newEmployee.Account,
                Degree = newEmployee.Degree
            };
            return LocalEmployee;
        }
        private Employer CopyEmployer(Employer newEmployer)
        {
            Employer LocalEmployer = new Employer
            {
                ID = newEmployer.ID,
                LastName = newEmployer.LastName,
                FirstName = newEmployer.FirstName,
                Adresses = newEmployer.Adresses,
                Phon = newEmployer.Phon,
                EstablishmentDate = newEmployer.EstablishmentDate,
                IsCompany = newEmployer.IsCompany,
                CompanyName = newEmployer.CompanyName,
            };
            return LocalEmployer;
        }
        #endregion

        #region Exceptions
        private void ExceptionsOfContract(Contract newContract)
        {
            /* if (newContract.Regine.MaxHourSalary < newContract.SallaryBruto || newContract.Regine.MinHourSalary > newContract.SallaryBruto)
                 throw new Exception("המשכורת לא בטווח של תחום ההתמחות");*/
            if (DataSource.Employees.FirstOrDefault(s => s.ID == newContract.EmployeeID) == null)
                throw new Exception("אין כזה עובד במאגר של החברה");
            if (DataSource.Employers.FirstOrDefault(s => s.ID == newContract.EmployerID) == null)
                throw new Exception("אין כזה מעביד במאגר של החברה");
        }
        private void ExceptionsOfSpecialization(Specialization newSpecialization)
        {
            if (newSpecialization.MaxHourSalary < newSpecialization.MinHourSalary)
                throw new Exception("המינימום לשעה חייב להיות פחות מהמקסימום");
            if ((newSpecialization.ID >= 100000000 || newSpecialization.ID < 10000000) && newSpecialization.ID != 0)
                throw new Exception("צריך מספר של 8 ספרות");
        }
        private void ExceptionsOfEmployee(Employee localEmployee)
        {
            Employee Emplo = (Employee)GetobjectById(localEmployee);
            if (Emplo != null)
                throw new Exception("העובד כבר במאגר");

            var bankArcount = localEmployee?.Account;
            if (!ValidBankAccount(bankArcount))
                throw new Exception("חשבון הבנק לא תקין");
        }

        public bool ValidBankAccount(BankAccount account)
        {
            var list = GetBanksDetails();
            // = list.FirstOrDefault(x => x.NumberAccount == account.NumberAccount);
            return true;
        }
        public bool ValidContract(Contract localContract)
        {
          TimeSpan  t=  localContract.FromDate-localContract.ToDate;
            if (t.Days < 0)
                return false;
            return true;
        }
        private void ExceptionsOfEmployer(object localEmployee)
        {
            Employer Emplo = (Employer)GetobjectById(localEmployee);
           /* if (Emplo != null)
                throw new Exception("Student with the same id already exists...");*/
        }
        #endregion
    }
}

