using Nancy.Metadata.Modules;
using Nancy.Swagger.Demo.Models;
using Swagger.ObjectModel.ApiDeclaration;
using Swagger.ObjectModel.Swagger2;

namespace Nancy.Swagger.Demo.Modules
{
    //public class HomeMetadataModule : MetadataModule<SwaggerRouteData>
    //{
    //    public HomeMetadataModule()
    //    {
    //        Describe["GetUsers"] = description => description.AsSwagger(with =>
    //        {
    //            with.ResourcePath("/users");
    //            with.Summary("The list of users");
    //            with.Notes("This returns a list of users from our awesome app");
    //            with.Model<User>();
    //        });
    //
    //        Describe["PostUsers"] = description => description.AsSwagger(with =>
    //        {
    //            with.ResourcePath("/users");
    //            with.Summary("Create a User");
    //            with.Response(201, "Created a User");
    //            with.Response(422, "Invalid i                     nput");
    //            with.Model<User>();
    //            with.BodyParam<User>("A User object", required: true);
    //            with.Notes("Creates a user with the shown schema for our awesome app");
    //        });
    //    }
    //}

    //public class HomeMetadataModule : MetadataModule<RouteOperation> {
    //    public HomeMetadataModule() {
    //
    //        Describe["GetUsers2"] = description => description.AsSwagger2(with => {
    //
    //            with.Method("get")
    //                .Tag("User Management")
    //                .Path(description.Path)
    //                .Description("Gets Users - 2")
    //                .Parameter<int>(ParameterType.Path, "integer", "counter", "description");
    //
    //            with.Method("post")
    //                .Tag("User Management")
    //                .Path(description.Path)
    //                .Description("Gets Users - post")
    //                .Parameter<int>(ParameterType.Path, "integer", "counter", "description");
    //        });
    //        Describe["GetUsers"] = description => description.AsSwagger2(with => {
    //
    //            with.Method("get")
    //                .Tag("User Lisiting")
    //                .Path(description.Path)
    //                .Description("Gets Users - ")
    //                .Parameter<int>(ParameterType.Path, "integer", "counter", "description")
    //                .Parameter<int>(ParameterType.Path, "integer", "counter2", "description2")
    //                .Response(204, "User", "Everything is fine.")
    //                .Response(500, "User", "Failure.");
    //        });
    //    }
    //}
}