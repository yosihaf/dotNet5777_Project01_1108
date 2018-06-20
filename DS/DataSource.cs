using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DS
{
    public class DataSource
    {
        public const string BASE_URL = "../../../DS/Data/";
        public const string SourceLocationEmployers = BASE_URL + "Employers.xml";
        public const string SourceLocationEmployees = BASE_URL + "Employees.xml";
        public const string SourceLocationContracts = BASE_URL + "Contracts.xml";
        public const string SourceLocationSpecializations = BASE_URL + "Specializations.xml";
        public const string CodeLocation = BASE_URL + "code.xml";
        public const string BabkBranchsDataLocation = BASE_URL + "atm.xml";
        public static int Code;


        public static List<Specialization> Specializations=new List<Specialization>();
        public static List<Employee> Employees = new List<Employee>();
        public static List<Employer> Employers = new List<Employer>();
        public static List<Contract> Contracts = new List<Contract>();
        public static BankData BankData;

        public static void initCode() {
            var path = CodeLocation;
            if (File.Exists(path)) {
                Code = LoadObj<int>(path);
                Code = 10000000;
            }
            else {
                Code = 10000000;
                SaveObj<int>(Code, path);
            }
        }

        public static void SaveCode() {
            var path = CodeLocation;
            SaveObj<int>(Code, path);
        }

        private static XElement LoadXmlElement(string url)
        {
            try
            {
                return XElement.Load(url);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        public static bool InitData(CollectionNames collectionName = CollectionNames.All)
        {
            // init code for ids
            initCode();
            // load bank branchs data
            var ele = LoadXmlElement(BabkBranchsDataLocation);
            BankData = new BankData(ele);
            bool flag = true;
            if (collectionName == CollectionNames.Employees || collectionName == CollectionNames.All)
            {
                var path = SourceLocationEmployees;
                if(File.Exists(path))
                    Employees = LoadObj<List<Employee>>(path);
                else
                    SaveObj<List<Employee>>(Employees, path);
            }
            if (collectionName == CollectionNames.Specializations || collectionName == CollectionNames.All)
            {
                var path = SourceLocationSpecializations;
                if (File.Exists(path))
                    Specializations = LoadObj<List<Specialization>>(path);
                else
                    SaveObj<List<Specialization>>(Specializations, path);
            }
            if (collectionName == CollectionNames.Employers || collectionName == CollectionNames.All)
            {
                var path = SourceLocationEmployers;
                if (File.Exists(path))
                    Employers = LoadObj<List<Employer>>(path);
                else
                    SaveObj<List<Employer>>(Employers, path);

            }
            if (collectionName == CollectionNames.Contracts || collectionName == CollectionNames.All)
            {
                var path = SourceLocationContracts;
                if (File.Exists(path))
                    Contracts = LoadObj<List<Contract>>(path);
                else
                    SaveObj<List<Contract>>(Contracts, path);

            }

            return flag;

        }

        public static bool LoadData(CollectionNames collectionName = CollectionNames.All) {
            bool flag = true;
            if (collectionName == CollectionNames.Employees || collectionName == CollectionNames.All) {
                var path = SourceLocationEmployees;
                Employees = LoadObj<List<Employee>>(path);
            }
            if (collectionName == CollectionNames.Specializations || collectionName == CollectionNames.All)
            {
                var path = SourceLocationSpecializations;
                Specializations = LoadObj<List<Specialization>>(path);
            }
            if (collectionName == CollectionNames.Employers || collectionName == CollectionNames.All)
            {
                var path = SourceLocationEmployers;
                Employers = LoadObj<List<Employer>>(path);
            }
            if (collectionName == CollectionNames.Contracts || collectionName == CollectionNames.All)
            {
                var path = SourceLocationContracts;
                Contracts = LoadObj<List<Contract>>(path);
            }

            return flag;

        }

        public static bool SaveData(CollectionNames collectionName = CollectionNames.All)
        {
            var flag = true;
            if (collectionName == CollectionNames.Employees || collectionName == CollectionNames.All)
            {
                var path = SourceLocationEmployees;
                SaveObj<List<Employee>>(Employees, path);
            }
            if (collectionName == CollectionNames.Specializations || collectionName == CollectionNames.All)
            {
                var path = SourceLocationSpecializations;
                SaveObj<List<Specialization>>(Specializations,path);
            }
            if (collectionName == CollectionNames.Employers || collectionName == CollectionNames.All)
            {
                var path = SourceLocationEmployers;
                SaveObj<List<Employer>>(Employers,path);
            }
            if (collectionName == CollectionNames.Contracts || collectionName == CollectionNames.All)
            {
                var path = SourceLocationContracts;
                SaveObj<List<Contract>>(Contracts, path);
            }

            return flag;

        }
        public static T LoadObj<T>(string path) {
            string xml =LoadXml(path);
            if (string.IsNullOrEmpty(xml))
                return default(T);

            return Deserialize<T>(xml);

        }
        public static bool SaveObj<T>(T value, string path) {

            string xml = string.Empty;
            if (!Serialize<T>(value, ref xml))
                return false;
            CreateXml(xml, path);
            return true;

        }
        public static void CreateXml(string xml, string path) {
             File.WriteAllText(path, xml);
        }

        public static string LoadXml(string path)
        {
            if (!File.Exists(path))
                return null;
            return File.ReadAllText(path);
        }

        public static bool Serialize<T>(T value, ref string serializeXml)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                StringWriter stringWriter = new StringWriter();
                XmlWriter writer = XmlWriter.Create(stringWriter);

                xmlserializer.Serialize(writer, value);

                serializeXml = stringWriter.ToString();

                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
        public static T Deserialize<T>(String xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return returnedXmlClass;
        }
    }
}


