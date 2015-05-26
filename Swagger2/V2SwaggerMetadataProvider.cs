using System.Collections.Generic;
using System.Linq;
using Nancy.Routing;

namespace Nancy.Swagger.Services
{
    [SwaggerApi]
    public class V2SwaggerMetadataProvider : SwaggerMetadataProvider
    {
        private readonly IRouteCacheProvider _routeCacheProvider;

        private readonly ISwaggerModelCatalog _modelCatalog;

        public V2SwaggerMetadataProvider(
            IRouteCacheProvider routeCacheProvider,
            ISwaggerModelCatalog modelCatalog)
        {
            _routeCacheProvider = routeCacheProvider;
            _modelCatalog = modelCatalog;
        }

        public override IList<SwaggerRouteData> RetrieveSwaggerRouteData()
        {
            return _routeCacheProvider
                .GetCache()
                .RetrieveMetadata<SwaggerRouteData>()
                .OfType<SwaggerRouteData>()
                .ToList(); // filter nulls
        }

        public override IList<SwaggerModelData> RetrieveSwaggerModelData()
        {
            return _modelCatalog.ToList();
        }
    }
}