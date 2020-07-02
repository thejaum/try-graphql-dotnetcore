using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try_graphql_example.Schema.Things;

namespace try_graphql_example.Adapter.ThingsAdapter
{
    public interface ThingBusinessAdapter
    {
        public ThingType AddThing(ThingType thingType);
        public List<ThingType> GetThingList();
    }
}
