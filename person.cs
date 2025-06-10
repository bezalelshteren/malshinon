using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    public enum type
    {
        reporter,
        target,
        both,
        potentialAgent
    }

    public class persons
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string secretCode { get; set; }
        public type type { get; set; }
        public int numReports { get; set; }
        public int numMentions { get; set; }

        public persons() { }

        public persons(string firstName, string lastName, string secretCode, type type, int numReports, int numMentions)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.secretCode = secretCode;
            this.type = type;
            this.numReports = numReports;
            this.numMentions = numMentions;

        }
    }
}
