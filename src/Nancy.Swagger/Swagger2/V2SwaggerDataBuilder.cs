using Nancy.Responses.Negotiation;
using Swagger.ObjectModel.ApiDeclaration;
using Swagger.ObjectModel.Swagger2;
using System;
using System.Collections.Generic;

namespace Nancy.Swagger.Swagger2 {

    [SwaggerApi]
    public class V2SwaggerRouteDataBuilder {

        public V2SwaggerRouteDataBuilder(string operationNickName, /*HttpMethod*/ string method, string apiPath) {
            Data = new RouteOperation();
            Method(method.ToLower());
        }

        public RouteOperation Data;
        public string CurrentMethod;

        public V2SwaggerRouteDataBuilder Method(string method) {
            CurrentMethod = method;
            if (!Data.Operations.Contains(method))
                Data.Operations.Add(method, new RouteOperationModel(Data));

            return this;
        }

        public V2SwaggerRouteDataBuilder Description(string description) {
            try {
                ((RouteOperationModel)Data.Operations[CurrentMethod]).Description = description;
            } catch (Exception e) {
                throw new InvalidOperationException(
                    "Must call V2SwaggerRouteDataBuilder.Method() before building the route data, currentMethod=" + CurrentMethod, e);
            }
            return this;
        }
        public V2SwaggerRouteDataBuilder Path(string path) {
            Data.Path = path;
            return this;
        }

        public V2SwaggerRouteDataBuilder Response(string code, string response_model, string description = null) {

            description = description ?? Enum.GetName(typeof(HttpStatusCode), Convert.ToInt32(code));

            var response_object = new ResponseObject {
                Description = description,
                Schema = new SchemaObject {
                    Ref = "#/definitions/" + response_model
                }
            };

            IDictionary<string, ResponseObject> responses =
                ((RouteOperationModel)Data.Operations[CurrentMethod]).Responses;
            responses.Add(Convert.ToString(code), response_object);

            return this;
        }

        public V2SwaggerRouteDataBuilder Tag(string tag) {
            try {
                ((RouteOperationModel)Data.Operations[CurrentMethod]).Tags.Add(tag);
            } catch (Exception e) {
                throw new InvalidOperationException(
                    "Must call V2SwaggerRouteDataBuilder.Method() before building the route data.", e);
            }
            return this;
        }

        public V2SwaggerRouteDataBuilder Parameter(
            ParameterType parameter_in,
            string type,
            string name,
            string description = null,
            string format = null,
            bool required = false) {

            RouteParameter param;

            if (parameter_in == ParameterType.Body) {
                param = new RouteParameter {
                    Name = name,
                    In = parameter_in,
                    Description = description,
                    Required = required,
                    Schema = new SchemaObject {
                        Ref = "#/definitions/" + type
                    }
                };
            } else {
                param = new RouteParameter {
                    Name = name,
                    In = parameter_in,
                    Description = description,
                    Required = required,
                    Type = type,
                    Format = format
                };
            }

            try {
                ((RouteOperationModel)Data.Operations[CurrentMethod]).Parameters.Add(param);
            } catch (Exception e) {
                throw new InvalidOperationException (
                    "Must call V2SwaggerRouteDataBuilder.Method() before building the route data.", e);
            }

            return this;
        }

        public V2SwaggerRouteDataBuilder Model<T>() {
            Data.Model = typeof(T);
            return this;
        }

    }
}