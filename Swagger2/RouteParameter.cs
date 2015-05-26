namespace Swagger2 {
    using Swagger.ObjectModel;
    using Swagger.ObjectModel.ApiDeclaration;
    using Swagger.ObjectModel.Attributes;

    public class RouteParameter : SwaggerModel {

        [SwaggerProperty("name", true)]
        public string Name { get; set; }

        [SwaggerProperty("in", true)]
        public ParameterType In { get; set; }

        [SwaggerProperty("type", true)]
        public string Type { get; set; }

        [SwaggerProperty("required", true)]
        public bool Required { get; set; }

        // TODO: missing schema
    }
}
