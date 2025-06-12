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
            //report report = new report();
            dhl dhl = new dhl();
            malshinonOptions malshinonOptions = new malshinonOptions();
            persons person = new persons()
            {
                firstName = "firstName",
                lastName = "lastName",
                secretCode = "secretCode",
                type = type.reporter,
                numReports = 5,
                numMentions = 8,
            };

            Console.WriteLine("enter your choice");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    malshinonOptions.InsertNewPerson(dhl,person);
                    break;
                case 2:
                    malshinonOptions.GetPersonByName( malshinonOptions.enterReport()[0], dhl, person);
                    break;
                case 3:
                    //malshinonOptions
                    break;
            }
        }
    }
}
