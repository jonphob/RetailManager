using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace RetailManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token" , new PathItem
            {
                post = new Operation 
                {
                    tags = new List<string> { "Authorization" },
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            name = "grant_type",
                            @in = "formData",
                            required = true,
                            type = "string",
                            @default = "password"
                        },
                        new Parameter
                        {
                            name = "username",
                            @in = "formData",
                            required = true,
                            type = "string"
                        },
                        new Parameter
                        {
                            name = "password",
                            @in = "formData",
                            required = true,
                            type = "string"
                        }
                    },  
                }
            });
        }
    }
}