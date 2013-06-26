﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Application.Messages
{
    public class JobApplicantDto
    {
        Guid Id { get; set; }
        Address Address { get; set; }
        Name Name { get; set; }
        string PhoneNumber { get; set; }
    }
}
