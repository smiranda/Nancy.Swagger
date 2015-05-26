using Swagger.ObjectModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.ObjectModel.Swagger2 {
    public class SchemaObject : SwaggerModel {
        [SwaggerProperty("$ref", true)]
        public string Ref {get; set;}
    }
}
