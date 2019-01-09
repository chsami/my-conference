using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceApi.Migrations;
using ConferenceApi.Models;
using ConferenceApi.Mutations;
using ConferenceApi.Queries;
using ConferenceApi.Schemas;
using ConferenceApi.Store;
using ConferenceApi.Types;
using GraphiQl;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConferenceApi
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
            services.AddMvc();
            services.AddDbContext<ConferenceContext>(options =>
                options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

            //GRAPHQL STUFF
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();

            services.AddScoped<ConferenceQuery>();
            services.AddScoped<ConferenceMutation>();
            services.AddScoped<ISchema, ConferenceSchema>();

            services.AddScoped<ConferenceType>();
            services.AddScoped<ConferenceInputType>();
            services.AddScoped<CategoryEnumType>();
            services.AddScoped<LocationType>();
            services.AddScoped<AddressType>();




            //DATA LAYER
            services.AddScoped<IDatastore, DataStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            new ApplicationDatabaseInitializer().SeedAsync(app).GetAwaiter();

            app.UseMvc();

            app.UseGraphiQl();

        }
    }
}
