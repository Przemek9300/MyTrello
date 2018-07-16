using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using trelloApi.Context;
using trelloApi.Services;
using trelloApi.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace trelloApi
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
            services.AddAutoMapper();
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()) ;;
            services.AddTransient<IUserService, UserSerivce>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPasswordService, PasswordService>();
                  services.AddSwaggerGen(c =>  
      {  
          c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });  
      });  
            services.AddMediatR();
            services.AddTransient<ClaimsPrincipal>();
            services.AddDbContext<YettiContext>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseCors(builder =>
                    builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
                app.UseDeveloperExceptionPage();
                app.UseAuthentication();


            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>  
      {  
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  
      });  
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
