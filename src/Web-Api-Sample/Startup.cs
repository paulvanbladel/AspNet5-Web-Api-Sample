using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;
using Web_Api_Sample.Models;

namespace Web_Api_Sample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=WestWind;Trusted_Connection=True;";
            var connection = "Data Source=/repos/Web-Api-Sample/src/Web-Api-Sample/temp2.sqlite";  //in case you want to sqlite !!!
            services
                .AddEntityFramework()
                //.AddInMemoryDatabase()
            //    .AddSqlServer()
                .AddSqlite() //in case you want to sqlite !!!
            //    .AddDbContext<WestWindContext>(options => options.UseSqlServer(connection));
                .AddDbContext<WestWindContext>(options => options.UseSqlite(connection)); //in case you want to sqlite !!!
            //    .AddDbContext<WestWindContext>(options => options.UseInMemoryDatabase(true)); //in case you want to sqlite !!!


            services //no idea want this line can't be added to previous ??
                .AddMvc()
                .AddJsonOptions(options =>
            {
                //elegant handling of circular references
                options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
