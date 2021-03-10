using GeneratedControllers.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace GeneratedControllers.Conventions
{
    public class GenericRestControllerNameConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType || controller.ControllerType.GetGenericTypeDefinition() != typeof(GeneratedController<,>))
            {
                return;
            }

            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = entityType.Name;
            controller.RouteValues["Controller"] = $"{entityType.Name}s";
        }
    }
}