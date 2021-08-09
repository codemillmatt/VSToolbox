using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ToolboxFunctionOpen
{
    public static class GetAllVendors
    {
        [FunctionName("GetAllVendors")]
        [OpenApiOperation(operationId: "Run", Description ="Get all the vendors for vending stuff", Summary = "That about sums it about")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), 
            Description = "All of the vendors")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Vendor> allVendors = new List<Vendor>();
            allVendors.Add(new Vendor { Location = "Seattle", Name = "Seattle Vendor" });
            allVendors.Add(new Vendor { Location = "Redmond", Name = "Redmond Vendor" });

            return new OkObjectResult(allVendors);
        }
    }
}

