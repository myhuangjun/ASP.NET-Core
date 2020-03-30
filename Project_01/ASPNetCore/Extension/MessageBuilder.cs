using ASPNetCore.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.Extension
{
    public class MessageBuilder
    {
        public IServiceCollection Service { get; set; }
        public MessageBuilder(IServiceCollection service)
        {
            Service = service;
        }

        public void UseSms()
        {
            Service.AddSingleton<IMessageService,SmsService>();
        }
        public void UseEmail()
        {
            Service.AddSingleton<IMessageService, EmailService>();
        }
    }
}
