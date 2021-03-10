using GeneratedControllers.Attributes;
using GeneratedControllers.Contracts;
using GeneratedControllers.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GeneratedControllers.FeatureProviders
{
    public class GeneratedControllerApplicationFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GeneratedControllerApplicationFeatureProvider).Assembly;

            var candidates = currentAssembly
                .GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IContract<>)))
                .Where(x => x.GetCustomAttributes(typeof(GeneratedControllerAttribute)).Any());

            foreach (var candidate in candidates)
            {
                var idType = candidate.GetInterface(typeof(IContract<>).Name).GenericTypeArguments[0];

                var controllerType = typeof(GeneratedControllerBase<,>);
                var controller = controllerType.MakeGenericType(candidate, idType);

                feature.Controllers.Add(
                    controller.GetTypeInfo()
                );
            }
        }
    }
}
