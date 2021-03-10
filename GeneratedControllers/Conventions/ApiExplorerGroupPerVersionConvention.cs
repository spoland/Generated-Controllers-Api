using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GeneratedControllers.Conventions
{
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        /// <summary>
        /// Called to apply the convention to the <see cref="T:Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel" />.
        /// </summary>
        /// <param name="controller">The <see cref="T:Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel" />.</param>
        public void Apply(ControllerModel controller)
        {
            var controllerVersion = controller.Selectors[0].AttributeRouteModel.Template.Split("/")[1];
            var apiVersion = ApiVersion.Parse(controllerVersion);

            controller.ApiExplorer.GroupName = apiVersion.ToString();
        }
    }
}
