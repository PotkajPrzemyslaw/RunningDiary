using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RunningDiary.Core;
using RunningDiary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningDiary
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
            services.AddControllersWithViews();

            services.AddDbContext<RunningDiaryDbContext>(options =>
                options.UseSqlServer(@"Server=localhost;Database=RunningDiaryDatabase;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddTransient<IRunnerRepository, RunnerRepository>(); //mo?na u?ywa? repozytoria
            services.AddTransient<IWorkoutRepository, WorkoutRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();

            services.AddTransient<DtoMapper>();
            services.AddTransient<ViewModelMapper>();
            services.AddTransient<IRunnerManager, RunnerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=About}/{id?}");
            });

            var database = serviceProvider.GetService<RunningDiaryDbContext>();

            database.Database.Migrate();// EnsureCreated
        }
    }
}
