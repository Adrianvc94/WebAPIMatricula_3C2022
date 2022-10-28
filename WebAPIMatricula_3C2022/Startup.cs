using API.Bll.Colegiatura.Interfaces;
using API.Bll.Error.Interfaces;
using API.Bll.Estudiante.Interfaces;
using API.Bll.Nota.Interfaces;
using API.Dal.Colegiatura;
using API.Dal.Error;
using API.Dal.Estudiante;
using API.Dal.Nota;
using API.Bll.Horario.Interfaces;
using API.Bll.Profesor.Interfaces;
using API.Dal.Error;
using API.Dal.Estudiante;
using API.Dal.Horario;
using API.Dal.Profesor;
using API.Dto.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI;
using WebAPI.Services;
using API.Bll.Curso.Interfaces;
using API.Dal.Curso;

namespace WebAPIMatricula_3C2022
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>
                (Configuration.GetSection("AppSettings").GetSection("ConnectionStrings"));



            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.AddDbContext<WebAPI.Helpers.DataContext>();
            services.Configure<AppSettings>(appSettingsSection);



            #region JWT
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<WebAPI.Services.IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);



                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }



                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    LifetimeValidator = TokenLifetimeValidator.Validate
                };
            });
            #endregion


          
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdEstudiante, AdEstudiante>();
            services.AddScoped<IAdNota, AdNota>();
            services.AddScoped<IAdColegiatura, AdColegiatura>();
            services.AddScoped<IAdCurso, AdCurso>();
            services.AddScoped<IAdHorario, AdHorario>();
            services.AddScoped<IAdProfesor, AdProfesor>();
            services.AddScoped<IAdError, AdError>();



            services.AddControllers();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIMatricula", Version = "v1" });
            });
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIMatricula v1"));



            app.UseHttpsRedirection();



            app.UseRouting();



            app.UseAuthentication();
            //USO DE WEB API CON JWT
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}