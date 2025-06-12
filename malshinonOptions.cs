using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZstdSharp.Unsafe;

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

        public void GetPersonByName( string name)
        {
            List<persons> peoples = new List<persons>();

            string[] allName = name.Split(' ');
            string firstName = allName[0];
            string lastName = allName[1];//xdcfvgbhnjhgvfcvgbhnjk
            string query = "SELECT COUNT(*) FROM people WHERE CONCAT(firstName, ' ', lastName) LIKE @name;";

            bool isExist = checkIfPersonExist(query, new[] { "@name", name }, connactionToDatabase(strcon));
            if (isExist)
            {
                Console.WriteLine("ooooo");
                query = "SELECT * FROM people WHERE CONCAT(firstName, ' ', lastName) LIKE @name;";

                peoples = getPersonFromSql(query, new[] { "@name", "%" + name + "%" }, connactionToDatabase(strcon));
            }
            else if (isExist == false) {
                Console.WriteLine("pppppp");
                Console.WriteLine("to insert enter your type");
                string type = Console.ReadLine();
                persons persons1 = new persons(firstName, lastName, createSecretCode(name), type);
                this.InsertNewPerson(persons1,name);
                Console.WriteLine("aaaaaa");
            }
            foreach(persons p in peoples)
            {
                Console.WriteLine(p);
            }
        }


        public void GetPersonBySecretCode(persons persons)
        {
            Console.WriteLine("enter your secret Code");
            string secretCode = Console.ReadLine();
            List<persons> peoples = new List<persons>();
            string query = "SELECT COUNT(*) FROM people WHERE secretCode LIKE @secretCode;";

            bool isExist = checkIfPersonExist(query, new[] { "@secretCode", secretCode }, connactionToDatabase(strcon));
            if (isExist)
            {
                Console.WriteLine("ooooo");
                query = "SELECT * FROM people WHERE secretCode LIKE @secretCode;";

                peoples = getPersonFromSql(query, new[] { "@secretCode", "%" + secretCode + "%" }, connactionToDatabase(strcon));
            }
            else if (isExist == false)
            {
                Console.WriteLine("this code name isn't exist");
            }
            foreach (persons p in peoples)
            {
                Console.WriteLine(p);
            }
        }

        

        public void InsertNewPerson(persons persons,string name) 
        {
            string query = "SELECT COUNT(*) FROM people WHERE CONCAT(firstName, ' ', lastName) LIKE @name;";
            //string name = this.enterReport()[0];
            if (checkIfPersonExist(query, new[] { "@name",  "%" + name + "%" }, connactionToDatabase(strcon)))
                {
                Console.WriteLine("is olredy exist do you wontto get heim !");
                }
            else if(checkIfPersonExist(query, new[] { "@name",  "%" + name + "%" }, connactionToDatabase(strcon))== false)
            {
                Console.WriteLine("ssss");
                query = "INSERT INTO people(firstName, lastName, secretCode, type, numReports, numMentions) VALUES(@firstName, @lastName, @secretCode, @type, @numReports, @numMentions);";
                insertANewPerson(query,persons, connactionToDatabase(strcon));
            }

        }
        public void InsertIntelReport(report report )
        {
            string targetId = enterReport()[0];
            string reports = enterReport()[1];
            string query = "INSERT INTO intelreports(text) VALUES(@text);";
            report report1 = report(reports,targetId);
            insertareport(query,report,connactionToDatabase(strcon));
           

        }
        public void UpdateReportCount() 
        {
            string queryToPeople = "UPDATE people SET numReports = numReports + 1 WHERE secretCode = @secretCode;";
            updatePerson(queryToPeople, new[] { "@numReports", "numReports" }, connactionToDatabase(strcon));
        }

        

        public void UpdateMentionCount()
        {
            string query = "UPDATE people SET numMentions = numMentions + 1 WHERE secretCode = @secretCode;";
            updatePerson(query, new[] { "@numMentions", "numMentions" }, connactionToDatabase(strcon));
        }

        public void updateForiginKey()
        {
            string query = "SELECT id FROM people WHERE CONCAT(firstName, ' ', lastName) = @name;";
            updatePerson(query, new[] { "@", "numMentions" }, connactionToDatabase(strcon));
        }

        public static string createSecretCode(string name)
        {
            string secret = "";
            foreach (char c in name)
            {
                char d = (char)(219 - c);
                secret += d;
            }
            return secret;
        }

        public void GetReporterStats()
        {

        }
        public void GetTargetStats()
        {

        }
        public void CreateAlert() { }
        public void GetAlerts() { }
    }
}
