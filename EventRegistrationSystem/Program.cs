//using EventRegistrationSystem.DBContext; // Ensure you are using the correct namespace for your DBContext
using EventRegistrationSystem.Service; // Ensure to include the namespace for EmailService
using Microsoft.EntityFrameworkCore;
using Mailjet.Client;

namespace EventRegistrationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework Core with SQL Server
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(connectionString));

            // Configure Mailjet
            builder.Services.AddSingleton<MailjetClient>(provider =>
            {
                var configuration = builder.Configuration;
                string apiKey = configuration["Mailjet:ApiKey"];
                string secretKey = configuration["Mailjet:SecretKey"];
                return new MailjetClient(apiKey, secretKey);
            });

            // Register EmailService
            builder.Services.AddScoped<EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
