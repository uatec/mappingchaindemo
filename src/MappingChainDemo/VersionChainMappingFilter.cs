using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MappingChainDemo.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MappingChainDemo
{
    public class VersionChainMappingFilter : IActionFilter
    {
        VersionRegistration[] versionChain = new VersionRegistration[]
        {
            new VersionRegistration
            {
                Version = OrderVersions.V1,
            },
            new VersionRegistration
            {
                Version = OrderVersions.V2,
                Mapper = new V2Mapper()
            },
            new VersionRegistration
            {
                Version = OrderVersions.V3,
                Mapper = new V3Mapper()
            }
        };

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do nothing
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                string requestedVersion = (string)context.RouteData.Values["version"];

                foreach (VersionRegistration versionRegistration in versionChain.Reverse())
                {
                    if (versionRegistration.Version == requestedVersion) return;

                    objectResult.Value = versionRegistration.Mapper.DowngradeObject(objectResult.Value);
                }
            }
        }
    }
}