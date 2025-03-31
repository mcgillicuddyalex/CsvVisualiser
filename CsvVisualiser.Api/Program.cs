
using CsvVisualiser.Common.Interfaces;
using CsvVisualiser.Common.Models;
using CsvVisualiser.Service;

namespace CsvVisualiser.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => {
                options.AddPolicy("AllowWebsite", policy => {
                    policy.WithOrigins("https://localhost:50323")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddSingleton<ICsvExtraction<Sales>, CsvExtraction<Sales>>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("AllowWebsite");

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
