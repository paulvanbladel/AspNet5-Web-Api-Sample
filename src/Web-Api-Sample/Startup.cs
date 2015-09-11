using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;
using Web_Api_Sample.Models;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
namespace Web_Api_Sample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appEnv = CallContextServiceLocator.Locator.ServiceProvider.GetRequiredService<IApplicationEnvironment>();
            var databaseName = "database.sqlite3";
            var connection = $"Data Source={ appEnv.ApplicationBasePath}/{databaseName}";

            services
                .AddEntityFramework()
                .AddSqlite()
            
                .AddDbContext<WestWindContext>(options => options.UseSqlite(connection)); 
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
