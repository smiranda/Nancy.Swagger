namespace Swagger.ObjectModel.Swagger2 {

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Swagger.ObjectModel.Attributes;
    using System.Runtime.Serialization;
    using System.Collections;

    public class RouteOperation {

        public IDictionary Operations;

        public string Path;
        
        public Type Model { get; set; }

        public RouteOperation() {
            Operations = new Dictionary<string, RouteOperationModel>();
        }

    }

    public class RouteOperationModel : SwaggerModel {

        public RouteOperationModel(RouteOperation meta) {
            Parameters = new List<RouteParameter>();
            Responses = new Dictionary<string, ResponseObject>();
            Tags = new List<string>();
            _meta = meta;
        }

        private RouteOperation _meta;
        public RouteOperation GetMeta() {
            return _meta;
        }

        [SwaggerProperty("summary", true)]
        public string Summary { get; set; }

        [SwaggerProperty("description", true)]
        public string Description { get; set; }

        [SwaggerProperty("parameters", true)]
        public IList<RouteParameter> Parameters { get; set; }

        [SwaggerProperty("tags", true)]
        public IList<string> Tags { get; set; }

        [SwaggerProperty("produces", true)]
        public IList<string> Produces { get; set; }

        [SwaggerProperty("consumes", true)]
        public IList<string> Consumes { get; set; }

        [SwaggerProperty("responses", true)]
        public IDictionary<string, ResponseObject> Responses { get; set; }
    }
}
