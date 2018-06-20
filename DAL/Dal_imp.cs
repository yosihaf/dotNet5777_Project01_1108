using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DS;


namespace DAL
{
     
    public class Dal_imp : IDAL
    {
          Random r = new Random();
        public void addContract(Contract newContract)
        {
           
           
                do
                {
                    newContract.ID = AddId();
                } while (DataSource.contract.Find(x => x.ID == newContract.ID) != null);
           
            DataSource.contract.Add(newContract);
        }

public void addSpecialization(Specialization newSpecialization)
        {
            do
            {
                newSpecialization.ID = AddId();
            } while (DataSource.specialization.Find(x => x.ID == newSpecialization.ID) != null);
            DataSource.specialization.Add(newSpecialization);
        }

        public void addEmployee(Employee newEmployee)
        {

            TestAndAdd(newEmployee);
        }

        public void addEmployer(Employer newEmployer)
        {
            TestAndAdd(newEmployer);
        }



        public void removeContract(Contract oldContract)
        {

            foreach (Contract element in DataSource.contract)
            {
                if (element == oldContract)
                    DataSource.contract.Remove(oldContract);

            }
            throw new NotImplementedException();
        }

        public void removeEmployee(Employee oldEmployee)
        {
            foreach (Employee element in DataSource.employee)
            {
                if (element == oldEmployee)
                    DataSource.employee.Remove(oldEmployee);
            }
            throw new NotImplementedException();
        }

        public void removeEmployer(Employer oldEmployer)
        {
            foreach (Employer element in DataSource.employer)
            {
                if (element == oldEmployer)
                    DataSource.employer.Remove(oldEmployer);
            }
            throw new NotImplementedException();
        }

        public void removeSpecialization(Specialization oldSpecialization)
        {
            foreach (Specialization element in DataSource.specialization)
            {
                if (element == oldSpecialization)
                    DataSource.specialization.Remove(oldSpecialization);
            }
            throw new NotImplementedException();
        }

        public List<BankAccount> returnBankAccount()
        {
            throw new NotImplementedException();
        }

        public List<Contract> returnContract()
        {
            return DataSource.contract;
        }

        public List<Employee> returnEmployee()
        {
            return DataSource.employee;
        }

        public List<Employer> returnEmployer()
        {
            return DataSource.employer;
        }

        public List<Specialization> returnSpecialization()
        {
          return DataSource.specialization; 
        }

        public void updatinContract(Contract newC)
        {
            Contract value = DataSource.contract.Find(x => x.ID == newC.ID);
            if (value != null)
            {
                DataSource.contract.Remove(value);
                DataSource.contract.Add(newC);
            }
            else
                throw new NotImplementedException();
        }

        public void updatinEmployee(Employee newE)
        {
            Employee value = DataSource.employee.Find(x => x.ID == newE.ID);
            if (value != null)
            {
                DataSource.employee.Remove(value);
                DataSource.employee.Add(newE);
            }
            else
                throw new NotImplementedException();
        }

        public void updatinEmployer(Employer newE)
        {
            Employer value = DataSource.employer.Find(x => x.ID == newE.ID);
            if (value != null)
            {
                DataSource.employer.Remove(value);
                DataSource.employer.Add(newE);
            }
            else
                throw new NotImplementedException();
        }

        public void updatinSpecialization(Specialization newSp)
        {
            Specialization value = DataSource.specialization.Find(x => x.ID == newSp.ID);
            if (value != null)
            {
                DataSource.specialization.Remove(value);
                DataSource.specialization.Add(newSp);
            }
            else
                throw new NotImplementedException();
        }

        public   void TestAndAdd (object obj)
        {
            Employee newEmployee;
            Employer newEmployer;
            if (obj is Employee)
            {
                newEmployee = (Employee)obj;

                do
                {
                     if (newEmployee.ID == 0)
                    newEmployee.ID = AddId();
                } while (DataSource.employee.Find(x => x.ID == newEmployee.ID)!=null);
                Employee value = DataSource.employee.Find(x => x.ID == newEmployee.ID);

                if (value == null)
                    DataSource.employee.Add(newEmployee);
                else
                    throw new NotImplementedException();
            }
            else if (obj is Employer)
            {
                newEmployer = (Employer)obj;
                do
                {
                    if (newEmployer.ID == 0)
                        newEmployer.ID = AddId();
                } while (DataSource.employer.Find(x => x.ID == newEmployer.ID) != null);
                Employer value = DataSource.employer.Find(x => x.ID == newEmployer.ID);

                if (value == null)
                    DataSource.employer.Add(newEmployer);
                else
                    throw new NotImplementedException();
            }
        }
        public int AddId()
        {
           int ID = r.Next(10000000,99999999);
            return ID;
        }
    }
}

