using ASPNetCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.Controller
{
    /// <summary>
    /// 第一版  使用IMessageService
    /// </summary>
    public class HomeController
    {
        private IMessageService Service;
        public HomeController(IMessageService service)
        {
            Service = service;
        }
    }
}
