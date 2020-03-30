using ASPNetCore.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.Extension
{
    /// <summary>
    /// 自定义服务第二版
    /// </summary>
    public static class MessageExtension
    {
        public static void AddMessage(this IServiceCollection service, Action<MessageBuilder> config)
        {
            //带理解
            var builder = new MessageBuilder(service);
            config(builder);
        }
    }
}
