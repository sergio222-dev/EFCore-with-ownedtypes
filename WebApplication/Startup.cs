using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Core;
using WebApplication.Core.Entity;

namespace WebApplication
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
            services.AddRazorPages();

            var builder = new SqlConnectionStringBuilder();

            builder.DataSource = "localhost,1433";
            builder.InitialCatalog = "master";
            builder.UserID = "sa";
            builder.Password = "Sqlpassword222";

            var connectionString = builder.ConnectionString;

            services.AddTransient((s => new WikiContext(connectionString)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WikiContext context)
        {

            var id = new CustomerId(Guid.NewGuid());
            var name = new CustomerName("SomeGuy");
            var studioId = new StudioId(Guid.NewGuid());

            var newCustomer = Customer.Create(id, name, studioId);

            context.Customers.Add(newCustomer);
            context.SaveChanges();

            var results = context.Customers.Select(c => c);
            
            
            foreach (var customer in results)
            {
                Console.WriteLine($"{customer?.Name?.Value}, {customer?.StudioId?.Value}, {customer?.Id?.Value}");
                
            }

            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }
            // else
            // {
            //     app.UseExceptionHandler("/Error");
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //     app.UseHsts();
            // }
            //
            // app.UseHttpsRedirection();
            // app.UseStaticFiles();
            //
            // app.UseRouting();
            //
            // app.UseAuthorization();
            //
            // app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}