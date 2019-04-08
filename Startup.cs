using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarkIndustries.Data;
using StarkIndustries.Data.DbModels;
using StarkIndustries.Domain.Agents;
using StarkIndustries.Domain.Customers;

namespace Stark_Industries
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
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
            // Register the Swagger services
            services.AddSwaggerDocument();

            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUi3();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var context = serviceProvider.GetService<ApiContext>();
            AddSeedData(context);

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void AddSeedData(ApiContext context)
        {
            var customerJson = File.ReadAllText("customers.json");
            var customerList = JsonConvert.DeserializeObject<List<CustomerModel>>(customerJson);

            //hack to convert string array to work with entity
            var newCustomerList = new List<Customer>();
            foreach(var customer in customerList) { 
            
                //create a new tag list to map to new object
                var tagList = new List<Tag>();

                //loops through tags to add to list
                foreach(var tag in customer.Tags)
                {
                    var newTag = new Tag
                    {
                        TagName = tag
                    };
                    tagList.Add(newTag);
                }

                //map idential properties except for new taglist, use above
                var newCustomer = new Customer
                {
                    _id = customer._id,
                    Agent_id = customer.Agent_id,
                    Guid = customer.Guid,
                    IsActive = customer.IsActive,
                    Balance = customer.Balance,
                    Age = customer.Age,
                    EyeColor = customer.EyeColor,
                    Name = new Name
                    {
                        First = customer.Name.First,
                        Last = customer.Name.Last
                    },
                    Company = customer.Company,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    Registered = customer.Registered,
                    Latitude = customer.Latitude,
                    Longitude = customer.Longitude,
                    Tags = tagList
                };

                newCustomerList.Add(newCustomer);
            }
            context.Customers.AddRange(newCustomerList);

            var agentJson = File.ReadAllText("agents.json");
            var agentList = JsonConvert.DeserializeObject<List<Agent>>(agentJson);

            context.Agents.AddRange(agentList);

            context.SaveChanges();
        }
    }
}
