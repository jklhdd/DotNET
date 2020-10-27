using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace AuthenticationWithWebApi.Filters
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            var pathToken = new PathItem()
            {
               
                post = new Operation()
                {
                    tags = new List<string> { "Auth"},
                    consumes = new List<string> { "application/x-www-form-urlencoded"},
                    parameters = new List<Parameter>()
                    {
                        new Parameter()
                        {
                            type= "string",
                            name = "grant_type",
                            required =true,
                            @default = "password",
                            @in = "formData"
                        },
                        new Parameter()
                        {
                            type= "string",
                            name = "username",
                            required =true,
                            @default = "haonc@gmail.com",
                            @in = "formData"
                        },
                        new Parameter()
                        {
                            type= "string",
                            name = "password",
                            required =true,
                            @default = "Hao123@123",
                            @in = "formData"
                        }

                    }
                }
            };
            var paths = swaggerDoc.paths.OrderBy(x => x.Key).ToList();
            paths.Insert(0, new KeyValuePair<string, PathItem>("/token", pathToken));

            swaggerDoc.paths = paths.ToDictionary(e => e.Key, e => e.Value);
        }
    }
}