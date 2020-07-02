using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using try_graphql_example.Adapter;
using try_graphql_example.Adapter.ThingsAdapter;
using try_graphql_example.Schema.Things;

namespace try_graphql_example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ThingBusinessAdapter, CacheThingAdapter>();

            services.AddGraphQL(SchemaBuilder.New()
                .AddQueryType(d => d.Name("Query"))
                .AddType<ThingQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddType<ThingMutation>()
                .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
               .UseRouting()
               .UseGraphQL()
               .UseGraphQLHttpPost(new HttpPostMiddlewareOptions { Path = "/graphql" })
               .UseGraphQLHttpGetSchema(new HttpGetSchemaMiddlewareOptions { Path = "/graphql/schema" })
               .UseVoyager();
            app.UsePlayground();
        }
    }
}
