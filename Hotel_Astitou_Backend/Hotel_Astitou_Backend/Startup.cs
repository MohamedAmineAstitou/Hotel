using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Services;
using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Persistence.Repositories;
using Hotel_Astitou_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MantaxHotel.Infrastructure;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;
using Hotel_Astitou_Backend.Notify;

namespace Hotel_Astitou_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
            }));

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();

            services.AddSignalR();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IApartmentService, ApartmentService>();

            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ILodgerService, LodgerService>();

            services.AddScoped<ILodgerRepository, LodgerRepository>();
            services.AddScoped<IGuarantorService, GuarantorService>();
            services.AddScoped<IGuarantorRepository, GuarantorRepository>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddDbContext<HotelAstitouContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HotelAstitou")));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var userService = context
                                .HttpContext.RequestServices.GetRequiredService<IUserService>();
                            var userId = int.Parse(context.Principal.Identity.Name);
                            var user = await userService.FindByIdAsync(userId);
                            if (user == null)
                                context.Fail("Unauthorized");
                            context.Success();
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(JWTProvider.SecretKeyBytes),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Astitou.API",
                    Version = "v0.3",
                    Description = "ASTITOU.API",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed",
                        Email = @"""mohamed.astitou@helb-prigogine.be;"""
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache license 2.0",
                        Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseCors("CorsPolicy");

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel_Astitou_Backend"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notification_hub");
            });
        }
    }
}
