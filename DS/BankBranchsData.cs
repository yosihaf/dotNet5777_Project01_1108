using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace DS
{
    public class BankData
    {
        XElement BankBranchsXml;
        public BankData(XElement xml)
        {
            BankBranchsXml = xml;
        }
        public BankBranch GetBankBranch(int BankNumber, int BranchNumber) {
            var list = from b in BankBranchsXml.Elements()
                       where b.Element("קוד_בנק").FirstNode.ToString() == BankNumber.ToString() &&
                             b.Element("קוד_סניף").FirstNode.ToString() == BranchNumber.ToString()
                       select ElementToBankBranch(b);



            return list.FirstOrDefault();
        }
        private BankBranch ElementToBankBranch(XElement e) {
            return new BankBranch()
            {
                BankName = e.Element("שם_בנק").FirstNode.ToString(),
                NumberBank = Convert.ToInt32(e.Element("קוד_בנק").FirstNode.ToString()),
                NumberBranch = Convert.ToInt32(e.Element("קוד_סניף").FirstNode.ToString()),
            };

        }
        public IEnumerable<dynamic> GetBanksDetails() {
            var l = (from b in BankBranchsXml.Elements()
                   select new ItemBaseDeatils{ Value = Convert.ToInt32(b.Element("קוד_בנק").FirstNode.ToString()), Name =b.Element("שם_בנק").FirstNode.ToString() }).Distinct().ToList(); ;
            //var a =  l.DistinctBy(note => note.ID).Distinct();
            return l;
        }
    }
}
