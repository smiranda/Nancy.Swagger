namespace Swagger.ObjectModel.Swagger2 {

    using Swagger.ObjectModel.ApiDeclaration;
    using Swagger.ObjectModel.Attributes;
    using System;

    public class RouteParameter : SwaggerModel {

        [SwaggerProperty("name", true)]
        public string Name { get; set; }

        [SwaggerProperty("description", true)]
        public string Description { get; set; }

        [SwaggerProperty("required", true)]
        public bool Required { get; set; }
        
        [SwaggerProperty("in", true)]
        public ParameterType In { get; set; }

        // In case In is not body
        [SwaggerProperty("type", true)]
        public string Type { get; set; }

        [SwaggerProperty("format", true)]
        public string Format { get; set; }

        // In case In is body
        [SwaggerProperty("schema", true)]
        public SchemaObject Schema { get; set; }
    }
}
