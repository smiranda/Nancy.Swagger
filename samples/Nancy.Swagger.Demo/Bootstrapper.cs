using Nancy.Conventions;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Autofac;
using Nancy.Swagger.Demo.Modules;
using System.Reflection;

namespace Nancy.Swagger.Demo
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.AddDirectory("swagger-ui-content");
            StaticConfiguration.DisableErrorTraces = false;
        }
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines) {

            RootDocMetadataModule.ConfigBasePath = "/NancySwagger2";
            RootDocMetadataModule.ConfigHost = "localhost";
            RootDocMetadataModule.ConfigSchemes = new string[] {"http"};
            RootDocMetadataModule.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

    }
}