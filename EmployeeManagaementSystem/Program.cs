using EmployeeManagaementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeManagaementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddAuthorization();

            builder.Services.AddControllers();
                
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            builder.Services.AddDbContext<EmsContext>(options 
                => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<EmsContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            
            
           
            app.MapControllers();

            //app.MapControllerRoute(name: "blog",
            //    pattern: "blog/{*article}",
            //    defaults: new { controller = "Blog", action = "Article" });
            //app.MapControllerRoute(name: "default",
            //   pattern: "{controller=Employee}/{action=Index}/{id?}");

            app.Run();
        }
    }
}