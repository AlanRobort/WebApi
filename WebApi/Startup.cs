using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        //public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public  IConfiguration Configuration { get; }

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ProductContext>(
            //    options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //);

            services.AddDbContext<ProductContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); 

                }
            );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //注册LocalMailService，每次请求（不是指HTTP request）都会创建一个实例
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {

            loggerFactory.AddNLog();
                 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                //UseExceptionHandler是可以传参数的, 但暂时先这样,
                //我们在app.Run方法里抛一个异常, 然后运行程序, 在Chrome里按F12
                //就会发现有一个(或若干个, 多少次请求, 就有多少个错误)500错误.
                app.UseExceptionHandler();
            }
            
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
