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
        /// �����м��
        /// </summary>
        /// <param name="services">���������� IOC(���Ʒ�ת)����</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //������÷���
            //��ӶԿ�������API����ع��ܵ�֧��,����֧����ͼ��ҳ��
            services.AddControllers();

            //֧�ֿ�����\API\��ͼ��صĹ��ܵ�֧��
            //ASP.MVC Coew 3.XĬ�Ϲ���
            services.AddControllersWithViews();
            //���Razor Page����С��������֧��
            services.AddRazorPages();

            //ASP.MVC CORE 2.xĬ��
            //������������
            services.AddMvc();

            //������÷���
            //��������,EF Coew ,��־��� Swagger

            //ע���Զ������,����Ҫѡ����������(˲ʱ,������,����)
            //˲ʱ:ÿ�����󶼻ᴴ��һ���µ�
            //������ �̵߳��� ��ͬһ���߳�(����)��,ֻʵ����һ��
            //����  ȫ�ֵ���
            //services.AddSingleton();//����
            //services.AddTransient();//˲ʱ
            //services.AddScoped();//������
            //services.AddSingleton<IMessageService, EmailService>();��һ��
            services.AddMessage(option => option.UseSms());//�ڶ���  �ȽϹ淶�ķ����װ

        }
        // �����м��  �м����ɹܵ�
        //�м�� ���Ǵ���HTTP���������Ӧ
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IMessageService service)
        {
            //service.Send();
            //�м��������ְ��:
            //1.ѡ���Ƿ����󴫵ݸ��ܵ��е���һ���м�� ---next
            //2.�ڹܵ��е���һ���м����ǰ��ִ�й���
            //app.Use(async (content, next) =>
            //{
            //    await content.Response.WriteAsync("Middleware 1 Begin \r\n");
            //    await next();
            //});
            ////run������û��next��  �ж��м��
            ////ר��������·��,һ����������
            //app.Run(async context=>
            //{
            //    await context.Response.WriteAsync("Hello Run \r\n");
            //});
            //����ǿ�������
            if (env.IsDevelopment())
            {
                //������Ա�쳣ҳ���м��
                app.UseDeveloperExceptionPage();
            }
            //����Զ����м��  �汾1
            //app.UseMiddleware<TestMiddleware>();
            //app.UseTestMiddle();   //�汾2

            //�ս��·���м��
            //ASP.NET Core 2.X��   û�����
            //ASP.NET Core 3.X �³���,���ж�·�ɵ�����,����·�ɲ����
            app.UseRouting();
            //�ս���м��   �����м����·��֮��Ĺ�ϵ
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
