namespace Swagger2
{
    using Swagger.ObjectModel;
    using Swagger.ObjectModel.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ApiDocumentation : SwaggerModel
    {
        public ApiDocumentation() {

        }

        [SwaggerProperty("swagger", true)]
        public string Version { get; set; }

        [SwaggerProperty("info", true)]
        public RootInfo Info { get; set; }

        [SwaggerProperty("host", true)]
        public string Host { get; set; }

        [SwaggerProperty("schemes", true)]
        public IEnumerable<string> Schemes { get; set; }

        [SwaggerProperty("basePath", true)]
        public string basePath { get; set; }

        [SwaggerProperty("produces", true)]
        public IEnumerable<string> Produces { get; set; }

        [SwaggerProperty("paths", true)]
        public IDictionary<string, IDictionary<string, RouteOperation>> Paths { get; set; }
    }
}
