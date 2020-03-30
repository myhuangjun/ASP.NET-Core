using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.Service
{
    public class SmsService:IMessageService
    {
        public string Send()
        {
            return "Send Sms";
        }
    }

    public class EmailService : IMessageService
    {
        public string Send()
        {
            return "Send Email";
        }
    }
}
