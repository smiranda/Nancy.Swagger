using Swagger.ObjectModel;
using Swagger.ObjectModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger2 {

    public class RootInfo : SwaggerModel{

        [SwaggerProperty("title", true)]
        public string Title { get; set; }

        [SwaggerProperty("description", true)]
        public string Description { get; set; }

        [SwaggerProperty("version", true)]
        public string Version { get; set; }
    }
}
