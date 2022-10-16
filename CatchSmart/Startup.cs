using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CatchSmart.Core.Models;
using CatchSmart.Db;
using CatchSmart.Core.Services;
using CatchSmart.Core.Validations;
using CatchSmart.Service;

namespace CatchSmart
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatchSmart", Version = "v1" });
            });
            services.AddDbContext<CatchSmartDbContext>(options =>
            {
                options.UseSqlite("Filename=CatchSmart.db");
            });

            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Candidate>, EntityService<Candidate>>();
            services.AddScoped<IEntityService<Company>, EntityService<Company>>();
            services.AddScoped<IEntityService<Positions>, EntityService<Positions>>();
            services.AddScoped<IEntityService<CandidatePositions>, EntityService<CandidatePositions>>();
            services.AddScoped<IEntityService<CompaniesPositions>, EntityService<CompaniesPositions>>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ICandidateValidator, CandidateValidator>();
            services.AddScoped<ICompanyValidator, CompanyValidator>();
            services.AddScoped<ICompanyPositionService, CompanyPositionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatchSmart v1"));
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
