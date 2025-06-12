using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    public class report
    {
        public int id { get; }
        public string text { get; }

        public int reporterId { get; }
        public int targetId { get; }

        public DateTime Time;
       // public report() { }
        public report(string text, int reporterId, int targetId)
        {
            this.text = text;
            this.reporterId = reporterId;
            this.targetId = targetId;
        }
    }
}
