using Swagger.ObjectModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.ObjectModel.Swagger2 {
    public class SchemaObject : SwaggerModel {
        [SwaggerProperty("$ref", true)]
        public string Ref {get; set;}

        [SwaggerProperty("type", true)]
        public string Type { get; set; }

        [SwaggerProperty("format", true)]
        public string Format { get; set; }
    }

    public class SchemaList : SwaggerModel {
        [SwaggerProperty("type", true)]
        public string Type { get; set; }

        [SwaggerProperty("items", true)]
        public SchemaObject Items { get; set; }
    }
}
