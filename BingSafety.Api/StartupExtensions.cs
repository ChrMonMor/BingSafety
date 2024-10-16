﻿using BingSafety.Application;
using BingSafety.Persistence;

namespace BingSafety.Api {
    public static class StartupExtensions {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder) {
            // service registrations herer!
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddCors(options => 
            options.AddPolicy(
                "open",
                policy => policy.WithOrigins([builder.Configuration ["ApiUrl"] ?? "https://localhost:7077",
                   builder.Configuration["MauiUrl"] ?? "https://localhost:7088"])
                .AllowAnyMethod()
                .SetIsOriginAllowed(pol => true)
                .AllowAnyHeader()
                .AllowCredentials()
                ));

            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipline(this WebApplication app) { 
            // middelware here!
            app.UseCors("open");
            if (app.Environment.IsDevelopment()) { 
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }
    }
}
