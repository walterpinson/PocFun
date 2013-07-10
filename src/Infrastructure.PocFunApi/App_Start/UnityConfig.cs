using System;
using System.Configuration;
using Core.Application.Services;
using Core.Domain.Services;
using Core.Domain.Services.Impl;
using Microsoft.Practices.Unity;

using Infrastructure.Server;

namespace Infrastructure.PocFunApi.App_Start
{
    using Infrastructure.Security;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig

    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            _mongoUrl = ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString;

            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static string _mongoUrl ;

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // Registration names
            const string mongoJobRepo = "mongoJobRepository";
            const string mongoJobApplicantRepo = "mongoJobApplicantRepository";
            const string sqlJobRepo = "sqlJobRepository";
            const string sqlJobApplicantRepo = "sqlJobApplicantRepository";

            // TODO: Register your types here
            container.RegisterType<ITokenService, TokenService>();
            container.RegisterType<IApplyForJobsService, ApplyForJobsService>();
            container.RegisterType<IJobRepository, Data.MongoDb.JobRepository>(mongoJobRepo,
                new InjectionConstructor(_mongoUrl));
            container.RegisterType<IJobRepository, Data.SqlAzure.JobRepository>(sqlJobRepo);
            container.RegisterType<IJobApplicantRepository, Data.MongoDb.JobApplicantRepository>(mongoJobApplicantRepo,
                new InjectionConstructor(_mongoUrl));
            container.RegisterType<IJobApplicantRepository, Data.SqlAzure.JobApplicantRepository>(sqlJobApplicantRepo);

            // This is a recruiter that persists using MongoDb
            container.RegisterType<IRecruiter, Recruiter>("mongo",
                new InjectionConstructor(
                    new ResolvedParameter<IApplyForJobsService>(),
                    new ResolvedParameter<IJobRepository>(mongoJobRepo),
                    new ResolvedParameter<IJobApplicantRepository>(mongoJobApplicantRepo)));

            // This is a recruiter that persists using Sql
            container.RegisterType<IRecruiter, Recruiter>("sql",
                new InjectionConstructor(
                    typeof(IApplyForJobsService),
                    new ResolvedParameter<IJobRepository>(sqlJobRepo),
                    new ResolvedParameter<IJobApplicantRepository>(sqlJobApplicantRepo)));
        }
    }
}
