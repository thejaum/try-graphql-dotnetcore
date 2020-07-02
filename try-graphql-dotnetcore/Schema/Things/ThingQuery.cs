using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try_graphql_example.Adapter.ThingsAdapter;

namespace try_graphql_example.Schema.Things
{
    [ExtendObjectType(Name = "Query")]
    public class ThingQuery
    {
        public List<ThingType> getThingList(
            [Service] ThingBusinessAdapter thingBusinessAdapter) {
            try
            {
                return thingBusinessAdapter.GetThingList();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw new QueryException(message: ex.Message);
            }

        }
    }
}
