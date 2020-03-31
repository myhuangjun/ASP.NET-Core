using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore
{
    public static class CustonMiddlewareExtensions
    {
        public static void  UseTestMiddle(this IApplicationBuilder app)
        {
            app.UseMiddleware<TestMiddleware>();
        }
    }
}
