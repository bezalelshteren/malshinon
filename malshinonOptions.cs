using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    public class malshinonOptions : dhl
    {
        public string[] enterReport()
        {
            Console.WriteLine("Enter the name of the target and report separated by a semicolon");
            string[] allInfo = Console.ReadLine().Split(';');
            return allInfo;
        }

        public void GetPersonByName(string name, persons persons)
        {
            List<persons> peoples = new List<persons>();

            string[] allName = name.Split(' ');
            string firstName = allName[0];
            string lastName = allName[1];//
            string query = "SELECT * FROM people WHERE CONCAT(firstName, ' ', lastName) LIKE @name;";

            bool isExist = checkIfPersonExist(name, connactionToDatabase(strcon));
            if (isExist)
            {
                Console.WriteLine("ooooo");
                peoples = getPersonFromSql(query, new[] { "@name", name }, connactionToDatabase(strcon), persons);
            }
            else if (isExist == false) {
                Console.WriteLine("pppppp");

                persons persons1 = new persons(firstName, lastName, createSecretCode(name));
                this.InsertNewPerson(persons1);
                Console.WriteLine("aaaaaa");
            }

        }


        public void GetPersonBySecretCode()
        {

        }

        

        public void InsertNewPerson(persons persons) 
        {
            string name = this.enterReport()[0];
            if (checkIfPersonExist(name, connactionToDatabase(strcon)))
                {
                Console.WriteLine("is olredy exist do you wontto get heim !");
                }
            else if(checkIfPersonExist(name,connactionToDatabase(strcon))== false)
            {
                Console.WriteLine("ssss");
                insertANewPerson(persons, connactionToDatabase(strcon));
            }

        }
        public void InsertIntelReport()
        {
            string report = enterReport()[1];

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
