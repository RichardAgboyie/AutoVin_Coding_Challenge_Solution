using AutoVin_Code_Challenge.Core.Features.Transactions.Commands;
using AutoVin_Code_Challenge.Core.Features.Transactions.Interfaces;
using AutoVin_Code_Challenge.Core.Features.Transactions.Queries;
using AutoVin_Code_Challenge.Infrastructure.Contract;
using AutoVin_Code_Challenge.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AutoVin_Code_Challenge
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoVin_Code_Challenge", Version = "v1" });
            });

            services.AddDbContextPool<AppDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("AppConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITransactionCommand, TransactionCommand>();
            services.AddTransient<ITransactionQueries, TransactionQueries>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoVin_Code_Challenge v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
