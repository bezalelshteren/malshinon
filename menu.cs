using malshinon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace secrate
{
    public class menu
    {

        public void yourChoice()
        {
            Console.WriteLine("enter your name");
            string name = Console.ReadLine();
            string[] fullName = name.Split(' ');

            malshinonOptions malshinonOptions = new malshinonOptions();
            //string[] fullName =  malshinonOptions.enterReport();
            //string name = fullName.ToString();
            persons pers = new persons(fullName[0], fullName[1],malshinonOptions.createSecretCode(name),"reporter");

            //report report = new report();
            //dhl dhl = new dhl();
            //string[] name2 = malshinonOptions.enterReport();
            //string newName = name2.ToString();
            malshinonOptions.InsertNewPerson(pers,name);
            persons person = new persons();
            

            Console.WriteLine("enter your choice");
            Console.WriteLine("1 is to insert a person, 2 is to get a person 3 to get person by secretCode 4 to insert a report and aperson ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string[] fullName1 = malshinonOptions.enterReport();
                    string name1 = fullName.ToString();
                    persons persons = new persons(fullName1[0], fullName1[1],malshinonOptions.createSecretCode(name1),"target");
                    malshinonOptions.InsertNewPerson(persons,name1);
                    break;
                case 2:
                    malshinonOptions.GetPersonByName(malshinonOptions.enterReport()[0]);
                    break;
                case 3:
                    malshinonOptions.GetPersonBySecretCode(person);
                    break;
                case 4:
                    malshinonOptions.InsertIntelReport();
                    break;
                case 5:
                    malshinonOptions.GetAlerts();
                    break;
            }
        }
    }
}
