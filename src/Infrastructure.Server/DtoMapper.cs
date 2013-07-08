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
            Mapper.CreateMap<JobDto, Job>()
                .ForMember(dest => dest.PersonHired, opt => opt.Ignore()) 
                .ForMember(dest => dest.Applications, opt => opt.Ignore());

            Mapper.CreateMap<JobApplicant, JobApplicantDto>();
            Mapper.CreateMap<JobApplicantDto, JobApplicant>();

            Mapper.CreateMap<JobApplication, JobApplicationDto>();
            Mapper.CreateMap<JobApplicationDto, JobApplication>();
        }
    }
}
