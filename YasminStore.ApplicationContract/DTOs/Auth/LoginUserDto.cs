﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.ApplicationContract.DTOs.Auth
{
    public class LoginUserDto
    {
        
            public string PhoneNumber { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        
    }
}
