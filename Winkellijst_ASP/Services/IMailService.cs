﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Services
{
    public interface IMailService
    {
        Task SendPasswordResetLink(string email, string name, string url);
    }
}
