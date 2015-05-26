using System;
using System.Collections.Generic;
using System.Linq;
using Swagger.ObjectModel;
using Swagger.ObjectModel.ApiDeclaration;
using Swagger.ObjectModel.ResourceListing;
using Swagger.ObjectModel.Swagger2;
using Nancy.Swagger.Services;

namespace Nancy.Swagger.Swagger2
{
    [SwaggerApi]
    public class V2SwaggerMetadataConverter : IV2SwaggerMetadataConverter
    {
        private IV2SwaggerMetadataProvider _metadataProvider;

        public V2SwaggerMetadataConverter(IV2SwaggerMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        public ApiDocumentation GetApiDocumentation()
        {

            var routeData = _metadataProvider.RetrieveSwaggerRouteData();
            var modelsData = _metadataProvider.RetrieveSwaggerModelData();
            var rootDocumentation = _metadataProvider.RetrieveRootDocumentation();

            var apiDocumentation = new ApiDocumentation() {
                Version = "2.0",
                Info = rootDocumentation.rootInfo,
                Host = rootDocumentation.Host,
                Schemes = rootDocumentation.Schemes,
                basePath = rootDocumentation.basePath,
                Paths = routeData
            };

            apiDocumentation.Definitions = _metadataProvider.RetrieveSwaggerModelData()
                .SelectMany(m => m.ToModel(modelsData))
                .GroupBy(m => m.Id)
                .Select(g => g.First())
                .OrderBy(m => m.Id)
                .ToDictionary(m => m.Id, m => { m.Id = null; return m; });

            return apiDocumentation;
        }
    }
}