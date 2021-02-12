using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReservationSys.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Abstract;
using ReservationSys.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ReservationSys.Domain.Interfaces;
using ReservationSys.Domain.Repositories;
using ReservationSys.Domain.UnitOfWork;

namespace ReservationSys.Api
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

            services.AddCors();
            services.AddControllers();


            #region Repositories

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // services.AddTransient(typeof(IGenericRepository<Contact>), typeof(ContactRepository));
            // services.AddTransient(typeof(IGenericRepository<Reservation>), typeof(ReservationRepository));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion


            services.AddDbContext<EFDbContext>(options =>
            {

                options.UseSqlite(
                    Configuration.GetConnectionString("ReservationsContext"),
                    b => b.MigrationsAssembly("ReservationSys.Api"));

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReservationSys.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(
                    options => options.WithOrigins(new string[] { "*" }).AllowAnyMethod().AllowAnyHeader()
                );
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationSys.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
