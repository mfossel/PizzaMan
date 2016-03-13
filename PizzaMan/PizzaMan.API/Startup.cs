using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PizzaMan.API;
using PizzaMan.API.Infrastructure;
using PizzaMan.Core.Infrastructure;
using PizzaMan.DATA.Infrastructure;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Repository;
using PizzaMan.Core.Domain;

[assembly: OwinStartup(typeof(PizzaMan.Api.Startup))]
namespace PizzaMan.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ConfigureSimpleInjector(app);
            ConfigureOAuth(app, container);

            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, Container container)
        {
            Func<IAuthorizationRepository> authRepositoryFactory = container.GetInstance<IAuthorizationRepository>;

            var authorizationOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new PizzaManAuthorizationServerProvider(authRepositoryFactory)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(authorizationOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public Container ConfigureSimpleInjector(IAppBuilder app)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            container.Register<IDatabaseFactory, DatabaseFactory>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>();

            container.Register<IPhotoRepository, PhotoRepository>();
            container.Register<IPizzeriaRepository, PizzeriaRepository>();
            container.Register<IReviewRepository, ReviewRepository>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserStore<User, string>, UserStore>(Lifestyle.Scoped);
            container.Register<IAuthorizationRepository, AuthorizationRepository>(Lifestyle.Scoped);

            // more code to facilitate a scoped lifestyle
            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            container.Verify();

            return container;
        }
    }
}