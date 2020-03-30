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
            service.Send();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

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
