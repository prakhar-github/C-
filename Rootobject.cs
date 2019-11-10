using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Rootobject
    {
        public Passage[] passages { get; set; }
        public int query_id { get; set; }
        public string[] answers { get; set; }
        public string query_type { get; set; }
        public string query { get; set; }
    }
}
