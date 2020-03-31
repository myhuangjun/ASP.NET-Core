using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore
{

    /// <summary>
    /// 测试中间件
    /// </summary>
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsynv(HttpContext context)
        {
            //在这里写中间件的业务代码
            await _next(context); ;
        }
    }
}
