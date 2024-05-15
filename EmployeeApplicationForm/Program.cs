
using Asp.Versioning;
using EmplpyeeApplicationForm.Infrastructure;
using EmplpyeeApplicationForm.Infrastructure.Interfaces;
using EmplpyeeApplicationForm.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;


namespace EmployeeApplicationForm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();

            builder.Services.AddDbContextFactory<AppDbContext>(optionsBuilder =>
                 optionsBuilder
                   .UseCosmos(
                     connectionString: builder.Configuration["CosmosDbConnectionString"],
            databaseName: "CosmosDB"));

           

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
