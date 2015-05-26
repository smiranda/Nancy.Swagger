using Swagger.ObjectModel.ApiDeclaration;
using Swagger.ObjectModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.ObjectModel.Swagger2 {
    public class ResponseObject : SwaggerModel {

        [SwaggerProperty("description", true)]
        public string Description { get; set; }

        [SwaggerProperty("schema", true)]
        public SchemaObject Schema { get; set; }
    }
}
