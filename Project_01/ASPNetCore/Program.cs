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
            //Ĭ������
            //��������
            //���������в���
            //����Ӧ������
            //����Ĭ����־���
            Host.CreateDefaultBuilder(args)
            //�����������һЩ��չ����,�����Զ�������
            //����Kestrel
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //�������
                    //webBuilder.ConfigureKestrel((content, options) => { options.Limits.MaxRequestBodySize = 200; });
                    //����������  ���ȼ�:������(cmd  ����)  Ӧ������(�����ļ���appsettings.json)  Ӳ����  ��������(launchSettings.json)
                    webBuilder.UseUrls("http://*:6000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
