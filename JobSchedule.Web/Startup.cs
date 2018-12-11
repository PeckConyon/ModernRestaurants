using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using JobSchedule.Context.Context;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Context.Repositories.BaseRepository;
using JobSchedule.Context.Repositories.BaseRepository.AwardRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRoleRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyRepo;
using JobSchedule.Context.Repositories.BaseRepository.GoalRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobCategoryRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobTemplateRepo;
using JobSchedule.Context.Repositories.BaseRepository.MemberGoalRepo;
using JobSchedule.Context.Repositories.BaseRepository.MemberJobRepo;

using JobSchedule.Service.AwardService;
using JobSchedule.Service.FamilyMemberRoleService;
using JobSchedule.Service.FamilyMemberService;
using JobSchedule.Service.FamilyService;
using JobSchedule.Service.GoalService;
using JobSchedule.Service.JobCategoryService;
using JobSchedule.Service.JobService;
using JobSchedule.Service.JobTemplateService;
using JobSchedule.Service.MemberJobService;
using JobSchedule.Service.MemberGoalService;
using System;

namespace JobSchedule.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<JobDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IAwardRepository, AwardRepository>();
            services.AddTransient<IFamilyMemberRepository, FamilyMemberRepository>();
            services.AddTransient<IFamilyMemberRoleRepository, FamilyMemberRoleRepository>();
            services.AddTransient<IFamilyRepository, FamilyRepository>();
            services.AddTransient<IGoalRepository, GoalRepository>();
            services.AddTransient<IJobCategoryRepository, JobCategoryRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<IJobTemplateRepository, JobTemplateRepository>();
            services.AddTransient<IMemberJobRepository, MemberJobRepository>();
            services.AddTransient<IMemberGoalRepository, MemberGoalRepository>();

            services.AddTransient<IAwardService, AwardService>();
            services.AddTransient<IFamilyMemberRoleSerive, FamilyMemberRoleSerive>();
            services.AddTransient<IFamilyMemberSerive, FamilyMemberSerive>();
            services.AddTransient<IFamilySerive, FamilySerive>();
            services.AddTransient<IGoalSerive, GoalSerive>();
            services.AddTransient<IJobCategoryService, JobCategoryService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IJobTemplateService, JobTemplateService>();
            services.AddTransient<IMemberJobService, MemberJobService>();
            services.AddTransient<IMemberGoalService, MemberGoalService>();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

           
        }
    }
}
