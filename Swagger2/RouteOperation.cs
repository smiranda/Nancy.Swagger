using Swagger.ObjectModel;
using Swagger.ObjectModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger2 {

    public class RouteOperation : SwaggerModel {

        [SwaggerProperty("summary", true)]
        public string Summary { get; set; }

        [SwaggerProperty("description", true)]
        public string Description { get; set; }

        [SwaggerProperty("parameters", true)]
        public IEnumerable<RouteParameter> Parameters { get; set; }

        [SwaggerProperty("tags", true)]
        public IEnumerable<string> Tags { get; set; }

        // TODO: missing responses
    }
}
