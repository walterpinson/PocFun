using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Application.Messages;
using Infrastructure.PocFunApi.Models;

namespace Infrastructure.PocFunApi.Controllers
{
    public class JobsMessageController : ApiController
    {
        // GET api/values
        public Message<JobDto> Get()
        {
            var message = new Message<JobDto>();

            var jobs = new List<JobDto>();
            var job = new JobDto {Id = Guid.NewGuid(), Salary = Decimal.Parse("15000.00"), Title = "The Dude"};
            jobs.Add(job);

            job = new JobDto { Id = Guid.NewGuid(), Salary = Decimal.Parse("120000.00"), Title = "The Dude II" };
            jobs.Add(job);

            message.Items = jobs;

            return message;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}