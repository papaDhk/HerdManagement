using HerdManagement.Domain.Common;
using HerdEntity = HerdManagement.Domain.Herd.Entities.Herd;
namespace HerdManagement.Domain.Herd.Utils
{
    public class HerdValidator : IValidator<HerdEntity>
    {
        public ValidationResult Validate(HerdEntity herd)
        {
            ValidationResult validationResult = new ValidationResult();

            if (herd.Name == null)
            {
                validationResult.Errors.Add("NullNameError");
                validationResult.isValid = false;
            }
            else
            {
                validationResult.isValid = true;
            }
            return validationResult;
        }
    }
}
