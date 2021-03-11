using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongViec
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
            var connectionString = Configuration[":CONNECTION_STRING"];
            services.AddDbContext<DataContext>(options =>
options.UseSqlServer("Data Source=DESKTOP-0V8GOPQ;Initial Catalog=CongViecDB;Persist Security Info=True;User ID=sa;Password=sapassword"));
            services.AddDbContext<DataContext>(opts => opts.UseSqlServer(connectionString), ServiceLifetime.Transient);
            _ = services.AddDbContext<DataContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:DataContext"]));
            

            //DI
            services.AddTransient<DuAnDAL ,DuAnDAL>();
            services.AddTransient<CongViecDAL ,CongViecDAL>();
            services.AddTransient<NguoiDungDAL ,NguoiDungDAL>();
            services.AddTransient<NguoiSuDungDAL ,NguoiSuDungDAL>();

            services.AddTransient<DuAnBO ,DuAnBO>();
            services.AddTransient<CongViecBO ,CongViecBO>();
            services.AddTransient<NguoiDungBO ,NguoiDungBO>();
            services.AddTransient<NguoiSuDungBO ,NguoiSuDungBO>();
           
            services.AddControllers();


            //identity
            services.AddIdentity<NguoiSuDung, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


            //Authentication  
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })


            //Jwt Bearer  
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Authentication
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
