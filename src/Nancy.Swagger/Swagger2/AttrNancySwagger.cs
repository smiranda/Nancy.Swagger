using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Metadata.Modules;
using Nancy.Swagger;
using Nancy.Swagger.Services;
using Swagger.ObjectModel.Swagger2;
using Swagger.ObjectModel.ApiDeclaration;

namespace Nancy.Swagger.Swagger2 {

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, Inherited = true)]
    public class PropertyDoc : Attribute {
        public string Description;

        private long? MaximumProperty = null;
        public long Maximum { get { return this.MaximumProperty.GetValueOrDefault(); } set { this.MaximumProperty = value; } }
        public bool MaximumHasValue { get { return this.MaximumProperty != null; } }

        private long? MinimumProperty = null;
        public long Minimum { get { return this.MinimumProperty.GetValueOrDefault(); } set { this.MinimumProperty = value; } }
        public bool MinimumHasValue { get { return this.MinimumProperty != null; } }

        private bool? RequiredProperty = null;
        public bool Required { get { return this.RequiredProperty.GetValueOrDefault(); } set { this.RequiredProperty = value; } }
        public bool RequiredHasValue { get { return this.RequiredProperty != null; } }

        private string[] EnumValuesProperty = null;
        public string[] EnumValues { get { return this.EnumValuesProperty; } set { this.EnumValuesProperty = value; } }
        public bool EnumValuesHasValue { get { return this.EnumValuesProperty != null; } }

        public uint Index;
        public PropertyDoc(uint index, string Description_) { Index = index;  Description = Description_; }

    }
    [AttributeUsage(AttributeTargets.Class)]
    public class ModelDoc : System.Attribute {
        public string Description;
        public ModelDoc(string Description_) {
            Description = Description_;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RouteDocEntry : System.Attribute {
        public string OperationRef;
        public RouteDocEntry(string OperationRef_) {
            OperationRef = OperationRef_;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ApiDoc : System.Attribute {
        public string Host { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string basePath { get; set; }
        public string[] schemes { get; set; }
    }

    public class RouteDoc : RouteDocEntry {

        private string DescriptionProperty = null;
        public string Description { get { return this.DescriptionProperty; } set { this.DescriptionProperty = value; } }
        public bool DescriptionHasValue { get { return this.DescriptionProperty != null; } }

        //private string PathProperty = null;
        //public string Path { get { return this.PathProperty; } set { this.PathProperty = value; } }
        //public bool PathHasValue { get { return this.PathProperty != null; } }

        private string MethodProperty = null;
        public string Method { get { return this.MethodProperty; } set { this.MethodProperty = value; } }
        public bool MethodHasValue { get { return this.MethodProperty != null; } }

        private string TagProperty = null;
        public string Tag { get { return this.TagProperty; } set { this.TagProperty = value; } }
        public bool TagHasValue { get { return this.TagProperty != null; } }

        public RouteDoc(string OperationRef_)
            : base(OperationRef_) {
        }
    }

    public class ParamDoc : RouteDocEntry {

        private string NameProperty = null;
        public string Name { get { return this.NameProperty; } set { this.NameProperty = value; } }
        public bool NameHasValue { get { return this.NameProperty != null; } }

        private string DescriptionProperty = null;
        public string Description { get { return this.DescriptionProperty; } set { this.DescriptionProperty = value; } }
        public bool DescriptionHasValue { get { return this.DescriptionProperty != null; } }

        private bool? RequiredProperty = null;
        public bool Required { get { return this.RequiredProperty.GetValueOrDefault(); } set { this.RequiredProperty = value; } }
        public bool RequiredHasValue { get { return this.RequiredProperty != null; } }

        private ParameterType? InProperty = null;
        public ParameterType In { get { return this.InProperty.GetValueOrDefault(); } set { this.InProperty = value; } }
        public bool InHasValue { get { return this.InProperty != null; } }

        private string TypeProperty = null;
        public string Type { get { return this.TypeProperty; } set { this.TypeProperty = value; } }
        public bool TypeHasValue { get { return this.TypeProperty != null; } }

        private string FormatProperty = null;
        public string Format { get { return this.FormatProperty; } set { this.FormatProperty = value; } }
        public bool FormatHasValue { get { return this.FormatProperty != null; } }

        private object[] EnumValuesProperty = null;
        public object[] EnumValues { get { return this.EnumValuesProperty; } set { this.EnumValuesProperty = value; } }
        public bool EnumValuesHasValue { get { return this.EnumValuesProperty != null; } }

        public uint Index;
        public ParamDoc(uint index, string OperationRef_)
            : base(OperationRef_) {
                Index = index;
        }
    }
    public class ResponseDoc : RouteDocEntry {

        private string DescriptionProperty = null;
        public string Description { get { return this.DescriptionProperty; } set { this.DescriptionProperty = value; } }
        public bool DescriptionHasValue { get { return this.DescriptionProperty != null; } }

        private string ModelProperty = null;
        public string Model { get { return this.ModelProperty; } set { this.ModelProperty = value; } }
        public bool ModelHasValue { get { return this.ModelProperty != null; } }

        public string Code { get; set; }

        public ResponseDoc(string OperationRef_)
            : base(OperationRef_) {
        }
    }

    public abstract class ModelDocProvider<T> : ISwaggerModelDataProvider {
        public SwaggerModelData GetModelData() {
            return SwaggerModelData.ForType<T>(with => {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(this.GetType());
                foreach (System.Attribute attr in attrs) {
                    if (attr is ModelDoc) {
                        ModelDoc attr_doc = (ModelDoc)attr;
                        with.Description(attr_doc.Description);
                        var member_info = this.GetType().GetProperties();

                        List<Tuple<PropertyDoc, string>> prop_doc_list = new List<Tuple<PropertyDoc, string>>();
                        for (int i = 0; i < member_info.Length; i++) {
                            PropertyDoc attr_prop = (PropertyDoc)System.Attribute.GetCustomAttribute(member_info[i], typeof(PropertyDoc));
                            if (attr_prop != null && attr_prop is PropertyDoc) {
                                var tup = new Tuple<PropertyDoc, string>(attr_prop, member_info[i].Name);
                                prop_doc_list.Add(tup);
                            }
                        }

                        // put PropertyDoc in order
                        List<Tuple<PropertyDoc, string>> ordered_list = prop_doc_list.OrderBy(p => p.Item1.Index).ToList();
                        foreach (Tuple<PropertyDoc, string> attr_prop_tup in ordered_list) {

                            PropertyDoc attr_prop = attr_prop_tup.Item1;
                            string attr_prop_name = attr_prop_tup.Item2;

                            var propertyData = with.Data.Properties.First(d => d.Name == attr_prop_name);
                            var swaggerData = new SwaggerModelPropertyDataBuilder<Object>(propertyData);
                            swaggerData.Description(attr_prop.Description);
                            if (attr_prop.RequiredHasValue)
                                swaggerData.Required(attr_prop.Required);
                            if (attr_prop.MinimumHasValue)
                                swaggerData.Minimum(attr_prop.Minimum);
                            if (attr_prop.MaximumHasValue)
                                swaggerData.Maximum(attr_prop.Maximum);
                            if (attr_prop.EnumValuesHasValue)
                                swaggerData.Enum(attr_prop.EnumValues);
                        }
                    }
                }
            });
        }
    }

    public abstract class RootDataProvider : MetadataModule<RootDocumentation> {

        public static string ConfigHost;
        public static string ConfigBasePath;
        public static string[] ConfigSchemes; 

        public RootDataProvider() {

            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(this.GetType());

            Describe["ROOTDOC"] = description => {
                var doc = new RootDocumentation();

                foreach (System.Attribute attr in attrs) {
                    if (attr is ApiDoc) {
                        var api_doc = (ApiDoc)attr;
                        doc = new RootDocumentation {
                            Host = ConfigHost ?? api_doc.Host,
                            rootInfo = new RootInfo {
                                Title = api_doc.Title,
                                Description = api_doc.Description,
                                Version = api_doc.Version
                            },
                            basePath = ConfigBasePath ?? api_doc.basePath,
                            Schemes = ConfigSchemes ?? api_doc.schemes
                        };
                    }
                }
                return doc;
            };
        }
    }

    public abstract class MetaDataProvider : MetadataModule<RouteOperation> {

        public MetaDataProvider() {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(this.GetType());
            Dictionary<string, List<RouteDocEntry>> route_doc_map = new Dictionary<string, List<RouteDocEntry>>();

            foreach (System.Attribute attr in attrs) {
                RouteDocEntry attr_entry = (RouteDocEntry)attr;
                string map_key = attr_entry.OperationRef;

                if (route_doc_map.ContainsKey(map_key)) {
                    route_doc_map[map_key].Add(attr_entry);
                } else {
                    List<RouteDocEntry> doc_list = new List<RouteDocEntry>();
                    doc_list.Add(attr_entry);
                    route_doc_map.Add(map_key, doc_list);
                }
            }

            foreach (var route_doc_entry in route_doc_map) {
                string OperationRef = route_doc_entry.Key;
                Describe[OperationRef] = description => description.AsSwagger2(with => {

                    List<ParamDoc> param_doc_list = new List<ParamDoc>();

                    foreach (RouteDocEntry attr_entry in route_doc_entry.Value) {
                        if (attr_entry is RouteDoc) {
                            RouteDoc attr_entry_route = (RouteDoc)attr_entry;

                            if (attr_entry_route.DescriptionHasValue)
                                with.Description(attr_entry_route.Description);

                            if (attr_entry_route.TagHasValue)
                                with.Tag(attr_entry_route.Tag);

                            with.Path(description.Path);
                        }

                        if (attr_entry is ResponseDoc) {
                            ResponseDoc attr_entry_model = (ResponseDoc)attr_entry;
                            with.Response(attr_entry_model.Code, attr_entry_model.Model, attr_entry_model.Description);
                        }

                        if (attr_entry is ParamDoc) {
                            param_doc_list.Add((ParamDoc)attr_entry);
                        }
                    }

                    // put ParamDocs in order
                    List<ParamDoc> ordered_list = param_doc_list.OrderBy(p => p.Index).ToList();
                    foreach (ParamDoc attr_entry_param in ordered_list) {
                        with.Parameter(
                            attr_entry_param.In, attr_entry_param.Type, attr_entry_param.Name,
                            attr_entry_param.EnumValuesHasValue ? attr_entry_param.EnumValues : null,
                            attr_entry_param.Description, attr_entry_param.Format, attr_entry_param.Required);
                    }

                });
            }
        }
    }
}