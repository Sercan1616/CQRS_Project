using CQRS_Project.CQRS.Handlers;
using CQRS_Project.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRS_Project
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=CQRS_Test_DB; integrated security=true;");
            });



            services.AddMediatR(typeof(Startup));

            /// MEDIATR DESING KULLANMAZSAK BU ÞEKÝLDE KULLANMAMIZ GEREKÝYOR
            //services.AddScoped<GetStudentByIdQueryHandler>();
            //services.AddScoped<GetAllStudentQueryHandler>();
            //services.AddScoped<CreateStudentCommandHandler>();
            //services.AddScoped<RemoveStudentCommandHandler>();
            //services.AddScoped<UpdateStudentCommandHandler>();

            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
