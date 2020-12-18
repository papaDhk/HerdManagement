using System;
using System.Collections.Generic;
using System.Text;

namespace HerdManagement.Domain.Common
{
    interface IValidator<T>
    {
        public ValidationResult Validate(T entityToValidate);
    }
}
