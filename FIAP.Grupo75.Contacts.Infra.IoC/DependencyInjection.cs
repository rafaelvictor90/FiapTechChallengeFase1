using FIAP.Grupo75.Contacts.Application.Interfaces;
using FIAP.Grupo75.Contacts.Application.Mappings;
using FIAP.Grupo75.Contacts.Application.Services;
using FIAP.Grupo75.Contacts.Domain.Account;
using FIAP.Grupo75.Contacts.Domain.Interfaces;
using FIAP.Grupo75.Contacts.Infra.Data.Context;
using FIAP.Grupo75.Contacts.Infra.Data.Identity;
using FIAP.Grupo75.Contacts.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace FIAP.Grupo75.Contacts.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IDddRepository, DddRepository>();

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IDddService, DddService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
