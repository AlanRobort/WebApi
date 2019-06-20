using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi
{

    public class LocalMailService:IMailService
    {
        private readonly ILogger<LocalMailService> _logger;
        private string _ToMail = "developer@qq.com";
        private string _FromMail = "Admin@qq.com";

        //private readonly string _ToMail = Startup.Configuration["mailSettings:mailToAddress"];
        //private readonly string _FromMail = Startup.Configuration["mailSettings:mailFromAddress"];

        public LocalMailService(ILogger<LocalMailService> logger)
        {
            _logger = logger;
        }

        public void send(string subject,string msg)
        {
            Debug.WriteLine($"从{_FromMail}给{_ToMail}通过{nameof(LocalMailService)}发送的");
        }
    }
}
