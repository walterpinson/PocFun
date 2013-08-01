using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Application.Messages;
using Infrastructure.PocFunApi.Models;

namespace Infrastructure.PocFunApi.Controllers
{
    public class JobsMessageController : ApiController
    {
        // GET v1/jobsmessage
        public ApiMessage<JobDto> Get()
        {
            var apiMessage = new ApiMessage<JobDto>();
            var message = new Message<JobDto>();

            var jobs = new List<JobDto>();
            var job = new JobDto {Id = Guid.NewGuid(), Salary = Decimal.Parse("15000.00"), Title = "The Dude"};
            jobs.Add(job);

            job = new JobDto { Id = Guid.NewGuid(), Salary = Decimal.Parse("120000.00"), Title = "The Dude II" };
            jobs.Add(job);

            message.Items = jobs;

            // Add the message body to the Api Message
            apiMessage.Message = message;

            return apiMessage;
        }

        // GET v1/jobsmessage/5
        public string Get(int id)
        {
            return "value";
        }

        // POST v1/jobsmessage
        public HttpResponseMessage Post(ApiMessage<JobDto> apiMessage)
        {
            if (ModelState.IsValid)
            {
                var newId = Guid.NewGuid();
                apiMessage.Message.Items[0].Id = newId;

                var response = Request.CreateResponse(HttpStatusCode.Created, apiMessage);
                response.Headers.Location = new Uri(string.Format("{0}/{1}", Request.RequestUri, newId));

                return response;
            }
            else
            {
                var errorMessage = new ApiMessage<JobDto>();
                var error = new Error
                {
                    Description = "Your request is invalid. Please try again.",
                    InternalCode = 456.ToString(),
                    Name = "Invalid request"
                };

                errorMessage.Message.Errors.Add(error);

                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);

                return errorResponse;
            }
        }

        // PUT v1/jobsmessage/5
        public HttpResponseMessage Put(Guid id, ApiMessage<JobDto> apiMessage)
        {
            if (ModelState.IsValid)
            {
                var response = Request.CreateResponse(HttpStatusCode.NoContent, apiMessage);
                response.Headers.Location = new Uri(Request.RequestUri, id.ToString());

                return response;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // DELETE v1/jobsmessage/5
        public void Delete(int id)
        {
        }
    }
}