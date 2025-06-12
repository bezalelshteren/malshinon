using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    public class malshinonOptions
    {
        public string[] enterReport()
        {
            Console.WriteLine("Enter the name of the target and report separated by a semicolon");
            string[] allInfo = Console.ReadLine().Split(';');
            return allInfo;
        }

        public void GetPersonByName(string name,dhl dhl,persons persons)
        {
            string[] allName = name.Split(' ');
            string firstName = allName[0];
            string lastName = allName[1];
            bool isExist =  dhl.checkIfPersonExist(name,dhl.connactionToDatabase(dhl.strcon));
            if (isExist)
            {
                dhl.getPersonFromSql(name, dhl.connactionToDatabase(dhl.strcon),persons);
            }
            else if(isExist == false)
            {
                persons persons1 = new persons(firstName,lastName,createSecretCode(name));
                this.InsertNewPerson(dhl, persons1);
            }
        }


        public void GetPersonBySecretCode()
        {

        }
        public void InsertNewPerson(dhl dhl,persons persons) 
        {
            string name = this.enterReport()[0];
            if (dhl.checkIfPersonExist(name, dhl.connactionToDatabase(dhl.strcon)))
                {
                Console.WriteLine("is olredy exist do you wontto get heim !");
                }
            else if(dhl.checkIfPersonExist(name, dhl.connactionToDatabase(dhl.strcon))== false)
            {
                dhl.insertANewPerson(persons, dhl.connactionToDatabase(dhl.strcon));
            }

        }
        public void InsertIntelReport()
        {

        }
        public void UpdateReportCount() 
        {
            
        }

        public string createSecretCode(string name)
        {
            string secret = "";
            foreach (char c in name)
            {
                char d = (char)(219 - c);
                secret += d;
            }
            return secret;
        }

        public void UpdateMentionCount()
        {

        }
        public void GetReporterStats()
        {

        }
        public void GetTargetStats() { }
        public void CreateAlert() { }
        public void GetAlerts() { }
    }
}
