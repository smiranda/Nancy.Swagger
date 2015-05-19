using Nancy.Bootstrapper;
using Nancy.Swagger.Services;
using Nancy.Swagger.Swagger2;

namespace Nancy.Swagger
{
    [SwaggerApi]
    public class SwaggerRegistrations : Registrations
    {
        public SwaggerRegistrations()
        {
            //RegisterWithDefault<ISwaggerMetadataProvider>(typeof(DefaultSwaggerMetadataProvider));
            //RegisterWithDefault<ISwaggerMetadataConverter>(typeof(DefaultSwaggerMetadataConverter));

            RegisterWithDefault<IV2SwaggerMetadataProvider>(typeof(V2SwaggerMetadataProvider));
            RegisterWithDefault<IV2SwaggerMetadataConverter>(typeof(V2SwaggerMetadataConverter));

            RegisterWithDefault<ISwaggerModelCatalog>(typeof(DefaultSwaggerModelCatalog));
            RegisterAll<ISwaggerModelDataProvider>();
        }
    }
}