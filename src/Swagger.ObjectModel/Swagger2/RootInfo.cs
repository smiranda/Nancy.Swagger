namespace Swagger.ObjectModel.Swagger2 {

    using Swagger.ObjectModel;
    using Swagger.ObjectModel.Attributes;

    public class RootInfo : SwaggerModel{

        [SwaggerProperty("title", true)]
        public string Title { get; set; }

        [SwaggerProperty("description", true)]
        public string Description { get; set; }

        [SwaggerProperty("version", true)]
        public string Version { get; set; }
    }
}
