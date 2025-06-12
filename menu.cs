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
            persons pers = new persons(fullName[0], fullName[1],malshinonOptions.createSecretCode(name),"reporter");
            
            malshinonOptions.InsertNewPerson(pers,name);
            persons person = new persons();
            all.PrintMenu();
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
                case 6:
                    malshinonOptions.UpdateMentionCount();
                    break;
            }
        }
    }
}
