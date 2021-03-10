using GeneratedControllers.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GeneratedControllers.Conventions
{
    public class GeneratedNameControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType || controller.ControllerType.GetGenericTypeDefinition() != typeof(GeneratedControllerBase<,>))
            {
                return;
            }

            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = entityType.Name;
            controller.RouteValues["Controller"] = $"{entityType.Name}s";
        }
    }
}