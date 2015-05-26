namespace Swagger.ObjectModel.Swagger2
{
    using Swagger.ObjectModel.ApiDeclaration;
    using Swagger.ObjectModel.Attributes;
    using System;
    using System.Collections;
    using System.Collections.Generic;

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
        public IDictionary<string, IDictionary> Paths { get; set; }

        [SwaggerProperty("definitions", true)]
        public IDictionary<string, Model> Definitions { get; set; }
    }
}
