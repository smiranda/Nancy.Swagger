using Nancy.Conventions;

namespace Nancy.Swagger.Demo
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.AddDirectory("swagger-ui-content");
            StaticConfiguration.DisableErrorTraces = false;
        }
    }
}