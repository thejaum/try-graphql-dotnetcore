using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try_graphql_example.Adapter.ThingsAdapter;
using try_graphql_example.Schema.Things;

namespace try_graphql_example.Adapter
{
    public class CacheThingAdapter : ThingBusinessAdapter
    {
        private IMemoryCache _cache;
        private readonly string listName = "thing_list";

        public CacheThingAdapter(IMemoryCache cache)
        {
            this._cache = cache;
        }

        public ThingType AddThing(ThingType thingType)
        {
            List<ThingType> thingList;
            _cache.TryGetValue(listName, out thingList);
            if (thingList == null)
                thingList = new List<ThingType>();
            thingList.Add(thingType);
            _cache.Set(listName, thingList);
            return thingType;            
        }

        public List<ThingType> GetThingList()
        {
            List<ThingType> thingList;
            _cache.TryGetValue(listName, out thingList);
            if (thingList == null)
                thingList = new List<ThingType>();
            return thingList;
        }
    }
}
