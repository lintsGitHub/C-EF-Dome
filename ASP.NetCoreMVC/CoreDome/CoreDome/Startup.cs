using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDome.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreDome
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// 这个方法就是用来配置依赖注入的东西，也有点像Spring中的配置
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //注册一个Service
            //一个单例的Service
            //这句代码的一个意思就是，当service去请求IStudent这个接口时，容器会返回StudentService实例
            services.AddSingleton<IStudent, StudentService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 配置HTTP请求管道
        /// 里面都是一些中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="logger">日志，因为在源码中有这个动作，我们可以拿出来使用了</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ////我们调用两次run的话只会返回第一个run的结果，因为context.Response.WriteAsync("Hello World!"); 就代表着这个方法已经完成，并不会执行下一个返回结果
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //但是我们需要执行两个结果呢
            //我们就可以使用app.Use方法
            app.Use(async(context, next) =>
            {
                logger.LogInformation("app1,start");
                
                await context.Response.WriteAsync("Hello World!");
                //进入到下一个中间件
                await next();
                logger.LogInformation("app1,end");
            });

            //遇到请求就返回HelloWorld
            //Run参数是RequestDelegate 请求委托
            app.Run(async (context) =>
            {
                logger.LogInformation("app2,start");
                await context.Response.WriteAsync("Hello World!");
                logger.LogInformation("app2,end");
            });
        }
    }
}
