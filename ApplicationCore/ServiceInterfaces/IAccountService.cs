﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IAccountService
    {
        int RegisterUser(UserRegisterRequestModel model);
        UserRegisterRequestModel ValidateUser(LoginRequestModel model);
    }
}
