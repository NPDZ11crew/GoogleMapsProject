
using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Core;
using GoogleMaps_FinalProjectAspApi.DAL;
using GoogleMaps_FinalProjectAspApi.DAL.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http.Headers;

namespace GoogleMaps_FinalProjectAspApi
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

            //builder.Services.AddHttpClient(client =>
            //{
            //    client.BaseAddress = new Uri("https://places.googleapis.com/v1");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //});
            builder.Services.AddScoped<IPlaceService, PlaceService>();
            builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
            builder.Services.AddScoped<IGoogleMapsService, GoogleMapsService>();
            builder.Services.AddScoped<IGeocodingService, GeocodingService>();
            builder.Services.AddScoped<IPlaceDetailsRepository, PlaceDetailsRepository>();
            builder.Services.AddScoped<IPlaceDetailsService, PlaceDetailsService>();
            builder.Services.AddHttpClient();
            builder.Services.AddDbContext<GMDbContext>(options =>
                                            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
