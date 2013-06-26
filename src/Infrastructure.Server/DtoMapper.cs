using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Application.Messages;
using AutoMapper;

namespace Infrastructure.Server
{
    public static class DtoMapper
    {
        public static void Configure()
        {
            Mapper.CreateMap<Job, JobDto>();
            Mapper.CreateMap<JobDto, Job>();

            Mapper.CreateMap<JobApplicant, JobApplicantDto>();
            Mapper.CreateMap<JobApplicantDto, JobApplicant>();
        }
    }
}
