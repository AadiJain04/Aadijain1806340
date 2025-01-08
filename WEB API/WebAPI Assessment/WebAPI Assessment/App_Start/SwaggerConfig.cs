using System.Web.Http;
using WebActivatorEx;
using WebAPI_Assessment;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebAPI_Assessment
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "WebAPI_Assessment"))
                .EnableSwaggerUi(); 
        }
    }
}