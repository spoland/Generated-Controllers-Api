using GeneratedControllers.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeneratedControllers.Contracts.v2
{
    /// <summary>
    /// An example manager model.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.IValidatableObject" />
    [GeneratedController("2.0")]
    public class Manager : IContract<int>, IValidatableObject
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }
}
