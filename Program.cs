using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OOP.Context;
using OOP.Contracts;
using OOP.Interfaces;
using OOP.Logger;
using OOP.Provides;
using OOP.Services;
using System.Data;

namespace OOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;
            var connectionEF = "Host=localhost;Port=8000;Database=postgres;Username=admin;Password=admin";
            var connectionDapper = "User ID=admin;Password=admin;Host=localhost;Port=8000;Database=postgres;";

            services.AddEndpointsApiExplorer();
            builder.Services.AddRazorPages();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddSingleton<IMyLogger, MyLogger>();
            builder.Services.AddTransient<IUserProvider, UserProvider>(services => 
                new UserProvider(services.GetRequiredService<MainContext>(), connectionEF)
            );
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddScoped<IDbConnection, NpgsqlConnection>(_ =>
                new NpgsqlConnection(connectionDapper)
            );
            builder.Services.AddTransient<IUserProviderDapper, UserProviderDapper>();
            builder.Services.AddScoped<MainContext>(_ =>
                new MainContext(connectionEF)
            );

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}