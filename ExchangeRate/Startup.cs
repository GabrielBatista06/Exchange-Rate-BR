using System;
using System.Text;
using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Persistence.Repositories;
using BackEnd.Services;
using ExchangeRate.Domain.IRepositories;
using ExchangeRate.Persistence.Repositories;
using ExchangeRate.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace ExchangeRate
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExchangeRate", Version = "v1" });
            });


            //Mappeo

            //Mappeo
            services.AddAutoMapper(typeof(Startup));

            // Mocks
           services.AddScoped<IObtenerRemesaRepository, Api1Repository>();
           services.AddScoped<IObtenerRemesaRepository, Api2Repository>();
           services.AddScoped<IObtenerRemesaRepository, Api3Repository>();


            //Service
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ObtenerMejorOfertaService>();


            //Repository
            services.AddScoped<ILoginRepository, LoginRepository>();

            //Cors
            services.AddCors(options => options.AddPolicy("AllowWebapp",
                                                builder => builder.AllowAnyOrigin()
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod()));


            //Add Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero

                });

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExchangeRate v1"));
            }

            app.UseCors("AllowWebapp");
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
