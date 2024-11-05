using FIAP.Grupo75.Contacts.Infra.IoC;
using System.Reflection;
using FIAP.Grupo75.Contacts.Logging;
using FIAP.Grupo75.Contacts.Infra.Data.Identity;
using FIAP.Grupo75.Contacts.Domain.Account;

namespace FIAP.Grupo75.Contacts.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddInfrastructureJWT(Configuration);
            services.AddInfrastructureSwagger();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
                {
                    LogLevel = LogLevel.Information,
                }));
            });

            services.AddScoped<SeedUserRoleInitial>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ISeedUserRoleInitial seedUserRoleInitial)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FIAP.Grupo75.Contacts.API v1"));
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            seedUserRoleInitial.SeedRoles();
            seedUserRoleInitial.SeedUsers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
