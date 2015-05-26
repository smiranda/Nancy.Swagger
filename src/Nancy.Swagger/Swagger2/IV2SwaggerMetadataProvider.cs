using Swagger.ObjectModel.Swagger2;
using System.Collections;
using System.Collections.Generic;

namespace Nancy.Swagger.Swagger2
{
    public interface IV2SwaggerMetadataProvider
    {
        IList<SwaggerModelData> RetrieveSwaggerModelData();

        IDictionary<string, IDictionary> RetrieveSwaggerRouteData();

        RootDocumentation RetrieveRootDocumentation();
    }
}