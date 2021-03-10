using System.Collections.Generic;

namespace GeneratedControllers.Swagger
{
    /// <summary>
    /// Swagger configuration options
    /// </summary>
    public class SwaggerConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerConfiguration"/> class.
        /// </summary>
        /// <param name="apiVersions">The API versions.</param>
        public SwaggerConfiguration(List<string> apiVersions)
        {
            ApiVersions = apiVersions;
        }

        /// <summary>
        /// Gets the API versions.
        /// </summary>
        public List<string> ApiVersions { get; }
    }
}
