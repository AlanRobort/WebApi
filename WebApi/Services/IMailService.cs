﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
  public interface IMailService
    {
        void send(string subject, string msg);
    }
}
