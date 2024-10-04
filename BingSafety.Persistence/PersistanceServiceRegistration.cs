using BingSafety.Persistence.Repositories;
using BingSafety.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BingSafety.Persistence {
    public static class PersistanceServiceRegistration {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
            var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDbConnectionString"));
            services.AddDbContext<BingSafetyDbContext>(options => {
                options.UseMongoDB(mongoClient, configuration.GetSection("DatabaseName")["MongoDB"]);   
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IEmergencyEventRepository, EmergencyEventRepository>();
            services.AddScoped<IEventStatusRepository, EventStatusRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ISoundRecordingRepository, SoundRecordingRepository>();
            services.AddScoped<IVideoRecordingRepository, VideoRecordingRepository>();

            return services;
        }
    }
}
