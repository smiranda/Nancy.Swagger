using Nancy.ModelBinding;
using Nancy.Swagger.Demo.Models;
using Nancy.Swagger.Modules;
using Nancy.Swagger.Swagger2;
using Swagger.ObjectModel.ApiDeclaration;
using System;

namespace Nancy.Swagger.Demo.Modules
{
    [ApiDoc(
        Title="NancySwagger2 Demo",
        Description="Proof of concept",
        Version="1.0.0"
        //Host="localhost",
        //basePath="/NancySwagger2",
        //schemes=new string[]{"http"}
    )]
    public class RootDocMetadataModule : RootDataProvider { };
    public class RootDocModule : RootDocModuleTemplate { };

    [RouteDoc("GetUsers",
        Description="Gets the users of this system",
        Tag="User Management"),
        ParamDoc(0, "GetUsers",
            Name="Counter0",
            Description="Counting facility",
            Required=true,
            In=ParameterType.Path,
            Type="integer",
            Format="int32"),
        ParamDoc(1, "GetUsers",
            Name = "Counter1",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ParamDoc(2, "GetUsers",
            Name = "Counter2",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ParamDoc(3, "GetUsers",
            Name = "Counter3",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ParamDoc(4, "GetUsers",
            Name = "Counter4",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ResponseDoc("GetUsers",
            Code = "200",
            Model= "User",
            Description= "Requested user"),
        ResponseDoc("GetUsers",
            Code = "500",
            Model = "User",
            Description = "Requested user, deformed")
    ]
    [RouteDoc("PostUsersGet",
        Description = "Gets the users of this system",
        Tag = "User Management"),
        ParamDoc(0, "PostUsersGet",
            Name = "Counter0",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ParamDoc(1, "PostUsersGet",
            Name = "Counter1",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ParamDoc(2, "PostUsersGet",
            Name = "Counter2",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ParamDoc(3, "PostUsersGet",
            Name = "Counter3",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ParamDoc(4, "PostUsersGet",
            Name = "Counter4",
            Description = "Counting facility",
            Required = true,
            In = ParameterType.Path,
            Type = "integer",
            Format = "int32"),
        ResponseDoc("PostUsersGet",
            Code = "200",
            Model = "User",
            Description = "Requested user"),
        ResponseDoc("PostUsersGet",
            Code = "500",
            Model = "User",
            Description = "Requested user, deformed")
    ]
    [RouteDoc("PostUsers",
       Description = "Posts a user",
       Tag = "User Management"),
       ParamDoc(0, "PostUsers",
           Name = "Counter",
           Description = "Counting facility",
           Required = true,
           In = ParameterType.Path,
           Type = "integer",
           EnumValues = new object[]{1,2},
           Format = "int32"),
       ParamDoc(1, "PostUsers",
           Name = "User",
           Description = "Provided User",
           Required = true,
           In = ParameterType.Body,
           Type = "User"),
       ResponseDoc("PostUsers",
           Code = "200",
           Model = "User",
           IsArray = true,
           Description = "Posted user echo")
    ]
    public class HomeMetadataModule : MetaDataProvider { };

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["Home", "/"] = _ => "Hello Swagger!";

            Get["GetUsers", "/users/{p0}"] = _ => new[] { new User { Name = "Vincent Vega", Age = 45 } };
            Post["PostUsersGet", "/users/{p0}"] = _ => new[] { new User { Name = "Vincent Vega", Age = 45 } };
            
            Get["GetUsers2", "/users2"] = _ => new[] { new User { Name = "Vincent Vega", Age = 45 } };

            Post["PostUsers", "/usersP"] = _ =>
            {
                var result = this.BindAndValidate<User>();

                if (!ModelValidationResult.IsValid)
                {
                    return Negotiate.WithModel(new { Message = "Oops" })
                        .WithStatusCode(HttpStatusCode.UnprocessableEntity);
                }

                return Negotiate.WithModel(result).WithStatusCode(HttpStatusCode.Created);
            };
        }
    }
}