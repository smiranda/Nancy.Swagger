using Swagger.ObjectModel.ApiDeclaration;
using Swagger.ObjectModel.ResourceListing;
using Swagger.ObjectModel.Swagger2;

namespace Nancy.Swagger.Swagger2
{
    [SwaggerApi]
    public interface IV2SwaggerMetadataConverter
    {
        ApiDocumentation GetApiDocumentation();
    }
}