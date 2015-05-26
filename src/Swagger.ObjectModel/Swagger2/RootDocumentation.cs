using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.ObjectModel.Swagger2 {
    public class RootDocumentation {
        public RootInfo rootInfo {get; set;}
        public string Host { get; set; }
        public IEnumerable<string> Schemes { get; set; }
        public string basePath { get; set; }
    }
}
