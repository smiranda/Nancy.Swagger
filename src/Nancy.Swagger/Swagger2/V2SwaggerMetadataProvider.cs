using System.Collections.Generic;
using System.Linq;
using System;
using Nancy.Routing;
using Swagger.ObjectModel.Swagger2;
using System.Collections;

namespace Nancy.Swagger.Swagger2
{
    [SwaggerApi]
    public class V2SwaggerMetadataProvider : V2AbsSwaggerMetadataProvider
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

        public override IDictionary<string, IDictionary>
            RetrieveSwaggerRouteData()
        {
            var metadata = _routeCacheProvider
                            .GetCache()
                            .RetrieveMetadata<RouteOperation>()
                            .OfType<RouteOperation>();
            
            IDictionary <string, RouteOperation> metadict =
                new Dictionary<string, RouteOperation>();
            
            foreach (var e in metadata) {
                if (!metadict.Keys.Contains(e.Path)) {
                    metadict.Add(e.Path, e);
                } else {
                    foreach(var method in (Dictionary<string, RouteOperationModel>)e.Operations)
                        metadict[e.Path].Operations.Add(method.Key, method.Value);
                }
            }

            return metadict
                .Select(r => Tuple.Create(r.Value.Path, r.Value.Operations))
                .ToDictionary(x => x.Item1, x => x.Item2);
        }

        public override RootDocumentation RetrieveRootDocumentation() {

            var cache = _routeCacheProvider.GetCache();

            return cache
                .RetrieveMetadata<RootDocumentation>()
                .OfType<RootDocumentation>()
                .First();
        }

        public override IList<SwaggerModelData> RetrieveSwaggerModelData()
        {
            return _modelCatalog.ToList();
        }
    }
}