﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class TokenRequest
    {
        public string UserId { get; set; }

        public string IpAddress { get; set; }
    }
}
