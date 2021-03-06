﻿using System.Web.Http;
using Infrastructure.PocFunApi.Handlers;

namespace Infrastructure.PocFunApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //
            // Configure Custom Message Handlers
            config.MessageHandlers.Add(new ClientAuthorizationHandler());

            //
            // Configure routes

//            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "JobSpecificJobApplicationsRoute",
                routeTemplate: "v1/jobs/{jobId}/jobapplications",
                defaults: new { controller = "JobApplications", jobId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "JobSpecificJobApplicantsRoute",
                routeTemplate: "v1/jobs/{jobId}/jobapplicants",
                defaults: new { controller = "JobApplicants", jobId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
