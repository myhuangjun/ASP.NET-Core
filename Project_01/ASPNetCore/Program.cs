using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASPNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //默认配置
            //环境变量
            //加载命令行参数
            //加载应用配置
            //配置默认日志组件
            Host.CreateDefaultBuilder(args)
            //调用这里面的一些扩展方法,进行自定义配置
            //启用Kestrel
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //配置组件
                    //webBuilder.ConfigureKestrel((content, options) => { options.Limits.MaxRequestBodySize = 200; });
                    //主机配置项  优先级:命令行(cmd  启动)  应用配置(配置文件中appsettings.json)  硬编码  环境配置(launchSettings.json)
                    webBuilder.UseUrls("http://*:6000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
