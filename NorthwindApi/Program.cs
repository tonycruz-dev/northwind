
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.EntityDataModels;
using NorthwindApi.Interfaces;
using NorthwindApi.Repository_;
using System.Text.Json.Serialization;

namespace NorthwindApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            })
            .AddOData(opt => opt.AddRouteComponents(
                "odata",
             new NorthwindDataModel()
            .GetEntityDataModel())
            .Filter()
            .Expand()
            .Select()
            .OrderBy()
            .Count()
            .SetMaxTop(1000)
            .SkipToken());
            builder.Services.AddDbContext<NorthwindContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddScoped<ISalesCategory, SalesCategory>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
