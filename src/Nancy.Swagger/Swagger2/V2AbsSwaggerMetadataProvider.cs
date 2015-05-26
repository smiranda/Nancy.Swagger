using Swagger.ObjectModel.Swagger2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Swagger.Swagger2
{
    public abstract class V2AbsSwaggerMetadataProvider : IV2SwaggerMetadataProvider
    {
        public abstract IList<SwaggerModelData> RetrieveSwaggerModelData();

        public abstract IDictionary<string, IDictionary> RetrieveSwaggerRouteData();

        public abstract RootDocumentation RetrieveRootDocumentation();
    }
}
