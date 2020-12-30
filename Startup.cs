using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using CompanyOwnerWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using CompanyOwnerWebAPI.Services;

namespace CompanyOwnerWebAPI
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
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<ICompanyUserService, CompanyUserService>();

            services.AddScoped<IUserService, UserService>();

            services.AddControllers();

            services.AddDbContext<DataContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("AppDbContext"),
                b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();               
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyOwnerWebAPI V1");
                c.RoutePrefix = string.Empty;
            });  

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
