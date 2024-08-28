using IT4ProcessSimulator.DataBase;
using IT4ProcessSimulator.Repository;
using IT4ProcessSimulator.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT4ProcessSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Criando conex�o com o banco de dados! #1
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<DbContextIT4ProcessSimulator>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
             );



            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
