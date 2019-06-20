using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class CloudMailService:IMailService
    {
        private readonly ILogger<CloudMailService> _logger;
        private string _ToMail = "Admin@qq.com";
        private string _FromMail = "noreply@alibaba.com";


        //private readonly string _Tomail = Startup.Configuration["mailSettings:mailToAddress"];
        //private readonly string _Fromail = Startup.Configuration["mailSettings:mailFromAddress"];
        public CloudMailService(ILogger<CloudMailService> logger)
        {
            _logger = logger;
        }

        public void send(string subject, string msg)
        {
            Debug.WriteLine($"从{_FromMail}给{_ToMail}通过{nameof(LocalMailService)}发送的");
        }
    }
}
