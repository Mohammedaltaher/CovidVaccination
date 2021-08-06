using AutoMapper;
using CovidVaccination.Interfaces;
using CovidVaccination.Map;
using CovidVaccination.Model;
using CovidVaccination.Repositories;
using CovidVaccination.UnitOfWorks;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Threading.Tasks;
using CovidVaccination.ViewModel;

namespace CovidVaccination
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

            services.AddControllers();

            #region Database
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IVaccinationRepository, VaccinationRepository>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Auto Mapper Configurations  
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new PatientProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Fluent Validation
            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<PatientRequest>, PatientRequestValidator>();
            #endregion
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CovidVaccination", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CovidVaccination v1"));
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