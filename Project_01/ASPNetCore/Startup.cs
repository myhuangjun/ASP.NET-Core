using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCore.Extension;
using ASPNetCore.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPNetCore
{
    public class Startup
    {
        /// <summary>
        /// 配置中间件
        /// </summary>
        /// <param name="services">服务器容器 IOC(控制反转)容器</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //添加内置服务
            //添加对控制器和API的相关功能的支持,但不支持视图和页面
            services.AddControllers();

            //支持控制器\API\视图相关的功能的支持
            //ASP.MVC Coew 3.X默认功能
            services.AddControllersWithViews();
            //添加Razor Page和最小控制器的支持
            services.AddRazorPages();

            //ASP.MVC CORE 2.x默认
            //等于上面两句
            services.AddMvc();

            //添加外置服务
            //第三方的,EF Coew ,日志框架 Swagger

            //注册自定义服务,必须要选择生命周期(瞬时,作用域,单例)
            //瞬时:每次请求都会创建一个新的
            //作用域 线程单例 在同一个线程(请求)里,只实例化一次
            //单例  全局单例
            //services.AddSingleton();//单例
            //services.AddTransient();//瞬时
            //services.AddScoped();//作用域
            //services.AddSingleton<IMessageService, EmailService>();第一版
            services.AddMessage(option => option.UseSms());//第二版  比较规范的服务封装

        }
        // 配置中间件  中间件组成管道
        //中间件 就是处理HTTP的请求和响应
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IMessageService service)
        {
            //service.Send();
            //中间件有两个职责:
            //1.选择是否讲请求传递给管道中的下一个中间件 ---next
            //2.在管道中的下一个中间件的前后执行工作
            //app.Use(async (content, next) =>
            //{
            //    await content.Response.WriteAsync("Middleware 1 Begin \r\n");
            //    await next();
            //});
            ////run方法是没有next的  中断中间件
            ////专门用来短路的,一般放在最后面
            //app.Run(async context=>
            //{
            //    await context.Response.WriteAsync("Hello Run \r\n");
            //});
            //如果是开发环境
            if (env.IsDevelopment())
            {
                //开发人员异常页面中间件
                app.UseDeveloperExceptionPage();
            }
            //添加自定义中间件  版本1
            //app.UseMiddleware<TestMiddleware>();
            //app.UseTestMiddle();   //版本2

            //终结点路由中间件
            //ASP.NET Core 2.X里   没有这个
            //ASP.NET Core 3.X 猜出来,都有对路由的需求,所以路由拆出来
            app.UseRouting();
            //终结点中间件   配置中间件和路由之间的关系
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
