using Microsoft.AspNetCore.Mvc;
using System;

namespace GeneratedControllers.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public GeneratedControllerAttribute(string apiVersion)
        {
            ApiVersion = ApiVersion.Parse(apiVersion);
        }

        public ApiVersion ApiVersion { get; set; }
    }
}