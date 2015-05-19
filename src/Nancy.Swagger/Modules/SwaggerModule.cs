using Nancy.Swagger.Services;
using Nancy.Swagger.Swagger2;

namespace Nancy.Swagger.Modules
{
    [SwaggerApi]
    public class SwaggerModule : NancyModule {
        public SwaggerModule(IV2SwaggerMetadataConverter converter)
            : base(SwaggerConfig.ResourceListingPath)
        {
            Get["/"] = _ => {
                return converter.GetApiDocumentation().ToJson();
            };
        }
    }

    public class RootDocModuleTemplate : NancyModule {
        public RootDocModuleTemplate() {
            Get["ROOTDOC", "/ROOTDOC"] = _ => "ROOTDOC";
        }
    };
}