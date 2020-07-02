using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace try_graphql_example.Schema.Things
{

    public class ThingType
    {
        public string type { get; set; }
        public string name { get; set; }
        public string place { get; set; }
        public DateTime time { get; set; }
        public string notification { get; set; }
    }
}
