﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentication3.Models
{
    public class LoginModel
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
    }
}