using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IChatService), typeof(ChatService));
            services.AddScoped(typeof(IGameService), typeof(GameService));
            services.AddScoped(typeof(IPlayerService), typeof(PlayerService));
            services.AddScoped(typeof(IMissionService), typeof(MissionService));
            services.AddScoped(typeof(ISquadService), typeof(SquadService));
            services.AddScoped(typeof(ISquadMemberService), typeof(SquadMemberService));
            services.AddScoped(typeof(ISquadCheckinService), typeof(SquadCheckinService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HumansVsZombies_Backend", Version = "v1" });
            });

            services.AddDbContext<HvZDbContext>(
            opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HumansVsZombies_Backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
