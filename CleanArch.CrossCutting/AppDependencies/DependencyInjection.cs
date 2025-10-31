﻿using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System.Data;

namespace CleanArch.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => 
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new MySqlConnection(mySqlConnection);
                connection.Open();
                return connection;
            });

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

            return services;
        }
    }
}
