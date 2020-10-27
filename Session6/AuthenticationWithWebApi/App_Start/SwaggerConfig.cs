using System.Web.Http;
using WebActivatorEx;
using AuthenticationWithWebApi;
using Swashbuckle.Application;
using AuthenticationWithWebApi.Filters;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace AuthenticationWithWebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "AuthenticationWithWebApi");
                        c.DocumentFilter<AuthTokenOperation>();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocExpansion(DocExpansion.None);
                        c.InjectJavaScript(thisAssembly, "AuthenticationWithWebApi.CustomerContent.swagger-basic-auth.js");
                    });
        }
    }
}
