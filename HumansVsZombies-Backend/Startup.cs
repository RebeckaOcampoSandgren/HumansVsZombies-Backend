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
using System.IO;
using System.Linq;
using System.Reflection;
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
            services.AddScoped(typeof(IKillService), typeof(KillService));
            services.AddScoped(typeof(ISquadMemberService), typeof(SquadMemberService));
            services.AddScoped(typeof(ISquadCheckinService), typeof(SquadCheckinService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "HumansVsZombies_Backend", 
                    Version = "v1",
                    Description = "HumansVsZombies is a game where all players start as a human, and an original zombie will be randomly selected. The Original Zombie attacks human players and then humans turn into zombies. In each game there is the possibility to chat and select a squad.",
                    Contact = new OpenApiContact
                    {
                        Name = "Rebecka, Negin, Betiel & Fadi",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/RebeckaOcampoSandgren/HumansVsZombies-Backend")
                    }
                });
                //Set the comments path for the swagger JSON and UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //services.AddDbContext<HvZDbContext>(
            //opt => opt.UseSqlServer(Configuration.GetConnectionString("AzureDb")));
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
