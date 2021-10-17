using BMW_ONBOARDING_SYSTEM.Helpers;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.Repositories;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM
{
    public class Startup
    {

        private IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // just added for for using .include
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            // Configure the database
            services.AddDbContext<INF370DBContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ILessonOutcome, LessonOutcomeRepository>();
            services.AddScoped<IAchievementTypeRepository, AchievementTypeRepository>();
            //services.AddScoped<ICertificateTypeRepository, CertificateTypeRepository>();
            services.AddScoped<ILessonContentRepository, lessonContentRepository>();
            services.AddScoped<IBadgeRepository, BadgeRepository>();
            services.AddScoped<IEmployeeCalendarRepository, EmployeeCalendarRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IOnboarderRepository, OnboarderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentQueryRepository, EquipmentQueryRepository>();
            services.AddScoped<IFaqRepository, FaqRepository>();
            //services.AddScoped<IActiveLogRepository, ActiveLogRepository>();
            services.AddScoped<IAuditLogRepository, AuditRepository>();
            //services.AddScoped<IWarrantyRepository, WarrantyRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();

            services.AddScoped<ISuburbRepository, SuburbRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IEquipementTypeRepository, EquipmentTypeRepository>();
            services.AddScoped<IEquipmentBrandRepository, EquipmentBrandRepository>();
            services.AddScoped<IOTPRepository, OTPRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IOption, OptionRepository>();
            services.AddCors();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

           // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetUserByIdAsync(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                    //RoleClaimType = true
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
            //configured for deployment
            // app.UseHsts();
            // app.UseHttpsRedirection();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
