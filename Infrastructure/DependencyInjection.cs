﻿using Application.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Jobs;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DbConn")));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<JobFactory>();
            services.AddScoped<SendExchangeRateInfoJob>();
        }
    }
}
