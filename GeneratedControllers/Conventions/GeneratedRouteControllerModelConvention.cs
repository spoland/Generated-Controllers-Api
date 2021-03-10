using GeneratedControllers.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;

namespace GeneratedControllers.Conventions
{
    public class GeneratedRouteControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                var generatedControllerAttribute = genericType.GetCustomAttribute<GeneratedControllerAttribute>();
                controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"api/{generatedControllerAttribute.ApiVersion}/[controller]s"));
            }
        }
    }
}
