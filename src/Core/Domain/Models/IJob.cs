﻿using System;
using System.Collections.Generic;

namespace Core.Domain.Models
{
    interface IJob
    {
        Guid Id { get; set; }
        string Title { get; set; }
        decimal Salary { get; set; }
        bool IsFilled { get; set; }
        IList<JobApplication> Applications { get; set; }
        JobApplicant PersonHired { get; set; }
        bool AcceptApplication(JobApplication application);
        void Fill(JobApplicant personHired);
    }
}
